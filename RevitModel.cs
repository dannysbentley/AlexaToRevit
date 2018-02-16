using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Structure;

namespace AlexaToRevit
{
    class RevitModel
    {
        //***********************************GetWalls***********************************
        public List<Wall> GetWalls(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> Walls = collector.OfClass(typeof(Wall)).ToElements();
            List<Wall> List_Walls = new List<Wall>();
            foreach (Wall w in Walls)
            {
                List_Walls.Add(w);
            }
            return List_Walls;
        }

        //***********************************GetParameterValue***********************************
        public string GetParameterValue(Parameter parameter)
        {
            switch (parameter.StorageType)
            {
                case StorageType.Double:
                    //get value with unit, AsDouble() can get value without unit
                    return parameter.AsValueString();
                case StorageType.ElementId:
                    return parameter.AsElementId().IntegerValue.ToString();
                case StorageType.Integer:
                    //get value with unit, AsInteger() can get value without unit
                    return parameter.AsValueString();
                case StorageType.None:
                    return parameter.AsValueString();
                case StorageType.String:
                    return parameter.AsString();
                default:
                    return "";
            }
        }
    }
}
