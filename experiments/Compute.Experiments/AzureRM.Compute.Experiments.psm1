function New-AzVm {
    # Images
    Write-Host "Load images..."
    $jsonImages = Get-Content -Path "images.json" | ConvertFrom-Json
    Write-Host "done"

    # an array of @{ Type = ...; Name = ...; Image = ... }
    $images = $jsonImages.outputs.aliases.value.psobject.Properties | ForEach-Object {
        # e.g. "Linux"
        $type = $_.Name
        $_.Value.psobject.Properties | ForEach-Object {
            New-Object -TypeName psobject -Property @{
                # e.g. "Linux"
                Type = $type;
                # e.g. "CentOs"
                Name = $_.Name;
                # e.g. @{ publisher = "OpenLogic"; offer = "CentOS"; sku = "7.3"; version = "latest" }
                Image = $_.Value
            }
        }
    }

    # Find VM Image
    $vmImageName = "Win2012R2Datacenter"
    $vmImage = $images | Where-Object { $_.Name -eq $vmImageName } | Select-Object -First 1

    Write-Host $vmImage

    # Location
    Write-Host "Load locations..."
    $location = (Get-AzureRmLocation | Select-Object -First 1 -Wait).Location
    $location = "eastus"
    Write-Host "done"

    # Resource Group
    $resourceGroupName = "resourceGroupTest"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Virtual Network
    $virtualNetworkName = "virtualNetworkTest"
    $virtualNetworkAddressPrefix = "192.168.0.0/16"
    $subnet = @{ Name = "subnetTest"; AddressPrefix = "192.168.1.0/24" }
    $subnetConfig = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet.Name -AddressPrefix $subnet.AddressPrefix
    $virtualNetwork = New-AzureRmVirtualNetwork `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -Name $virtualNetworkName `
        -AddressPrefix $virtualNetworkAddressPrefix `
        -Subnet $subnetConfig

    # Piblic IP
    $publicIpAddressName = "publicIpAddressTest"
    $publicIpAddress = New-AzureRmPublicIpAddress `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -AllocationMethod Static `
        -Name $publicIpAddressName

    # Security Group (it may have several rules(ports))
    $securityGroupName = "securityGroupTest"
    $securityRule = @{
        Name = "securityRuleTest";
        Protocol = "Tcp";
        Priority = 1000;
        Access = "Allow";
        Direction = "Inbound";
        SourcePortRange = "*";
        SourceAddressPrefix = "*";
        DestinationPortRange = 3389;
        DestinationAddressPrefix = "*";
    }
    $securityRuleConfig = New-AzureRmNetworkSecurityRuleConfig `
        -Name $securityRule.Name `
        -Protocol $securityRule.Protocol `
        -Priority $securityRule.Priority `
        -Access $securityRule.Access `
        -Direction $securityRule.Direction `
        -SourcePortRange $securityRule.SourcePortRange `
        -SourceAddressPrefix $securityRule.SourceAddressPrefix `
        -DestinationPortRange $securityRule.DestinationPortRange `
        -DestinationAddressPrefix $securityRule.DestinationAddressPrefix
    $securityGroup = New-AzureRmNetworkSecurityGroup `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -Name $securityGroupName `
        -SecurityRules $securityRuleConfig

    # Network Interface
    $networkInterfaceName = "networkInterfaceTest"
    $networkInterface = New-AzureRmNetworkInterface `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -Name $networkInterfaceName `
        -PublicIpAddressId $publicIpAddress.Id `
        -SubnetId $virtualNetwork.Subnets[0].Id `
        -NetworkSecurityGroupId $securityGroup.Id

    # VM
    # $vmCredentials = Get-Credential
    $vm = @{ Name = "vmTest"; Size = "Standard_DS2" }
    $vmConfig = New-AzureRmVMConfig -VMName $vm.Name -VMSize $vm.Size
    $vmComputer = $vm.Name
    $vmComputerPassword = "E5v7e9!@%f";
    $vmComputerUser = "special";
    switch ($vmImage.Type) {
        "Windows" {
            $password = ConvertTo-SecureString $vmComputerPassword -AsPlainText -Force;
            $cred = New-Object System.Management.Automation.PSCredential ($vmComputerUser, $password);
            $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                -Windows `
                -ComputerName $vmComputer `
                -Credential $cred
        }
        "Linux" {

        }
    }

    $vmImageImage = $vmImage.Image
    Write-Host $vmImageImage
    $vmConfig = $vmConfig `
        | Set-AzureRmVMSourceImage `
            -PublisherName $vmImageImage.publisher `
            -Offer $vmImageImage.offer `
            -Skus $vmImageImage.sku `
            -Version $vmImageImage.version `
        | Add-AzureRmVMNetworkInterface -Id $networkInterface.Id

    New-AzureRmVm -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig
}

Export-ModuleMember -Function New-AzVm