using System;

namespace WindowsFormsApp1
{
    public class RecordData
    {
        public static RecordData MaxRecord = new RecordData(
            int.MinValue, DateTime.MinValue, float.MinValue, float.MinValue, float.MinValue);

        public static RecordData MinRecord = new RecordData(
            int.MaxValue, DateTime.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        

        public int ID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Time;
        public DateTime Date;

        public float NormalizedID { get; set; }
        public float NormalizedDate { get; set; }

        public RecordData (int id, DateTime date, float x, float y, float z)
        {
            ID = id;
            X = x;
            Y = y;
            Z = z;
            Date = date;

            if (MaxRecord != null && MinRecord != null)
            {
                if (MaxRecord.X < X)
                    MaxRecord.X = X;

                if (MaxRecord.Y < Y)
                    MaxRecord.Y = Y;

                if (MaxRecord.Z < Z)
                    MaxRecord.Z = Z;
            }

            if (MaxRecord != null && MinRecord != null)
            {
                if(MinRecord.X > X)
                    MinRecord.X = X;

                if(MinRecord.Y > Y)
                    MinRecord.Y = Y;

                if(MinRecord.Z > Z)
                    MinRecord.Z = Z;
            }

            if (MaxRecord != null && MinRecord != null)
            {
                if (MaxRecord.ID < ID)
                    MaxRecord.ID = ID;

                if (MinRecord.ID > ID)
                    MinRecord.ID = ID;
            }

            if (MaxRecord != null && MinRecord != null)
            {
                if (MaxRecord.Date < Date)
                    MaxRecord.Date = Date;

                if (MinRecord.Date > Date)
                    MinRecord.Date = Date;
            }
        }

        public RecordData()
        {
            //Empty
        }
    }
}
