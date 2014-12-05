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
    /// Get a list of Storage accounts from the StorSimple Service config or retrieves a specified Storage Account Cred
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleStorageAccountCredential"), OutputType(typeof(StorageAccountCredential), typeof(IList<StorageAccountCredential>))]
    public class GetAzureStorSimpleStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountName)]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var allSACs = StorSimpleClient.GetAllStorageAccountCredentials();
                if (StorageAccountName == null)
                {
                    WriteObject(allSACs);
                    return;
                }
                
                var sac = allSACs.Where(x => x.Name.Equals(StorageAccountName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (sac == null)
                {
                    WriteVerbose(Resources.NotFoundMessageStorageAccount);
                }
                else
                {
                    WriteObject(sac);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}