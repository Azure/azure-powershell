function New-AzVm {
    [CmdletBinding()]
    param (
        [Parameter()][PSCredential] $Credential,
        [Parameter()][string] $Name = "VM",
        [Parameter()][string] $ImageName = "Win2012R2Datacenter",
        [Parameter()][string] $ResourceGroupName = $Name + "ResourceGroup",
        [Parameter()][string] $Location = "eastus",
        [Parameter()][string] $VirtualNetworkName = $Name + "VirtualNetwork",
        [Parameter()][string] $PublicIpAddressName = $Name + "PublicIpAddress",
        [Parameter()][string] $SecurityGroupName = $Name + "SecurityGroup",
        [Parameter()][string] $NetworkInterfaceName = $Name + "NetworkInterface"
    )

    PROCESS {
        if (-not $Credential) {
            $Credential = Get-Credential
        }

        # Find VM Image
        $vmImage = $images | Where-Object { $_.Name -eq $ImageName } | Select-Object -First 1
        if (-not $vmImage) {
            throw "Unknown image: " + $ImageName
        }

        # Resource Group
        $resourceGroup = Set-ResourceGroup -Name $ResourceGroupName -Location $Location

        # Virtual Network
        $virtualNetworkAddressPrefix = "192.168.0.0/16"
        $subnet = @{ Name = $Name + "Subnet"; AddressPrefix = "192.168.1.0/24" }
        $subnetConfig = New-AzureRmVirtualNetworkSubnetConfig `
            -Name $subnet.Name `
            -AddressPrefix $subnet.AddressPrefix
        $virtualNetwork = New-AzureRmVirtualNetwork `
            -ResourceGroupName $ResourceGroupName `
            -Location $Location `
            -Name $VirtualNetworkName `
            -AddressPrefix $virtualNetworkAddressPrefix `
            -Subnet $subnetConfig

        # Piblic IP
        $publicIpAddress = New-AzureRmPublicIpAddress `
            -ResourceGroupName $ResourceGroupName `
            -Location $Location `
            -AllocationMethod Static `
            -Name $PublicIpAddressName

        # Security Group (it may have several rules(ports))
        $securityRule = @{
            Name = $Name + "SecurityRule";
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
            -ResourceGroupName $ResourceGroupName `
            -Location $Location `
            -Name $SecurityGroupName `
            -SecurityRules $securityRuleConfig

        # Network Interface
        $networkInterface = New-AzureRmNetworkInterface `
            -ResourceGroupName $ResourceGroupName `
            -Location $Location `
            -Name $NetworkInterfaceName `
            -PublicIpAddressId $publicIpAddress.Id `
            -SubnetId $virtualNetwork.Subnets[0].Id `
            -NetworkSecurityGroupId $securityGroup.Id

        # VM
        $vmSize = "Standard_DS2"
        $vmConfig = New-AzureRmVMConfig -VMName $Name -VMSize $vmSize
        $vmComputerName = $Name + "Computer"
        switch ($vmImage.Type) {
            "Windows" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Windows `
                    -ComputerName $vmComputerName `
                    -Credential $Credential
            }
            "Linux" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Linux `
                    -ComputerName $vmComputerName `
                    -Credential $Credential
            }
        }

        $vmImageImage = $vmImage.Image
        $vmConfig = $vmConfig `
            | Set-AzureRmVMSourceImage `
                -PublisherName $vmImageImage.publisher `
                -Offer $vmImageImage.offer `
                -Skus $vmImageImage.sku `
                -Version $vmImageImage.version `
            | Add-AzureRmVMNetworkInterface -Id $networkInterface.Id

        $response = New-AzureRmVm `
            -ResourceGroupName $ResourceGroupName `
            -Location $Location `
            -VM $vmConfig

        New-PsObject @{
            ResourceId = $resourceGroup.ResourceId;
            Response = $response
        }
    }
}

function Set-ResourceGroup {
    param(
        [parameter(Mandatory = $true)][string]$Name,
        [parameter(Mandatory = $true)][string]$Location
    )

    $resourceGroup = Get-AzureRmResourceGroup `
        | Where-Object { $_.ResourceGroupName -eq $Name } `
        | Select-Object -First 1 -Wait;
    if ($resourceGroup) {
        $resourceGroup;
    } else {
        New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location
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