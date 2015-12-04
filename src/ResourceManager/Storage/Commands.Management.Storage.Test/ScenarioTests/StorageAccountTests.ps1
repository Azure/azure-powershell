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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;

        $stotype = 'StandardGRS';
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname; }
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { $global:sto = Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype; }
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardLRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;
    
        $stotype = 'Standard_RAGRS';
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_GRS';
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        
        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stokey1 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;
        
        $stokey2 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey1.Key2 $stokey2.Key2;

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey2.Key1 $stokey3.Key1;
        Assert-AreNotEqual $stokey2.Key2 $stokey3.Key2;

        Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].StorageAccountName $stoname;
        Assert-AreEqual $stos[0].AccountType $stotype;
        Assert-AreEqual $stos[0].Location $loc;

        Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;
        
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].StorageAccountName $stoname;
        Assert-AreEqual $stos[0].AccountType $stotype;
        Assert-AreEqual $stos[0].Location $loc;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype; }
        $stotype = 'Standard_RAGRS';
        Set-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;

        $sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.StorageAccountName $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRmStorageAccount
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname; }
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokeys = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreNotEqual $stokeys.Key1 $stokeys.Key2;

        Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokey1 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;

        $stokey2 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey1.Key2 $stokey2.Key2;

        New-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzureRmStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey2.Key1 $stokey3.Key1;
        Assert-AreNotEqual $stokey2.Key2 $stokey3.Key2;

        Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
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
        $loc = 'West US';

        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:stokeys = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname | Get-AzureRmStorageAccountKey -ResourceGroupName $rgname; }
        Assert-AreNotEqual $stokeys.Key1 $stokeys.Key2;

        Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname;
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
        $loc = 'West US'

        New-AzureRmResourceGroup -Name $rgname -Location $loc
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname }
		$global:sto | Set-AzureRmCurrentStorageAccount
		$context = Get-AzureRmContext
		Assert-AreEqual $stoname $context.Subscription.CurrentStorageAccountName
		$global:sto | Remove-AzureRmStorageAccount
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
        $loc = 'West US'

        New-AzureRmResourceGroup -Name $rgname -Location $loc
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype
        Retry-IfException { $global:sto = Get-AzureRmStorageAccount -ResourceGroupName $rgname  -Name $stoname }
		Set-AzureRmCurrentStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname
		$context = Get-AzureRmContext
		Assert-AreEqual $stoname $context.Subscription.CurrentStorageAccountName
		$global:sto | Remove-AzureRmStorageAccount
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
