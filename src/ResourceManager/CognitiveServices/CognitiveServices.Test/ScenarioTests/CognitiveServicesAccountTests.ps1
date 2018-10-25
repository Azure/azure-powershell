﻿# ----------------------------------------------------------------------------------
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
Test New-AzureRmCognitiveServicesAccount
#>
function Test-NewAzureRmAllKindsOfCognitiveServicesAccounts
{
	# Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

	$locWU = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
	$locGBL = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "Global";

	try
	{
		New-AzureRmResourceGroup -Name $rgname -Location 'West US';
		
		# Create all known kinds of Cognitive Services accounts.
		Test-CreateCognitiveServicesAccount $rgname 'AcademicTest' 'Academic' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'BingAutosuggestTest' 'Bing.Autosuggest' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'BingSearchTest' 'Bing.Search' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'BingSpeechTest' 'Bing.Speech' 'S0' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'BingSpellCheckTest' 'Bing.SpellCheck' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'ComputerVisionTest' 'ComputerVision' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'ContentModeratorTest' 'ContentModerator' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'EmotionTest' 'Emotion' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'FaceTest' 'Face' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'LUISTest' 'LUIS' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'RecommendationsTest' 'Recommendations' 'S1' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'SpeakerRecognitionTest' 'SpeakerRecognition' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'SpeechTest' 'Speech' 'S0' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'SpeechTranslationTest' 'SpeechTranslation' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'TextAnalyticsTest' 'TextAnalytics' 'S1' $locWU
		Test-CreateCognitiveServicesAccount $rgname 'TextTranslationTest' 'TextTranslation' 'S1' $locGBL
		Test-CreateCognitiveServicesAccount $rgname 'WebLMTest' 'WebLM' 'S0' $locWU
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";
        
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
function Test-GetAzureRmCognitiveServicesAccountSkusLegacy
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        
        $skus = (Get-AzureRmCognitiveServicesAccountSkus -ResourceGroupName $rgname -Name $accountname).Value | Select-Object -ExpandProperty Sku;
        $skuNames = $skus | Select-Object -ExpandProperty Name
        
        $expectedSkus = "F0", "S0", "S1", "S2", "S3", "S4"
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
Test Get-AzureRmCognitiveServicesAccountSkus
#>
function Test-GetAzureRmCognitiveServicesAccountSkus
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    
    try
    {
        $skus = (Get-AzureRmCognitiveServicesAccountSkus -Type 'TextAnalytics');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        $expectedSkus = "F0", "S0","S1", "S2", "S3", "S4"
        Assert-AreEqualArray $expectedSkus $skuNames

		$skus = (Get-AzureRmCognitiveServicesAccountSkus -Type 'TextAnalytics' -Location 'westus');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        $expectedSkus = "F0", "S0","S1", "S2", "S3", "S4"
        Assert-AreEqualArray $expectedSkus $skuNames

        $skus = (Get-AzureRmCognitiveServicesAccountSkus -Type 'QnAMaker' -Location 'global');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        Assert-AreEqual 0 $skuNames.Count

    }
    finally
    {
    }
}

<#
.SYNOPSIS
Test Get-AzureRmCognitiveServicesAccountType
#>
function Test-GetAzureRmCognitiveServicesAccountType
{
    try
    {
        $typeName = (Get-AzureRmCognitiveServicesAccountType -TypeName 'Face');
        Assert-AreEqual 'Face' $typeName

        $typeName = (Get-AzureRmCognitiveServicesAccountType -TypeName 'InvalidKind');
        Assert-Null $typeName
		
		$typeNames = (Get-AzureRmCognitiveServicesAccountType -Location 'westus');
        Assert-True {$typeNames.Contains('Face')}

		$typeNames = (Get-AzureRmCognitiveServicesAccountType);
        Assert-True {$typeNames.Contains('Face')}

		$typeNames = (Get-AzureRmCognitiveServicesAccountType -Location 'global');
        Assert-False {$typeNames.Contains('Face')}
        Assert-True {$typeNames.Contains('Bing.Search.v7')}
    }
    finally
    {
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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US";

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

<#
.SYNOPSIS
Test  New-AzureRmCognitiveServicesAccount
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        $shortaccount = New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $shortname -Type $accounttype -SkuName $skuname -Location $loc -Force;
		$longaccount = New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $longname -Type $accounttype -SkuName $skuname -Location $loc -Force;

		Assert-AreEqual $shortname $shortaccount.AccountName;               
		Assert-AreEqual $longname $longaccount.AccountName;
        
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
        New-AzureRmResourceGroup -Name $rgname -Location $loc

		# 100 Face
		For($i = 0; $i -lt $TotalCount ; $i++)
		{
			New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name "facepaging_wu_$i" -Type 'Face' -SkuName 'S0' -Location $loc -Force;
		}

		# 100 Emotion
		For($i = 0; $i -lt $TotalCount ; $i++)
		{
			New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name "emotionpaging_wu_$i" -Type 'Emotion' -SkuName 'S0' -Location $loc -Force;
		}

		$accounts = Get-AzureRmCognitiveServicesAccount
		Assert-AreEqual 200 $accounts.Count

		$accounts = Get-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzureRmCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
		$usages1 = Get-AzureRmCognitiveServicesAccountUsage -ResourceGroupName $rgname -Name $accountname
		$usages2 = Get-AzureRmCognitiveServicesAccountUsage -InputObject $createdAccount
		$usages3 = Get-AzureRmCognitiveServicesAccountUsage -ResourceId $createdAccount.Id

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
