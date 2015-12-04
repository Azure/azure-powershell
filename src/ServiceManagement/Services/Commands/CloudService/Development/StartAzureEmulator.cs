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
using System.IO;
using System.Management.Automation;
using System.Security.Principal;
using System.Text;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService.Development
{
    /// <summary>
    /// Runs the service in the emulator
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureEmulator"), OutputType(typeof(CloudServiceProject))]
    public class StartAzureEmulatorCommand : AzureSMCmdlet
    {
        [Parameter(Mandatory = false)]
        [Alias("ln")]
        public SwitchParameter Launch { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The emulator type")]
        public ComputeEmulatorMode Mode { get; set; }

        public CloudServiceProject StartAzureEmulatorProcess(string rootPath)
        {
            string warning;
            string roleInformation;

            StringBuilder message = new StringBuilder();
            CloudServiceProject cloudServiceProject = new CloudServiceProject(rootPath, null);

            if (Directory.Exists(cloudServiceProject.Paths.LocalPackage))
            {
                WriteVerbose(Resources.StopEmulatorMessage);
                cloudServiceProject.StopEmulators(out warning);
                if (!string.IsNullOrEmpty(warning))
                {
                    WriteWarning(warning);
                }
                WriteVerbose(Resources.StoppedEmulatorMessage);
                string packagePath = cloudServiceProject.Paths.LocalPackage;
                WriteVerbose(string.Format(Resources.RemovePackage, packagePath));
                try
                {
                    Directory.Delete(packagePath, true);
                }
                catch (IOException)
                {
                    throw new InvalidOperationException(string.Format(Resources.FailedToCleanUpLocalPackage, packagePath));
                }
            }

            WriteVerbose(string.Format(Resources.CreatingPackageMessage, "local"));
            cloudServiceProject.CreatePackage(DevEnv.Local);

            WriteVerbose(Resources.StartingEmulator);
            cloudServiceProject.ResolveRuntimePackageUrls();
            cloudServiceProject.StartEmulators(Launch.ToBool(), Mode, out roleInformation, out warning);
            WriteVerbose(roleInformation);
            if (!string.IsNullOrEmpty(warning))
            {
                WriteWarning(warning);
            }

            WriteVerbose(Resources.StartedEmulator);
            SafeWriteOutputPSObject(
                cloudServiceProject.GetType().FullName,
                Parameters.ServiceName, cloudServiceProject.ServiceName,
                Parameters.RootPath, cloudServiceProject.Paths.RootPath);

            return cloudServiceProject;
        }

        public override void ExecuteCmdlet()
        {
            AzureTool.Validate();
            if (!IsRunningElevated())
            {
                throw new PSArgumentException(Resources.AzureEmulatorNotRunningElevetaed);
            }
            base.ExecuteCmdlet();
            StartAzureEmulatorProcess(CommonUtilities.GetServiceRootPath(CurrentPath()));
        }

        private bool IsRunningElevated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}