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
Test StorageAccount
.DESCRIPTION
SmokeTest
#>
function Test-StorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'BlobStorage'
        $accessTier = 'Cool'

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $job = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -AccessTier $accessTier -AsJob
        $job | Wait-Job
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $accessTier $sto.AccessTier;

        $stotype = 'Standard_LRS';
        $accessTier = 'Hot'
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { $global:sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -AccessTier $accessTier -Force }
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $accessTier $sto.AccessTier;
    
        $stotype = 'Standard_RAGRS';
        $accessTier = 'Cool'
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -AccessTier $accessTier -Force
        
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $accessTier $sto.AccessTier;

        $stotype = 'Standard_GRS';
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype
        
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $accessTier $sto.AccessTier;

        $stokey1 = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

        New-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;
        
        $stokey2 = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey2[1].Value $stokey1[1].Value;

        New-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey3[0].Value $stokey2[0].Value;
        Assert-AreNotEqual $stokey2[1].Value $stokey3[1].Value;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzStorageAccount
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-NewAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $kind = 'StorageV2'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-NotNull  $sto.PrimaryEndpoints.Web 
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzStorageAccount
.DESCRIPTION
SmokeTest
#>
function Test-GetAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -RequireInfrastructureEncryption;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;
		Assert-AreEqual $true $sto.Encryption.RequireInfrastructureEncryption

        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stoname $stos[0].StorageAccountName;
        Assert-AreEqual $stotype $stos[0].Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $stos[0].Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzStorageAccount
.DESCRIPTION
SmokeTest
#>
function Test-SetAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableHttpsTrafficOnly $true  -EnableHierarchicalNamespace $true;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;
        
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stoname $stos[0].StorageAccountName;
        Assert-AreEqual $stotype $stos[0].Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $stos[0].Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -EnableHttpsTrafficOnly $false }
        $stotype = 'Standard_RAGRS';
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $false $sto.EnableHttpsTrafficOnly;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzStorageAccount -Force
.DESCRIPTION
SmokeTest
#>
function Test-RemoveAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzStorageAccountEncryptionKeySource
#>
function Test-SetAzureRmStorageAccountKeySource
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -StorageEncryption
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $true $sto.Encryption.Services.Blob.Enabled
        Assert-AreEqual $true $sto.Encryption.Services.File.Enabled
        Assert-AreEqual Microsoft.Storage $sto.Encryption.KeySource;
        Assert-AreEqual $null $sto.Encryption.Keyvaultproperties.Keyname;
        Assert-AreEqual $null $sto.Encryption.Keyvaultproperties.KeyVersion;
        Assert-AreEqual $null $sto.Encryption.Keyvaultproperties.KeyVaultUri;
        
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -StorageEncryption -AssignIdentity
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreNotEqual SystemAssigned $sto.Identity.Type
        Assert-AreEqual $true $sto.Encryption.Services.Blob.Enabled
        Assert-AreEqual $true $sto.Encryption.Services.File.Enabled
        Assert-AreEqual Microsoft.Storage $sto.Encryption.KeySource;
        Assert-AreEqual $null $sto.Encryption.Keyvaultproperties.Keyname;
        Assert-AreEqual $null $sto.Encryption.Keyvaultproperties.KeyVersion;
        Assert-AreEqual $null $sto.Encryption.Keyvaultproperties.KeyVaultUri;
        
        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; 
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzStorageAccountKey
#>
function Test-GetAzureStorageAccountKey
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokeys = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreNotEqual $stokeys[1].Value $stokeys[0].Value;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzStorageAccountKey
#>
function Test-NewAzureStorageAccountKey
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokey1 = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }

        New-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;

        $stokey2 = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey1[1].Value $stokey2[1].Value;

        New-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey2[0].Value $stokey3[0].Value;
        Assert-AreNotEqual $stokey2[1].Value $stokey3[1].Value;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzStorageAccount | Get-AzStorageAccountKey 
