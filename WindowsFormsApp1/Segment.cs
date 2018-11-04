using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Segment : IComparable
    {
        public static List<Segment> AllSegments { get; set; } = new List<Segment>();

        public RecordData P1 { get; set; }
        public RecordData P2 { get; set; }
        public float AltitudeMin { get; set; }
        public float AltitudeMax { get; set; }
        public float AltitudeMoyenne { get; set; }

        public Segment (RecordData p1, RecordData p2)
        {
            P1 = p1;
            P2 = p2;

            AltitudeMin = Math.Min(P1.Z, P2.Z);
            AltitudeMax = Math.Max(P1.Z, P2.Z);
            AltitudeMoyenne = (P1.Z + P2.Z) / 2;

            AllSegments.Add(this);
        }

        public int CompareTo(object obj)
        {
            if (AltitudeMoyenne > ((Segment)obj).AltitudeMoyenne)
                return 1;
            else if (AltitudeMoyenne < ((Segment)obj).AltitudeMoyenne)
                return -1;
            else
                return 0;
        }
    }
}
