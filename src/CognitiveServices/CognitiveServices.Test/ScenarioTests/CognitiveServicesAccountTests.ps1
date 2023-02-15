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

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc;
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
Test AsyncAccountOperations
#>
function Test-AsyncAccountOperations
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Personalizer';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West US 2";

        New-AzResourceGroup -Name $rgname -Location $loc;

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force;
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
Test New-AzCognitiveServicesAccount
#>
function Test-NewAzureRmCognitiveServicesAccountWithVnet
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $vnetname = 'vnet' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "West Central US";

        New-AzResourceGroup -Name $rgname -Location $loc;

		$vnet = CreateAndGetVirtualNetwork $rgname $vnetname

		$networkRuleSet = [Microsoft.Azure.Commands.Management.CognitiveServices.Models.PSNetworkRuleSet]::New()
		$networkRuleSet.AddIpRule("200.0.0.0")
		$networkRuleSet.AddVirtualNetworkRule($vnet.Subnets[0].Id)

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force -NetworkRuleSet $networkRuleSet;
        Assert-NotNull $createdAccount;
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
function Test-SetAzureRmCognitiveServicesAccountWithCustomDomain
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

        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -Force;
        Assert-NotNull $createdAccount;
        
		$changedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -CustomSubdomainName $accountname -Force;
		Assert-NotNull $changedAccount;
        Assert-True {$changedAccount.Endpoint.Contains('cognitiveservices.azure.com')}
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
SetAzureRmCognitiveServicesAccountWithVnet
#>
function Test-SetAzureRmCognitiveServicesAccountWithVnet
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $vnetname = 'vnet' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;

		$vnet = CreateAndGetVirtualNetwork $rgname $vnetname

		$networkRuleSet = [Microsoft.Azure.Commands.Management.CognitiveServices.Models.PSNetworkRuleSet]::New()
		$networkRuleSet.AddIpRule("200.0.0.0")
		$networkRuleSet.AddVirtualNetworkRule($vnet.Subnets[0].Id)

		$changedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -NetworkRuleSet $networkRuleSet -Force;
		Assert-NotNull $changedAccount;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}





<#
.SYNOPSIS
TestNetworkRuleSet
#>
function Test-NetworkRuleSet
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $vnetname = 'vnet' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;

		$vnet = CreateAndGetVirtualNetwork $rgname $vnetname

		$vnetid = $vnet.Subnets[0].Id
		$vnetid2 = $vnet.Subnets[1].Id

		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-Null $ruleSet

		Update-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname -DefaultAction Deny
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 0 $ruleSet.VirtualNetworkRules.Count

		Add-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -VirtualNetworkResourceId $vnetid
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 1 $ruleSet.VirtualNetworkRules.Count

		Add-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -VirtualNetworkResourceId $vnetid2
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 2 $ruleSet.VirtualNetworkRules.Count

		Remove-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -VirtualNetworkResourceId $vnetid
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 1 $ruleSet.VirtualNetworkRules.Count

		Remove-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -VirtualNetworkResourceId $vnetid2
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 0 $ruleSet.VirtualNetworkRules.Count

		Add-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -AccountName $accountname -IpAddressOrRange "16.17.18.0"
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 1 $ruleSet.IpRules.Count
		Assert-AreEqual 0 $ruleSet.VirtualNetworkRules.Count

		Add-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -AccountName $accountname -IpAddressOrRange "16.17.18.1"
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 2 $ruleSet.IpRules.Count
		Assert-AreEqual 0 $ruleSet.VirtualNetworkRules.Count

		Remove-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -IpAddressOrRange "16.17.18.0"
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 1 $ruleSet.IpRules.Count
		Assert-AreEqual 0 $ruleSet.VirtualNetworkRules.Count

		Remove-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -IpAddressOrRange "16.17.18.1"
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 0 $ruleSet.VirtualNetworkRules.Count

		Update-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -AccountName $accountname -DefaultAction Allow -IPRule (@{IpAddress="200.0.0.0"},@{IpAddress="28.2.0.0/16"}) -VirtualNetworkRule (@{Id=$vnetid},@{Id=$vnetid2})
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Allow' $ruleSet.DefaultAction
		Assert-AreEqual 2 $ruleSet.IpRules.Count
		Assert-AreEqual 2 $ruleSet.VirtualNetworkRules.Count

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
TestNetworkRuleSetDefaultActions
#>
function Test-NetworkRuleSetDefaultActions
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $vnetname = 'vnet' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = Get-Location -providerNamespace "Microsoft.CognitiveServices" -resourceType "accounts" -preferredLocation "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;

		$vnet = CreateAndGetVirtualNetwork $rgname $vnetname

		$vnetid = $vnet.Subnets[0].Id
		$vnetid2 = $vnet.Subnets[1].Id

		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-Null $ruleSet

		Add-AzCognitiveServicesAccountNetworkRule -ResourceGroupName $rgname -Name $accountname -VirtualNetworkResourceId $vnetid
		$ruleSet = Get-AzCognitiveServicesAccountNetworkRuleSet -ResourceGroupName $rgname -Name $accountname
		Assert-NotNull $ruleSet
		Assert-AreEqual 'Deny' $ruleSet.DefaultAction
		Assert-AreEqual 0 $ruleSet.IpRules.Count
		Assert-AreEqual 1 $ruleSet.VirtualNetworkRules.Count
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
        
        Assert-AreNotEqual 0 $skuNames.Count

		$skus = (Get-AzCognitiveServicesAccountSkus -Type 'TextAnalytics' -Location 'westus');
        $skuNames = $skus | Select-Object -ExpandProperty Name | Sort-Object | Get-Unique
        
        Assert-AreNotEqual 0 $skuNames.Count

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

