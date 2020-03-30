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
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobContainer
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$containerName = "container"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
        $publicAccess = 'blob'
		$metadata = @{tag0="value0"} # set 3 metadata will fail in server, so use 1 mentadata here. Can revert to 3 mentadata when server fixed

		Update-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -PublicAccess $publicAccess -Metadata $metadata
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual $publicAccess $container.PublicAccess
		Assert-AreEqual $metadata.Count $container.Metadata.Count
		
        $publicAccess = 'container'
		$metadata = @{tag0="value0";tag1="value1"}
		$containerName2 = "container2"+ $rgname		
		New-AzRmStorageContainer -StorageAccount $stos -Name $containerName2 -PublicAccess $publicAccess -Metadata $metadata
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName2 $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual $publicAccess $container.PublicAccess
		Assert-AreEqual $metadata.Count $container.Metadata.Count

		$job = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -AsJob
		$job | Wait-Job
		$containers = $job.Output
		Assert-AreEqual 2 $containers.Count
		Assert-AreEqual $containerName  $containers[1].Name
		Assert-AreEqual $containerName2  $containers[0].Name

		Remove-AzRmStorageContainer -Force -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$containers = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 1 $containers.Count
		Assert-AreEqual $containerName2  $containers[0].Name

		Remove-AzRmStorageContainer -Force -StorageAccount $stos -Name $containerName2
		$containers = Get-AzRmStorageContainer -StorageAccount $stos
		Assert-AreEqual 0 $containers.Count

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test StorageAccount container with Encryption Scope
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobContainerEncryptionScope
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$containerName = "container"+ $rgname
		$containerName2 = "container2"+ $rgname
		$scopeName = "testscope"
		$scopeName2 = "testscope2"

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
		
		# create Scope
		New-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName -StorageEncryption
		$scope = Get-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName
		Assert-AreEqual $rgname $scope.ResourceGroupName
		Assert-AreEqual $stoname $scope.StorageAccountName
		Assert-AreEqual $scopeName $scope.Name
		Assert-AreEqual "Microsoft.Storage" $scope.Source
		Assert-AreEqual "Enabled" $scope.State
		
		# update Scope
		$scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName -State Disabled 
		Assert-AreEqual "Disabled" $scope.State
		$scope = Update-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName -State Enabled
		Assert-AreEqual "Enabled" $scope.State
		
		#List Scope
		New-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName2 -StorageEncryption
		$scopes = Get-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual 2 $scopes.Count

		#create container
		New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -DefaultEncryptionScope $scopename -PreventEncryptionScopeOverride $true 
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $scopename $container.DefaultEncryptionScope
		Assert-AreEqual $true $container.DenyEncryptionScopeOverride
		New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2 -DefaultEncryptionScope $scopename2 -PreventEncryptionScopeOverride $false 
		$container2 = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2
		Assert-AreEqual $rgname $container2.ResourceGroupName
		Assert-AreEqual $stoname $container2.StorageAccountName
		Assert-AreEqual $containerName2 $container2.Name
		Assert-AreEqual $scopename2 $container2.DefaultEncryptionScope
		Assert-AreEqual false $container2.DenyEncryptionScopeOverride
		
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-StorageBlobContainerLegalHold
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$containerName = "container"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
        Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname  -Name $containerName -Tag  tag1,tag2,tag3
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 3 $container.LegalHold.Tags.Count
		Assert-AreEqual "tag1" $container.LegalHold.Tags[0].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].ObjectIdentifier
		Assert-AreEqual "tag2" $container.LegalHold.Tags[1].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[1].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[1].ObjectIdentifier
		Assert-AreEqual "tag3" $container.LegalHold.Tags[2].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[2].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[2].ObjectIdentifier

		Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -Tag tag1,tag2 
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 1 $container.LegalHold.Tags.Count
		Assert-AreEqual "tag3" $container.LegalHold.Tags[0].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].ObjectIdentifier

		Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -Tag tag1
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 2 $container.LegalHold.Tags.Count
		Assert-AreEqual "tag3" $container.LegalHold.Tags[0].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].ObjectIdentifier
		Assert-AreEqual "tag1" $container.LegalHold.Tags[1].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[1].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[1].ObjectIdentifier

		Remove-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -Tag tag1,tag3
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 0 $container.LegalHold.Tags.Count

		Remove-AzRmStorageContainer -Force -StorageAccount $stos -Name $containerName
		$containers = Get-AzRmStorageContainer -StorageAccount $stos
		Assert-AreEqual 0 $containers.Count

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


