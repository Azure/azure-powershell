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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/TestVault123';
        $mockkey = 'https://myvault.vault-int.azure-int.net/keys/mockkey/00000000000000000000000000000000';
        $mocksecret = 'https://myvault.vault-int.azure-int.net/secrets/mocksecret/00000000000000000000000000000000';
        $access = 'Read';
        $mockGalleryImageId = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/galleries/swaggergallery/images/swaggerimagedef/versions/1.0.0';

        # Config create test
        $diskconfig = New-AzDiskConfig -Location $loc -DiskSizeGB 500 -SkuName UltraSSD_LRS -OsType Windows -CreateOption Empty `
                                       -DiskMBpsReadWrite 8 -DiskIOPSReadWrite 500 -EncryptionType "EncryptionAtRestWithCustomerKey" -DiskEncryptionSetId $encSetId `
                                       -DiskIOPSReadOnly 1000 -DiskMBpsReadOnly 10 -MaxSharesCount 5 `
                                       -GalleryImageReference @{Id=$mockGalleryImageId;Lun=2};

        Assert-AreEqual "UltraSSD_LRS" $diskconfig.Sku.Name;
        Assert-AreEqual 500 $diskconfig.DiskIOPSReadWrite;
        Assert-AreEqual 8 $diskconfig.DiskMBpsReadWrite;
        Assert-AreEqual $encSetId $diskconfig.Encryption.DiskEncryptionSetId;
        Assert-AreEqual "EncryptionAtRestWithCustomerKey" $diskconfig.Encryption.Type;
        Assert-AreEqual 1000 $diskconfig.DiskIOPSReadOnly;
        Assert-AreEqual 10 $diskconfig.DiskMBpsReadOnly;
        Assert-AreEqual 5 $diskconfig.MaxShares;
        Assert-AreEqual $mockGalleryImageId $diskconfig.CreationData.GalleryImageReference.Id;
        Assert-AreEqual 2 $diskconfig.CreationData.GalleryImageReference.Lun;

        $diskconfig = New-AzDiskConfig -Location $loc -Zone "1" -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
                                       -EncryptionSettingsEnabled $true -HyperVGeneration "V1";
        # Encryption test
        $diskconfig = Set-AzDiskDiskEncryptionKey -Disk $diskconfig -SecretUrl $mocksecret -SourceVaultId $mocksourcevault;
        $diskconfig = Set-AzDiskKeyEncryptionKey -Disk $diskconfig -KeyUrl $mockkey -SourceVaultId $mocksourcevault;
        Assert-AreEqual $mocksecret $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;
        Assert-AreEqual $mocksourcevault $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;

        # Image test
        $mockimage = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/images/TestImage123';
        $diskconfig = Set-AzDiskImageReference -Disk $diskconfig -Id $mockimage -Lun 0;
        Assert-AreEqual $mockimage $diskconfig.CreationData.ImageReference.Id;
        Assert-AreEqual 0 $diskconfig.CreationData.ImageReference.Lun;

        $diskconfig.EncryptionSettingsCollection.Enabled = $false;
        $diskconfig.EncryptionSettingsCollection.EncryptionSettings = $null;
        $diskconfig.CreationData.ImageReference = $null;

        Assert-AreEqual "1" $diskconfig.Zones
        $diskconfig.Zones = $null

        $job = New-AzDisk -ResourceGroupName $rgname -DiskName $diskname -Disk $diskconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get disk test
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($diskname -replace ".$") + "*"

        $disk = Get-AzDisk
        Assert-True { $disk.Count -ge 1 }
        
        $disk = Get-AzDisk -ResourceGroupName $rgname
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $disk.DiskSizeBytes;

        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -ResourceGroupName $wildcardRgQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $disk.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -Name $diskname
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $disk.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -Name $wildcardNameQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $disk.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -ResourceGroupName $wildcardRgQuery -Name $diskname
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -ResourceGroupName $wildcardRgQuery -Name $wildcardNameQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $disk.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -ResourceGroupName $rgname -Name $wildcardNameQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname;
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $disk.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $false $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual "V1" $disk.HyperVGeneration;

        # Grant access test
        $job = Grant-AzDiskAccess -ResourceGroupName $rgname -DiskName $diskname -Access $access -DurationInSecond 5 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.AccessSAS;

        $job = Revoke-AzDiskAccess -ResourceGroupName $rgname -DiskName $diskname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        # Config update test
        $encSetId = "fakeid";
        $updateconfig = New-AzDiskUpdateConfig -DiskSizeGB 10 -AccountType UltraSSD_LRS -OsType Windows -DiskMBpsReadWrite 8 -DiskIOPSReadWrite 500 `
                                               -EncryptionType "EncryptionAtRestWithCustomerKey" -DiskEncryptionSetId $encSetId;
        Assert-AreEqual "UltraSSD_LRS" $updateconfig.Sku.Name;
        Assert-AreEqual 500 $updateconfig.DiskIOPSReadWrite;
        Assert-AreEqual 8 $updateconfig.DiskMBpsReadWrite;
        Assert-AreEqual $encSetId $updateconfig.Encryption.DiskEncryptionSetId;
        Assert-AreEqual "EncryptionAtRestWithCustomerKey" $updateconfig.Encryption.Type;

        $updateconfig = New-AzDiskUpdateConfig -DiskSizeGB 10 -AccountType Premium_LRS -OsType Windows;
        $job = Update-AzDisk -ResourceGroupName $rgname -DiskName $diskname -DiskUpdate $updateconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname;
        Assert-AreEqual (10 * 1073741824) $disk.DiskSizeBytes;

        # Remove test
        $job = Remove-AzDisk -ResourceGroupName $rgname -DiskName $diskname -Force -AsJob;
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
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/TestVault123';
        $mockkey = 'https://myvault.vault-int.azure-int.net/keys/mockkey/00000000000000000000000000000000';
        $mocksecret = 'https://myvault.vault-int.azure-int.net/secrets/mocksecret/00000000000000000000000000000000';
        $access = 'Read';

        # Config and create test
        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 500 -SkuName UltraSSD_LRS -OsType Windows -CreateOption Empty `
                                               -EncryptionType "EncryptionAtRestWithCustomerKey" -DiskEncryptionSetId $encSetId;
        Assert-AreEqual "UltraSSD_LRS" $snapshotconfig.Sku.Name;
        Assert-AreEqual $encSetId $snapshotconfig.Encryption.DiskEncryptionSetId;
        Assert-AreEqual "EncryptionAtRestWithCustomerKey" $snapshotconfig.Encryption.Type;

        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
                                               -EncryptionSettingsEnabled $true  -HyperVGeneration "V2";

        # Encryption test
        $snapshotconfig = Set-AzSnapshotDiskEncryptionKey -Snapshot $snapshotconfig -SecretUrl $mocksecret -SourceVaultId $mocksourcevault;
        $snapshotconfig = Set-AzSnapshotKeyEncryptionKey -Snapshot $snapshotconfig -KeyUrl $mockkey -SourceVaultId $mocksourcevault;
        Assert-AreEqual $mocksecret $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;
        Assert-AreEqual $mocksourcevault $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;

        # Image test
        $mockimage = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/images/TestImage123';
        $snapshotconfig = Set-AzSnapshotImageReference -Snapshot $snapshotconfig -Id $mockimage -Lun 0;
        Assert-AreEqual $mockimage $snapshotconfig.CreationData.ImageReference.Id;
        Assert-AreEqual 0 $snapshotconfig.CreationData.ImageReference.Lun;

        $snapshotconfig.EncryptionSettingsCollection.Enabled = $false;
        $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings = $null;
        $snapshotconfig.CreationData.ImageReference = $null;
        $job = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Snapshot $snapshotconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get snapshot test
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($snapshotname -replace ".$") + "*"

        $snapshot = Get-AzSnapshot
        Assert-True { $snapshot.Count -ge 1 }

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -ResourceGroupName $wildcardRgQuery
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -SnapshotName $wildcardNameQuery;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -ResourceGroupName $wildcardRgQuery -SnapshotName $wildcardNameQuery;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -ResourceGroupName $wildcardRgQuery -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname -SnapshotName $wildcardNameQuery;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual (5 * 1073741824) $snapshot.DiskSizeBytes;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $false $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual "V2" $snapshot.HyperVGeneration;
        Assert-False {$snapshot.Incremental}

        # Grant access test
        $job = Grant-AzSnapshotAccess -ResourceGroupName $rgname -SnapshotName $snapshotname -Access $access -DurationInSecond 5 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.AccessSAS;

        $job = Revoke-AzSnapshotAccess -ResourceGroupName $rgname -SnapshotName $snapshotname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        # Config update test
        $encSetId = "fakeid";
        $updateconfig = New-AzSnapshotUpdateConfig -EncryptionType "EncryptionAtRestWithCustomerKey" -DiskEncryptionSetId $encSetId;
        Assert-AreEqual $encSetId $updateconfig.Encryption.DiskEncryptionSetId;
        Assert-AreEqual "EncryptionAtRestWithCustomerKey" $updateconfig.Encryption.Type;

        $updateconfig = New-AzSnapshotUpdateConfig -DiskSizeGB 10 -AccountType Premium_LRS -OsType Windows;
        $job = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -SnapshotUpdate $updateconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname;
        Assert-AreEqual (10 * 1073741824) $snapshot.DiskSizeBytes;

        # Remove test
        $job = Remove-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Force -AsJob;
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

function Test-DiskEncrypt
{
    # Setup
    $rgname = 'mytestrg'
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');
    $diskname = 'disk' + $rgname;
    $vaultName = 'kv' + $rgname
    $kekName = 'kek' + $rgname
    $secretname = 'mysecret'
    $secretdata = 'mysecretvalue'
    $securestring = ConvertTo-SecureString $secretdata -Force -AsPlainText

    #
    # Note: In order to record this test, you need to run the following commands to create KeyValut key and KeyVault secret in a separate Powershell window.
    # 
    #New-AzResourceGroup -Name $rgname -Location $loc -Force;
    #$vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $loc -Sku Standard;
    #$userPrincipalName = (Get-AzContext).Account.Id;
    #Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $rgname -UserPrincipalName $userPrincipalName -EnabledForDiskEncryption;
    #$kek = Add-AzKeyVaultKey -VaultName $vaultName -Name $kekName -Destination "Software";
    #$secret = Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretname -SecretValue $securestring;
    #$mockkey = $kek.Id
    #$mocksecret = $secret.Id

    try
    {
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mockkey = "https://kvmytestrg.vault.azure.net:443/keys/kekmytestrg/f97010094ad141daa9c162ebb7651bc0"
        $mocksecret = "https://kvmytestrg.vault.azure.net:443/secrets/mysecret/8c03adb6d78e476b93db022f87b4a1e1"
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName;
        $access = 'Read';

        # Config create test
        $diskconfig = New-AzDiskConfig -Location $loc -DiskSizeGB 500 -SkuName UltraSSD_LRS -OsType Windows -CreateOption Empty -DiskMBpsReadWrite 8 -DiskIOPSReadWrite 500;
        Assert-AreEqual "UltraSSD_LRS" $diskconfig.Sku.Name;
        Assert-AreEqual 500 $diskconfig.DiskIOPSReadWrite;
        Assert-AreEqual 8 $diskconfig.DiskMBpsReadWrite

        $diskconfig = New-AzDiskConfig -Location $loc -Zone "1" -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -EncryptionSettingsEnabled $true;
        # Encryption test
        $diskconfig = Set-AzDiskDiskEncryptionKey -Disk $diskconfig -SecretUrl $mocksecret -SourceVaultId $mocksourcevault;
        $diskconfig = Set-AzDiskKeyEncryptionKey -Disk $diskconfig -KeyUrl $mockkey -SourceVaultId $mocksourcevault;
        Assert-AreEqual $mocksecret $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;
        Assert-AreEqual $mocksourcevault $diskconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;

        # Image test
        $mockimage = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/images/TestImage123';
        $diskconfig = Set-AzDiskImageReference -Disk $diskconfig -Id $mockimage -Lun 0;
        Assert-AreEqual $mockimage $diskconfig.CreationData.ImageReference.Id;
        Assert-AreEqual 0 $diskconfig.CreationData.ImageReference.Lun;
        $diskconfig.CreationData.ImageReference = $null;

        Assert-AreEqual "1" $diskconfig.Zones
        $diskconfig.Zones = $null

        $job = New-AzDisk -ResourceGroupName $rgname -DiskName $diskname -Disk $diskconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get disk test
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($diskname -replace ".$") + "*"

        $disk = Get-AzDisk
        Assert-True { $disk.Count -ge 1 }

        $disk = Get-AzDisk -ResourceGroupName $rgname
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;        
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -ResourceGroupName $wildcardRgQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -Name $diskname
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -Name $wildcardNameQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -ResourceGroupName $wildcardRgQuery -Name $diskname
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -ResourceGroupName $wildcardRgQuery -Name $wildcardNameQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -ResourceGroupName $rgname -Name $wildcardNameQuery
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname;
        Assert-AreEqual $null $disk.Zones;
        Assert-AreEqual 5 $disk.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual Empty $disk.CreationData.CreateOption;
        Assert-AreEqual $true $disk.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $disk.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $disk.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;
        Assert-Null $disk.HyperVGeneration;

        # Grant access test
        $job = Grant-AzDiskAccess -ResourceGroupName $rgname -DiskName $diskname -Access $access -DurationInSecond 5 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.AccessSAS;

        $job = Revoke-AzDiskAccess -ResourceGroupName $rgname -DiskName $diskname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        # Config update test
        $updateconfig = New-AzDiskUpdateConfig -DiskSizeGB 10 -AccountType UltraSSD_LRS -OsType Windows -DiskMBpsReadWrite 8 -DiskIOPSReadWrite 500;
        Assert-AreEqual "UltraSSD_LRS" $updateconfig.Sku.Name;
        Assert-AreEqual 500 $updateconfig.DiskIOPSReadWrite;
        Assert-AreEqual 8 $updateconfig.DiskMBpsReadWrite

        $updateconfig = New-AzDiskUpdateConfig -DiskSizeGB 10 -AccountType Premium_LRS -OsType Windows;
        $job = Update-AzDisk -ResourceGroupName $rgname -DiskName $diskname -DiskUpdate $updateconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Remove test
        $job = Remove-AzDisk -ResourceGroupName $rgname -DiskName $diskname -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;
    }
    finally
    {
        # Cleanup
        #Clean-ResourceGroup $rgname
    }
}

function Test-SnapshotEncrypt
{
    # Setup
    $rgname = 'mytestrg';
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');
    $snapshotname = 'snapshot' + $rgname;
    $vaultName = 'kv' + $rgname
    $kekName = 'kek' + $rgname
    $secretname = 'mysecret'
    $secretdata = 'mysecretvalue'
    $securestring = ConvertTo-SecureString $secretdata -Force -AsPlainText

    #
    # Note: In order to record this test, you need to run the following commands to create KeyValut key and KeyVault secret in a separate Powershell window.
    # 
    #New-AzResourceGroup -Name $rgname -Location $loc -Force;
    #$vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $loc -Sku Standard;
    #$userPrincipalName = (Get-AzContext).Account.Id;
    #Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $rgname -UserPrincipalName $userPrincipalName -EnabledForDiskEncryption;
    #$kek = Add-AzKeyVaultKey -VaultName $vaultName -Name $kekName -Destination "Software";
    #$secret = Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretname -SecretValue $securestring;
    #$mockkey = $kek.Id
    #$mocksecret = $secret.Id

    try
    {
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mockkey = "https://kvmytestrg.vault.azure.net:443/keys/kekmytestrg/f97010094ad141daa9c162ebb7651bc0"
        $mocksecret = "https://kvmytestrg.vault.azure.net:443/secrets/mysecret/8c03adb6d78e476b93db022f87b4a1e1"
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName;
        $access = 'Read';

        # Config and create test
        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty -EncryptionSettingsEnabled $true;

        # Encryption test
        $snapshotconfig = Set-AzSnapshotDiskEncryptionKey -Snapshot $snapshotconfig -SecretUrl $mocksecret -SourceVaultId $mocksourcevault;
        $snapshotconfig = Set-AzSnapshotKeyEncryptionKey -Snapshot $snapshotconfig -KeyUrl $mockkey -SourceVaultId $mocksourcevault;
        Assert-AreEqual $mocksecret $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;
        Assert-AreEqual $mocksourcevault $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;

        # Image test
        $mockimage = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Compute/images/TestImage123';
        $snapshotconfig = Set-AzSnapshotImageReference -Snapshot $snapshotconfig -Id $mockimage -Lun 0;
        Assert-AreEqual $mockimage $snapshotconfig.CreationData.ImageReference.Id;
        Assert-AreEqual 0 $snapshotconfig.CreationData.ImageReference.Lun;

        $snapshotconfig.CreationData.ImageReference = $null;
        $job = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Snapshot $snapshotconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Get snapshot test
        $wildcardRgQuery = ($rgname -replace ".$") + "*"
        $wildcardNameQuery = ($snapshotname -replace ".$") + "*"

        $snapshot = Get-AzSnapshot
        Assert-True { $snapshot.Count -ge 1 }

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -ResourceGroupName $wildcardRgQuery
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -SnapshotName $wildcardNameQuery;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -ResourceGroupName $wildcardRgQuery -SnapshotName $wildcardNameQuery;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -ResourceGroupName $wildcardRgQuery -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname -SnapshotName $wildcardNameQuery;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname;
        Assert-AreEqual 5 $snapshot.DiskSizeGB;
        Assert-AreEqual "Standard_LRS" $snapshot.Sku.Name;
        Assert-AreEqual Windows $snapshot.OsType;
        Assert-AreEqual Empty $snapshot.CreationData.CreateOption;
        Assert-AreEqual $true $snapshot.EncryptionSettingsCollection.Enabled;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mocksecret $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.SecretUrl;
        Assert-AreEqual $mocksourcevault $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.SourceVault.Id;
        Assert-AreEqual $mockkey $snapshot.EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.KeyUrl;
        Assert-Null $snapshot.HyperVGeneration;

        # Grant access test
        $job = Grant-AzSnapshotAccess -ResourceGroupName $rgname -SnapshotName $snapshotname -Access $access -DurationInSecond 5 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Assert-NotNull $st.AccessSAS;

        $job = Revoke-AzSnapshotAccess -ResourceGroupName $rgname -SnapshotName $snapshotname -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        Verify-PSOperationStatusResponse $st;

        # Config update test
        $updateconfig = New-AzSnapshotUpdateConfig -DiskSizeGB 10 -AccountType Premium_LRS -OsType Windows;
        $job = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -SnapshotUpdate $updateconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        # Remove test
        $job = Remove-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Force -AsJob;
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

<#
.SYNOPSIS
Testing disk upload
#>
function Test-DiskUpload
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $diskname0 = 'disk0' + $rgname;
    $diskname1 = 'disk1' + $rgname;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $diskconfig = New-AzDiskConfig -Location $loc -SkuName 'Standard_LRS' -OsType 'Windows' `
                                        -DiskSizeGB 32767 -CreateOption 'Upload';

        New-AzDisk -ResourceGroupName $rgname -DiskName $diskname0 -Disk $diskconfig;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;
        Assert-AreEqual 35183298347520 $disk.CreationData.UploadSizeBytes; # 35,183,298,347,520 = 32,767 * 1,073,741,824 + 512 (for vhd footer)
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual "ReadyToUpload" $disk.DiskState;

        # Update disk
        $disk | Update-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;
        Assert-AreEqual 35183298347520 $disk.CreationData.UploadSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual "ReadyToUpload" $disk.DiskState;

        Remove-AzDisk -ResourceGroupName $rgname -DiskName $diskname0 -Force;

        $diskconfig = New-AzDiskConfig -Location $loc -SkuName 'Standard_LRS' -OsType 'Windows' `
                                       -UploadSizeInBytes 35183298347520 -CreateOption 'Upload';

        New-AzDisk -ResourceGroupName $rgname -DiskName $diskname1 -Disk $diskconfig;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname1;
        Assert-AreEqual 35183298347520 $disk.CreationData.UploadSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual "ReadyToUpload" $disk.DiskState;

        # Update disk
        $disk | Update-AzDisk -ResourceGroupName $rgname -DiskName $diskname1;

        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname1;
        Assert-AreEqual 35183298347520 $disk.CreationData.UploadSizeBytes;
        Assert-AreEqual "Standard_LRS" $disk.Sku.Name;
        Assert-AreEqual Windows $disk.OsType;
        Assert-AreEqual "ReadyToUpload" $disk.DiskState;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Testing disk upload
#>
function Test-DiskEncryptionSet
{
    # Setup
    $loc = "westcentralus";
    $rgname = "psenctest";
    $encryptionName = "enc" + $rgname;

    $vaultName1 = 'kv1' + $rgname ;
    $kekName1 = 'kek1' + $rgname;
    $secretname1 = 'mysecret1';
    $secretdata1 = 'mysecretvalue1';
    $securestring1 = ConvertTo-SecureString $secretdata1 -Force -AsPlainText;

    $vaultName2 = 'kv2' + $rgname ;
    $kekName2 = 'kek1' + $rgname;
    $secretname2 = 'mysecret2';
    $secretdata2 = 'mysecretvalue2';
    $securestring2 = ConvertTo-SecureString $secretdata1 -Force -AsPlainText;

    try
    {
        #
        # Note: In order to record this test, you need to run the following commands to create KeyValut key and KeyVault secret in a separate Powershell window.
        #
        #New-AzResourceGroup -Name $rgname -Location $loc -Force;
        #$vault1 = New-AzKeyVault -VaultName $vaultName1 -ResourceGroupName $rgname -Location $loc -Sku Standard;
        #$vault2 = New-AzKeyVault -VaultName $vaultName2 -ResourceGroupName $rgname -Location $loc -Sku Standard;
        #$mocksourcevault1 = $vault1.ResourceId;
        #$mocksourcevault2 = $vault2.ResourceId;
        #$userPrincipalName = (Get-AzContext).Account.Id;
        #Set-AzKeyVaultAccessPolicy -VaultName $vaultName1 -ResourceGroupName $rgname -EnabledForDiskEncryption;
        #Set-AzKeyVaultAccessPolicy -VaultName $vaultName2 -ResourceGroupName $rgname -EnabledForDiskEncryption;
        #$kek1 = Add-AzKeyVaultKey -VaultName $vaultName1 -Name $kekName1 -Destination "Software";
        #$kek2 = Add-AzKeyVaultKey -VaultName $vaultName2 -Name $kekName2 -Destination "Software";
        #$secret1 = Set-AzKeyVaultSecret -VaultName $vaultName1 -Name $secretname1 -SecretValue $securestring1;
        #$secret2 = Set-AzKeyVaultSecret -VaultName $vaultName2 -Name $secretname2 -SecretValue $securestring2;
        #$mockkey1 = $kek1.Id
        #$mockkey2 = $kek2.Id

        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mockkey1 = "https://kv1psenctest.vault.azure.net/keys/kek1psenctest/7b0ea2a977294b93aa599d15c96a4368";
        $mockkey2 = "https://kv2psenctest.vault.azure.net/keys/kek1psenctest/03684334d612487aa1bd8c9fb5349178";

        $mocksourcevault1 = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName1;
        $mocksourcevault2 = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName2;

        New-AzDiskEncryptionSetConfig -Location $loc -KeyUrl $mockkey1 -SourceVaultId $mocksourcevault1 -IdentityType "SystemAssigned" `
        | New-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionName;

        $encSet = Get-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionName;
        Assert-AreEqual $encryptionName $encSet.Name;
        Assert-AreEqual $loc $encSet.Location;
        Assert-AreEqual "SystemAssigned" $encSet.Identity.Type;
        Assert-NotNull $encSet.Identity.PrincipalId;
        Assert-NotNull $encSet.Identity.TenantId;
        Assert-AreEqual $mockkey1 $encSet.ActiveKey.KeyUrl;
        Assert-AreEqual $mocksourcevault1 $encSet.ActiveKey.SourceVault.Id;
        Assert-AreEqual 0 $encSet.Tags.Count;

        $encSets = Get-AzDiskEncryptionSet -ResourceGroupName $rgname;
        Assert-True {$encSets.Count -ge 1};

        $encSets = Get-AzDiskEncryptionSet;
        Assert-True {$encSets.Count -ge 1};

        $tags = @{test1 = "testval1"; test2 = "testval2" };
        Assert-ThrowsContains { `
            Update-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionName -KeyUrl $mockkey2 -SourceVaultId $mocksourcevault2 -Tag $tags; } `
            "Please grant get, wrap and unwrap key permissions to disk encryption set 'encpsenctest'."
        #    "Key rotation in disk encryption set is not supported in this version."

        Update-AzDiskEncryptionSet -ResourceId $encSet.Id -Tag $tags;

        $encSet = Get-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionName;
        Assert-AreEqual 2 $encSet.Tags.Count;
        Assert-AreEqual "testval1" $encSet.Tags.test1;
        Assert-AreEqual "testval2" $encSet.Tags.test2;

        $tags = @{test1 = "testval2"; test2 = "testval1" };
        $encSet | Update-AzDiskEncryptionSet -KeyUrl $mockkey1 -SourceVaultId $mocksourcevault1 -Tag $tags;

        $encSet = Get-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionName;
        Assert-AreEqual $encryptionName $encSet.Name;
        Assert-AreEqual $loc $encSet.Location;
        Assert-AreEqual "SystemAssigned" $encSet.Identity.Type;
        Assert-NotNull $encSet.Identity.PrincipalId;
        Assert-NotNull $encSet.Identity.TenantId;
        Assert-AreEqual $mockkey1 $encSet.ActiveKey.KeyUrl;
        Assert-AreEqual $mocksourcevault1 $encSet.ActiveKey.SourceVault.Id;
        Assert-AreEqual 2 $encSet.Tags.Count;
        Assert-AreEqual "testval2" $encSet.Tags.test1;
        Assert-AreEqual "testval1" $encSet.Tags.test2;
    }
    finally
    {
        # Cleanup
        $encSet | Remove-AzDiskEncryptionSet -Force;
    }
}