<#
.SYNOPSIS
Create a virtual network
#>
function CreateAndGetVirtualNetwork ($resourceGroupName, $vnetName, $location = "SOUTHCENTRALUS")
{

	$subnet1 = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "200.0.0.0/24"
	$subnet2 = New-AzVirtualNetworkSubnetConfig -Name "subnet" -AddressPrefix "200.0.1.0/24"
	$vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "200.0.0.0/16" -Subnet $subnet1,$subnet2

	$getVnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName

	return $getVnet
}

<#
.SYNOPSIS
Test ManagedIdentity
#>
function Test-ManagedIdentity
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    
    try
    {
        # Create with AssignIdentity
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Update with AssignIdentity
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -AssignIdentity
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.Identity.Type "SystemAssigned"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Update with IdentityType
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -IdentityType "SystemAssigned"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.Identity.Type "SystemAssigned"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Create with AssignIdentity and Update with IdentityType.None
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -IdentityType "None"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.Identity.Type "None"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test DisableLocalAuth
#>
function Test-DisableLocalAuth
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'TextAnalytics';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -DisableLocalAuth $true -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.DisableLocalAuth $true
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.DisableLocalAuth $null

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -DisableLocalAuth $true
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.DisableLocalAuth $true

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -DisableLocalAuth $false
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.DisableLocalAuth $false
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSISTest-ApiProperties
Test RestrictOutboundNetworkAccess
#>
function Test-RestrictOutboundNetworkAccess
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -RestrictOutboundNetworkAccess $true -AllowedFqdnList @("abc.com", "dfe.net") -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.AllowedFqdnList.Count 2
        Assert-AreEqual $createdAccount.RestrictOutboundNetworkAccess $true
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.RestrictOutboundNetworkAccess $null

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -RestrictOutboundNetworkAccess $true -AllowedFqdnList @("abc.com", "dfe.net")
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.AllowedFqdnList.Count 2
        Assert-AreEqual $updatedAccount.RestrictOutboundNetworkAccess $true

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -RestrictOutboundNetworkAccess $false
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.RestrictOutboundNetworkAccess $false
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test UserAssignedIdentity
#>
function Test-UserAssignedIdentity
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'E0';
        $accounttype = 'Face';
        $loc = "WestUS2";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -IdentityType "UserAssigned" -UserAssignedIdentityId @("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi") -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "UserAssigned"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'E0';
        $accounttype = 'Face';
        $loc = "WestUS2";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -AssignIdentity -IdentityType "SystemAssignedUserAssigned" -UserAssignedIdentityId "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi"
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.Identity.Type "SystemAssignedUserAssigned"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
   
<#
.SYNOPSIS
Test Encryption
#>
function Test-Encryption
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'E0';
        $accounttype = 'Face';
        $loc = "West US 2";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -CognitiveServicesEncryption -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"
        Assert-AreEqual $createdAccount.Encryption.KeySource "Microsoft.CognitiveServices"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }

    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'E0';
        $accounttype = 'Face';
        $loc = "West US 2";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -CognitiveServicesEncryption
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.Encryption.KeySource "Microsoft.CognitiveServices"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'FormRecognizer';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -IdentityType "UserAssigned" -UserAssignedIdentityId "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi"  -KeyVaultEncryption -KeyName "TestKey" -KeyVersion "dcb017f640db4818ba240751674f975f" -KeyVaultUri "https://sdk-test-mi.vault.azure.net/" -KeyVaultIdentityClientId "9feb3cc7-408c-449d-8baf-f3dd44ad292b" -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "UserAssigned"
        Assert-AreEqual $createdAccount.Encryption.KeySource "Microsoft.KeyVault"
        Assert-AreEqual $createdAccount.Encryption.KeyVaultProperties.KeyName "TestKey"
        Assert-AreEqual $createdAccount.Encryption.KeyVaultProperties.KeyVersion "dcb017f640db4818ba240751674f975f"
        Assert-AreEqual $createdAccount.Encryption.KeyVaultProperties.KeyVaultUri "https://sdk-test-mi.vault.azure.net/"
        Assert-AreEqual $createdAccount.Encryption.KeyVaultProperties.IdentityClientId "9feb3cc7-408c-449d-8baf-f3dd44ad292b"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'FormRecognizer';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -IdentityType "UserAssigned" -UserAssignedIdentityId "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi" -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "UserAssigned"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -KeyVaultEncryption -KeyName "TestKey" -KeyVersion "dcb017f640db4818ba240751674f975f" -KeyVaultUri "https://sdk-test-mi.vault.azure.net/" -KeyVaultIdentityClientId "9feb3cc7-408c-449d-8baf-f3dd44ad292b"
        Assert-NotNull $updatedAccount; 
        Assert-AreEqual $updatedAccount.Encryption.KeySource "Microsoft.KeyVault"
        Assert-AreEqual $updatedAccount.Encryption.KeyVaultProperties.KeyName "TestKey"
        Assert-AreEqual $updatedAccount.Encryption.KeyVaultProperties.KeyVersion "dcb017f640db4818ba240751674f975f"
        Assert-AreEqual $updatedAccount.Encryption.KeyVaultProperties.KeyVaultUri "https://sdk-test-mi.vault.azure.net/"
        Assert-AreEqual $updatedAccount.Encryption.KeyVaultProperties.IdentityClientId "9feb3cc7-408c-449d-8baf-f3dd44ad292b"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test UserOwnedStorage
