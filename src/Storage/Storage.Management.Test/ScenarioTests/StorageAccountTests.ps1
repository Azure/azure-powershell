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
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableHttpsTrafficOnly $true  -EnableHierarchicalNamespace $true -PublicNetworkAccess Disabled;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;
        Assert-AreEqual Disabled $sto.PublicNetworkAccess;
        
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stoname $stos[0].StorageAccountName;
        Assert-AreEqual $stotype $stos[0].Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $stos[0].Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHttpsTrafficOnly;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;
        Assert-AreEqual Disabled $sto.PublicNetworkAccess;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -EnableHttpsTrafficOnly $false -PublicNetworkAccess Enabled }
        $stotype = 'Standard_RAGRS';
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;
        Assert-AreEqual Enabled $sto.PublicNetworkAccess;

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $false $sto.EnableHttpsTrafficOnly;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace;
        Assert-AreEqual Enabled $sto.PublicNetworkAccess;

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
        Assert-AreEqual "SystemAssigned" $sto.Identity.Type
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
        $tenanetId = "57F86AF8-9BA8-41AA-B54F-9F73EF8A7C03";
        $resourceId1 = "/subscriptions/2720A159-AF04-4BED-B6FD-EC62CB5A1988/resourceGroups/resourceGroupName/providers/Microsoft.Compute/virtualMachines/VMName1"
        $resourceId2 = "/subscriptions/2720A159-AF04-4BED-B6FD-EC62CB5A1988/resourceGroups/resourceGroupName/providers/Microsoft.Compute/virtualMachines/VMName2"

        New-AzResourceGroup -Name $rgname -Location $loc;
        
        $global:sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -NetworkRuleSet (@{bypass="Logging,Metrics,AzureServices";
            ipRules=(@{IPAddressOrRange="$ip1";Action="allow"},@{IPAddressOrRange="$ip2";Action="allow"});defaultAction="Deny"})

        $stoacl = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname).NetworkRuleSet
        Assert-AreEqual 7 $stoacl.Bypass;
        Assert-AreEqual Deny $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip1 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip2 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count	
        Assert-AreEqual 0 $stoacl.ResourceAccessRules.Count			

        $sto | Update-AzStorageAccountNetworkRuleSet -verbose -Bypass AzureServices,Metrics -DefaultAction Allow -IpRule (@{IPAddressOrRange="$ip3";Action="allow"},@{IPAddressOrRange="$ip4";Action="allow"}) -ResourceAccessRule (@{ResourceId=$resourceId1;TenantId=$tenanetId},@{ResourceId=$resourceId2;TenantId=$tenanetId})
        $stoacl = $sto | Get-AzStorageAccountNetworkRuleSet
        $stoacliprule = $stoacl.IpRules
        $stoaclrcrule = $stoacl.ResourceAccessRules
        Assert-AreEqual 6 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip3 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip4 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        Assert-AreEqual 2 $stoacl.ResourceAccessRules.Count

        $job = Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IPAddressOrRange "$ip3" -AsJob
        $job | Wait-Job
        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 6 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 1 $stoacl.IpRules.Count
        Assert-AreEqual $ip4 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        Assert-AreEqual 2 $stoacl.ResourceAccessRules.Count
        
        Remove-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -TenantId $tenanetId -ResourceId $resourceId2
        $stoacl = $sto | Get-AzStorageAccountNetworkRuleSet
        Assert-AreEqual 6 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 1 $stoacl.IpRules.Count
        Assert-AreEqual $ip4 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        Assert-AreEqual 1 $stoacl.ResourceAccessRules.Count
        Assert-AreEqual $resourceId1 $stoacl.ResourceAccessRules[0].ResourceId
        
        
        $job = Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname -IpRule @() -ResourceAccessRule @() -DefaultAction Deny -Bypass None -AsJob
        $job | Wait-Job
        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 0 $stoacl.Bypass;
        Assert-AreEqual Deny $stoacl.DefaultAction;
        Assert-AreEqual 0 $stoacl.IpRules.Count
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        Assert-AreEqual 0 $stoacl.ResourceAccessRules.Count	
        
        foreach($iprule in $stoacliprule) {
            $job = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IpRule $iprule -AsJob
            $job | Wait-Job
            # add again should not fail
            Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -IpRule $iprule
        }
        
        foreach($rule in $stoaclrcrule) {
            $job = Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -ResourceAccessRule $rule -AsJob
            $job | Wait-Job
            # add again should not fail
            Add-AzStorageAccountNetworkRule -ResourceGroupName $rgname -Name $stoname -ResourceAccessRule $rule
        }

        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 0 $stoacl.Bypass;
        Assert-AreEqual Deny $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip3 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip4 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        Assert-AreEqual 2 $stoacl.ResourceAccessRules.Count	
        
        $job = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -AsJob -NetworkRuleSet (@{bypass="AzureServices";
            ipRules=(@{IPAddressOrRange="$ip1";Action="allow"},@{IPAddressOrRange="$ip2";Action="allow"});
            defaultAction="Allow";
            resourceAccessRules=(@{ResourceId=$resourceId2;TenantId=$tenanetId})}) 
        $job | Wait-Job

        $stoacl = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 4 $stoacl.Bypass;
        Assert-AreEqual Allow $stoacl.DefaultAction;
        Assert-AreEqual 2 $stoacl.IpRules.Count
        Assert-AreEqual $ip1 $stoacl.IpRules[0].IPAddressOrRange;
        Assert-AreEqual $ip2 $stoacl.IpRules[1].IPAddressOrRange;
        Assert-AreEqual 0 $stoacl.VirtualNetworkRules.Count
        Assert-AreEqual 1 $stoacl.ResourceAccessRules.Count
        Assert-AreEqual $resourceId2 $stoacl.ResourceAccessRules[0].ResourceId

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
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -UpgradeToStorageV2 -Force;
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
        $loc = Get-ProviderLocation_Canary ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;

        $global:sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto2 = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname | New-AzStorageAccount -Name $stoname2 -skuName $stotype; }
        Assert-AreEqual $sto.ResourceGroupName $sto2.ResourceGroupName;
        Assert-AreEqual $sto.Location $sto2.Location;
        Assert-AreNotEqual $sto.StorageAccountName $sto2.StorageAccountName;
        
        Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname | set-AzStorageAccount -UpgradeToStorageV2 -Force
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
        
        $sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableAzureActiveDirectoryDomainServicesForFile $true -DefaultSharePermission StorageFileDataSmbShareContributor;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADDS' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 	
        Assert-AreEqual 'StorageFileDataSmbShareContributor' $sto.AzureFilesIdentityBasedAuth.DefaultSharePermission; 	

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADDS' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 
        Assert-AreEqual 'StorageFileDataSmbShareContributor' $sto.AzureFilesIdentityBasedAuth.DefaultSharePermission; 		
        
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableAzureActiveDirectoryDomainServicesForFile $false -DefaultSharePermission StorageFileDataSmbShareReader
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'None' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 
        Assert-AreEqual 'StorageFileDataSmbShareReader' $sto.AzureFilesIdentityBasedAuth.DefaultSharePermission; 

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'None' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 
        Assert-AreEqual 'StorageFileDataSmbShareReader' $sto.AzureFilesIdentityBasedAuth.DefaultSharePermission; 
        
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
        $stoname2 = 'stohotsdfrew' + $rgname
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $loc2 = 'eastus2'
        $kind = 'StorageV2'

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname2 -Location $loc2 -Kind "BlockBlobStorage" -SkuName "Premium_LRS"
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;        
                    
        # create Rule1
        $action1 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -DaysAfterCreationGreaterThan 100
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToArchive -daysAfterModificationGreaterThan 50 -DaysAfterLastTierChangeGreaterThan 40
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToCool -daysAfterModificationGreaterThan 30
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -BaseBlobAction TierToCold -DaysAfterModificationGreaterThan 100
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction Delete -daysAfterCreationGreaterThan 100
        $action1 = Add-AzStorageAccountManagementPolicyAction -InputObject $action1 -SnapshotAction TierToCold -daysAfterCreationGreaterThan 50 
        $filter1 = New-AzStorageAccountManagementPolicyFilter -PrefixMatch ab,cd
        $rule1 = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action1 -Filter $filter1

        # create Rule2
        $action2 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
        $blobindexmatch1 = New-AzStorageAccountManagementPolicyBlobIndexMatchObject -Name "tag1" -Value "value1"
        $blobindexmatch2 = New-AzStorageAccountManagementPolicyBlobIndexMatchObject -Name "tag2" -Value "value2"
        $filter2 = New-AzStorageAccountManagementPolicyFilter -BlobType appendBlob,blockBlob -BlobIndexMatch $blobindexmatch1,$blobindexmatch2
        $rule2 = New-AzStorageAccountManagementPolicyRule -Name Test2 -Action $action2 -Filter $filter2 -Disabled
        
        # create Rule3
        $action3 = Add-AzStorageAccountManagementPolicyAction -BlobVersionAction Delete -DaysAfterCreationGreaterThan 30
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -BlobVersionAction TierToCool -DaysAfterCreationGreaterThan 40
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -BlobVersionAction TierToArchive -DaysAfterCreationGreaterThan 50 -DaysAfterLastTierChangeGreaterThan 20
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -BlobVersionAction TierToCold -DaysAfterCreationGreaterThan 100
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -SnapshotAction TierToCool -daysAfterCreationGreaterThan 60
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -SnapshotAction TierToArchive -daysAfterCreationGreaterThan 60 -DaysAfterLastTierChangeGreaterThan 30
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -SnapshotAction Delete -daysAfterCreationGreaterThan 80
        $action3 = Add-AzStorageAccountManagementPolicyAction -InputObject $action3 -SnapshotAction TierToCold -daysAfterCreationGreaterThan 100
        $filter3 = New-AzStorageAccountManagementPolicyFilter 
        $rule3 = New-AzStorageAccountManagementPolicyRule -Name Test3 -Action $action3 -Filter $filter3

        # Set policy 
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -Rule $rule1,$rule2,$rule3
        Assert-AreEqual 3 $policy.Rules.Count
        Assert-AreEqual $rule1.Enabled $policy.Rules[0].Enabled
        Assert-AreEqual $rule1.Name $policy.Rules[0].Name
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCold.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCold.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan
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
        Assert-AreEqual $rule2.Definition.Filters.BlobTypes[1] $policy.Rules[1].Definition.Filters.BlobTypes[1]
        Assert-AreEqual $rule2.Definition.Filters.PrefixMatch $policy.Rules[1].Definition.Filters.PrefixMatch
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[0].Name $policy.Rules[1].Definition.Filters.BlobIndexMatch[0].Name
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[0].Value $policy.Rules[1].Definition.Filters.BlobIndexMatch[0].Value
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[1].Name $policy.Rules[1].Definition.Filters.BlobIndexMatch[1].Name
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[1].Value $policy.Rules[1].Definition.Filters.BlobIndexMatch[1].Value
        Assert-AreEqual $rule3.Enabled $policy.Rules[2].Enabled
        Assert-AreEqual $rule3.Name $policy.Rules[2].Name
        Assert-AreEqual $rule3.Definition.Actions.BaseBlob $policy.Rules[2].Definition.Actions.BaseBlob
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToCold.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Filters.BlobTypes[0] $policy.Rules[2].Definition.Filters.BlobTypes[0]
        Assert-AreEqual $rule3.Definition.Filters.PrefixMatch $policy.Rules[2].Definition.Filters.PrefixMatch
        
        $policy = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname
        Assert-AreEqual 3 $policy.Rules.Count
        Assert-AreEqual $rule1.Enabled $policy.Rules[0].Enabled
        Assert-AreEqual $rule1.Name $policy.Rules[0].Name
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCold.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCold.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan
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
        Assert-AreEqual $rule2.Definition.Filters.BlobTypes[1] $policy.Rules[1].Definition.Filters.BlobTypes[1]
        Assert-AreEqual $rule2.Definition.Filters.PrefixMatch $policy.Rules[1].Definition.Filters.PrefixMatch
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[0].Name $policy.Rules[1].Definition.Filters.BlobIndexMatch[0].Name
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[0].Value $policy.Rules[1].Definition.Filters.BlobIndexMatch[0].Value
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[1].Name $policy.Rules[1].Definition.Filters.BlobIndexMatch[1].Name
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[1].Value $policy.Rules[1].Definition.Filters.BlobIndexMatch[1].Value
        Assert-AreEqual $rule3.Enabled $policy.Rules[2].Enabled
        Assert-AreEqual $rule3.Name $policy.Rules[2].Name
        Assert-AreEqual $rule3.Definition.Actions.BaseBlob $policy.Rules[2].Definition.Actions.BaseBlob
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToCold.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Filters.BlobTypes[0] $policy.Rules[2].Definition.Filters.BlobTypes[0]
        Assert-AreEqual $rule3.Definition.Filters.PrefixMatch $policy.Rules[2].Definition.Filters.PrefixMatch

        Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname	
        
        $policy| Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname 

        $policy = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname	
        Assert-AreEqual 3 $policy.Rules.Count
        Assert-AreEqual $rule1.Enabled $policy.Rules[0].Enabled
        Assert-AreEqual $rule1.Name $policy.Rules[0].Name
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCold.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCold.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule1.Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan
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
        Assert-AreEqual $rule2.Definition.Filters.BlobTypes[1] $policy.Rules[1].Definition.Filters.BlobTypes[1]
        Assert-AreEqual $rule2.Definition.Filters.PrefixMatch $policy.Rules[1].Definition.Filters.PrefixMatch
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[0].Name $policy.Rules[1].Definition.Filters.BlobIndexMatch[0].Name
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[0].Value $policy.Rules[1].Definition.Filters.BlobIndexMatch[0].Value
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[1].Name $policy.Rules[1].Definition.Filters.BlobIndexMatch[1].Name
        Assert-AreEqual $rule2.Definition.Filters.BlobIndexMatch[1].Value $policy.Rules[1].Definition.Filters.BlobIndexMatch[1].Value
        Assert-AreEqual $rule3.Enabled $policy.Rules[2].Enabled
        Assert-AreEqual $rule3.Name $policy.Rules[2].Name
        Assert-AreEqual $rule3.Definition.Actions.BaseBlob $policy.Rules[2].Definition.Actions.BaseBlob
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToArchive.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.Delete.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToCool.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterLastTierChangeGreaterThan
        Assert-AreEqual $rule3.Definition.Actions.Version.TierToCold.DaysAfterCreationGreaterThan $policy.Rules[2].Definition.Actions.Version.TierToCold.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule3.Definition.Filters.BlobTypes[0] $policy.Rules[2].Definition.Filters.BlobTypes[0]
        Assert-AreEqual $rule3.Definition.Filters.PrefixMatch $policy.Rules[2].Definition.Filters.PrefixMatch

        $policy| Remove-AzStorageAccountManagementPolicy
        
        $action4 = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToHot -daysAfterModificationGreaterThan 100
        $action4 = Add-AzStorageAccountManagementPolicyAction -InputObject $action4 -BaseBlobAction TierToHot -DaysAfterCreationGreaterThan 50
        $action4 = Add-AzStorageAccountManagementPolicyAction -InputObject $action4 -SnapshotAction Delete -DaysAfterCreationGreaterThan 100
        $filter4 = New-AzStorageAccountManagementPolicyFilter -PrefixMatch prefix1,prefix2
        $rule4 = New-AzStorageAccountManagementPolicyRule -Name Test4 -Action $action4 -Filter $filter4

        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2 -Rule $rule4
        Assert-AreEqual 1 $policy.Rules.Count
        Assert-AreEqual $rule4.Enabled $policy.Rules[0].Enabled 
        Assert-AreEqual $rule4.Name $policy.Rules[0].Name
        Assert-AreEqual $rule4.Definition.Filters.PrefixMatch[0] $policy.Rules[0].Definition.Filters.PrefixMatch[0]
        Assert-AreEqual $rule4.Definition.Filters.PrefixMatch[1] $policy.Rules[0].Definition.Filters.PrefixMatch[1]	
        Assert-AreEqual $rule4.Definition.Actions.BaseBlob.TierToHot.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToHot.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule4.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        
        $policy = Get-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2
        Assert-AreEqual 1 $policy.Rules.Count
        Assert-AreEqual $rule4.Enabled $policy.Rules[0].Enabled 
        Assert-AreEqual $rule4.Name $policy.Rules[0].Name
        Assert-AreEqual $rule4.Definition.Filters.PrefixMatch[0] $policy.Rules[0].Definition.Filters.PrefixMatch[0]
        Assert-AreEqual $rule4.Definition.Filters.PrefixMatch[1] $policy.Rules[0].Definition.Filters.PrefixMatch[1]	
        Assert-AreEqual $rule4.Definition.Actions.BaseBlob.TierToHot.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.BaseBlob.TierToHot.DaysAfterCreationGreaterThan
        Assert-AreEqual $rule4.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan $policy.Rules[0].Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan
        
        $policy| Remove-AzStorageAccountManagementPolicy
        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname2;
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
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableLargeFileShare -SkuName $stotype -UpgradeToStorageV2 -Force;
        
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
Test Test-NewSetAzureStorageAccount_AllowSharedKeyAccess
.DESCRIPTION
SmokeTest
#>
function Test-NewSetAzureStorageAccountAllowSharedKeyAccess
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
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -AllowSharedKeyAccess $false ;

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $false $sto.AllowSharedKeyAccess

        # validate the storage account Context is Oauth based
        Assert-AreEqual $false $sto.Context.StorageAccount.Credentials.IsSharedKey
        Assert-AreEqual $true $sto.Context.StorageAccount.Credentials.IsToken
        Assert-AreNotEqual $null $sto.Context.Track2OauthToken 
        
        #Update account
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -AllowSharedKeyAccess $true -EnableHttpsTrafficOnly $true 
        
        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.AllowSharedKeyAccess

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

