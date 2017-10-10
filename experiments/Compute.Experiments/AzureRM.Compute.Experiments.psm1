<#
.ExternalHelp AzureRM.Compute.Experiments-help.xml
#>
function New-AzVm {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param (
        [Parameter(Mandatory=$true, Position=0)][string] $Name = "VM",
        [Parameter(Mandatory=$true)][PSCredential] $Credential,

        [Parameter()][string] $ResourceGroupName = $Name,
        [Parameter()][string] $Location,

        [Parameter()][string] $VirtualNetworkName = $Name,
        [Parameter()][string] $AddressPrefix = "192.168.0.0/16",

        [Parameter()][string] $SubnetName = $Name,
        [Parameter()][string] $SubnetAddressPrefix = "192.168.1.0/24",

        [Parameter()][string] $PublicIpAddressName = $Name,
        [Parameter()][string] $DomainNameLabel = $Name + $ResourceGroupName,
        [Parameter()][ValidateSet("Static", "Dynamic")][string] $AllocationMethod = "Static",

        [Parameter()][string] $SecurityGroupName = $Name,
        [Parameter()][int[]] $OpenPorts,

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

        # find image
        $image = Get-Image($ImageName)

        # ports
        if (!$OpenPorts) {
            switch ($image.Type) {
                "Windows" {
                    $OpenPorts = @(3389, 5985)
                }
                "Linux" {
                    $OpenPorts = @(22)
                }
            }
        }

        $rgi = [ResourceGroup]::new($ResourceGroupName)

        $vni = [VirtualNetwork]::new($VirtualNetworkName, $rgi, $AddressPrefix)
        $subnet = [Subnet]::new($SubnetName, $vni, $SubnetAddressPrefix)
        $piai = [PublicIpAddress]::new($PublicIpAddressName, $rgi, $DomainNameLabel, $AllocationMethod)
        $sgi = [SecurityGroup]::new($SecurityGroupName, $rgi, $OpenPorts)

        # we don't allow to reuse NetworkInterface
        $nii = [NetworkInterface]::new(
            $Name,
            $rgi,
            $subnet,
            $piai,
            $sgi)

        # the purpouse of the New-AzVm cmdlet is to create (not get) a VM so $name is $null.
        $vmi = [VirtualMachine]::new(
            $Name,
            $rgi,
            $nii,
            $Credential,
            $image,
            $Size)

        # infer a location
        $locationi = [Location]::new()
        if (-not $Location) {
            $vmi.UpdateLocation($locationi, $context)
            if (-not $locationi.Value) {
                $locationi.Value = "eastus"
            }
            Write-Verbose ("Resource Location " + $locationi.Value)
        } else {
            $locationi.Value = $Location
        }

        $createParams = [CreateParams]::new($locationi.Value, $context)

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

                $jobName = "Creating VM $Name"
                return Start-Job -Name $jobName -ScriptBlock $script -ArgumentList $arguments
            } else {
                $vm = $vmi.GetOrCreate($createParams, [ProgressRange]::new(0.0, 1.0))
                Write-Progress "Done." -Completed
                $fqdn = $piai.DomainNameLabel + "." + $locationi.Value + ".cloudapp.azure.com"
                switch ($image.Type) {
                    "Windows" {
                        Write-Verbose ("Use 'mstsc /v:$fqdn' to connect to the VM." )
                    }
                    "Linux" {
                        Write-Verbose ("Use 'ssh $($Credential.UserName)@$fqdn' to connect to the VM." )
                    }
                }
                return [PSAzureVm]::new($vm, $fqdn)
            }
        }
    }
}

class PSAzureVm {
    [Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine] $Vm;
    [string] $Name;
    [string] $ResourceGroupName;
    [string] $Fqdn;

    PSAzureVm([Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine] $vm, [string] $fqdn) {
        $this.Vm = $vm
        $this.Name = $vm.Name
        $this.ResourceGroupName = $vm.ResourceGroupName
        $this.Fqdn = $fqdn
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
    [string] $Location;
    [object] $Context;

    CreateParams(
        [string] $location,
        [object] $context)
    {
        $this.Location = $location
        $this.Context = $context
    }
}

class ProgressRange {
    [double] $Start;
    [double] $Size;

    ProgressRange([double] $start, [double] $size) {
        $this.Start = $start;
        $this.Size = $size;
    }
}

class AzureObject {
    [string] $Name;
    [AzureObject[]] $Children;
    [int] $Priority;
    [int] $ObjectSize;

    [bool] $GetInfoCalled = $false;
    [object] $info = $null;

