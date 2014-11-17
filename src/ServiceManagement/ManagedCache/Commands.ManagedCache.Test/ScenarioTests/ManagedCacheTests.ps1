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