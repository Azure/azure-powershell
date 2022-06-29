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
Test StorageAccount blob IsVersioningEnabled
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobIsVersioningEnabled
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
	
        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc -Tag @{Some = 'some'};
		
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
		
		# Enable Blob  versioning
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -IsVersioningEnabled $true
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $true $property.IsVersioningEnabled 
		
		# Disable Blob  versioning
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -IsVersioningEnabled $false
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $false $property.IsVersioningEnabled 

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
		New-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName -StorageEncryption -RequireInfrastructureEncryption 
		$scope = Get-AzStorageEncryptionScope -ResourceGroupName $rgname -StorageAccountName $stoname -EncryptionScopeName $scopeName
		Assert-AreEqual $rgname $scope.ResourceGroupName
		Assert-AreEqual $stoname $scope.StorageAccountName
		Assert-AreEqual $scopeName $scope.Name
		Assert-AreEqual "Microsoft.Storage" $scope.Source
		Assert-AreEqual "Enabled" $scope.State
		Assert-AreEqual $true $scope.RequireInfrastructureEncryption
		
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
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'
		$containerName = "container"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind -EnableHierarchicalNamespace $true
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
        Add-AzRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname  -Name $containerName -Tag  tag1,tag2,tag3 -AllowProtectedAppendWriteAll $true
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
		Assert-AreEqual $true $container.LegalHold.ProtectedAppendWritesHistory.AllowProtectedAppendWritesAll

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

<#
.SYNOPSIS
Test StorageAccount ObjectLevelWorm
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobContainerVLW
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'
        $containerName = "container"+ $rgname
        $containerName2 = "container2"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

        # enabled versioning
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -IsVersioningEnabled $true        
        $property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
        Assert-AreEqual $true $property.IsVersioningEnabled 

        # create container with ImmutableStorageWithVersioning
        New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -EnableImmutableStorageWithVersioning
        $container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
        Assert-AreEqual $rgname $container.ResourceGroupName
        Assert-AreEqual $stoname $container.StorageAccountName
        Assert-AreEqual $containerName $container.Name
        Assert-AreEqual $false $container.HasLegalHold
        Assert-AreEqual $false $container.HasImmutabilityPolicy
        Assert-AreEqual $true $container.ImmutableStorageWithVersioning.Enabled
        
        # migrate container to enable VLW
        New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2
        $container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2
        Assert-AreEqual $rgname $container.ResourceGroupName
        Assert-AreEqual $stoname $container.StorageAccountName
        Assert-AreEqual $containerName2 $container.Name
        Assert-AreEqual $false $container.HasLegalHold
        Assert-AreEqual $false $container.HasImmutabilityPolicy
        Assert-AreNotEqual $true $container.ImmutableStorageWithVersioning.Enabled

        $immutabilityPeriod =1
        Set-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName2 -ImmutabilityPeriod $immutabilityPeriod
        $policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName2
        Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
        Assert-AreEqual Unlocked $policy.State
        
        $t = Invoke-AzRmStorageContainerImmutableStorageWithVersioningMigration -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2 -asjob
        $t | Wait-Job
        $container = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2
        Assert-AreEqual $true $container.ImmutableStorageWithVersioning.Enabled
        
        # remove the containers
        Remove-AzRmStorageContainer -Force -StorageAccount $stos -Name $containerName
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



