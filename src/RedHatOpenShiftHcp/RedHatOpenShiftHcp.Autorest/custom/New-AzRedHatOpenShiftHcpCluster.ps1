
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an ARO-HCP cluster, auto-wiring the identity list and etcd KMS encryption type.
.Description
Wraps the generated cluster-create cmdlet (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\New-AzRedHatOpenShiftHcpCluster, which also exposes the raw -Resource /
-JsonFilePath / -JsonString creation paths). You pass only the operator-identity maps + KMS vault/key;
this cmdlet:
  * resolves bare identity names to full resource IDs (via the subscription/RG from -PlatformSubnetId),
  * derives -UserAssignedIdentity = control-plane operators + service MI (so you don't build it), and
  * hardcodes the etcd customer-managed encryption type to KMS.
`-UserAssignedIdentity` and `-CustomerManagedEncryptionType` are therefore not exposed here.
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster
#>
function New-AzRedHatOpenShiftHcpCluster {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster])]
    [CmdletBinding(DefaultParameterSetName = 'CreateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('HcpOpenShiftClusterName')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String]
        # The name of the HcpOpenShiftCluster.
        ${Name},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String]
        # The name of the resource group. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription. The value must be an UUID.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The geo-location where the resource lives.
        ${Location},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # name is the name of the keyvault key used for encryption/decryption.
        ${ActiveKeyName},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # version contains the version of the key to use.
        ${ActiveKeyVersion},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String[]]
        # The list of authorized IPv4 CIDR blocks allowed to access the API server. Maximum 500 entries.
        ${ApiAuthorizedCidR},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("Public", "Private")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The internet visibility of the OpenShift API server.
        ${ApiVisibility},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # maxNodeProvisionTimeSeconds: max time to wait for node provisioning. Default 900s.
        ${AutoscalingMaxNodeProvisionTimeSecond},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # maxNodesTotal: maximum allowable number of nodes for scale-out.
        ${AutoscalingMaxNodesTotal},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # maxPodGracePeriod: max seconds to wait for graceful pod termination before scaling down. Default 600s.
        ${AutoscalingMaxPodGracePeriodSecond},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # podPriorityThreshold. Default -10.
        ${AutoscalingPodPriorityThreshold},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # Cluster image registry state. Default Enabled.
        ${ClusterImageRegistryState},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("None", "FIPS")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # Cryptographic restrictions for kernel and userspace libraries.
        ${CryptoRestriction},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # BaseDomainPrefix for the cluster DNS.
        ${DnsBaseDomainPrefix},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Determines whether to enable a system-assigned identity for the resource.
        ${EnableSystemAssignedIdentity},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IImageDigestMirror[]]
        # imageDigestMirrors rules.
        ${ImageDigestMirror},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("Public", "Private", "Disabled")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The type of the default cluster ingress.
        ${IngressType},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # vaultName is the name of the keyvault that contains the secret.
        ${KmVaultName},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("Public", "Private")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # visibility of the keyvault that contains the secret.
        ${KmVisibility},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # Network host prefix.
        ${NetworkHostPrefix},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The CIDR block from which to assign machine IP addresses.
        ${NetworkMachineCidr},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The CIDR of the pod IP addresses.
        ${NetworkPodCidr},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The CIDR block for assigned service IPs.
        ${NetworkServiceCidr},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("OVNKubernetes", "Other")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The main controller responsible for rendering the core networking components.
        ${NetworkType},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # nodeDrainTimeoutMinutes default for all NodePools.
        ${NodeDrainTimeoutMinute},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # Resource group name to put cluster resources (managed RG).
        ${PlatformManagedResourceGroup},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # ResourceId for the NSG attached to the cluster subnet.
        ${PlatformNetworkSecurityGroupId},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.PSArgumentCompleterAttribute("LoadBalancer")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The core outgoing configuration.
        ${PlatformOutboundType},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The Azure resource ID of the worker subnet.
        ${PlatformSubnetId},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The Azure resource ID of the VNet-integration subnet.
        ${PlatformVnetIntegrationSubnetId},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ITrackedResourceTags]))]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IUserAssignedIdentitiesProfileControlPlaneOperators]))]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Collections.Hashtable]
        # Control-plane operator identities: @{ '<operator-name>' = '<resource-id-or-bare-name>' }.
        ${UserAssignedIdentityControlPlaneOperator},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IUserAssignedIdentitiesProfileDataPlaneOperators]))]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Collections.Hashtable]
        # Data-plane operator identities: @{ '<operator-name>' = '<resource-id-or-bare-name>' }.
        ${UserAssignedIdentityDataPlaneOperator},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The service managed identity (resource ID or bare name).
        ${UserAssignedIdentityServiceManagedIdentity},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # ChannelGroup (e.g. stable / fast).
        ${VersionChannelGroup},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # ID is the desired X.Y version of the cluster control plane.
        ${VersionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional. Use SubscriptionId instead.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job.
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach.
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline.
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline.
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously.
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use.
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call.
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy.
        ${ProxyUseDefaultCredentials}
    )

    process {
        $subnetId = if ($PSBoundParameters.ContainsKey('PlatformSubnetId')) { $PlatformSubnetId } else { $null }
        $resolver = [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom.IdentityResolver]

        # Resolve bare identity names to full resource IDs (control-plane, data-plane, service MI).
        if ($PSBoundParameters.ContainsKey('UserAssignedIdentityControlPlaneOperator')) {
            $cp = @{}
            foreach ($k in $UserAssignedIdentityControlPlaneOperator.Keys) {
                $cp[$k] = $resolver::Resolve([string]$UserAssignedIdentityControlPlaneOperator[$k], $subnetId)
            }
            $PSBoundParameters['UserAssignedIdentityControlPlaneOperator'] = $cp
        }
        if ($PSBoundParameters.ContainsKey('UserAssignedIdentityDataPlaneOperator')) {
            $dp = @{}
            foreach ($k in $UserAssignedIdentityDataPlaneOperator.Keys) {
                $dp[$k] = $resolver::Resolve([string]$UserAssignedIdentityDataPlaneOperator[$k], $subnetId)
            }
            $PSBoundParameters['UserAssignedIdentityDataPlaneOperator'] = $dp
        }
        $service = $null
        if ($PSBoundParameters.ContainsKey('UserAssignedIdentityServiceManagedIdentity')) {
            $service = $resolver::Resolve([string]$UserAssignedIdentityServiceManagedIdentity, $subnetId)
            $PSBoundParameters['UserAssignedIdentityServiceManagedIdentity'] = $service
        }

        # Derive the flat ARM identity list = control-plane operators + service MI (NOT data-plane),
        # so the caller never builds it by hand.
        $flat = [System.Collections.Generic.List[string]]::new()
        if ($PSBoundParameters.ContainsKey('UserAssignedIdentityControlPlaneOperator')) {
            foreach ($v in $PSBoundParameters['UserAssignedIdentityControlPlaneOperator'].Values) { $flat.Add([string]$v) }
        }
        if ($service) { $flat.Add($service) }
        if ($flat.Count -gt 0) {
            $PSBoundParameters['UserAssignedIdentity'] = @($flat | Select-Object -Unique)
        }

        # Hardcode the etcd customer-managed encryption type (the only supported value).
        $PSBoundParameters['CustomerManagedEncryptionType'] = 'KMS'

        # Forward to the hidden generated cmdlet (identity.type=UserAssigned and
        # keyManagementMode=CustomerManaged are set by the generator from the above).
        Az.RedHatOpenShiftHcp.internal\New-AzRedHatOpenShiftHcpCluster @PSBoundParameters
    }
}
