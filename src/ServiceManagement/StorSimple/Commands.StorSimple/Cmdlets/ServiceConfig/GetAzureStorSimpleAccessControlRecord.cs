using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;
    using System.Collections.Generic;

    /// <summary>
    /// Get a list of Access Control Records present in the StorSimple Manager Service Configuration or retrieves a specific named ACR Object
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleAccessControlRecord"), OutputType(typeof(AccessControlRecord), typeof(IList<AccessControlRecord>))]
    public class GetAzureStorSimpleAccessControlRecord : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageACRName)]
        public string ACRName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var allACRs = StorSimpleClient.GetAllAccessControlRecords();
                if (ACRName == null)
                {
                    WriteObject(allACRs);
                    WriteVerbose(String.Format(Resources.ACRGet_StatusMessage, allACRs.Count, allACRs.Count > 1 ? "s" : String.Empty));
                    return;
                }
                
                var acr = allACRs.Where(x => x.Name.Equals(ACRName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (acr == null)
                {
                    WriteObject(null);
                    WriteVerbose(String.Format(Resources.NotFoundMessageACR,ACRName));
                }
                else
                {
                    WriteObject(acr);
                    WriteVerbose(String.Format(Resources.FoundMessageACR, ACRName));
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}