Invoke-LiveTestScenario -Name "Operate a virtual machine." -Description "Test creating and removing a virtual machine" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus2"
    $vmName = New-LiveTestResourceName
    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $nicName = New-LiveTestResourceName
    $nsgName = New-LiveTestResourceName
    $computerName = New-LiveTestResourceName
    $osDiskName = New-LiveTestResourceName

    $localAdminName = New-LiveTestResourceName
    $localAdminPassword = ConvertTo-SecureString (New-LiveTestPassword) -AsPlainText -Force
    $localAdminCred = New-Object System.Management.Automation.PSCredential ($localAdminName, $localAdminPassword)

    $snetCfg = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.10.1.0/24 -DefaultOutboundAccess $false
    $vnet = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.10.0.0/16 -Subnet $snetCfg
    $nsgRuleHighRiskPorts = New-AzNetworkSecurityRuleConfig -Name "DenyHighRiskPorts" -Direction Inbound -Priority 101 -Protocol Tcp -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 22, 3389 -Access Deny
    $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgName -Name $nsgName -Location $location -SecurityRules $nsgRuleHighRiskPorts
    $nic = New-AzNetworkInterface -ResourceGroupName $rgName -Name $nicName -Location $location -Subnet $vnet.Subnets[0] -NetworkSecurityGroup $nsg

    $vmCfg = New-AzVMConfig -VMName $vmName -VMSize Standard_D2s_v3
    $vmCfg | Set-AzVMSecurityProfile -SecurityType TrustedLaunch
    $vmCfg | Set-AzVMOSDisk -Name $osDiskName -StorageAccountType StandardSSD_LRS -CreateOption FromImage -DeleteOption Delete
    $vmCfg | Set-AzVMOperatingSystem -Windows -ComputerName $computerName -Credential $localAdminCred -ProvisionVMAgent -EnableAutoUpdate
    $vmCfg | Set-AzVMSourceImage -PublisherName "MicrosoftWindowsServer" -Offer "WindowsServer" -Skus "2022-datacenter-azure-edition-core" -Version "latest"
    $vmCfg | Add-AzVMNetworkInterface -Id $nic.Id -DeleteOption Delete
    $vmCfg | Set-AzVMBootDiagnostic -Disable
    New-AzVM -ResourceGroupName $rgName -Location $location -VM $vmCfg -DisableBginfoExtension

    $actual = Get-AzVM -ResourceGroupName $rgName -Name $vmName

    Assert-NotNull $actual
    Assert-NotNull $actual.NetworkProfile.NetworkInterfaces
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vmName $actual.Name
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual "Standard_D2s_v3" $actual.HardwareProfile.VmSize
    Assert-AreEqual $nic.Id $actual.NetworkProfile.NetworkInterfaces[0].Id
    Assert-AreEqual "TrustedLaunch" $actual.SecurityProfile.SecurityType
    Assert-AreEqual $computerName $actual.OSProfile.ComputerName
    Assert-AreEqual "MicrosoftWindowsServer" $actual.StorageProfile.ImageReference.Publisher
    Assert-AreEqual "WindowsServer" $actual.StorageProfile.ImageReference.Offer
    Assert-AreEqual "2022-datacenter-azure-edition-core" $actual.StorageProfile.ImageReference.Sku
    Assert-AreEqual "latest" $actual.StorageProfile.ImageReference.Version
    Assert-AreEqual $osDiskName $actual.StorageProfile.OsDisk.Name
    Assert-AreEqual "StandardSSD_LRS" $actual.StorageProfile.OsDisk.ManagedDisk.StorageAccountType
    Assert-AreEqual "FromImage" $actual.StorageProfile.OsDisk.CreateOption
    Assert-AreEqual "Delete" $actual.StorageProfile.OsDisk.DeleteOption

    Remove-AzVM -ResourceGroupName $rgName -Name $vmName -Force
    $vm = Get-AzVM -ResourceGroupName $rgName -Name $vmName -ErrorAction SilentlyContinue
    Assert-Null $vm
}

Invoke-LiveTestScenario -Name "Create a managed disk" -Description "Test creating a managed disk" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $diskName = New-LiveTestResourceName
    $diskLocation = "westus"
    $diskSize = 10
    $diskSkuName = "Standard_LRS"

    $diskCfg = New-AzDiskConfig -Location $diskLocation -DiskSizeGB $diskSize -SkuName $diskSkuName -OsType Windows -CreateOption Empty
    New-AzDisk -ResourceGroupName $rgName -DiskName $diskName -Disk $diskCfg | Out-Null
    $actual = Get-AzDisk -ResourceGroupName $rgName -DiskName $diskName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $diskName $actual.Name
    Assert-AreEqual $diskLocation $actual.Location
    Assert-AreEqual $diskSize $actual.DiskSizeGB
    Assert-AreEqual $diskSkuName $actual.Sku.Name
    Assert-AreEqual Windows $actual.OsType
}

