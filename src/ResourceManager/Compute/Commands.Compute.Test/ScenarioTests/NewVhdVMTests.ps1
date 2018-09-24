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
Test New-AzureRmVhdVM with a valid disk file
#>
function Test-NewAzureRmVhdVMWithValidDiskFile
{

    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        # Create a new VM using the tiny VHD file
        [string]$file = ".\VhdFiles\tiny.vhd";
        $vmname = $rgname + 'vm';
        [string]$domainNameLabel = "$vmname-$rgname".tolower();
		$vm = New-AzureRmVM -ResourceGroupName $rgname -Name $vmname -Location $loc -DiskFile $file -OpenPorts 1234 -DomainNameLabel $domainNameLabel;
        Assert-AreEqual $vm.Name $vmname;
        Assert-AreEqual $vm.Location $loc;
        Assert-Null $vm.OSProfile $null;
        Assert-Null $vm.StorageProfile.DataDisks;
        Assert-NotNull $vm.StorageProfile.OSDisk.ManagedDisk;
        # Check the dependent disk resource
        $stoname = $vmname;
        $diskname = $vmname;
        $disk = Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Import $disk.CreationData.CreateOption;
        Assert-AreEqual "https://${stoname}.blob.core.windows.net/${rgname}/${diskname}.vhd" $disk.CreationData.SourceUri;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test New-AzureRmVhdVM with an invalid disk file
#>
function Test-NewAzureRmVhdVMWithInvalidDiskFile
{
    # Setup
    $rgname = Get-ComputeTestResourceName;

    try
    {
        # Create an invalid VHD file
        [string]$file1 = ".\test_invalid_file_1.vhd";
        $st = Set-Content -Path $file1 -Value "test1" -Force;

        # Common
        [string]$loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');
      
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        # Try to create a VM using the VHD file
        $expectedException = $false;
        $expectedErrorMessage = "*unsupported format*";
        try
        {
			[string]$domainNameLabel = "$rgname-$rgname".tolower();
            $st = New-AzureRmVM -ResourceGroupName $rgname -Name $rgname -Location $loc -Linux -DiskFile $file1 -OpenPorts 1234 -DomainNameLabel $domainNameLabel;
        }
        catch
        {
            if ($_ -like $expectedErrorMessage)
            {
                $expectedException = $true;
            }
        }
        
        if (-not $expectedException)
        {
            throw "Expected exception from calling New-AzureRmVM was not caught: '$expectedErrorMessage'.";
        }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
