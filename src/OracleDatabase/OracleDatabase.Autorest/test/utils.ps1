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

    $vnetName = "PowerShellTestVnet"
    $vnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)"
    $env.Add("vnetId", $vnetId)

    $subnetName = "delegated"
    $subnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)/subnets/$($subnetName)"
    $env.Add("subnetId", $subnetId)

    # Exadata Infra Properties

    $rstr1 = RandomString -allChars $false -len 4
    $exaInfraName = "OFake_PowerShellTestExaInfra" + $rstr1
    $env.Add("exaInfraName", $exaInfraName)

    $exaInfraShape = "Exadata.X9M"
    $env.Add("exaInfraShape", $exaInfraShape)

    $exaInfraComputeCount = 2
    $env.Add("exaInfraComputeCount", $exaInfraComputeCount)

    $exaInfraStorageCount = 3
    $env.Add("exaInfraStorageCount", $exaInfraStorageCount)

    # VM Cluster Properties

    $rstr2 = RandomString -allChars $false -len 4
    $vmClusterName = "OFake_PowerShellTestVmVluster" + $rstr2
    $env.Add("vmClusterName", $vmClusterName)

    $vmClusterHostName = "powershell-test"
    $env.Add("vmClusterHostName", $vmClusterHostName)

    $vmClusterCpuCoreCount = 4
    $env.Add("vmClusterCpuCoreCount", $vmClusterCpuCoreCount)

    $sshPublicKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDBGTHtPeOBRuHNkW6GF0xKMFA79EuOGoCRuzsE1I9v/kUl9oElGgCpUoSLDsvRl4ZzmTBaJDgG020Qy+6SoVnQkSztGvyXxQJm5obkKhNjutheDpJ3ozQysHqWybyRt8dga7TvhTS5HXHJ2pwbFmYjlIdhxviP3qwzqpIYf0kQde1RXlnvOKyVlOfTDr6ovJ9J+fWle5mwE9ywm2anYPpIgydap3oFTaj8RoFW7G6m5kJAu2U4J9jShrp2vTOjFx8JIuy35quclPZ3UzdiMALmXIR7gA/9bwsog0nQDz6YLpz9r3PxZuo4mGEzNyj1yn5USROBcgLOVKruij53uWiT5RgZzhZSheJryNE54mFCHaaw4C3CZfI+m7DFuEXmOvqTbxlwV8/r2jNzpobtExXm4KowmFTYvVuts6jy58zZ/WSizb0oxqJI8TgO/C5mujN1D/NMibxOWLEnyncHRPm+wGUhnNpl8dnST6a1Dsf694q+OBnMWJWQPU4NR/eZ8JU= generated-by-azure"
    $env.Add("sshPublicKey", $sshPublicKey)

    $vmClusterGiVersion = "19.0.0.0"
    $env.Add("vmClusterGiVersion", $vmClusterGiVersion)

    $vmClusterLicenseModel = "LicenseIncluded"
    $env.Add("vmClusterLicenseModel", $vmClusterLicenseModel)

    $vmClusterCusterName = "TestVmClust"
    $env.Add("vmClusterCusterName", $vmClusterCusterName)

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

    $rstr3 = RandomString -allChars $false -len 4
    $adbsName = "OFakePowerShellTestAdbs" + $rstr3
    $env.Add("adbsName", $adbsName)

    $adbsDbWorkload = "DW"
    $env.Add("adbsDbWorkload", $adbsDbWorkload)

    $adbsComputeCount = 2.0
    $env.Add("adbsComputeCount", $adbsComputeCount)

    $adbsComputeModel = "ECPU"
    $env.Add("adbsComputeModel", $adbsComputeModel)

    $adbsDbVersion = "19c"
    $env.Add("adbsDbVersion", $adbsDbVersion)

    $adbsDataStorageInTb = 2
    $env.Add("adbsDataStorageInTb", $adbsDataStorageInTb)

    $adbsLicenseModel = "LicenseIncluded"
    $env.Add("adbsLicenseModel", $adbsLicenseModel)

    $adbsDatabaseType = "Regular"
    $env.Add("adbsDatabaseType", $adbsDatabaseType)

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