#>
function Test-UserOwnedStorage
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'SpeechServices';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -StorageAccountId @("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest") -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"
        Assert-AreEqual $createdAccount.UserOwnedStorage.Length 1
        Assert-AreEqual $createdAccount.UserOwnedStorage[0].ResourceId "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'SpeechServices';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -AssignIdentity -Force;
        Assert-NotNull $createdAccount;
        
        
        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -StorageAccountId @("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest") 
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.UserOwnedStorage.Length 1
        Assert-AreEqual $updatedAccount.UserOwnedStorage[0].ResourceId "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test PrivateEndpoint
#>
function Test-PrivateEndpoint
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'Face';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Enabled"
        Assert-AreEqual $createdAccount.PrivateEndpointConnections $null

        $vnet = @{
            Name = 'vnet-ut'
            ResourceGroupName = $rgname
            Location = 'Central US EUAP'
            AddressPrefix = '10.0.0.0/16'    
        }
        $virtualNetwork = New-AzVirtualNetwork @vnet
        $subnet = @{
            Name = 'default'
            VirtualNetwork = $virtualNetwork
            AddressPrefix = '10.0.0.0/24'
        }
        $subnetConfig = Add-AzVirtualNetworkSubnetConfig @subnet
        $virtualNetwork | Set-AzVirtualNetwork

        $vnet = Get-AzVirtualNetwork -ResourceName vnet-ut -ResourceGroupName $rgname
        $plsConnection = New-AzPrivateLinkServiceConnection -Name pe-powershell-ut -PrivateLinkServiceId $createdAccount.Id -RequestMessage "Please Approve my request" -GroupId "account"
        New-AzPrivateEndpoint -PrivateLinkServiceConnection $plsConnection -Subnet $vnet.Subnets[0] -Name pe-powershell-ut -ResourceGroupName $rgname -Location centraluseuap -Force
        
        $account = Get-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname
        Assert-AreEqual $account.PrivateEndpointConnections.Length 1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test PublicNetworkAccess
