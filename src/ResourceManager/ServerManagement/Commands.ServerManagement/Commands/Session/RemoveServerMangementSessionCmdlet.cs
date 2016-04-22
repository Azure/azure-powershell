using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Session
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmServerManagementSession")]
    public class RemoveServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session to delete.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }
        #endregion

        #region ByObject
        [Parameter(Mandatory = true, HelpMessage = "The session to delete.", ParameterSetName = "ByObject")]
        [ValidateNotNull]
        public Model.Session Session { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Session != null)
            {
                ResourceGroupName = Session.ResourceGroupName;
                NodeName = Session.NodeName;
                SessionName = Session.Name;
                WriteVerbose($"Using Session object for resourcegroup/node name/session name");
            }

            WriteVerbose($"Deleting session for {ResourceGroupName}/{NodeName}/{SessionName}");
            Client.Session.Delete(ResourceGroupName, NodeName, SessionName);
        }
    }
}