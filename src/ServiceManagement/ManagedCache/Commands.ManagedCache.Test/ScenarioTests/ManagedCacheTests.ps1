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

########################## Managed Cache End to End Scenario Tests #############################

<#
.SYNOPSIS
Managed Cache End to End
#>
function Test-ManagedCacheEndToEnd
{
    $cacheName = getAssetName
    # cache service can only take lower case name
    $cacheName = $cacheName.ToLower()
    # new a sevice
    New-AzureManagedCache $cacheName "West US"

    # verify using a get
    $newCacheService = Get-AzureManagedCache $cacheName
    Assert-AreEqual $cacheName $newCacheService.Name
    Assert-AreEqual 'Basic' $newCacheService.Sku
    Assert-AreEqual '128MB' $newCacheService.Memory

    # updating a proeprty and verify
    $newCacheService = Set-AzureManagedCache $cacheName -Memory 256MB
    Assert-AreEqual '256MB' $newCacheService.Memory

    # verify the access keys
    $existingKey = Get-AzureManagedCacheAccessKey $cacheName
    $newKey = New-AzureManagedCacheAccessKey $cacheName
    Assert-AreNotEqual $existingKey.Primary $newKey.Primary

    # Remove it
    Remove-AzureManagedCache $cacheName -Force
}

########################## List caching service location Test  #############################
<#
.SYNOPSIS
List locations that support managed caching service
#>
function Test-ListLocationsSupportCaching
{
    $allLocations = Get-AzureManagedCacheLocation
    
    Assert-AreNotEqual 0 $allLocations.Count

    $found = $FALSE
    foreach ($location in $allLocations)
    {
        if ($location.Location -eq "West US")
        {
            $found = $TRUE
            break
        }
    }
    Assert-True {$found}
}

########################## Managed Cache (Named cache) Scenario Tests #############################
<#
.SYNOPSIS
Managed Cache (Named cache) without actual cache
#>
function Test-ManagedCacheNamedCacheDoNotExists
{
    $cacheName = "nonexistingcache"
    # cache service can only take lower case name
    $cacheName = $cacheName.ToLower()
    
    Assert-ThrowsContains {New-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "nonexisting" -ExpiryTime 10} "doesn't exist in current subscription"
}

