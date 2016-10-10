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

.".\\Common.ps1"
.".\\Assert.ps1"

$commands = 

function Test-SetAzureStorageBlobContent
{
  Assert-ThrowsContains {
    Set-AzureStorageBlobContent -File "InstallationTests.ps1" -Container foo -Blob foo -BlobType Block 
  } "Could not get the storage context.  Please pass in a storage context or set the current storage context." > $null
}

function Test-UpdateStorageAccount
{
  $accounts = Get-AzureStorageAccount
  $subscription = $(Get-AzureSubscription -Current).SubscriptionName
  Set-AzureSubscription -SubscriptionName $subscription -CurrentStorageAccountName $accounts[0].StorageAccountName
  $storageAccountName = $(Get-AzureStorageContainer)[0].Context.StorageAccountName
  Assert-AreEqual $storageAccountName $accounts[0].StorageAccountName

  Set-AzureSubscription -SubscriptionName $subscription -CurrentStorageAccountName $accounts[1].StorageAccountName
  $storageAccountName = $(Get-AzureStorageContainer)[0].Context.StorageAccountName
  Assert-AreEqual $storageAccountName $accounts[1].StorageAccountName
  #Remove-AzureSubscription $(Get-AzureSubscription -Current).SubscriptionName -Force
}

[CmdletBinding]
function Get-IncompleteHelp
{
  Get-Help azure | where {[System.String]::IsNullOrEmpty($_.Synopsis) -or `
  [System.String]::Equals($_.Synopsis, (Get-Command $_.Name).Definition, `
  [System.StringComparison]::OrdinalIgnoreCase)} | % {Write-Output $_.Name}
}