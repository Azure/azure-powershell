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
Test SyncGroup
.DESCRIPTION
SmokeTest
#>
function Test-SyncGroup
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by Name"
        $syncGroup = Get-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -Verbose
         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "List StorageSyncServices by Name"
        $storageSyncService = Get-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose
        Write-Verbose "Validating StorageSyncService Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

        Write-Verbose "Get SyncGroup by ParentObject"
        $syncGroup = Get-AzureRmStorageSyncGroup -ParentObject $storageSyncService -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Get SyncGroup by ParentResourceId"
        $syncGroup = Get-AzureRmStorageSyncGroup -ParentResourceId $storageSyncService.ResourceId -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName | Get-AzureRmStorageSyncGroup  | Remove-AzureRmStorageSyncGroup -Force -AsJob | Wait-Job

        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName | Remove-AzureRmStorageSyncGroup -Force -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

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
Test NewSyncGroup
.DESCRIPTION
SmokeTest
#>
function Test-NewSyncGroup
{
   # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

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
Test GetSyncGroup
.DESCRIPTION
SmokeTest
#>
function Test-GetSyncGroup
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by Name"
        $syncGroup = Get-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -Verbose
         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

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
Test GetSyncGroups
.DESCRIPTION
SmokeTest
#>
function Test-GetSyncGroups
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by Name"
        $syncGroups = Get-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose

        Assert-AreEqual $syncGroups.Length 1
        $syncGroup = $syncGroups[0]

         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

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
Test GetSyncGroupParentObject
.DESCRIPTION
SmokeTest
#>
function Test-GetSyncGroupParentObject
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        $storageSyncService = New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by ParentObject"
        $syncGroup = Get-AzureRmStorageSyncGroup -ParentObject $storageSyncService -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

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
Test GetSyncGroupParentResourceId
.DESCRIPTION
SmokeTest
#>
function Test-GetSyncGroupParentResourceId
{
    # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        $storageSyncService = New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by ParentResourceId"
        $syncGroup = Get-AzureRmStorageSyncGroup -ParentResourceId $storageSyncService.ResourceId -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

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
Test RemoveSyncGroup
.DESCRIPTION
SmokeTest
#>
function Test-RemoveSyncGroup
{
     # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName 

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
Test RemoveSyncGroupInputObject
.DESCRIPTION
SmokeTest
#>
function Test-RemoveSyncGroupInputObject
{
     # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -InputObject $syncGroup -Force

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
Test RemoveSyncGroupInputObject
.DESCRIPTION
SmokeTest
#>
function Test-RemoveSyncGroupResourceId
{
     # Setup
    $resourceGroupName = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $storageSyncServiceName = Get-StorageManagementTestResourceName
        $syncGroupName = Get-StorageManagementTestResourceName
        $resourceLocation = Get-ProviderLocation ResourceManagement;

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -ResourceId $syncGroup.ResourceId -Force

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