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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using ResourceIdentityType = Microsoft.Azure.Management.ContainerService.Models.ResourceIdentityType;
using Microsoft.Azure.Commands.Aks.Commands;
using Microsoft.Azure.Commands.Aks.Utils;
using System.Security;

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

        [Parameter(Mandatory = false, HelpMessage = "Node pool labels used for building Kubernetes network.")]
        public Hashtable NodePoolLabel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags to be persisted on the agent pool virtual machine scale set.")]
        public Hashtable NodePoolTag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "SSH key file value or key file path. Defaults to {HOME}/.ssh/id_rsa.pub.")]
        [Alias("SshKeyPath")]
        public string SshKeyValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Grant the 'acrpull' role of the specified ACR to AKS Service Principal, e.g. myacr")]
        public string AcrNameToAttach { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The desired number of allocated SNAT ports per VM.")]
        [ValidateRange(0, 64000)]
        public int LoadBalancerAllocatedOutboundPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Desired managed outbound IPs count for the cluster load balancer.")]
        public int LoadBalancerManagedOutboundIpCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Desired outbound IP resources for the cluster load balancer.")]
        public string[] LoadBalancerOutboundIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Desired outbound IP Prefix resources for the cluster load balancer.")]
        public string[] LoadBalancerOutboundIpPrefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Desired outbound flow idle timeout in minutes.")]
        [ValidateRange(4, 120)]
        public int LoadBalancerIdleTimeoutInMinute { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The IP ranges authorized to access the Kubernetes API server.")]
        public string[] ApiServerAccessAuthorizedIpRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to create the cluster as a private cluster or not.")]
        public SwitchParameter EnableApiServerAccessPrivateCluster { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The private DNS zone mode for the cluster.")]
        public string ApiServerAccessPrivateDnsZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to create additional public FQDN for private cluster or not.")]
        public SwitchParameter EnableApiServerAccessPrivateClusterPublicFQDN { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The FQDN subdomain of the private cluster with custom private dns zone.")]
        public string FqdnSubdomain { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Using a managed identity to manage cluster resource group.")]
        public SwitchParameter EnableManagedIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ResourceId of user assign managed identity for cluster.")]
        public string AssignIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The upgrade channel for auto upgrade. For more information see https://learn.microsoft.com/azure/aks/upgrade-cluster#set-auto-upgrade-channel.")]
        [PSArgumentCompleter("rapid", "stable", "patch", "node-image", "none")]
        public string AutoUpgradeChannel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource ID of the disk encryption set to use for enabling encryption.")]
        public string DiskEncryptionSetID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Local accounts should be disabled on the Managed Cluster.")]
        public SwitchParameter DisableLocalAccount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The HTTP proxy server endpoint to use.")]
        public string HttpProxy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The HTTPS proxy server endpoint to use")]
        public string HttpsProxy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The endpoints that should not go through proxy.")]
        public string[] HttpProxyConfigNoProxyEndpoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Alternative CA cert to use for connecting to proxy servers.")]
        public string HttpProxyConfigTrustedCa { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Aks custom headers used for building Kubernetes network.")]
        public Hashtable AksCustomHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Azure Active Directory configuration.")]
        public ManagedClusterAADProfile AadProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The administrator password to use for Windows VMs. Password requirement:"
          + "At least one lower case, one upper case, one special character !@#$%^&*(), the minimum lenth is 12.")]
        [ValidateSecureString(RegularExpression = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%\\^&\\*\\(\\)])[a-zA-Z\\d!@#$%\\^&\\*\\(\\)]{12,123}$", ParameterName = nameof(WindowsProfileAdminUserPassword))]
        public SecureString WindowsProfileAdminUserPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable Azure Hybrid User Benefits (AHUB) for Windows VMs.")]
        public SwitchParameter EnableAHUB { get; set; }

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
            if (!string.IsNullOrEmpty(spId) && !string.IsNullOrEmpty(clientSecret))
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

                acsServicePrincipal = BuildServicePrincipal(Name, clientSecret);
                WriteVerbose(Resources.CreatedANewServicePrincipalAndAssignedTheContributorRole);
                StoreServicePrincipal(acsServicePrincipal);
            }
            return acsServicePrincipal;
        }

        private AcsServicePrincipal BuildServicePrincipal(string name, string clientSecret)
        {
            var keyCredentials = new List<MicrosoftGraphKeyCredential> {
                    new MicrosoftGraphKeyCredential {
                        EndDateTime = DateTime.UtcNow.AddYears(2),
                        StartDateTime = DateTime.UtcNow,
                        Key = clientSecret,
                        Type = "Symmetric",
                        Usage = "Verify"
                    }
            };
            var appCreateParameters = new MicrosoftGraphApplication
            {
                DisplayName = name,
                KeyCredentials = keyCredentials
            };
            var app = GraphClient.Applications.CreateApplication(appCreateParameters);

            MicrosoftGraphServicePrincipal sp = null;
            var success = RetryAction(() =>
            {
                var servicePrincipalCreateParams = new MicrosoftGraphServicePrincipal
                {
                    AppId = app.AppId,
                    AccountEnabled = true,
                    KeyCredentials = keyCredentials
                };
                sp = GraphClient.ServicePrincipals.CreateServicePrincipal(servicePrincipalCreateParams);
            }, Resources.ServicePrincipalCreate);

            if (!success)
            {
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner,
                    desensitizedMessage: Resources.CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner);
            }

            AddSubscriptionRoleAssignment("Contributor", sp.Id);
            return new AcsServicePrincipal { SpId = app.AppId, ClientSecret = clientSecret, ObjectId = sp.Id };
        }

        protected RoleAssignment GetRoleAssignmentWithRoleDefinitionId(string roleDefinitionId, string acrResourceId, string acsServicePrincipalObjectId)
        {
            RoleAssignment roleAssignment = null;
            var actionSuccess = RetryAction(() =>
            {
                roleAssignment = AuthClient.RoleAssignments.ListForScope(acrResourceId)
                    .Where(x => (x.Properties.RoleDefinitionId == roleDefinitionId && (x.Name == Name || x.Properties.PrincipalId == acsServicePrincipalObjectId)))
                    .FirstOrDefault();
            });
            if (!actionSuccess)
            {
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotGetAcrRoleAssignment,
                    desensitizedMessage: Resources.CouldNotGetAcrRoleAssignment);
            }
            return roleAssignment;
        }

        protected void AddAcrRoleAssignment(string acrName, string acrParameterName, AcsServicePrincipal acsServicePrincipal)
        {
            string acrResourceId = getSpecifiedAcr(acrName, acrParameterName);

            var roleDefinitionId = GetRoleId("acrpull", acrResourceId);
            var spObjectId = getSPObjectId(acsServicePrincipal);

            RoleAssignment roleAssignment = GetRoleAssignmentWithRoleDefinitionId(roleDefinitionId, acrResourceId, spObjectId);
            if (roleAssignment != null)
            {
                WriteWarning(string.Format(Resources.AcrRoleAssignmentIsAlreadyExist, acrResourceId));
                return;
            }

            var success = RetryAction(() =>
                AuthClient.RoleAssignments.Create(acrResourceId, Guid.NewGuid().ToString(), new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties(roleDefinitionId, spObjectId)
                }), Resources.AddRoleAssignment);

            if (!success)
            {
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotAddAcrRoleAssignment,
                    desensitizedMessage: Resources.CouldNotAddAcrRoleAssignment);
            }
        }

        protected string getSPObjectId(AcsServicePrincipal acsServicePrincipal) {
            var spObjectId = acsServicePrincipal.ObjectId;
            if (spObjectId == null)
            {
                try
                {
                    ODataQuery<MicrosoftGraphServicePrincipal> oDataQuery = new ODataQuery<MicrosoftGraphServicePrincipal>(sp => sp.AppId == acsServicePrincipal.SpId);
                    var servicePrincipal = GraphClient.FilterServicePrincipals(oDataQuery).First();
                    spObjectId = servicePrincipal.Id;
                }
                catch (Exception ex)
                {
                    throw new AzPSInvalidOperationException(
                        string.Format(Resources.CouldNotFindObjectIdForServicePrincipal, acsServicePrincipal.SpId),
                        ex,
                        string.Format(Resources.CouldNotFindObjectIdForServicePrincipal, "*"));
                }
            }
            return spObjectId;
        }

        protected string getSpecifiedAcr(string acrName, string acrParameterName) {
            try
            {
                //Find Acr resourceId first
                var acrQuery = new ODataQuery<GenericResourceFilter>($"$filter=resourceType eq 'Microsoft.ContainerRegistry/registries' and name eq '{acrName}'");
                var acrObjects = RmClient.Resources.List(acrQuery);
                while (acrObjects.Count() == 0 && acrObjects.NextPageLink != null)
                {
                    acrObjects = RmClient.Resources.ListNext(acrObjects.NextPageLink);
                }
                if (acrObjects.Count() == 0)
                {
                    throw new AzPSArgumentException(
                    string.Format(Resources.CouldNotFindSpecifiedAcr, acrName),
                    acrParameterName,
                    string.Format(Resources.CouldNotFindSpecifiedAcr, "*"));
                }
                return acrObjects.First().Id;
            }
            catch (Exception ex)
            {
                throw new AzPSArgumentException(string.Format(Resources.CouldNotFindSpecifiedAcr, acrName), ex, string.Format(Resources.CouldNotFindSpecifiedAcr, "*"));
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
            if (config?.ContainsKey(DefaultContext.Subscription.Id) == true)
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

        protected ManagedClusterLoadBalancerProfile CreateOrUpdateLoadBalancerProfile(ManagedClusterLoadBalancerProfile loadBalancerProfile)
        {
            if ((this.IsParameterBound(c => c.LoadBalancerManagedOutboundIpCount) ||
                this.IsParameterBound(c => c.LoadBalancerOutboundIp) ||
                this.IsParameterBound(c => c.LoadBalancerOutboundIpPrefix) ||
                this.IsParameterBound(c => c.LoadBalancerAllocatedOutboundPort) ||
                this.IsParameterBound(c => c.LoadBalancerIdleTimeoutInMinute)) &&
                loadBalancerProfile == null)
            {
                loadBalancerProfile = new ManagedClusterLoadBalancerProfile();
            }
            if (this.IsParameterBound(c => c.LoadBalancerManagedOutboundIpCount))
            {
                loadBalancerProfile.ManagedOutboundIPs = new ManagedClusterLoadBalancerProfileManagedOutboundIPs(LoadBalancerManagedOutboundIpCount);
            }
            if (this.IsParameterBound(c => c.LoadBalancerOutboundIp))
            {
                loadBalancerProfile.OutboundIPs = new ManagedClusterLoadBalancerProfileOutboundIPs(LoadBalancerOutboundIp.ToList().Select(x => { return new ResourceReference(x); }).ToList());
            }
            if (this.IsParameterBound(c => c.LoadBalancerOutboundIpPrefix))
            {
                loadBalancerProfile.OutboundIPPrefixes = new ManagedClusterLoadBalancerProfileOutboundIPPrefixes(LoadBalancerOutboundIpPrefix.ToList().Select(x => { return new ResourceReference(x); }).ToList());
            }
            if (this.IsParameterBound(c => c.LoadBalancerAllocatedOutboundPort))
            {
                loadBalancerProfile.AllocatedOutboundPorts = LoadBalancerAllocatedOutboundPort;
            }
            if (this.IsParameterBound(c => c.LoadBalancerIdleTimeoutInMinute))
            {
                loadBalancerProfile.IdleTimeoutInMinutes = LoadBalancerIdleTimeoutInMinute;
            }

            return loadBalancerProfile;
        }

        protected ManagedClusterAutoUpgradeProfile CreateOrUpdateAutoUpgradeProfile(ManagedClusterAutoUpgradeProfile autoUpgradeProfile)
        {
            if (this.IsParameterBound(c => c.AutoUpgradeChannel) && autoUpgradeProfile == null)
            {
                autoUpgradeProfile = new ManagedClusterAutoUpgradeProfile();
            }
            if (this.IsParameterBound(c => c.AutoUpgradeChannel))
            {
                autoUpgradeProfile.UpgradeChannel = AutoUpgradeChannel;
            }
            return autoUpgradeProfile;
        }

        protected ManagedClusterHttpProxyConfig CreateOrUpdateHttpProxyConfig(ManagedClusterHttpProxyConfig httpProxyConfig)
        {
            if ((this.IsParameterBound(c => c.HttpProxy) ||
                this.IsParameterBound(c => c.HttpsProxy) ||
                this.IsParameterBound(c => c.HttpProxyConfigNoProxyEndpoint) ||
                this.IsParameterBound(c => c.HttpProxyConfigTrustedCa)) &&
                httpProxyConfig == null)
            {
                httpProxyConfig = new ManagedClusterHttpProxyConfig();
            }
            if (this.IsParameterBound(c => c.HttpProxy))
            {
                httpProxyConfig.HttpProxy = HttpProxy;
            }
            if (this.IsParameterBound(c => c.HttpsProxy))
            {
                httpProxyConfig.HttpsProxy = HttpsProxy;
            }
            if (this.IsParameterBound(c => c.HttpProxyConfigNoProxyEndpoint))
            {
                httpProxyConfig.NoProxy = HttpProxyConfigNoProxyEndpoint;
            }
            if (this.IsParameterBound(c => c.HttpProxyConfigTrustedCa))
            {
                httpProxyConfig.TrustedCa = HttpProxyConfigTrustedCa;
            }

            return httpProxyConfig;
        }

        protected ManagedClusterAPIServerAccessProfile CreateOrUpdateApiServerAccessProfile(ManagedClusterAPIServerAccessProfile apiServerAccessProfile)
        {
            if ((this.IsParameterBound(c => c.ApiServerAccessAuthorizedIpRange) ||
                this.IsParameterBound(c => c.EnableApiServerAccessPrivateCluster) ||
                this.IsParameterBound(c => c.ApiServerAccessPrivateDnsZone) ||
                this.IsParameterBound(c => c.EnableApiServerAccessPrivateClusterPublicFQDN)) &&
                apiServerAccessProfile == null)
            {
                apiServerAccessProfile = new ManagedClusterAPIServerAccessProfile();
            }
            if (this.IsParameterBound(c => c.ApiServerAccessAuthorizedIpRange))
            {
                apiServerAccessProfile.AuthorizedIPRanges = ApiServerAccessAuthorizedIpRange;
            }
            if (this.IsParameterBound(c => c.EnableApiServerAccessPrivateCluster))
            {
                apiServerAccessProfile.EnablePrivateCluster = EnableApiServerAccessPrivateCluster;
            }
            if (this.IsParameterBound(c => c.ApiServerAccessPrivateDnsZone))
            {
                apiServerAccessProfile.PrivateDnsZone = ApiServerAccessPrivateDnsZone;
            }
            if (this.IsParameterBound(c => c.EnableApiServerAccessPrivateClusterPublicFQDN))
            {
                apiServerAccessProfile.EnablePrivateClusterPublicFqdn = EnableApiServerAccessPrivateClusterPublicFQDN;
            }

            return apiServerAccessProfile;
        }

        protected ManagedCluster SetIdentity(ManagedCluster cluster)
        {
            if (this.IsParameterBound(c => c.EnableManagedIdentity))
            {
                if (!EnableManagedIdentity)
                {
                    cluster.Identity = null;
                }
                else
                {
                    if (cluster.Identity == null)
                    {
                        cluster.Identity = new ManagedClusterIdentity();
                    }
                }
            }
            if (this.IsParameterBound(c => c.AssignIdentity))
            {
                if (cluster.Identity == null)
                {
                    throw new AzPSArgumentException(Resources.NeedEnableManagedIdentity, nameof(AssignIdentity));
                }
                cluster.Identity.Type = ResourceIdentityType.UserAssigned;
                cluster.Identity.UserAssignedIdentities = new Dictionary<string, ManagedServiceIdentityUserAssignedIdentitiesValue>
                {
                    { AssignIdentity, new ManagedServiceIdentityUserAssignedIdentitiesValue() }
                };

            }
            else
            {
                if (cluster.Identity != null && cluster.Identity.Type == null)
                {
                    cluster.Identity.Type = ResourceIdentityType.SystemAssigned;
                    cluster.Identity.UserAssignedIdentities = null;
                }
            }

            return cluster;
        }

        private protected ManagedCluster CreateOrUpdate(string resourceGroupName, string resourceName, ManagedCluster parameters)
        {
            if (this.IsParameterBound(c => c.AksCustomHeader))
            {
                Dictionary<string, List<string>> customHeaders = Utilities.HashtableToDictionary(AksCustomHeader);
                return Client.ManagedClusters.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, resourceName, parameters, customHeaders).GetAwaiter().GetResult().Body;
            }
            else
            {
                return Client.ManagedClusters.CreateOrUpdate(resourceGroupName, resourceName, parameters);
            }
        }
    }
}