<#
.SYNOPSIS
Test Test-NewAzureStorageAccountEdgeZone
.DESCRIPTION
SmokeTest
#>
function Test-NewAzureStorageAccountEdgeZone
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
        
        # new account
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -EdgeZone "microsoftlosangeles1"

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual "EdgeZone" $sto.ExtendedLocation.Type;
        Assert-AreEqual "microsoftlosangeles1" $sto.ExtendedLocation.Name;

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
Test Test-AzureStorageAccountKeySASPolicy
.DESCRIPTION
SmokeTest
#>
function Test-AzureStorageAccountKeySASPolicy
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
        $keyExpirationPeriodInDay = 5
        $sasExpirationPeriod = "1.12:05:06"

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
        
        # new account
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -KeyExpirationPeriodInDay $keyExpirationPeriodInDay -SasExpirationPeriod $sasExpirationPeriod

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $keyExpirationPeriodInDay $sto.KeyPolicy.KeyExpirationPeriodInDays;
        Assert-AreEqual $sasExpirationPeriod $sto.SasPolicy.SasExpirationPeriod;
        Assert-NotNull $sto.KeyCreationTime.Key1
        Assert-NotNull $sto.KeyCreationTime.Key2

        # update account		
        $keyExpirationPeriodInDay = 3
        $sasExpirationPeriod = "50.00:00:00"
        Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -KeyExpirationPeriodInDay $keyExpirationPeriodInDay -SasExpirationPeriod $sasExpirationPeriod -EnableHttpsTrafficOnly $true

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $keyExpirationPeriodInDay $sto.KeyPolicy.KeyExpirationPeriodInDays;
        Assert-AreEqual $sasExpirationPeriod $sto.SasPolicy.SasExpirationPeriod;
        Assert-NotNull $sto.KeyCreationTime.Key1
        Assert-NotNull $sto.KeyCreationTime.Key2

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
Test Test-NewAzureStorageAccountUserAssignedIdentity
.DESCRIPTION
SmokeTest
#>
function Test-AzureStorageAccountUserAssignedIdentity
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")

        # create keyvault and user assigned idenity
        $keyvaultName = "weiestestcanary"
        $keyvaultUri = "https://$($keyvaultName).vault.azure.net:443"
        $keyname = "wrappingKey"
        $useridentity= "/subscriptions/45b60d85-fd72-427a-a708-f994d26e593e/resourceGroups/weitry/providers/Microsoft.ManagedIdentity/userAssignedIdentities/weitestid1"
        $useridentity2= "/subscriptions/45b60d85-fd72-427a-a708-f994d26e593e/resourceGroups/weitry/providers/Microsoft.ManagedIdentity/userAssignedIdentities/weitestid2"

        # $keyVault = New-AzKeyVault -VaultName $keyvaultName -ResourceGroupName $rgname -Location $loc -EnablePurgeProtection
        # Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgname -ObjectId $servicePricipleObjectId -PermissionsToKeys backup,create,delete,get,import,get,list,update,restore 
        # $key = Add-AzKeyVaultKey -VaultName $keyvaultName -Name $keyname -Destination 'Software'    

        # $userId = New-AzUserAssignedIdentity -ResourceGroupName $rgname -Name $rgname+"userid"
        # Set-AzKeyVaultAccessPolicy -VaultName $keyvaultName -ResourceGroupName $rgname -ObjectId $userId.PrincipalId -PermissionsToKeys get,wrapkey,unwrapkey -BypassObjectIdValidation
        # $useridentity= $userId.Id
        
        # new account with keyvault encryption + UserAssignedIdentity
        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -SkuName $stotype -Location $loc `
                    -UserAssignedIdentityId $useridentity  -IdentityType SystemAssignedUserAssigned  `
                    -KeyName $keyname -KeyVaultUri $keyvaultUri -KeyVaultUserAssignedIdentityId $useridentity

        Assert-AreEqual "SystemAssigned,UserAssigned" $account.Identity.Type 
        Assert-AreEqual Microsoft.Keyvault $account.Encryption.KeySource
        Assert-AreEqual  $useridentity $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity 
        Assert-AreEqual  $keyvaultUri $account.Encryption.KeyVaultProperties.KeyVaultUri 
        Assert-AreEqual  $keyname $account.Encryption.KeyVaultProperties.KeyName 

        # update UserAssignedIdentity to another
        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname `
                    -IdentityType UserAssigned -UserAssignedIdentityId $useridentity2 `
                    -KeyVaultUserAssignedIdentityId $useridentity2  -KeyName $keyname -KeyVaultUri $keyvaultUri

        Assert-AreEqual "UserAssigned" $account.Identity.Type 
        Assert-AreEqual Microsoft.Keyvault $account.Encryption.KeySource
        Assert-AreEqual  $useridentity2 $account.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity 
        Assert-AreEqual  $keyvaultUri $account.Encryption.KeyVaultProperties.KeyVaultUri 
        Assert-AreEqual  $keyname $account.Encryption.KeyVaultProperties.KeyName 

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
Test Test-StorageBlobInventory
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobInventory
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
        $containerName = "container"+ $rgname

        New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
        
        # new account and container, enable versioning
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype 
        New-AzRmStorageContainer -ResourceGroupName $rgname  -StorageAccountName $stoname  -Name $containerName
        Update-AzStorageBlobServiceProperty  -ResourceGroupName $rgname  -StorageAccountName $stoname -IsVersioningEnabled $true

        #create rule objects
        $rule1 = New-AzStorageBlobInventoryPolicyRule -Name test1 -Disabled -BlobType blockBlob,appendBlob -PrefixMatch abc,edf,eqwewqe,eqwewqreewqe,qwewqewqewqewqewadasd -IncludeSnapshot -IncludeBlobVersion `
                    -Destination $containerName -Format Parquet -Schedule Weekly `
                    -BlobSchemaField name,Creation-Time,Last-Modified,Content-Length,Content-MD5,BlobType,AccessTier,AccessTierChangeTime,Metadata,AccessTierInferred,Tags -CreationTimeLastNDay 3
        $rule2 = New-AzStorageBlobInventoryPolicyRule -Name test2 -Destination $containerName -Disabled -Format Csv -Schedule Daily -ContainerSchemaField Name,Metadata,PublicAccess,Last-mOdified,LeaseStatus,LeaseState,LeaseDuration,HasImmutabilityPolicy,HasLegalHold,Etag,DefaultEncryptionScope,DenyEncryptionScopeOverride -PrefixMatch con1,con2
        $rule3 = New-AzStorageBlobInventoryPolicyRule -Name test3 -Destination $containerName -BlobType appendBlob -PrefixMatch abc1,edf1 -ExcludePrefix aaa1,bbb1  -Format Csv -Schedule Weekly -BlobSchemaField Name,Deleted,RemainingRetentionDays,Content-Type,Content-Language,Cache-Control,Content-Disposition -IncludeDeleted

        # Set inventory policy
        $policy1 = Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname  -Disabled -Rule $rule1,$rule2,$rule3
        Assert-AreEqual $false $policy1.Enabled
        Assert-AreEqual 3 $policy1.Rules.Count

        # get inventory policy 
        $policy1 = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname
        Assert-AreEqual $false $policy1.Enabled
        Assert-AreEqual 3 $policy1.Rules.Count
        Assert-AreEqual "test1" $policy1.Rules[0].Name
        Assert-AreEqual $false $policy1.Rules[0].Enabled
        Assert-AreEqual $containerName $policy1.Rules[0].Destination
        Assert-AreEqual "Parquet" $policy1.Rules[0].Definition.Format
        Assert-AreEqual "Weekly" $policy1.Rules[0].Definition.Schedule
        Assert-AreEqual "Blob" $policy1.Rules[0].Definition.ObjectType
        Assert-AreEqual 14 $policy1.Rules[0].Definition.SchemaFields.Count
        Assert-AreEqual $true $policy1.Rules[0].Definition.Filters.IncludeSnapshots
        Assert-AreEqual $true $policy1.Rules[0].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy1.Rules[0].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy1.Rules[0].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 5 $policy1.Rules[0].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual 3 $policy1.Rules[0].Definition.Filters.CreationTime.LastNDays
        Assert-AreEqual "test2" $policy1.Rules[1].Name
        Assert-AreEqual $false $policy1.Rules[1].Enabled
        Assert-AreEqual $containerName $policy1.Rules[1].Destination
        Assert-AreEqual "Csv" $policy1.Rules[1].Definition.Format
        Assert-AreEqual "Daily" $policy1.Rules[1].Definition.Schedule
        Assert-AreEqual "Container" $policy1.Rules[1].Definition.ObjectType
        Assert-AreEqual 12 $policy1.Rules[1].Definition.SchemaFields.Count
        Assert-Null $policy1.Rules[1].Definition.Filters.IncludeSnapshots
        Assert-Null $policy1.Rules[1].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy1.Rules[1].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy1.Rules[1].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "test3" $policy1.Rules[2].Name
        Assert-AreEqual $true $policy1.Rules[2].Enabled
        Assert-AreEqual $containerName $policy1.Rules[2].Destination
        Assert-AreEqual "Csv" $policy1.Rules[2].Definition.Format
        Assert-AreEqual "Weekly" $policy1.Rules[2].Definition.Schedule
        Assert-AreEqual "Blob" $policy1.Rules[2].Definition.ObjectType
        Assert-AreEqual 7 $policy1.Rules[2].Definition.SchemaFields.Count
        Assert-Null $policy1.Rules[2].Definition.Filters.IncludeSnapshots
        Assert-Null $policy1.Rules[2].Definition.Filters.IncludeBlobVersions
        Assert-AreEqual $true $policy1.Rules[2].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy1.Rules[2].Definition.Filters.ExcludePrefix.Count
        Assert-AreEqual 1 $policy1.Rules[2].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 2 $policy1.Rules[2].Definition.Filters.PrefixMatch.Count

        # set policy with json and account name pipeline
        $policy2 = Get-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $stoname |  Set-AzStorageBlobInventoryPolicy -Policy (@{
                Enabled=$true;
                Rules=(@{
                    Enabled=$true;
                    Name="Test1";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Blob";
                        Format="Csv";
                        Schedule="Weekly";
                        SchemaFields=@("name","Content-Length","BlobType","Snapshot","VersionId","IsCurrentVersion");
                        Filters=(@{
                            BlobTypes=@("blockBlob","appendBlob");
                            PrefixMatch=@("prefix1","prefix2");
                            IncludeSnapshots=$true;
                            IncludeBlobVersions=$true;
                        })
                    })
                },
                @{
                    Enabled=$false;
                    Name="Test2";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Container";
                        Format="Parquet";
                        Schedule="Daily";
                        SchemaFields=@("name","Metadata","PublicAccess","DefaultEncryptionScope","DenyEncryptionScopeOverride");
                        Filters=(@{
                            PrefixMatch=@("conpre1","conpre2");
                            ExcludePrefix=@("expre1","expre2");
                        })
                    })
                },
                @{
                    Enabled=$false;
                    Name="Test3";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Blob";
                        Format="Csv";
                        Schedule="Weekly";
                        SchemaFields=@("name","Deleted","RemainingRetentionDays","Content-Type","Content-Language","Cache-Control","Content-Disposition");
                        Filters=(@{
                            BlobTypes=@("blockBlob","appendBlob");
                            PrefixMatch=@("conpre1","conpre2");
                            ExcludePrefix=@("expre1","expre2");
                            IncludeDeleted=$true
                        })
                    })
                })
            })
        Assert-AreEqual $true $policy2.Enabled
        Assert-AreEqual 3 $policy2.Rules.Count

        # get inventory policy 
        $policy2 = Get-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $stoname | Get-AzStorageBlobInventoryPolicy 
        Assert-AreEqual $true $policy2.Enabled
        Assert-AreEqual 3 $policy2.Rules.Count
        Assert-AreEqual "Test1" $policy2.Rules[0].Name
        Assert-AreEqual $true $policy2.Rules[0].Enabled
        Assert-AreEqual $containerName $policy2.Rules[0].Destination
        Assert-AreEqual "Csv" $policy2.Rules[0].Definition.Format
        Assert-AreEqual "Weekly" $policy2.Rules[0].Definition.Schedule
        Assert-AreEqual "Blob" $policy2.Rules[0].Definition.ObjectType
        Assert-AreEqual 6 $policy2.Rules[0].Definition.SchemaFields.Count
        Assert-AreEqual $true $policy2.Rules[0].Definition.Filters.IncludeSnapshots
        Assert-AreEqual $true $policy2.Rules[0].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy2.Rules[0].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy2.Rules[0].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 2 $policy2.Rules[0].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "Test2" $policy2.Rules[1].Name
        Assert-AreEqual $false $policy2.Rules[1].Enabled
        Assert-AreEqual $containerName $policy2.Rules[1].Destination
        Assert-AreEqual "Parquet" $policy2.Rules[1].Definition.Format
        Assert-AreEqual "Daily" $policy2.Rules[1].Definition.Schedule
        Assert-AreEqual "Container" $policy2.Rules[1].Definition.ObjectType
        Assert-AreEqual 5 $policy2.Rules[1].Definition.SchemaFields.Count
        Assert-Null $policy2.Rules[1].Definition.Filters.IncludeSnapshots
        Assert-Null $policy2.Rules[1].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy2.Rules[1].Definition.Filters.IncludeDeleted
        Assert-Null $policy2.Rules[1].Definition.Filters.BlobTypes
        Assert-AreEqual 2 $policy2.Rules[1].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "Test3" $policy2.Rules[2].Name
        Assert-AreEqual $false $policy2.Rules[2].Enabled
        Assert-AreEqual $containerName $policy2.Rules[2].Destination
        Assert-AreEqual "Csv" $policy2.Rules[2].Definition.Format
        Assert-AreEqual "Weekly" $policy2.Rules[2].Definition.Schedule
        Assert-AreEqual "Blob" $policy2.Rules[2].Definition.ObjectType
        Assert-AreEqual 7 $policy2.Rules[2].Definition.SchemaFields.Count
        Assert-Null $policy2.Rules[2].Definition.Filters.IncludeSnapshots
        Assert-Null $policy2.Rules[2].Definition.Filters.IncludeBlobVersions
        Assert-AreEqual $true $policy2.Rules[2].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy2.Rules[2].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 2 $policy2.Rules[2].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual 2 $policy2.Rules[2].Definition.Filters.ExcludePrefix.Count

        # remove policy 
        Get-AzStorageAccount -ResourceGroupName $rgname  -StorageAccountName $stoname | Remove-AzStorageBlobInventoryPolicy 

        # set policy by pipeline policy then get inventory policy 
        $policy3 = $policy1 | Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname 
        $policy3 = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname
        Assert-AreEqual $false $policy3.Enabled
        Assert-AreEqual 3 $policy3.Rules.Count
        Assert-AreEqual "test1" $policy3.Rules[0].Name
        Assert-AreEqual $false $policy3.Rules[0].Enabled
        Assert-AreEqual $containerName $policy3.Rules[0].Destination
        Assert-AreEqual "Parquet" $policy3.Rules[0].Definition.Format
        Assert-AreEqual "Weekly" $policy3.Rules[0].Definition.Schedule
        Assert-AreEqual "Blob" $policy3.Rules[0].Definition.ObjectType
        Assert-AreEqual 14 $policy3.Rules[0].Definition.SchemaFields.Count
        Assert-AreEqual $true $policy3.Rules[0].Definition.Filters.IncludeSnapshots
        Assert-AreEqual $true $policy3.Rules[0].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy3.Rules[0].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy3.Rules[0].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 5 $policy3.Rules[0].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "test2" $policy3.Rules[1].Name
        Assert-AreEqual $false $policy3.Rules[1].Enabled
        Assert-AreEqual $containerName $policy3.Rules[1].Destination
        Assert-AreEqual "Csv" $policy3.Rules[1].Definition.Format
        Assert-AreEqual "Daily" $policy3.Rules[1].Definition.Schedule
        Assert-AreEqual "Container" $policy3.Rules[1].Definition.ObjectType
        Assert-AreEqual 12 $policy3.Rules[1].Definition.SchemaFields.Count
        Assert-Null $policy3.Rules[1].Definition.Filters.IncludeSnapshots
        Assert-Null $policy3.Rules[1].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy3.Rules[1].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy3.Rules[1].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "test3" $policy3.Rules[2].Name
        Assert-AreEqual $true $policy3.Rules[2].Enabled
        Assert-AreEqual $containerName $policy3.Rules[2].Destination
        Assert-AreEqual "Csv" $policy3.Rules[2].Definition.Format
        Assert-AreEqual "Weekly" $policy3.Rules[2].Definition.Schedule
        Assert-AreEqual "Blob" $policy3.Rules[2].Definition.ObjectType
        Assert-AreEqual 7 $policy3.Rules[2].Definition.SchemaFields.Count
        Assert-Null $policy3.Rules[2].Definition.Filters.IncludeSnapshots
        Assert-Null $policy3.Rules[2].Definition.Filters.IncludeBlobVersions
        Assert-AreEqual $true $policy3.Rules[2].Definition.Filters.IncludeDeleted
        Assert-AreEqual 1 $policy3.Rules[2].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 2 $policy3.Rules[2].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual 2 $policy3.Rules[2].Definition.Filters.ExcludePrefix.Count

        # set policy by pipeline policy rules then get inventory policy 
        $policy4 = ,($policy2.Rules) | Set-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname -Disabled
        $policy4 = Get-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname	
        Assert-AreEqual $false $policy4.Enabled
        Assert-AreEqual 3 $policy4.Rules.Count
        Assert-AreEqual "Test1" $policy4.Rules[0].Name
        Assert-AreEqual $true $policy4.Rules[0].Enabled
        Assert-AreEqual $containerName $policy4.Rules[0].Destination
        Assert-AreEqual "Csv" $policy4.Rules[0].Definition.Format
        Assert-AreEqual "Weekly" $policy4.Rules[0].Definition.Schedule
        Assert-AreEqual "Blob" $policy4.Rules[0].Definition.ObjectType
        Assert-AreEqual 6 $policy4.Rules[0].Definition.SchemaFields.Count
        Assert-AreEqual $true $policy4.Rules[0].Definition.Filters.IncludeSnapshots
        Assert-AreEqual $true $policy4.Rules[0].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy4.Rules[0].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy4.Rules[0].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 2 $policy4.Rules[0].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "Test2" $policy4.Rules[1].Name
        Assert-AreEqual $false $policy4.Rules[1].Enabled
        Assert-AreEqual $containerName $policy4.Rules[1].Destination
        Assert-AreEqual "Parquet" $policy4.Rules[1].Definition.Format
        Assert-AreEqual "Daily" $policy4.Rules[1].Definition.Schedule
        Assert-AreEqual "Container" $policy4.Rules[1].Definition.ObjectType
        Assert-AreEqual 5 $policy4.Rules[1].Definition.SchemaFields.Count
        Assert-Null $policy4.Rules[1].Definition.Filters.IncludeSnapshots
        Assert-Null $policy4.Rules[1].Definition.Filters.IncludeBlobVersions
        Assert-Null $policy4.Rules[1].Definition.Filters.IncludeDeleted
        Assert-Null $policy4.Rules[1].Definition.Filters.BlobTypes
        Assert-AreEqual 2 $policy4.Rules[1].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual "Test3" $policy4.Rules[2].Name
        Assert-AreEqual $false $policy4.Rules[2].Enabled
        Assert-AreEqual $containerName $policy4.Rules[2].Destination
        Assert-AreEqual "Csv" $policy4.Rules[2].Definition.Format
        Assert-AreEqual "Weekly" $policy4.Rules[2].Definition.Schedule
        Assert-AreEqual "Blob" $policy4.Rules[2].Definition.ObjectType
        Assert-AreEqual 7 $policy4.Rules[2].Definition.SchemaFields.Count
        Assert-Null $policy4.Rules[2].Definition.Filters.IncludeSnapshots
        Assert-Null $policy4.Rules[2].Definition.Filters.IncludeBlobVersions
        Assert-AreEqual $true $policy4.Rules[2].Definition.Filters.IncludeDeleted
        Assert-AreEqual 2 $policy4.Rules[2].Definition.Filters.BlobTypes.Count
        Assert-AreEqual 2 $policy4.Rules[2].Definition.Filters.PrefixMatch.Count
        Assert-AreEqual 2 $policy4.Rules[2].Definition.Filters.ExcludePrefix.Count

        # remove policy 
        Remove-AzStorageBlobInventoryPolicy -ResourceGroupName $rgname  -StorageAccountName $stoname

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
Test Test-NewAzureStorageAccountEnableNfsV3
.DESCRIPTION
SmokeTest
#>
function Test-NewAzureStorageAccountEnableNfsV3
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

        $rg = New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
        
        ## Create a vnet and subnet in same location, then get the subnet resource id
        # New-AzVirtualNetwork -ResourceGroupName $rgname -Location $loc -AddressPrefix 10.0.0.0/24 -Name "vnet1" 
        # $subnet = Get-AzVirtualNetwork -ResourceGroupName $rgname -Name "vnet1" | Add-AzVirtualNetworkSubnetConfig -Name "subnet1" -AddressPrefix "10.0.0.0/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzVirtualNetwork 
        # $vnet1 = $subnet.Id
        $vnet1 = "$($rg.ResourceId)/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1"
        
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype `
                -EnableNfsV3 $true `
                -EnableHierarchicalNamespace $true `
                -EnableHttpsTrafficOnly $false `
                -NetworkRuleSet (@{bypass="Logging,Metrics";defaultAction="deny";virtualNetworkRules=(@{VirtualNetworkResourceId="$vnet1";Action="allow"})}) 

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace
        Assert-AreEqual $false $sto.EnableHttpsTrafficOnly
        Assert-AreEqual $true $sto.EnableNfsV3

        # valid create container with NFSv3 properties		
        $containerName = "container"+ $rgname
        $con = New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -RootSquash RootSquash
        Assert-AreEqual $false $con.EnableNfsV3AllSquash
        Assert-AreEqual $true $con.EnableNfsV3RootSquash
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -RootSquash NoRootSquash
        Assert-AreEqual $false $con.EnableNfsV3AllSquash
        Assert-AreEqual $false $con.EnableNfsV3RootSquash
        $con = Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -RootSquash AllSquash
        Assert-AreEqual $true $con.EnableNfsV3AllSquash
        Assert-AreEqual $false $con.EnableNfsV3RootSquash

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
Test Test-AzureStorageAccountHierarchicalNamespaceUpgrade
.DESCRIPTION
SmokeTest
#>
function Test-AzureStorageAccountHierarchicalNamespaceUpgrade
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

        $rg = New-AzResourceGroup -Name $rgname -Location $loc;
        Write-Output ("Resource Group created")
        
        # Create Storage account
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype 

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $null $sto.EnableHierarchicalNamespace

        # HierarchicalNamespace upgrade validation and execute upgrade
        Invoke-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $stoname -RequestType Validation		
        $task = Invoke-AzStorageAccountHierarchicalNamespaceUpgrade -ResourceGroupName $rgname -Name $stoname -RequestType Upgrade -Force -AsJob
        $task | Wait-Job

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $true $sto.EnableHierarchicalNamespace

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
Test AzureStorageAccountWorm
.DESCRIPTION
SmokeTest
#>
function Test-AzureStorageAccountWorm
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
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableAccountLevelImmutability -ImmutabilityPeriod 1 -ImmutabilityPolicyState Disabled 

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.ImmutableStorageWithVersioning.Enabled;
        Assert-AreEqual 1 $sto.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays;
        Assert-AreEqual Disabled $sto.ImmutableStorageWithVersioning.ImmutabilityPolicy.State;
        
        Retry-IfException { $global:sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -ImmutabilityPeriod 2 -ImmutabilityPolicyState Unlocked  }
        Assert-AreEqual $true $sto.ImmutableStorageWithVersioning.Enabled;
        Assert-AreEqual 2 $sto.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays;
        Assert-AreEqual Unlocked $sto.ImmutableStorageWithVersioning.ImmutabilityPolicy.State;
        
        Retry-IfException { $global:sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -ImmutabilityPolicyState Locked }
        Assert-AreEqual $true $sto.ImmutableStorageWithVersioning.Enabled;
        Assert-AreEqual 2 $sto.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays;
        Assert-AreEqual Locked $sto.ImmutableStorageWithVersioning.ImmutabilityPolicy.State;
        
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
Test Test-NewAzStorageContext
.DESCRIPTION
SmokeTest
#>
function Test-NewAzStorageContext
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
        $blobEndpoint = $sto.PrimaryEndpoints.Blob
        $tableEndpoint = $sto.PrimaryEndpoints.Table
        $queueEndpoint = $sto.PrimaryEndpoints.Queue
        $fileEndpoint = $sto.PrimaryEndpoints.File
        Assert-AreEqual $stoname $sto.StorageAccountName;

        $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -StorageAccountName $sto.StorageAccountName)[0].Value
        $ctxAccountInfo = New-AzStorageContext -StorageAccountName $sto.StorageAccountName -StorageAccountKey $stokey
        Assert-AreEqual $ctxAccountInfo.BlobEndpoint $blobEndpoint
        Assert-AreEqual $ctxAccountInfo.TableEndpoint $tableEndpoint
        Assert-AreEqual $ctxAccountInfo.QueueEndpoint $queueEndpoint 
        Assert-AreEqual $ctxAccountInfo.FileEndpoint $fileEndpoint

        $ctxAccountInfoServiceEndpoint = New-AzStorageContext -StorageAccountName $sto.StorageAccountName -StorageAccountKey $stokey -BlobEndpoint $blobEndpoint -TableEndpoint $tableEndpoint
        Assert-AreEqual $ctxAccountInfoServiceEndpoint.BlobEndpoint $blobEndpoint
        Assert-AreEqual $ctxAccountInfoServiceEndpoint.TableEndpoint $tableEndpoint
        Assert-Null $ctxAccountInfoServiceEndpoint.QueueEndpoint 
        Assert-Null $ctxAccountInfoServiceEndpoint.FileEndpoint

        $ctxAnonymousServiceEndpoint = New-AzStorageContext -Anonymous -QueueEndpoint $queueEndpoint -FileEndpoint $fileEndpoint
        Assert-AreEqual $ctxAnonymousServiceEndpoint.QueueEndpoint $queueEndpoint
        Assert-AreEqual $ctxAnonymousServiceEndpoint.FileEndpoint $fileEndpoint
        Assert-Null $ctxAnonymousServiceEndpoint.BlobEndpoint
        Assert-Null $ctxAnonymousServiceEndpoint.TableEndpoint
        Assert-AreEqual $ctxAnonymousServiceEndpoint.StorageAccountName "[Anonymous]"

        $ctxOAuthServiceEndpoint = New-AzStorageContext -BlobEndpoint $blobEndpoint -FileEndpoint $fileEndpoint -TableEndpoint $tableEndpoint -UseConnectedAccount
        Assert-AreEqual $ctxOAuthServiceEndpoint.BlobEndpoint $blobEndpoint
        Assert-AreEqual $ctxOAuthServiceEndpoint.FileEndpoint $fileEndpoint
        Assert-AreEqual $ctxOAuthServiceEndpoint.TableEndpoint $tableEndpoint
        Assert-Null $ctxOAuthServiceEndpoint.QueueEndpoint
        Assert-AreEqual $ctxOAuthServiceEndpoint.StorageAccountName "[AccessToken]"

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
Test NewSet-AzStorageAccountFileAADKERB
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-NewSetAzStorageAccountFileAADKERB
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

        $DomainName = "testaadkerb.com"
        $DomainGuid = "aebfc118-1111-1111-1111-d98e41a77cd5"
        
        # new account with AADKERB
        $sto = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableAzureActiveDirectoryKerberosForFile $true ;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADKERB' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 		

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADKERB' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 	
        
        # update account with AADKERB disabled
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableAzureActiveDirectoryKerberosForFile $false 
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
        
        # update account with AADKERB enabled
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableAzureActiveDirectoryKerberosForFile $true 
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADKERB' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADKERB' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 
        
        # update account with AADKERB enabled with domainName and domainGUID
        $sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableAzureActiveDirectoryKerberosForFile $true -ActiveDirectoryDomainName $DomainName -ActiveDirectoryDomainGuid $DomainGuid
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual $DomainName $sto.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.domainName; 
        Assert-AreEqual $DomainGuid $sto.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.domainGUID; 

        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind; 
        Assert-AreEqual 'AADKERB' $sto.AzureFilesIdentityBasedAuth.DirectoryServiceOptions; 
        Assert-AreEqual $DomainName $sto.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.domainName; 
        Assert-AreEqual $DomainGuid $sto.AzureFilesIdentityBasedAuth.ActiveDirectoryProperties.domainGUID; 
        
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
Test AzureStorageLocalUserSftp
.DESCRIPTION
SmokeTest
#>
function Test-AzureStorageLocalUserSftp
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
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableSftp $true -EnableHierarchicalNamespace $true -EnableNfsV3 $false -EnableLocalUser $true

        Retry-IfException { $global:sto = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $loc.ToLower().Replace(" ", "") $sto.Location;
        Assert-AreEqual $kind $sto.Kind;
        Assert-AreEqual $true $sto.EnableSftp;
        Assert-AreEqual $true $sto.EnableLocalUser;
        
        Retry-IfException { $global:sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableSftp $false }
        Assert-AreEqual $false $sto.EnableSftp;
        Assert-AreEqual $true $sto.EnableLocalUser;
        
        Retry-IfException { $global:sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableLocalUser $false }
        Assert-AreEqual $false $sto.EnableSftp;
        Assert-AreEqual $false $sto.EnableLocalUser;
        
        Retry-IfException { $global:sto = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -EnableLocalUser $true -EnableSftp $true }
        Assert-AreEqual $true $sto.EnableSftp;
        Assert-AreEqual $true $sto.EnableLocalUser;
        
        # create local user
        $userName1 = "testuser1"
        $userName2 = "testuser2"
        $sshkey1 = New-AzStorageLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykey=" -Description "sshpulickey name1"
        $sshkey2 = New-AzStorageLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykew=" -Description "sshpulickey name2"
        $permissionScope1 = New-AzStorageLocalUserPermissionScope -Permission rwd -Service blob -ResourceName container1 
        $permissionScope2 = New-AzStorageLocalUserPermissionScope -Permission rw -Service file -ResourceName share2
        $localuser1 = Set-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName1 -HomeDirectory "/" -SshAuthorizedKey $sshkey1,$sshkey2 -PermissionScope $permissionScope1,$permissionScope2 -HasSharedKey $true -HasSshKey $true -HasSshPassword $true
        Assert-AreEqual $userName1 $localuser1.Name;
        Assert-AreEqual $true $localuser1.HasSharedKey;
        Assert-AreEqual $true $localuser1.HasSshKey;
        Assert-AreEqual $true $localuser1.HasSshPassword;
        Assert-AreEqual "/" $localuser1.HomeDirectory;
        Assert-AreEqual 2 $localuser1.PermissionScopes.Count;
        Assert-AreEqual "rwd" $localuser1.PermissionScopes[0].Permissions;
        Assert-AreEqual "blob" $localuser1.PermissionScopes[0].Service;
        Assert-AreEqual "container1" $localuser1.PermissionScopes[0].ResourceName;
        Assert-AreEqual "rw" $localuser1.PermissionScopes[1].Permissions;
        Assert-AreEqual "file" $localuser1.PermissionScopes[1].Service;
        Assert-AreEqual "share2" $localuser1.PermissionScopes[1].ResourceName;
        Assert-AreEqual 2 $localuser1.SshAuthorizedKeys.Count;
        Assert-AreEqual "ssh-rsa keykeykeykeykey="  $localuser1.SshAuthorizedKeys[0].Key;
        Assert-AreEqual "sshpulickey name1"  $localuser1.SshAuthorizedKeys[0].Description;
        Assert-AreEqual "ssh-rsa keykeykeykeykew="  $localuser1.SshAuthorizedKeys[1].Key;
        Assert-AreEqual "sshpulickey name2"  $localuser1.SshAuthorizedKeys[1].Description;
        $localuser2 = Set-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName2 -HomeDirectory "/dir1" 
        Assert-AreEqual $userName2 $localuser2.Name;
        Assert-Null $localuser2.HasSharedKey;
        Assert-Null $localuser2.HasSshKey;
        Assert-Null $localuser2.HasSshPassword;
        Assert-AreEqual "/dir1" $localuser2.HomeDirectory;
        Assert-Null $localuser2.PermissionScopes;
        Assert-Null $localuser2.SshAuthorizedKeys;

        # update local user
        $localuser2 = Set-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName2 -HomeDirectory "/dir2" -HasSharedKey $true -HasSshKey $true -HasSshPassword $true `
            -SshAuthorizedKey (@{
                Description="sshpulickey name3";
                Key="ssh-rsa keykeykeykeykew=";                
            },
            @{
                Description="sshpulickey name4";
                Key="ssh-rsa keykeykeykeykew="; 
            }) `
            -PermissionScope (@{
                Permissions="rw";
                Service="blob"; 
                ResourceName="container1";                
            },
            @{
                Permissions="rwd";
                Service="file"; 
                ResourceName="share1";
            }) 
        Assert-AreEqual $userName2 $localuser2.Name;
        Assert-AreEqual $true $localuser2.HasSharedKey;
        Assert-AreEqual $true $localuser2.HasSshKey;
        Assert-AreEqual $true $localuser2.HasSshPassword;
        Assert-AreEqual "/dir2" $localuser2.HomeDirectory;
        Assert-AreEqual 2 $localuser2.PermissionScopes.Count;
        Assert-AreEqual "rw" $localuser2.PermissionScopes[0].Permissions;
        Assert-AreEqual "blob" $localuser2.PermissionScopes[0].Service;
        Assert-AreEqual "container1" $localuser2.PermissionScopes[0].ResourceName;
        Assert-AreEqual "rwd" $localuser2.PermissionScopes[1].Permissions;
        Assert-AreEqual "file" $localuser2.PermissionScopes[1].Service;
        Assert-AreEqual "share1" $localuser2.PermissionScopes[1].ResourceName;
        Assert-AreEqual 2 $localuser2.SshAuthorizedKeys.Count;
        Assert-AreEqual "ssh-rsa keykeykeykeykew="  $localuser2.SshAuthorizedKeys[0].Key;
        Assert-AreEqual "sshpulickey name3"  $localuser2.SshAuthorizedKeys[0].Description;
        Assert-AreEqual "ssh-rsa keykeykeykeykew="  $localuser2.SshAuthorizedKeys[1].Key;
        Assert-AreEqual "sshpulickey name4"  $localuser2.SshAuthorizedKeys[1].Description;

        # get single local user
        $localuser1 = Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName1
        Assert-AreEqual $userName1 $localuser1.Name;
        Assert-AreEqual $true $localuser1.HasSharedKey;
        Assert-AreEqual $true $localuser1.HasSshKey;
        Assert-AreEqual $true $localuser1.HasSshPassword;
        Assert-AreEqual "/" $localuser1.HomeDirectory;
        Assert-AreEqual 2 $localuser1.PermissionScopes.Count;
        Assert-AreEqual "rwd" $localuser1.PermissionScopes[0].Permissions;
        Assert-AreEqual "blob" $localuser1.PermissionScopes[0].Service;
        Assert-AreEqual "container1" $localuser1.PermissionScopes[0].ResourceName;
        Assert-AreEqual "rw" $localuser1.PermissionScopes[1].Permissions;
        Assert-AreEqual "file" $localuser1.PermissionScopes[1].Service;
        Assert-AreEqual "share2" $localuser1.PermissionScopes[1].ResourceName;
        Assert-Null $localuser1.SshAuthorizedKeys;

        #list all local users
        $localusers = Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname 
        Assert-AreEqual 2 $localusers.Count;
        Assert-AreEqual $userName1 $localusers[0].Name;
        Assert-AreEqual $userName2 $localusers[1].Name;

        # get public key
        $key = Get-AzStorageLocalUserKey -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName1
        Assert-NotNull $key.SharedKey
        Assert-AreEqual 2 $key.SshAuthorizedKeys.Count;
        #Assert-AreEqual "ssh-rsa keykeykeykeykey="  $key.SshAuthorizedKeys[0].Key;
        Assert-AreEqual "sshpulickey name1"  $key.SshAuthorizedKeys[0].Description;
        Assert-AreEqual "ssh-rsa keykeykeykeykew="  $key.SshAuthorizedKeys[1].Key;
        Assert-AreEqual "sshpulickey name2"  $key.SshAuthorizedKeys[1].Description;

        # regenerate ssh password
        $password = New-AzStorageLocalUserSshPassword -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName1
        Assert-NotNull $password.SshPassword

        # remove local user
        Remove-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname -UserName $userName1
        $localusers = Get-AzStorageLocalUser -ResourceGroupName $rgname -StorageAccountName $stoname 
        Assert-AreEqual 1 $localusers.Count;
        Assert-AreEqual $userName2 $localusers[0].Name;

        #clean up
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
Test StorageAccountDNSEndpointType
.DESCRIPTION
SmokeTest
#>
function Test-StorageAccountDNSEndpointType
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname
        $stoname2 = 'sto2' + $rgname
        $stotype = 'Standard_LRS'
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2' 
        New-AzResourceGroup -Name $rgname -Location $loc;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -SkuName $stotype -DnsEndpointType AzureDnsZone
        $account = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $account.StorageAccountName $stoname 
        Assert-AreEqual $account.DnsEndpointType AzureDnsZone

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname2 -Location $loc -SkuName $stotype -DnsEndpointType Standard
        $account2 = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname2
        Assert-AreEqual $account2.StorageAccountName $stoname2
        Assert-AreEqual $account2.DnsEndpointType Standard

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}