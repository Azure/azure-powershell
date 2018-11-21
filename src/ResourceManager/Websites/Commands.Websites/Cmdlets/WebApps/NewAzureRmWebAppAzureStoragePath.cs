using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppAzureStoragePath", SupportsShouldProcess = true), OutputType(typeof(WebAppAzureStoragePath))]
    public class NewAzureRmWebAppAzureStoragePath: WebAppBaseClientCmdLet
    {
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the Azure Storage property. Must be unique within the Web App or Slot")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Type of Azure Storage account. Windows Containers only supports Azure Files")]
        [ValidateNotNullOrEmpty]
        public AzureStorageType Type { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Storage account name. E.g.: myfilestorageaccount.file.core.windows.net")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the share to mount to the container")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Access key to the Azure Storage account")]
        [ValidateNotNullOrEmpty]
        public string AccessKey { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Path in the container where the share specified by ShareName will be exposed")]
        [ValidateNotNullOrEmpty]
        public string MountPath { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new WebAppAzureStoragePath()
            {
                AccessKey = AccessKey,
                AccountName = AccountName,
                MountPath = MountPath,
                ShareName = ShareName,
                Type = Type,
                Name = Name
            });
        }
    }
}
