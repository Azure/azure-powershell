//-----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Refer to the class documentation.
// </summary>
//-----------------------------------------------------------------------

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Maintenance
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MaintenanceConfiguration", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSMaintenanceConfiguration))]
    public partial class NewAzureRmMaintenanceConfiguration : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string resourceName = this.Name;
                    MaintenanceConfiguration configuration = new MaintenanceConfiguration();
                    if (this.Location != null)
                    {
                        configuration.Location = this.Location;
                    }
                    if (this.Tag != null)
                    {
                        configuration.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }

                    if (this.ExtensionProperty != null)
                    {
                        configuration.ExtensionProperties = this.ExtensionProperty.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }
                    if (this.MaintenanceScope != null)
                    {
                        configuration.MaintenanceScope = this.MaintenanceScope;
                    }

                    var result = MaintenanceConfigurationsClient.CreateOrUpdate(resourceGroupName, resourceName, configuration);
                    var psObject = new PSMaintenanceConfiguration();
                    MaintenanceAutomationAutoMapperProfile.Mapper.Map<MaintenanceConfiguration, PSMaintenanceConfiguration>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false)]
        [AllowNull]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false)]
        [AllowNull]
        public Hashtable ExtensionProperty { get; set; }

        [Parameter(
            Mandatory = false)]
        [AllowNull]
        public string MaintenanceScope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
