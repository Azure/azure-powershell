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
Test New-AzureRmLocationBasedServicesAccount
#>
function Test-NewAzureRmLocationBasedServicesAccount
{
    # Setup
    $rgname = Get-LocationBasedServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'lbsa' + $rgname;
        $skuname = 'S0';
        $loc = Get-Location 'Microsoft.LocationBasedServices' 'accounts' 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        Assert-NotNull $createdAccount;
        # Call create again, expect to get the same account
        $createdAccountAgain = New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        Assert-NotNull $createdAccountAgain
        Assert-AreEqual $createdAccount.Id $createdAccountAgain.Id;
        Assert-AreEqual $createdAccount.ResourceGroupName $createdAccountAgain.ResourceGroupName;
        Assert-AreEqual $createdAccount.Name $createdAccountAgain.Name;
        Assert-AreEqual $createdAccount.Location $createdAccountAgain.Location;
        Assert-AreEqual $createdAccount.Sku.Name $createdAccountAgain.Sku.Name;
        
        Retry-IfException { Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRmLocationBasedServicesAccount
#>
function Test-RemoveAzureRmLocationBasedServicesAccount
{
    # Setup
    $rgname = Get-LocationBasedServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'lbsa' + $rgname;
        $skuname = 'S0';
        $loc = Get-Location 'Microsoft.LocationBasedServices' 'accounts' 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false;
        $accountGotten = Get-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname;
        Assert-Null $accountGotten

        # create it again and test removal by id
        $createdAccount2 = New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;

        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        Remove-AzureRmLocationBasedServicesAccount -ResourceId $resourceid -Confirm:$false;
        $accountGotten2 = Get-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname;
        Assert-Null $accountGotten2

        Retry-IfException { Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmLocationBasedServicesAccount
#>
function Test-GetAzureLocationBasedServicesAccount
{
    # Setup
    $rgname = Get-LocationBasedServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'lbsa' + $rgname;
        $skuname = 'S0';
        $loc = Get-Location 'Microsoft.LocationBasedServices' 'accounts' 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;

        $account = Get-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname;
        
        Assert-AreEqual $accountname $account.AccountName;
        Assert-AreEqual $skuname $account.Sku.Name;

        # get account by resourceid
        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        $account2 = Get-AzureRmLocationBasedServicesAccount -ResourceId $resourceid;
        Assert-AreEqual $accountname $account2.AccountName;
        Assert-AreEqual $skuname $account2.Sku.Name;

        # get all accounts in the RG 
        $accounts = Get-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname;
        $numberOfAccountsInRG = ($accounts | measure).Count;
        Assert-AreEqual $accountname $accounts[0].AccountName;
        Assert-AreEqual $skuname $accounts[0].Sku.Name;

        # get all accounts in the subscription
        $allAccountsInSubscription = Get-AzureRmLocationBasedServicesAccount;
        $numberOfAccountsInSubscription = ($allAccountsInSubscription | measure).Count;

        Assert-True { $numberOfAccountsInSubscription -ge $numberOfAccountsInRG }
        
        Retry-IfException { Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmLocationBasedServicesAccountKey
#>
function Test-GetAzureRmLocationBasedServicesAccountKey
{
    # Setup
    $rgname = Get-LocationBasedServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'lbsa' + $rgname;
        $skuname = 'S0';
        $loc = Get-Location 'Microsoft.LocationBasedServices' 'accounts' 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        
        $keys = Get-AzureRmLocationBasedServicesAccountKey -ResourceGroupName $rgname -Name $accountname;
        
        Assert-NotNull $keys.PrimaryKey;
        Assert-NotNull $keys.SecondaryKey;
        Assert-AreNotEqual $keys.PrimaryKey $keys.SecondaryKey;

        # get account by resourceid
        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        $keys2 = Get-AzureRmLocationBasedServicesAccountKey -ResourceId $resourceid;
        Assert-AreEqual $keys.PrimaryKey $keys2.PrimaryKey;
        Assert-AreEqual $keys.SecondaryKey $keys2.SecondaryKey;

        Retry-IfException { Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmLocationBasedServicesAccountKey
#>
function Test-NewAzureRmLocationBasedServicesAccountKey
{
    # Setup
    $rgname = Get-LocationBasedServicesManagementTestResourceName;
    
    try
    {
        # Test
        $accountname = 'lbsa' + $rgname;
        $skuname = 'S0';
        $loc = Get-Location 'Microsoft.LocationBasedServices' 'accounts' 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;
        
        $originalKeys = Get-AzureRmLocationBasedServicesAccountKey -ResourceGroupName $rgname -Name $accountname;

        # Update primary
        $updatedKeys = New-AzureRmLocationBasedServicesAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Primary -Confirm:$false;
            
        Assert-AreNotEqual $originalKeys.PrimaryKey $updatedKeys.PrimaryKey;
        Assert-AreEqual $originalKeys.SecondaryKey $updatedKeys.SecondaryKey;

        # Update secondary
        $updatedKeys2 = New-AzureRmLocationBasedServicesAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Secondary -Confirm:$false;

        Assert-AreEqual $updatedKeys.PrimaryKey $updatedKeys2.PrimaryKey;
        Assert-AreNotEqual $updatedKeys.SecondaryKey $updatedKeys2.SecondaryKey;

        # get account by resourceid
        $resource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $accountname;
        $resourceid = $resource.ResourceId;

        $updatedKeys3 = New-AzureRmLocationBasedServicesAccountKey -ResourceId $resourceid -KeyName Primary -Confirm:$false;
            
        Assert-AreNotEqual $updatedKeys2.PrimaryKey $updatedKeys3.PrimaryKey;
        Assert-AreEqual $updatedKeys2.SecondaryKey $updatedKeys3.SecondaryKey;


        Retry-IfException { Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Get-AzureRmLocationBasedServicesAccount | Get-AzureRmLocationBasedServicesAccountKey
#>
function Test-PipingGetAccountToGetKey
{
    # Setup
    $rgname = Get-LocationBasedServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'lbsa' + $rgname;
        $skuname = 'S0';
        $loc = Get-Location 'Microsoft.LocationBasedServices' 'accounts' 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName $skuname -Force;

        $keys = Get-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname | Get-AzureRmLocationBasedServicesAccountKey;
        Assert-NotNull $keys
        Assert-NotNull $keys.PrimaryKey
        Assert-NotNull $keys.SecondaryKey
        Assert-AreNotEqual $keys.PrimaryKey $keys.SecondaryKey;

        Retry-IfException { Remove-AzureRmLocationBasedServicesAccount -ResourceGroupName $rgname -Name $accountname -Confirm:$false; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

