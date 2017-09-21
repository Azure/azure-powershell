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
        [Parameter()][string] $Size = "Standard_DS1_v2",

        [Parameter()][object] $AzureRmContext,
        [Parameter()][switch] $AsJob
    )

    PROCESS {
        # TODO: make sure it's logged in.
        $context = if ($AzureRmContext) {
            Get-AzureRmContext -AzureRmContext $AzureRmContext
        } else {
            Get-AzureRmContext
        }

        $rgi = [ResourceGroup]::new($ResourceGroupName)

        $vni = [VirtualNetwork]::new($VirtualNetworkName, $rgi, $AddressPrefix)
        $subnet = [Subnet]::new($SubnetName, $vni, $SubnetAddressPrefix)
        $piai = [PublicIpAddress]::new($PublicIpAddressName, $rgi, $DomainNameLabel, $AllocationMethod)
        $sgi = [SecurityGroup]::new($SecurityGroupName, $rgi, $OpenPorts)

        # we don't allow to reuse NetworkInterface so $name is $null.
        $nii = [NetworkInterface]::new(
            $null,
            $rgi,
            $subnet,
            $piai,
            $sgi)

        # the purpouse of the New-AzVm cmdlet is to create (not get) a VM so $name is $null.
        $vmi = [VirtualMachine]::new(
            $null,
            $rgi,
            $nii,
            $Credential,
            $ImageName,
            $images,
            $Size)

        # infer a location
        $locationi = [Location]::new()
        if (-not $Location) {
            $vmi.UpdateLocation($locationi, $context)
            if (-not $locationi.Value) {
                $locationi.Value = "eastus"
            }
        } else {
            $locationi.Value = $Location
        }

        $createParams = [CreateParams]::new($Name, $locationi.Value, $context)

        if ($PSCmdlet.ShouldProcess($Name, "Creating a virtual machine")) {
            if ($AsJob) {
                $boundParams = $PSCmdlet.MyInvocation.BoundParameters
                $arguments = @{ 'AzureRmContext' = $context }
                foreach ($argName in $boundParams.Keys) {
                    if ($argName -ne 'AsJob' -and $argName -ne 'AzureRmContext') {
                        $arguments[$argName] = $boundParams[$argName]
                    }
                }
                $script = {
                    [hashtable] $params = $args[0]
                    New-AzVm @params
                }
                return Start-Job $script -ArgumentList $arguments
            } else {
                # Force to create Resource Group before anything else.
                $rg = $rgi.GetOrCreate($createParams)
                $vmResponse = $vmi.Create($createParams)
                return [PSAzureVm]::new(
                    $rg.ResourceId,
                    $VirtualMachine.Name
                )
            }
        }
    }
}

class PSAzureVm {
    [string] $ResourceGroupId;
    [string] $Name;

    PSAzureVm([string] $resourceGroupId, [string] $name) {
        $this.ResourceGroupId = $resourceGroupId
        $this.Name = $name
    }
}

class Location {
    [int] $Priority;
    [string] $Value;

    Location() {
        $this.Priority = 0
        $this.Value = $null
    }
}

class CreateParams {
    [string] $Name;
    [string] $Location;
    [object] $Context;

    CreateParams(
        [string] $name,
        [string] $location,
        [object] $context)
    {
        $this.Name = $name
        $this.Location = $location
        $this.Context = $context
    }
}

class AzureObject {
    [string] $Name;
    [AzureObject[]] $Children;
    [int] $Priority;
    [object] $info = $null;

    AzureObject([string] $name, [AzureObject[]] $children) {
        $this.Name = $name
        $this.Children = $children
        $this.Priority = 0
        foreach ($child in $this.Children) {
            if ($this.Priority -lt $child.Priority) {
                $this.Priority = $child.Priority
            }
        }
        $this.Priority++
    }

    [object] GetInfoOrThrow([object] $context) {
        return $null
    }

    [object] Create([CreateParams] $p) {
        return $null
    }

    # This function should be called only when $this.Name is not $null.
    [object] GetInfo([object] $context) {
        if (!$this.Info) {
            try {
                $this.Info = $this.GetInfoOrThrow($context)
            } catch {
                # ignore all errors
            }
        }
        return $this.Info;
    }

    [void] UpdateLocation([Location] $location, [object] $context) {
        if ($this.Priority -gt $location.Priority) {
            if ($this.Name) {
                $i = $this.GetInfo($context)
                if ($i) {
                    $location.Value = $i.Location
                    $location.Priority = $this.Priority
                    return;
                }
            }
            foreach ($child in $this.Children) {
                $child.UpdateLocation($location, $context)
            }
        }
    }