#>
function Test-PipingGetAccountToGetKey
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:stokeys = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname | Get-AzStorageAccountKey -ResourceGroupName $rgname; }
        Assert-AreNotEqual $stokeys[0].Value $stokeys[1].Value;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzStorageAccount | Set-AzCurrentStorageAccount
.DESCRIPTION
SmokeTest
#>
function Test-PipingToSetAzureRmCurrentStorageAccount
{
 # Setup
    $rgname = Get-StorageManagementTestResourceName

    try
    {
        # Test
        $stoname = 'sto' + $rgname
        $stotype = 'Standard_GRS'
        $loc = Get-ProviderLocation ResourceManagement

        New-AzResourceGroup -Name $rgname -Location $loc;

        $loc = Get-ProviderLocation_Stage;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname }
        $global:sto | Set-AzCurrentStorageAccount
        $context = Get-AzContext
        $sub = New-Object -TypeName Microsoft.Azure.Commands.Profile.Models.PSAzureSubscription -ArgumentList $context.Subscription
        Assert-AreEqual $stoname $sub.CurrentStorageAccountName
        $global:sto | Remove-AzStorageAccount -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzCurrentStorageAccount with RG and storage account name parameters
.DESCRIPTION
SmokeTest
#>
function Test-SetAzureRmCurrentStorageAccount
{
 # Setup
    $rgname = Get-StorageManagementTestResourceName

    try
    {
        # Test
        $stoname = 'sto' + $rgname
        $stotype = 'Standard_GRS'
        $loc = Get-ProviderLocation ResourceManagement

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname }
        Set-AzCurrentStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname
        $context = Get-AzContext
        Assert-AreEqual $stoname $context.Subscription.CurrentStorageAccountName
        $global:sto | Remove-AzStorageAccount -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Revoke-AzStorageAccountUserDelegationKeys
.DESCRIPTION
SmokeTest
#>
function Test-RevokeAzStorageAccountUserDelegationKeys
{
 # Setup
    $rgname = Get-StorageManagementTestResourceName

    try
    {
        # Test
        $stoname = 'sto' + $rgname
        $stotype = 'Standard_LRS'
        $loc = Get-ProviderLocation ResourceManagement

        New-AzResourceGroup -Name $rgname -Location $loc
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
		
		# revoke with storage account name and resource group name
		Revoke-AzStorageAccountUserDelegationKeys -ResourceGroupName $rgname  -Name $stoname

		# revoke with pipeline
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname }
        $global:sto | Revoke-AzStorageAccountUserDelegationKeys
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test NetworkRule
#>
function Test-NetworkRule
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $ip1 = "20.11.0.0/16";
        $ip2 = "10.0.0.0/7";
        $ip3 = "11.1.1.0/24";
        $ip4 = "28.0.2.0/19";

        New-AzResourceGroup -Name $rgname -Location $loc;
        
        $global:sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -NetworkRuleSet (@{bypass="Logging,Metrics,AzureServices";
            ipRules=(@{IPAddressOrRange="$ip1";Action="allow"},
            @{IPAddressOrRange="$ip2";Action="allow"});
            defaultAction="Deny"}) 

        $stoacl = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname).NetworkRuleSet
        Assert-AreEqual 7 $stoacl.Bypass;
        Assert-AreEqual Deny $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip1 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip2 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count

        $sto | Update-AzStorageAccountNetworkRuleSet -verbose -Bypass AzureServices,Metrics -DefaultAction Allow -IpRule (@{IPAddressOrRange="$ip3";Action="allow"},@{IPAddressOrRange="$ip4";Action="allow"})
        $stoacl = $sto | Get-AzStorageAccountNetworkRuleSet
        $stoacliprule = $stoacl.IpRules
        Assert-AreEqual 6 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip3 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip4 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count

        $job = Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IPAddressOrRange "$ip3" -AsJob
        $job | Wait-Job
        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 6 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 1 $stoacl.IpRules.Count
        Assert-AreEqual $ip4 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        
        $job = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname -IpRule @() -DefaultAction Deny -Bypass None -AsJob
        $job | Wait-Job
        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 0 $stoacl.Bypass;
        Assert-AreEqual Deny $stoacl.DefaultAction;
        Assert-AreEqual 0 $stoacl.IpRules.Count
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        
        foreach($iprule in $stoacliprule) {
            $job = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IpRule $iprule -AsJob
            $job | Wait-Job
			# add again should not fail
			Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IpRule $iprule
        }

        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 0 $stoacl.Bypass;
        Assert-AreEqual Deny $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip3 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip4 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        
        $job = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -AsJob -NetworkRuleSet (@{bypass="AzureServices";
            ipRules=(@{IPAddressOrRange="$ip1";Action="allow"},
            @{IPAddressOrRange="$ip2";Action="allow"});
            defaultAction="Allow"}) 
        $job | Wait-Job

        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 4 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip1 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip2 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count

        $job = Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname -AsJob
        $job | Wait-Job
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test SetAzureStorageAccount with Kind as StorageV2
.Description
AzureAutomationTest
#>
function Test-SetAzureStorageAccountStorageV2
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'Storage'

        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;        
                    
        $kind = 'StorageV2'
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -UpgradeToStorageV2;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-NotNull  $sto.PrimaryEndpoints.Web 

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test GetAzureStorageUsage with current Location
.Description
AzureAutomationTest
#>
function Test-GetAzureStorageLocationUsage
{
        # Test
        $loc = Get-ProviderLocation_Stage ResourceManagement; 

        $usage = Get-AzStorageUsage -Location $loc
        Assert-AreNotEqual 0 $usage.Limit;
        Assert-AreNotEqual 0 $usage.CurrentValue;      
}

<#
.SYNOPSIS
Test Invoke-AzStorageAccountFailover
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-FailoverAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_RAGRS';
        $kind = 'StorageV2'

        $loc = Get-ProviderLocation_Canary ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        $seconcaryLocation = $sto.SecondaryLocation

        #Invoke Failover
        $job = Invoke-AzStorageAccountFailover -ResourceGroupName $rgname -Name $stoname -Force -AsJob
        $job | Wait-Job

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $seconcaryLocation $sto.PrimaryLocation;
        Assert-AreEqual 'Standard_LRS' $sto.Sku.Name;
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzStorageAccountFileStorage
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-NewAzureStorageAccountFileStorage
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $kind = 'FileStorage'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
#>
function Test-NewAzureStorageAccountFileStorage
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $kind = 'FileStorage'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzStorageAccountBlockBlobStorage
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-NewAzureStorageAccountBlockBlobStorage
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $kind = 'BlockBlobStorage'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test GetAzureStorageUsage with current Location
.Description
AzureAutomationTest
#>
function Test-GetAzureStorageLocationUsage
{
        # Test
        $loc = Get-ProviderLocation_Stage ResourceManagement; 

        $usage = Get-AzStorageUsage -Location $loc
        Assert-AreNotEqual 0 $usage.Limit;
        Assert-AreNotEqual 0 $usage.CurrentValue;      
}

<#
.SYNOPSIS
Test Get-AzStorageAccount with -IncludeGeoReplicationStats
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-GetAzureStorageAccountGeoReplicationStats
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_RAGRS';
        $kind = 'StorageV2'

        $loc = Get-ProviderLocation_Canary ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname -IncludeGeoReplicationStats;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-NotNull $sto.GeoReplicationStats.Status
        Assert-NotNull $sto.GeoReplicationStats.LastSyncTime
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
        }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzStorageAccount | New/Set-AzStorageAccount
#>
function Test-PipingNewUpdateAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stoname2 = 'sto' + $rgname + '2';
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;

        $global:sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto2 = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname | New-AzStorageAccount -Name $stoname2 -skuName $stotype; }
        Assert-AreEqual $sto.ResourceGroupName $sto2.ResourceGroupName;
        Assert-AreEqual $sto.Location $sto2.Location;
        Assert-AreNotEqual $sto.StorageAccountName $sto2.StorageAccountName;
		
		Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname | set-AzStorageAccount -UpgradeToStorageV2
		$global:sto = $sto | set-AzStorageAccount -EnableHttpsTrafficOnly $true
        Assert-AreEqual 'StorageV2' $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;

        Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname | Remove-AzStorageAccount -Force;
        $sto2 | Remove-AzStorageAccount -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}



