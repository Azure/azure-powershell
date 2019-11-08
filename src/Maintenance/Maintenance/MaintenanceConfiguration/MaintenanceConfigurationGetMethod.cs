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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MaintenanceConfiguration", DefaultParameterSetName = "DefaultParameter")]
    [OutputType(typeof(PSMaintenanceConfiguration))]
    public partial class GetAzureRmMaintenanceConfiguration : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string name = this.Name;

                if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(name))
                {
                    var result = MaintenanceConfigurationsClient.Get(resourceGroupName, name);
                    WriteObject(result);
                }

                else
                {
                    var psObject = new List<PSMaintenanceConfiguration>();
                    var result = MaintenanceConfigurationsClient.List();

                    foreach (var maintenanceConfiguration in result)
                    {
                        PSMaintenanceConfiguration psMaintenanceConfiguration = new PSMaintenanceConfiguration();
                        MaintenanceAutomationAutoMapperProfile.Mapper.Map<MaintenanceConfiguration, PSMaintenanceConfiguration>(maintenanceConfiguration, psMaintenanceConfiguration);
                        psObject.Add(psMaintenanceConfiguration);
                    }

                    WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }
    }
}