<#
.SYNOPSIS
Testing the EncryptionType parameter passed to the Config obejct is inherited by an associated DiskEncryptionSet object. 
#>
function Test-DiskEncryptionSetConfigEncryptionType
{
    # Setup
    $loc = 'centraluseuap';
    $rgname = 'adamGroupDES7';
    $encryptionName = "enc" + $rgname;

    $vaultName1 = 'kv15' + $rgname ;
    $vaultName2 = 'kv16' + $rgname ;

    try
    {
        <#
        # 
        # Note: In order to record this test, you need to run the following commands to create KeyValut key and KeyVault secret in a separate Powershell window.
        #
        Note: In order to record this test, you need to run the following commands to create KeyValut key and KeyVault secret in a separate Powershell window.
        $vaultName1 = 'kv15' + $rgname ;
        $kekName1 = 'kek15' + $rgname;
        $secretname1 = 'mysecret15';
        $secretdata1 = 'mysecretvalue15';
        $securestring1 = ConvertTo-SecureString $secretdata1 -Force -AsPlainText;

        $vaultName2 = 'kv16' + $rgname;
        $kekName2 = 'kek15' + $rgname; #not a typo
        $secretname2 = 'mysecret16';
        $secretdata2 = 'mysecretvalue16';
        $securestring2 = ConvertTo-SecureString $secretdata1 -Force -AsPlainText;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $vault1 = New-AzKeyVault -VaultName $vaultName1 -ResourceGroupName $rgname -Location $loc -Sku Standard;
        $vault2 = New-AzKeyVault -VaultName $vaultName2 -ResourceGroupName $rgname -Location $loc -Sku Standard;
        $mocksourcevault1 = $vault1.ResourceId;
        $mocksourcevault2 = $vault2.ResourceId;
        $userPrincipalName = (Get-AzContext).Account.Id;
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName1 -ResourceGroupName $rgname -EnabledForDiskEncryption;
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName2 -ResourceGroupName $rgname -EnabledForDiskEncryption;
        $kek1 = Add-AzKeyVaultKey -VaultName $vaultName1 -Name $kekName1 -Destination "Software";
        $kek2 = Add-AzKeyVaultKey -VaultName $vaultName2 -Name $kekName2 -Destination "Software";
        $secret1 = Set-AzKeyVaultSecret -VaultName $vaultName1 -Name $secretname1 -SecretValue $securestring1;
        $secret2 = Set-AzKeyVaultSecret -VaultName $vaultName2 -Name $secretname2 -SecretValue $securestring2;
        $mockkey1 = $kek1.Id
        $mockkey2 = $kek2.Id
        #>

        $mockkey1 = "https://kv15adamgroupdes7.vault.azure.net/keys/kek15adamGroupDES7/74332f302a0e48999415f6f9bbf7430c";
        $mockkey2 = "https://kv16adamgroupdes7.vault.azure.net/keys/kek15adamGroupDES7/84412eaa63f344bf8a1b15612f2b36cb";
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $mocksourcevault1 = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName1;
        $mocksourcevault2 = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName2;

        $encryptionType = "EncryptionAtRestWithPlatformAndCustomerKeys";

        $encSetConfig = New-AzDiskEncryptionSetConfig -Location $loc -EncryptionType $encryptionType;

        $encSetConfigValues = New-AzDiskEncryptionSetConfig -Location $loc -KeyUrl $mockkey1 -SourceVaultId $mocksourcevault1 -EncryptionType $encryptionType -IdentityType "SystemAssigned" `

        $encSet = New-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionName -DiskEncryptionSet $encSetConfigValues;

        Assert-NotNull $encSetConfig;
        Assert-AreEqual $encSetConfig.EncryptionType $encryptionType;

        Assert-NotNull $encSet;
        Assert-AreEqual $encryptionType $encSet.EncryptionType;

        # Test default EncryptionType value
        $encSetConfigDefault = New-AzDiskEncryptionSetConfig -Location $loc -KeyUrl $mockkey2 -SourceVaultId $mocksourcevault2 -IdentityType "SystemAssigned";
        Assert-NotNull $encSetConfigDefault;
        Assert-AreEqual $encSetDefaultConfig.EncryptionType $null;

        $encryptionNameDefault = $encryptionName + "Default";
        $encryptionTypeDefault = "EncryptionAtRestWithCustomerKey";

        $encSetDefault = New-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $encryptionNameDefault -DiskEncryptionSet $encSetConfigDefault;
        Assert-NotNull $encSetDefault;
        Assert-AreEqual $encSetDefault.EncryptionType $encryptionTypeDefault;
        
    }
    finally
    {
        # Cleanup
        $encSet | Remove-AzDiskEncryptionSet -Force;
        $encSetDefault | Remove-AzDiskEncryptionSet -Force;
    }
}

<#
.SYNOPSIS
Testing diskAssess object
#>
function Test-DiskAccessObject
{
    $rgname = Get-ComputeTestResourceName;
    $rgname2 = $rgname + '2';
    $diskname1Rg1 = 'diskaccess1' + $rgname;
    $diskName2Rg1 = 'diskAccess2' + $rgname;
    $diskName3Rg2 = 'diskAccess1' + $rgname2;
    
    try
    {
        # Common
        $loc = "northcentralus";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        New-AzResourceGroup -Name $rgname2 -Location $loc -Force;

        #Create DiskAccess1 in ResourceGroup1
        New-AzDiskAccess -ResourceGroupName $rgname -Name $diskname1Rg1 -location $loc

        #Use Get-AzDiskAccess on DiskAccess1 using Default ParameterSet
        $diskAccess1 = Get-AzDiskAccess -ResourceGroupName $rgname -Name $diskname1Rg1
        #Use Get-AzDiskAccess on DiskAccess1 using resourceId
        $diskAccess1check = Get-AzDiskAccess -resourceId $diskAccess1.id

        #check if diskAccess1 is good
        Assert-NotNull $diskAccess1
        Assert-AreEqual $diskAccess1.Name $diskname1Rg1

        #ASSERT check if diskaccess1 and diskaccess1check are same
        Assert-AreEqual $diskAccess1.id $diskAccess1check.id

        #Create DiskAccess2 in ResourceGroup1
        New-AzDiskAccess -ResourceGroupName $rgname -Name $diskname2Rg1 -location $loc

        #Use Get-AzDiskAccess by resourceGroupName
        $rg1Result = Get-AzDiskAccess -ResourceGroupName $rgname

        Assert-AreEqual $rg1Result.count 2

        #add DiskAccess3 to ResourceGroup2
        New-AzDiskAccess -ResourceGroupName $rgname2 -Name $diskname3Rg2 -location $loc

        #use get-azdiskaccess with no parameters. count should be >= 3
        $allResult = Get-AzDiskAccess

        Assert-True {$allResult.Count -gt 2;}

        #remove-AzDiskAccess to DiskAccess1 by resourceId
        Remove-AzDiskAccess -resourceid $diskAccess1.id
        
        #Remove-AzDiskAccess to DiskAccess2 by default parameter set
        Remove-AzDiskAccess -ResourceGroupName $rgname -Name $diskname2Rg1

        #Get-AzDiskAccess by resource group. Count should be 0
        $allResult = Get-AzDiskAccess -ResourceGroupName $rgname

        Assert-AreEqual $allResult.count 0

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $rgname2
    }
}

<#
.SYNOPSIS
Testing DiskConfig property NetworkAccessPolicy
#>
function Test-DiskConfigDiskAccessNetworkAccess
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $diskname0 = 'disk0' + $rgname;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        #Testing disk access
        $diskAccess = New-AzDiskAccess -ResourceGroupName $rgname -Name "diskaccessname" -location $loc
        $diskconfig = New-AzDiskConfig -Location $loc -SkuName 'Standard_LRS' -OsType 'Windows' `
                                        -UploadSizeInBytes 35183298347520 -CreateOption 'Upload' -DiskAccessId $diskAccess.Id;
        New-AzDisk -ResourceGroupName $rgname -DiskName $diskname0 -Disk $diskconfig;
        $disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;
        
        Assert-AreEqual $diskAccess.Id $disk.DiskAccessId;

        Remove-AzDisk -ResourceGroupName $rgname -DiskName $diskname0 -Force;

        $diskconfig2 = New-AzDiskConfig -Location $loc -SkuName 'Standard_LRS' -OsType 'Windows' `
                                        -UploadSizeInBytes 35183298347520 -CreateOption 'Upload' -NetworkAccessPolicy "AllowAll";
        New-AzDisk -ResourceGroupName $rgname -DiskName $diskname0 -Disk $diskconfig2;
        $disk2 = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname0;
        Assert-AreEqual "AllowAll" $disk2.NetworkAccessPolicy;
    
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Testing SnapshotConfig property NetworkAccessPolicy
#>
function Test-SnapshotConfigDiskAccessNetworkPolicy
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $snapshotname = 'snapshot' + $rgname;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Config and create test
        $diskAccess = New-AzDiskAccess -ResourceGroupName $rgname -Name "diskaccessname" -location $loc

        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty `
                                               -EncryptionSettingsEnabled $true  -HyperVGeneration "V2" -DiskAccessId $diskAccess.Id;

        $snapshotconfig.EncryptionSettingsCollection.Enabled = $false;
        $snapshotconfig.EncryptionSettingsCollection.EncryptionSettings = $null;
        $snapshotconfig.CreationData.ImageReference = $null;
        $job = New-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Snapshot $snapshotconfig -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $snapshot = Get-AzSnapshot -ResourceGroupName $rgname
        Assert-AreEqual $diskAccess.Id $snapshot.DiskAccessId

        # Remove test
        $job = Remove-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Force -AsJob;
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

<#
.SYNOPSIS
Testing the Get-DiskEncryptionSetAssociatedResources cmdlet. 
Creates a DiskEncyptionSet object, 
then associates a disk to it. 
Check with the cmdlet,
add another disk associated to the encryptionset,
then check with the cmdlet again.
#>
function Test-GetDiskEncryptionSetAssociatedResource
{
    # Setup
    $loc = 'eastus';
    $rgname = 'EncSetAssociTest';
    $iteration = '4'
    $vaultName = 'kv'+ $iteration + $rgname ;

    
    try
    {
        # Create keyvault 

        <#
        # Note: In order to record this test, you need to run the following commands to create KeyValut key and KeyVault secret in a separate Powershell window.

        $kekName = 'key' + $iteration + $rgname;
        $secretname = 'mysecret00';
        $secretdata = 'mysecretvalue00';
        $securestring = ConvertTo-SecureString $secretdata -Force -AsPlainText;

        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $loc -Sku Standard -EnablePurgeProtection;
        $mocksourcevault = $vault.ResourceId;
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $rgname -EnabledForDiskEncryption;
        $kek = Add-AzKeyVaultKey -VaultName $vaultName -Name $kekName -Destination "Software";
        $secret = Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretname -SecretValue $securestring;
        $mockkey = $kek.Id

        $sub = Get-AzContext;
        $subId = $sub.Subscription.id;
        $mocksourcevault = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.KeyVault/vaults/' + $vaultName;

        # Create DiskEncyptionSet
        $diskEncryptionSetConfig = New-AzDiskEncryptionSetConfig -Location $loc -KeyUrl $mockkey -SourceVaultId $mocksourcevault -IdentityType "SystemAssigned" 
        $diskEncryptionSetName = "encryptionSet0" + $iteration;
        $diskEncryptionSet = New-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $diskEncryptionSetName -inputobject $diskEncryptionSetConfig

        # set access policy for diskencryptionset in keyvault
        $access = @("get", "wrapkey", "unwrapkey")
        Set-AzKeyVaultAccessPolicy -vaultname $vaultName -objectId $diskEncryptionSet.Identity.PrincipalId -PermissionsToKeys $access

        #>

        $diskEncryptionSetName = "encryptionSet0" + $iteration;
        $diskEncryptionSet = Get-AzDiskEncryptionSet -ResourceGroupName $rgname -Name $diskEncryptionSetName;
        
        # Create a disk and associate it with EncryptionSet
        $diskconfig00 = New-AzDiskConfig -Location $loc -Zone "1" -DiskSizeGB 1 -AccountType "Standard_LRS" -OsType "Windows" -CreateOption "Empty" -HyperVGeneration "V1" -diskencryptionsetid $diskEncryptionSet.id -EncryptionType 'EncryptionAtRestWithCustomerKey';
        $disk00Name = "disk00" + $iteration
        $disk00 = New-AzDisk -ResourceGroupName $rgname -DiskName $disk00Name -Disk $diskconfig00

        # check association
        $res = get-AzDiskEncryptionSetAssociatedResource -resourceGroupName $rgname -diskEncryptionSetName $diskEncryptionSetName;
        Assert-NotNull $res
        Assert-True { $res.count -eq 1}
        Assert-AreEqual $res[0] $disk00.id

        # create another disk without disk encryption set association
        $diskconfig01 = New-AzDiskConfig -Location $loc -Zone "1" -DiskSizeGB 1 -AccountType "Standard_LRS" -OsType "Windows" -CreateOption "Empty" -HyperVGeneration "V1";
        $disk01Name = "disk01" + $iteration
        $disk01 = New-AzDisk -ResourceGroupName $rgname -DiskName $disk01Name -Disk $diskconfig01

        # check association (count still 1)
        $res = get-AzDiskEncryptionSetAssociatedResource -resourceGroupName $rgname -diskEncryptionSetName $diskEncryptionSetName;
        Assert-True {$res.count -eq 1}

        # Update disk to associate with encryptionset
        $diskUpdatedConfig = New-AzDiskUpdateConfig -EncryptionType 'EncryptionAtRestWithCustomerKey' -DiskEncryptionSetId $diskEncryptionSet.Id
        Update-AzDisk -ResourceGroupName $rgname -DiskName $disk01Name -DiskUpdate $diskUpdatedConfig

        # check association (count = 2)
        $res = get-AzDiskEncryptionSetAssociatedResource -resourceGroupName $rgname -diskEncryptionSetName $diskEncryptionSetName;
        Assert-True {$res.count -eq 2}
    }
    finally
    {
        # Cleanup
        # Clean-ResourceGroup $rgname
        Remove-AzDisk -ResourceGroupName $rgName -DiskName $disk00Name -Force
        Remove-AzDisk -ResourceGroupName $rgName -DiskName $disk01Name -Force
    }
}

<#
.SYNOPSIS
Testing the new parameters 
Tier
LogicalSectorSize 
in the New-AzDiskConfig cmdlet.

Testing the new parameters 
Tier 
MaxSharesCount
DiskIOPSReadOnly
DiskMBpsReadOnly
in the New-AzDiskUpdateConfig cmdlet. 
#>
function Test-DiskConfigTierSectorSizeReadOnly
{

        # Setup 
        $rgname = Get-ComputeTestResourceName;
        $loc = "eastus2euap";

        try
        {
            New-AzResourceGroup -Name $rgname -Location $loc -Force;
            $diskNameTier = "datadisktier";
            $diskNameSector = "datadisksector";
            $tier3 = "P3";
            $tier40 = "P40";
            $tier30 = "P30";
            $sectorSize = 512;
            $IoPS1 = 100;
            $IoPS2 = 120;
            $MbPS1 = 3;
            $MbPS2 = 20;
            $maxShares1 = 2;
            $maxShares2 = 3;
            

            $diskTier = New-AzDiskConfig -Location $loc -DiskSizeGB 1024 `
                -SkuName Premium_LRS -OsType Windows -CreateOption Empty -Tier $tier30 -MaxSharesCount $maxShares1 `
                | New-AzDisk -ResourceGroupName $rgname -DiskName $diskNameTier;

            Assert-AreEqual $tier30 $diskTier.Tier; 
            Assert-AreEqual $maxShares1 $diskTier.MaxShares;

            $diskSector = New-AzDiskConfig -Location $loc -DiskSizeGB 5 `
                -SkuName UltraSSD_LRS -OsType Windows -CreateOption Empty -LogicalSectorSize $sectorSize -DiskIOPSReadOnly $IoPS1 -DiskMBpsReadOnly $MbPS1 `
                | New-AzDisk -ResourceGroupName $rgname -DiskName $diskNameSector;

            Assert-AreEqual $diskSector.CreationData.LogicalSectorSize $sectorSize; 

            # New-AzDiskUpdateConfig
            # Tier and MaxShares
            $diskUpdateTierConfig = New-AzDiskUpdateConfig -Tier $tier40 -MaxSharesCount $maxShares2;
            $diskUp = Update-AzDisk -ResourceGroupName $rgname -DiskName $diskNameTier -DiskUpdate $diskUpdateTierConfig;

            $diskUpdated = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskNameTier;

            Assert-AreEqual $tier40 $diskUpdated.Tier; 
            Assert-AreEqual $maxShares2 $diskUpdated.MaxShares; 

            # DiskIOPSReadOnly and DiskMBpsReadOnly
            $diskUpdateReadOnlyConfig = New-AzDiskUpdateConfig -DiskIOPSReadOnly $IoPS2 -DiskMBpsReadOnly $MbPS2;
            $diskUp = Update-AzDisk -ResourceGroupName $rgname -DiskName $diskNameSector -DiskUpdate $diskUpdateReadOnlyConfig;

            $diskUpdated = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskNameSector;
            Assert-AreEqual $IoPS2 $diskUpdated.DiskIOPSReadOnly; 
            Assert-AreEqual $MbPS2 $diskUpdated.DiskMBpsReadOnly; 
		}
        finally 
        {
            # Cleanup
            Clean-ResourceGroup $rgname
		}
}

<#
.SYNOPSIS
Test the New-AzSnapshot cmdlet throws an error when attempting to create a snapshot with 
the same name in the same resource group. 
#>
function Test-SnapshotDuplicateCreationFails
{
    # Setup 
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeVMLocation;

    try
    {
        # Common
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        $snapshotName = "test1";

        $snapshotconfig = New-AzSnapshotConfig -Location $loc -DiskSizeGB 5 -AccountType Standard_LRS -OsType Windows -CreateOption Empty;
        
        $snapshot = New-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotName -Snapshot $snapshotconfig;
        Assert-NotNull $snapshot;

        # Assert duplicate snapshot fails to create.
        Assert-ThrowsContains { $snapshot2 = New-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotName -Snapshot $snapshotconfig; } "Please use Update-AzSnapshot to update an existing Snapshot.";

        # Assert update snapshot succeeds. 
        $snapshotconfig2 = New-AzSnapshotUpdateConfig -DiskSizeGB 10 -AccountType Standard_LRS -OsType Windows;
        $job = Update-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotName -SnapshotUpdate $snapshotconfig2 -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}