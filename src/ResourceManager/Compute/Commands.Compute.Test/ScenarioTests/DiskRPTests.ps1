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
Test Add Vhd
#>
function Test-Disk
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
	$diskname = 'disk' + $rgname;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;
		$subId = Get-SubscriptionIdFromResourceGroup $rgname;
		$mockkey = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/TestVault123';
		$access = 'Read';

        # Config create test
		$diskconfig = New-AzureRmDiskConfig -Location $loc -DiskSizeGB 5 -AccountType StandardLRS -OsType Windows -CreateOption Empty;
		$diskconfig = Set-AzureRmDiskDiskEncryptionKey -Disk $diskconfig;
		$diskconfig = Set-AzureRmDiskKeyEncryptionKey -Disk $diskconfig;
		New-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname -Disk $diskconfig;
		
		#Get disk test
		Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname;

		#Grant access test
		Grant-AzureRmDiskAccess -ResourceGroupName $rgname -DiskName $diskname -Access 'Read' -DurationInSecond 5;
		Revoke-AzureRmDiskAccess -ResourceGroupName $rgname -DiskName $diskname;

		#Config update test
		$updateconfig = New-AzureRmDiskConfig -Location $loc;
		$updateconfig = New-AzureRmDiskUpdateConfig -DiskSizeGB 10 -AccountType PremiumLRS -OsType Windows -CreateOption Empty;
		Update-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname -DiskUpdate $updateconfig;
		
		#Remove
		Remove-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}