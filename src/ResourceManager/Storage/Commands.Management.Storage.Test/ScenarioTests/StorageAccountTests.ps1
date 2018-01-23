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
.Description
AzureAutomationTest
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
		$encryptionServiceBF = "Blob,File"
		$encryptionServiceB = "Blob"
		$encryptionServiceF = "File"
		$kind = 'BlobStorage'
		$accessTier = 'Cool'

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $job = New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -AccessTier $accessTier -EnableEncryptionService $encryptionServiceBF -AsJob
		$job | Wait-Job
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;

        $stotype = 'StandardGRS';
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname; }
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.AccessTier $accessTier;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true

        $stotype = 'Standard_LRS';
		$accessTier = 'Hot'
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { $global:sto = Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -DisableEncryptionService $encryptionServiceB -AccessTier $accessTier -Force; }
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardLRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.AccessTier $accessTier;
		Assert-AreEqual $sto.Encryption.Services.Blob $null
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true
    
        $stotype = 'Standard_RAGRS';
		$accessTier = 'Cool'
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -AccessTier $accessTier -DisableEncryptionService $encryptionServiceF -EnableEncryptionService $encryptionServiceB -Force ;
        
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.AccessTier $accessTier;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File $null

        $stotype = 'Standard_GRS';
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -DisableEncryptionService $encryptionServiceBF;
        
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.AccessTier $accessTier;
		Assert-AreEqual $sto.Encryption $null

        $stokey1 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;
        
        $stokey2 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey1[1].Value $stokey2[1].Value;

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey2[0].Value $stokey3[0].Value;
        Assert-AreNotEqual $stokey2[1].Value $stokey3[1].Value;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmStorageAccount
.Description
AzureAutomationTest
#>
function Test-NewAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_ZRS';
		$kind = 'StorageV2'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        
		$sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
		$stotype = 'StandardZRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        
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
Test Get-AzureRmStorageAccount
.Description
AzureAutomationTest
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
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = 'Storage'

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
		 Write-Output ("Resource Group created")

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype ;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $false;

        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].StorageAccountName $stoname;
        Assert-AreEqual $stos[0].Sku.Name $stotype;
        Assert-AreEqual $stos[0].Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $false;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzureRmStorageAccount
