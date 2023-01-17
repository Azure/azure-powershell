Invoke-LiveTestScenario -Name "VM.NewVM Test" -Description "Test create new VM" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName

    ## VM Account
    # Credentials for Local Admin account you created in the sysprepped (generalized) vhd image
    $VMLocalAdminUser = "LocalAdminUser"
    $VMLocalAdminSecurePassword = ConvertTo-SecureString "Password" -AsPlainText -Force
    ## Azure Account
    $LocationName = "westus"
    # This a Premium_LRS storage account.
    # It is required in order to run a client VM with efficiency and high performance.
    $StorageAccount = "Mydisk"

    ## VM
    $OSDiskName = "MyClient"
    $ComputerName = "MyClientVM"
    $OSDiskUri = "https://Mydisk.blob.core.windows.net/disks/MyOSDisk.vhd"
    $SourceImageUri = "https://Mydisk.blob.core.windows.net/vhds/MyOSImage.vhd"

    # Modern hardware environment with fast disk, high IOPs performance.
    # Required to run a client VM with efficiency and performance
    $VMSize = "Standard_DS3"
    $OSDiskCaching = "ReadWrite"
    $OSCreateOption = "FromImage"

    ## Networking
    $DNSNameLabel = "mydnsname" # mydnsname.westus.cloudapp.azure.com
    $NetworkName = "MyNet"
    $NICName = "MyNIC"
    $PublicIPAddressName = "MyPIP"
    $SubnetName = "MySubnet"
    $SubnetAddressPrefix = "10.0.0.0/24"
    $VnetAddressPrefix = "10.0.0.0/16"

    $SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix
    $Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroupName -Location $LocationName -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet
    $PIP = New-AzPublicIpAddress -Name $PublicIPAddressName -DomainNameLabel $DNSNameLabel -ResourceGroupName $ResourceGroupName -Location $LocationName -AllocationMethod Dynamic
    $NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $ResourceGroupName -Location $LocationName -SubnetId $Vnet.Subnets[0].Id -PublicIpAddressId $PIP.Id

    $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

    $VirtualMachine = New-AzVMConfig -VMName $name -VMSize $VMSize
    $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate
    $VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id
    $VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name $OSDiskName -VhdUri $OSDiskUri -SourceImageUri $SourceImageUri -Caching $OSDiskCaching -CreateOption $OSCreateOption -Windows

    $actual =  New-AzVM -ResourceGroupName $rgName -Location $LocationName -VM $VirtualMachine -Verbose

    Assert-AreEqual $name $actual.Name
    Assert-AreEqual "MyNIC" $actual.NICName
    Assert-AreEqual "MySubnet" $actual.NICName
}

Invoke-LiveTestScenario -Name "VM.RemoveVM Test" -Description "Test remove VM" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName
    ## VM Account
    # Credentials for Local Admin account you created in the sysprepped (generalized) vhd image
    $VMLocalAdminUser = "LocalAdminUser"
    $VMLocalAdminSecurePassword = ConvertTo-SecureString "Password" -AsPlainText -Force
    ## Azure Account
    $LocationName = "westus"
    # This a Premium_LRS storage account.
    # It is required in order to run a client VM with efficiency and high performance.
    $StorageAccount = "Mydisk"

    ## VM
    $OSDiskName = "MyClient"
    $ComputerName = "MyClientVM"
    $OSDiskUri = "https://Mydisk.blob.core.windows.net/disks/MyOSDisk.vhd"
    $SourceImageUri = "https://Mydisk.blob.core.windows.net/vhds/MyOSImage.vhd"

    # Modern hardware environment with fast disk, high IOPs performance.
    # Required to run a client VM with efficiency and performance
    $VMSize = "Standard_DS3"
    $OSDiskCaching = "ReadWrite"
    $OSCreateOption = "FromImage"

    ## Networking
    $DNSNameLabel = "mydnsname" # mydnsname.westus.cloudapp.azure.com
    $NetworkName = "MyNet"
    $NICName = "MyNIC"
    $PublicIPAddressName = "MyPIP"
    $SubnetName = "MySubnet"
    $SubnetAddressPrefix = "10.0.0.0/24"
    $VnetAddressPrefix = "10.0.0.0/16"

    $SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix
    $Vnet = New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroupName -Location $LocationName -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet
    $PIP = New-AzPublicIpAddress -Name $PublicIPAddressName -DomainNameLabel $DNSNameLabel -ResourceGroupName $ResourceGroupName -Location $LocationName -AllocationMethod Dynamic
    $NIC = New-AzNetworkInterface -Name $NICName -ResourceGroupName $ResourceGroupName -Location $LocationName -SubnetId $Vnet.Subnets[0].Id -PublicIpAddressId $PIP.Id

    $Credential = New-Object System.Management.Automation.PSCredential ($VMLocalAdminUser, $VMLocalAdminSecurePassword);

    $VirtualMachine = New-AzVMConfig -VMName $name -VMSize $VMSize
    $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine -Windows -ComputerName $ComputerName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate
    $VirtualMachine = Add-AzVMNetworkInterface -VM $VirtualMachine -Id $NIC.Id
    $VirtualMachine = Set-AzVMOSDisk -VM $VirtualMachine -Name $OSDiskName -VhdUri $OSDiskUri -SourceImageUri $SourceImageUri -Caching $OSDiskCaching -CreateOption $OSCreateOption -Windows

    New-AzVM -ResourceGroupName $rgName -Location $LocationName -VM $VirtualMachine -Verbose
    Remove-AzVM -ResourceGroupName $rgName -Name $name -Force

    $removedVM = Get-AzVM -ResourceGroupName $rgName -Name $name
    Assert-Null $removedVM

    # purge deleted vault
    Remove-AzVM -ResourceGroupName $rgName -Name $name -Force
}