    AzureObject([string] $name, [AzureObject[]] $children) {
        $this.Name = $name
        $this.Children = $children
        $this.Priority = 0
        $this.ObjectSize = 1
        foreach ($child in $this.Children) {
            if ($this.Priority -lt $child.Priority) {
                $this.Priority = $child.Priority
            }
            $this.ObjectSize += $child.ObjectSize
        }
        $this.Priority++
    }

    <#
    [string] GetResourceType() {
        return $null
    }

    [object] GetInfoOrThrow([object] $context) {
        return $null
    }

    [object] Create([CreateParams] $p) {
        return $null
    }
    #>

    [string] GetLocation([object] $context) {
        $i = $this.GetInfo($context)
        if ($i) {
            return $i.Location
        }
        return $null
    }

    [object] GetInfo([object] $context) {
        if (!$this.GetInfoCalled) {
            $this.GetInfoCalled = $true
            try {
                $this.Info = $this.GetInfoOrThrow($context)
                if ($this.Info) {
                    Write-Verbose ("Found '" + $this.Name + "' " + $this.GetResourceType() + ".")
                }
            } catch {
                # ignore all errors
            }
        }
        return $this.Info;
    }

    [void] UpdateLocation([Location] $location, [object] $context) {
        if ($this.Priority -gt $location.Priority) {
            $l = $this.GetLocation($context)
            if ($l) {
                $location.Value = $l
                $location.Priority = $this.Priority
                return;
            }
            foreach ($child in $this.Children) {
                $child.UpdateLocation($location, $context)
            }
        }
    }

    [object] GetOrCreate([CreateParams] $p, [ProgressRange] $progressRange) {
        $i = $this.GetInfo($p.Context)
        if ($i) {
            return $i
        }
        $pSize = $progressRange.Size / $this.ObjectSize
        $offset = $progressRange.Start
        foreach ($child in $this.Children) {
            $pChildSize = $pSize * $child.ObjectSize
            $pc = [ProgressRange]::new($offset, $pChildSize)
            $child.GetOrCreate($p, $pc) | Out-Null
            $offset += $pChildSize
        }
        $message = "Creating '" + $this.Name + "' " + $this.GetResourceType() + "."
        $percent = [convert]::ToInt32($offset * 100)
        Write-Progress $message -PercentComplete $percent -Status "$percent% Complete:"
        Write-Verbose $message
        $this.Info = $this.Create($p)
        return $this.Info
    }
}

class ResourceGroup: AzureObject {
    ResourceGroup([string] $name): base($name, @()) {
    }

