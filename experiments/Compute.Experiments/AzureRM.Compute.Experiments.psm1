<#
.ExternalHelp AzureRM.Compute.Experiments-help.xml
#>
function New-AzVm {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory=$true)][string] $Name = "VM",
        [Parameter()][PSCredential] $Credential,
        [Parameter()][string] $ImageName = "Win2012R2Datacenter",
        [Parameter()][string] $ResourceGroupName,
        [Parameter()][string] $Location,
        [Parameter()][string] $VirtualNetworkName,
        [Parameter()][string] $PublicIpAddressName,
        [Parameter()][string] $SecurityGroupName
        # [Parameter()][string] $NetworkInterfaceName
    )

    PROCESS {
        $rgi = [ResourceGroup]::new($ResourceGroupName);
        $vni = [VirtualNetwork]::new($VirtualNetworkName);
        $piai = [PublicIpAddress]::new($PublicIpAddressName);
        $sgi = [SecurityGroup]::new($SecurityGroupName);
        $nii = [NetworkInterface]::new(
            $null, # $NetworkInterfaceName,
            $vni,
            $piai,
            $sgi);
        $vmi = [VirtualMachine]::new($null, $nii, $rgi, $Credential, $ImageName, $images);

        $locationi = [Location]::new();
        if (-not $Location) {
            $vmi.UpdateLocation($locationi);
            if (-not $locationi.Value) {
                $locationi.Value = "eastus";
            }
        } else {
            $locationi.Value = $Location;
        }

        $resourceGroup = $rgi.GetOrCreate($Name + "ResourceGroup", $locationi.Value, $null);
        $vmResponse = $vmi.Create($Name, $locationi.Value, $resourceGroup.ResourceGroupName);

        New-PsObject @{
            ResourceId = $resourceGroup.ResourceId;
            Response = $vmResponse;
        }
    }
}

class Location {
    [int] $Priority;
    [string] $Value;

    Location() {
        $this.Priority = 0;
        $this.Value = $null;
    }
}

class AzureObject {
    [string] $Name;
    [AzureObject[]] $Children;
    [int] $Priority;

    AzureObject([string] $name, [AzureObject[]] $children) {
        $this.Name = $name;
        $this.Children = $children;
        $this.Priority = 0;
        foreach ($child in $this.Children) {
            if ($this.Priority -lt $child.Priority) {
                $this.Priority = $child.Priority;
            }
        }
        $this.Priority++;
    }

    # This function should be called only when $this.Name is not $null.
    [object] GetInfo() {
        return $null;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        return $null;
    }

    [void] UpdateLocation([Location] $location) {
        if ($this.Priority -gt $location.Priority) {
            if ($this.Name) {
                $location.Value = $this.GetInfo().Location;
                $location.Priority = $this.Priority;
            } else {
                foreach ($child in $this.Children) {
                    $child.UpdateLocation($location);
                }
            }
        }
    }

    [object] GetOrCreate([string] $name, [string] $location, [string] $resourceGroupName) {
        if ($this.Name) {
            return $this.GetInfo();
        } else {
            $result = $this.Create($name, $location, $resourceGroupName);
            $this.Name = $name;
            return $result;
        }
    }
}

class ResourceGroup: AzureObject {
    ResourceGroup([string] $name): base($name, @()) {
    }

    [object] GetInfo() {
        return Get-AzureRmResourceGroup -Name $this.Name;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        return New-AzureRmResourceGroup -Name $name -Location $location;
    }
}

class Resource1: AzureObject {
    Resource1([string] $name): base($name, @([ResourceGroup]::new($null))) {
    }
}

class VirtualNetwork: Resource1 {
    VirtualNetwork([string] $name): base($name) {
    }

