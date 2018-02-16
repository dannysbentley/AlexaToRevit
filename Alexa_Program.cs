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
            // Revit model object.
            RevitModel model = new RevitModel();
            CsvAlexaResponse csv = new CsvAlexaResponse(@"C:\Alexa\AlexaRead.csv"); // databaase file path
            // Collect wall the walls
            List<Wall> walls = model.GetWalls(doc);
            int count = walls.Count;
            double length = 0;
            double Volume = 0;
            //data objects. 
            DataRecords CountRecords = new DataRecords();
            DataRecords LengthRecords = new DataRecords();
            DataRecords VolumeRecords = new DataRecords();
            // iterate over the walls to calculate the total length
            foreach (Element e in walls)
            {
                // Get the curve from the wall. 
                LocationCurve curve = e.Location as LocationCurve;
                // Use the Built In Parameter for length and volumn 
                Parameter parameterLength = e.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                Parameter parameterVolume = e.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                length = length + parameterLength.AsDouble();
                Volume = Volume + parameterVolume.AsDouble();
            }

            // populate data objects with data. 
            CountRecords.label = "Count";
            CountRecords.Total = count;

            LengthRecords.label = "Length";
            LengthRecords.Total = length;

            VolumeRecords.label = "Volume";
            VolumeRecords.Total = Volume;
            // Add data objects to list 
            IList<DataRecords> dataRecords = new List<DataRecords>();
            dataRecords.Add(CountRecords);
            dataRecords.Add(LengthRecords);
            dataRecords.Add(VolumeRecords);
            //write to database .csv file. 
            csv.WriteFile(dataRecords);
        }
    }
}
