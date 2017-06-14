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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.PersistentVMs
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteDesktopFile", DefaultParameterSetName = "Download"), OutputType(typeof(ManagementOperationContext))]
    public class GetAzureRemoteDesktopFileCommand : IaaSDeploymentManagementCmdletBase
    {

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the Role Instance or Virtual Machine Name to create/connect via RDP")]
        [ValidateNotNullOrEmpty]
        [Alias("InstanceName")]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Path and name of the output RDP file.", ParameterSetName = "Download")]
        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Path and name of the output RDP file.", ParameterSetName = "Launch")]
        [ValidateNotNullOrEmpty]
        public string LocalPath
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "Start a remote desktop session to the specified role instance.", ParameterSetName = "Launch")]
        public SwitchParameter Launch
        {
            get;
            set;
        }

        [SecurityPermission(SecurityAction.LinkDemand)]
        protected override void ExecuteCommand()
        {
            base.ExecuteCommand();
            if (CurrentDeploymentNewSM == null)
            {
                throw new ArgumentException(Resources.NoCloudServicePresent);
            }

            ManagementOperationContext context;
            string rdpFilePath = LocalPath ?? Path.GetTempFileName();
            WriteVerboseWithTimestamp(string.Format(Resources.AzureRemoteDesktopBeginOperation, CommandRuntime));
            var desktopFileResponse = this.ComputeClient.VirtualMachines.GetRemoteDesktopFile(this.ServiceName, CurrentDeploymentNewSM.Name, Name + "_IN_0");
            using (var stream = new MemoryStream(desktopFileResponse.RemoteDesktopFile))
            {
                using (var file = File.Create(rdpFilePath))
                {
                    int count;
                    byte[] buffer = new byte[1000];

                    while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, count);
                    }
                }

                var operation = GetOperation(desktopFileResponse.RequestId);

                WriteVerboseWithTimestamp(string.Format(Resources.AzureRemoteDesktopCompletedOperation, CommandRuntime));

                context = new ManagementOperationContext
                {
                    OperationDescription = CommandRuntime.ToString(),
                    OperationStatus = operation.Status.ToString(),
                    OperationId = operation.Id
                };
            }

            if (Launch.IsPresent)
            {
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                        
                if (LocalPath == null)
                {
                    string scriptGuid = Guid.NewGuid().ToString();

                    string launchRDPScript = Path.GetTempPath() + scriptGuid + ".bat";
                    using (var scriptStream = File.OpenWrite(launchRDPScript))
                    {
                        var writer = new StreamWriter(scriptStream);
                        writer.WriteLine("start /wait mstsc.exe " + rdpFilePath);
                        writer.Flush();
                    }

                    startInfo.FileName = launchRDPScript;
                }
                else
                {
                    startInfo.FileName = "mstsc.exe";
                    startInfo.Arguments = rdpFilePath;
                }

                Process.Start(startInfo);
            }

            WriteObject(context, true);
        }
    }
}