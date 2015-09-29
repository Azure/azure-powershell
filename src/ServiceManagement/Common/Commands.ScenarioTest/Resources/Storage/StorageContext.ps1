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

<#
.SYNOPSIS
Tests using New-AzureStorageContext with anonymous storage account
#>
function Test-NewAnonymousStorageContext
{
    $account = "test";
    $context = New-AzureStorageContext -StorageAccountName $account -Anonymous;
    Assert-AreEqual $context.StorageAccountName "[Anonymous]"
}

<#
.SYNOPSIS
Tests using New-AzureStorageContext with storage account name and key
#>
function Test-NewStorageContextWithNameAndKey
{
    $account = "test";
    $key = "XM+4nFQ832Qfi4mH/ChQwdQUmTqrZqbQTJWpAQZ6klWjTVsIBVZy5xNdCDje4EWP0gdXK9vIFAY8LOmz85Wmcg==";
    $context = New-AzureStorageContext -StorageAccountName $account -StorageAccountKey $key -Protocol Https
    Assert-AreEqual $context.StorageAccountName $account
    Assert-True {$context.BlobEndPoint.ToString().StartsWith("https://")}
}