Invoke-LiveTestScenario -Name "Update a managed disk" -Description "Test updating an existing managed disk" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $diskName = New-LiveTestResourceName
    $diskLocation = "westus"
    $diskSize = 10
    $diskSizeUpdated = 20
    $diskSkuName = "Standard_LRS"
    $diskSkuNameUpdated = "StandardSSD_LRS"

    $diskCfg = New-AzDiskConfig -Location $diskLocation -DiskSizeGB $diskSize -SkuName $diskSkuName -OsType Windows -CreateOption Empty
    New-AzDisk -ResourceGroupName $rgName -DiskName $diskName -Disk $diskCfg

    $disk = Get-AzDisk -ResourceGroupName $rgName -DiskName $diskName
    $disk.DiskSizeGB = $diskSizeUpdated
    Update-AzDisk -ResourceGroupName $rgName -DiskName $diskName -Disk $disk

    $diskUpdateCfg = New-AzDiskUpdateConfig -SkuName $diskSkuNameUpdated
    Update-AzDisk -ResourceGroupName $rgName -DiskName $diskName -DiskUpdate $diskUpdateCfg

    $actual = Get-AzDisk -ResourceGroupName $rgName -DiskName $diskName
    Assert-NotNull $actual
    Assert-AreEqual $diskSizeUpdated $actual.DiskSizeGB
    Assert-AreEqual $diskSkuNameUpdated $actual.Sku.Name
}

Invoke-LiveTestScenario -Name "Remove a managed disk" -Description "Test removing an existing managed disk" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $diskName = New-LiveTestResourceName
    $diskLocation = "westus"
    $diskSize = 10
    $diskSkuName = "Standard_LRS"

    $diskCfg = New-AzDiskConfig -Location $diskLocation -DiskSizeGB $diskSize -SkuName $diskSkuName -OsType Windows -CreateOption Empty
    New-AzDisk -ResourceGroupName $rgName -DiskName $diskName -Disk $diskCfg
    Remove-AzDisk -ResourceGroupName $rgName -DiskName $diskName -Force

    $actual = Get-AzDisk -ResourceGroupName $rgName -DiskName $diskName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Create a ssh key" -Description "Test creating a ssh key" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $keyName = New-LiveTestResourceName

    New-AzSshKey -ResourceGroupName $rgName -Name $keyName

    $actual = Get-AzSshKey -ResourceGroupName $rgName -Name $keyName
    Assert-NotNull $actual
    Assert-AreEqual $keyName $actual.Name
}

Invoke-LiveTestScenario -Name "Update a ssh key" -Description "Test updating an existing ssh key" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $key1Name = New-LiveTestResourceName
    $key2Name = New-LiveTestResourceName

    $key1 = New-AzSshKey -ResourceGroupName $rgName -Name $key1Name
    $publicKey1 = $key1.publicKey

    $key2 = New-AzSshKey -ResourceGroupname $rgName -Name $key2Name
    $publicKey2 = $key2.publicKey

    Get-AzSshKey -ResourceGroupName $rgName -Name $key1Name | Update-AzSshKey -PublicKey $publicKey2
    Update-AzSshKey -ResourceId $key2.Id -PublicKey $publicKey1

    $actual1 = Get-AzSshKey -ResourceGroupname $rgName -Name $key1Name
    Assert-NotNull $actual1
    Assert-AreEqual $key1Name $actual1.Name
    Assert-AreEqual $publicKey2 $actual1.publicKey

    $actual2 = Get-AzSshKey -ResourceGroupname $rgName -Name $key2Name
    Assert-NotNull $actual2
    Assert-AreEqual $key2Name $actual2.Name
    Assert-AreEqual $publicKey1 $actual2.publicKey
}

Invoke-LiveTestScenario -Name "Delete a ssh key" -Description "Test deleting a ssh key" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $key1Name = New-LiveTestResourceName
    $key2Name = New-LiveTestResourceName

    New-AzSshKey -ResourceGroupName $rgName -Name $key1Name
    Remove-AzSshKey -ResourceGroupName $rgName -name $key1Name
    $actual = Get-AzSshKey -ResourceGroupName $rgName -Name $key1Name -ErrorAction SilentlyContinue
    Assert-Null $actual

    $key2 = New-AzSshKey -ResourceGroupName $rgName -Name $key2Name
    Remove-AzSshKey -ResourceId $key2.Id
    $actual = Get-AzSshKey -ResourceGroupName $rgName -Name $key2Name -ErrorAction SilentlyContinue
    Assert-Null $actual
}
