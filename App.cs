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
            //Updater updater = new Updater(a.ActiveAddInId); //Updater 

            //UpdaterRegistry.RegisterUpdater(updater);

            ElementClassFilter walls = new ElementClassFilter(typeof(Wall));
            //Set trigger to send to execute when modified
            //UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeElementAddition());
            //UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeElementDeletion());
            //UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeGeometry());
           // UpdaterRegistry.AddTrigger(updater.GetUpdaterId(), walls, Element.GetChangeTypeAny());            

            return Result.Succeeded;
        }

        //***********************************OnShutdown***********************************
        public Result OnShutdown(UIControlledApplication a)
        {
            //Updater updater = new Updater(a.ActiveAddInId);
            //UpdaterRegistry.UnregisterUpdater(updater.GetUpdaterId());

            return Result.Succeeded;
        }
    }
}
