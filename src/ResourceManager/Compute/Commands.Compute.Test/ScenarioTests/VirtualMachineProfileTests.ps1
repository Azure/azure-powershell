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
Test Virtual Machine Profile
#>
function Test-VirtualMachineProfile
{
    # VM Profile & Hardware
    $vmsize = 'Standard_A2';
    $vmname = 'pstestvm' + ((Get-Random) % 10000);
    $p = New-AzureRmVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # Network
    $ipname = 'hpfip' + ((Get-Random) % 10000);
    $ipRefUri1 = "https://test.foo.bar/$ipname";
    $nicName = $ipname + 'nic1';
    $publicIPName = $ipname + 'name1';

    $p = Add-AzureRmVMNetworkInterface -VM $p -Id $ipRefUri1;

    $ipname = 'hpfip' + ((Get-Random) % 10000);
    $ipRefUri2 = "https://test.foo.bar/$ipname";
    $p = Add-AzureRmVMNetworkInterface -VM $p -Id $ipRefUri2;

    # Remove all NICs
    $p = $p | Remove-AzureRmVMNetworkInterface;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 0;

    $p = Add-AzureRmVMNetworkInterface -VM $p -Id $ipRefUri1 -Primary;
    $p = Add-AzureRmVMNetworkInterface -VM $p -Id $ipRefUri2;
    $p = Remove-AzureRmVMNetworkInterface -VM $p -Id $ipRefUri2;
        
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $ipRefUri1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Primary $true;

    # Storage
    $stoname = 'hpfteststo' + ((Get-Random) % 10000);
    $stotype = 'Standard_GRS';

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
    $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
    $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

    $p = Set-AzureRmVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption Empty;

    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 0 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 1 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB $null -Lun 2 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
    Assert-Null $p.StorageProfile.DataDisks[2].DiskSizeGB;
    $p = Remove-AzureRmVMDataDisk -VM $p -Name 'testDataDisk3';
        
    Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
    Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
    Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 0;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

    # Remove all data disks
    $p = $p | Remove-AzureRmVMDataDisk;
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 0;

    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 0 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 1 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;

    Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 0;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

    # Windows OS
    $user = "Foo12";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";

    $winRMCertUrl = "http://keyVaultName.vault.azure.net/secrets/secretName/secretVersion";
    $timeZone = "Pacific Standard Time";
    $custom = "echo 'Hello World'";
    $encodedCustom = "ZWNobyAnSGVsbG8gV29ybGQn";

    $p = Set-AzureRmVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -CustomData $custom -WinRMHttp -WinRMHttps -WinRMCertificateUrl $winRMCertUrl -ProvisionVMAgent -EnableAutoUpdate -TimeZone $timeZone;

    # Image Reference
    $imgRef = Get-DefaultCRPWindowsImageOffline -loc $loc;
    $p = ($imgRef | Set-AzureRmVMSourceImage -VM $p);

    $subid = (Get-AzureRmContext).Subscription.SubscriptionId;

    $referenceUri = "/subscriptions/" + $subid + "/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123";
    $certStore = "My";
    $certUrl =  "https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bdd703272";
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri -CertificateStore $certStore -CertificateUrl $certUrl;

    $referenceUri2 = "/subscriptions/" + $subid + "/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault456";
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri2 -CertificateStore $certStore -CertificateUrl $certUrl;

    $certStore2 = "My2";
    $certUrl2 =  "https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bddaaaaaa";
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri -CertificateStore $certStore2 -CertificateUrl $certUrl2;

    $aucSetting = "AutoLogon";
    $aucContent = "<UserAccounts><AdministratorPassword><Value>" + $password + "</Value><PlainText>true</PlainText></AdministratorPassword></UserAccounts>";
    $p = Add-AzureRmVMAdditionalUnattendContent -VM $p -Content $aucContent -SettingName $aucSetting;
    $p = Add-AzureRmVMAdditionalUnattendContent -VM $p -Content $aucContent -SettingName $aucSetting;

    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual $p.OSProfile.AdminPassword $password;
    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;
    Assert-AreEqual $p.OSProfile.Secrets[0].SourceVault.Id $referenceUri;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[0].CertificateStore $certStore;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[0].CertificateUrl $certUrl;
    Assert-AreEqual $p.OSProfile.Secrets[0].SourceVault.Id $referenceUri;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[1].CertificateStore $certStore2;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[1].CertificateUrl $certUrl2;
    Assert-AreEqual $p.OSProfile.Secrets[1].SourceVault.Id $referenceUri2;
    Assert-AreEqual $p.OSProfile.Secrets[1].VaultCertificates[0].CertificateStore $certStore;
    Assert-AreEqual $p.OSProfile.Secrets[1].VaultCertificates[0].CertificateUrl $certUrl;
    Assert-AreEqual $encodedCustom $p.OSProfile.CustomData;

    # Verify WinRM
    Assert-Null $p.OSProfile.WindowsConfiguration.WinRM.Listeners[0].CertificateUrl;
    Assert-AreEqual "http" $p.OSProfile.WindowsConfiguration.WinRM.Listeners[0].Protocol ;
    Assert-AreEqual $winRMCertUrl $p.OSProfile.WindowsConfiguration.WinRM.Listeners[1].CertificateUrl ;
    Assert-AreEqual "https" $p.OSProfile.WindowsConfiguration.WinRM.Listeners[1].Protocol ;

    # Verify Windows Provisioning Setup
    Assert-AreEqual $true $p.OSProfile.WindowsConfiguration.ProvisionVMAgent;
    Assert-AreEqual $true $p.OSProfile.WindowsConfiguration.EnableAutomaticUpdates;
    Assert-AreEqual $timeZone $p.OSProfile.WindowsConfiguration.TimeZone;

    # Verify Additional Unattend Content
    #Assert-AreEqual "Microsoft-Windows-Shell-Setup" $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[0].ComponentName;
    Assert-AreEqual $aucContent $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[0].Content;
    Assert-AreEqual "oobeSystem" $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[0].PassName;
    Assert-AreEqual $aucSetting $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[0].SettingName;
    #Assert-AreEqual "Microsoft-Windows-Shell-Setup" $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[1].ComponentName;
    Assert-AreEqual $aucContent $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[1].Content;
    Assert-AreEqual "oobeSystem" $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[1].PassName;
    Assert-AreEqual $aucSetting $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent[1].SettingName;

    # Linux OS
    $img = "b4590d9e3ed742e4a1d46e5424aa335e__SUSE-Linux-Enterprise-Server-11-SP3-v206";

    $p = Set-AzureRmVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred -CustomData $custom -DisablePasswordAuthentication;

    $imgRef = Get-DefaultCRPLinuxImageOffline -loc $loc;
    $p = ($imgRef | Set-AzureRmVMSourceImage -VM $p);

    $sshPath = "/home/pstestuser/.ssh/authorized_keys";
    $sshPublicKey = "MIIDszCCApugAwIBAgIJALBV9YJCF/tAMA0GCSqGSIb3DQEBBQUAMEUxCzAJBgNV";
    $p = Add-AzureRmVMSshPublicKey -VM $p -KeyData $sshPublicKey -Path $sshPath;
    $p = Add-AzureRmVMSshPublicKey -VM $p -KeyData $sshPublicKey -Path $sshPath;
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri -CertificateStore $certStore -CertificateUrl $certUrl;

    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual $p.OSProfile.AdminPassword $password;

    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

    Assert-AreEqual $p.OSProfile.Secrets[0].SourceVault.Id $referenceUri;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[0].CertificateStore $certStore;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[0].CertificateUrl $certUrl;
    Assert-AreEqual $encodedCustom $p.OSProfile.CustomData;

    # Verify SSH configuration
    Assert-AreEqual $sshPublicKey $p.OSProfile.LinuxConfiguration.Ssh.PublicKeys[0].KeyData;
    Assert-AreEqual $sshPath $p.OSProfile.LinuxConfiguration.Ssh.PublicKeys[0].Path;
    Assert-AreEqual $sshPublicKey $p.OSProfile.LinuxConfiguration.Ssh.PublicKeys[1].KeyData;
    Assert-AreEqual $sshPath $p.OSProfile.LinuxConfiguration.Ssh.PublicKeys[1].Path;
    Assert-AreEqual $true $p.OSProfile.LinuxConfiguration.DisablePasswordAuthentication
}

