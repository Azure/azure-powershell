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
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;
        Wait-Seconds 300;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        $stos = Get-AzureStorageAccount -ResourceGroupName $rgname;
        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_LRS';
        Set-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        Wait-Seconds 300;

        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;
    
        $stotype = 'Standard_RAGRS';
        Set-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        Wait-Seconds 300;

        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_GRS';
        Set-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        Wait-Seconds 300;

        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stokey1 = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

        New-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;
        Wait-Seconds 300;

        $stokey2 = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey1.Key2 $stokey2.Key2;

        New-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;
        Wait-Seconds 300;

        $stokey3 = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey2.Key1 $stokey3.Key1;
        Assert-AreNotEqual $stokey2.Key2 $stokey3.Key2;

        Wait-Seconds 300;
        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureStorageAccount
#>
function Test-NewAzureStorageAccount
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureStorageAccount
#>
function Test-GetAzureStorageAccount
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        $stos = Get-AzureStorageAccount -ResourceGroupName $rgname;
        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzureStorageAccount
#>
function Test-SetAzureStorageAccount
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;
        Wait-Seconds 300;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        $stos = Get-AzureStorageAccount -ResourceGroupName $rgname;
        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        $stotype = 'Standard_LRS';
        Set-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        $stotype = 'Standard_RAGRS';
        Set-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Type $stotype;
        Wait-Seconds 300;

        $sto = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
        Assert-AreEqual $sto.Name $stoname;
        Assert-AreEqual $sto.Properties.AccountType $stotype;
        Assert-AreEqual $sto.Location $loc;

        Wait-Seconds 300;
        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzureStorageAccount
#>
function Test-RemoveAzureStorageAccount
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureStorageAccountKey
#>
function Test-GetAzureStorageAccountKey
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        $stokeys = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokeys.Key1 $stokeys.Key2;

        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureStorageAccountKey
#>
function Test-NewAzureStorageAccountKey
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        $stokey1 = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;

        New-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key1;
        Wait-Seconds 300;

        $stokey2 = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey1.Key2 $stokey2.Key2;

        New-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname -KeyName key2;
        Wait-Seconds 300;

        $stokey3 = Get-AzureStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-AreNotEqual $stokey1.Key1 $stokey2.Key1;
        Assert-AreEqual $stokey2.Key1 $stokey3.Key1;
        Assert-AreNotEqual $stokey2.Key2 $stokey3.Key2;

        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzureStorageAccount | Get-AzureStorageAccountKey 
#>
function Test-PipingGetAccountToGetKey
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname = 'pstest' + $rgname;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = 'East US';

        New-AzureResourceGroup -Name $rgname -Location $loc;

        New-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        Wait-Seconds 300;

        $stokeys = Get-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname | Get-AzureStorageAccountKey -ResourceGroupName $rgname;
        Assert-AreNotEqual $stokeys.Key1 $stokeys.Key2;

        Remove-AzureStorageAccount -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}