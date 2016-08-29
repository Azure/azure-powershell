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
Test New-AzureRmCognitiveServicesAccount
#>
function Test-NewAzureRmCognitiveServicesAccount
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Assert-NotNull $createdAccount;
        # Call create again, expect to get the same account
        $createdAccountAgain = New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Assert-NotNull $createdAccountAgain
        Assert-AreEqual $createdAccount.Name $createdAccountAgain.Name;
        Assert-AreEqual $createdAccount.Endpoint $createdAccountAgain.Endpoint;
        
        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRmCognitiveServicesAccount
#>
function Test-RemoveAzureRmCognitiveServicesAccount
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force;
		Assert-Throws { $accountGotten = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname; }
		Assert-Null $accountGotten;	
        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmCognitiveServiceAccount
#>
function Test-GetAzureCognitiveServiceAccount
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $account = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
        
        Assert-AreEqual $accountname $account.AccountName;
        Assert-AreEqual $accounttype $account.AccountType;
        Assert-AreEqual $loc $account.Location;
        Assert-AreEqual $skuname $account.Sku.Name;

        $accounts = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname;
        $numberOfAccountsInRG = ($accounts | measure).Count;
        Assert-AreEqual $accountname $accounts[0].AccountName;
        Assert-AreEqual $accounttype $accounts[0].AccountType;
        Assert-AreEqual $loc $accounts[0].Location;
        Assert-AreEqual $skuname $accounts[0].Sku.Name;

        $allAccountsInSubscription = Get-AzureRmCognitiveServicesAccount;
        $numberOfAccountsInSubscription = ($allAccountsInSubscription | measure).Count;

        Assert-True { $numberOfAccountsInSubscription -ge $numberOfAccountsInRG }
        
        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzureRmCognitiveServicesAccount
#>
function Test-SetAzureRmCognitiveServicesAccount
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';
        
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $originalAccount = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;

        # Update SKU
        $changedAccount = Set-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName S3 -Tags @{Name = "testtag"; Value = "testval"} -Force;
        
        Assert-AreEqual $originalAccount.Location $changedAccount.Location;
        Assert-AreEqual $originalAccount.Endpoint $changedAccount.Endpoint;
        Assert-AreEqual $originalAccount.Kind $changedAccount.Kind;
        
        # get the account agains
        $gottenAccount = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;

        Assert-AreEqual $originalAccount.Location $gottenAccount.Location;
        Assert-AreEqual $originalAccount.Endpoint $gottenAccount.Endpoint;
        Assert-AreEqual $originalAccount.Kind $gottenAccount.Kind;
        Assert-AreEqual 'S3' $gottenAccount.Sku.Name;
		
        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmCognitiveServicesAccountKey
#>
function Test-GetAzureRmCognitiveServicesAccountKey
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        
        $keys = Get-AzureRmCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname;
        
        Assert-AreNotEqual $keys.Key1 $keys.Key2;

        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmCognitiveServicesAccountKey
#>
function Test-NewAzureRmCognitiveServicesAccountKey
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        
        $originalKeys = Get-AzureRmCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname;
        # Update key1
        $updatedKeys = New-AzureRmCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Key1 -Force;
            
        Assert-AreNotEqual $originalKeys.Key1 $updatedKeys.Key1;
        Assert-AreEqual $originalKeys.Key2 $updatedKeys.Key2;

        # Update key2
        $reupdatedKeys = New-AzureRmCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Key2 -Force;

        Assert-AreEqual $updatedKeys.Key1 $reupdatedKeys.Key1;
        Assert-AreNotEqual $originalKeys.Key2 $reupdatedKeys.Key2;

        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Get-AzureRmCognitiveServicesAccountSkus
#>
function Test-GetAzureRmCognitiveServicesAccountSkus
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        
        $skus = (Get-AzureRmCognitiveServicesAccountSkus -ResourceGroupName $rgname -Name $accountname).Value | Select-Object -ExpandProperty Sku;
        $skuNames = $skus | Select-Object -ExpandProperty Name
        
        $expectedSkus = "F0", "S1", "S2", "S3", "S4"
        Assert-AreEqualArray $expectedSkus $skuNames

        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmCognitiveServicesAccount | Get-AzureRmCognitiveServicesAccountKey
#>
function Test-PipingGetAccountToGetKey
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $keys = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname | Get-AzureRmCognitiveServicesAccountKey;
        Assert-AreNotEqual $keys.Key1 $keys.Key2;

        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmCognitiveServicesAccount | Set-AzureRmCognitiveServicesAccount
#>
function Test-PipingToSetAzureAccount
{
 # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $account = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
		$account | Set-AzureRmCognitiveServicesAccount -SkuName S3 -Force;
		
        $updatedAccount = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
        Assert-AreEqual 'S3' $updatedAccount.Sku.Name;

        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmCognitiveServicesAccount | Get-AzureRmCognitiveServicesAccountSkus
#>
function Test-PipingToGetAccountSkus
{
 # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $account = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
		$sku = ($account | Get-AzureRmCognitiveServicesAccountSkus).Value | Select-Object -ExpandProperty Sku;
        $skuNames = $sku | Select-Object -ExpandProperty Name
        
        $expectedSkus = "F0", "S1", "S2", "S3", "S4"
        Assert-AreEqualArray $expectedSkus $skuNames
        
        Retry-IfException { Remove-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

