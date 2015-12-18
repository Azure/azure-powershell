using System;
using System.Net.PeerToPeer.Collaboration;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightScriptAction
    {
        public AzureHDInsightScriptAction(ScriptAction action)
        {
            ActionName = action.Name;
            Uri = action.Uri;
            Parameters = action.Parameters;
        }

        public AzureHDInsightScriptAction()
        {
        }

        public ScriptAction GetScriptActionFromPSModel()
        {
            var param = "";
            if (Parameters != null)
            {
                param = Parameters;
            }
            return new ScriptAction(ActionName, Uri, param);
        }

        public string ActionName { get; set; }

        public Uri Uri { get; set; }

        public string Parameters { get; set; }
    }
}
