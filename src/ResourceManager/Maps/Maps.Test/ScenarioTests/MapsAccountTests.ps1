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
Test New-AzureRmMapsAccount
#>
function Test-NewAzureRmMapsAccount
{
    # Setup
    $rgname = Get-MapsManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'ps-' + $rgname;
        $skuname = 'S0';
        $location = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $location;

        $createdAccount = New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        Assert-NotNull $createdAccount;
        # Call create again, expect to get the same account
        $createdAccountAgain = New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        Assert-NotNull $createdAccountAgain
        Assert-AreEqual $createdAccount.Id $createdAccountAgain.Id;
        Assert-AreEqual $createdAccount.ResourceGroupName $createdAccountAgain.ResourceGroupName;
        Assert-AreEqual $createdAccount.Name $createdAccountAgain.Name;
        Assert-AreEqual $createdAccount.Location $createdAccountAgain.Location;
        Assert-AreEqual $createdAccount.Sku.Name $createdAccountAgain.Sku.Name;
        
        Retry-IfException { Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRmMapsAccount
#>
function Test-RemoveAzureRmMapsAccount
{
    # Setup
    $rgname = Get-MapsManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'ps-' + $rgname;
        $skuname = 'S0';
        $location = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $location;

        $createdAccount = New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false;
        $accountGotten = Get-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname;
        Assert-Null $accountGotten

        # create it again and test removal by id
        $createdAccount2 = New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;

        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        Remove-AzureRmMapsAccount -ResourceId $resourceid -Confirm:$false;
        $accountGotten2 = Get-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname;
        Assert-Null $accountGotten2

        Retry-IfException { Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmMapsAccount
#>
function Test-GetAzureMapsAccount
{
    # Setup
    $rgname = Get-MapsManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'ps-' + $rgname;
        $skuname = 'S0';
        $location = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $location;

        New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;

        $account = Get-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname;
        
        Assert-AreEqual $accountname $account.AccountName;
        Assert-AreEqual $skuname $account.Sku.Name;

        # get account by resourceid
        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        $account2 = Get-AzureRmMapsAccount -ResourceId $resourceid;
        Assert-AreEqual $accountname $account2.AccountName;
        Assert-AreEqual $skuname $account2.Sku.Name;

        # get all accounts in the RG 
        $accounts = Get-AzureRmMapsAccount -ResourceGroupName $rgname;
        $numberOfAccountsInRG = ($accounts | measure).Count;
        Assert-AreEqual $accountname $accounts[0].AccountName;
        Assert-AreEqual $skuname $accounts[0].Sku.Name;

        # get all accounts in the subscription
        $allAccountsInSubscription = Get-AzureRmMapsAccount;
        $numberOfAccountsInSubscription = ($allAccountsInSubscription | measure).Count;

        Assert-True { $numberOfAccountsInSubscription -ge $numberOfAccountsInRG }
        
        Retry-IfException { Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmMapsAccountKey
#>
function Test-GetAzureRmMapsAccountKey
{
    # Setup
    $rgname = Get-MapsManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'ps-' + $rgname;
        $skuname = 'S0';
        $location = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $location;
        New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        
        $keys = Get-AzureRmMapsAccountKey -ResourceGroupName $rgname -Name $accountname;
        
        Assert-NotNull $keys.PrimaryKey;
        Assert-NotNull $keys.SecondaryKey;
        Assert-AreNotEqual $keys.PrimaryKey $keys.SecondaryKey;

        # get account by resourceid
        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        $keys2 = Get-AzureRmMapsAccountKey -ResourceId $resourceid;
        Assert-AreEqual $keys.PrimaryKey $keys2.PrimaryKey;
        Assert-AreEqual $keys.SecondaryKey $keys2.SecondaryKey;

        Retry-IfException { Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmMapsAccountKey
#>
function Test-NewAzureRmMapsAccountKey
{
    # Setup
    $rgname = Get-MapsManagementTestResourceName;
    
    try
    {
        # Test
        $accountname = 'ps-' + $rgname;
        $skuname = 'S0';
        $location = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $location;
        New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        
        $originalKeys = Get-AzureRmMapsAccountKey -ResourceGroupName $rgname -Name $accountname;

        # Update primary
        $updatedKeys = New-AzureRmMapsAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Primary -Confirm:$false;
            
        Assert-AreNotEqual $originalKeys.PrimaryKey $updatedKeys.PrimaryKey;
        Assert-AreEqual $originalKeys.SecondaryKey $updatedKeys.SecondaryKey;

        # Update secondary
        $updatedKeys2 = New-AzureRmMapsAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Secondary -Confirm:$false;

        Assert-AreEqual $updatedKeys.PrimaryKey $updatedKeys2.PrimaryKey;
        Assert-AreNotEqual $updatedKeys.SecondaryKey $updatedKeys2.SecondaryKey;

        # get account by resourceid
        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        $updatedKeys3 = New-AzureRmMapsAccountKey -ResourceId $resourceid -KeyName Primary -Confirm:$false;
            
        Assert-AreNotEqual $updatedKeys2.PrimaryKey $updatedKeys3.PrimaryKey;
        Assert-AreEqual $updatedKeys2.SecondaryKey $updatedKeys3.SecondaryKey;


        Retry-IfException { Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Get-AzureRmMapsAccount | Get-AzureRmMapsAccountKey
#>
function Test-PipingGetAccountToGetKey
{
    # Setup
    $rgname = Get-MapsManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'ps-' + $rgname;
        $skuname = 'S0';
        $location = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $location;
        New-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;

        $keys = Get-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname | Get-AzureRmMapsAccountKey;
        Assert-NotNull $keys
        Assert-NotNull $keys.PrimaryKey
        Assert-NotNull $keys.SecondaryKey
        Assert-AreNotEqual $keys.PrimaryKey $keys.SecondaryKey;

        Retry-IfException { Remove-AzureRmMapsAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

