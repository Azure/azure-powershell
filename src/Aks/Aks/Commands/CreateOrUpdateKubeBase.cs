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
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Commands.Aks.Models;
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
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Rest.Azure.OData;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Aks
{
    public abstract class CreateOrUpdateKubeBase : KubeCmdletBase
    {
        protected const string DefaultParamSet = "defaultParameterSet";
        protected readonly Regex DnsRegex = new Regex("[^A-Za-z0-9-]");

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "Kubernetes managed cluster Name.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = DefaultParamSet,
            HelpMessage = "The client id and client secret associated with the AAD application / service principal.")]
        public PSCredential ServicePrincipalIdAndSecret { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Azure location for the cluster. Defaults to the location of the resource group.")]
        [LocationCompleter("Microsoft.ContainerService/managedClusters")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "User name for the Linux Virtual Machines.")]
        [Alias("AdminUserName")]
        public string LinuxProfileAdminUserName { get; set; } = "azureuser";

        [Parameter(Mandatory = false, HelpMessage = "The DNS name prefix for the cluster. The length must be <= 9 if users plan to add windows container.")]
        public string DnsNamePrefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The version of Kubernetes to use for creating the cluster.")]
        public string KubernetesVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Unique name of the node pool profile in the context of the subscription and resource group.")]
        public string NodeName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Minimum number of nodes for auto-scaling.")]
        public int NodeMinCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum number of nodes for auto-scaling")]
        public int NodeMaxCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable auto-scaler")]
        public SwitchParameter EnableNodeAutoScaling { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The default number of nodes for the node pools.")]
        public int NodeCount { get; set; } = 3;

        [Parameter(Mandatory = false, HelpMessage = "The default number of nodes for the node pools.")]
        public int NodeOsDiskSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The size of the Virtual Machine. Default value is Standard_D2_v2")]
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

        protected virtual ManagedCluster BuildNewCluster()
        {
            BeforeBuildNewCluster();

            var defaultAgentPoolProfile = new ManagedClusterAgentPoolProfile(
                name: NodeName ?? "default",
                count: NodeCount,
                vmSize: NodeVmSize,
                osDiskSizeGB: NodeOsDiskSize);

            if (this.IsParameterBound(c => c.NodeMinCount))
            {
                defaultAgentPoolProfile.MinCount = NodeMinCount;
            }
            if (this.IsParameterBound(c => c.NodeMaxCount))
            {
                defaultAgentPoolProfile.MaxCount = NodeMaxCount;
            }
            if (EnableNodeAutoScaling.IsPresent)
            {
                defaultAgentPoolProfile.EnableAutoScaling = EnableNodeAutoScaling.ToBool();
            }

            var pubKey =
                new List<ContainerServiceSshPublicKey> { new ContainerServiceSshPublicKey(SshKeyValue) };

            var linuxProfile =
                new ContainerServiceLinuxProfile(LinuxProfileAdminUserName,
                    new ContainerServiceSshConfiguration(pubKey));

            var acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret?.UserName, ServicePrincipalIdAndSecret?.Password?.ConvertToString());

            var spProfile = new ManagedClusterServicePrincipalProfile(
                acsServicePrincipal.SpId,
                acsServicePrincipal.ClientSecret);

            WriteVerbose(string.Format(Resources.DeployingYourManagedKubeCluster, AcsSpFilePath));
            var managedCluster = new ManagedCluster(
                Location,
                name: Name,
                tags: TagsConversionHelper.CreateTagDictionary(Tag, true),
                dnsPrefix: DnsNamePrefix,
                kubernetesVersion: KubernetesVersion,
                agentPoolProfiles: new List<ManagedClusterAgentPoolProfile> { defaultAgentPoolProfile },
                linuxProfile: linuxProfile,
                servicePrincipalProfile: spProfile);
            return managedCluster;
        }

        protected void BeforeBuildNewCluster()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Location))
            {
                var rg = RmClient.ResourceGroups.Get(ResourceGroupName);
                Location = rg.Location;

                var validLocations = RmClient.Providers.Get("Microsoft.ContainerService").ResourceTypes.ToList().Find(x => x.ResourceType.Equals("managedClusters")).Locations;
                validLocations = validLocations.Select(l => l.Replace(" ", string.Empty).Replace("-", string.Empty).ToLower()).ToList();
                // If the ResourceGroup location name is not valid, use "East US"
                if (!validLocations.Contains(rg.Location))
                {
                    // Add check in case East US is removed from the list of valid locations
                    if (validLocations.Contains("eastus"))
                    {
                        Location = "eastus";
                    }
                    else
                    {
                        Location = validLocations[0];
                    }

                    WriteVerbose(string.Format(Resources.UsingDefaultLocation, Location));
                }

                else
                {
                    WriteVerbose(string.Format(Resources.UsingLocationFromTheResourceGroup, Location,
                    ResourceGroupName));
                }
            }

            if (string.IsNullOrEmpty(DnsNamePrefix))
            {
                DnsNamePrefix = DefaultDnsPrefix();
            }

            WriteVerbose(string.Format(Resources.UsingDnsNamePrefix, DnsNamePrefix));
            SshKeyValue = GetSshKey(SshKeyValue);
        }

        /// <summary>
        /// Fetch SSH public key string
        /// </summary>
        /// <param name="sshKeyOrFile">a string representing either the file location, the ssh key pub data or null.</param>
        /// <returns>SSH public key data</returns>
        /// <exception cref="ArgumentException">The SSH key or file argument was null and there was no default pub key in path.</exception>
        protected string GetSshKey(string sshKeyOrFile)
        {
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
                var errorMessage = string.Format(Resources.CouldNotFindSshPublicKeyInError, path);
                throw new AzPSArgumentException(errorMessage, nameof(SshKeyValue));
            }

            WriteVerbose(string.Format(Resources.FetchSshPublicKeyFromFile, path));
            return AzureSession.Instance.DataStore.ReadFileAsText(path);

            // we didn't find an SSH key and there was no SSH public key in the home directory
        }

        protected AcsServicePrincipal EnsureServicePrincipal(string spId = null, string clientSecret = null)
        {
            //If user specifies service principal, just use it directly and no need to save to disk
            if(!string.IsNullOrEmpty(spId) && !string.IsNullOrEmpty(clientSecret))
            {
                return new AcsServicePrincipal()
                {
                    SpId = spId,
                    ClientSecret = clientSecret
                };
            }

            var acsServicePrincipal = LoadServicePrincipal();
            if (acsServicePrincipal == null)
            {
                WriteWarning(string.Format(
                    Resources.NoServicePrincipalFoundCreatingANewServicePrincipal,
                    AcsSpFilePath, DefaultContext.Subscription.Id));

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
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner,
                    desensitizedMessage: Resources.CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner);
            }

            AddSubscriptionRoleAssignment("Contributor", sp.ObjectId);
            return new AcsServicePrincipal { SpId = app.AppId, ClientSecret = clientSecret, ObjectId = app.ObjectId };
        }

        protected void AddAcrRoleAssignment(string acrName, string acrParameterName, AcsServicePrincipal acsServicePrincipal)
        {
            string acrResourceId = null;
            try
            {
                //Find Acr resourceId first
                var acrQuery = new ODataQuery<GenericResourceFilter>($"$filter=resourceType eq 'Microsoft.ContainerRegistry/registries' and name eq '{acrName}'");
                var acrObjects = RmClient.Resources.List(acrQuery);
                acrResourceId = acrObjects.First().Id;
            }
            catch(Exception)
            {
                throw new AzPSArgumentException(
                    string.Format(Resources.CouldNotFindSpecifiedAcr, acrName),
                    acrParameterName,
                    string.Format(Resources.CouldNotFindSpecifiedAcr, "*"));
            }

            var roleId = GetRoleId("acrpull", acrResourceId);
            var spObjectId = acsServicePrincipal.ObjectId;
            if(spObjectId == null)
            {
                try
                {
                    //Please note string.Equals doesn't work here, while == works.
                    var odataQuery = new ODataQuery<ServicePrincipal>(sp => sp.AppId == acsServicePrincipal.SpId);
                    var servicePrincipal = GraphClient.ServicePrincipals.List(odataQuery).First();
                    spObjectId = servicePrincipal.ObjectId;
                }
                catch(Exception ex)
                {
                    throw new AzPSInvalidOperationException(
                        string.Format(Resources.CouldNotFindObjectIdForServicePrincipal, acsServicePrincipal.SpId),
                        ex,
                        string.Format(Resources.CouldNotFindObjectIdForServicePrincipal,"*"));
                }
            }
            var success = RetryAction(() =>
                AuthClient.RoleAssignments.Create(acrResourceId, Guid.NewGuid().ToString(), new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties(roleId, spObjectId)
                }), Resources.AddRoleAssignment);

            if (!success)
            {
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotAddAcrRoleAssignment,
                    desensitizedMessage: Resources.CouldNotAddAcrRoleAssignment);
            }
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
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotAssignServicePrincipalWithSubsContributorPermission,
                    desensitizedMessage: Resources.CouldNotAssignServicePrincipalWithSubsContributorPermission);
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
                    TestMockSupport.Delay(1000 * i);
                }
            }
            return success;
        }

        protected AcsServicePrincipal LoadServicePrincipal()
        {
            var config = LoadServicePrincipals();
            if(config?.ContainsKey(DefaultContext.Subscription.Id) == true)
            {
                return config[DefaultContext.Subscription.Id];
            }
            return null;
        }

        protected Dictionary<string, AcsServicePrincipal> LoadServicePrincipals()
        {
            return AzureSession.Instance.DataStore.FileExists(AcsSpFilePath)
                ? JsonConvert.DeserializeObject<Dictionary<string, AcsServicePrincipal>>(
                    AzureSession.Instance.DataStore.ReadFileAsText(AcsSpFilePath))
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
            var namePart = string.Join("", DnsRegex.Replace(Name, "").Take(5));
            if (char.IsDigit(namePart[0]))
            {
                namePart = "a" + string.Join("", namePart.Skip(1));
            }

            var subPart = string.Join("", DefaultContext.Subscription.Id.Take(4));
            return $"{namePart}{subPart}";
        }
    }
}