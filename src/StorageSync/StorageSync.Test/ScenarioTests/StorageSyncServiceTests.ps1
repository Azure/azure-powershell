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
Test StorageSyncService
.DESCRIPTION
SmokeTest
#>
function Test-StorageSyncService
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName -IncomingTrafficPolicy "AllowVirtualNetworksOnly"

        $storageSyncService = Get-AzStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose
        Write-Verbose "Validating StorageSyncService Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual "AllowVirtualNetworksOnly" $storageSyncService.IncomingTrafficPolicy

        Set-AzStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -IncomingTrafficPolicy "AllowAllTraffic"

        Write-Verbose "List StorageSyncServices by ResourceGroup"
        $storageSyncServices = Get-AzStorageSyncService -ResourceGroupName $resourceGroupName

        Write-Verbose "List StorageSyncServices by Name"
        $storageSyncService = Get-AzStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose

        Write-Verbose "Validating StorageSyncService Properties"
        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual "AllowAllTraffic" $storageSyncService.IncomingTrafficPolicy
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        # TODO : Remove the new generation of sss, it should work
         $storageSyncServiceName = Get-ResourceName("sss")

        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName | Get-AzStorageSyncService  | Remove-AzStorageSyncService -Force -AsJob | Wait-Job

         # TODO : Remove the new generation of sss, it should work
        $storageSyncServiceName = Get-ResourceName("sss")

        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName | Remove-AzStorageSyncService -Force -AsJob | Wait-Job
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
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

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
Test NewStorageSyncServiceWithIdentity
.DESCRIPTION
SmokeTest
#>
function Test-NewStorageSyncServiceWithIdentity
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        try 
        {
            $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName -AssignIdentity -IdentityType SystemAssigned
        }
        catch 
        {
            Write-Host $_.Exception.Message
            Write-Host $_.Exception.InnerException.Message
            throw $_
        }

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
    Write-Verbose "RecordMode : $(
)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "List StorageSyncServices by Name"
        $storageSyncService = Get-AzStorageSyncService -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Verbose

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

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
Test GetStorageSyncServices
.DESCRIPTION
SmokeTest
#>
function Test-GetStorageSyncServices
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "List StorageSyncServices by ResourceGroup"
        $storageSyncServices = Get-AzStorageSyncService -ResourceGroupName $resourceGroupName -Verbose

        Assert-AreEqual $storageSyncServices.Length 1
        $storageSyncService = $storageSyncServices[0]

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))

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
Test RemoveStorageSyncService
.DESCRIPTION
SmokeTest
#>
function Test-RemoveStorageSyncService
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))
        
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
Test RemoveStorageSyncServiceInputObject
.DESCRIPTION
SmokeTest
#>
function Test-RemoveStorageSyncServiceInputObject
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))
        
        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -InputObject $storageSyncService
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
    Write-Verbose "RecordMode : $(Get-StorageTestMode)"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices");

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Assert-AreEqual $storageSyncServiceName $storageSyncService.StorageSyncServiceName
        Assert-AreEqual (Normalize-Location($resourceLocation)) (Normalize-Location($storageSyncService.Location))
        
        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceId $storageSyncService.ResourceId
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}