<#
.SYNOPSIS
Test NewSet-AzStorageAccountFileAADDS
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-NewSetAzStorageAccountFileAADDS
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $kind = 'StorageV2'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        $loc = Get-ProviderLocation_Stage ResourceManagement;
		
        $sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableAzureActiveDirectoryDomainServicesForFile $true;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADDS' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 	

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADDS' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 		
		
		$sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableAzureActiveDirectoryDomainServicesForFile $false
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'None' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'None' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 
        
        Retry-IfException { Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set/Get/Remove-AzureStorageAccountManagementPolicy
.Description
AzureAutomationTest
#>
function Test-StorageAccountManagementPolicy
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;        
                    
		# create Rule1
		$action1 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
		$action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToArchive -daysAfterModificationGreaterThan 50
		$action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToCool -daysAfterModificationGreaterThan 30
		$action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction Delete -daysAfterCreationGreaterThan 100
		$filter1 = New-AzStorageAccountManagementPolicyFilter -PrefixMatch ab,cd
		$rule1 = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action1 -Filter $filter1

		# create Rule2
		$action2 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
		$filter2 = New-AzStorageAccountManagementPolicyFilter
		$rule2 = New-AzStorageAccountManagementPolicyRule -Name Test2 -Action $action2 -Filter $filter2 -Disabled

		# Set policy 
		$policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -Rule $rule1, $rule2
		Assert-AreEqual 2 $policy.Rules.Count
		Assert-AreEqual $rule1.Enabled $policy.Rules[0].Enabled
		Assert-AreEqual $rule1.Name $policy.Rules[0].Name
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
		Assert-AreEqual $rule1.Definition.Filters.BlobTypes[0] $policy.Rules[0].Definition.Filters.BlobTypes[0]
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch.Count $policy.Rules[0].Definition.Filters.PrefixMatch.Count
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch[0] $policy.Rules[0].Definition.Filters.PrefixMatch[0]
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch[1] $policy.Rules[0].Definition.Filters.PrefixMatch[1]		
		Assert-AreEqual $rule2.Enabled $policy.Rules[1].Enabled
		Assert-AreEqual $rule2.Name $policy.Rules[1].Name
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan $policy.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.TierToArchive $policy.Rules[1].Definition.Actions.BaseBlob.TierToArchive
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.TierToCool $policy.Rules[1].Definition.Actions.BaseBlob.TierToCool
		Assert-AreEqual $rule2.Definition.Actions.Snapshot $policy.Rules[1].Definition.Actions.Snapshot
		Assert-AreEqual $rule2.Definition.Filters.BlobTypes[0] $policy.Rules[1].Definition.Filters.BlobTypes[0]
		Assert-AreEqual $rule2.Definition.Filters.PrefixMatch $policy.Rules[1].Definition.Filters.PrefixMatch
		
		$policy = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 2 $policy.Rules.Count
		Assert-AreEqual $rule1.Enabled $policy.Rules[0].Enabled
		Assert-AreEqual $rule1.Name $policy.Rules[0].Name
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
		Assert-AreEqual $rule1.Definition.Filters.BlobTypes[0] $policy.Rules[0].Definition.Filters.BlobTypes[0]
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch.Count $policy.Rules[0].Definition.Filters.PrefixMatch.Count
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch[0] $policy.Rules[0].Definition.Filters.PrefixMatch[0]
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch[1] $policy.Rules[0].Definition.Filters.PrefixMatch[1]		
		Assert-AreEqual $rule2.Enabled $policy.Rules[1].Enabled
		Assert-AreEqual $rule2.Name $policy.Rules[1].Name
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan $policy.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.TierToArchive $policy.Rules[1].Definition.Actions.BaseBlob.TierToArchive
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.TierToCool $policy.Rules[1].Definition.Actions.BaseBlob.TierToCool
		Assert-AreEqual $rule2.Definition.Actions.Snapshot $policy.Rules[1].Definition.Actions.Snapshot
		Assert-AreEqual $rule2.Definition.Filters.BlobTypes[0] $policy.Rules[1].Definition.Filters.BlobTypes[0]
		Assert-AreEqual $rule2.Definition.Filters.PrefixMatch $policy.Rules[1].Definition.Filters.PrefixMatch

		Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname	
        
		$policy| Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname 

		$policy = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname	
        Assert-AreEqual 2 $policy.Rules.Count
		Assert-AreEqual $rule1.Enabled $policy.Rules[0].Enabled
		Assert-AreEqual $rule1.Name $policy.Rules[0].Name
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
		Assert-AreEqual $rule1.Definition.Filters.BlobTypes[0] $policy.Rules[0].Definition.Filters.BlobTypes[0]
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch.Count $policy.Rules[0].Definition.Filters.PrefixMatch.Count
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch[0] $policy.Rules[0].Definition.Filters.PrefixMatch[0]
		Assert-AreEqual $rule1.Definition.Filters.PrefixMatch[1] $policy.Rules[0].Definition.Filters.PrefixMatch[1]		
		Assert-AreEqual $rule2.Enabled $policy.Rules[1].Enabled
		Assert-AreEqual $rule2.Name $policy.Rules[1].Name
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan $policy.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.TierToArchive $policy.Rules[1].Definition.Actions.BaseBlob.TierToArchive
		Assert-AreEqual $rule2.Definition.Actions.BaseBlob.TierToCool $policy.Rules[1].Definition.Actions.BaseBlob.TierToCool
		Assert-AreEqual $rule2.Definition.Actions.Snapshot $policy.Rules[1].Definition.Actions.Snapshot
		Assert-AreEqual $rule2.Definition.Filters.BlobTypes[0] $policy.Rules[1].Definition.Filters.BlobTypes[0]
		Assert-AreEqual $rule2.Definition.Filters.PrefixMatch $policy.Rules[1].Definition.Filters.PrefixMatch

		$policy| Remove-AzStorageAccountManagementPolicy

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Test-NewSetAzureStorageAccount_LargeFileShare
.DESCRIPTION
SmokeTest
#>
function Test-NewSetAzureStorageAccount_LargeFileShare
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
		# new account
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -EnableLargeFileShare;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual "Enabled" $sto.LargeFileSharesState;
		
		#update Account
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableLargeFileShare -SkuName $stotype -UpgradeToStorageV2;
		
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual "Enabled" $sto.LargeFileSharesState;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Test-NewAzureStorageAccountQueueTableEncrytionKeyType
.DESCRIPTION
SmokeTest
#>
function Test-NewAzureStorageAccountQueueTableEncrytionKeyType
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
		# new account
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -EncryptionKeyTypeForTable Account -EncryptionKeyTypeForQueue Account

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual "Account" $sto.Encryption.Services.Queue.KeyType
        Assert-AreEqual "Account" $sto.Encryption.Services.Table.KeyType

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Test-NewSetAzureStorageAccount_GZRS
.DESCRIPTION
SmokeTest
#>
function Test-NewSetAzureStorageAccount_GZRS
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GZRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype ;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
		
        $stotype = 'Standard_RAGZRS';
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -SkuName $stotype ;
		
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

	<#
.SYNOPSIS
Test Test-NewAzureStorageAccount_RAGZRS
.DESCRIPTION
SmokeTest
#>
function Test-NewSetAzureStorageAccount_RAGZRS
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_RAGZRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype ;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
		
        $stotype = 'Standard_GZRS';
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -SkuName $stotype ;
		
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}



	<#
