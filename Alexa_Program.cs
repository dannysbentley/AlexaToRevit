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
            List<FamilyInstance> specialtyEquipment = model.GetFamilyInstance(doc, BuiltInCategory.OST_SpecialityEquipment);
            List<FamilyInstance> MEPsystem = model.GetFamilyInstance(doc, BuiltInCategory.OST_MechanicalEquipment);

            int WallCount = walls.Count;
            int SpecEquipCount = specialtyEquipment.Count;
            int MEPCount = MEPsystem.Count;

            double length = 0;
            double Volume = 0;
            //data objects. 
            DataRecords CountWallRecords = new DataRecords();
            DataRecords LengthWallRecords = new DataRecords();
            DataRecords VolumeWallRecords = new DataRecords();
            DataRecords CountSpecialEquipRecords = new DataRecords();
            DataRecords CountMEPRecords = new DataRecords();

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
            CountWallRecords.label = "Wall Count";
            CountWallRecords.Count = WallCount;

            LengthWallRecords.label = "Wall Length";
            LengthWallRecords.Count = length;

            VolumeWallRecords.label = "Wall Volume";
            VolumeWallRecords.Count = Volume;

            CountSpecialEquipRecords.label = "Specialty Equipment Count";
            CountSpecialEquipRecords.Count = SpecEquipCount;

            CountMEPRecords.label = "MEP Count";
            CountMEPRecords.Count = MEPCount;

            // Add data objects to list 
            IList<DataRecords> dataRecords = new List<DataRecords>();
            dataRecords.Add(CountWallRecords);
            dataRecords.Add(LengthWallRecords);
            dataRecords.Add(VolumeWallRecords);

            dataRecords.Add(CountSpecialEquipRecords);
            dataRecords.Add(CountMEPRecords);
            //write to database .csv file. 
            csv.WriteFile(dataRecords);
        }
    }
}
