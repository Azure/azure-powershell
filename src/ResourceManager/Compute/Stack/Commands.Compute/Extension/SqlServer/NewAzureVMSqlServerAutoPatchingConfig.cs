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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Helper cmdlet to construct instance of AutoPatching settings class
    /// </summary>
    [Cmdlet(
         VerbsCommon.New,
         AzureVMSqlServerAutoPatchingConfigNoun),
     OutputType(
         typeof(AutoPatchingSettings))]
    public class NewAzureVMSqlServerAutoPatchingConfigCommand : PSCmdlet
    {
        protected const string AzureVMSqlServerAutoPatchingConfigNoun = "AzureVMSqlServerAutoPatchingConfig";

        [Parameter]
        public SwitchParameter Enable { get; set; }

        [Parameter]
        [ValidateSetAttribute(new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Everyday" })]
        public string DayOfWeek { get; set; }

        [Parameter]
        public int MaintenanceWindowStartingHour { get; set; }

        [Parameter]
        public int MaintenanceWindowDuration { get; set; }

        [Parameter]
        [ValidateSetAttribute(new string[] { "Important" })]
        public string PatchCategory { get; set; }

        /// <summary>
        /// Creates and returns <see cref="AutoPatchingSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            AutoPatchingSettings autoPatchingSettings = new AutoPatchingSettings();

            autoPatchingSettings.Enable = (Enable.IsPresent) ? Enable.ToBool() : false;
            autoPatchingSettings.DayOfWeek = DayOfWeek;
            autoPatchingSettings.MaintenanceWindowStartingHour = MaintenanceWindowStartingHour;
            autoPatchingSettings.MaintenanceWindowDuration = MaintenanceWindowDuration;
            autoPatchingSettings.PatchCategory = PatchCategory;

            WriteObject(autoPatchingSettings);
        }
    }
}
