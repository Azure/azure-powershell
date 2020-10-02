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
Test Storage File Share
.DESCRIPTION
SmokeTest
#>
function Test-StorageFileShare
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
		$shareName = "share"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		
        $quotaGiB = 100
		$metadata = @{tag0="value0";tag1="value1"} 

		Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName -QuotaGiB $quotaGiB -Metadata $metadata
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual $quotaGiB $share.QuotaGiB
		Assert-AreEqual $metadata.Count $share.Metadata.Count		
		
        $quotaGiB = 200
		$metadata = @{tag0="value0";tag1="value1";tag2="value2"} 
		$share | Update-AzRmStorageShare -QuotaGiB $quotaGiB -Metadata $metadata
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual $quotaGiB $share.QuotaGiB
		Assert-AreEqual $metadata.Count $share.Metadata.Count
		
        $quotaGiB = 300
		$metadata = @{tag0="value0";tag1="value1";tag2="value2";tag3="value3"}
		$shareName2 = "share2"+ $rgname		
		$stos | New-AzRmStorageShare -Name $shareName2 -QuotaGiB $quotaGiB -Metadata $metadata
		$share = $stos | Get-AzRmStorageShare -Name $shareName2
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName2 $share.Name
		Assert-AreEqual $quotaGiB $share.QuotaGiB
		Assert-AreEqual $metadata.Count $share.Metadata.Count

		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 2 $shares.Count
		Assert-AreEqual $shareName  $shares[1].Name
		Assert-AreEqual $shareName2  $shares[0].Name

		Remove-AzRmStorageShare -Force -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 1 $shares.Count
		Assert-AreEqual $shareName2  $shares[0].Name

		$stos  | Get-AzRmStorageShare -Name $shareName2 | Remove-AzRmStorageShare -Force 
		$shares = Get-AzRmStorageShare -StorageAccount $stos
		Assert-AreEqual 0 $shares.Count

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-StorageFileShareGetUsage
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
		$shareName = "share"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		
        # Get share usage
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName -GetShareUsage
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual 0 $share.ShareUsageBytes
		Assert-AreEqual $null $share.Deleted


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
Test Storage File Share Soft Delete
.DESCRIPTION
SmokeTest
#>
function Test-ShareSoftDelete
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
		$shareName1 = "share1"+ $rgname
		$shareName2 = "share2"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		# Enable Share Soft delete
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 5 
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual $true $servicePropertie.ShareDeleteRetentionPolicy.Enabled
		Assert-AreEqual 5 $servicePropertie.ShareDeleteRetentionPolicy.Days

		#create Shares
		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName1 $share.Name
		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName2
		
		#delete share
		Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Force

		#list share check
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeDeleted
		$deletedShareVersion = $share[0].Version
		Assert-AreEqual 2 $share.Count
		Assert-AreEqual $shareName1 $share[0].Name
		Assert-AreEqual $null $share[0].ShareUsageBytes
		Assert-AreEqual $true $share[0].Deleted
		Assert-AreNotEqual $null $share[0].DeletedTime
		Assert-AreNotEqual $null $share[0].Version	
		Assert-AreEqual $shareName2 $share[1].Name
		Assert-AreEqual $null $share[1].Deleted
		Assert-AreEqual $null $share[1].DeletedTime
		Assert-AreEqual $null $share[1].Version

		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 1 $share.Count
		Assert-AreEqual $shareName2 $share[0].Name
		Assert-AreEqual $null $share[0].Deleted
		Assert-AreEqual $null $share[0].DeletedTime
		Assert-AreEqual $null $share[0].Version

		# restore share and check
		if ($env:AZURE_TEST_MODE -eq "Record")
		{
			# sleep 1 miniute if record. Don't need sleep in replay
			sleep 60
		}
		Restore-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -DeletedShareVersion $deletedShareVersion	

		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual 2 $share.Count
		Assert-AreEqual $shareName1 $share[0].Name
		Assert-AreEqual $null $share[0].Deleted
		Assert-AreEqual $null $share[0].DeletedTime
		Assert-AreEqual $null $share[0].Version	
		Assert-AreEqual $shareName2 $share[1].Name
		Assert-AreEqual $null $share[1].Deleted
		Assert-AreEqual $null $share[1].DeletedTime
		Assert-AreEqual $null $share[1].Version		

		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeDeleted
		Assert-AreEqual 2 $share.Count

		# Disable Share Soft delete
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableShareDeleteRetentionPolicy $false
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual $false $servicePropertie.ShareDeleteRetentionPolicy.Enabled

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


