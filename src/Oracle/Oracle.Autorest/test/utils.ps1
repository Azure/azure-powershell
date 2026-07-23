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

    $exaInfraName = "OFake_PowerShellExaInfra"
    $env.Add("exaInfraName", $exaInfraName)

    $exaInfraShape = "Exadata.X9M"
    $env.Add("exaInfraShape", $exaInfraShape)

    $exaInfraComputeCount = 3
    $env.Add("exaInfraComputeCount", $exaInfraComputeCount)

    $exaInfraStorageCount = 3
    $env.Add("exaInfraStorageCount", $exaInfraStorageCount)

    # VM Cluster Properties

    $vmClusterName = "OFake_PSVmCluster"
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

    $adbsName = "OFakePowerShellAdbs"
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

    #Exascale setup 

    $description = "test_resource"
    $env.Add("description", $description)

    $highCapacityDatabaseStorageInput = 300
    $env.Add("highCapacityDatabaseStorageInput", $highCapacityDatabaseStorageInput)

    $oracleExadbVMClusterName = "OfakeExa_DbCluster"
    $env.Add("oracleExadbVMClusterName", $oracleExadbVMClusterName)
   
    $enabledEcpuCount = 16
    $env.Add("enabledEcpuCount", $enabledEcpuCount)

    $gridImageOcid = "ocid1.dbpatch.oc1.iad.anuwcljtt5t4sqqaoajnkveobp3ryw7zlfrrcf6tb2ndvygp54z2gbds2hxa"
    $env.Add("gridImageOcid", $gridImageOcid)

    $nodeCount = 2
    $env.Add("nodeCount", $nodeCount)

    $exaScaleShape = "EXADBXS"
    $env.Add("exaScaleShape", $exaScaleShape)

    $totalEcpuCount = 32 
    $env.Add("totalEcpuCount", $totalEcpuCount)

    $VMFileSystemStorage = 1024
    $env.Add("VMFileSystemStorage", $VMFileSystemStorage)

    $oracleExascaleDbStorageVaultName = "Ofake_VaultPS" 
    $env.Add("oracleExascaleDbStorageVaultName", $oracleExascaleDbStorageVaultName)
    #New-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup -Location $env.location -Zone $env.zone -Description $env.description -HighCapacityDatabaseStorageInput $env.highCapacityDatabaseStorageInput -DisplayName $env.oracleExascaleDbStorageVaultName
    #$dbStorageVault = Get-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup

    #prerequisite resources
    $adbsDNDName = "adbsDNDP"
    $env.Add("adbsDNDName", $adbsDNDName)
    $VmClusterDNDName = "OfakeDNDVM"
    $env.Add("VmClusterDNDName", $VmClusterDNDName)
    $ExaInfraDNDName = "OfakeExaDND"
    $env.Add("ExaInfraDNDName", $ExaInfraDNDName)

    # Resource Anchor Properties
    $resourceAnchorRgName = "PowershellAnchors"
    $env.Add("resourceAnchorRgName", $resourceAnchorRgName)

    $resourceAnchorName = "PowershellTestRANew1"
    $env.Add("resourceAnchorName", $resourceAnchorName)

    $resourceAnchorLocation = "global"
    $env.Add("resourceAnchorLocation", $resourceAnchorLocation)

    # Network Anchor Properties
    $networkAnchorRgName = "PowershellAnchors"
    $env.Add("networkAnchorRgName", $networkAnchorRgName)

    $networkAnchorName = "PowershellTest1s"
    $env.Add("networkAnchorName", $networkAnchorName)

    # $networkAnchorSubnetId = "/subscriptions/$($env.subscriptionId)/resourceGroups/$($env.networkAnchorRgName)/providers/Microsoft.Network/virtualNetworks/basedb-iad53-vnet/subnets/$($subnetName)"
    # $env.Add("networkAnchorSubnetId", $networkAnchorSubnetId)

    $resourceAnchorId = "/subscriptions/$($env.subscriptionId)/resourceGroups/$($env.networkAnchorRgName)/providers/Oracle.Database/resourceAnchors/PowershellTestRANew1"
    $env.Add("resourceAnchorId", $resourceAnchorId)

    # BaseDB Properties
    $baseDbName = "PowershellSdkNew"
    $env.Add("baseDbName", $baseDbName)

    $baseDbZone = @("1")
    $env.Add("baseDbZone", $baseDbZone)

    $databaseEdition = "EnterpriseEdition"
    $env.Add("databaseEdition", $databaseEdition)

    $baseDbHostname = "whitelist25"
    $env.Add("baseDbHostname", $baseDbHostname)

    $baseDbShape = "VM.Standard.E5.Flex"
    $env.Add("baseDbShape", $baseDbShape)

    $baseDbDisplayName = "BaseDbWhitelisMih"
    $env.Add("baseDbDisplayName", $baseDbDisplayName)

    $baseDbNodeCount = 1
    $env.Add("baseDbNodeCount", $baseDbNodeCount)

    $initialDataStorageSizeInGb = 256
    $env.Add("initialDataStorageSizeInGb", $initialDataStorageSizeInGb)

    $baseDbComputeModel = "OCPU"
    $env.Add("baseDbComputeModel", $baseDbComputeModel)

    $baseDbComputeCount = 4
    $env.Add("baseDbComputeCount", $baseDbComputeCount)

    $baseDbVersion = "19.27.0.0"
    $env.Add("baseDbVersion", $baseDbVersion)

    $baseDbPdbName = "pdbNameSep05"
    $env.Add("baseDbPdbName", $baseDbPdbName)

    $dbSystemOptionStorageManagement = "LVM"
    $env.Add("dbSystemOptionStorageManagement", $dbSystemOptionStorageManagement)

    $netAnchorName = "basedb-na9293-ti-iad52"
    $baseDbNetAnchor = "/subscriptions/a374f63c-de57-4fa6-a14a-53fb69667389/resourceGroups/canary-basedb-iad/providers/Oracle.Database/networkAnchors/canary-NA-DND"
    $env.Add("baseDbNetAnchor", $baseDbNetAnchor)

    $resAnchorName = "basedb-na9293-ti-iad52"
    $baseDbResAnchor = "/subscriptions/a374f63c-de57-4fa6-a14a-53fb69667389/resourceGroups/canary-basedb-iad/providers/Oracle.Database/resourceAnchors/canary-RA-DND"
    $env.Add("baseDbResAnchor", $baseDbResAnchor)

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

