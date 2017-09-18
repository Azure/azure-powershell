<#
.ExternalHelp AzureRM.Compute.Experiments-help.xml
#>
function New-AzVm {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param (
        [Parameter(Mandatory=$true, Position=0)][string] $Name = "VM",
        [Parameter(Mandatory=$true)][PSCredential] $Credential,

        [Parameter()][string] $ResourceGroupName,
        [Parameter()][string] $Location,

        [Parameter()][string] $VirtualNetworkName,
        [Parameter()][string] $AddressPrefix = "192.168.0.0/16",

        [Parameter()][string] $SubnetName,
        [Parameter()][string] $SubnetAddressPrefix = "192.168.1.0/24",

        [Parameter()][string] $PublicIpAddressName,
        [Parameter()][string] $DomainNameLabel = $Name,
        [Parameter()][string] $AllocationMethod = "Static",

        [Parameter()][string] $SecurityGroupName,
        [Parameter()][int[]] $OpenPorts = @(3389, 5985),

        [Parameter()][string] $ImageName = "Win2016Datacenter",
        [Parameter()][string] $Size = "Standard_DS1_v2"
    )

    PROCESS {
        $rgi = [ResourceGroup]::new($ResourceGroupName);

        $vni = [VirtualNetwork]::new($VirtualNetworkName, $AddressPrefix);
        $subnet = [Subnet]::new($SubnetName, $vni, $SubnetAddressPrefix);
        $piai = [PublicIpAddress]::new($PublicIpAddressName, $DomainNameLabel, $AllocationMethod);
        $sgi = [SecurityGroup]::new($SecurityGroupName, $OpenPorts);

        # we don't allow to reuse NetworkInterface so $name is $null.
        $nii = [NetworkInterface]::new(
            $null,
            $subnet,
            $piai,
            $sgi);

        # the purpouse of the New-AzVm cmdlet is to create (not get) a VM so $name is $null.
        $vmi = [VirtualMachine]::new(
            $null,
            $nii,
            $rgi,
            $Credential,
            $ImageName,
            $images,
            $Size);

        # infer a location
        $locationi = [Location]::new();
        if (-not $Location) {
            $vmi.UpdateLocation($locationi);
            if (-not $locationi.Value) {
                $locationi.Value = "eastus";
            }
        } else {
            $locationi.Value = $Location;
        }

        $createParams = [CreateParams]::new($Name, $locationi.Value, $Name);

        if ($PSCmdlet.ShouldProcess($Name, "Creating a virtual machine")) {
            $resourceGroup = $rgi.GetOrCreate($createParams);
            $vmResponse = $vmi.Create($createParams);

            return [PSAzureVm]::new(
                $resourceGroup.ResourceId,
                $Name
            );
        }
    }
}

class PSAzureVm {
    [string] $ResourceGroupId;
    [string] $Name;

