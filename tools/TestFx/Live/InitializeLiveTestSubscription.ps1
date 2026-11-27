<#
.SYNOPSIS
    Prepares the live test subscription before running live scenarios.

.DESCRIPTION
    The live test tenant is periodically recreated, so subscription level settings do not persist.
    This script is idempotent and runs on every live test job to:
      1. Register the resource providers required by the live scenarios.
      2. Attempt to register optional preview features and report whether they are usable.
      3. Delete stale live test resource groups left behind by crashed or cancelled runs.

    Failures are reported as warnings and do not block the live test run.
#>
[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter()]
    [string[]] $ResourceProviders = @(
        "Microsoft.AlertsManagement",
        "Microsoft.AnalysisServices",
        "Microsoft.App",
        "Microsoft.AppPlatform",
        "Microsoft.Automation",
        "Microsoft.BotService",
        "Microsoft.Compute",
        "Microsoft.ContainerInstance",
        "Microsoft.ContainerRegistry",
        "Microsoft.ContainerService",
        "Microsoft.Databricks",
        "Microsoft.DesktopVirtualization",
        "Microsoft.Insights",
        "Microsoft.KeyVault",
        "Microsoft.Kubernetes",
        "Microsoft.KubernetesConfiguration",
        "Microsoft.ManagedIdentity",
        "Microsoft.Network",
        "Microsoft.OperationalInsights",
        "Microsoft.OperationsManagement",
        "Microsoft.Sql",
        "Microsoft.Storage",
        "Microsoft.Synapse",
        "Microsoft.Web"
    ),

    [Parameter()]
    [ValidateRange(1, [int]::MaxValue)]
    [int] $StaleResourceGroupAgeInHours = 24,

    [Parameter()]
    [ValidateRange(0, 3600)]
    [int] $RegistrationTimeoutInSeconds = 600
)

$ErrorActionPreference = "Stop"

$resourceGroupPrefix = "azpslrg"

$context = Get-AzContext
if ($null -eq $context -or $null -eq $context.Subscription) {
    Write-Host "##[warning]No Azure context found. Skipping live test subscription initialization."
    return
}
$subscriptionId = $context.Subscription.Id
Write-Host "##[section]Initializing live test subscription $subscriptionId"

function Get-ResourceProviderState {
    param ([string] $SubscriptionId)

    $states = @{}
    $path = "/subscriptions/$SubscriptionId/providers?api-version=2021-04-01"
    do {
        $response = Invoke-AzRestMethod -Method GET -Path $path -ErrorAction Stop
        if ($response.StatusCode -ne 200) {
            throw "Failed to list resource providers. Status code: $($response.StatusCode). $($response.Content)"
        }
        $page = $response.Content | ConvertFrom-Json
        foreach ($provider in $page.value) {
            $states[$provider.namespace] = $provider.registrationState
        }
        $path = $null
        if (![string]::IsNullOrWhiteSpace($page.nextLink)) {
            $path = ([uri]$page.nextLink).PathAndQuery
        }
    }
    while ($null -ne $path)

    $states
}

#region Resource providers
Write-Host "##[group]Register resource providers"
$pendingProviders = [System.Collections.Generic.List[string]]::new()
try {
    $providerStates = Get-ResourceProviderState -SubscriptionId $subscriptionId
}
catch {
    Write-Host "##[warning]$($_.Exception.Message)"
    $providerStates = @{}
}

foreach ($rp in $ResourceProviders) {
    try {
        $state = $providerStates[$rp]
        if ($state -eq "Registered") {
            Write-Host "$rp is registered."
            continue
        }

        Write-Host "Registering $rp (current state: $state)."
        if (!$PSCmdlet.ShouldProcess($rp, "Register resource provider")) {
            continue
        }
        Register-AzResourceProvider -ProviderNamespace $rp -ErrorAction Stop | Out-Null
        $pendingProviders.Add($rp)
    }
    catch {
        Write-Host "##[warning]Failed to register resource provider ${rp}: $($_.Exception.Message)"
    }
}

$deadline = (Get-Date).AddSeconds($RegistrationTimeoutInSeconds)
while ($pendingProviders.Count -gt 0 -and (Get-Date) -lt $deadline) {
    Start-Sleep -Seconds 15
    try {
        $providerStates = Get-ResourceProviderState -SubscriptionId $subscriptionId
    }
    catch {
        continue
    }
    foreach ($rp in @($pendingProviders)) {
        if ($providerStates[$rp] -eq "Registered") {
            Write-Host "$rp is registered."
            [void]$pendingProviders.Remove($rp)
        }
    }
}
foreach ($rp in $pendingProviders) {
    Write-Host "##[warning]Resource provider $rp is still registering after $RegistrationTimeoutInSeconds seconds."
}
Write-Host "##[endgroup]"
#endregion

