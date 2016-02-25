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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    /// <summary>
    /// Enable or Disable boot diagnostics of a persistent VM object.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ProfileNouns.BootDiagnostics), OutputType(typeof(IPersistentVM))]
    public class SetAzureBootDiagnosticsCommand : VirtualMachineConfigurationCmdletBase
    {
        private const string EnableParameterSet = "EnableBootDiagnostics";
        private const string DisableParameterSet = "DisableBootDiagnostics";

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = EnableParameterSet,
            HelpMessage = HelpMessages.VMBootDiagnosticsEnable)]
        public SwitchParameter Enable { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = DisableParameterSet,
            HelpMessage = HelpMessages.VMBootDiagnosticsDisable)]
        public SwitchParameter Disable { get; set; }

        internal void ExecuteCommand()
        {
            var role = VM.GetInstance();
            if (role.DebugSettings == null)
            {
                role.DebugSettings = new DebugSettings();
            }
            role.DebugSettings.BootDiagnosticsEnabled = Enable.IsPresent;
            WriteObject(VM, true);
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }
}
