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

    $resourceGroup = "PowerShellTestRg"
    $env.Add("resourceGroup", $resourceGroup)

    $location = "eastus"
    $env.Add("location", $location)

    $zone = @("2")
    $env.Add("zone", $zone)

    $vnetName = "PSTestVnet"
    $vnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)"
    $env.Add("vnetId", $vnetId)

    $subnetName = "delegated"
    $subnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)/subnets/$($subnetName)"
    $env.Add("subnetId", $subnetId)

    # Exadata Infra Properties

    $exaInfraName = "OFake_PowerShellTestExaInfra"
    $env.Add("exaInfraName", $exaInfraName)

    $exaInfraShape = "Exadata.X9M"
    $env.Add("exaInfraShape", $exaInfraShape)

    $exaInfraComputeCount = 3
    $env.Add("exaInfraComputeCount", $exaInfraComputeCount)

    $exaInfraStorageCount = 3
    $env.Add("exaInfraStorageCount", $exaInfraStorageCount)

    # VM Cluster Properties

    $vmClusterName = "OFake_PowerShellTestVmCluster"
    $env.Add("vmClusterName", $vmClusterName)

    $vmClusterHostName = "host"
    $env.Add("vmClusterHostName", $vmClusterHostName)

    $vmClusterCpuCoreCount = 4
    $env.Add("vmClusterCpuCoreCount", $vmClusterCpuCoreCount)

    $vmClusterGiVersion = "19.0.0.0"
    $env.Add("vmClusterGiVersion", $vmClusterGiVersion)

    $vmClusterLicenseModel = "LicenseIncluded"
    $env.Add("vmClusterLicenseModel", $vmClusterLicenseModel)

    $vmClusterClusterName = "TestVMC"
    $env.Add("vmClusterClusterName", $vmClusterClusterName)

    $vmClusterMemorySizeInGb = 90
    $env.Add("vmClusterMemorySizeInGb", $vmClusterMemorySizeInGb)

    $vmClusterDbNodeStorageSizeInGb = 180
    $env.Add("vmClusterDbNodeStorageSizeInGb", $vmClusterDbNodeStorageSizeInGb)

    $vmClusterDataStorageSizeInTb = 2.0
    $env.Add("vmClusterDataStorageSizeInTb", $vmClusterDataStorageSizeInTb)

    $vmClusterDataStoragePercentage = 80
    $env.Add("vmClusterDataStoragePercentage", $vmClusterDataStoragePercentage)

    $vmClusterIsLocalBackupEnabled = $false
    $env.Add("vmClusterIsLocalBackupEnabled", $vmClusterIsLocalBackupEnabled)

    $vmClusterIsSparseDiskgroupEnabled = $false
    $env.Add("vmClusterIsSparseDiskgroupEnabled", $vmClusterIsSparseDiskgroupEnabled)

    $vmClusterTimeZone = "UTC"
    $env.Add("vmClusterTimeZone", $vmClusterTimeZone)

    # ADBS Properties

    $adbsName = "OFakePowerShellTestAdbs"
    $env.Add("adbsName", $adbsName)

    $adbsDbWorkload = "OLTP"
    $env.Add("adbsDbWorkload", $adbsDbWorkload)

    $adbsComputeCount = 2.0
    $env.Add("adbsComputeCount", $adbsComputeCount)

    $adbsComputeModel = "ECPU"
    $env.Add("adbsComputeModel", $adbsComputeModel)

    $adbsDbVersion = "19c"
    $env.Add("adbsDbVersion", $adbsDbVersion)

    $adbsDataStorageInGb = 32
    $env.Add("adbsDataStorageInGb", $adbsDataStorageInGb)

    $adbsLicenseModel = "BringYourOwnLicense"
    $env.Add("adbsLicenseModel", $adbsLicenseModel)

    $adbsDatabaseType = "Regular"
    $env.Add("adbsDatabaseType", $adbsDatabaseType)

    $adbsCharacterSet = "AL32UTF8"
    $env.Add("adbsCharacterSet", $adbsCharacterSet)

    $adbsNCharacterSet = "AL16UTF16"
    $env.Add("adbsNCharacterSet", $adbsNCharacterSet)

    $adbsBackupId = "testId12345"
    $env.Add("adbsBackupId", $adbsBackupId)

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

