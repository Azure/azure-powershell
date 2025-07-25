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
    $env.Location = "eastus"
    $env.WaaSTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    $env.ResourceGroupName = "PS_CLI_TF_RG"
    $env.WaaSSubscriptionId = "49d64d54-e966-4c46-a868-1999802b762c"
    $env.SapVirtualInstanceName = "PS1"
    $env.SapApplicationInstanceName = "ps1appvm0-0"
    $env.SapCentralInstanceName = "ps1ascsvm-0"
    $env.SapDatabseInstanceName = "PS1"
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
    $env.ConfigPath = "CreateSVIConfig.json"
    $env.IdentityName = @{
        '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}
    }
    $env.IdentityType = "UserAssigned"
    $env.MSIPath = "msi.json"
    $env.DiscoverSVI = "PS1"
    $env.DiscoverRG = "PS_CLI_TF_RG"
    $env.MrgRGName = "PS2-rg"
    $env.MrgSAName = "acssstoragel46"
    $env.MrgNetAccTyp = "Private"
    $env.CentralServerVmId = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Compute/virtualMachines/ps1ascsvm"
    $env.MonitorRg = "suha-0802-rg1"
    $env.HaMonitorSubnetRg = "nitin-agarwal-scale-test"
    $env.MonitorSubnetRg = "e2e-portal-wlmonitor-do-not-delete"
    $env.MonitorRg = "suha-0802-rg1"
    $env.MonitorName = "suha-160323-ams7"
    $env.HaMonitorName = "suha-160323-ams9"
    $env.CreateHaMonitorName = "suha-170323-ams4"
    $env.CreateMonitorName = "suha-170323-ams3"
    $env.MonitorSubnet = "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorSubnetRg)/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1703-2"
    $env.HaMonitorSubnet = "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.HaMonitorSubnetRg)/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1603-3"
    $env.haProviderName = "suha-ha-1"
    $env.sqlProviderName = "suha-sql-1"
    $env.nwProviderName = "suha-nw-1"
    $env.hanaProviderName = "suha-hana-1"
    $env.db2ProviderName = "suha-db2-1"
    $env.osProviderName = "suha-os-1"
    $env.DeletionRG = "PS_CLI_TF_RG"
    $env.DeletionVIS = "PS1"
    $env.DeletionVISID = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PS_CLI_TF_RG/providers/Microsoft.Workloads/sapVirtualInstances/PS2"
    $env.DeletionVISAppID = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/AH9-vis-hana/providers/Microsoft.Workloads/sapVirtualInstances/A27/applicationInstances/app0"
    $env.DeletionVISCsID = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/AH9-vis-hana/providers/Microsoft.Workloads/sapVirtualInstances/A27/centralInstances/cs0"
    $env.DeletionVISDbID = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/AH9-vis-hana/providers/Microsoft.Workloads/sapVirtualInstances/A27/databaseInstances/db0"
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