function Test-StorageBlobContainerImmutabilityPolicy
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$containerName = "container"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
		
        $policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 		
		Assert-AreEqual 0 $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Deleted $policy.State
		Assert-AreEqual "" $policy.Etag

		$immutabilityPeriod =3
        Set-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName -ImmutabilityPeriod $immutabilityPeriod -AllowProtectedAppendWrite $true
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		Assert-AreEqual $true $policy.AllowProtectedAppendWrites
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 1 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		Assert-AreEqual $true $container.ImmutabilityPolicy.AllowProtectedAppendWrites
		
		$immutabilityPeriod =2
        Set-AzRmStorageContainerImmutabilityPolicy -inputObject $policy -ImmutabilityPeriod $immutabilityPeriod -AllowProtectedAppendWrite $false
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		Assert-AreEqual $false $policy.AllowProtectedAppendWrites
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName		
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 1 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		Assert-AreEqual $false $container.ImmutabilityPolicy.AllowProtectedAppendWrites

        Remove-AzRmStorageContainerImmutabilityPolicy -inputObject $policy 
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual 0 $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Deleted $policy.State
		Assert-AreEqual "" $policy.Etag
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName		
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $null $container.ImmutabilityPolicy
		
		$immutabilityPeriod =7
        Set-AzRmStorageContainerImmutabilityPolicy -inputObject $policy -ImmutabilityPeriod $immutabilityPeriod
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName	
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 1 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		
        Lock-AzRmStorageContainerImmutabilityPolicy -inputObject $policy -Force
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Locked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Locked $container.ImmutabilityPolicy.State
		Assert-AreEqual 2 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		Assert-AreEqual lock $container.ImmutabilityPolicy.UpdateHistory[1].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[1].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[1].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[1].ObjectIdentifier
		
		$immutabilityPeriod2 =20
        Set-AzRmStorageContainerImmutabilityPolicy -inputObject $policy -ExtendPolicy -ImmutabilityPeriod $immutabilityPeriod2
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod2 $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Locked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod2 $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Locked $container.ImmutabilityPolicy.State
		Assert-AreEqual 3 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		Assert-AreEqual lock $container.ImmutabilityPolicy.UpdateHistory[1].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[1].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[1].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[1].ObjectIdentifier
		Assert-AreEqual extend $container.ImmutabilityPolicy.UpdateHistory[2].Update
		Assert-AreEqual $immutabilityPeriod2 $container.ImmutabilityPolicy.UpdateHistory[2].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[2].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[2].ObjectIdentifier

		Remove-AzRmStorageContainer -Force -StorageAccount $stos -Name $containerName
		$containers = Get-AzRmStorageContainer -StorageAccount $stos
		Assert-AreEqual 0 $containers.Count

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test StorageAccount Blob Service Properties
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobServiceProperties
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
	
        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
		
		# Update and Get Blob Service Properties: DefaultServiceVersion
		$property = Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -DefaultServiceVersion 2018-03-28 
		Assert-AreEqual '2018-03-28' $property.DefaultServiceVersion
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual '2018-03-28' $property.DefaultServiceVersion

		# Update and Get Blob Service Properties: ChangeFeed
		$property = Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableChangeFeed $true
		Assert-AreEqual $true $property.ChangeFeed.Enabled
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $true $property.ChangeFeed.Enabled
		$property = Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableChangeFeed $false
		Assert-AreEqual $false $property.ChangeFeed.Enabled
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $false $property.ChangeFeed.Enabled

		# Enable and Disable Blob Delete Retention Policy
		$policy = Enable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -PassThru -RetentionDays 3
		Assert-AreEqual $true $policy.Enabled
		Assert-AreEqual 3 $policy.Days
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual '2018-03-28' $property.DefaultServiceVersion
		Assert-AreEqual $true $property.DeleteRetentionPolicy.Enabled
		Assert-AreEqual 3 $property.DeleteRetentionPolicy.Days

		$policy = Disable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -PassThru
		Assert-AreEqual $false $policy.Enabled
		Assert-AreEqual $null $policy.Days
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual '2018-03-28' $property.DefaultServiceVersion
		Assert-AreEqual $false $property.DeleteRetentionPolicy.Enabled
		Assert-AreEqual $null $property.DeleteRetentionPolicy.Days

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test StorageAccount Blob Restore
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobRestore
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
	
        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
		
		# Enable Blob Delete Retension Policy, Enable Changefeed, then enabled blob restore policy, then get blob service proeprties and check the setting
		Enable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -RetentionDays 5
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableChangeFeed $true
		# If record, need sleep before enable the blob restore policy, or will get server error
		#sleep 100 
		Enable-AzStorageBlobRestorePolicy -ResourceGroupName $rgname -StorageAccountName $stoname -RestoreDays 4
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $true $property.ChangeFeed.Enabled
		Assert-AreEqual $true $property.DeleteRetentionPolicy.Enabled
		Assert-AreEqual 5 $property.DeleteRetentionPolicy.Days
		Assert-AreEqual $true $property.RestorePolicy.Enabled
		Assert-AreEqual 4 $property.RestorePolicy.Days

		# restore blobs by -asjob
		$range1 = New-AzStorageBlobRangeToRestore -StartRange container1/blob1 -EndRange container2/blob2
		$range2 = New-AzStorageBlobRangeToRestore -StartRange container3/blob3 -EndRange ""
		$job = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $stoname -TimeToRestore (Get-Date).AddSeconds(-1) -BlobRestoreRange $range1,$range2 -asjob

		# Get  Storage Account with Blob Restore Status
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeBlobRestoreStatus

		# wait for restore job finish, and check Blob Restore Status in Storage Account	
		$job | Wait-Job
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeBlobRestoreStatus
		Assert-AreEqual "Complete" $stos.BlobRestoreStatus.Status

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


