
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Update an ARO-HCP cluster, auto-wiring the identity list when operator identities change.
.Description
Wraps the generated cluster-update cmdlet (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Update-AzRedHatOpenShiftHcpCluster, which also exposes the raw -InputObject
/ -Resource paths). When you change operator identities, this cmdlet GET-merges them with the current
cluster so you can rotate a single operator without re-listing all of them:
  * fetches the current cluster and merges your -UserAssignedIdentity*Operator maps into its existing ones,
  * resolves bare identity names to full resource IDs (using the cluster's subnet), and
  * recomputes -UserAssignedIdentity = control-plane operators + service MI (data-plane excluded, matching
    create).
`-UserAssignedIdentity` is therefore not exposed here. If no identity parameter is supplied, the request is
forwarded unchanged (no GET).
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster
#>
function Update-AzRedHatOpenShiftHcpCluster {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # version contains the version of the key to use.
        ${ActiveKeyVersion},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # maxNodeProvisionTimeSeconds. Default 900s.
        ${AutoscalingMaxNodeProvisionTimeSecond},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # maxNodesTotal.
        ${AutoscalingMaxNodesTotal},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # maxPodGracePeriod. Default 600s.
        ${AutoscalingMaxPodGracePeriodSecond},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # podPriorityThreshold. Default -10.
        ${AutoscalingPodPriorityThreshold},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Nullable[System.Boolean]]
        # Determines whether to enable a system-assigned identity for the resource.
        ${EnableSystemAssignedIdentity},

        [Parameter()]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IImageDigestMirror[]]
        # imageDigestMirrors rules.
        ${ImageDigestMirror},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Int32]
        # nodeDrainTimeoutMinutes default for all NodePools.
        ${NodeDrainTimeoutMinute},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ITrackedResourceTags]))]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IUserAssignedIdentitiesProfileControlPlaneOperators]))]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Collections.Hashtable]
        # Control-plane operator identities to set/rotate: @{ '<operator-name>' = '<resource-id-or-bare-name>' }.
        ${UserAssignedIdentityControlPlaneOperator},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IUserAssignedIdentitiesProfileDataPlaneOperators]))]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.Collections.Hashtable]
        # Data-plane operator identities to set/rotate: @{ '<operator-name>' = '<resource-id-or-bare-name>' }.
        ${UserAssignedIdentityDataPlaneOperator},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # The service managed identity (resource ID or bare name).
        ${UserAssignedIdentityServiceManagedIdentity},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Body')]
        [System.String]
        # ChannelGroup (e.g. stable / fast).
        ${VersionChannelGroup},

        [Parameter()]
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
        $identityPassed =
            $PSBoundParameters.ContainsKey('UserAssignedIdentityControlPlaneOperator') -or
            $PSBoundParameters.ContainsKey('UserAssignedIdentityDataPlaneOperator') -or
            $PSBoundParameters.ContainsKey('UserAssignedIdentityServiceManagedIdentity')

        if ($identityPassed) {
            # GET current cluster to merge against (so a single-operator rotation doesn't drop the others).
            $getParams = @{ ResourceGroupName = $ResourceGroupName; Name = $Name }
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $getParams['SubscriptionId'] = $SubscriptionId }
            if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $getParams['DefaultProfile'] = $DefaultProfile }
            $current = Az.RedHatOpenShiftHcp.internal\Get-AzRedHatOpenShiftHcpCluster @getParams
            if (-not $current) { throw "Cluster '$Name' not found in resource group '$ResourceGroupName'." }

            $cj = $current.ToJsonString() | ConvertFrom-Json
            $oa = $cj.properties.platform.operatorsAuthentication.userAssignedIdentities
            $subnetId = $cj.properties.platform.subnetId
            $resolver = [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom.IdentityResolver]

            # Merged control-plane map = current + user overrides (bare names resolved).
            $cp = @{}
            if ($oa -and $oa.controlPlaneOperators) {
                foreach ($p in $oa.controlPlaneOperators.PSObject.Properties) { $cp[$p.Name] = [string]$p.Value }
            }
            if ($PSBoundParameters.ContainsKey('UserAssignedIdentityControlPlaneOperator')) {
                foreach ($k in $UserAssignedIdentityControlPlaneOperator.Keys) {
                    $cp[$k] = $resolver::Resolve([string]$UserAssignedIdentityControlPlaneOperator[$k], $subnetId)
                }
            }

            # Merged data-plane map.
            $dp = @{}
            if ($oa -and $oa.dataPlaneOperators) {
                foreach ($p in $oa.dataPlaneOperators.PSObject.Properties) { $dp[$p.Name] = [string]$p.Value }
            }
            if ($PSBoundParameters.ContainsKey('UserAssignedIdentityDataPlaneOperator')) {
                foreach ($k in $UserAssignedIdentityDataPlaneOperator.Keys) {
                    $dp[$k] = $resolver::Resolve([string]$UserAssignedIdentityDataPlaneOperator[$k], $subnetId)
                }
            }

            # Service MI (overridden if supplied, else keep current).
            if ($PSBoundParameters.ContainsKey('UserAssignedIdentityServiceManagedIdentity')) {
                $service = $resolver::Resolve([string]$UserAssignedIdentityServiceManagedIdentity, $subnetId)
            }
            elseif ($oa -and $oa.serviceManagedIdentity) { $service = [string]$oa.serviceManagedIdentity }
            else { $service = $null }

            # Recompute the flat ARM identity list = control-plane operators + service MI (NOT data-plane).
            $flat = [System.Collections.Generic.List[string]]::new()
            foreach ($v in $cp.Values) { $flat.Add([string]$v) }
            if ($service) { $flat.Add($service) }

            # Send the complete merged desired state.
            $PSBoundParameters['UserAssignedIdentityControlPlaneOperator'] = $cp
            if ($dp.Count -gt 0) { $PSBoundParameters['UserAssignedIdentityDataPlaneOperator'] = $dp }
            if ($service) { $PSBoundParameters['UserAssignedIdentityServiceManagedIdentity'] = $service }
            if ($flat.Count -gt 0) { $PSBoundParameters['UserAssignedIdentity'] = @($flat | Select-Object -Unique) }
        }

        Az.RedHatOpenShiftHcp.internal\Update-AzRedHatOpenShiftHcpCluster @PSBoundParameters
    }
}
