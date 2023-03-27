function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
    $env.ResourceGroupName = "db0-vis-rg"
    $env.WaaSSubscriptionId = "49d64d54-e966-4c46-a868-1999802b762c"
    $env.SapVirtualInstanceName = "DB0"
    $env.SapApplicationInstanceName = "app0"
    $env.SapCentralInstanceName = "cs0"
    $env.SapDatabseInstanceName = "db0"
    $env.SapProduct = "S4HANA"
    $env.EnviornmentNonProd = "NonProd"
    $env.EnviornmentProd = "Prod"
    $env.DatabaseType = "HANA" 
    $env.DbVMSku = "Standard_M32ts"
    $env.DeploymentType = "SingleServer"
    $env.DeploymentTypeThreeTier = "ThreeTier"
    $env.Saps = "10000"
    $env.DbMemory = "256"
    $env.ProvisioningState = "Succeeded"
    $env.TestType = "TestType"
    $env.TestTypeValue = "PS"
    $env.DbScaleMethod = "ScaleUp"
    $env.AppServerIdSub2 = "/subscriptions/40449e6d-a5d2-40f1-a151-0b76f21a48c0/resourceGroups/DB8-RG/providers/Microsoft.Workloads/sapVirtualInstances/DB8/applicationInstances/db8vm-2"
    $env.CsServerIdSub2 = "/subscriptions/40449e6d-a5d2-40f1-a151-0b76f21a48c0/resourceGroups/DB8-RG/providers/Microsoft.Workloads/sapVirtualInstances/DB8/centralInstances/db8vm-1"
    $env.DbServerIdSub2 = "/subscriptions/40449e6d-a5d2-40f1-a151-0b76f21a48c0/resourceGroups/DB8-RG/providers/Microsoft.Workloads/sapVirtualInstances/DB8/databaseInstances/VB8"
    $env.SapIdSub2 = "/subscriptions/40449e6d-a5d2-40f1-a151-0b76f21a48c0/resourceGroups/DB8-RG/providers/Microsoft.Workloads/sapVirtualInstances/DB8"
    $env.SapId = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0"
    $env.ResourceGroupCreateSVI = "X51Test"
    $env.CreateSVI = "X51"
    $env.ConfigPath = "CreateSVIConfig.json"
    $env.DiscoverSVI = "Y00"
    $env.DiscoverRG = "yb-bugBash"
    $env.CentralServerVmId = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/yb-bugBash/providers/Microsoft.Compute/virtualMachines/y00vm"
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
    $env.DeletionRG = "AH9-vis-hana"
    $env.DeletionVIS = "A26"
    $env.DeletionVISID = "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/AH9-vis-hana/providers/Microsoft.Workloads/sapVirtualInstances/A27"
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

