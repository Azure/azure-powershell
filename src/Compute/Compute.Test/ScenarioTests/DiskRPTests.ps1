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
        $job = New-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Snapshot $snapshotconfig -AsJob;
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
        $job = New-AzSnapshot -ResourceGroupName $rgname -SnapshotName $snapshotname -Snapshot $snapshotconfig -AsJob;
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
        $mockkey1 = "https://kv1psenctest.vault.azure.net:443/keys/kek1psenctest/21571e3773bb4e6495c2d314a3f5de8b";
        $mockkey2 = "https://kv2psenctest.vault.azure.net:443/keys/kek1psenctest/d4bae3704edb4d4da592360a756cd278";

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
            "Key rotation in disk encryption set is not supported in this version."

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
