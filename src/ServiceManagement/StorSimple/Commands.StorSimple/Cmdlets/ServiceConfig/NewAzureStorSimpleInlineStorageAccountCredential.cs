using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Properties;

    /// <summary>
    /// Create Storage Account Credential to be added inline during Volume Container creation
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleInlineStorageAccountCredential"),
     OutputType(typeof (StorageAccountCredentialResponse))]

    public class NewAzureStorSimpleInlineStorageAccountCredential : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Alias("Key")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorageAccountKey)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageEndpoint)]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                string endpoint = String.IsNullOrEmpty(Endpoint) ? Constants.DefaultEndpoint : Endpoint;

                var sac = new StorageAccountCredentialResponse()
                {
                    CloudType = CloudType.Azure,
                    Hostname = GetHostnameFromEndpoint(endpoint),
                    Login = StorageAccountName,
                    Password = StorageAccountKey,
                    UseSSL = true,
                    Name = StorageAccountName
                };

                WriteObject(sac);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

