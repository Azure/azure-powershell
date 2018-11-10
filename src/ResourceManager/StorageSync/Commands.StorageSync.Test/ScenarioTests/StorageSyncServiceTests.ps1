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
Test StorageSyncService
.DESCRIPTION
SmokeTest
#>
function Test-StorageSyncService
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName
        
        Write-Verbose "List StorageSyncServices by ResourceGroup"
        $storageSyncServices = Get-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName

        Write-Verbose "List StorageSyncServices by Name"
        $storageSyncService = Get-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose

        Write-Verbose "List StorageSyncServices by Name"
        Retry-IfException { $global:storageSyncService = Get-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName  -Name $storageSyncServiceName }

        Write-Verbose "Validating StorageSyncService Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName | Get-AzureRmStorageSyncService  | Remove-AzureRmStorageSyncService -Force -AsJob | Wait-Job

        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName | Remove-AzureRmStorageSyncService -Force -AsJob | Wait-Job
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test NewStorageSyncService
.DESCRIPTION
SmokeTest
#>
function Test-NewStorageSyncService
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test GetStorageSyncService
.DESCRIPTION
SmokeTest
#>
function Test-GetStorageSyncService
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "List StorageSyncServices by Name"
        $storageSyncService = Get-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test GetStorageSyncServices
.DESCRIPTION
SmokeTest
#>
function Test-GetStorageSyncServices
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "List StorageSyncServices by ResourceGroup"
        $storageSyncServices = Get-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Verbose

        Assert-AreEqual $storageSyncServices.Length 1
        $storageSyncService = $storageSyncServices[0]

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test RemoveStorageSyncService
.DESCRIPTION
SmokeTest
#>
function Test-RemoveStorageSyncService
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))
        
        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test RemoveStorageSyncServiceInputObject
.DESCRIPTION
SmokeTest
#>
function Test-RemoveStorageSyncServiceInputObject
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))
        
        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -InputObject $storageSyncService
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test RemoveStorageSyncServiceResourceId
.DESCRIPTION
SmokeTest
#>
function Test-RemoveStorageSyncServiceResourceId
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))
        
        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceId $storageSyncService.ResourceId
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}