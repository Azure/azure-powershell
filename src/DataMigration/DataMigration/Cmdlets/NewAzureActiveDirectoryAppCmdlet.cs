// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewAzureActiveDirectoryAppCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of AzureActiveDirectoryApp.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationAzureActiveDirectoryApp"), OutputType(typeof(PSAzureActiveDirectoryApp))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsAadApp")]
    public class NewAzureActiveDirectoryAppCmdlet : DataMigrationCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "Azure Active Directory Application Id")]
        [ValidateNotNullOrEmpty]
        [Alias("AppId")]
        public string ApplicationId { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Azure Active Directory Key")]
        [ValidateNotNullOrEmpty]
        [Alias("Key")]
        public SecureString AppKey { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSAzureActiveDirectoryApp aadApp = new PSAzureActiveDirectoryApp(this.DefaultContext.Tenant.Id)
            {
                ApplicationId = ApplicationId,
                AppKey = AppKey,
            };

            WriteObject(aadApp);
        }
    }
}
