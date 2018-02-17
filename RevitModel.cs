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
            //filter element collector to quickly get all the walls. 
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> Walls = collector.OfClass(typeof(Wall)).ToElements();

            List<Wall> List_Walls = new List<Wall>();
            // Add all walls to a list 
            foreach (Wall w in Walls)
            {
                List_Walls.Add(w);
            }
            // Return walls. 
            return List_Walls;
        }

        //***********************************GetFamilyInstance***********************************
        public List<FamilyInstance> GetFamilyInstance(Document doc, BuiltInCategory category)
        {
            List<FamilyInstance> List_FamilyInstance = new List<FamilyInstance>();

            ElementClassFilter familyInstanceFilter = new ElementClassFilter(typeof(FamilyInstance));
            // Category filter 
            ElementCategoryFilter Categoryfilter = new ElementCategoryFilter(category);
            // Instance filter 
            LogicalAndFilter InstancesFilter = new LogicalAndFilter(familyInstanceFilter, Categoryfilter);

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            // Colletion Array of Elements
            ICollection<Element> Elements = collector.WherePasses(InstancesFilter).ToElements();

            foreach (Element e in Elements)
            {
                FamilyInstance familyInstance = e as FamilyInstance;

                if (null != familyInstance)
                {
                    try
                    {
                        List_FamilyInstance.Add(familyInstance);
                    }
                    catch (Exception ex)
                    {
                        string x = ex.Message;
                    }
                }
            }
            return List_FamilyInstance;
        }
    }
}
