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
Tests Create-AzureVM with valid information.
#>
function Test-GetAzureVM
{
    # Setup

    $location = Get-DefaultLocation
    $imgName = Get-DefaultImage $location


    $storageName = getAssetName
    New-AzureStorageAccount -StorageAccountName $storageName -Location $location

    Set-CurrentStorageAccountName $storageName

    $vmName = "vm1"
    $svcName = Get-CloudServiceName

    # Test
    New-AzureService -ServiceName $svcName -Location $location
    New-AzureQuickVM -Windows -ImageName $imgName -Name $vmName -ServiceName $svcName -AdminUsername "pstestuser" -Password "p@ssw0rd"

    Get-AzureVM -ServiceName $svcName -Name $vmName


    # Cleanup
    Cleanup-CloudService $svcName
}


<#
.SYNOPSIS
Test Get-AzureLocation
#>
function Test-GetAzureLocation
{
    $locations = Get-AzureLocation;

    foreach ($loc in $locations)
    {
        $svcName = getAssetName;
        $st = New-AzureService -ServiceName $svcName -Location $loc.Name;
        
        # Cleanup
        Cleanup-CloudService $svcName
    }
}

# Test Service Management Cloud Exception
function Run-ServiceManagementCloudExceptionTests
{
    $compare = "*OperationID : `'*`'";
    Assert-ThrowsLike { $st = Get-AzureService -ServiceName '*' } $compare;
    Assert-ThrowsLike { $st = Get-AzureVM -ServiceName '*' } $compare;
    Assert-ThrowsLike { $st = Get-AzureAffinityGroup -Name '*' } $compare;
}

# Test Start/Stop-AzureVM for Multiple VMs
function Run-StartAndStopMultipleVirtualMachinesTest
{
    # Setup
    $location = Get-DefaultLocation;
    $imgName = Get-DefaultImage $location;

    $storageName = 'pstest' + (getAssetName);
    New-AzureStorageAccount -StorageAccountName $storageName -Location $location;

    # Associate the new storage account with the current subscription
    Set-CurrentStorageAccountName $storageName;

    $vmNameList = @("vm01", "vm02", "test04");
    $svcName = 'pstest' + (Get-CloudServiceName);
    $userName = "pstestuser";
    $password = "p@ssw0rd";

    # Test
    New-AzureService -ServiceName $svcName -Location $location;

    try
    {
        foreach ($vmName in $vmNameList)
        {
            New-AzureQuickVM -Windows -ImageName $imgName -Name $vmName -ServiceName $svcName -AdminUsername $userName -Password $password;
        }

        # Get VM List
        $vmList = Get-AzureVM -ServiceName $svcName;

        # Test Stop
        Stop-AzureVM -Force -ServiceName $svcName -Name $vmNameList[0];
        Stop-AzureVM -Force -ServiceName $svcName -Name $vmNameList[0],$vmNameList[1];
        Stop-AzureVM -Force -ServiceName $svcName -Name $vmNameList;
        Stop-AzureVM -Force -ServiceName $svcName -Name '*';
        Stop-AzureVM -Force -ServiceName $svcName -Name 'vm*';
        Stop-AzureVM -Force -ServiceName $svcName -Name 'vm*','test*';
        Stop-AzureVM -Force -ServiceName $svcName -VM $vmList[0];
        Stop-AzureVM -Force -ServiceName $svcName -VM $vmList[0],$vmList[1];
        Stop-AzureVM -Force -ServiceName $svcName -VM $vmList;

        # Test Start
        Start-AzureVM -ServiceName $svcName -Name $vmNameList[0];
        Start-AzureVM -ServiceName $svcName -Name $vmNameList[0],$vmNameList[1];
        Start-AzureVM -ServiceName $svcName -Name $vmNameList;
        Start-AzureVM -ServiceName $svcName -Name '*';
        Start-AzureVM -ServiceName $svcName -Name 'vm*';
        Start-AzureVM -ServiceName $svcName -Name 'vm*','test*';
        Start-AzureVM -ServiceName $svcName -VM $vmList[0];
        Start-AzureVM -ServiceName $svcName -VM $vmList[0],$vmList[1];
        Start-AzureVM -ServiceName $svcName -VM $vmList;
    }
    finally
    {
        # Cleanup
        Cleanup-CloudService $svcName;
    }
}