.SYNOPSIS
Test Test-NewAzureStorageAccount_TLSveresionBlobPublicAccess
.DESCRIPTION
SmokeTest
#>
function Test-NewSetAzureStorageAccountTLSveresionBlobPublicAccess
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'
		$tlsVersion = "TLS1_2"

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype  -MinimumTlsVersion $tlsVersion -AllowBlobPublicAccess $false;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $tlsVersion $sto.MinimumTlsVersion
        Assert-AreEqual $false $sto.AllowBlobPublicAccess
		
		$tlsVersion = "TLS1_1"
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -SkuName $stotype -MinimumTlsVersion $tlsVersion -AllowBlobPublicAccess $true ;
		
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $tlsVersion $sto.MinimumTlsVersion
        Assert-AreEqual $true $sto.AllowBlobPublicAccess

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

	<#
.SYNOPSIS
Test Test-NewSetAzStorageAccount_RoutingPreference
.DESCRIPTION
SmokeTest
#>
function Test-NewSetAzStorageAccount_RoutingPreference
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -PublishMicrosoftEndpoint $true -PublishInternetEndpoint $true -RoutingChoice MicrosoftRouting;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
		Assert-AreEqual $true $sto.RoutingPreference.PublishMicrosoftEndpoints
		Assert-AreEqual $true $sto.RoutingPreference.PublishInternetEndpoints
		Assert-AreEqual "MicrosoftRouting" $sto.RoutingPreference.RoutingChoice
		Assert-AreNotEqual $null $sto.PrimaryEndpoints.MicrosoftEndpoints
		Assert-AreNotEqual $null $sto.PrimaryEndpoints.InternetEndpoints
		
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -RoutingChoice InternetRouting;
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
		Assert-AreEqual $true $sto.RoutingPreference.PublishMicrosoftEndpoints
		Assert-AreEqual $true $sto.RoutingPreference.PublishInternetEndpoints
		Assert-AreEqual "InternetRouting" $sto.RoutingPreference.RoutingChoice
		Assert-AreNotEqual $null $sto.PrimaryEndpoints.MicrosoftEndpoints
		Assert-AreNotEqual $null $sto.PrimaryEndpoints.InternetEndpoints

        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -PublishMicrosoftEndpoint $false ;
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
		Assert-AreEqual $false $sto.RoutingPreference.PublishMicrosoftEndpoints
		Assert-AreEqual $true $sto.RoutingPreference.PublishInternetEndpoints
		Assert-AreEqual "InternetRouting" $sto.RoutingPreference.RoutingChoice
		Assert-AreEqual $null $sto.PrimaryEndpoints.MicrosoftEndpoints
		Assert-AreNotEqual $null $sto.PrimaryEndpoints.InternetEndpoints

        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -PublishInternetEndpoint $false;
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
		Assert-AreEqual $false $sto.RoutingPreference.PublishMicrosoftEndpoints
		Assert-AreEqual $false $sto.RoutingPreference.PublishInternetEndpoints
		Assert-AreEqual "InternetRouting" $sto.RoutingPreference.RoutingChoice
		Assert-AreEqual $null $sto.PrimaryEndpoints.MicrosoftEndpoints
		Assert-AreEqual $null $sto.PrimaryEndpoints.InternetEndpoints

        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -PublishMicrosoftEndpoint $true -PublishInternetEndpoint $false -RoutingChoice MicrosoftRouting;
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
		Assert-AreEqual $true $sto.RoutingPreference.PublishMicrosoftEndpoints
		Assert-AreEqual $false $sto.RoutingPreference.PublishInternetEndpoints
		Assert-AreEqual "MicrosoftRouting" $sto.RoutingPreference.RoutingChoice
		Assert-AreNotEqual $null $sto.PrimaryEndpoints.MicrosoftEndpoints
		Assert-AreEqual $null $sto.PrimaryEndpoints.InternetEndpoints

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}