.Description
AzureAutomationTest
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
		$kind = 'Storage'
		$encryptionServiceBF = "File,Blob"

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableEncryptionService $encryptionServiceBF -EnableHttpsTrafficOnly $true;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $true;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true
        
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].StorageAccountName $stoname;
        Assert-AreEqual $stos[0].Sku.Name $stotype;
        Assert-AreEqual $stos[0].Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $true;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -DisableEncryptionService $encryptionServiceBF -EnableHttpsTrafficOnly $false; }
        $stotype = 'Standard_RAGRS';
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;

        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $false;
		Assert-AreEqual $sto.Encryption $null

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRmStorageAccount -Force
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
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
Test New-AzureRmStorageAccountEncryptionKeySource
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
		
		$sto = Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableEncryptionService Blob -StorageEncryption
		$stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
        Assert-AreEqual $sto.Encryption.KeySource Microsoft.Storage;
        Assert-AreEqual $sto.Encryption.Keyvaultproperties.Keyname $null;
        Assert-AreEqual $sto.Encryption.Keyvaultproperties.KeyVersion $null;
        Assert-AreEqual $sto.Encryption.Keyvaultproperties.KeyVaultUri $null;
		
		$sto = Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableEncryptionService File -AssignIdentity
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
		Assert-AreNotEqual $sto.Identity.Type SystemAssigned $null
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true
        Assert-AreEqual $sto.Encryption.KeySource Microsoft.Storage;
        Assert-AreEqual $sto.Encryption.Keyvaultproperties.Keyname $null;
        Assert-AreEqual $sto.Encryption.Keyvaultproperties.KeyVersion $null;
        Assert-AreEqual $sto.Encryption.Keyvaultproperties.KeyVaultUri $null;
		
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; 
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmStorageAccountKey
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokeys = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreNotEqual $stokeys[0].Value $stokeys[1].Value;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmStorageAccountKey
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokey1 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;

        $stokey2 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey1[1].Value $stokey2[1].Value;

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1[0].Value $stokey2[0].Value;
        Assert-AreEqual $stokey2[0].Value $stokey3[0].Value;
        Assert-AreNotEqual $stokey2[1].Value $stokey3[1].Value;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmStorageAccount | Get-AzureRmStorageAccountKey 
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:stokeys = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname | Get-AzureRmStorageAccountKey -ResourceGroupName $rgname; }
        Assert-AreNotEqual $stokeys[0].Value $stokeys[1].Value;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRmStorageAccount | Set-AzureRmCurrentStorageAccount
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname }
		$global:sto | Set-AzureRmCurrentStorageAccount
		$context = Get-AzureRmContext
		$sub = New-Object -TypeName Microsoft.Azure.Commands.Profile.Models.PSAzureSubscription -ArgumentList $context.Subscription
		Assert-AreEqual $stoname $sub.CurrentStorageAccountName
		$global:sto | Remove-AzureRmStorageAccount -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzureRmCurrentStorageAccount with RG and storage account name parameters
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname }
		Set-AzureRmCurrentStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname
		$context = Get-AzureRmContext
		Assert-AreEqual $stoname $context.Subscription.CurrentStorageAccountName
		$global:sto | Remove-AzureRmStorageAccount -Force
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
        $loc = Get-ProviderLocation_Canary  ResourceManagement;
        $ip1 = "20.11.0.0/16";
        $ip2 = "10.0.0.0/7";
        $ip3 = "11.1.1.0/24";
        $ip4 = "28.0.2.0/19";

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
		
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -NetworkRuleSet (@{bypass="Logging,Metrics,AzureServices";
			ipRules=(@{IPAddressOrRange="$ip1";Action="allow"},
            @{IPAddressOrRange="$ip2";Action="allow"});
			defaultAction="Deny"}) 

		$stoacl = (Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname).NetworkRuleSet
        Assert-AreEqual $stoacl.Bypass 7;
        Assert-AreEqual $stoacl.DefaultAction Deny;
        Assert-AreEqual $stoacl.IpRules.Count 2
        Assert-AreEqual $stoacl.IpRules[0].IPAddressOrRange $ip1;
        Assert-AreEqual $stoacl.IpRules[1].IPAddressOrRange $ip2;
        Assert-AreEqual $stoacl.VirtualNetworkRules $null

		Update-AzureRmStorageAccountNetworkRuleSet -verbose -ResourceGroupName $rgname -Name $stoname -Bypass AzureServices,Metrics -DefaultAction Allow -IpRule (@{IPAddressOrRange="$ip3";Action="allow"},@{IPAddressOrRange="$ip4";Action="allow"})
        $stoacl = Get-AzureRmStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
		$stoacliprule = $stoacl.IpRules
        Assert-AreEqual $stoacl.Bypass 6;
        Assert-AreEqual $stoacl.DefaultAction Allow;
        Assert-AreEqual $stoacl.IpRules.Count 2
        Assert-AreEqual $stoacl.IpRules[0].IPAddressOrRange $ip3;
        Assert-AreEqual $stoacl.IpRules[1].IPAddressOrRange $ip4;
        Assert-AreEqual $stoacl.VirtualNetworkRules $null

		$job = Remove-AzureRmStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IPAddressOrRange "$ip3" -AsJob
		$job | Wait-Job
        $stoacl = Get-AzureRmStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $stoacl.Bypass 6;
        Assert-AreEqual $stoacl.DefaultAction Allow;
        Assert-AreEqual $stoacl.IpRules.Count 1
        Assert-AreEqual $stoacl.IpRules[0].IPAddressOrRange $ip4;
        Assert-AreEqual $stoacl.VirtualNetworkRules $null
		
		$job = Update-AzureRmStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname -IpRule @() -DefaultAction Deny -Bypass None -AsJob
		$job | Wait-Job
        $stoacl = Get-AzureRmStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $stoacl.Bypass 0;
        Assert-AreEqual $stoacl.DefaultAction Deny;
        Assert-AreEqual $stoacl.IpRules $null
        Assert-AreEqual $stoacl.VirtualNetworkRules $null
		
		$job = $stoacliprule | Add-AzureRmStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -AsJob
		$job | Wait-Job
        $stoacl = Get-AzureRmStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $stoacl.Bypass 0;
        Assert-AreEqual $stoacl.DefaultAction Deny;
        Assert-AreEqual $stoacl.IpRules.Count 2
        Assert-AreEqual $stoacl.IpRules[0].IPAddressOrRange $ip3;
        Assert-AreEqual $stoacl.IpRules[1].IPAddressOrRange $ip4;
        Assert-AreEqual $stoacl.VirtualNetworkRules $null
		
        $job = Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -AsJob -NetworkRuleSet (@{bypass="AzureServices";
			ipRules=(@{IPAddressOrRange="$ip1";Action="allow"},
            @{IPAddressOrRange="$ip2";Action="allow"});
			defaultAction="Allow"}) 
		$job | Wait-Job

		$stoacl = Get-AzureRmStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $stoacl.Bypass 4;
        Assert-AreEqual $stoacl.DefaultAction Allow;
        Assert-AreEqual $stoacl.IpRules.Count 2
        Assert-AreEqual $stoacl.IpRules[0].IPAddressOrRange $ip1;
        Assert-AreEqual $stoacl.IpRules[1].IPAddressOrRange $ip2;
        Assert-AreEqual $stoacl.VirtualNetworkRules $null

        $job = Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname -AsJob
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

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;        
      				
		$kind = 'StorageV2'
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -UpgradeToStorageV2;
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test NewSetAzureStorageAccount with EncryptionService None
.Description
AzureAutomationTest
#>
function Test-NewAzureStorageAccountEncryptionServiceNone
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
        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableEncryptionService None;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;   
      
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableHttpsTrafficOnly $true -EnableEncryptionService None;
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $true;    
      
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableHttpsTrafficOnly $false -DisableEncryptionService None;
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
        Assert-AreEqual $sto.EnableHttpsTrafficOnly $false;

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}