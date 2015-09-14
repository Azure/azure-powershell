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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stos = Get-AzureRMStorageAccount -ResourceGroupName $rgname;

        $stotype = 'StandardGRS';
        Retry-IfException { $global:sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname  -Name $stoname; }
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { $global:sto = Set-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype; }
        $sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardLRS';
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;
    
        $stotype = 'Standard_RAGRS';
        Set-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        
        $sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_GRS';
        Set-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        
        $sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stokey1 = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

        New-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;
        
        $stokey2 = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey1.Key2 $stokey2.Key2;

        New-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey2.Key1 $stokey3.Key1;
        Assert-AreNotEqual $stokey2.Key2 $stokey3.Key2;

        Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRMStorageAccount
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRMStorageAccount
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stos = Get-AzureRMStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].Name $stoname;
        Assert-AreEqual $stos[0].AccountType $stotype;
        Assert-AreEqual $stos[0].Location $loc;

        Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzureRMStorageAccount
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname; }
        $stotype = 'StandardGRS';
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;
        
        $stos = Get-AzureRMStorageAccount -ResourceGroupName $rgname;
        Assert-AreEqual $stos[0].Name $stoname;
        Assert-AreEqual $stos[0].AccountType $stotype;
        Assert-AreEqual $stos[0].Location $loc;

        $stotype = 'Standard_LRS';
        # TODO: Still need to do retry for Set-, even after Get- returns it.
        Retry-IfException { Set-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype; }
        $stotype = 'Standard_RAGRS';
        Set-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;

        $sto = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
        $stotype = 'StandardRAGRS';
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureRMStorageAccount
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRMStorageAccountKey
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokeys = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }
        Assert-AreNotEqual $stokeys.Key1 $stokeys.Key2;

        Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRMStorageAccountKey
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        
        Retry-IfException { $global:stokey1 = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname; }

        New-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;

        $stokey2 = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey1.Key2 $stokey2.Key2;

        New-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;

        $stokey3 = Get-AzureRMStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey2.Key1 $stokey3.Key1;
        Assert-AreNotEqual $stokey2.Key2 $stokey3.Key2;

        Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureRMStorageAccount | Get-AzureRMStorageAccountKey 
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

        New-AzureRMResourceGroup -Name $rgname -Location $loc;

        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;

        Retry-IfException { $global:stokeys = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname | Get-AzureRMStorageAccountKey -ResourceGroupName $rgname; }
        Assert-AreNotEqual $stokeys.Key1 $stokeys.Key2;

        Remove-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}