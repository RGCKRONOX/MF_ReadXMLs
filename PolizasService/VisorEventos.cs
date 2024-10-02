using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXMLPremium
{
    internal class VisorEventos
    {
        string application = "LecturaXMLPremium";
        string EventLogName = "LecturaXMLPremium";
        public EventLog el;

        public VisorEventos()
        {
            this.verificaRegistro();
        }

        public void verificaRegistro()
        {
            Registro r = new Registro("SYSTEM\\ControlSet001\\Services\\EventLog\\LecturaXMLPremium", "local_machine");
            if (!r.VerificaSiExisteClave("Sources"))
            {
                r.guardaLlave("Sources", new string[] { });
            }
        }

        public void verificaEventLogs()
        {
            //if (!EventLog.Exists(this.application))
            //{
            this.el = new EventLog(application);
            this.el.Source = this.EventLogName;
            //}
        }

        public void addInfoLog(string message)
        {
            this.el.WriteEntry(message, EventLogEntryType.Information);
        }

        public void addErrorLog(string error)
        {
            this.el.WriteEntry(error, EventLogEntryType.Error);
        }
    }
}
