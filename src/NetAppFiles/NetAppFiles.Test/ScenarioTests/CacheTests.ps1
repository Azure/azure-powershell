# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# ---------------------------------------------------------------------------
# ANF Cache (FlexCache) tests
#
# All scenarios in this file require a pre-existing on-prem ONTAP cluster
# reachable from the cache peering subnet so it can be used as the FlexCache
# origin. The required inputs that must be provided per environment are:
#
#   $originPeerClusterName  - ONTAP cluster name of the external cluster
#   $originPeerAddresses    - Intercluster LIF IP addresses (one per node)
#   $originPeerVserverName  - External Vserver (SVM) hosting the origin volume
#   $originPeerVolumeName   - External origin volume name
#
# Until that fixture is wired into the test environment, the xUnit wrappers
# in CacheTests.cs are decorated with [Fact(Skip = "...")] so the runner
# does not attempt to execute them. Re-enable each test by removing its Skip
# argument once the corresponding ONTAP origin is available.
# ---------------------------------------------------------------------------

<#
.SYNOPSIS
Returns the placeholder origin-cluster information used by the Cache scenario
tests. Replace these values with real on-prem ONTAP coordinates when re-enabling
the tests.
#>
function Get-CacheOriginPlaceholder
{
    return [pscustomobject]@{
        ClusterName  = "onprem-ontap-cluster"
        Addresses    = @("10.10.0.10", "10.10.0.11")
        VserverName  = "onprem-svm"
        VolumeName   = "onprem-origin-vol"
    }
}

<#
.SYNOPSIS
Provisions a resource group, VNet with a 'caches' subnet and a 'peering'
subnet, an ANF account, and a capacity pool suitable for a Cache. Returns
the provisioning context used by the test bodies.
#>
function New-CacheTestEnvironment
{
    param(
        [string] $ResourceGroup,
        [string] $Location,
        [string] $AccountName,
        [string] $PoolName,
        [long]   $PoolSize     = 4398046511104,
        [string] $ServiceLevel = "Premium"
    )

    $subsId            = (Get-AzureRmContext).Subscription.SubscriptionId
    $vnetName          = "$ResourceGroup-vnet"
    $cacheSubnetName   = "cache-subnet"
    $peeringSubnetName = "peering-subnet"

    New-AzResourceGroup -Name $ResourceGroup -Location $Location -Tags @{Owner = 'b-aubald'}

    $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $ResourceGroup -Location $Location -Name $vnetName -AddressPrefix 10.0.0.0/16

    $cacheDelegation = New-AzDelegation -Name "netAppCaches" -ServiceName "Microsoft.Netapp/volumes"
    Add-AzVirtualNetworkSubnetConfig -Name $cacheSubnetName   -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $cacheDelegation | Set-AzVirtualNetwork | Out-Null
    $virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName $ResourceGroup -Name $vnetName
    Add-AzVirtualNetworkSubnetConfig -Name $peeringSubnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.2.0/24" | Set-AzVirtualNetwork | Out-Null

    $cacheSubnetId   = "/subscriptions/$subsId/resourceGroups/$ResourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$cacheSubnetName"
    $peeringSubnetId = "/subscriptions/$subsId/resourceGroups/$ResourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$peeringSubnetName"

    $account = New-AzNetAppFilesAccount -ResourceGroupName $ResourceGroup -Location $Location -AccountName $AccountName
    $pool    = New-AzNetAppFilesPool    -ResourceGroupName $ResourceGroup -Location $Location -AccountName $AccountName -PoolName $PoolName -PoolSize $PoolSize -ServiceLevel $ServiceLevel

    return [pscustomobject]@{
        SubscriptionId  = $subsId
        VnetName        = $vnetName
        CacheSubnetId   = $cacheSubnetId
        PeeringSubnetId = $peeringSubnetId
        Account         = $account
        Pool            = $pool
    }
}