    [object] GetOrCreate([CreateParams] $p) {
        $i = $this.GetInfo($p.Context)
        if ($i) {
            return $i
        }
        if ($this.Name) {
            $p = [CreateParams]::new(
                $this.Name,
                $p.Location,
                $p.Context
            )
        }
        $this.Info = $this.Create($p)
        $this.Name = $p.Name
        return $this.Info
    }
}

class ResourceGroup: AzureObject {
    ResourceGroup([string] $name): base($name, @()) {
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRmResourceGroup `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmResourceGroup `
            -Name $p.Name `
            -Location $p.Location `
            -AzureRmContext $p.Context `
            -WarningAction SilentlyContinue `
            -ErrorAction Stop
    }
}

class Resource1: AzureObject {
    [ResourceGroup] $ResourceGroup;

    Resource1(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [AzureObject[]] $children
    ): base($name, @($children)) {
        $this.ResourceGroup = $resourceGroup
    }

    Resource1(
        [string] $name,
        [ResourceGroup] $resourceGroup
    ): base($name, @($resourceGroup)) {
        $this.ResourceGroup = $resourceGroup
    }

    [string] GetResourceGroupName([CreateParams] $p) {
        return $this.ResourceGroup.GetOrCreate($p).ResourceGroupName;
    }
}

class VirtualNetwork: Resource1 {
    [string] $AddressPrefix;

    VirtualNetwork(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [string] $addressPrefix
    ): base($name, $resourceGroup) {
        $this.AddressPrefix = $addressPrefix
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRmVirtualNetwork `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmVirtualNetwork `
            -ResourceGroupName $this.GetResourceGroupName($p) `
            -Location $p.Location `
            -Name $p.Name `
            -AddressPrefix $this.AddressPrefix `
            -AzureRmContext $p.Context `
            -WarningAction SilentlyContinue `
            -ErrorAction Stop
    }
}

class PublicIpAddress: Resource1 {
    [string] $DomainNameLabel;
    [string] $AllocationMethod;

    PublicIpAddress(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [string] $domainNameLabel,
        [string] $allocationMethod
    ): base($name, $resourceGroup) {
        $this.DomainNameLabel = $domainNameLabel
        $this.AllocationMethod = $allocationMethod
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRMPublicIpAddress `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmPublicIpAddress `
            -ResourceGroupName $this.GetResourceGroupName($p) `
            -Location $p.Location `
            -Name $p.Name `
            -DomainNameLabel  $this.DomainNameLabel.ToLower() `
            -AllocationMethod $this.AllocationMethod `
            -AzureRmContext $p.Context `
            -WarningAction SilentlyContinue `
            -ErrorAction Stop
    }
}

class SecurityGroup: Resource1 {
    [int[]] $OpenPorts;

    SecurityGroup(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [int[]] $OpenPorts
    ): base($name, $resourceGroup) {
        $this.OpenPorts = $OpenPorts
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRMSecurityGroup `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $rules = New-Object `
            "System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.PSSecurityRule]"
        $priority = 1000
        foreach ($port in $this.OpenPorts) {
            $name = $p.Name + $port
            $securityRuleConfig = New-AzureRmNetworkSecurityRuleConfig `
                -Name $name `
                -Protocol "Tcp" `
                -Priority $priority `
                -Access "Allow" `
                -Direction "Inbound" `
                -SourcePortRange "*" `
                -SourceAddressPrefix "*" `
                -DestinationPortRange $port `
                -DestinationAddressPrefix "*" `
                -ErrorAction Stop
            $rules.Add($securityRuleConfig)
            ++$priority
        }
        return New-AzureRmNetworkSecurityGroup `
            -ResourceGroupName $this.GetResourceGroupName($p) `
            -Location $p.Location `
            -Name $p.Name `
            -SecurityRules $rules `
            -AzureRmContext $p.Context `
            -WarningAction SilentlyContinue `
            -ErrorAction Stop
    }
}

class Subnet: AzureObject {
    [VirtualNetwork] $VirtualNetwork;
    [string] $SubnetAddressPrefix;

    Subnet([string] $name, [VirtualNetwork] $virtualNetwork, [string] $subnetAddressPrefix):
        base($name, @($virtualNetwork)) {
        $this.VirtualNetwork = $virtualNetwork
        $this.SubnetAddressPrefix = $subnetAddressPrefix
    }

