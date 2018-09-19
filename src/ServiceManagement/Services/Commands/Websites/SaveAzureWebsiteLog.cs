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

using System.IO;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Gets the azure logs.
    /// </summary>
    [Cmdlet(VerbsData.Save, "AzureWebsiteLog"), OutputType(typeof(bool))]
    public class SaveAzureWebsiteLogCommand : DeploymentBaseCmdlet
    {
        internal const string DefaultOutput = "./logs.zip";

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The logs output file.")]
        public string Output
        {
            get;
            set;
        }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the SaveAzureWebsiteLogCommand class.
        /// </summary>
        public SaveAzureWebsiteLogCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SaveAzureWebsiteLogCommand class.
        /// </summary>
        /// <param name="deploymentChannel">
        /// Channel used for communication with the git repository.
        /// </param>
        public SaveAzureWebsiteLogCommand(IDeploymentServiceManagement deploymentChannel)
        {
            DeploymentChannel = deploymentChannel;
        }

        internal string DefaultCurrentPath = null;
        internal string GetCurrentPath()
        {
            return SessionState != null ?
                SessionState.Path.CurrentFileSystemLocation.Path :
                DefaultCurrentPath;
        }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Output))
            {
                Output = Path.Combine(GetCurrentPath(), DefaultOutput);
            }
            else
            {
                // Set the file extension to .zip
                Output = Path.ChangeExtension(Output, "zip");
            }

            base.ExecuteCmdlet();

            // List new deployments
            Stream websiteLogs = null;
            InvokeInDeploymentOperationContext(() => { websiteLogs = DeploymentChannel.DownloadLogs(); });

            using (Stream file = File.OpenWrite(Output))
            {
                CopyStream(websiteLogs, file);
            }

            websiteLogs.Dispose();

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        internal static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