#>
function Test-PublicNetworkAccess
{
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        $accountname = 'csa' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Enabled"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -PublicNetworkAccess "Disabled"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.PublicNetworkAccess "Disabled"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -PublicNetworkAccess "Enabled"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.PublicNetworkAccess "Enabled"

        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -PublicNetworkAccess "Enabled"
        Assert-NotNull $updatedAccount;
        Assert-AreEqual $updatedAccount.PublicNetworkAccess "Enabled"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        $accountname = 'csa' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -PublicNetworkAccess "Enabled" -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Enabled"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
    
    $rgname = Get-CognitiveServicesManagementTestResourceName;
    try
    {
        $accountname = 'csa' + $rgname;
        $skuname = 'S1';
        $accounttype = 'TextAnalytics';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -PublicNetworkAccess "Disabled" -Force;
        Assert-NotNull $createdAccount;
        Assert-AreEqual $createdAccount.PublicNetworkAccess "Disabled"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Capabilities
#>
function Test-Capabilities
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'F0';
        $accounttype = 'FormRecognizer';
        $loc = "Central US EUAP";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -Force;
        Assert-NotNull $createdAccount;
        Assert-True {$createdAccount.Capabilities.Length -gt 0}
        Assert-True {$createdAccount.Capabilities[0].Name.Length -gt 0}
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ApiProperties
#>
function Test-ApiProperties
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'QnAMaker.v2';
        $loc = "SOUTHCENTRALUS";

        New-AzResourceGroup -Name $rgname -Location $loc;
        $apiProperties = New-AzCognitiveServicesAccountApiProperty
        $apiProperties.QnaAzureSearchEndpointId = "https://sdk-test-qna-maker.azurewebsites.net"
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc -CustomSubdomainName $accountname -ApiProperty $apiProperties -Force;
        Assert-NotNull $createdAccount;
        Assert-True {$createdAccount.ApiProperties.QnaAzureSearchEndpointId -eq "https://sdk-test-qna-maker.azurewebsites.net"}
        
        $apiProperties.QnaAzureSearchEndpointId = "https://qnamaker.azurewebsites.net"
        
        $updatedAccount = Set-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -ApiProperty $apiProperties -Force;
        Assert-NotNull $updatedAccount;
        Assert-True {$updatedAccount.ApiProperties.QnaAzureSearchEndpointId -eq "https://qnamaker.azurewebsites.net"}
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test New-SoftDelete
#>
function Test-SoftDelete
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S2';
        $accounttype = 'TextAnalytics';
        $loc = "Central US EUAP";
        
        # generate a soft deleted account
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc;
        Assert-NotNull $createdAccount;
        Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force;
        
        # Check the soft deleted account
        $deletedAccounts = Get-AzCognitiveServicesAccount -InRemovedState;
        $deletedAccount = Get-AzCognitiveServicesAccount -InRemovedState -Location $loc -ResourceGroupName $rgname -Name $accountname;
        Assert-NotNull $deletedAccount;
        Assert-True {IsAccountInInAccountList $deletedAccount $deletedAccounts}

        # can recover
        Undo-AzCognitiveServicesAccountRemoval -Location $loc -ResourceGroupName $rgname -Name $accountname -Force
        Remove-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Force;

        # can purge
        Remove-AzCognitiveServicesAccount -Location $loc -ResourceGroupName $rgname -Name $accountname -InRemovedState -Force;
        $lastDeletedAccounts = Get-AzCognitiveServicesAccount -InRemovedState;
        Assert-False {IsAccountInInAccountList $deletedAccount $lastDeletedAccounts}

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test CommitmentPlan
#>
function Test-CommitmentPlan
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S';
        $accounttype = 'TextAnalytics';
        $loc = "Central US EUAP";
        
        # generate a account
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc;
        Assert-NotNull $createdAccount;
        

        Get-AzCognitiveServicesCommitmentTier -Location westus


        Get-AzCognitiveServicesAccountCommitmentPlan -ResourceGroupName $rgname -AccountName $accountname

        $properties = New-AzCognitiveServicesObject -Type CommitmentPlanProperties
        $properties.HostingModel = "Web"
        $properties.AutoRenew = $false
        $properties.PlanType = "TA"
        $properties.Current.Tier = "T1"
        $properties.Next = $null

        New-AzCognitiveServicesAccountCommitmentPlan -ResourceGroupName $rgname -AccountName $accountname -Name plan -Properties $properties
        Get-AzCognitiveServicesAccountCommitmentPlan -ResourceGroupName $rgname -AccountName $accountname
        Get-AzCognitiveServicesAccountCommitmentPlan -ResourceGroupName $rgname -AccountName $accountname -Name plan
        Remove-AzCognitiveServicesAccountCommitmentPlan -ResourceGroupName $rgname -AccountName $accountname -Name plan
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Deployment
#>
function Test-Deployment
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'OpenAI';
        $loc = "SOUTHCENTRALUS";
        
        # generate a account
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc;
        Assert-NotNull $createdAccount;
        
        Get-AzCognitiveServicesAccountDeployment -ResourceGroupName $rgname -AccountName $accountname

        $properties = New-AzCognitiveServicesObject -Type DeploymentProperties
        $properties.Model.Format = "OpenAI"
        $properties.Model.Name = "text-ada-001"
        $properties.Model.Version = "1"
        $properties.ScaleSettings.ScaleType = "Standard"

        New-AzCognitiveServicesAccountDeployment -ResourceGroupName $rgname -AccountName $accountname -Name dpy -Properties $properties
        Get-AzCognitiveServicesAccountDeployment -ResourceGroupName $rgname -AccountName $accountname
        Get-AzCognitiveServicesAccountDeployment -ResourceGroupName $rgname -AccountName $accountname -Name dpy
        Remove-AzCognitiveServicesAccountDeployment -ResourceGroupName $rgname -AccountName $accountname -Name dpy
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ListModels
#>
function Test-ListModels
{
    # Setup
    $rgname = Get-CognitiveServicesManagementTestResourceName;

    try
    {
        # Test
        $accountname = 'csa' + $rgname;
        $skuname = 'S0';
        $accounttype = 'OpenAI';
        $loc = "westus2";
        
        # generate a account
        New-AzResourceGroup -Name $rgname -Location $loc;
        $createdAccount = New-AzCognitiveServicesAccount -ResourceGroupName $rgname -Name $accountname -Type $accounttype -SkuName $skuname -Location $loc;
        Assert-NotNull $createdAccount;
        
        $models = Get-AzCognitiveServicesAccountModel -ResourceGroupName $rgname -AccountName $accountname
        
		Assert-AreNotEqual 0 $$models.Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Check if an account is in a list of accounts (location, resource group name and resource name match)
#>
function IsAccountInInAccountList ($account, $accounts) {
    foreach ($a in $accounts)
    {
        if (($a.AccountName -eq $account.AccountName) -and ($a.ResourceGroupName -eq $account.ResourceGroupName) -and ($a.Location -eq $account.Location)) {
            return $true
        }
    }
    return $false
}