    [object] GetInfoOrThrow([object] $context) {
        $virutalNetworkInfo = $this.VirtualNetwork.GetInfo($context)
        if (!$virutalNetworkInfo) {
            return $null
        }
        return $virutalNetworkInfo `
            | Get-AzureRmVirtualNetworkSubnetConfig -Name $this.Name -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $virtualNetworkInfo = $this.VirtualNetwork.GetOrCreate($p)
        Add-AzureRmVirtualNetworkSubnetConfig `
            -VirtualNetwork $virtualNetworkInfo `
            -Name $p.Name `
            -AddressPrefix $this.SubnetAddressPrefix
        $virtualNetworkInfo = Set-AzureRmVirtualNetwork `
            -VirtualNetwork $virtualNetworkInfo `
            -AzureRmContext $p.Context `
            -ErrorAction Stop
        return Get-AzureRmVirtualNetworkSubnetConfig `
            -VirtualNetwork $virtualNetworkInfo `
            -Name $p.Name
    }
}

class NetworkInterface: Resource1 {
    [Subnet] $Subnet;
    [PublicIpAddress] $PublicIpAddress;
    [SecurityGroup] $SecurityGroup;

    NetworkInterface(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [Subnet] $subnet,
        [PublicIpAddress] $publicIpAddress,
        [SecurityGroup] $securityGroup
    ): base($name, $resourceGroup, @($subnet, $publicIpAddress, $securityGroup)) {
        $this.Subnet = $subnet
        $this.PublicIpAddress = $publicIpAddress
        $this.SecurityGroup = $securityGroup
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRMNetworkInterface `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $publicIpAddressInfo = $this.PublicIpAddress.GetOrCreate($p)
        $subnetInfo = $this.Subnet.GetOrCreate($p)
        $securityGroupInfo = $this.SecurityGroup.GetOrCreate($p)
        return New-AzureRmNetworkInterface `
            -ResourceGroupName $this.GetResourceGroupName($p) `
            -Location $p.Location `
            -Name $p.Name `
            -PublicIpAddressId $publicIpAddressInfo.Id `
            -SubnetId $subnetInfo.Id `
            -NetworkSecurityGroupId $securityGroupInfo.Id `
            -AzureRmContext $p.Context `
            -WarningAction SilentlyContinue `
            -ErrorAction Stop
    }
}

class VirtualMachine: Resource1 {
    [NetworkInterface] $NetworkInterface;
    [pscredential] $Credential;
    [string] $ImageName;
    [object] $Images;
    [string] $Size;

    VirtualMachine(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [NetworkInterface] $networkInterface,
        [PSCredential] $credential,
        [string] $imageName,
        [object] $images,
        [string] $size):
        base($name, $resourceGroup, @($networkInterface)) {

        $this.Credential = $credential
        $this.ImageName = $imageName
        $this.NetworkInterface = $networkInterface
        $this.Images = $images
        $this.Size = $size
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRMVirtualMachine `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $networkInterfaceInstance = $this.NetworkInterface.GetOrCreate($p)

        $vmImage = $this.Images | Where-Object { $_.Name -eq $this.ImageName } | Select-Object -First 1
        if (-not $vmImage) {
            throw "Unknown image: " + $this.ImageName
        }

        $vmConfig = New-AzureRmVMConfig -VMName $p.Name -VMSize $this.Size -ErrorAction Stop
        $vmComputerName = $p.Name
        switch ($vmImage.Type) {
            "Windows" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Windows `
                    -ComputerName $vmComputerName `
                    -Credential $this.Credential `
                    -ErrorAction Stop
            }
            "Linux" {
                $vmConfig = $vmConfig | Set-AzureRmVMOperatingSystem `
                    -Linux `
                    -ComputerName $vmComputerName `
                    -Credential $this.Credential `
                    -ErrorAction Stop
            }
        }

        $vmImageImage = $vmImage.Image
        $vmConfig = $vmConfig `
            | Set-AzureRmVMSourceImage `
                -PublisherName $vmImageImage.publisher `
                -Offer $vmImageImage.offer `
                -Skus $vmImageImage.sku `
                -Version $vmImageImage.version `
                -ErrorAction Stop `
            | Add-AzureRmVMNetworkInterface `
                -Id $networkInterfaceInstance.Id `
                -ErrorAction Stop

        return New-AzureRmVm `
            -ResourceGroupName $this.GetResourceGroupName($p) `
            -Location $p.Location `
            -VM $vmConfig `
            -AzureRmContext $p.Context `
            -WarningAction SilentlyContinue `
            -ErrorAction Stop
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