    PSAzureVm([string] $resourceGroupId, [string] $name) {
        $this.ResourceGroupId = $resourceGroupId;
        $this.Name = $name;
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

class CreateParams {
    [string] $Name;
    [string] $Location;
    [string] $ResourceGroupName;

    CreateParams([string] $name, [string] $location, [string] $resourceGroupName) {
        $this.Name = $name;
        $this.Location = $location;
        $this.ResourceGroupName = $resourceGroupName;
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

    [object] Create([CreateParams] $p) {
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

    [object] GetOrCreate([CreateParams] $p) {
        if ($this.Name) {
            return $this.GetInfo();
        } else {
            $result = $this.Create($p);
            $this.Name = $p.Name;
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

    [object] Create([CreateParams] $p) {
        return New-AzureRmResourceGroup `
            -Name $p.Name `
            -Location $p.Location `
            -WarningAction SilentlyContinue;
    }
}

class Resource1: AzureObject {
    Resource1([string] $name): base($name, @([ResourceGroup]::new($null))) {
    }
}

class VirtualNetwork: Resource1 {
    [string] $AddressPrefix;

    VirtualNetwork([string] $name, [string] $addressPrefix): base($name) {
        $this.AddressPrefix = $addressPrefix;
    }

    [object] GetInfo() {
        return Get-AzureRmVirtualNetwork -Name $this.Name;
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmVirtualNetwork `
            -ResourceGroupName $p.ResourceGroupName `
            -Location $p.Location `
            -Name $p.Name `
            -AddressPrefix $this.AddressPrefix `
            -WarningAction SilentlyContinue;
    }
}

class PublicIpAddress: Resource1 {
    [string] $DomainNameLabel;
    [string] $AllocationMethod;

    PublicIpAddress(
        [string] $name,
        [string] $domainNameLabel,
        [string] $allocationMethod
    ): base($name) {
        $this.DomainNameLabel = $domainNameLabel;
        $this.AllocationMethod = $allocationMethod;
    }

    [object] GetInfo() {
        return Get-AzureRMPublicIpAddress -Name $this.Name;
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmPublicIpAddress `
            -ResourceGroupName $p.ResourceGroupName `
            -Location $p.Location `
            -Name $p.Name `
            -DomainNameLabel  $this.DnsLabel `
            -AllocationMethod Static `
            -WarningAction SilentlyContinue
    }
}

class SecurityGroup: Resource1 {
    [int[]] $OpenPorts;

    SecurityGroup([string] $name, [int[]] $OpenPorts): base($name) {
        $this.OpenPorts = $OpenPorts;
    }

    [object] GetInfo() {
        return Get-AzureRMSecurityGroup -Name $this.Name
    }

    [object] Create([CreateParams] $p) {
        $rules = New-Object "System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.PSSecurityRule]";
        foreach ($port in $this.OpenPorts) {
            $name = $p.Name + $port;
            $securityRuleConfig = New-AzureRmNetworkSecurityRuleConfig `
                -Name $name `
                -Protocol "Tcp" `
                -Priority 1000 `
                -Access "Allow" `
                -Direction "Inbound" `
                -SourcePortRange "*" `
                -SourceAddressPrefix "*" `
                -DestinationPortRange $port `
                -DestinationAddressPrefix "*";
            $rules.Add($securityRuleConfig);
        }
        return New-AzureRmNetworkSecurityGroup `
            -ResourceGroupName $p.ResourceGroupName `
            -Location $p.Location `
            -Name $p.Name `
            -SecurityRules $rules `
            -WarningAction SilentlyContinue
    }
}

class Subnet: AzureObject {
    [VirtualNetwork] $VirtualNetwork;
    [string] $SubnetAddressPrefix;

    Subnet([string] $name, [VirtualNetwork] $virtualNetwork, [string] $subnetAddressPrefix):
        base($name, @($virtualNetwork)) {
        $this.VirtualNetwork = $virtualNetwork;
        $this.SubnetAddressPrefix = $subnetAddressPrefix;
    }

    [object] GetInfo() {
        $virutalNetworkInfo = $this.VirtualNetwork.GetInfo();
        return $virutalNetworkInfo | Get-AzureRmVirtualNetworkSubnetConfig -Name $this.Name;
    }

    [object] Create([CreateParams] $p) {
        $virtualNetworkInfo = $this.VirtualNetwork.GetOrCreate($p);
        Add-AzureRmVirtualNetworkSubnetConfig `
            -VirtualNetwork $virtualNetworkInfo `
            -Name $p.Name `
            -AddressPrefix $this.SubnetAddressPrefix;
        $virtualNetworkInfo = Set-AzureRmVirtualNetwork -VirtualNetwork $virtualNetworkInfo
        $result = Get-AzureRmVirtualNetworkSubnetConfig -VirtualNetwork $virtualNetworkInfo -Name $p.Name
        return $result;
    }
}

class NetworkInterface: AzureObject {
    [Subnet] $Subnet;
    [PublicIpAddress] $PublicIpAddress;
    [SecurityGroup] $SecurityGroup;

    NetworkInterface(
        [string] $name,
        [Subnet] $subnet,
        [PublicIpAddress] $publicIpAddress,
        [SecurityGroup] $securityGroup
    ): base($name, @($subnet, $publicIpAddress, $securityGroup)) {
        $this.Subnet = $subnet;
        $this.PublicIpAddress = $publicIpAddress;
        $this.SecurityGroup = $securityGroup;
    }

    [object] GetInfo() {
        return Get-AzureRMNetworkInterface -Name $this.Name;
    }

    [object] Create([CreateParams] $p) {
        $publicIpAddressInfo = $this.PublicIpAddress.GetOrCreate($p);
        $subnetInfo = $this.Subnet.GetOrCreate($p);
        $securityGroupInfo = $this.SecurityGroup.GetOrCreate($p);
        return New-AzureRmNetworkInterface `
            -ResourceGroupName $p.ResourceGroupName `
            -Location $p.Location `
            -Name $p.Name `
            -PublicIpAddressId $publicIpAddressInfo.Id `
            -SubnetId $subnetInfo.Id `
            -NetworkSecurityGroupId $securityGroupInfo.Id `
            -WarningAction SilentlyContinue
    }
}

class VirtualMachine: AzureObject {
    [NetworkInterface] $NetworkInterface;
    [pscredential] $Credential;
    [string] $ImageName;
    [object] $Images;
    [string] $Size;

    VirtualMachine(
        [string] $name,
        [NetworkInterface] $networkInterface,
        [ResourceGroup] $resourceGroup,
        [PSCredential] $credential,
        [string] $imageName,
        [object] $images,
        [string] $size):
        base($name, @($networkInterface, $resourceGroup)) {

        $this.Credential = $credential;
        $this.ImageName = $imageName;
        $this.NetworkInterface = $networkInterface;
        $this.Images = $images;
        $this.Size = $size;
    }

    [object] GetInfo() {
        return Get-AzureRMVirtualMachine -Name $this.Name;
    }

    [object] Create([CreateParams] $p) {
        $networkInterfaceInstance = $this.NetworkInterface.GetOrCreate($p);

        if (-not $this.Credential) {
            $this.Credential = Get-Credential;
        }

        $vmImage = $this.Images | Where-Object { $_.Name -eq $this.ImageName } | Select-Object -First 1;
        if (-not $vmImage) {
            throw "Unknown image: " + $this.ImageName;
        }

        $vmConfig = New-AzureRmVMConfig -VMName $p.Name -VMSize $this.Size;
        $vmComputerName = $p.Name;
        switch ($vmImage.Type) {
            "Windows" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Windows `
                    -ComputerName $vmComputerName `
                    -Credential $this.Credential;
            }
            "Linux" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Linux `
                    -ComputerName $vmComputerName `
                    -Credential $this.Credential;
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
            -ResourceGroupName $p.ResourceGroupName `
            -Location $p.Location `
            -VM $vmConfig `
            -WarningAction SilentlyContinue
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