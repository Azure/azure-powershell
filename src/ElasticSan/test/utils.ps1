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
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $env.RandomString = (RandomString $false 8)
    $env.ResourceGroupName = "testelasticsanrg" + $env.RandomString
    $env.Location = "eastus"

    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location

    $vnetName = "testvnet" + $env.RandomString
    $subnet1Name = "subnet1" + $env.RandomString
    $subnet2Name = "subnet2" + $env.RandomString
    $vnet =  New-AzVirtualNetwork -ResourceGroupName $env.ResourceGroupName -Location $env.Location -AddressPrefix 10.0.0.0/24 -Name $vnetName
    $vnet = $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix "10.0.0.0/28" -ServiceEndpoint Microsoft.Storage | Set-AzVirtualNetwork
    $vnet = $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix "10.0.0.16/28" -ServiceEndpoint Microsoft.Storage | Set-AzVirtualNetwork
    $env.vnetResourceId1 = '/subscriptions/' + $env.SubscriptionId + '/resourceGroups/' + $env.ResourceGroupName + '/providers/Microsoft.Network/virtualNetworks/' + $vnetName + '/subnets/' + $subnet1Name
    $env.vnetResourceId2 = '/subscriptions/' + $env.SubscriptionId + '/resourceGroups/' + $env.ResourceGroupName + '/providers/Microsoft.Network/virtualNetworks/' + $vnetName + '/subnets/' + $subnet2Name

    $env.ElasticSanLocation = "southcentralusstg"
    $env.ElasticSanName1 = "testelasticsan1" + $env.RandomString
    $env.ElasticSanName2 = "testelasticsan2" + $env.RandomString
    $env.BaseSizeTib = 1
    $env.ExtendedCapacitySizeTib = 6 
    $env.ElasticSanTags = @{tag1 = "value1"; tag2 = "value2"}

    # Initialize an Elastic SAN
    New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $env.ElasticSanName1 -AvailabilityZone 'zone1' -BaseSizeTib $env.BaseSizeTib -ExtendedCapacitySizeTib $env.ExtendedCapacitySizeTib -Location $env.ElasticSanLocation -SkuName 'Premium_LRS' -Tag $env.ElasticSanTags
    New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $env.ElasticSanName2 -AvailabilityZone 'zone1' -BaseSizeTib $env.BaseSizeTib -ExtendedCapacitySizeTib $env.ExtendedCapacitySizeTib -Location $env.ElasticSanLocation -SkuName 'Premium_LRS' -Tag $env.ElasticSanTags
    $env.VolumeGroupName = "testvolgroup" + $env.RandomString
    New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $env.VolumeGroupName -Encryption 'EncryptionAtRestWithPlatformKey' -ProtocolType 'Iscsi'
    $env.VolumeName = "testvol" + $env.RandomString
    New-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $env.VolumeGroupName -Name $env.VolumeName -SizeGiB 100

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.ResourceGroupName
}

