#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace AlexaToRevit
{
    class App : IExternalApplication
    {
        //***********************************OnStartup***********************************
        public Result OnStartup(UIControlledApplication a)
        {
            //Updater active using appication id. 
            //Updater updater = new Updater(a.ActiveAddInId); //Updater 

            //Register the updater
            //UpdaterRegistry.RegisterUpdater(updater);

            // Revit elements to trigger
            ElementClassFilter walls = new ElementClassFilter(typeof(Wall));
            //Set trigger to send to execute when modified, deleted, gemoetry change or anything. 
            //UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeElementAddition());
            //UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeElementDeletion());
            //UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeGeometry());
           // UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeAny());            

            return Result.Succeeded;
        }

        //***********************************OnShutdown***********************************
        public Result OnShutdown(UIControlledApplication a)
        {
            // Close registeration. 
            //Updater updater = new Updater(a.ActiveAddInId);
            //UpdaterRegistry.UnregisterUpdater(updater.GetUpdaterId());

            return Result.Succeeded;
        }
    }
}
