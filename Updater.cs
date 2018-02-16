using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaToRevit
{
    class Updater : IUpdater
    {
        //public static bool m_updateActive = true;
        static AddInId m_appId;
        static UpdaterId m_updaterId;

        //***********************************Updater***********************************
        public Updater(AddInId id)
        {
            m_appId = id;
            m_updaterId = new UpdaterId(m_appId, new Guid("75760920-bda2-4bb6-804d-b0e5b11ff950"));
        }

        //***********************************Execute***********************************
        public void Execute(UpdaterData data)
        {
            Document doc = data.GetDocument();

            var modifiedIds = data.GetModifiedElementIds();
            var addedIds = data.GetAddedElementIds();

            Alexa_Program program = new Alexa_Program();
            program.AlexaProgram(doc);
        }

        //***********************************GetAdditionalInformation***********************************
        public string GetAdditionalInformation()
        {
            return "Wall type updater example: updates csv file database";
        }

        //***********************************GetChangePriority***********************************
        public ChangePriority GetChangePriority()
        {
            return ChangePriority.FloorsRoofsStructuralWalls;
        }

        //***********************************GetUpdaterId***********************************
        public UpdaterId GetUpdaterId()
        {
            return m_updaterId;
        }

        //***********************************GetUpdaterName***********************************
        public string GetUpdaterName()
        {
            return "Wall Updater";
        }
    }
}