    [string] GetResourceType() {
        return "Resource Group"
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRmResourceGroup `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmResourceGroup `
            -Name $this.Name `
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
    ): base($name, @($resourceGroup) + $children) {
        $this.ResourceGroup = $resourceGroup
    }

    Resource1(
        [string] $name,
        [ResourceGroup] $resourceGroup
    ): base($name, @($resourceGroup)) {
        $this.ResourceGroup = $resourceGroup
    }

    [string] GetResourceGroupName() {
        return $this.ResourceGroup.Info.ResourceGroupName;
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

    [string] GetResourceType() {
        return "Virtual Network"
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRmVirtualNetwork `
            -ResourceGroupName $this.ResourceGroup.Name `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmVirtualNetwork `
            -ResourceGroupName $this.GetResourceGroupName() `
            -Location $p.Location `
            -Name $this.Name `
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
        $this.DomainNameLabel = $domainNameLabel.ToLower()
        $this.AllocationMethod = $allocationMethod
    }

    [string] GetResourceType() {
        return "Public IP Address"
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRMPublicIpAddress `
            -ResourceGroupName $this.ResourceGroup.Name `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        return New-AzureRmPublicIpAddress `
            -ResourceGroupName $this.GetResourceGroupName() `
            -Location $p.Location `
            -Name $this.Name `
            -DomainNameLabel  $this.DomainNameLabel `
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

    [string] GetResourceType() {
        return "Security Group"
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRmNetworkSecurityGroup `
            -ResourceGroupName $this.ResourceGroup.Name `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $rules = New-Object `
            "System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.PSSecurityRule]"
        $priority = 1000
        foreach ($port in $this.OpenPorts) {
            $name = $this.Name + $port
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
            -ResourceGroupName $this.GetResourceGroupName() `
            -Location $p.Location `
            -Name $this.Name `
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

    [string] GetResourceType() {
        return "Subnet"
    }

    [object] GetInfoFromVirtualNetworkInfo([object] $virtualNetworkInfo) {
        return $virtualNetworkInfo `
            | Get-AzureRmVirtualNetworkSubnetConfig -Name $this.Name -ErrorAction Stop
    }

    [object] GetInfoOrThrow([object] $context) {
        $virtualNetworkInfo = $this.VirtualNetwork.GetInfo($context)
        if ($virtualNetworkInfo) {
            return $this.GetInfoFromVirtualNetworkInfo($virtualNetworkInfo)
        }
        return $null
    }

    [string] GetLocation([object] $context) {
        return $this.VirtualNetwork.GetLocation($context)
    }

    [object] Create([CreateParams] $p) {
        $virtualNetworkInfo = $this.VirtualNetwork.Info
        try {
            return $this.GetInfoFromVirtualNetworkInfo($virtualNetworkInfo)
        } catch {
        }
        $virtualNetworkInfo = Add-AzureRmVirtualNetworkSubnetConfig `
            -VirtualNetwork $virtualNetworkInfo `
            -Name $this.Name `
            -AddressPrefix $this.SubnetAddressPrefix
        $virtualNetworkInfo = Set-AzureRmVirtualNetwork `
            -VirtualNetwork $virtualNetworkInfo `
            -AzureRmContext $p.Context `
            -ErrorAction Stop
        return $this.GetInfoFromVirtualNetworkInfo($virtualNetworkInfo)
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

    [string] GetResourceType() {
        return "Network Interface"
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRMNetworkInterface `
            -ResourceGroupName $this.ResourceGroup.Name `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $publicIpAddressInfo = $this.PublicIpAddress.Info
        $subnetInfo = $this.Subnet.Info
        $securityGroupInfo = $this.SecurityGroup.Info
        return New-AzureRmNetworkInterface `
            -ResourceGroupName $this.GetResourceGroupName() `
            -Location $p.Location `
            -Name $this.Name `
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
    [object] $Image;
    [string] $Size;

    VirtualMachine(
        [string] $name,
        [ResourceGroup] $resourceGroup,
        [NetworkInterface] $networkInterface,
        [PSCredential] $credential,
        [object] $image,
        [string] $size):
        base($name, $resourceGroup, @($networkInterface)) {

        $this.Credential = $credential
        $this.NetworkInterface = $networkInterface
        $this.Image = $image
        $this.Size = $size
    }

    [string] GetResourceType() {
        return "Virtual Machine"
    }

    [object] GetInfoOrThrow([object] $context) {
        return Get-AzureRmVM `
            -ResourceGroupName $this.ResourceGroup.Name `
            -Name $this.Name `
            -AzureRmContext $context `
            -ErrorAction Stop
    }

    [object] Create([CreateParams] $p) {
        $networkInterfaceInstance = $this.NetworkInterface.Info

        $vmConfig = New-AzureRmVMConfig `
            -VMName $this.Name `
            -VMSize $this.Size `
            -ErrorAction Stop
        $vmConfig = $vmConfig | Set-AzureRmVMBootDiagnostics -Disable -ErrorAction Stop
        $vmComputerName = $this.Name
        switch ($this.Image.Type) {
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

        $vmImageImage = $this.Image.Image
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

        $rgName = $this.GetResourceGroupName()
        New-AzureRmVm `
                -ResourceGroupName $rgName `
                -Location $p.Location `
                -VM $vmConfig `
                -AzureRmContext $p.Context `
                -WarningAction SilentlyContinue `
                -ErrorAction Stop `
            | Out-Null

        return $this.GetInfoOrThrow($p.Context)
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

function Get-Image([string] $imageName) {
    $vmImage = $images | Where-Object { $_.Name -eq $imageName } | Select-Object -First 1
    if (-not $vmImage) {
        throw "Unknown image: " + $this.ImageName
    }
    return $vmImage
}

Export-ModuleMember -Function New-AzVm

$locations = $null

function Get-WordToCompleteList {
    param($List, $WordToComplete)

    return $List `
        | Where-Object { $_ -like "$WordToComplete*" } `
        | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_) }
}

Register-ArgumentCompleter -CommandName New-AzVm -ParameterName Location -ScriptBlock {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    if (!$global:locations) {
        $global:locations = Get-AzureRmLocation `
            | ForEach-Object { $_.Location }
    }
    return Get-WordToCompleteList -List $global:locations -WordToComplete $wordToComplete
}

Register-ArgumentCompleter -CommandName New-AzVm -ParameterName ImageName -ScriptBlock {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $list = $images | ForEach-Object { $_.Name }
    return Get-WordToCompleteList -List $list -WordToComplete $wordToComplete
}
