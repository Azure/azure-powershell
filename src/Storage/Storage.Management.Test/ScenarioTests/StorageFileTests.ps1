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



