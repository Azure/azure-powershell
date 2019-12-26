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

        $stotype = 'StandardGRS';
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
        $stotype = 'StandardLRS';
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $accessTier $sto.AccessTier;
    
        $stotype = 'Standard_RAGRS';
        $accessTier = 'Cool'
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -AccessTier $accessTier -Force
        
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $accessTier $sto.AccessTier;

        $stotype = 'Standard_GRS';
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype
        
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardGRS';
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

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardLRS';
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
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'Storage'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype ;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $false $sto.EnableHttpsTrafficOnly;

        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stoname $stos[0].StorageAccountName;
        Assert-AreEqual $stotype $stos[0].Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $stos[0].Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $false $sto.EnableHttpsTrafficOnly;

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
        $kind = 'Storage'

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableHttpsTrafficOnly $true;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;
        
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stoname $stos[0].StorageAccountName;
        Assert-AreEqual $stotype $stos[0].Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $stos[0].Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -EnableHttpsTrafficOnly $false }
        $stotype = 'Standard_RAGRS';
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $false $sto.EnableHttpsTrafficOnly;

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
        $stotype = 'StandardGRS';
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

        New-AzResourceGroup -Name $rgname -Location $loc
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

        New-AzResourceGroup -Name $rgname -Location $loc
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
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -NetworkRuleSet (@{bypass="Logging,Metrics,AzureServices";
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

        Update-AzStorageAccountNetworkRuleSet -verbose -ResourceGroupName $rgname -Name $stoname -Bypass AzureServices,Metrics -DefaultAction Allow -IpRule (@{IPAddressOrRange="$ip3";Action="allow"},@{IPAddressOrRange="$ip4";Action="allow"})
        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
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
        $loc = Get-ProviderLocation ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
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

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
