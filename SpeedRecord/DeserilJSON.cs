using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRecord
{
   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Direction
    {
        public bool IsEmpty { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Distances
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int ElapsedTime { get; set; }
        public double Speed { get; set; }
        public double SNR1 { get; set; }
        public double Distance { get; set; }
    }

    public class LastMetering
    {
        public DateTime DateTime { get; set; }
        public int ElapsedTime { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public double DistanceBegin { get; set; }
        public List<MeteringProfile> MeteringProfiles { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double HeightLeft { get; set; }
        public double HeightRight { get; set; }
        public int Tag1 { get; set; }
        public int Tag2 { get; set; }
        public bool IsExclude { get; set; }
    }

    public class Line
    {
       public Line2 Line2 { get; set; }
        public double Angle { get; set; }
        public double AngleHorizontal { get; set; }
    }

    public class Line2
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
        public Direction Direction { get; set; }
        public double Length { get; set; }
    }

    public class Metering
    {
        public DateTime DateTime { get; set; }
        public int ElapsedTime { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public double DistanceBegin { get; set; }
        public List<MeteringProfile> MeteringProfiles { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double HeightLeft { get; set; }
        public double HeightRight { get; set; }
        public int Tag1 { get; set; }
        public int Tag2 { get; set; }
        public bool IsExclude { get; set; }
    }

    public class MeteringProfile
    {
        public string ProfilometerId { get; set; }
        public int Id { get; set; }
        public List<Point> Points { get; set; }
        public List<Line> Lines { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int RangePointsCount { get; set; }
        public int TotalLengthVerticalLines { get; set; }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Spot { get; set; }
    }

    public class ProfilometerStatistic
    {
        public string Ip { get; set; }
        public double PointsAverage { get; set; }
        public int Strength { get; set; }
        public int Exposition { get; set; }
        public int Gain { get; set; }
        public string AnalogGain { get; set; }
        public string IpShort { get; set; }
        public string IpSide { get; set; }
    }

    public class Root
    {
        public string Id { get; set; }
        public string IdTrace { get; set; }
        public bool IsFeed { get; set; }
        public int SlabType { get; set; }
        public DateTime DateReceipt { get; set; }
        public DateTime DateTrace { get; set; }
        public DateTime DateMeasuring { get; set; }
        public object ImageTagRef { get; set; }
        public bool IsRecord { get; set; }
        public List<Metering> Meterings { get; set; }
        public List<State> States { get; set; }
        public List<Distances> Distances { get; set; }
        public int TraceXMin { get; set; }
        public int TraceXMax { get; set; }
        public double DistanceFactor { get; set; }
        public double OpticLengthFactor { get; set; }
        public double DeltaSpeed { get; set; }
        public double SpeedThreshold { get; set; }
        public double SNRThreshold { get; set; }
        public LastMetering LastMetering { get; set; }
        public int ExpositionAdapting { get; set; }
        public SwCyclogram swCyclogram { get; set; }
        public double TempVelocimeter { get; set; }
        public bool IsByPass { get; set; }
        public bool IsComplete { get; set; }
        public bool IsRollback { get; set; }
        public string CompleteDesc { get; set; }
        public int TempSlab { get; set; }
        public int VideoWriterId { get; set; }
        public int ProfileCount { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double WidthLeft { get; set; }
        public double WidthRight { get; set; }
        public double Height { get; set; }
        public double HeightLeft { get; set; }
        public double HeightRight { get; set; }
        public double HeightCalculate { get; set; }
        public double WidthPlan { get; set; }
        public double WidthCalculate { get; set; }
        public double LengthPlan { get; set; }
        public double LengthSeries { get; set; }
        public double LengthCalculate { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public int MinCountProfilePoints { get; set; }
        public int MaxCountProfilePoints { get; set; }
        public int AvgCountProfilePoints { get; set; }
        public List<ProfilometerStatistic> ProfilometerStatistics { get; set; }
        public bool isPlanFind { get; set; }
        public bool isSeriesSlabsFind { get; set; }
        public double SNR { get; set; }
    }

    public class State
    {
        public int ElapsedTime { get; set; }
        public string Series { get; set; }
        public int Sample { get; set; }
        public int Tag { get; set; }
        public int Value { get; set; }
    }

    public class SwCyclogram
    {
        public bool IsRunning { get; set; }
        public string Elapsed { get; set; }
        public int ElapsedMilliseconds { get; set; }
        public long ElapsedTicks { get; set; }
    }

}
