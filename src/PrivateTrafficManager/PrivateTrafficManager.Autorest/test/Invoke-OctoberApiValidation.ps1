#Requires -Version 7.0
[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$SubscriptionId,
    [Parameter(Mandatory)]
    [string]$ResourceGroupName,
    [Parameter(Mandatory)]
    [string]$GatewayId,
    [Parameter(Mandatory)]
    [string]$VirtualNetworkId,
    [Parameter(Mandatory)]
    [string]$Location,
    [ValidateSet('Live', 'Record', 'Playback')]
    [string]$Mode = 'Playback',
    [string]$RecordingPath = (Join-Path $PSScriptRoot 'OctoberApi-Sanitized.Recording.json')
)

$ErrorActionPreference = 'Stop'
Import-Module Pester -MinimumVersion 5.0 -ErrorAction Stop
$accountsPath = Join-Path $PSScriptRoot '../../../../artifacts/Debug/Az.Accounts/Az.Accounts.psd1'
Import-Module $accountsPath -ErrorAction Stop
$modulePath = Join-Path $PSScriptRoot '../../../../artifacts/Debug/Az.PrivateTrafficManager/Az.PrivateTrafficManager.psd1'
Import-Module $modulePath -Force -ErrorAction Stop
if ($Mode -eq 'Record' -and (Test-Path $RecordingPath)) {
    throw 'Use a new recording path to avoid mixing validation runs.'
}
$recorder = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Runtime.PipelineMock]::new($RecordingPath)
switch ($Mode) {
    Record { $recorder.SetRecord() }
    Playback { $recorder.SetPlayback(); $recorder.ForceResponseHeaders['Retry-After'] = '0' }
    Live { $recorder.SetLive() }
}
$recorder.PushDescription('October API validation')
$common = @{
    SubscriptionId = $SubscriptionId
    ResourceGroupName = $ResourceGroupName
    HttpPipelinePrepend = $recorder
    ErrorAction = 'Stop'
}
$module = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Module]::Instance
$onNewRequest = $module.OnNewRequest
if ($Mode -eq 'Playback') {
    $module.OnNewRequest = $null
}

function Invoke-ValidationStep {
    param([string]$Name, [scriptblock]$Action)
    $recorder.PushScenario($Name)
    try {
        & $Action
        Write-Information "PASS: $Name" -InformationAction Continue
    }
    finally {
        $recorder.PopScenario()
    }
}