<#
.SYNOPSIS
Test Virtual Machine Profile without AdditionalUnattendContent
#>
function Test-VirtualMachineProfileWithoutAUC
{
    # VM Profile & Hardware
    $vmsize = 'Standard_A2';
    $vmname = 'pstestvm' + ((Get-Random) % 10000);
    $p = New-AzureRmVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # Network
    $ipname = 'hpfip' + ((Get-Random) % 10000);
    $ipRefUri = "https://test.foo.bar/$ipname";
    $nicName = $ipname + 'nic1';
    $publicIPName = $ipname + 'name1';

    $p = Add-AzureRmVMNetworkInterface -VM $p -Id $ipRefUri;

    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $ipRefUri;

    # Storage
    $stoname = 'hpfteststo' + ((Get-Random) % 10000);
    $stotype = 'Standard_GRS';

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
    $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
    $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

    $dekUri = "https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bddaaaaaa";
    $dekId =  "/subscriptions/" + $subid + "/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123";
    $kekUri = "http://keyVaultName.vault.azure.net/secrets/secretName/secretVersion";
    $kekId = "/subscriptions/" + $subid + "/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123";

    $p = Set-AzureRmVMOSDisk -VM $p -Windows -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption Empty -DiskEncryptionKeyUrl $dekUri -DiskEncryptionKeyVaultId $dekId -KeyEncryptionKeyUrl $kekUri -KeyEncryptionKeyVaultId $kekId;

    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 0 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 1 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
    $p = Add-AzureRmVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 2 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
    $p = Remove-AzureRmVMDataDisk -VM $p -Name 'testDataDisk3';

    Assert-AreEqual $p.StorageProfile.OSDisk.EncryptionSettings.DiskEncryptionKey.SourceVault.Id $dekId
    Assert-AreEqual $p.StorageProfile.OSDisk.EncryptionSettings.DiskEncryptionKey.SecretUrl $dekUri
    Assert-AreEqual $p.StorageProfile.OSDisk.EncryptionSettings.KeyEncryptionKey.SourceVault.Id $kekId
    Assert-AreEqual $p.StorageProfile.OSDisk.EncryptionSettings.KeyEncryptionKey.KeyUrl $kekUri
    Assert-AreEqual $p.StorageProfile.OSDisk.Caching $osDiskCaching;
    Assert-AreEqual $p.StorageProfile.OSDisk.Name $osDiskName;
    Assert-AreEqual $p.StorageProfile.OSDisk.Vhd.Uri $osDiskVhdUri;
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 0;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

    # Windows OS
    $user = "Foo12";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";
    $img = 'a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd';

    $winRMCertUrl = "http://keyVaultName.vault.azure.net/secrets/secretName/secretVersion";
    $timeZone = "Pacific Standard Time";
    $custom = "echo 'Hello World'";
    $encodedCustom = "ZWNobyAnSGVsbG8gV29ybGQn";

    $p = Set-AzureRmVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -CustomData $custom -WinRMHttp -WinRMHttps -WinRMCertificateUrl $winRMCertUrl -ProvisionVMAgent -EnableAutoUpdate -TimeZone $timeZone;

    $imgRef = Get-DefaultCRPWindowsImageOffline -loc $loc;
    $p = ($imgRef | Set-AzureRmVMSourceImage -VM $p);

    $subid = (Get-AzureRmContext).Subscription.SubscriptionId;

    $referenceUri = "/subscriptions/" + $subid + "/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123";
    $certStore = "My";
    $certUrl =  "https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984Assert-True379a7e0230bdd703272";
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri -CertificateStore $certStore -CertificateUrl $certUrl;

    $referenceUri2 = "/subscriptions/" + $subid + "/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault456";
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri2 -CertificateStore $certStore -CertificateUrl $certUrl;

    $certStore2 = "My2";
    $certUrl2 =  "https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bddaaaaaa";
    $p = Add-AzureRmVMSecret -VM $p -SourceVaultId $referenceUri -CertificateStore $certStore2 -CertificateUrl $certUrl2;

    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual $p.OSProfile.AdminPassword $password;

    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

    Assert-AreEqual $p.OSProfile.Secrets[0].SourceVault.Id $referenceUri;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[0].CertificateStore $certStore;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[0].CertificateUrl $certUrl;
    Assert-AreEqual $p.OSProfile.Secrets[0].SourceVault.Id $referenceUri;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[1].CertificateStore $certStore2;
    Assert-AreEqual $p.OSProfile.Secrets[0].VaultCertificates[1].CertificateUrl $certUrl2;
    Assert-AreEqual $p.OSProfile.Secrets[1].SourceVault.Id $referenceUri2;
    Assert-AreEqual $p.OSProfile.Secrets[1].VaultCertificates[0].CertificateStore $certStore;
    Assert-AreEqual $p.OSProfile.Secrets[1].VaultCertificates[0].CertificateUrl $certUrl;
    Assert-AreEqual $encodedCustom $p.OSProfile.CustomData;

    # Verify WinRM
    Assert-Null $p.OSProfile.WindowsConfiguration.WinRM.Listeners[0].CertificateUrl;
    Assert-AreEqual "http" $p.OSProfile.WindowsConfiguration.WinRM.Listeners[0].Protocol ;
    Assert-AreEqual $winRMCertUrl $p.OSProfile.WindowsConfiguration.WinRM.Listeners[1].CertificateUrl ;
    Assert-AreEqual "https" $p.OSProfile.WindowsConfiguration.WinRM.Listeners[1].Protocol ;

    # Verify Windows Provisioning Setup
    Assert-AreEqual $true $p.OSProfile.WindowsConfiguration.ProvisionVMAgent;
    Assert-AreEqual $true $p.OSProfile.WindowsConfiguration.EnableAutomaticUpdates;
    Assert-AreEqual $timeZone $p.OSProfile.WindowsConfiguration.TimeZone;

    # Verify Additional Unattend Content
    Assert-Null $p.OSProfile.WindowsConfiguration.AdditionalUnattendContent "NULL";
    Assert-False {$p.OSProfile.WindowsConfiguration.AdditionalUnattendContent.IsInitialized};
}
