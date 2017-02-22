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
        $loc = 'eastasia';
		$encryptionServiceBF = "Blob,File"
		$encryptionServiceB = "Blob"
		$encryptionServiceF = "File"
		$kind = 'BlobStorage'
		$accessTier = 'Cool'

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -AccessTier $accessTier -EnableEncryptionService $encryptionServiceBF;
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
#>
function Test-NewAzureStorageAccount
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'westus';

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
Test Get-AzureRmStorageAccount
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
        $loc = 'westus';
		$kind = 'Storage'

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;

        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].StorageAccountName $stoname;
        Assert-AreEqual $stos[0].Sku.Name $stotype;
        Assert-AreEqual $stos[0].Location $loc;
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
Test Set-AzureRmStorageAccount
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
        $loc = 'eastasia';
		$kind = 'Storage'
		$encryptionServiceBF = "File,Blob"

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableEncryptionService $encryptionServiceBF;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true
        
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].StorageAccountName $stoname;
        Assert-AreEqual $stos[0].Sku.Name $stotype;
        Assert-AreEqual $stos[0].Location $loc;
        Assert-AreEqual $sto.Kind $kind;
		Assert-AreEqual $sto.Encryption.Services.Blob.Enabled $true
		Assert-AreEqual $sto.Encryption.Services.File.Enabled $true

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype -DisableEncryptionService $encryptionServiceBF; }
        $stotype = 'Standard_RAGRS';
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;

        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.Sku.Name $stotype;
        Assert-AreEqual $sto.Location $loc;
        Assert-AreEqual $sto.Kind $kind;
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
        $loc = 'westus';

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
        $loc = 'westus';

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
        $loc = 'westus';

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
        $loc = 'westus';

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
        $loc = 'westus'

        New-AzureRmResourceGroup -Name $rgname -Location $loc
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname }
		$global:sto | Set-AzureRmCurrentStorageAccount
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
        $loc = 'westus'

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