try {
    Invoke-ValidationStep 'Empty test scope' {
        @(Get-AzPrivateTrafficManagerProfile @common).Count | Should -Be 0
        @(Get-AzPrivateTrafficManagerTopologyMap @common).Count | Should -Be 0
    }
    Invoke-ValidationStep 'Basic profile create and PATCH' {
        $ptmProfile = New-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-basic' -Location $Location -CustomTopologyMapMode Disabled -TrafficRoutingMethod Weighted -ProfileStatus Enabled -DnsConfigRecordType A -DnsConfigTtl 30 -Tag @{ purpose = 'powershell-validation' } -Confirm:$false
        $ptmProfile.CustomTopologyMapMode | Should -Be 'Disabled'
        $ptmProfile.ProvisioningState | Should -Be 'Succeeded'
        $null = Update-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-basic' -DnsConfigTtl 60 -Confirm:$false
        $ptmProfile = Get-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-basic'
        $ptmProfile.DnsConfigTtl | Should -Be 60
        $ptmProfile.TrafficRoutingMethod | Should -Be 'Weighted'
    }
    Invoke-ValidationStep 'Gateway association CRUD and parent identity' {
        $ptmProfile = Get-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-basic'
        $identity = @{ Id = $ptmProfile.Id }
        $parentCommon = @{ HttpPipelinePrepend = $recorder; ErrorAction = 'Stop' }
        $association = New-AzPrivateTrafficManagerProfileProbingGateway @parentCommon -Name 'gateway' -PrivateTrafficManagerProfileInputObject $identity -ProbingGatewayId $GatewayId -Confirm:$false
        $association.ProbingGatewayId | Should -Be $GatewayId
        $null = Update-AzPrivateTrafficManagerProfileProbingGateway @common -Name 'gateway' -PrivateTrafficManagerProfileName 'pwsh-basic' -ProbingGatewayId $GatewayId -Confirm:$false
        $association = Get-AzPrivateTrafficManagerProfileProbingGateway @parentCommon -Name 'gateway' -PrivateTrafficManagerProfileInputObject $identity
        $association.ProbingGatewayId | Should -Be $GatewayId
        @(Get-AzPrivateTrafficManagerProfileProbingGateway @common -PrivateTrafficManagerProfileName 'pwsh-basic').Count | Should -Be 1
        Remove-AzPrivateTrafficManagerProfileProbingGateway @common -Name 'gateway' -PrivateTrafficManagerProfileName 'pwsh-basic' -Confirm:$false
        @(Get-AzPrivateTrafficManagerProfileProbingGateway @common -PrivateTrafficManagerProfileName 'pwsh-basic').Count | Should -Be 0
    }
    Invoke-ValidationStep 'Health policy GET PUT preserves probe fields' {
        $policy = New-AzPrivateTrafficManagerHealthPolicy @common -Name 'probe' -PrivateTrafficManagerProfileName 'pwsh-basic' -ProbeConfigProtocol HTTPS -ProbeConfigPort 443 -ProbeConfigPath '/health' -ProbeConfigIntervalInSecond 30 -ProbeConfigTimeoutInSecond 10 -ProbeConfigToleratedNumberOfFailure 3 -ProbeConfigCustomHeader @(@{ Name = 'X-Probe'; Value = 'ready' }) -ProbeConfigExpectedStatusCodeRange @(@{ Min = 200; Max = 299 }) -Confirm:$false
        $policy.Kind | Should -Be 'Probe'
        $null = Update-AzPrivateTrafficManagerHealthPolicy @common -Name 'probe' -PrivateTrafficManagerProfileName 'pwsh-basic' -ProbeConfigPath '/ready' -Confirm:$false
        $policy = Get-AzPrivateTrafficManagerHealthPolicy @common -Name 'probe' -PrivateTrafficManagerProfileName 'pwsh-basic'
        $policy.ProbeConfigPath | Should -Be '/ready'
        $policy.ProbeConfigProtocol | Should -Be 'HTTPS'
        $policy.ProbeConfigPort | Should -Be 443
        $policy.ProbeConfigIntervalInSecond | Should -Be 30
        $policy.ProbeConfigTimeoutInSecond | Should -Be 10
        $policy.ProbeConfigToleratedNumberOfFailure | Should -Be 3
        $policy.ProbeConfigCustomHeader[0].Value | Should -Be 'ready'
        $policy.ProbeConfigExpectedStatusCodeRange[0].Max | Should -Be 299
        $script:policyId = $policy.Id
    }
    Invoke-ValidationStep 'Weighted endpoint CRUD' {
        $endpoint = New-AzPrivateTrafficManagerEndpoint @common -Name 'weighted' -PrivateTrafficManagerProfileName 'pwsh-basic' -Target '10.1.0.4' -EndpointStatus Enabled -Weight 10 -HealthPolicyId $script:policyId -Confirm:$false
        $endpoint.Weight | Should -Be 10
        $null = Update-AzPrivateTrafficManagerEndpoint @common -Name 'weighted' -PrivateTrafficManagerProfileName 'pwsh-basic' -Weight 20 -Confirm:$false
        $endpoint = Get-AzPrivateTrafficManagerEndpoint @common -Name 'weighted' -PrivateTrafficManagerProfileName 'pwsh-basic'
        $endpoint.Weight | Should -Be 20
        $endpoint.Target | Should -Be '10.1.0.4'
        $endpoint.HealthPolicyId | Should -Be $script:policyId
        Remove-AzPrivateTrafficManagerEndpoint @common -Name 'weighted' -PrivateTrafficManagerProfileName 'pwsh-basic' -Confirm:$false
        @(Get-AzPrivateTrafficManagerEndpoint @common -PrivateTrafficManagerProfileName 'pwsh-basic').Count | Should -Be 0
        Remove-AzPrivateTrafficManagerHealthPolicy @common -Name 'probe' -PrivateTrafficManagerProfileName 'pwsh-basic' -Confirm:$false
        @(Get-AzPrivateTrafficManagerHealthPolicy @common -PrivateTrafficManagerProfileName 'pwsh-basic').Count | Should -Be 0
    }
    Invoke-ValidationStep 'VNet profile and endpoint assignments' {
        $ptmProfile = New-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-vnet' -Location $Location -CustomTopologyMapMode Disabled -TrafficRoutingMethod VNet -ProfileStatus Enabled -DnsConfigRecordType A -DnsConfigTtl 30 -Confirm:$false
        $ptmProfile.TrafficRoutingMethod | Should -Be 'VNet'
        $endpoint = New-AzPrivateTrafficManagerEndpoint @common -Name 'assigned' -PrivateTrafficManagerProfileName 'pwsh-vnet' -Target '10.1.0.4' -EndpointStatus Enabled -AlwaysServe Enabled -VirtualNetworkId @($VirtualNetworkId) -Confirm:$false
        $endpoint.VirtualNetworkId | Should -Contain $VirtualNetworkId
        $null = New-AzPrivateTrafficManagerEndpoint @common -Name 'fallback' -PrivateTrafficManagerProfileName 'pwsh-vnet' -Target '10.1.0.5' -EndpointStatus Enabled -AlwaysServe Enabled -Confirm:$false
        $null = Update-AzPrivateTrafficManagerEndpoint @common -Name 'assigned' -PrivateTrafficManagerProfileName 'pwsh-vnet' -Target '10.1.0.6' -Confirm:$false
        $endpoint = Get-AzPrivateTrafficManagerEndpoint @common -Name 'assigned' -PrivateTrafficManagerProfileName 'pwsh-vnet'
        $endpoint.Target | Should -Be '10.1.0.6'
        $endpoint.VirtualNetworkId | Should -Contain $VirtualNetworkId
        @(Get-AzPrivateTrafficManagerEndpoint @common -PrivateTrafficManagerProfileName 'pwsh-vnet').Count | Should -Be 2
    }
    Invoke-ValidationStep 'Topology map sites and catch-all PATCH' {
        $null = New-AzPrivateTrafficManagerTopologyMap @common -Name 'pwsh-map' -Location $Location -CatchAllSiteName 'default' -Site @(@{ Name = 'default'; ProbingGatewayId = @($GatewayId); VirtualNetworkId = @($VirtualNetworkId) }) -Tag @{ purpose = 'powershell-validation' } -Confirm:$false
        $site = New-AzPrivateTrafficManagerSite @common -Name 'default' -TopologyMapName 'pwsh-map' -VirtualNetworkId @($VirtualNetworkId) -ProbingGatewayId @($GatewayId) -Confirm:$false
        $site.ProbingGatewayId | Should -Contain $GatewayId
        $null = Update-AzPrivateTrafficManagerSite @common -Name 'default' -TopologyMapName 'pwsh-map' -VirtualNetworkId @($VirtualNetworkId) -Confirm:$false
        $site = Get-AzPrivateTrafficManagerSite @common -Name 'default' -TopologyMapName 'pwsh-map'
        $site.VirtualNetworkId | Should -Contain $VirtualNetworkId
        $null = Update-AzPrivateTrafficManagerTopologyMap @common -Name 'pwsh-map' -CatchAllSiteName 'default' -Tag @{ purpose = 'powershell-validation'; updated = 'true' } -Confirm:$false
        $map = Get-AzPrivateTrafficManagerTopologyMap @common -Name 'pwsh-map'
        $map.CatchAllSiteName | Should -Be 'default'
        $map.Tag['updated'] | Should -Be 'true'
        @($map.Site).Count | Should -Be 1
        @(Get-AzPrivateTrafficManagerSite @common -TopologyMapName 'pwsh-map').Count | Should -Be 1
    }
    Invoke-ValidationStep 'Delete owned resources and verify empty lists' {
        Remove-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-vnet' -Confirm:$false
        Remove-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName 'pwsh-basic' -Confirm:$false
        Remove-AzPrivateTrafficManagerSite @common -Name 'default' -TopologyMapName 'pwsh-map' -Confirm:$false
        @(Get-AzPrivateTrafficManagerSite @common -TopologyMapName 'pwsh-map').Count | Should -Be 0
        Remove-AzPrivateTrafficManagerTopologyMap @common -Name 'pwsh-map' -Confirm:$false
        @(Get-AzPrivateTrafficManagerProfile @common).Count | Should -Be 0
        @(Get-AzPrivateTrafficManagerTopologyMap @common).Count | Should -Be 0
    }
}
finally {
    $module.OnNewRequest = $onNewRequest
    $recorder.PopDescription()
}