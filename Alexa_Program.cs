using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaToRevit
{
    class Alexa_Program
    {
        //***********************************AlexaProgram***********************************
        public void AlexaProgram(Document doc)
        {
            RevitModel model = new RevitModel();
            CsvAlexaResponse csv = new CsvAlexaResponse(@"C:\Alexa\AlexaRead.csv");

            List<Wall> walls = model.GetWalls(doc);
            int count = walls.Count;
            double length = 0;
            double Volume = 0;

            DataRecords CountRecords = new DataRecords();
            DataRecords LengthRecords = new DataRecords();
            DataRecords VolumeRecords = new DataRecords();

            foreach (Element e in walls)
            {
                LocationCurve curve = e.Location as LocationCurve;
                Parameter parameterLength = e.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                Parameter parameterVolume = e.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                length = length + parameterLength.AsDouble();
                Volume = Volume + parameterVolume.AsDouble();
            }

            CountRecords.label = "Count";
            CountRecords.Total = count;

            LengthRecords.label = "Length";
            LengthRecords.Total = length;

            VolumeRecords.label = "Volume";
            VolumeRecords.Total = Volume;

            IList<DataRecords> dataRecords = new List<DataRecords>();
            dataRecords.Add(CountRecords);
            dataRecords.Add(LengthRecords);
            dataRecords.Add(VolumeRecords);

            csv.WriteFile(dataRecords);
        }
    }
}