function Test-StorageBlobContainerImmutabilityPolicy
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
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
        Set-AzRmStorageContainerImmutabilityPolicy -inputObject $policy -ImmutabilityPeriod $immutabilityPeriod -AllowProtectedAppendWrite $false -AllowProtectedAppendWriteAll $true
		$policy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		Assert-AreEqual $false $policy.AllowProtectedAppendWrites
		Assert-AreEqual $true $policy.AllowProtectedAppendWritesAll
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
		Assert-AreEqual $true $container.ImmutabilityPolicy.AllowProtectedAppendWritesAll

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
		
		# Enable and Disable Blob Delete Retention Policy
		$policy = Enable-AzStorageBlobDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -PassThru -RetentionDays 3 -AllowPermanentDelete
		Assert-AreEqual $true $policy.Enabled
		Assert-AreEqual 3 $policy.Days
		Assert-AreEqual $true $policy.AllowPermanentDelete
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
        Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableChangeFeed $true -IsVersioningEnabled $true
        # If record, need sleep before enable the blob restore policy, or will get server error
        # sleep 100 
        Enable-AzStorageBlobRestorePolicy -ResourceGroupName $rgname -StorageAccountName $stoname -RestoreDays 4
        $property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
        #Assert-AreEqual $true $property.ChangeFeed.Enabled
        Assert-AreEqual $true $property.DeleteRetentionPolicy.Enabled
        Assert-AreEqual 5 $property.DeleteRetentionPolicy.Days
        Assert-AreEqual $true $property.RestorePolicy.Enabled
        Assert-AreEqual 4 $property.RestorePolicy.Days

        # restore blobs by -asjob
        $range1 = New-AzStorageBlobRangeToRestore -StartRange container1/blob1 -EndRange container2/blob2
        $range2 = New-AzStorageBlobRangeToRestore -StartRange container3/blob3 -EndRange ""
        sleep 2
        $job = Restore-AzStorageBlobRange -ResourceGroupName $rgname -StorageAccountName $stoname -TimeToRestore (Get-Date).AddSeconds(-1) -BlobRestoreRange $range1,$range2 -WaitForComplete -asjob

        # Get  Storage Account with Blob Restore Status
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeBlobRestoreStatus

        # wait for restore job finish, and check Blob Restore Status in Storage Account	
        $job | Wait-Job
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeBlobRestoreStatus
        # Assert-AreEqual "Complete" $stos.BlobRestoreStatus.Status

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
Test StorageAccount Object Replication
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobORS
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname1 = 'sto' + $rgname + 'src';
        $stoname2 = 'sto' + $rgname + 'dest';
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'
	
        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $sto1 = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname1 -Location $loc -Type $stotype -Kind $kind 
        $sto2 = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname2 -Location $loc -Type $stotype -Kind $kind 
		Assert-Null $sto1.AllowCrossTenantReplication
		Assert-Null $sto2.AllowCrossTenantReplication
		
		# Enable Blob Enable Changefeed and versioning
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname1 -EnableChangeFeed $true -IsVersioningEnabled $true
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname2 -EnableChangeFeed $true -IsVersioningEnabled $true
		$property1 = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname1
		Assert-AreEqual $true $property1.ChangeFeed.Enabled
		Assert-AreEqual $true $property1.IsVersioningEnabled 
		$property2 = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname2
		Assert-AreEqual $true $property2.ChangeFeed.Enabled
		Assert-AreEqual $true $property2.IsVersioningEnabled 

		# create containers		
		Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname1  | New-AzRmStorageContainer -name src
		Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname2 | New-AzRmStorageContainer -name dest
		Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname1  | New-AzRmStorageContainer -name src1
		Get-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname2 | New-AzRmStorageContainer -name dest1

		# create rules
		$minCreationTime = "2019-01-01T16:00:00Z"
		$rule1 = New-AzStorageObjectReplicationPolicyRule -SourceContainer src1 -DestinationContainer dest1 
		$rule2 = New-AzStorageObjectReplicationPolicyRule -SourceContainer src -DestinationContainer dest -MinCreationTime $minCreationTime -PrefixMatch a,abc,dd #-Tag t1,t2,t3 

		# set policy to dest account
		$destPolicy = Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2 -PolicyId default -SourceAccount $stoname1  -Rule $rule1,$rule2
		$policyID = $destPolicy.PolicyId
		Assert-AreEqual $stoname1 $destPolicy.SourceAccount
		Assert-AreEqual $stoname2 $destPolicy.DestinationAccount
		Assert-AreEqual 2 $destPolicy.Rules.Count
		Assert-AreEqual src1 $destPolicy.Rules[0].SourceContainer
		Assert-AreEqual dest1 $destPolicy.Rules[0].DestinationContainer
		Assert-AreEqual $null $destPolicy.Rules[0].Filters
		Assert-AreEqual src $destPolicy.Rules[1].SourceContainer
		Assert-AreEqual dest $destPolicy.Rules[1].DestinationContainer
		Assert-AreEqual 3 $destPolicy.Rules[1].Filters.PrefixMatch.Count
		Assert-AreEqual $minCreationTime ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")
		$destPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2 -PolicyId $destPolicy.PolicyId
		Assert-AreEqual $policyID $destPolicy.PolicyId
		Assert-AreEqual $stoname1 $destPolicy.SourceAccount
		Assert-AreEqual $stoname2 $destPolicy.DestinationAccount
		Assert-AreEqual 2 $destPolicy.Rules.Count
		Assert-AreEqual src1 $destPolicy.Rules[0].SourceContainer
		Assert-AreEqual dest1 $destPolicy.Rules[0].DestinationContainer
		Assert-AreEqual $null $destPolicy.Rules[0].Filters
		Assert-AreEqual src $destPolicy.Rules[1].SourceContainer
		Assert-AreEqual dest $destPolicy.Rules[1].DestinationContainer
		Assert-AreEqual 3 $destPolicy.Rules[1].Filters.PrefixMatch.Count
		Assert-AreEqual $minCreationTime ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")

		#Set policy to source account
		Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname1 -InputObject $destPolicy
		$srcPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname1
		Assert-AreEqual $policyID $srcPolicy.PolicyId
		Assert-AreEqual $stoname1 $srcPolicy.SourceAccount
		Assert-AreEqual $stoname2 $srcPolicy.DestinationAccount
		Assert-AreEqual 2 $srcPolicy.Rules.Count
		Assert-AreEqual src1 $srcPolicy.Rules[0].SourceContainer
		Assert-AreEqual dest1 $srcPolicy.Rules[0].DestinationContainer
		Assert-AreEqual $null $srcPolicy.Rules[0].Filters
		Assert-AreEqual src $srcPolicy.Rules[1].SourceContainer
		Assert-AreEqual dest $srcPolicy.Rules[1].DestinationContainer
		Assert-AreEqual 3 $srcPolicy.Rules[1].Filters.PrefixMatch.Count
		Assert-AreEqual $minCreationTime ($srcPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")
		$destPolicy | Remove-AzStorageObjectReplicationPolicy 
		$srcPolicy | Remove-AzStorageObjectReplicationPolicy 

		# disable AllowCrossTenantReplication
		$sto1 = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname1  -AllowCrossTenantReplication $false -EnableHttpsTrafficOnly $true 
		$sto2 = Set-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $stoname2 -AllowCrossTenantReplication $false -EnableHttpsTrafficOnly $true 
		Assert-AreEqual $false $sto1.AllowCrossTenantReplication
		Assert-AreEqual $false $sto2.AllowCrossTenantReplication

		# Set policy with source account resourceID
		Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2 -PolicyId default -SourceAccount $sto1.Id  -Rule $rule1,$rule2		
		$destPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2
		$policyID = $destPolicy.PolicyId
		Assert-AreEqual $sto1.Id $destPolicy.SourceAccount
		Assert-AreEqual $sto2.Id $destPolicy.DestinationAccount
		Assert-AreEqual 2 $destPolicy.Rules.Count
		Assert-AreEqual src1 $destPolicy.Rules[0].SourceContainer
		Assert-AreEqual dest1 $destPolicy.Rules[0].DestinationContainer
		Assert-AreEqual $null $destPolicy.Rules[0].Filters
		Assert-AreEqual src $destPolicy.Rules[1].SourceContainer
		Assert-AreEqual dest $destPolicy.Rules[1].DestinationContainer
		Assert-AreEqual 3 $destPolicy.Rules[1].Filters.PrefixMatch.Count
		Assert-AreEqual $minCreationTime ($destPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")

		Set-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname1 -InputObject $destPolicy
		$srcPolicy = Get-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname1
		Assert-AreEqual $policyID $srcPolicy.PolicyId
		Assert-AreEqual $sto1.Id $srcPolicy.SourceAccount
		Assert-AreEqual $sto2.Id $srcPolicy.DestinationAccount
		Assert-AreEqual 2 $srcPolicy.Rules.Count
		Assert-AreEqual src1 $srcPolicy.Rules[0].SourceContainer
		Assert-AreEqual dest1 $srcPolicy.Rules[0].DestinationContainer
		Assert-AreEqual $null $srcPolicy.Rules[0].Filters
		Assert-AreEqual src $srcPolicy.Rules[1].SourceContainer
		Assert-AreEqual dest $srcPolicy.Rules[1].DestinationContainer
		Assert-AreEqual 3 $srcPolicy.Rules[1].Filters.PrefixMatch.Count
		Assert-AreEqual $minCreationTime ($srcPolicy.Rules[1].Filters.MinCreationTime.ToUniversalTime().ToString("s")+"Z")

		#remove policies		
		Remove-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname2 -PolicyId $destPolicy.PolicyId
		Remove-AzStorageObjectReplicationPolicy -ResourceGroupName $rgname -StorageAccountName $stoname1 -PolicyId $srcPolicy.PolicyId
		
        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname1;
        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname2;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test StorageAccount ChangeFeed
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobChangeFeed
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
		
		# Enable Blob  Changefeed 
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableChangeFeed $true -ChangeFeedRetentionInDays 5
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $true $property.ChangeFeed.Enabled
		Assert-AreEqual 5 $property.ChangeFeed.RetentionInDays

		# Disable Blob  Changefeed 
		Update-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableChangeFeed $false
		$property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual $false $property.ChangeFeed.Enabled
		Assert-AreEqual $null $property.ChangeFeed.RetentionInDays

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
Test StorageAccount Blob Container SoftDelete in Service Properties
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobContainerSoftDelete
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation_Canary ResourceManagement;
        $kind = 'StorageV2'
	
        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

        # Enable Blob Delete Retention Policy
        $policy = Enable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -PassThru -RetentionDays 30 
        Assert-AreEqual $true $policy.Enabled
        Assert-AreEqual 30 $policy.Days
        $property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
        Assert-AreEqual $true $property.ContainerDeleteRetentionPolicy.Enabled
        Assert-AreEqual 30 $property.ContainerDeleteRetentionPolicy.Days

        # Create and delete container, then get container
        $contaierName = "testcontaienr"
        New-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $contaierName 
        Remove-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $contaierName -Force
        $cons = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname
        Assert-AreEqual 0 $cons.Count
        $cons = Get-AzRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeDeleted
        Assert-AreEqual 1 $cons.Count
        Assert-AreEqual $contaierName $cons[0].Name
        Assert-AreEqual $true $cons[0].Deleted


        # Disable Blob Delete Retention Policy
        $policy = Disable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -PassThru
        Assert-AreEqual $false $policy.Enabled
        $property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
        Assert-AreEqual $false $property.ContainerDeleteRetentionPolicy.Enabled

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
Test StorageAccount Blob LastAccessTimeTracking
.DESCRIPTION
SmokeTest
#>
function Test-StorageBlobLastAccessTimeTracking
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
		
        $loc = Get-ProviderLocation_canary ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
		
        # Enable Blob LastAccessTimeTracking
        $policy = Enable-AzStorageBlobLastAccessTimeTracking -ResourceGroupName $rgname -StorageAccountName $stoname -PassThru
        Assert-AreEqual $true $policy.Enable
        $property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
        Assert-AreEqual $true $property.LastAccessTimeTrackingPolicy.Enable

        # set management policy
        $action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
        $action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToArchive -DaysAfterLastAccessTimeGreaterThan 50  -InputObject $action
        $action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToCool -DaysAfterLastAccessTimeGreaterThan 30  -EnableAutoTierToHotFromCool -InputObject $action
        $action = Add-AzStorageAccountManagementPolicyAction -SnapshotAction Delete -daysAfterCreationGreaterThan 100 -InputObject $action
        $filter = New-AzStorageAccountManagementPolicyFilter -PrefixMatch prefix1,prefix2
        $rule = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action -Filter $filter
        $policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname -Rule $rule
        Assert-AreEqual $true $policy.Rules[0].Definition.Actions.BaseBlob.EnableAutoTierToHotFromCool
        Assert-AreEqual  30 $policy.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterLastAccessTimeGreaterThan
        Assert-AreEqual  50 $policy.Rules[0].Definition.Actions.BaseBlob.TierToArchive.DaysAfterLastAccessTimeGreaterThan
        Assert-AreEqual  100 $policy.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan

        # remove management policy
        Remove-AzStorageAccountManagementPolicy -ResourceGroupName $rgname -StorageAccountName $stoname 

        # Disable Blob LastAccessTimeTracking
        $policy = Disable-AzStorageBlobLastAccessTimeTracking -ResourceGroupName $rgname -StorageAccountName $stoname -PassThru
        # Assert-AreEqual $true (($policy.Enable -eq $false) -or ($policy -eq $null))
        $property = Get-AzStorageBlobServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname
        #Assert-AreEqual $true (($property.LastAccessTimeTrackingPolicy.Enable -eq $false) -or ($property.LastAccessTimeTrackingPolicy -eq $null))
        # Assert-AreEqual $false $property.LastAccessTimeTrackingPolicy.Enable

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}






