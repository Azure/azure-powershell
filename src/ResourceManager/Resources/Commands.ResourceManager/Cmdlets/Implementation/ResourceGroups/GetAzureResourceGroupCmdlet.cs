﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using System.Reflection;
    using WindowsAzure.Commands.Common;

    /// <summary>
    /// Filters resource groups.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmResourceGroup", DefaultParameterSetName = ResourceGroupNameParameterSet), OutputType(typeof(List<PSResourceGroup>))]
    public class GetAzureResourceGroupCmdlet : ResourceManagerCmdletBase, IModuleAssemblyInitializer
    {
        /// <summary>
        /// List resources group by name parameter set.
        /// </summary>
        internal const string ResourceGroupNameParameterSet = "Lists the resource group based on the name.";

        /// <summary>
        /// List resources group by Id parameter set.
        /// </summary>
        internal const string ResourceGroupIdParameterSet = "Lists the resource group based on the Id.";

        [Alias("ResourceGroupName")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = ResourceGroupNameParameterSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("ResourceGroupId", "ResourceId")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group Id.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            Name = Name ?? ResourceIdentifier.FromResourceGroupIdentifier(this.Id).ResourceGroupName;

            this.WriteObject(
                ResourceManagerSdkClient.FilterResourceGroups(name: this.Name, tag: null, detailed: false, location: this.Location),
                true);
        }

        /// <summary>
        /// Load global aliases and script cmdlets for ARM
        /// </summary>
        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "ResourceManagerStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // need to fix exception in WriteDebug
                // this.WriteDebug("Exception on importing ResourceManagerStartup.ps1: " + e.Message);
            }
        }
    }
}