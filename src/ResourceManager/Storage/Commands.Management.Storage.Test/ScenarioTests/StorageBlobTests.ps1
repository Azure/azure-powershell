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
        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $loc = Get-ProviderLocation_Stage;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;

		New-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
        $publicAccess = 'blob'
		$metadata = @{tag0="value0";tag1="value1";tag2="value2"}

		Update-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -PublicAccess $publicAccess -Metadata $metadata
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
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
		New-AzureRmStorageContainer -StorageAccount $stos -Name $containerName2 -PublicAccess $publicAccess -Metadata $metadata
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName2
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName2 $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual $publicAccess $container.PublicAccess
		Assert-AreEqual $metadata.Count $container.Metadata.Count

		$containers = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 2 $containers.Count
		Assert-AreEqual $containerName  $containers[1].Name
		Assert-AreEqual $containerName2  $containers[0].Name

		Remove-AzureRmStorageContainer -Force -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$containers = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 1 $containers.Count
		Assert-AreEqual $containerName2  $containers[0].Name

		Remove-AzureRmStorageContainer -Force -StorageAccount $stos -Name $containerName2
		$containers = Get-AzureRmStorageContainer -StorageAccount $stos
		Assert-AreEqual 0 $containers.Count

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
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
        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $loc = Get-ProviderLocation_Stage;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;

		New-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
        Add-AzureRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname  -Name $containerName -Tag  tag1,tag2,tag3
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
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

		Remove-AzureRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -Tag tag1,tag2 
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 1 $container.LegalHold.Tags.Count
		Assert-AreEqual "tag3" $container.LegalHold.Tags[0].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].ObjectIdentifier

		Add-AzureRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -Tag tag1
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 2 $container.LegalHold.Tags.Count
		Assert-AreEqual "tag3" $container.LegalHold.Tags[0].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[0].ObjectIdentifier
		Assert-AreEqual "tag1" $container.LegalHold.Tags[1].Tag
		Assert-AreNotEqual $null $container.LegalHold.Tags[1].Timestamp
		Assert-AreNotEqual $null $container.LegalHold.Tags[1].ObjectIdentifier

		Remove-AzureRmStorageContainerLegalHold -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName -Tag tag1,tag3
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 0 $container.LegalHold.Tags.Count

		Remove-AzureRmStorageContainer -Force -StorageAccount $stos -Name $containerName
		$containers = Get-AzureRmStorageContainer -StorageAccount $stos
		Assert-AreEqual 0 $containers.Count

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
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
        $kind = 'Storage'
		$containerName = "container"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzureRmResourceGroup -Name $rgname -Location $loc;

        $loc = Get-ProviderLocation_Stage;
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzureRmStorageAccount -ResourceGroupName $rgname;

		New-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $rgname $container.ResourceGroupName
		Assert-AreEqual $stoname $container.StorageAccountName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $false $container.HasLegalHold
		Assert-AreEqual $false $container.HasImmutabilityPolicy
		Assert-AreEqual none $container.PublicAccess
		
		
        $policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 		
		Assert-AreEqual 0 $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreEqual "" $policy.Etag

		$immutabilityPeriod =3
        Set-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName -ImmutabilityPeriod $immutabilityPeriod
		$policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 1 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		
		$immutabilityPeriod =2
        Set-AzureRmStorageContainerImmutabilityPolicy -inputObject $policy -ImmutabilityPeriod $immutabilityPeriod		
		$policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName		
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 1 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier

        Remove-AzureRmStorageContainerImmutabilityPolicy -inputObject $policy 
		$policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual 0 $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreEqual "" $policy.Etag
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName		
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual 0 $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 0 $container.ImmutabilityPolicy.UpdateHistory.Count
		
		$immutabilityPeriod =7
        Set-AzureRmStorageContainerImmutabilityPolicy -inputObject $policy -ImmutabilityPeriod $immutabilityPeriod
		$policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName	
		Assert-AreEqual $containerName $container.Name
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Unlocked $container.ImmutabilityPolicy.State
		Assert-AreEqual 1 $container.ImmutabilityPolicy.UpdateHistory.Count
		Assert-AreEqual put $container.ImmutabilityPolicy.UpdateHistory[0].Update
		Assert-AreEqual $immutabilityPeriod $container.ImmutabilityPolicy.UpdateHistory[0].ImmutabilityPeriodSinceCreationInDays
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].Timestamp
		Assert-AreNotEqual $null $container.ImmutabilityPolicy.UpdateHistory[0].ObjectIdentifier
		
        Lock-AzureRmStorageContainerImmutabilityPolicy -inputObject $policy -Force
		$policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName
		Assert-AreEqual $immutabilityPeriod $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Locked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
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
        Set-AzureRmStorageContainerImmutabilityPolicy -inputObject $policy -ExtendPolicy -ImmutabilityPeriod $immutabilityPeriod2
		$policy = Get-AzureRmStorageContainerImmutabilityPolicy -ResourceGroupName $rgname -StorageAccountName $stoname  -ContainerName $containerName 
		Assert-AreEqual $immutabilityPeriod2 $policy.ImmutabilityPeriodSinceCreationInDays
		Assert-AreEqual Locked $policy.State
		Assert-AreNotEqual $null $policy.Etag
		$container = Get-AzureRmStorageContainer -ResourceGroupName $rgname -StorageAccountName $stoname -Name $containerName
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

		Remove-AzureRmStorageContainer -Force -StorageAccount $stos -Name $containerName
		$containers = Get-AzureRmStorageContainer -StorageAccount $stos
		Assert-AreEqual 0 $containers.Count

        Remove-AzureRmStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