<#
.SYNOPSIS
Managed Cache (Named cache for basic sku) End to End
#>
function Test-ManagedCacheNamedCacheBasic
{
    $cacheName = "powershellbasic"
    # cache service can only take lower case name
    $cacheName = $cacheName.ToLower()
    
    # new a sevice
    New-AzureManagedCache -Name $cacheName -Location "East US" -Sku Basic -Memory 128MB

    # verify using a get
    $newCacheService = Get-AzureManagedCache $cacheName
    Assert-AreEqual $cacheName $newCacheService.Name
    Assert-AreEqual 'Basic' $newCacheService.Sku
    Assert-AreEqual '128MB' $newCacheService.Memory
	
    Assert-ThrowsContains {New-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "default"} "already has named cache with name"
    Assert-ThrowsContains {New-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random"} "It is not possible to create named cache in Basic Sku"

    $cacheDetails = Get-AzureManagedCacheNamedCache -Name $cacheName
    Assert-AreEqual $cacheName $cacheDetails.Name
    Assert-AreEqual 'Basic' $cacheDetails.Sku
    Assert-AreEqual '128MB' $cacheDetails.Memory
    Assert-AreEqual 'East US' $cacheDetails.Location
    Assert-AreEqual 1 $cacheDetails.NamedCaches.Count
    foreach($singleNamedCache in $cacheDetails.NamedCaches) {
        Assert-AreEqual "default" $singleNamedCache.CacheName
        Assert-AreEqual "Absolute" $singleNamedCache.ExpiryPolicy
        Assert-AreEqual 10 $singleNamedCache.TimeToLiveInMinutes
        Assert-AreEqual "Enabled" $singleNamedCache.Eviction
        Assert-AreEqual "Disabled" $singleNamedCache.Notifications
        Assert-AreEqual "Disabled" $singleNamedCache.HighAvailability
    }

    Assert-ThrowsContains {Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random"} "do not have named cache with name"
    Assert-ThrowsContains {Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "default" -WithNotifications} "Parameter 'WithNotifications' is not available for cache with Basic sku"
    Assert-ThrowsContains {Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "default" -WithHighAvailability} "Parameter 'WithHighAvailability' is not available for cache with Basic sku"

    $cacheDetailsAfterUpdate = Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "default" -ExpiryTime 11 -ExpiryPolicy "Sliding" -Force
    Assert-AreEqual $cacheName $cacheDetailsAfterUpdate.Name
    Assert-AreEqual 'Basic' $cacheDetailsAfterUpdate.Sku
    Assert-AreEqual '128MB' $cacheDetailsAfterUpdate.Memory
    Assert-AreEqual 'East US' $cacheDetailsAfterUpdate.Location
    Assert-AreEqual 1 $cacheDetailsAfterUpdate.NamedCaches.Count
    foreach($singleNamedCache in $cacheDetailsAfterUpdate.NamedCaches) {
        Assert-AreEqual "default" $singleNamedCache.CacheName
        Assert-AreEqual "Sliding" $singleNamedCache.ExpiryPolicy
        Assert-AreEqual 11 $singleNamedCache.TimeToLiveInMinutes
        Assert-AreEqual "Enabled" $singleNamedCache.Eviction
        Assert-AreEqual "Disabled" $singleNamedCache.Notifications
        Assert-AreEqual "Disabled" $singleNamedCache.HighAvailability
    }
    
    Assert-ThrowsContains {Remove-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "default" -Force -PassThru} "It is not possible to remove 'default' named cache"
	
    # Remove it
    Remove-AzureManagedCache $cacheName -Force
}

<#
.SYNOPSIS
Managed Cache (Named cache for standard sku) End to End
#>
function Test-ManagedCacheNamedCacheStandard
{
    $cacheName = "powershellstandard"
    # cache service can only take lower case name
    $cacheName = $cacheName.ToLower()
    
    # new a sevice
    New-AzureManagedCache -Name $cacheName -Location "West US" -Sku Standard -Memory 1GB

    # verify using a get
    $newCacheService = Get-AzureManagedCache $cacheName
    Assert-AreEqual $cacheName $newCacheService.Name
    Assert-AreEqual 'Standard' $newCacheService.Sku
    Assert-AreEqual '1GB' $newCacheService.Memory
	
    New-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random1"
    Assert-ThrowsContains {New-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random1"} "already has named cache with name"

    New-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random2" -WithNotifications -WithHighAvailability -WithoutEviction

    $cacheDetails = Get-AzureManagedCacheNamedCache -Name $cacheName
    Assert-AreEqual $cacheName $cacheDetails.Name
    Assert-AreEqual 'Standard' $cacheDetails.Sku
    Assert-AreEqual '1GB' $cacheDetails.Memory
    Assert-AreEqual 'West US' $cacheDetails.Location
    Assert-AreEqual 3 $cacheDetails.NamedCaches.Count
	
    $cacheRandom1 = Get-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random1"
    Assert-AreEqual 1 $cacheRandom1.NamedCaches.Count
    foreach($singleNamedCache in $cacheRandom1.NamedCaches) {
        Assert-AreEqual "random1" $singleNamedCache.CacheName
        Assert-AreEqual "Absolute" $singleNamedCache.ExpiryPolicy
        Assert-AreEqual 10 $singleNamedCache.TimeToLiveInMinutes
        Assert-AreEqual "Enabled" $singleNamedCache.Eviction
        Assert-AreEqual "Disabled" $singleNamedCache.Notifications
        Assert-AreEqual "Disabled" $singleNamedCache.HighAvailability
    }

    $cacheRandom2 = Get-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random2"
    Assert-AreEqual 1 $cacheRandom2.NamedCaches.Count
    foreach($singleNamedCache in $cacheRandom2.NamedCaches) {
        Assert-AreEqual "random2" $singleNamedCache.CacheName
        Assert-AreEqual "Absolute" $singleNamedCache.ExpiryPolicy
        Assert-AreEqual 10 $singleNamedCache.TimeToLiveInMinutes
        Assert-AreEqual "Disabled" $singleNamedCache.Eviction
        Assert-AreEqual "Enabled" $singleNamedCache.Notifications
        Assert-AreEqual "Enabled" $singleNamedCache.HighAvailability
    }

    Assert-ThrowsContains {Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "nonexisting"} "do not have named cache with name"
	
    Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random1" -ExpiryTime 11 -ExpiryPolicy "Sliding" -WithNotifications -WithHighAvailability -Force
    $cacheDetailsAfterUpdate = Get-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random1"
    Assert-AreEqual 1 $cacheDetailsAfterUpdate.NamedCaches.Count
    foreach($singleNamedCache in $cacheDetailsAfterUpdate.NamedCaches) {
        Assert-AreEqual "random1" $singleNamedCache.CacheName
        Assert-AreEqual "Sliding" $singleNamedCache.ExpiryPolicy
        Assert-AreEqual 11 $singleNamedCache.TimeToLiveInMinutes
        Assert-AreEqual "Enabled" $singleNamedCache.Eviction
        Assert-AreEqual "Enabled" $singleNamedCache.Notifications
        Assert-AreEqual "Enabled" $singleNamedCache.HighAvailability
    }
    
    Set-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random2" -Force
    $cacheDetailsAfterUpdate2 = Get-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random2"
    Assert-AreEqual 1 $cacheDetailsAfterUpdate2.NamedCaches.Count
    foreach($singleNamedCache in $cacheDetailsAfterUpdate2.NamedCaches) {
        Assert-AreEqual "random2" $singleNamedCache.CacheName
        Assert-AreEqual "Absolute" $singleNamedCache.ExpiryPolicy
        Assert-AreEqual 10 $singleNamedCache.TimeToLiveInMinutes
        Assert-AreEqual "Enabled" $singleNamedCache.Eviction
        Assert-AreEqual "Disabled" $singleNamedCache.Notifications
        Assert-AreEqual "Disabled" $singleNamedCache.HighAvailability
    }

    Assert-ThrowsContains {Remove-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "nonexisting" -Force -PassThru} "do not have named cache with name"
    Assert-True { Remove-AzureManagedCacheNamedCache -Name $cacheName -NamedCache "random2" -Force -PassThru }
	
    $cacheDetailsAfterRemove = Get-AzureManagedCacheNamedCache -Name $cacheName
    Assert-AreEqual 2 $cacheDetailsAfterRemove.NamedCaches.Count

    # Remove it
    Remove-AzureManagedCache $cacheName -Force
}