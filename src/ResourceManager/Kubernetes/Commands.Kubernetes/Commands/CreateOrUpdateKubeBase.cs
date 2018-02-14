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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.Kubernetes.Generated.Models;
using Microsoft.Azure.Commands.Kubernetes.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Kubernetes.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Kubernetes
{
    public abstract class CreateOrUpdateKubeBase : KubeCmdletBase
    {
        protected const string DefaultParamSet = "defaultParameterSet";
        protected const string SpParamSet = "servicePrincipalParameterSet";
        protected readonly Regex DnsRegex = new Regex("[^A-Za-z0-9-]");

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = SpParamSet,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Kubernetes managed cluster Name.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SpParamSet,
            HelpMessage = "Kubernetes managed cluster Name.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = SpParamSet,
            HelpMessage = "The client id and client secret associated with the AAD application / service principal.")]
        public PSCredential ClientIdAndSecret { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Azure location for the cluster. Defaults to the location of the resource group.")]
        [LocationCompleter("Microsoft.ContainerService/managedClusters")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "User name for the Linux Virtual Machines.")]
        public string AdminUserName { get; set; } = "azureuser";

        [Parameter(Mandatory = false, HelpMessage = "The DNS name prefix for the cluster.")]
        public string DnsNamePrefix { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The version of Kubernetes to use for creating the cluster.")]
        [PSArgumentCompleter("1.7.7", "1.8.1")]
        public string KubernetesVersion { get; set; } = "1.8.1";

        [Parameter(Mandatory = false, HelpMessage = "The default number of nodes for the node pools.")]
        public int NodeCount { get; set; } = 3;

        [Parameter(Mandatory = false, HelpMessage = "The default number of nodes for the node pools.")]
        public int NodeOsDiskSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The size of the Virtual Machine.")]
        public string NodeVmSize { get; set; } = "Standard_D2_v2";

        [Parameter(
            Mandatory = false,
            HelpMessage = "SSH key file value or key file path. Defaults to {HOME}/.ssh/id_rsa.pub.")]
        [Alias("SshKeyPath")]
        public string SshKeyValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public Hashtable Tag { get; set; }

        protected ManagedCluster BuildNewCluster()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Location))
            {
                var rg = RmClient.ResourceGroups.Get(ResourceGroupName);
                Location = rg.Location;
                WriteVerbose(string.Format(Resources.UsingLocationFromTheResourceGroup, Location,
                    ResourceGroupName));
            }

            if (string.IsNullOrEmpty(DnsNamePrefix))
            {
                DnsNamePrefix = DefaultDnsPrefix();
            }

            WriteVerbose(string.Format(Resources.UsingDnsNamePrefix, DnsNamePrefix));
            SshKeyValue = GetSshKey(SshKeyValue);

            var defaultAgentPoolProfile = new ContainerServiceAgentPoolProfile(
                "default",
                NodeVmSize,
                NodeCount,
                NodeOsDiskSize,
                DnsNamePrefix);

            var pubKey =
                new List<ContainerServiceSshPublicKey> {new ContainerServiceSshPublicKey(SshKeyValue)};

            var linuxProfile =
                new ContainerServiceLinuxProfile(AdminUserName,
                    new ContainerServiceSshConfiguration(pubKey));

            var acsServicePrincipal = EnsureServicePrincipal(ClientIdAndSecret?.UserName, ClientIdAndSecret?.Password?.ToString());

            var spProfile = new ContainerServiceServicePrincipalProfile(
                acsServicePrincipal.SpId,
                acsServicePrincipal.ClientSecret);

            WriteVerbose(string.Format(Resources.DeployingYourManagedKubeCluster, AcsSpFilePath));
            var managedCluster = new ManagedCluster(
                Location,
                name: Name,
                tags: TagsConversionHelper.CreateTagDictionary(Tag, true),
                dnsPrefix: DnsNamePrefix,
                kubernetesVersion: KubernetesVersion,
                agentPoolProfiles: new List<ContainerServiceAgentPoolProfile> {defaultAgentPoolProfile},
                linuxProfile: linuxProfile,
                servicePrincipalProfile: spProfile);
            return managedCluster;
        }

        /// <summary>
        /// Fetch SSH public key string
        /// </summary>
        /// <param name="sshKeyOrFile">a string representing either the file location, the ssh key pub data or null.</param>
        /// <returns>SSH public key data</returns>
        /// <exception cref="ArgumentException">The SSH key or file argument was null and there was no default pub key in path.</exception>
        protected string GetSshKey(string sshKeyOrFile)
        {
            const string helpLink = "https://docs.microsoft.com/en-us/azure/virtual-machines/linux/mac-create-ssh-keys";

            // SSH key was specified as either a file or as key data
            if (!string.IsNullOrEmpty(SshKeyValue))
            {
                if (File.Exists(sshKeyOrFile))
                {
                    WriteVerbose(string.Format(Resources.FetchSshPublicKeyFromFile, sshKeyOrFile));
                    return File.ReadAllText(sshKeyOrFile);
                }

                WriteVerbose(Resources.UsingSshPublicKeyDataAsCommandLineString);
                return sshKeyOrFile;
            }

            // SSH key value was not specified, so look in the home directory for the default pub key
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh", "id_rsa.pub");
            if (!AzureSession.Instance.DataStore.FileExists(path))
            {
                throw new ArgumentException(string.Format(Resources.CouldNotFindSshPublicKeyInError, path, helpLink));
            }

            WriteVerbose(string.Format(Resources.FetchSshPublicKeyFromFile, path));
            return AzureSession.Instance.DataStore.ReadFileAsText(path);

            // we didn't find an SSH key and there was no SSH public key in the home directory
        }

        protected AcsServicePrincipal EnsureServicePrincipal(string spId = null, string clientSecret = null)
        {
            var acsServicePrincipal = LoadServicePrincipal();
            if (acsServicePrincipal == null)
            {
                WriteVerbose(string.Format(
                    Resources.NoServicePrincipalFoundCreatingANewServicePrincipal,
                    AcsSpFilePath));

                // if nothing to load, make one
                if (clientSecret == null)
                {
                    clientSecret = RandomBase64String(16);
                }
                var salt = RandomBase64String(3);
                var url = $"http://{salt}.{DnsNamePrefix}.{Location}.cloudapp.azure.com";

                acsServicePrincipal = BuildServicePrincipal(Name, url, clientSecret);
                WriteVerbose(Resources.CreatedANewServicePrincipalAndAssignedTheContributorRole);
                StoreServicePrincipal(acsServicePrincipal);
            }
            return acsServicePrincipal;
        }

        private AcsServicePrincipal BuildServicePrincipal(string name, string url, string clientSecret)
        {
            var pwCreds = new PasswordCredential(
                value: clientSecret,
                startDate: DateTime.UtcNow,
                endDate: DateTime.UtcNow.AddYears(2));

            var app = GraphClient.Applications.Create(new ApplicationCreateParameters(
                false,
                name,
                new List<string> { url },
                url,
                passwordCredentials: new List<PasswordCredential> { pwCreds }));

            ServicePrincipal sp = null;
            var success = RetryAction(() =>
            {
                var spCreateParams = new ServicePrincipalCreateParameters(
                                app.AppId,
                                true,
                                passwordCredentials: new List<PasswordCredential> { pwCreds });
                sp = GraphClient.ServicePrincipals.Create(spCreateParams);
            }, Resources.ServicePrincipalCreate);

            if (!success)
            {
                throw new CmdletInvocationException(Resources.CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner);
            }

            AddSubscriptionRoleAssignment("Contributor", sp.ObjectId);
            return new AcsServicePrincipal { SpId = app.AppId, ClientSecret = clientSecret };
        }

        protected bool Exists()
        {
            try
            {
                var exists = Client.ManagedClusters.Get(ResourceGroupName, Name) != null;
                WriteVerbose(string.Format(Resources.ClusterExists, exists));
                return exists;
            }
            catch (CloudException)
            {
                WriteVerbose(Resources.ClusterDoesNotExist);
                return false;
            }
        }

        protected void AddSubscriptionRoleAssignment(string role, string appId)
        {
            var scope = $"/subscriptions/{DefaultContext.Subscription.Id}";
            var roleId = GetRoleId(role, scope);
            var success = RetryAction(() =>
                AuthClient.RoleAssignments.Create(scope, appId, new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties(roleId, appId)
                }), Resources.AddRoleAssignment);

            if (!success)
            {
                throw new CmdletInvocationException(
                    Resources.CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner);
            }
        }

        protected string GetRoleId(string roleName, string scope)
        {
            return AuthClient.RoleDefinitions.List(scope, $"roleName eq '{roleName}'").First().Id;
        }

        protected bool RetryAction(Action action, string actionName = null)
        {
            var success = false;
            foreach (var i in Enumerable.Range(1, 10))
            {
                try
                {
                    action();
                    success = true;
                    break;
                }
                catch (Exception ex)
                {
                    WriteVerbose(string.Format(Resources.RetryAfterActionError, i, actionName ?? "action", ex.Message));
                    // AAD might puke here, so we catch it and try again until success
                    TestMockSupport.Delay(1000 * i);
                }
            }
            return success;
        }

        protected AcsServicePrincipal LoadServicePrincipal()
        {
            var config = LoadServicePrincipals();
            return config?[DefaultContext.Subscription.Id];
        }

        protected Dictionary<string, AcsServicePrincipal> LoadServicePrincipals()
        {
            return AzureSession.Instance.DataStore.FileExists(AcsSpFilePath)
                ? JsonConvert.DeserializeObject<Dictionary<string, AcsServicePrincipal>>(
                    File.ReadAllText(AcsSpFilePath))
                : null;
        }

        protected void StoreServicePrincipal(AcsServicePrincipal acsServicePrincipal)
        {
            var config = LoadServicePrincipals() ?? new Dictionary<string, AcsServicePrincipal>();
            config[DefaultContext.Subscription.Id] = acsServicePrincipal;
            AzureSession.Instance.DataStore.CreateDirectory(Path.GetDirectoryName(AcsSpFilePath));
            AzureSession.Instance.DataStore.WriteFile(AcsSpFilePath, JsonConvert.SerializeObject(config));
        }

        protected static string RandomBase64String(int size)
        {
            var rnd = new Random();
            var secretBytes = new byte[size];
            rnd.NextBytes(secretBytes);
            return Convert.ToBase64String(secretBytes);
        }

        /// <summary>
        /// Build a semi-random DNS prefix based on the name of the cluster, resource group, and last 6 digits of the subscription
        /// </summary>
        /// <returns>Default DNS prefix string</returns>
        protected string DefaultDnsPrefix()
        {
            var namePart = string.Join("", DnsRegex.Replace(Name, "").Take(10));
            if (char.IsDigit(namePart[0]))
            {
                namePart = "a" + string.Join("", namePart.Skip(1));
            }

            var rgPart = DnsRegex.Replace(ResourceGroupName, "");
            var subPart = string.Join("", DefaultContext.Subscription.Id.Take(6));
            return $"{namePart}-{rgPart}-{subPart}";
        }
    }
}