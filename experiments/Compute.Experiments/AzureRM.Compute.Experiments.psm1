function New-AzVm {
    [CmdletBinding()]
    param (
        [PSCredential] $credential,
        [string] $imageName = "Win2012R2Datacenter",
        [string] $name = "vmTest"
    )

    PROCESS {
        if (-not $credential) {
            $credential = Get-Credential
        }

        # Find VM Image
        $vmImageName = $imageName
        $vmImage = $images | Where-Object { $_.Name -eq $vmImageName } | Select-Object -First 1

        Write-Host $vmImage

        # Location
        Write-Host "Load locations..."
        $location = (Get-AzureRmLocation | Select-Object -First 1 -Wait).Location
        $location = "eastus"
        Write-Host "done"

        # Resource Group
        $resourceGroupName = "resourceGroupTest"
        $resource = New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

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
        $vm = @{ Name = $name; Size = "Standard_DS2" }
        $vmConfig = New-AzureRmVMConfig -VMName $vm.Name -VMSize $vm.Size
        $vmComputer = $vm.Name
        switch ($vmImage.Type) {
            "Windows" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Windows `
                    -ComputerName $vmComputer `
                    -Credential $credential
            }
            "Linux" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Linux `
                    -ComputerName $vmComputer `
                    -Credential $credential
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

        New-PsObject @{
            ResourceId = $resource.ResourceId;
            Response = New-AzureRmVm -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig
        }
    }
}

function New-PsObject {
    param([hashtable] $property)

    New-Object psobject -Property $property
}

$staticImages = New-PsObject @{
    Linux = New-PsObject @{
        CentOS = New-PsObject @{
            publisher = "OpenLogic";
            offer = "CentOS";
            sku = "7.3";
            version = "latest";
        };
        CoreOS = New-PsObject @{
            publisher = "CoreOS";
            offer = "CoreOS";
            sku = "Stable";
            version = "latest";
        };
        Debian = New-PsObject @{
            publisher = "credativ";
            offer = "Debian";
            sku = "8";
            version = "latest";
        };
        "openSUSE-Leap" = New-PsObject @{
            publisher = "SUSE";
            offer = "openSUSE-Leap";
            sku = "42.2";
            version = "latest";
        };
        RHEL = New-PsObject @{
            publisher = "RedHat";
            offer = "RHEL";
            sku = "7.3";
            version = "latest";
        };
        SLES = New-PsObject @{
            publisher = "SUSE";
            offer = "SLES";
            sku = "12-SP2";
            version = "latest";
        };
        UbuntuLTS = New-PsObject @{
            publisher = "Canonical";
            offer = "UbuntuServer";
            sku = "16.04-LTS";
            version = "latest";
        };
    };
    Windows = New-PsObject @{
        Win2016Datacenter = New-PsObject @{
            publisher = "MicrosoftWindowsServer";
            offer = "WindowsServer";
            sku = "2016-Datacenter";
            version = "latest";
        };
        Win2012R2Datacenter = New-PsObject @{
            publisher = "MicrosoftWindowsServer";
            offer = "WindowsServer";
            sku = "2012-R2-Datacenter";
            version = "latest";
        };
        Win2012Datacenter = New-PsObject @{
            publisher = "MicrosoftWindowsServer";
            offer = "WindowsServer";
            sku = "2012-Datacenter";
            version = "latest";
        };
        Win2008R2SP1 = New-PsObject @{
            publisher = "MicrosoftWindowsServer";
            offer = "WindowsServer";
            sku = "2008-R2-SP1";
            version = "latest";
        };
    };
}

# Images
# an array of @{ Type = ...; Name = ...; Image = ... }
# $images = $jsonImages.outputs.aliases.value.psobject.Properties | ForEach-Object {
$images = $staticImages.psobject.Properties | ForEach-Object {
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

Export-ModuleMember -Function New-AzVm