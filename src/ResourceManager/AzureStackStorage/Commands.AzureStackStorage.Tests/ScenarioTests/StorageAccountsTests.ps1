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
Tests getting a single storage account with account ID given for a resource group with admin subscription id.
#>
function Test-GetStorageAccount
{
    # Setup
    $rgname = 'system'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $accountId = 1

    try 
    {
        $actual = Get-ACSStorageAccount -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -AccountId $accountId -Detail

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual.AccountId 1
        Assert-AreEqual $actual.AdminViewId '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourcegroups/system/providers/Microsoft.Storage.Admin/farms/03768357-B4F2-4C3C-AA75-574209B03D49/storageaccounts/1'
        Assert-AreEqual $actual.TenantViewId '/subscriptions/177fbbce-fd6a-4f11-bfa4-52c2f3a21918/resourcegroups/system/providers/Microsoft.Storage/storageaccounts/demo007'
        Assert-AreEqual $actual.AccountType 'StandardGRS'
        Assert-AreEqual $actual.State 'Created'
        Assert-AreEqual $actual.PrimaryEndpoints['blob'] 'https://host:11100/demo007'
        Assert-AreEqual $actual.PrimaryEndpoints['queue'] 'https://host:11101/demo007'
        Assert-AreEqual $actual.PrimaryEndpoints['table'] 'https://host:11102/demo007'

        #TODO: should the type of CreationTime be DateTime?
        Assert-AreEqual $actual.CreationTime 'Tue, 13 Oct 2015 05:42:48 GMT'
        Assert-AreEqual $actual.AlternateName $null
        Assert-AreEqual $actual.StatusOfPrimary 'Available'
        Assert-AreEqual $actual.TenantSubscriptionId '177fbbce-fd6a-4f11-bfa4-52c2f3a21918'
        Assert-AreEqual $actual.TenantAccountName 'demo007'
        Assert-AreEqual $actual.TenantResourceGroupName $rgname
        Assert-AreEqual $actual.CurrentOperation 'None'
        Assert-AreEqual $actual.CustomDomain $null
        Assert-AreEqual $actual.AcquisitionOperationCount 0
        Assert-AreEqual $actual.DeletedTime $null
        Assert-AreEqual $actual.AccountStatus 'Active'
        Assert-AreEqual $actual.RecoveredTime.ToString("yyyy-MM-dd HH:mm:ss") '2015-10-13 05:44:29'
        Assert-AreEqual $actual.RecycledTime $null
        Assert-AreEqual $actual.Permissions $null
        #TODO: verify WacAccountId, WacInternalState etc
        Assert-AreEqual $actual.FarmName $farmName
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests listing storage accounts with partial/full storage account name given in a resource group with admin subscription id.
#>
function Test-ListStorageAccounts
{
    # Setup
    $rgname = 'system'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $partialAccountName = 'acc'
    $tenantSubscriptionId = 'DB3972C4-90B4-4A11-9209-D6C12060F6FC'

    try 
    {
        $actual = Get-ACSStorageAccount -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -PartialAccountName $partialAccountName `
        -TenantSubscriptionId $tenantSubscriptionId

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual[0].AccountId 1
        Assert-AreEqual $actual[0].AdminViewId '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourcegroups/system/providers/Microsoft.Storage.Admin/farms/03768357-B4F2-4C3C-AA75-574209B03D49/storageaccounts/1'
        Assert-AreEqual $actual[0].TenantViewId '/subscriptions/177fbbce-fd6a-4f11-bfa4-52c2f3a21918/resourcegroups/system/providers/Microsoft.Storage/storageaccounts/demo007'
        Assert-AreEqual $actual[0].AccountType 'StandardGRS'
        Assert-AreEqual $actual[0].State 'Created'
        Assert-AreEqual $actual[0].PrimaryEndpoints['blob'] 'https://host:11100/demo007'
        Assert-AreEqual $actual[0].PrimaryEndpoints['queue'] 'https://host:11101/demo007'
        Assert-AreEqual $actual[0].PrimaryEndpoints['table'] 'https://host:11102/demo007'

        #TODO: should the type of CreationTime be DateTime?
        Assert-AreEqual $actual[0].CreationTime 'Tue, 13 Oct 2015 05:42:48 GMT'
        Assert-AreEqual $actual[0].AlternateName $null
        Assert-AreEqual $actual[0].StatusOfPrimary 'Available'
        Assert-AreEqual $actual[0].TenantSubscriptionId '177fbbce-fd6a-4f11-bfa4-52c2f3a21918'
        Assert-AreEqual $actual[0].TenantAccountName 'demo007'
        Assert-AreEqual $actual[0].TenantResourceGroupName $rgname
        Assert-AreEqual $actual[0].CurrentOperation 'None'
        Assert-AreEqual $actual[0].CustomDomain $null
        Assert-AreEqual $actual[0].AcquisitionOperationCount 0
        Assert-AreEqual $actual[0].DeletedTime $null
        Assert-AreEqual $actual[0].AccountStatus 'Active'
        Assert-AreEqual $actual[0].RecoveredTime.ToString("yyyy-MM-dd HH:mm:ss") '2015-10-13 05:44:29'
        Assert-AreEqual $actual[0].RecycledTime $null
        Assert-AreEqual $actual[0].Permissions $null
        #TODO: verify WacAccountId, WacInternalState etc
        Assert-AreEqual $actual[0].FarmName $farmName
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests undo the deletion of a storage account with account ID given in a resource group with admin subscription id.
#>
function Test-UndoStorageAccountDeletion
{
    # Setup
    $rgname = 'system'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $accountId = 1
    $tenantSubscriptionId = 'DB3972C4-90B4-4A11-9209-D6C12060F6FC'
    $newAccountName = 'acc_new_name'

    try 
    {
        $actual = Undo-ACSStorageAccountDeletion -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -AccountId $accountId -NewAccountName $newAccountName 
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests pipeline. Get an account first, then undo deletion.
#>
function Test-StorageAccountPipeline
{
    # Setup
    $rgname = 'system'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $accountId = 1
    $newAccountName = 'acc_new_name'

    try 
    {
        $actual = Get-ACSStorageAccount -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -AccountId $accountId -Detail `
            | Undo-ACSStorageAccountDeletion -NewAccountName $newAccountName 
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}