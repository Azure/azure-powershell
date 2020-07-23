using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;
using Microsoft.Azure.PowerShell.Cmdlets.Aks.Support;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    /// <summary>
    ///     Creates or updates a managed cluster with the specified configuration for agents and Kubernetes version.
    /// </summary>
    /// <remarks>
    ///     [OpenAPI]
    ///     ManagedClusters_CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}"
    /// </remarks>
    public partial class NewAzAksBase : KubeCmdletBase, IEventListener
    {
        private const string GroupNameParameterSet = "GroupNameParameterSet";

        protected readonly Regex DnsRegex = new Regex("[^A-Za-z0-9-]");

        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = Guid.NewGuid().ToString();

        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
        private InvocationInfo __invocationInfo;

        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
        private string __processRecordId;

        /// <summary>
        ///     The <see cref="CancellationTokenSource" /> for this operation.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>Backing field for <see cref="ParametersBody" /> property.</summary>
        private IManagedCluster _parametersBody = new ManagedCluster();

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>
        ///     Intializes a new instance of the <see cref="NewAzAks" /> cmdlet class.
        /// </summary>
        public NewAzAksBase()
        {
        }

        /// <summary>
        ///     Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of
        ///     the URI
        ///     for every service call.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage =
                "Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.")]
        [Info(
            Required = true,
            ReadOnly = false,
            Description =
                @"Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.",
            SerializedName = @"subscriptionId",
            PossibleTypes = new[] {typeof(string)})]
        [DefaultInfo(
            Name = @"",
            Description = @"",
            Script = @"(Get-AzContext).Subscription.Id")]
        [Category(ParameterCategory.Path)]
        public string SubscriptionId
        {
            get => _subscriptionId;
            set => _subscriptionId = value;
        }

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

        /// <summary>The name of the resource group.</summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The name of the resource group.",
            ParameterSetName = Constants.NameParameterSet)]
        [Info(
            Required = true,
            ReadOnly = false,
            Description = @"The name of the resource group.",
            SerializedName = @"resourceGroupName",
            PossibleTypes = new[] {typeof(string)})]
        [Category(ParameterCategory.Path)]
        public string ResourceGroupName
        {
            get => _resourceGroupName;
            set => _resourceGroupName = value;
        }

        /// <summary>The name of the managed cluster resource.</summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "The name of the managed cluster resource.",
            ParameterSetName = Constants.NameParameterSet)]
        [Info(
            Required = true,
            ReadOnly = false,
            Description = @"The name of the managed cluster resource.",
            SerializedName = @"resourceName",
            PossibleTypes = new[] {typeof(string)})]
        [Category(ParameterCategory.Path)]
        [Alias("ResourceName")]
        public string Name
        {
            get => _resourceName;
            set => _resourceName = value;
        }

        /// <summary>The client AAD application ID.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The client AAD application ID.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The client AAD application ID.",
            SerializedName = @"clientAppID",
            PossibleTypes = new[] {typeof(string)})]
        public string AadProfileClientAppId
        {
            get => ParametersBody.AadProfileClientAppId ?? null;
            set => ParametersBody.AadProfileClientAppId = value;
        }

        /// <summary>The server AAD application ID.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The server AAD application ID.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The server AAD application ID.",
            SerializedName = @"serverAppID",
            PossibleTypes = new[] {typeof(string)})]
        public string AadProfileServerAppId
        {
            get => ParametersBody.AadProfileServerAppId ?? null;
            set => ParametersBody.AadProfileServerAppId = value;
        }

        /// <summary>The server AAD application secret.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The server AAD application secret.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The server AAD application secret.",
            SerializedName = @"serverAppSecret",
            PossibleTypes = new[] {typeof(string)})]
        public string AadProfileServerAppSecret
        {
            get => ParametersBody.AadProfileServerAppSecret ?? null;
            set => ParametersBody.AadProfileServerAppSecret = value;
        }

        /// <summary>
        ///     The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.",
            SerializedName = @"tenantID",
            PossibleTypes = new[] {typeof(string)})]
        public string AadProfileTenantId
        {
            get => ParametersBody.AadProfileTenantId ?? null;
            set => ParametersBody.AadProfileTenantId = value;
        }

        /// <summary>Profile of managed cluster add-on.</summary>
        [ExportAs(typeof(Hashtable))]
        [Parameter(Mandatory = false, HelpMessage = "Profile of managed cluster add-on.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Profile of managed cluster add-on.",
            SerializedName = @"addonProfiles",
            PossibleTypes = new[] {typeof(IManagedClusterPropertiesAddonProfiles)})]
        public IManagedClusterPropertiesAddonProfiles AddOnProfile
        {
            get => ParametersBody.AddonProfile ?? null /* object */;
            set => ParametersBody.AddonProfile = value;
        }

        /// <summary>Properties of the agent pool.</summary>
        [AllowEmptyCollection]
        [Parameter(Mandatory = false, HelpMessage = "Properties of the agent pool.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Properties of the agent pool.",
            SerializedName = @"agentPoolProfiles",
            PossibleTypes = new[] {typeof(IManagedClusterAgentPoolProfile)})]
        public IManagedClusterAgentPoolProfile[] AgentPoolProfile
        {
            get => ParametersBody.AgentPoolProfile ?? null /* arrayOf */;
            set => ParametersBody.AgentPoolProfile = value;
        }

        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        [AllowEmptyCollection]
        [Parameter(Mandatory = false, HelpMessage = "Authorized IP Ranges to kubernetes API server.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Authorized IP Ranges to kubernetes API server.",
            SerializedName = @"authorizedIPRanges",
            PossibleTypes = new[] {typeof(string)})]
        public string[] AuthorizedIPRange
        {
            get => ParametersBody.ApiServerAccessProfileAuthorizedIPRange ?? null /* arrayOf */;
            set => ParametersBody.ApiServerAccessProfileAuthorizedIPRange = value;
        }

        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to create the cluster as a private cluster or not.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Whether to create the cluster as a private cluster or not.",
            SerializedName = @"enablePrivateCluster",
            PossibleTypes = new[] {typeof(SwitchParameter)})]
        public SwitchParameter EnablePrivateCluster
        {
            get => ParametersBody.ApiServerAccessProfileEnablePrivateCluster ?? default(SwitchParameter);
            set => ParametersBody.ApiServerAccessProfileEnablePrivateCluster = value;
        }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter Break { get; set; }

        /// <summary>The reference to the client API class.</summary>
        public AksClient Client => Module.Instance.ClientAPI;

        /// <summary>DNS prefix specified when creating the managed cluster.</summary>
        [Parameter(Mandatory = false, HelpMessage = "DNS prefix specified when creating the managed cluster.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"DNS prefix specified when creating the managed cluster.",
            SerializedName = @"dnsPrefix",
            PossibleTypes = new[] {typeof(string)})]
        public string DnsPrefix
        {
            get => ParametersBody.DnsPrefix ?? null;
            set => ParametersBody.DnsPrefix = value;
        }

        /// <summary>(PREVIEW) Whether to enable Kubernetes Pod security policy.</summary>
        [Parameter(Mandatory = false, HelpMessage = "(PREVIEW) Whether to enable Kubernetes Pod security policy.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"(PREVIEW) Whether to enable Kubernetes Pod security policy.",
            SerializedName = @"enablePodSecurityPolicy",
            PossibleTypes = new[] {typeof(SwitchParameter)})]
        public SwitchParameter EnablePodSecurityPolicy
        {
            get => ParametersBody.EnablePodSecurityPolicy ?? default(SwitchParameter);
            set => ParametersBody.EnablePodSecurityPolicy = value;
        }

        /// <summary>Whether to enable Kubernetes Role-Based Access Control.</summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to enable Kubernetes Role-Based Access Control.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Whether to enable Kubernetes Role-Based Access Control.",
            SerializedName = @"enableRBAC",
            PossibleTypes = new[] {typeof(SwitchParameter)})]
        public SwitchParameter EnableRbac
        {
            get => ParametersBody.EnableRbac ?? default(SwitchParameter);
            set => ParametersBody.EnableRbac = value;
        }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [Parameter(Mandatory = false, DontShow = true,
            HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [ValidateNotNull]
        [Category(ParameterCategory.Runtime)]
        public SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [Parameter(Mandatory = false, DontShow = true,
            HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [ValidateNotNull]
        [Category(ParameterCategory.Runtime)]
        public SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>
        ///     The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in
        ///     master
        ///     components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not
        ///     use MSI
        ///     for the managed cluster, service principal will be used instead.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI for the managed cluster, service principal will be used instead.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI for the managed cluster, service principal will be used instead.",
            SerializedName = @"type",
            PossibleTypes = new[] {typeof(ResourceIdentityType)})]
        [ArgumentCompleter(typeof(ResourceIdentityType))]
        public ResourceIdentityType IdentityType
        {
            get => ParametersBody.IdentityType ?? ((ResourceIdentityType) "");
            set => ParametersBody.IdentityType = value;
        }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public InvocationInfo InvocationInformation
        {
            get => __invocationInfo = __invocationInfo ?? MyInvocation;
            set { __invocationInfo = value; }
        }

        /// <summary>Version of Kubernetes specified when creating the managed cluster.</summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Version of Kubernetes specified when creating the managed cluster.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Version of Kubernetes specified when creating the managed cluster.",
            SerializedName = @"kubernetesVersion",
            PossibleTypes = new[] {typeof(string)})]
        public string KubernetesVersion
        {
            get => ParametersBody.KubernetesVersion ?? null;
            set => ParametersBody.KubernetesVersion = value;
        }

        /// <summary>The administrator username to use for Linux VMs.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The administrator username to use for Linux VMs.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The administrator username to use for Linux VMs.",
            SerializedName = @"adminUsername",
            PossibleTypes = new[] {typeof(string)})]
        public string LinuxProfileAdminUsername
        {
            get => ParametersBody.LinuxProfileAdminUsername ?? null;
            set => ParametersBody.LinuxProfileAdminUsername = value;
        }

        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [AllowEmptyCollection]
        [Parameter(Mandatory = false,
            HelpMessage = "The effective outbound IP resources of the cluster load balancer.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The effective outbound IP resources of the cluster load balancer.",
            SerializedName = @"effectiveOutboundIPs",
            PossibleTypes = new[] {typeof(IResourceReference)})]
        public IResourceReference[] LoadBalancerProfileEffectiveOutboundIP
        {
            get => ParametersBody.LoadBalancerProfileEffectiveOutboundIP ?? null /* arrayOf */;
            set => ParametersBody.LoadBalancerProfileEffectiveOutboundIP = value;
        }

        /// <summary>Resource location</summary>
        [Parameter(Mandatory = false, HelpMessage = "Resource location")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Resource location",
            SerializedName = @"location",
            PossibleTypes = new[] {typeof(string)})]
        public string Location
        {
            get => ParametersBody.Location ?? null;
            set => ParametersBody.Location = value;
        }

        /// <summary>
        ///     Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the
        ///     range
        ///     of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. ")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. ",
            SerializedName = @"count",
            PossibleTypes = new[] {typeof(int)})]
        public int ManagedOutboundIPCount
        {
            get => ParametersBody.ManagedOutboundIPCount ?? default(int);
            set => ParametersBody.ManagedOutboundIPCount = value;
        }

        /// <summary>
        ///     An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range
        ///     specified
        ///     in serviceCidr.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified in serviceCidr.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified in serviceCidr.",
            SerializedName = @"dnsServiceIP",
            PossibleTypes = new[] {typeof(string)})]
        public string DnsServiceIP
        {
            get => ParametersBody.NetworkProfileDnsServiceIP ?? null;
            set => ParametersBody.NetworkProfileDnsServiceIP = value;
        }

        /// <summary>
        ///     A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or
        ///     the Kubernetes
        ///     service address range.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range.",
            SerializedName = @"dockerBridgeCidr",
            PossibleTypes = new[] {typeof(string)})]
        public string DockerBridgeCidr
        {
            get => ParametersBody.NetworkProfileDockerBridgeCidr ?? null;
            set => ParametersBody.NetworkProfileDockerBridgeCidr = value;
        }

        /// <summary>The load balancer sku for the managed cluster.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The load balancer sku for the managed cluster.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The load balancer sku for the managed cluster.",
            SerializedName = @"loadBalancerSku",
            PossibleTypes = new[] {typeof(LoadBalancerSku)})]
        [ArgumentCompleter(typeof(LoadBalancerSku))]
        public LoadBalancerSku LoadBalancerSku
        {
            get => ParametersBody.NetworkProfileLoadBalancerSku ?? ((LoadBalancerSku) "");
            set => ParametersBody.NetworkProfileLoadBalancerSku = value;
        }

        /// <summary>Network plugin used for building Kubernetes network.</summary>
        [Parameter(Mandatory = false, HelpMessage = "Network plugin used for building Kubernetes network.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Network plugin used for building Kubernetes network.",
            SerializedName = @"networkPlugin",
            PossibleTypes = new[] {typeof(NetworkPlugin)})]
        [ArgumentCompleter(typeof(NetworkPlugin))]
        public NetworkPlugin NetworkPlugin
        {
            get => ParametersBody.NetworkProfileNetworkPlugin ?? ((NetworkPlugin) "");
            set => ParametersBody.NetworkProfileNetworkPlugin = value;
        }

        /// <summary>Network policy used for building Kubernetes network.</summary>
        [Parameter(Mandatory = false, HelpMessage = "Network policy used for building Kubernetes network.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Network policy used for building Kubernetes network.",
            SerializedName = @"networkPolicy",
            PossibleTypes = new[] {typeof(NetworkPolicy)})]
        [ArgumentCompleter(typeof(NetworkPolicy))]
        public NetworkPolicy NetworkPolicy
        {
            get => ParametersBody.NetworkProfileNetworkPolicy ?? ((NetworkPolicy) "");
            set => ParametersBody.NetworkProfileNetworkPolicy = value;
        }

        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        [Parameter(Mandatory = false,
            HelpMessage = "A CIDR notation IP range from which to assign pod IPs when kubenet is used.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"A CIDR notation IP range from which to assign pod IPs when kubenet is used.",
            SerializedName = @"podCidr",
            PossibleTypes = new[] {typeof(string)})]
        public string PodCidr
        {
            get => ParametersBody.NetworkProfilePodCidr ?? null;
            set => ParametersBody.NetworkProfilePodCidr = value;
        }

        /// <summary>
        ///     A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage =
                "A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.",
            SerializedName = @"serviceCidr",
            PossibleTypes = new[] {typeof(string)})]
        public string ServiceCidr
        {
            get => ParametersBody.NetworkProfileServiceCidr ?? null;
            set => ParametersBody.NetworkProfileServiceCidr = value;
        }

        /// <summary>
        ///     when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation
        ///     continue
        ///     asynchronously.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter NoWait { get; set; }

        /// <summary>Name of the resource group containing agent pool nodes.</summary>
        [Parameter(Mandatory = false, HelpMessage = "Name of the resource group containing agent pool nodes.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Name of the resource group containing agent pool nodes.",
            SerializedName = @"nodeResourceGroup",
            PossibleTypes = new[] {typeof(string)})]
        public string NodeResourceGroup
        {
            get => ParametersBody.NodeResourceGroup ?? null;
            set => ParametersBody.NodeResourceGroup = value;
        }

        /// <summary>A list of public IP prefix resources.</summary>
        [AllowEmptyCollection]
        [Parameter(Mandatory = false, HelpMessage = "A list of public IP prefix resources.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"A list of public IP prefix resources.",
            SerializedName = @"publicIPPrefixes",
            PossibleTypes = new[] {typeof(IResourceReference)})]
        public IResourceReference[] OutboundIPPrefixPublicIpprefix
        {
            get => ParametersBody.OutboundIPPrefixPublicIpprefix ?? null /* arrayOf */;
            set => ParametersBody.OutboundIPPrefixPublicIpprefix = value;
        }

        /// <summary>A list of public IP resources.</summary>
        [AllowEmptyCollection]
        [Parameter(Mandatory = false, HelpMessage = "A list of public IP resources.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"A list of public IP resources.",
            SerializedName = @"publicIPs",
            PossibleTypes = new[] {typeof(IResourceReference)})]
        public IResourceReference[] OutboundIPPublicIP
        {
            get => ParametersBody.OutboundIPPublicIP ?? null /* arrayOf */;
            set => ParametersBody.OutboundIPPublicIP = value;
        }

        /// <summary>Managed cluster.</summary>
        protected IManagedCluster ParametersBody
        {
            get => _parametersBody;
            set => _parametersBody = value;
        }

        /// <summary>
        ///     The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.HttpPipeline" /> that the remote call
        ///     will use.
        /// </summary>
        protected HttpPipeline Pipeline { get; set; }

        /// <summary>The URI for the proxy server to use</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [Category(ParameterCategory.Runtime)]
        public Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [Parameter(Mandatory = false, DontShow = true,
            HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [ValidateNotNull]
        [Category(ParameterCategory.Runtime)]
        public PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [Category(ParameterCategory.Runtime)]
        public SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>The ID for the service principal.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The ID for the service principal.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The ID for the service principal.",
            SerializedName = @"clientId",
            PossibleTypes = new[] {typeof(string)})]
        public string ServicePrincipalProfileClientId
        {
            get => ParametersBody.ServicePrincipalProfileClientId ?? null;
            set => ParametersBody.ServicePrincipalProfileClientId = value;
        }

        /// <summary>The secret password associated with the service principal in plain text.</summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The secret password associated with the service principal in plain text.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The secret password associated with the service principal in plain text.",
            SerializedName = @"secret",
            PossibleTypes = new[] {typeof(string)})]
        public string ServicePrincipalProfileSecret
        {
            get => ParametersBody.ServicePrincipalProfileSecret ?? null;
            set => ParametersBody.ServicePrincipalProfileSecret = value;
        }

        /// <summary>
        ///     The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        [AllowEmptyCollection]
        [Parameter(Mandatory = false,
            HelpMessage =
                "The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description =
                @"The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.",
            SerializedName = @"publicKeys",
            PossibleTypes = new[] {typeof(IContainerServiceSshPublicKey)})]
        public IContainerServiceSshPublicKey[] SshPublicKey
        {
            get => ParametersBody.SshPublicKey ?? null /* arrayOf */;
            set => ParametersBody.SshPublicKey = value;
        }

        /// <summary>Resource tags</summary>
        [ExportAs(typeof(Hashtable))]
        [Parameter(Mandatory = false, HelpMessage = "Resource tags")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"Resource tags",
            SerializedName = @"tags",
            PossibleTypes = new[] {typeof(IResourceTags)})]
        public IResourceTags Tag
        {
            get => ParametersBody.Tag ?? null /* object */;
            set => ParametersBody.Tag = value;
        }

        /// <summary>The administrator password to use for Windows VMs.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The administrator password to use for Windows VMs.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The administrator password to use for Windows VMs.",
            SerializedName = @"adminPassword",
            PossibleTypes = new[] { typeof(SecureString) })]
        public SecureString WindowProfileAdminPassword
        {
            get
            {
                SecureString result = null;
                if (ParametersBody.WindowProfileAdminPassword != null)
                {
                    result = new SecureString();
                    Array.ForEach(ParametersBody.WindowProfileAdminPassword.ToCharArray(), result.AppendChar);
                }

                return result;
            }
            set => ParametersBody.WindowProfileAdminPassword = value?.ToString();
        }

        /// <summary>The administrator username to use for Windows VMs.</summary>
        [Parameter(Mandatory = false, HelpMessage = "The administrator username to use for Windows VMs.")]
        [Category(ParameterCategory.Body)]
        [Info(
            Required = false,
            ReadOnly = false,
            Description = @"The administrator username to use for Windows VMs.",
            SerializedName = @"adminUsername",
            PossibleTypes = new[] {typeof(string)})]
        public string WindowProfileAdminUsername
        {
            get => ParametersBody.WindowProfileAdminUsername ?? null;
            set => ParametersBody.WindowProfileAdminUsername = value;
        }

        /// <summary>
        ///     <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        Action IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
        CancellationToken IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the message is completed.
        /// </returns>
        async Task IEventListener.Signal(string id, CancellationToken token, Func<EventData> messageData)
        {
            using (NoSynchronizationContext)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                switch (id)
                {
                    case Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? string.Empty)}");
                        return;
                    }
                    case Runtime.Events.Error:
                    {
                        WriteError(new ErrorRecord(new Exception(messageData().Message), string.Empty,
                            ErrorCategory.NotSpecified, null));
                        return;
                    }
                    case Runtime.Events.DelayBeforePolling:
                    {
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            var data = messageData();
                            if (data.ResponseMessage is HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = string.IsNullOrEmpty(asyncOperation)
                                    ? string.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri :
                                    location
                                    : asyncOperation;
                                WriteObject(new AsyncOperationResponse {Target = uri});
                                // do nothing more.
                                data.Cancel();
                                return;
                            }
                        }

                        break;
                    }
                }

                await Module.Instance.Signal(id, token, messageData,
                    (i, t, m) =>
                        ((IEventListener) this).Signal(i, t, () => EventDataConverter.ConvertFrom(m()) as EventData),
                    InvocationInformation, ParameterSetName, __correlationId, __processRecordId, null);
                if (token.IsCancellationRequested)
                {
                    return;
                }

                WriteDebug($"{id}: {(messageData().Message ?? string.Empty)}");
            }
        }

        /// <summary>
        ///     <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of
        ///     what
        ///     happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.ICloudError" /> from the
        ///     remote call
        /// </param>
        /// <param name="returnNow">
        ///     /// Determines if the rest of the onDefault method should be processed, or if the method should
        ///     return immediately (set to true to skip further processing )
        /// </param>
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<ICloudError> response,
            ref Task<bool> returnNow);

        /// <summary>
        ///     <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what
        ///     happens
        ///     on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedCluster" /> from
        ///     the remote call
        /// </param>
        /// <param name="returnNow">
        ///     /// Determines if the rest of the onOk method should be processed, or if the method should return
        ///     immediately (set to true to skip further processing )
        /// </param>
        partial void overrideOnOk(HttpResponseMessage responseMessage, Task<IManagedCluster> response,
            ref Task<bool> returnNow);

        /// <summary>
        ///     (overrides the default BeginProcessing method in System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                AttachDebugger.Break();
            }

            ((IEventListener) this).Signal(Runtime.Events.CmdletBeginProcessing).Wait();
            if (((IEventListener) this).Token.IsCancellationRequested)
            {
                return;
            }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of NewAzAks_SimpleParameterSet</returns>
        public NewAzAks Clone()
        {
            var clone = new NewAzAks();
            clone.__correlationId = __correlationId;
            clone.__processRecordId = __processRecordId;
            clone.DefaultProfile = DefaultProfile;
            clone.InvocationInformation = InvocationInformation;
            clone.Proxy = Proxy;
            clone.Pipeline = Pipeline;
            clone.AsJob = AsJob;
            clone.Break = Break;
            clone.ProxyCredential = ProxyCredential;
            clone.ProxyUseDefaultCredentials = ProxyUseDefaultCredentials;
            clone.HttpPipelinePrepend = HttpPipelinePrepend;
            clone.HttpPipelineAppend = HttpPipelineAppend;
            clone.ParametersBody = ParametersBody;
            clone.SubscriptionId = SubscriptionId;
            clone.ResourceGroupName = ResourceGroupName;
            clone.Name = Name;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            ((IEventListener) this).Signal(Runtime.Events.CmdletEndProcessing).Wait();
            if (((IEventListener) this).Token.IsCancellationRequested)
            {
                return;
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordStart).Wait();
            if (((IEventListener) this).Token.IsCancellationRequested)
            {
                return;
            }

            __processRecordId = Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'ManagedClustersCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = Clone();
                        var job = new AsyncJob(instance, MyInvocation.Line, MyInvocation.MyCommand.Name,
                            _cancellationTokenSource.Token, _cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using (var asyncCommandRuntime = new AsyncCommandRuntime(this, ((IEventListener) this).Token))
                        {
                            asyncCommandRuntime.Wait(ProcessRecordAsync(), ((IEventListener) this).Token);
                        }
                    }
                }
            }
            catch (AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach (var innerException in aggregateException.Flatten().InnerExceptions)
                {
                    ((IEventListener) this).Signal(Runtime.Events.CmdletException,
                            $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}")
                        .Wait();
                    if (((IEventListener) this).Token.IsCancellationRequested)
                    {
                        return;
                    }

                    // Write exception out to error channel.
                    WriteError(new ErrorRecord(innerException, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }
            catch (Exception exception) when ((exception as PipelineStoppedException) == null ||
                                              (exception as PipelineStoppedException).InnerException != null)
            {
                ((IEventListener) this).Signal(Runtime.Events.CmdletException,
                    $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait();
                if (((IEventListener) this).Token.IsCancellationRequested)
                {
                    return;
                }

                // Write exception out to error channel.
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null));
            }
            finally
            {
                ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }

        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async Task ProcessRecordAsync()
        {
            using (NoSynchronizationContext)
            {
                await ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordAsyncStart);
                if (((IEventListener) this).Token.IsCancellationRequested)
                {
                    return;
                }

                await ((IEventListener) this).Signal(Runtime.Events.CmdletGetPipeline);
                if (((IEventListener) this).Token.IsCancellationRequested)
                {
                    return;
                }

                Pipeline = Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((CommandRuntime as IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ??
                                     HttpPipelinePrepend);
                }

                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((CommandRuntime as IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ??
                                    HttpPipelineAppend);
                }

                // get the client instance
                try
                {
                    await ((IEventListener) this).Signal(Runtime.Events.CmdletBeforeAPICall);
                    if (((IEventListener) this).Token.IsCancellationRequested)
                    {
                        return;
                    }

                    var newCluster = BuildNewCluster();
                    await Client.ManagedClustersCreateOrUpdate(SubscriptionId, ResourceGroupName, Name, newCluster,
                        onOk, onDefault, this, Pipeline);

                    await ((IEventListener) this).Signal(Runtime.Events.CmdletAfterAPICall);
                    if (((IEventListener) this).Token.IsCancellationRequested)
                    {
                        return;
                    }
                }
                catch (UndeclaredResponseException urexception)
                {
                    WriteError(new ErrorRecord(urexception, urexception.StatusCode.ToString(),
                        ErrorCategory.InvalidOperation,
                        new
                        {
                            SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name,
                            body = ParametersBody
                        })
                    {
                        ErrorDetails = new ErrorDetails(urexception.Message) {RecommendedAction = urexception.Action}
                    });
                }
                finally
                {
                    await ((IEventListener) this).Signal(Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        protected virtual async Task ProcessInternal()
        {
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((IEventListener) this).Cancel();
            base.StopProcessing();
        }

        /// <summary>
        ///     a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.ICloudError" /> from the
        ///     remote call
        /// </param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async Task onDefault(HttpResponseMessage responseMessage, Task<ICloudError> response)
        {
            using (NoSynchronizationContext)
            {
                var _returnNow = Task.FromResult(false);
                overrideOnDefault(responseMessage, response, ref _returnNow);
                // if overrideOnDefault has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return;
                }

                // Error Response : default
                var code = (await response)?.Code;
                var message = (await response)?.Message;
                if ((null == code || null == message))
                {
                    // Unrecognized Response. Create an error record based on what we have.
                    var ex = new RestException<ICloudError>(responseMessage, await response);
                    WriteError(new ErrorRecord(ex, ex.Code, ErrorCategory.InvalidOperation,
                        new
                        {
                            SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name,
                            body = ParametersBody
                        })
                    {
                        ErrorDetails = new ErrorDetails(ex.Message) {RecommendedAction = ex.Action}
                    });
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception($"[{code}] : {message}"), code?.ToString(),
                        ErrorCategory.InvalidOperation,
                        new
                        {
                            SubscriptionId = SubscriptionId, ResourceGroupName = ResourceGroupName, Name = Name,
                            body = ParametersBody
                        })
                    {
                        ErrorDetails = new ErrorDetails(message) {RecommendedAction = string.Empty}
                    });
                }
            }
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">
        ///     the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedCluster" /> from
        ///     the remote call
        /// </param>
        /// <returns>
        ///     A <see cref="Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async Task onOk(HttpResponseMessage responseMessage, Task<IManagedCluster> response)
        {
            using (NoSynchronizationContext)
            {
                var _returnNow = Task.FromResult(false);
                overrideOnOk(responseMessage, response, ref _returnNow);
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return;
                }

                // onOk - response for 200 / application/json
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedCluster
                WriteObject((await response));
            }
        }

        protected IManagedCluster BuildNewCluster()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Location))
            {
                var rg = RmClient.ResourceGroups.Get(ResourceGroupName);
                Location = rg.Location;

                var validLocations = RmClient.Providers.Get("Microsoft.ContainerService").ResourceTypes.ToList()
                    .Find(x => x.ResourceType.Equals("managedClusters")).Locations;
                validLocations = validLocations
                    .Select(l => l.Replace(" ", string.Empty).Replace("-", string.Empty).ToLower()).ToList();
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

            if (string.IsNullOrEmpty(DnsPrefix))
            {
                DnsPrefix = DefaultDnsPrefix();
            }

            WriteVerbose(string.Format(Resources.UsingDnsNamePrefix, DnsPrefix));
            SshKeyValue = GetSshKey(SshKeyValue);

            var defaultAgentPoolProfile = new ManagedClusterAgentPoolProfile()
            {
                Name = "default",
                VMSize = NodeVmSize,
                Count = NodeCount,
                OSDiskSizeGb = NodeOsDiskSize,
            };

            var keyData = new {KeyData = SshKeyValue};
            var pubKey =
                new ContainerServiceSshPublicKey[] {new ContainerServiceSshPublicKey(new PSObject(keyData))};

            var linuxProfile =
                new ContainerServiceLinuxProfile()
                {
                    AdminUsername = string.IsNullOrEmpty(LinuxProfileAdminUsername)
                        ? "azureuser"
                        : LinuxProfileAdminUsername,
                    SshPublicKey = pubKey
                };

            var aksServicePrincipal =
                EnsureServicePrincipal(ServicePrincipalProfileClientId, ServicePrincipalProfileSecret);
            ServicePrincipalProfileClientId = aksServicePrincipal.SpId;
            ServicePrincipalProfileSecret = aksServicePrincipal.ClientSecret;

            //var spProfile = new ContainerServiceServicePrincipalProfile(
            //    aksServicePrincipal.SpId,
            //    aksServicePrincipal.ClientSecret);

            WriteVerbose(string.Format(Resources.DeployingYourManagedKubeCluster, AcsSpFilePath));

            AgentPoolProfile = new[] { defaultAgentPoolProfile };
            LinuxProfileAdminUsername = string.IsNullOrEmpty(LinuxProfileAdminUsername) ? "azureuser" : LinuxProfileAdminUsername;
            SshPublicKey = pubKey;

            return ParametersBody;
        }

        /// <summary>
        ///     Fetch SSH public key string
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
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh",
                "id_rsa.pub");
            if (!AzureSession.Instance.DataStore.FileExists(path))
            {
                throw new ArgumentException(string.Format(Resources.CouldNotFindSshPublicKeyInError, path, helpLink));
            }

            WriteVerbose(string.Format(Resources.FetchSshPublicKeyFromFile, path));
            return AzureSession.Instance.DataStore.ReadFileAsText(path);

            // we didn't find an SSH key and there was no SSH public key in the home directory
        }


        protected AksServicePrincipal EnsureServicePrincipal(string spId = null, string clientSecret = null)
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
                var url = $"http://{salt}.{DnsPrefix}.{Location}.cloudapp.azure.com";

                acsServicePrincipal = BuildServicePrincipal(Name, url, clientSecret);
                WriteVerbose(Resources.CreatedANewServicePrincipalAndAssignedTheContributorRole);
                StoreServicePrincipal(acsServicePrincipal);
            }

            return acsServicePrincipal;
        }

        private AksServicePrincipal BuildServicePrincipal(string name, string url, string clientSecret)
        {
            var pwCreds = new PasswordCredential(
                value: clientSecret,
                startDate: DateTime.UtcNow,
                endDate: DateTime.UtcNow.AddYears(2));

            var app = GraphClient.Applications.Create(new ApplicationCreateParameters(
                false,
                name,
                new List<string> {url},
                url,
                passwordCredentials: new List<PasswordCredential> {pwCreds}));

            ServicePrincipal sp = null;
            var success = RetryAction(() =>
            {
                var spCreateParams = new ServicePrincipalCreateParameters(
                    app.AppId,
                    true,
                    passwordCredentials: new List<PasswordCredential> {pwCreds});
                sp = GraphClient.ServicePrincipals.Create(spCreateParams);
            }, Resources.ServicePrincipalCreate);

            if (!success)
            {
                throw new CmdletInvocationException(Resources
                    .CouldNotCreateAServicePrincipalWithTheRightPermissionsAreYouAnOwner);
            }

            AddSubscriptionRoleAssignment("Contributor", sp.ObjectId);
            return new AksServicePrincipal {SpId = app.AppId, ClientSecret = clientSecret};
        }

        protected bool Exists()
        {
            try
            {
                var exists =
                    Client.ManagedClustersGet(SubscriptionId, ResourceGroupName, Name, onOk, onDefault, this,
                        Pipeline) != null;
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
                    TestMockSupport.Delay(1000 * i);
                }
            }

            return success;
        }

        protected AksServicePrincipal LoadServicePrincipal()
        {
            var config = LoadServicePrincipals();
            return config?[DefaultContext.Subscription.Id];
        }

        protected Dictionary<string, AksServicePrincipal> LoadServicePrincipals()
        {
            return AzureSession.Instance.DataStore.FileExists(AcsSpFilePath)
                ? JsonConvert.DeserializeObject<Dictionary<string, AksServicePrincipal>>(
                    AzureSession.Instance.DataStore.ReadFileAsText(AcsSpFilePath))
                : null;
        }

        protected void StoreServicePrincipal(AksServicePrincipal acsServicePrincipal)
        {
            var config = LoadServicePrincipals() ?? new Dictionary<string, AksServicePrincipal>();
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
        ///     Build a semi-random DNS prefix based on the name of the cluster, resource group, and last 6 digits of the
        ///     subscription
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