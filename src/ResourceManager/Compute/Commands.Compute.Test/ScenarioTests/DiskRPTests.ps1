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
Testing disk and snapshot commands
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
        $mockkey = 'https://myvault.vault-int.azure-int.net/secrets/123/';
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/TestVault123';
        $access = 'Read';

        # Config create test
        $diskconfig = New-AzureRmDiskConfig -Location $loc -DiskSizeGB 500 -SkuName UltraSSD_LRS -OsType Windows -CreateOption Empty -DiskMBpsReadWrite 8 -DiskIOPSReadWrite 500;
        Assert-AreEqual "UltraSSD_LRS" $diskconfig.Sku.Name;
        Assert-AreEqual 500 $diskconfig.DiskIOPSReadWrite;
        Assert-AreEqual 8 $diskconfig.DiskMBpsReadWrite

        $diskconfig = New-AzureRmDiskConfig -Location $loc -Zone "1" -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -EncryptionSettingsEnabled $true;
        # Encryption test
        $diskconfig = Set-AzureRmDiskDiskEncryptionKey -Disk $diskconfig -SecretUrl $mockkey -SourceVaultId $mocksourcevault;
        $diskconfig = Set-AzureRmDiskKeyEncryptionKey -Disk $diskconfig -KeyUrl $mockkey -SourceVaultId $mocksourcevault;
        Assert-AreEqual $mockkey $diskconfig.EncryptionSettings.DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $diskconfig.EncryptionSettings.DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $diskconfig.EncryptionSettings.KeyEncryptionKey.KeyUrl;
        Assert-AreEqual $mocksourcevault $diskconfig.EncryptionSettings.KeyEncryptionKey.SourceVault.Id;

        # Image test
        $mockimage = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/images/TestImage123';
        $diskconfig = Set-AzureRmDiskImageReference -Disk $diskconfig -Id $mockimage -Lun 0;
        Assert-AreEqual $mockimage $diskconfig.CreationData.ImageReference.Id;
        Assert-AreEqual 0 $diskconfig.CreationData.ImageReference.Lun;

        $diskconfig.EncryptionSettings.Enabled = $false;
        $diskconfig.EncryptionSettings.DiskEncryptionKey = $null;
        $diskconfig.EncryptionSettings.KeyEncryptionKey = $null;
        $diskconfig.CreationData.ImageReference = $null;

        Assert-AreEqual "1" $diskconfig.Zones
        $diskconfig.Zones = $null

        $job = New-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname -Disk $diskconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get disk test
        $disk = Get-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname;
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettings.Enabled;

        # Grant access test
        $job = Grant-AzureRmDiskAccess -ResourceGroupName $rgname -DiskName $diskname -Access $access -DurationInSecond 5 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.AccessSAS;

        $job = Revoke-AzureRmDiskAccess -ResourceGroupName $rgname -DiskName $diskname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        # Config update test
        $updateconfig = New-AzureRmDiskUpdateConfig -DiskSizeGB 10 -AccountType UltraSSD_LRS -OsType Windows -DiskMBpsReadWrite 8 -DiskIOPSReadWrite 500;
        Assert-AreEqual "UltraSSD_LRS" $updateconfig.Sku.Name;
        Assert-AreEqual 500 $updateconfig.DiskIOPSReadWrite;
        Assert-AreEqual 8 $updateconfig.DiskMBpsReadWrite

        $updateconfig = New-AzureRmDiskUpdateConfig -DiskSizeGB 10 -AccountType Premium_LRS -OsType Windows;
        $job = Update-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname -DiskUpdate $updateconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Remove test
        $job = Remove-AzureRmDisk -ResourceGroupName $rgname -DiskName $diskname -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-Snapshot
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $snapshotname = 'snapshot' + $rgname;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mockkey = 'https://myvault.vault-int.azure-int.net/secrets/123/';
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/TestVault123';
        $access = 'Read';

        # Config and create test
        $snapshotconfig = New-AzureRmSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -EncryptionSettingsEnabled $true;

        # Encryption test
        $snapshotconfig = Set-AzureRmSnapshotDiskEncryptionKey -Snapshot $snapshotconfig -SecretUrl $mockkey -SourceVaultId $mocksourcevault;
        $snapshotconfig = Set-AzureRmSnapshotKeyEncryptionKey -Snapshot $snapshotconfig -KeyUrl $mockkey -SourceVaultId $mocksourcevault;
        Assert-AreEqual $mockkey $snapshotconfig.EncryptionSettings.DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshotconfig.EncryptionSettings.DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshotconfig.EncryptionSettings.KeyEncryptionKey.KeyUrl;
        Assert-AreEqual $mocksourcevault $snapshotconfig.EncryptionSettings.KeyEncryptionKey.SourceVault.Id;

        # Image test
        $mockimage = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/images/TestImage123';
        $snapshotconfig = Set-AzureRmSnapshotImageReference -Snapshot $snapshotconfig -Id $mockimage -Lun 0;
        Assert-AreEqual $mockimage $snapshotconfig.CreationData.ImageReference.Id;
        Assert-AreEqual 0 $snapshotconfig.CreationData.ImageReference.Lun;

        $snapshotconfig.EncryptionSettings.Enabled = $false;
        $snapshotconfig.EncryptionSettings.DiskEncryptionKey = $null;
        $snapshotconfig.EncryptionSettings.KeyEncryptionKey = $null;
        $snapshotconfig.CreationData.ImageReference = $null;
        $job = New-AzureRmSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Snapshot $snapshotconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get snapshot test
        $snapshot = Get-AzureRmSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettings.Enabled;

        # Grant access test
        $job = Grant-AzureRmSnapshotAccess -ResourceGroupName $rgname -SnapshotName $snapshotname -Access $access -DurationInSecond 5 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.AccessSAS;

        $job = Revoke-AzureRmSnapshotAccess -ResourceGroupName $rgname -SnapshotName $snapshotname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        # Config update test
        $updateconfig = New-AzureRmSnapshotUpdateConfig -DiskSizeGB 10 -AccountType Premium_LRS -OsType Windows;
        $job = Update-AzureRmSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -SnapshotUpdate $updateconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Remove test
        $job = Remove-AzureRmSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}