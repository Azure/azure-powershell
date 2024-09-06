function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.Location = "northeurope"
    $env.WaaSTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    $env.ResourceGroupName = "PS_CLI_TF_RG"
    $env.WaaSSubscriptionId = "49d64d54-e966-4c46-a868-1999802b762c"
    $env.SapVirtualInstanceName = "PS6"
    $env.SapApplicationInstanceName = "ps6appvm0-0"
    $env.SapCentralInstanceName = "ps6ascsvm-0"
    $env.SapDatabseInstanceName = "PS6"
    $env.SoftStopTimeoutSecond = 100
    $env.SapProduct = "S4HANA"
    $env.EnviornmentNonProd = "NonProd"
    $env.EnviornmentProd = "Prod"
    $env.DatabaseType = "HANA" 
    $env.DbVMSku = "Standard_E32ds_v4"
    $env.DeploymentType = "SingleServer"
    $env.DeploymentTypeThreeTier = "ThreeTier"
    $env.Saps = "10000"
    $env.DbMemory = "256"
    $env.ProvisioningState = "Succeeded"
    $env.ProvisioningStateSucceeded = "Succeeded"
    $env.TestType = "TestType"
    $env.TestTypeValue = "PS"
    $env.DbScaleMethod = "ScaleUp"
    $env.AppServerIdSub2 = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Workloads/sapVirtualInstances/PS1/applicationInstances/ps1appvm0-0"
    $env.CsServerIdSub2 = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Workloads/sapVirtualInstances/PS1/centralInstances/ps1ascsvm-0"
    $env.DbServerIdSub2 = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Workloads/sapVirtualInstances/PS1/databaseInstances/PS1"
    $env.SapIdSub2 = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Workloads/sapVirtualInstances/PS1"
    $env.SapId = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Workloads/sapVirtualInstances/PS1"
    $env.ResourceGroupCreateSVI = "PS_CLI_TF_RG"
    $env.CreateSVI = "PS2"
    $env.CreateSingleSystemWithCustomResourceTrustedAccessSID = "PS1"
    $env.CreateDistributedSystemWithTrustedAccessNoTransShareSID = "PS2"
    $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareSID = "PS3"
    $env.CreateDistributedHAAvSetDiffTransRgShareSID = "PS4"
    $env.CreateSingleSystemWithNoTrustedAccessSID = "PS5"
    $env.CreateSingleSystemWithCustomResourceTrustedAccessConfigPath = "CreateSingleSystemWithCustomResourceTrustedAccessConfig.json"
    $env.InstallSingleSystemWithCustomResourceTrustedAccessConfigPath = "InstallSingleSystemWithCustomResourceTrustedAccessConfig.json"
    $env.CreateDistributedSystemWithTrustedAccessNoTransShareConfigPath = "CreateDistributedSystemWithTrustedAccessNoTransShareConfig.json"
    $env.CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfigPath = "CreateDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfig.json"
    $env.InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfigPath = "InstallDistributedHAAvZoneWithCustomResourceTrustedAccessTransShareConfig.json"
    $env.CreateDistributedHAAvSetDiffTransRgShareConfigPath = "CreateDistributedHAAvSetDiffTransRgShareConfig.json"
    $env.CreateSingleSystemWithNoTrustedAccessConfigPath = "CreateSingleSystemWithNoTrustedAccessConfig.json"
    $env.NoTransShareConfigType = "Skip"
    $env.MountTransShareConfigType = "Mount"
    $env.IdentityName = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI"
    $env.IdentityType = "UserAssigned"
    $env.DiscoverSVI = "PS1"
    $env.DiscoverRG = "PS_CLI_TF_RG"
    $env.MrgRGName = "PS4-rg"
    $env.MrgSAName = "acssstoragel46"
    $env.MrgNetAccTypPrvt = "Private"
    $env.MrgNetAccTypPub = "Public"
    $env.CentralServerVmId = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Compute/virtualMachines/ascsvm"
    $env.DeletionRG = "PS_CLI_TF_RG"
    $env.DeletionVIS = "PS6"
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}