    [object] GetInfo() {
        return Get-AzureRmVirtualNetwork -Name $this.Name;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        $subnetConfig = New-AzureRmVirtualNetworkSubnetConfig `
            -Name "Subnet" `
            -AddressPrefix "192.168.1.0/24"
        return New-AzureRmVirtualNetwork `
            -ResourceGroupName $resourceGroupName `
            -Location $location `
            -Name $name `
            -AddressPrefix "192.168.0.0/16" `
            -Subnet $subnetConfig
    }
}

class PublicIpAddress: Resource1 {
    PublicIpAddress([string] $name): base($name) {
    }

    [object] GetInfo() {
        return Get-AzureRMPublicIpAddress -Name $this.Name;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        return New-AzureRmPublicIpAddress `
            -ResourceGroupName $resourceGroupName `
            -Location $location `
            -AllocationMethod Static `
            -Name $name
    }
}

class SecurityGroup: Resource1 {
    SecurityGroup([string] $name): base($name) {
    }

    [object] GetInfo() {
        return Get-AzureRMSecurityGroup -Name $this.Name;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        $securityRuleConfig = New-AzureRmNetworkSecurityRuleConfig `
            -Name $name `
            -Protocol "Tcp" `
            -Priority 1000 `
            -Access "Allow" `
            -Direction "Inbound" `
            -SourcePortRange "*" `
            -SourceAddressPrefix "*" `
            -DestinationPortRange 3389 `
            -DestinationAddressPrefix "*"

        return New-AzureRmNetworkSecurityGroup `
            -ResourceGroupName $resourceGroupName `
            -Location $location `
            -Name $name `
            -SecurityRules $securityRuleConfig
    }
}

class NetworkInterface: AzureObject {
    [VirtualNetwork] $VirtualNetwork;
    [PublicIpAddress] $PublicIpAddress;
    [SecurityGroup] $SecurityGroup;

    NetworkInterface(
        [string] $name,
        [VirtualNetwork] $virtualNetwork,
        [PublicIpAddress] $publicIpAddress,
        [SecurityGroup] $securityGroup
    ): base($name, @($virtualNetwork, $publicIpAddress, $securityGroup)) {
        $this.VirtualNetwork = $virtualNetwork;
        $this.PublicIpAddress = $publicIpAddress;
        $this.SecurityGroup = $securityGroup;
    }

    [object] GetInfo() {
        return Get-AzureRMNetworkInterface -Name $this.Name;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        $xpublicIpAddress = $this.PublicIpAddress.GetOrCreate($name, $location, $resourceGroupName);
        $xvirtualNetwork = $this.VirtualNetwork.GetOrCreate($name, $location, $resourceGroupName);
        $xsecurityGroup = $this.SecurityGroup.GetOrCreate($name, $location, $resourceGroupName);
        return New-AzureRmNetworkInterface `
            -ResourceGroupName $resourceGroupName `
            -Location $location `
            -Name $name `
            -PublicIpAddressId $xpublicIpAddress.Id `
            -SubnetId $xvirtualNetwork.Subnets[0].Id `
            -NetworkSecurityGroupId $xsecurityGroup.Id
    }
}

class VirtualMachine: AzureObject {
    [NetworkInterface] $NetworkInterface;
    [pscredential] $Credential;
    [string] $ImageName;
    [object] $Images;

    VirtualMachine(
        [string] $name,
        [NetworkInterface] $networkInterface,
        [ResourceGroup] $resourceGroup,
        [PSCredential] $credential,
        [string] $imageName,
        [object] $images):
        base($name, @($networkInterface, $resourceGroup)) {

        $this.Credential = $credential;
        $this.ImageName = $imageName;
        $this.NetworkInterface = $networkInterface;
        $this.Images = $images;
    }

    [object] GetInfo() {
        return Get-AzureRMVirtualMachine -Name $this.Name;
    }

    [object] Create([string] $name, [string] $location, [string] $resourceGroupName) {
        $networkInterfaceInstance = $this.NetworkInterface.GetOrCreate( `
            $name, $location, $resourceGroupName);

        if (-not $this.Credential) {
            $this.Credential = Get-Credential
        }

        $vmImage = $this.Images | Where-Object { $_.Name -eq $this.ImageName } | Select-Object -First 1
        if (-not $vmImage) {
            throw "Unknown image: " + $this.ImageName
        }

        $vmSize = "Standard_DS2"
        $vmConfig = New-AzureRmVMConfig -VMName $Name -VMSize $vmSize
        $vmComputerName = $Name + "Computer"
        switch ($vmImage.Type) {
            "Windows" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Windows `
                    -ComputerName $vmComputerName `
                    -Credential $this.Credential
            }
            "Linux" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Linux `
                    -ComputerName $vmComputerName `
                    -Credential $this.Credential
            }
        }

        $vmImageImage = $vmImage.Image
        $vmConfig = $vmConfig `
            | Set-AzureRmVMSourceImage `
                -PublisherName $vmImageImage.publisher `
                -Offer $vmImageImage.offer `
                -Skus $vmImageImage.sku `
                -Version $vmImageImage.version `
            | Add-AzureRmVMNetworkInterface -Id $networkInterfaceInstance.Id

        return New-AzureRmVm `
            -ResourceGroupName $resourceGroupName `
            -Location $location `
            -VM $vmConfig
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