<#
.SYNOPSIS
Test Cache CRUD: New / Get / List / Update / Remove.
#>
function Test-CacheCrud
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $gibibyte         = 1024 * 1024 * 1024
    $cacheSize        = 100 * $gibibyte

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        # Create cache
        $newCache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        Assert-AreEqual "$accName/$poolName/$cacheName" $newCache.Name
        Assert-AreEqual $cacheSize  $newCache.Size
        Assert-AreEqual $cacheName  $newCache.FilePath
        Assert-NotNull  $newCache.OriginClusterInformation
        Assert-AreEqual $origin.ClusterName $newCache.OriginClusterInformation.PeerClusterName

        # Get by name
        $getCache = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-AreEqual "$accName/$poolName/$cacheName" $getCache.Name

        # Get by ResourceId
        $getById = Get-AzNetAppFilesCache -ResourceId $getCache.Id
        Assert-AreEqual $getCache.Id $getById.Id

        # List
        $listCaches = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 1 $listCaches.Length

        # Update: change throughput, enable CIFS change notifications, add tag
        $updateTagName  = "Owner"
        $updateTagValue = "b-aubald"
        $updated = Update-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName `
            -ThroughputMibps 64 `
            -CifsChangeNotifications "Enabled" `
            -Tag @{$updateTagName = $updateTagValue}

        Assert-AreEqual 64 $updated.ThroughputMibps
        Assert-AreEqual "Enabled" $updated.CifsChangeNotifications
        Assert-True { $updated.Tags.ContainsKey($updateTagName) }

        # WhatIf should not delete
        Remove-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName -WhatIf
        $stillThere = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-NotNull $stillThere

        # Remove
        Remove-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName

        $deleted = $null
        try
        {
            $deleted = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        }
        catch
        {
            $deleted = $null
        }
        Assert-Null $deleted
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Pipeline binding: pool -> Get caches; cache -> Update / Remove.
#>
function Test-CachePipeline
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        # Pipe pool to Get-AzNetAppFilesCache
        $listFromPool = $env.Pool | Get-AzNetAppFilesCache
        Assert-AreEqual 1 $listFromPool.Length
        Assert-AreEqual "$accName/$poolName/$cacheName" $listFromPool[0].Name

        # Pipe cache to Update
        $cache | Update-AzNetAppFilesCache -ThroughputMibps 32 | Out-Null
        $updated = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-AreEqual 32 $updated.ThroughputMibps

        # Pipe cache to Remove
        $updated | Remove-AzNetAppFilesCache -PassThru | Out-Null
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Get-AzNetAppFilesCachePeeringPassphrase returns cluster/vserver peering commands
and passphrases that can be applied on the on-prem ONTAP origin to complete
peering.
#>
function Test-CachePeeringPassphrase
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        $passphrase = Get-AzNetAppFilesCachePeeringPassphrase -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-NotNull $passphrase
        Assert-NotNull $passphrase.ClusterPeeringCommand
        Assert-NotNull $passphrase.ClusterPeeringPassphrase
        Assert-NotNull $passphrase.VserverPeeringCommand

        # Pipeline variant
        $passphraseFromPipeline = $cache | Get-AzNetAppFilesCachePeeringPassphrase
        Assert-NotNull $passphraseFromPipeline.ClusterPeeringCommand
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Set-AzNetAppFilesCachePool moves a cache to a different capacity pool.
#>
function Test-CachePoolChange
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName1     = Get-ResourceName
    $poolName2     = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024
    $poolSize         = 4398046511104
    $serviceLevel     = "Premium"

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName1
        $origin = Get-CacheOriginPlaceholder

        # Second pool to move into
        $pool2 = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel $serviceLevel

        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName1 -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        # Move to second pool
        $moved = Set-AzNetAppFilesCachePool `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName1 -Name $cacheName `
            -NewPoolResourceId $pool2.Id

        Assert-AreEqual "$accName/$poolName2/$cacheName" $moved.Name

        # Confirm it disappeared from the original pool
        $listInOldPool = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName1
        Assert-AreEqual 0 $listInOldPool.Length

        # Confirm it appears in the new pool
        $listInNewPool = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2
        Assert-AreEqual 1 $listInNewPool.Length
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Reset-AzNetAppFilesCacheSmbPassword resets the SMB machine account password
for the cache (only meaningful for SMB-enabled caches).
#>
function Test-CacheResetSmbPassword
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        # Create an SMB-capable cache. NOTE: a real SMB cache typically also requires an
        # Active Directory configured on the parent NetApp account. The AD provisioning is
        # outside the scope of this scenario test - it is part of the prerequisite fixture.
        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("CIFS") `
            -SmbEncryption "Enabled"

        $reset = Reset-AzNetAppFilesCacheSmbPassword -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-NotNull $reset
        Assert-AreEqual "$accName/$poolName/$cacheName" $reset.Name
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}
