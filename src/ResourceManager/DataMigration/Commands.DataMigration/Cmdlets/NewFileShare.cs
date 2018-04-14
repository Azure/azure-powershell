// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewFileShare.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationFileShare", SupportsShouldProcess = true), OutputType(typeof(MigrateSqlServerSqlDbDatabaseInput))]
    [Alias("New-AzureRmDmsFileShare")]
    public class NewFileShare : DataMigrationCmdlet
    {
        [Parameter(
                   Mandatory = true,
                   HelpMessage = "File share path."
               )]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Credentials to access the file share."
        )]
        public PSCredential Credential { get; set; }

        public override void ExecuteCmdlet()
        {
            var userName = Credential.UserName;
            var password = TaskCmdlet.Decrypt(Credential.Password);

            var fileShare = new FileShare
            {
                Path = Path,
                UserName = userName,
                Password = password
            };

            WriteObject(fileShare, false);
        }
    }
}
