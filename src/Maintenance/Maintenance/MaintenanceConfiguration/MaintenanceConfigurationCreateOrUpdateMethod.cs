// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using Newtonsoft.Json;
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

                    if (this.StartDateTime != null)
                    {
                        configuration.StartDateTime = this.StartDateTime;
                    }

                    if (this.ExpirationDateTime != null)
                    {
                        configuration.ExpirationDateTime = this.ExpirationDateTime;
                    }

                    if (this.Duration != null)
                    {
                        configuration.Duration = this.Duration.ToString((@"hh\:mm"));
                    }

                    if (this.Timezone != null)
                    {
                        configuration.TimeZone = this.Timezone;
                    }

                    if (this.RecurEvery != null)
                    {
                        configuration.RecurEvery = this.RecurEvery;
                    }

                    if (this.Visibility != null)
                    {
                        configuration.Visibility = this.Visibility;
                    }

                    if (this.InstallPatchRebootSetting != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.RebootSetting = this.InstallPatchRebootSetting;
                    }

                    if (this.WindowParameterClassificationToInclude != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.WindowsParameters = configuration.InstallPatches.WindowsParameters ?? new InputWindowsParameters();
                        configuration.InstallPatches.WindowsParameters.ClassificationsToInclude = this.WindowParameterClassificationToInclude.ToList();
                    }

                    if (this.WindowParameterExcludeKbRequiringReboot.HasValue)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.WindowsParameters = configuration.InstallPatches.WindowsParameters ?? new InputWindowsParameters();
                        configuration.InstallPatches.WindowsParameters.ExcludeKbsRequiringReboot = this.WindowParameterExcludeKbRequiringReboot;
                    }

                    if (this.WindowParameterKbNumberToExclude != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.WindowsParameters = configuration.InstallPatches.WindowsParameters ?? new InputWindowsParameters();
                        configuration.InstallPatches.WindowsParameters.KbNumbersToExclude = this.WindowParameterKbNumberToExclude.ToList();
                    }

                    if (this.WindowParameterKbNumberToInclude != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.WindowsParameters = configuration.InstallPatches.WindowsParameters ?? new InputWindowsParameters();
                        configuration.InstallPatches.WindowsParameters.KbNumbersToInclude = this.WindowParameterKbNumberToInclude.ToList();
                    }

                    if (this.LinuxParameterClassificationToInclude!= null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.LinuxParameters = configuration.InstallPatches.LinuxParameters ?? new InputLinuxParameters();
                        configuration.InstallPatches.LinuxParameters.ClassificationsToInclude = this.LinuxParameterClassificationToInclude.ToList();
                    }

                    if (this.LinuxParameterPackageNameMaskToExclude != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.LinuxParameters = configuration.InstallPatches.LinuxParameters ?? new InputLinuxParameters();
                        configuration.InstallPatches.LinuxParameters.PackageNameMasksToExclude= this.LinuxParameterPackageNameMaskToExclude.ToList();
                    }

                    if (this.LinuxParameterPackageNameMaskToInclude != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.LinuxParameters = configuration.InstallPatches.LinuxParameters ?? new InputLinuxParameters();
                        configuration.InstallPatches.LinuxParameters.PackageNameMasksToInclude= this.LinuxParameterPackageNameMaskToInclude.ToList();
                    }

                    if (this.PreTask != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.PreTasks = JsonConvert.DeserializeObject<List<TaskProperties>>(this.PreTask);
                    }

                    if (this.PostTask != null)
                    {
                        configuration.InstallPatches = configuration.InstallPatches ?? new InputPatchConfiguration();
                        configuration.InstallPatches.PreTasks = JsonConvert.DeserializeObject<List<TaskProperties>>(this.PostTask);
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
            Position = 0,
            Mandatory = true,
            HelpMessage = "The resource Group Name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            HelpMessage = "The maintenance configuration Name.",
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            HelpMessage = "The maintenance configuration location.",
            ValueFromPipelineByPropertyName = true)]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ARM Tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Extension properties per resource.")]
        public Hashtable ExtensionProperty { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Maintenance Scope.")]
        public string MaintenanceScope { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The StartDateTime in format YYYY-MM-DD hh:mm")]
        public string StartDateTime { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ExpirationDateTime in format YYYY-MM-DD hh:mm")]
        public string ExpirationDateTime { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Timezone")]
        public string Timezone { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Duration")]
        public TimeSpan Duration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Visibility")]
        public string Visibility { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Recurrence interval.")]
        public string RecurEvery { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of packages to include during vm patch operation")]
        public HashSet<string> LinuxParameterPackageNameMaskToInclude { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of packages to exclude during vm patch operation")]
        public HashSet<string> LinuxParameterPackageNameMaskToExclude { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of linux patch classifications")]
        public HashSet<string> LinuxParameterClassificationToInclude { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of KBs to include during vm patch operation")]
        public HashSet<string> WindowParameterKbNumberToInclude { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of KBs to exclude during vm patch operationn")]
        public HashSet<string> WindowParameterKbNumberToExclude { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of windows patch classification")]
        public HashSet<string> WindowParameterClassificationToInclude { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Exclude KBs which require reboot")]
        public bool? WindowParameterExcludeKbRequiringReboot { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of tasks executed before schedule. e.g. [{'source' :'runbook', 'taskScope': 'Global', 'parameters': { 'arg1': 'value1'}}]")]
        public string PreTask { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of tasks executed after schedule. [{'source' :'runbook', 'taskScope': 'Resource', 'parameters': { 'arg1': 'value1'}}]")]
        public string PostTask { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Install Patch Reboot Option. Allowed values Never, IfRequired, Always")]
        public string InstallPatchRebootSetting { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
