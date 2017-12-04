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
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using YamlDotNet.RepresentationModel;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet(VerbsCommon.Get, KubeNounStr + "Credential")]
    [OutputType(typeof(PSObject), typeof(List<PSObject>))]
    public class GetCredential : KubeCmdletBase
    {

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of your managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "Get the 'clusterAdmin' kubectl config instead of the default 'clusterUser'.")]
        public SwitchParameter Admin { get; set; } = false;

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A kubectl config file to create or update. Use '-' to print YAML to stdout instead.  Default: %Home%/.kube/config.")]
        public string ConfigPath { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                if (string.IsNullOrEmpty(ConfigPath))
                {
                    ConfigPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        ".kube",
                        "config");
                    WriteVerbose(string.Format("File was not specified. Writing credential to {0}.", ConfigPath));
                }

                WriteVerbose(Admin
                    ? "Fetching the clusterAdmin kubectl config"
                    : "Fetching the default clusterUser kubectl config");
                var accessProfile = Client.ManagedClusters.GetAccessProfiles(ResourceGroupName, Name,
                    Admin ? "clusterAdmin" : "clusterUser");

                var decodedKubeConfig = Encoding.UTF8.GetString(Convert.FromBase64String(accessProfile.KubeConfig));
                PrintOrMergeKubeConfig(decodedKubeConfig);
            });
        }

        private void PrintOrMergeKubeConfig(string config)
        {
            if (ConfigPath == "-")
            {
                WriteObject(config);
            }
            else
            {
                var dir = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var originalContent = "";
                if (File.Exists(ConfigPath))
                {
                    originalContent = File.ReadAllText(ConfigPath);
                }

                var newConfigYaml = new YamlStream();
                newConfigYaml.Load(new StringReader(config));

                var originalYaml = new YamlStream();
                originalYaml.Load(new StringReader(originalContent));

                WriteObject(newConfigYaml);
            }
        }


    }
}