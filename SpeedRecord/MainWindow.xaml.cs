using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DV = System.Windows.Forms.DataVisualization;
using WinForms = System.Windows.Forms;

namespace SpeedRecord
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> listJson;
        public MainWindow()
        {
            InitializeComponent();
            listJson = new Dictionary<string, string>();

            ChartS.Series[0].Color = System.Drawing.Color.Red;
            ChartS.Series[1].Color = System.Drawing.Color.Green;


            listElements.SelectionChanged += listElements_SelectionChanged;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            WinForms.FolderBrowserDialog folderBrowserDialog = new WinForms.FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == WinForms.DialogResult.Cancel) return;
            // MessageBox.Show(folderBrowserDialog.SelectedPath);
            string[] allfiles = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.json");
            foreach (string file in allfiles)
            {
                string[] labl = file.Split('\\');
                listElements.Items.Add(labl[labl.Length - 1]);
                listJson.Add(labl[labl.Length - 1], file);
            }
        }

        private void listElements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawChart(listJson[(string)listElements.SelectedItem]);
        }

        private void DrawChart(string path)
        {
            string str = File.ReadAllText(path);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(str);
           

            ChartS.Series[0].Points.Clear();
            ChartS.Series[1].Points.Clear();

            if((bool)rbKalman.IsChecked) Kalman(myDeserializedClass);
            else if ((bool)rbMNK.IsChecked)
            {
                MNK mnk = new MNK();
                mnk.MakeSystem(myDeserializedClass.Distances)
            }

         
        }

        void Kalman(Root myDeserializedClass)
        {
            double min = double.MaxValue;
            double max = double.MinValue;

            var filtered = new List<double>();

            var kalman = new KalmanFilterSimple1D(f: 1, h: 1, q: 2, r: 15); // задаем F, H, Q и R
            kalman.SetState(myDeserializedClass.Distances[0].Speed, 0.1); // Задаем начальные значение State и Covariance


            foreach (Distances distances in myDeserializedClass.Distances)
            {
                //double point = distances.Distance / distances.Speed;
                double point = distances.Speed;
                if (distances.Distance < min) min = point;
                if (distances.Distance > max) max = point;

                kalman.Correct(point); // Применяем алгоритм

                filtered.Add(kalman.State); // Сохраняем текущее состояние 

                if ((bool)chbFilter.IsChecked)
                {
                    ChartS.Series[0].Points.Add(kalman.State).AxisLabel = distances.Distance.ToString();
                    ChartS.Series[1].Points.Add(point).AxisLabel = distances.Distance.ToString();
                }
                else ChartS.Series[1].Points.Add(point).AxisLabel = distances.Distance.ToString();
            }
        }

    }
}
