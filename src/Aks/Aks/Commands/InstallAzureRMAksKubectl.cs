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
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    [Cmdlet("Install", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksKubectl", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class InstallAzureRMAksKubectl : KubeCmdletBase
    {
        private const string LatestVersion = "Latest";
        private const string KubecliString = "kubectl";
        private const string KubecliExeString = "kubectl.exe";
        private const string KubecliSiteUrl = "https://storage.googleapis.com/kubernetes-release/release";
        private const string KubecliSiteUrlMirror = "https://mirror.azure.cn/kubernetes/kubectl";
        private const string KubecliPathFormat = "/{0}/bin/{1}/amd64/{2}";

        [Parameter(Mandatory = false, HelpMessage = "Path at which to install kubectl. Default to install into ~/.azure-kubectl/")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Version of kubectl to install, e.g. 'v1.17.2'. Default value: Latest")]
        public string Version { get; set; } = LatestVersion;

        [Parameter(Mandatory = false, HelpMessage = "Download from mirror site : https://mirror.azure.cn/kubernetes/kubectl/")]
        public SwitchParameter DownloadFromMirror { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Overwrite existing kubectl without prompt")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            bool fromMirror = DownloadFromMirror.IsPresent;
            StringBuilder sourceUrlBuilder = fromMirror ?
                new StringBuilder(KubecliSiteUrlMirror) :
                new StringBuilder(KubecliSiteUrl);

            if (!this.IsParameterBound(c => c.Destination))
            {
                Destination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".azure-kubectl");
            }

            bool isWindows = false;
            string destFilePath = null; 
            var webClient = new WebClient();

            if (string.Equals(LatestVersion, Version, StringComparison.InvariantCultureIgnoreCase))
            {
                Version = ReadLatestStableVersion(fromMirror, webClient);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                destFilePath = Path.Combine(Destination, KubecliExeString);
                sourceUrlBuilder.AppendFormat(KubecliPathFormat, Version, "windows", KubecliExeString);
                isWindows = true;
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                destFilePath = Path.Combine(Destination, KubecliString);
                sourceUrlBuilder.AppendFormat(KubecliPathFormat, Version, "linux", KubecliString);
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if(fromMirror)
                {
                    throw new AzPSArgumentException(
                        Resources.NoKubectlForOsxOnMirror,
                        nameof(DownloadFromMirror),
                        desensitizedMessage: Resources.NoKubectlForOsxOnMirror);
                }
                destFilePath = Path.Combine(Destination, KubecliString);
                sourceUrlBuilder.AppendFormat(KubecliPathFormat, Version, "darwin", KubecliString);
            }
            else
            {
                var ex = new PlatformNotSupportedException(Resources.NotSupportOnThisOs);
                ex.Data[AzurePSErrorDataKeys.ErrorKindKey] = ErrorKind.UserError;
                ex.Data[AzurePSErrorDataKeys.DesensitizedErrorMessageKey] = Resources.NotSupportOnThisOs;
                throw ex;
            }

            bool fileExists = File.Exists(destFilePath);

            Action action = () =>
            {
                //mkdir if not exist
                if (!Directory.Exists(Destination))
                {
                    WriteVerbose($"Creating directory {Destination}");
                    Directory.CreateDirectory(Destination);
                }

                //download to local, use tmp file if already exists
                var tempFile = fileExists ? destFilePath + ".tmp" : destFilePath;
                var sourceUrl = sourceUrlBuilder.ToString();
                WriteVerbose($"Downloading from {sourceUrl} to local : {tempFile}");
                webClient.DownloadFile(sourceUrl, tempFile);

                if (fileExists)
                {
                    WriteVerbose($"Deleting {destFilePath}");
                    File.Delete(destFilePath);
                    WriteVerbose($"Moving {tempFile} to {destFilePath}");
                    File.Move(tempFile, destFilePath);
                }

                WriteWarning(string.Format(Resources.AddDirectoryToPath,
                    Destination, isWindows ? KubecliExeString : KubecliString));

                if (PassThru)
                {
                    WriteObject(true);
                }
                webClient.Dispose();
            };

            var msg = $"{destFilePath}";
            if(fileExists)
            {
                ConfirmAction(Force.IsPresent,
                    string.Format(Resources.DoYouWantToOverwriteExistingFile, destFilePath),
                    Resources.DownloadingKubectlFromWeb,
                    msg,
                    action);
            }
            else
            {
                if(ShouldProcess(Resources.DownloadingKubectlFromWeb, msg))
                {
                    RunCmdLet(action);
                }
            }

        }

        private string ReadLatestStableVersion(bool useMirror, WebClient client)
        {
            var sourceUrl = useMirror ? KubecliSiteUrlMirror : KubecliSiteUrl;
            var versionFile = sourceUrl + "/stable.txt";

            WriteVerbose($"Get latest stable version for {versionFile}");
            var content = client.DownloadData(versionFile);
            var version = Encoding.UTF8.GetString(content);
            return version.Trim();
        }
    }
}
