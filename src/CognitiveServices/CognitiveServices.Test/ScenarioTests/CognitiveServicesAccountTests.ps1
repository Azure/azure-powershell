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
Test New-AzCognitiveServicesAccount
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Assert-NotNull $createdAccount;
        # Call create again, expect to get the same account
        $createdAccountAgain = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Assert-NotNull $createdAccountAgain
        Assert-AreEqual $createdAccount.Name $createdAccountAgain.Name;
        Assert-AreEqual $createdAccount.Endpoint $createdAccountAgain.Endpoint;
        
        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzCognitiveServicesAccount
#>
function Test-NewAzureRmAllKindsOfCognitiveServicesAccounts
{
	# Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

	$locWU = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
	$locGBL = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "Global";

	try
	{
		New-AzResourceGroup -Name $rgname -Location 'West US';
		
		# Create all known kinds of Cognitive Services accounts.
		Test-CreateCognitiveServicesAccount $rgname 'BingSearchTest' 'Bing.Search.v7' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'BingSpeechTest' 'SpeechServices' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'BingSpellCheckTest' 'Bing.SpellCheck.v7' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'ComputerVisionTest' 'ComputerVision' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'ContentModeratorTest' 'ContentModerator' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'FaceTest' 'Face' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'LUISTest' 'LUIS' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'SpeakerRecognitionTest' 'SpeakerRecognition' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'TextAnalyticsTest' 'TextAnalytics' 'S1' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'TextTranslationTest' 'TextTranslation' 'S1' $locGBL
	}
	finally
	{
	    # Cleanup
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Test Remove-AzCognitiveServicesAccount
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force;
		Assert-Throws { $accountGotten = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname; }
		Assert-Null $accountGotten;	
        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzCognitiveServiceAccount
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $account = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
        
        Assert-AreEqual $accountname $account.AccountName;
        Assert-AreEqual $accounttype $account.AccountType;
        Assert-AreEqual $loc $account.Location;
        Assert-AreEqual $skuname $account.Sku.Name;

        $accounts = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname;
        $numberOfAccountsInRG = ($accounts | measure).Count;
        Assert-AreEqual $accountname $accounts[0].AccountName;
        Assert-AreEqual $accounttype $accounts[0].AccountType;
        Assert-AreEqual $loc $accounts[0].Location;
        Assert-AreEqual $skuname $accounts[0].Sku.Name;

        $allAccountsInSubscription = Get-AzCognitiveServicesAccount;
        $numberOfAccountsInSubscription = ($allAccountsInSubscription | measure).Count;

        Assert-True { $numberOfAccountsInSubscription -ge $numberOfAccountsInRG }
        
        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzCognitiveServicesAccount
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
        
        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $originalAccount = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;

        # Update SKU
        $changedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -SkuName S3 -Tags @{Name = "testtag"; Value = "testval"} -Force;
        
        Assert-AreEqual $originalAccount.Location $changedAccount.Location;
        Assert-AreEqual $originalAccount.Endpoint $changedAccount.Endpoint;
        Assert-AreEqual $originalAccount.Kind $changedAccount.Kind;
        
        # get the account agains
        $gottenAccount = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;

        Assert-AreEqual $originalAccount.Location $gottenAccount.Location;
        Assert-AreEqual $originalAccount.Endpoint $gottenAccount.Endpoint;
        Assert-AreEqual $originalAccount.Kind $gottenAccount.Kind;
        Assert-AreEqual 'S3' $gottenAccount.Sku.Name;
		
        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzCognitiveServicesAccountKey
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        
        $keys = Get-AzCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname;
        
        Assert-AreNotEqual $keys.Key1 $keys.Key2;

        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzCognitiveServicesAccountKey
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        
        $originalKeys = Get-AzCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname;
        # Update key1
        $updatedKeys = New-AzCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Key1 -Force;
            
        Assert-AreNotEqual $originalKeys.Key1 $updatedKeys.Key1;
        Assert-AreEqual $originalKeys.Key2 $updatedKeys.Key2;

        # Update key2
        $reupdatedKeys = New-AzCognitiveServicesAccountKey -ResourceGroupName $rgname -Name $accountname -KeyName Key2 -Force;

        Assert-AreEqual $updatedKeys.Key1 $reupdatedKeys.Key1;
        Assert-AreNotEqual $originalKeys.Key2 $reupdatedKeys.Key2;

        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test New-AzCognitiveServicesAccountKey
#>
function Test-NewAzureRmCognitiveServicesAccountWithCustomDomain
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West Central US";

        New-AzResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;
        # Call create again, expect to get the same account
        $createdAccountAgain = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccountAgain
        Assert-AreEqual $createdAccount.Name $createdAccountAgain.Name;
        Assert-AreEqual $createdAccount.Endpoint $createdAccountAgain.Endpoint;
        Assert-True {$createdAccount.Endpoint.Contains('cognitiveservices.azure.com')}
        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzCognitiveServicesAccountSkus
#>
function Test-GetAzureRmCognitiveServicesAccountSkus
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    
    try
    {
        $skus = (Get-AzCognitiveServicesAccountSkus -Type 'TextAnalytics');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        $expectedSkus = "F0", "S", "S0","S1", "S2", "S3", "S4"
        Assert-AreEqualArray $expectedSkus $skuNames

		$skus = (Get-AzCognitiveServicesAccountSkus -Type 'TextAnalytics' -Location 'westus');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        $expectedSkus = "F0", "S", "S0","S1", "S2", "S3", "S4"
        Assert-AreEqualArray $expectedSkus $skuNames

        $skus = (Get-AzCognitiveServicesAccountSkus -Type 'QnAMaker' -Location 'global');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        Assert-AreEqual 0 $skuNames.Count

    }
    finally
    {
    }
}

<#
.SYNOPSIS
Test Get-AzCognitiveServicesAccountType
#>
function Test-GetAzureRmCognitiveServicesAccountType
{
    try
    {
        $typeName = (Get-AzCognitiveServicesAccountType -TypeName 'Face');
        Assert-AreEqual 'Face' $typeName

        $typeName = (Get-AzCognitiveServicesAccountType -TypeName 'InvalidKind');
        Assert-Null $typeName
		
		$typeNames = (Get-AzCognitiveServicesAccountType -Location 'westus');
        Assert-True {$typeNames.Contains('Face')}

		$typeNames = (Get-AzCognitiveServicesAccountType);
        Assert-True {$typeNames.Contains('Face')}

		$typeNames = (Get-AzCognitiveServicesAccountType -Location 'global');
        Assert-False {$typeNames.Contains('Face')}
        Assert-True {$typeNames.Contains('Bing.Search.v7')}
    }
    finally
    {
    }
}


<#
.SYNOPSIS
Test Get-AzCognitiveServicesAccount | Get-AzCognitiveServicesAccountKey
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $keys = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname | Get-AzCognitiveServicesAccountKey;
        Assert-AreNotEqual $keys.Key1 $keys.Key2;

        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzCognitiveServicesAccount | Set-AzCognitiveServicesAccount
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;

        $account = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
		$account | Set-AzCognitiveServicesAccount -SkuName S3 -Force;
		
        $updatedAccount = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname;
        Assert-AreEqual 'S3' $updatedAccount.Sku.Name;

        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test  New-AzCognitiveServicesAccount
#>
function Test-MinMaxAccountName
{
	# Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName

    try
    {
        # Test
        $shortname = 'aa';
		$longname = 'testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttest';
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $shortaccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $shortname -Type $accounttype -SkuName $skuname -Location $loc -Force;
		$longaccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $longname -Type $accounttype -SkuName $skuname -Location $loc -Force;

		Assert-AreEqual $shortname $shortaccount.AccountName;               
		Assert-AreEqual $longname $longaccount.AccountName;
        
        Retry-IfException { Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test  Test-GetWithPaging
#>
function Test-GetWithPaging
{
	# Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName
	$loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US"
	
	try
    {
		$TotalCount = 100
        # Test
        New-AzResourceGroup -Name $rgname -Location $loc

		# 100 Face
		For($i = 0; $i -lt $TotalCount ; $i++)
		{
			New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name "facepaging_wu_$i" -Type 'Face' -SkuName 'S0' -Location $loc -Force;
		}

		# 100 CV
		For($i = 0; $i -lt $TotalCount ; $i++)
		{
			New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name "cvpaging_wu_$i" -Type 'ComputerVision' -SkuName 'S0' -Location $loc -Force;
		}

		$accounts = Get-AzCognitiveServicesAccount
		Assert-AreEqual 200 $accounts.Count

		$accounts = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname
		Assert-AreEqual 200 $accounts.Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Test-GetUsages
#>
function Test-GetUsages
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US"

        New-AzResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
		$usages1 = Get-AzCognitiveServicesAccountUsage -ResourceGroupName $rgname -Name $accountname
		$usages2 = Get-AzCognitiveServicesAccountUsage -InputObject $createdAccount
		$usages3 = Get-AzCognitiveServicesAccountUsage -ResourceId $createdAccount.Id

		Assert-True {$usages1.Count -gt 0}
		Assert-AreEqual 0.0 $usages1[0].CurrentValue
		Assert-True {$usages1[0].Limit -gt 0}

		Assert-AreEqual $usages1.Count $usages2.Count
		Assert-AreEqual $usages2.Count $usages3.Count

		Assert-AreEqual $usages1[0].CurrentValue $usages2[0].CurrentValue
		Assert-AreEqual $usages2[0].CurrentValue $usages3[0].CurrentValue

		Assert-AreEqual $usages1[0].Limit $usages2[0].Limit
		Assert-AreEqual $usages2[0].Limit $usages3[0].Limit
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
