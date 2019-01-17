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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
         $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by Name"
        $syncGroup = Get-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -Verbose
         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Get SyncGroup by ParentObject"
        $syncGroup = Get-AzStorageSyncGroup -ParentObject $storageSyncService -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Get SyncGroup by ParentResourceId"
        $syncGroup = Get-AzStorageSyncGroup -ParentResourceId $storageSyncService.ResourceId -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName | Get-AzStorageSyncGroup  | Remove-AzStorageSyncGroup -Force -AsJob | Wait-Job

        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName | Remove-AzStorageSyncGroup -Force -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by Name"
        $syncGroup = Get-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -Verbose
         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by Name"
        $syncGroups = Get-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose

        Assert-AreEqual $syncGroups.Length 1
        $syncGroup = $syncGroups[0]

         Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by ParentObject"
        $syncGroup = Get-AzStorageSyncGroup -ParentObject $storageSyncService -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Get SyncGroup by ParentResourceId"
        $syncGroup = Get-AzStorageSyncGroup -ParentResourceId $storageSyncService.ResourceId -Name $syncGroupName -Verbose
        Write-Verbose "Validating SyncGroup Properties"
        Assert-AreEqual $syncGroupName $syncGroup.SyncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName 

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -InputObject $syncGroup -Force

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

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
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
         $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzStorageSyncGroup -ResourceId $syncGroup.ResourceId -Force

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName

    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}