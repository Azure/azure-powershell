Invoke-LiveTestScenario -Name "Creates a virtual machine." -Description "Test create new VM" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName

    $VMLocalAdminUser = New-LiveTestResourceName
    $VMLocalAdminSecurePassword = ConvertTo-SecureString (New-LiveTestPassword) -AsPlainText -Force
    $domainNameLabel = New-LiveTestResourceName
    $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword)
    $text = New-LiveTestResourceName
    $bytes = [System.Text.Encoding]::Unicode.GetBytes($text)
    $userData = [Convert]::ToBase64String($bytes)

    $actual = New-AzVM -ResourceGroupName $rgName -Name $name -Credential $Credential -DomainNameLabel $domainNameLabel -UserData $userData -OpenPorts @()

    Assert-AreEqual $name $actual.Name
    # Assert-AreEqual "Succeeded" Label $actual.ProvisioningState
    # Assert-AreEqual $userData $actual.UserData
}

Invoke-LiveTestScenario -Name "Removes a virtual machine from Azure" -Description "Test removes a virtual machine from Azure." -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName

    $VMLocalAdminUser = New-LiveTestResourceName
    $VMLocalAdminSecurePassword = ConvertTo-SecureString (New-LiveTestPassword) -AsPlainText -Force
    $domainNameLabel = New-LiveTestResourceName
    $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword)
    $text = New-LiveTestResourceName
    $bytes = [System.Text.Encoding]::Unicode.GetBytes($text)
    $userData = [Convert]::ToBase64String($bytes)

    New-AzVM -ResourceGroupName $rgName -Name $name -Credential $Credential -DomainNameLabel $domainNameLabel -UserData $userData -OpenPorts @()
    Remove-AzVM -ResourceGroupName $rgName -Name $name -Force

    $removedVM = Get-AzVM -ResourceGroupName $rgName -Name $name -ErrorAction SilentlyContinue
    Assert-Null $removedVM
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
