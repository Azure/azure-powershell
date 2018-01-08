// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewDatabaseInfoCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of the Sql Server Connection Info.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationDatabaseInfo", SupportsShouldProcess = true), OutputType(typeof(DatabaseInfo))]
    [Alias("New-AzureRmDmsDBInfo")]
    public class NewDatabaseInfoCmdlet : DataMigrationCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "Source Database Name."
               )]
        [ValidateNotNullOrEmpty]
        [Alias("SourceDBName")]
        public string SourceDatabaseName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.SourceDatabaseName, Resources.createDbInfo))
            {
                base.ExecuteCmdlet();

                DatabaseInfo dbInfo = new DatabaseInfo();
                dbInfo.SourceDatabaseName = SourceDatabaseName;

                WriteObject(dbInfo);
            }
        }
    }
}
