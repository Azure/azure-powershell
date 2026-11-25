
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
# ----------------------------------------------------------------------------------

<#
.Synopsis
List installable HCP OpenShift versions, with optional control-plane / node-pool views.
.Description
Wraps the generated version-list cmdlet (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Get-AzRedHatOpenShiftHcpVersion). For CLI parity (az aro hcp
get-versions), the list output is filtered to **enabled** versions and sorted ascending by semver —
disabled versions are hidden. `-ControlPlane` returns the distinct **MAJOR.MINOR** versions a CLUSTER
accepts; `-NodePool` (and the default list) returns the full **X.Y.Z** patch versions a NODE POOL
requires. The two switches are mutually exclusive. A single lookup by `-Name` is returned as-is
(explicit requests are not filtered).

Output types differ by view: the default list, `-NodePool`, and `-Name` return the full
`IHcpOpenShiftVersion` model; `-ControlPlane` returns a summarized projection — a `PSCustomObject`
with `Name` (MAJOR.MINOR) and `ChannelGroup` — because a MAJOR.MINOR value is not a real version
resource and must not masquerade as one.
.Example
Get-AzRedHatOpenShiftHcpVersion -Location westeurope -ControlPlane
.Example
Get-AzRedHatOpenShiftHcpVersion -Location westeurope -NodePool
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftVersion
.Outputs
System.Management.Automation.PSCustomObject
#>
function Get-AzRedHatOpenShiftHcpVersion {
    # Default/-NodePool/-Name views emit the full version model; -ControlPlane emits a PSCustomObject
    # (Name = MAJOR.MINOR, ChannelGroup). Both declared so the output contract matches every view.
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftVersion], [System.Management.Automation.PSCustomObject])]
    [CmdletBinding(DefaultParameterSetName = 'List', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Parameter(ParameterSetName = 'List', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String]
        # The name of the Azure region.
        ${Location},

        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Parameter(ParameterSetName = 'GetViaIdentityLocation', Mandatory)]
        [Alias('HcpOpenShiftVersionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String]
        # The name of the HcpOpenShiftVersion.
        ${Name},

        [Parameter(ParameterSetName = 'Get')]
        [Parameter(ParameterSetName = 'List')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String[]]
        # The ID of the target subscription. Defaults to the current Az context subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'GetViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity]
        # Identity Parameter.
        ${InputObject},

        [Parameter(ParameterSetName = 'GetViaIdentityLocation', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity]
        # Identity Parameter.
        ${LocationInputObject},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Return the distinct MAJOR.MINOR versions a cluster accepts (enabled only, sorted). For -VersionId on New/Update-Cluster.
        ${ControlPlane},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Return the full X.Y.Z patch versions a node pool requires (enabled only, sorted). For -VersionId on New-NodePool.
        ${NodePool},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional. Use SubscriptionId instead.
        ${DefaultProfile},

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
        if ($ControlPlane -and $NodePool) {
            throw '-ControlPlane and -NodePool cannot be used together.'
        }

        # Forward everything except our view switches to the hidden generated cmdlet.
        $invoke = @{}
        foreach ($p in 'Location', 'Name', 'SubscriptionId', 'InputObject', 'LocationInputObject',
            'DefaultProfile', 'Break', 'HttpPipelineAppend', 'HttpPipelinePrepend', 'Proxy',
            'ProxyCredential', 'ProxyUseDefaultCredentials') {
            if ($PSBoundParameters.ContainsKey($p)) { $invoke[$p] = $PSBoundParameters[$p] }
        }
        $versions = Az.RedHatOpenShiftHcp.internal\Get-AzRedHatOpenShiftHcpVersion @invoke

        # A single explicit lookup (-Name / identity) is returned as-is — explicit requests are not
        # filtered. Curate (enabled + sort) for the LIST default and for either view switch.
        $isList = $PSCmdlet.ParameterSetName -eq 'List'
        if (-not ($ControlPlane -or $NodePool -or $isList)) {
            return $versions
        }

        # enabled-only (treat a missing 'enabled' as enabled, matching the CLI's get('enabled', True)),
        # ascending by semver.
        $sorted = @($versions | Where-Object { $_.Enabled -ne $false }) |
            Sort-Object -Property @{ Expression = { try { [version]$_.Name } catch { [version]'0.0.0' } } }

        if ($ControlPlane) {
            # distinct MAJOR.MINOR (first occurrence wins; ascending). Emits a summarized PSCustomObject
            # (declared in OutputType) rather than IHcpOpenShiftVersion: a MAJOR.MINOR value is not a real
            # version resource, so returning a full model with Name='4.22' but Id='.../4.22.18' would be a lie.
            $seen = [System.Collections.Generic.HashSet[string]]::new()
            foreach ($v in $sorted) {
                $parts = "$($v.Name)" -split '\.'
                if ($parts.Count -ge 2) {
                    $xy = "$($parts[0]).$($parts[1])"
                    if ($seen.Add($xy)) {
                        [pscustomobject]@{ Name = $xy; ChannelGroup = $v.ChannelGroup }
                    }
                }
            }
            return
        }

        # Default (list) and -NodePool: enabled-only full X.Y.Z, sorted (CLI parity: default == node-pool view).
        return $sorted
    }
}