#region Preview features
Write-Host "##[group]Register preview features"
$publicIpTagEnabled = $false
try {
    $feature = Get-AzProviderFeature -ProviderNamespace "Microsoft.Network" -FeatureName "AllowBringYourOwnPublicIpAddress" -ErrorAction Stop
    if ($feature.RegistrationState -ne "Registered") {
        Write-Host "Registering feature Microsoft.Network/AllowBringYourOwnPublicIpAddress (current state: $($feature.RegistrationState))."
        $feature = if ($PSCmdlet.ShouldProcess("Microsoft.Network/AllowBringYourOwnPublicIpAddress", "Register feature")) {
            Register-AzProviderFeature -ProviderNamespace "Microsoft.Network" -FeatureName "AllowBringYourOwnPublicIpAddress" -ErrorAction Stop
        }
        else {
            $feature
        }
        if ($feature.RegistrationState -eq "Registered") {
            Register-AzResourceProvider -ProviderNamespace "Microsoft.Network" | Out-Null
        }
    }

    $publicIpTagEnabled = $feature.RegistrationState -eq "Registered"
    Write-Host "Feature Microsoft.Network/AllowBringYourOwnPublicIpAddress state: $($feature.RegistrationState)."
}
catch {
    Write-Host "##[warning]Failed to register feature Microsoft.Network/AllowBringYourOwnPublicIpAddress: $($_.Exception.Message)"
}

if (!$publicIpTagEnabled) {
    Write-Host "##[warning]Public IP service tags are unavailable on this subscription. Live scenarios will create public IPs without the FirstPartyUsage tag."
}
Write-Host "##vso[task.setvariable variable=LiveTestPublicIpTagEnabled]$($publicIpTagEnabled.ToString().ToLowerInvariant())"
Write-Host "##[endgroup]"
#endregion

#region Stale resource groups
Write-Host "##[group]Clean up stale live test resource groups"
try {
    $listPath = "/subscriptions/$subscriptionId/resourcegroups?api-version=2021-04-01&`$expand=createdTime"
    $resourceGroups = [System.Collections.Generic.List[object]]::new()
    do {
        $response = Invoke-AzRestMethod -Method GET -Path $listPath -ErrorAction Stop
        if ($response.StatusCode -ne 200) {
            throw "Failed to list resource groups. Status code: $($response.StatusCode). $($response.Content)"
        }
        $page = $response.Content | ConvertFrom-Json
        if ($null -ne $page.value) {
            $resourceGroups.AddRange([object[]]$page.value)
        }
        $listPath = $null
        if (![string]::IsNullOrWhiteSpace($page.nextLink)) {
            $listPath = ([uri]$page.nextLink).PathAndQuery
        }
    }
    while ($null -ne $listPath)

    $cutoff = (Get-Date).ToUniversalTime().AddHours(-$StaleResourceGroupAgeInHours)
    $staleResourceGroups = @($resourceGroups | Where-Object {
            $_.name -match "^$resourceGroupPrefix\d[a-zA-Z0-9]{9}$" -and
            $null -ne $_.createdTime -and
            ([datetime]$_.createdTime).ToUniversalTime() -lt $cutoff -and
            $_.properties.provisioningState -ne "Deleting"
        })

    Write-Host "Found $($staleResourceGroups.Count) live test resource group(s) older than $StaleResourceGroupAgeInHours hour(s)."
    foreach ($rg in $staleResourceGroups) {
        if (!$PSCmdlet.ShouldProcess($rg.name, "Delete stale resource group")) {
            continue
        }

        # Issue the delete without waiting; ARM completes the deletion asynchronously.
        $deleteResponse = Invoke-AzRestMethod -Method DELETE -Path "/subscriptions/$subscriptionId/resourcegroups/$($rg.name)?api-version=2021-04-01"
        if ($deleteResponse.StatusCode -in 200, 202, 204, 404, 409) {
            # 409 means another live test job is already deleting the resource group.
            Write-Host "Deleting resource group $($rg.name) created at $($rg.createdTime)."
        }
        else {
            Write-Host "##[warning]Failed to delete resource group $($rg.name). Status code: $($deleteResponse.StatusCode)."
        }
    }
}
catch {
    Write-Host "##[warning]Failed to clean up stale live test resource groups: $($_.Exception.Message)"
}
Write-Host "##[endgroup]"
#endregion
