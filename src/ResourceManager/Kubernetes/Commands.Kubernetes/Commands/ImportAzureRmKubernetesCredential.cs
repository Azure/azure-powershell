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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using YamlDotNet.RepresentationModel;

namespace Microsoft.Azure.Commands.Kubernetes
{
    [Cmdlet("Import", KubeNounStr + "Credential")]
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
            HelpMessage =
                "A kubectl config file to create or update. Use '-' to print YAML to stdout instead.  Default: %Home%/.kube/config.")]
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
                if (ConfigPath == "-")
                {
                    WriteObject(decodedKubeConfig);
                }
                else
                {
                    MergeAndWriteKubeConfig(decodedKubeConfig);
                }
            });
        }

        public void MergeAndWriteKubeConfig(string config)
        {
            var dir = Path.GetDirectoryName(ConfigPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(ConfigPath))
            {
                WriteVerbose(string.Format("No config file located at {0}. Creating Kube config.", ConfigPath));
                File.WriteAllText(ConfigPath, config);
            }
            else
            {
                var mergedConfig = MergeKubeConfig(File.ReadAllText(ConfigPath), config);
                File.WriteAllText(ConfigPath, mergedConfig);
            }
        }

        public static string MergeKubeConfig(string original, string additions)
        {
            var originalYaml = new YamlStream();
            originalYaml.Load(new StringReader(original));

            var newConfigYaml = new YamlStream();
            newConfigYaml.Load(new StringReader(additions));

            var originalMapping = (YamlMappingNode) originalYaml.Documents[0].RootNode;
            var newMapping = (YamlMappingNode) newConfigYaml.Documents[0].RootNode;

            var mergedClusters = MergeNamedItems(originalMapping, newMapping, "clusters");
            originalMapping.Children.Remove(new YamlScalarNode("clusters"));
            originalMapping.Children.Add(new YamlScalarNode("clusters"), mergedClusters);

            var mergedUsers = MergeNamedItems(originalMapping, newMapping, "users");
            originalMapping.Children.Remove(new YamlScalarNode("users"));
            originalMapping.Children.Add(new YamlScalarNode("users"), mergedUsers);

            var mergedContexts = MergeNamedItems(originalMapping, newMapping, "contexts");
            originalMapping.Children.Remove(new YamlScalarNode("contexts"));
            originalMapping.Children.Add(new YamlScalarNode("contexts"), mergedContexts);

            originalMapping.Children.Remove(new YamlScalarNode("current-context"));
            originalMapping.Children.Add(new YamlScalarNode("current-context"),
                newMapping.Children[new YamlScalarNode("current-context")]);

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            originalYaml.Save(sw, false);
            return sb.ToString();
        }

        private static YamlSequenceNode MergeNamedItems(YamlMappingNode original, YamlMappingNode addition, string key)
        {
            var origNamedItems = (YamlSequenceNode) original[new YamlScalarNode(key)];
            var newNamedItems = (YamlSequenceNode) addition[new YamlScalarNode(key)];

            var namedItems = new Dictionary<string, YamlMappingNode>();
            origNamedItems
                .Children
                .Cast<YamlMappingNode>()
                .ForEach(x =>
                {
                    var nameNode = (YamlScalarNode) x.Children[new YamlScalarNode("name")];
                    if (!namedItems.ContainsKey(nameNode.Value)) namedItems.Add(nameNode.Value, x);
                });

            newNamedItems
                .Children
                .Cast<YamlMappingNode>()
                .ForEach(x =>
                {
                    var nameNode = (YamlScalarNode) x.Children[new YamlScalarNode("name")];
                    if (!namedItems.ContainsKey(nameNode.Value))
                    {
                        namedItems.Add(nameNode.Value, x);
                    }
                    else
                    {
                        namedItems[nameNode.Value] = x;
                    }
                });

            return new YamlSequenceNode(namedItems.Values);
        }
    }
}