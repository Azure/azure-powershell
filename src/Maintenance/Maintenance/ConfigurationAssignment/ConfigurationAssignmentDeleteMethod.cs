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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ConfigurationAssignment", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSConfigurationAssignment))]
    public partial class RemoveAzureRmConfigurationAssignment : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.ConfigurationAssignmentName, VerbsCommon.Remove)
                    && (this.Force.IsPresent ||
                        this.ShouldContinue(Properties.Resources.ResourceRemovalConfirmation,
                                            "Remove-AzConfigurationAssignment operation")))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string providerName = this.ProviderName;
                    string resourceParentType = this.ResourceParentType;
                    string resourceParentName = this.ResourceParentName;
                    string resourceType = this.ResourceType;
                    string resourceName = this.ResourceName;
                    string configurationAssignmentName = this.ConfigurationAssignmentName;

                    var result = (!string.IsNullOrEmpty(resourceParentType) && !string.IsNullOrEmpty(resourceParentName)) ?
                        ConfigurationAssignmentsClient.DeleteParent(resourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName) :
                        ConfigurationAssignmentsClient.Delete(resourceGroupName, providerName, resourceType, resourceName, configurationAssignmentName);

                    var psObject = new PSConfigurationAssignment();
                    MaintenanceAutomationAutoMapperProfile.Mapper.Map<ConfigurationAssignment, PSConfigurationAssignment>(result, psObject);
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
        public string ProviderName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceParentType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceParentName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 5,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 6,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 7,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ConfigurationAssignmentName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
