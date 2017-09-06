# Author: Aaron Roney.
# Modified: 20170827.
# Setup: Remove-Module Az.Compute; Import-Module .\Az.Compute.psm1; New-AzVm -Auto;

# Resources:
#   * [EXTERNAL] Azure PowerShell Docs: https://aka.ms/azpsdocs.
#   * [EXTERNAL] Strategy Doc: https://aka.ms/azpsstrategy.
#   * [EXTERNAL] Inspiration Sample: https://aka.ms/azpscreatevm.
#   * [EXTERNAL] Community Standups: https://aka.ms/azpsnetstandup.
#   * [EXTERNAL] Gallery Package: https://aka.ms/psazurerm.
#   * [EXTERNAL] Docker: https://aka.ms/azpsdocker.
#   * [EXTERNAL] Core Docker: https://aka.ms/azpscoredocker.
#   * [INTERNAL] Research Evidence: https://aka.ms/azpsimprovementresearch.

# TODO:
#   * Implement `-Auto' parameter set (i.e., `Name` and `ResourceGroup` will become optional).
#   * Implement new default formatter.
#   * Lock down parameter list: should be good as is (if we add the option to set OS disk size).
#   * Most of the parameters have "static" defaults: make these smart defaults, where applicable (e.g., location and open ports).
#   * WinServer2016 is hardcoded: add parameters to allow people to use the full image provider, etc.
#   * Import image providers, etc. from the "aliases.json".
#   * Integrate into Nelson's build semantics.
#   * Integrate app insights instrumentation so we can get good telemetry.

#Requires -Modules AzureRM.Compute

function New-AzVm {
    param (
        [Parameter(Mandatory = $true)] [string] $Name,
        [Parameter(Mandatory = $true)] [string] $ResourceGroup,

        # Generate a random as a hash of the name so it will be idempotent (tack on resource group?).
        [Parameter(DontShow)]
        $Random = $(Get-Hash $Name),

        [string] $Location = "",

        [string] $Image = "WinServer2016",
        [string] $Size = "Standard_DS1_v2",

        [string] $VnetName = "$($Name)Vnet",
        [string] $SubnetAddressPrefix = "192.168.1.0/24",
        [string] $VnetAddressPrefix = "192.168.0.0/16",

        [string] $PublicIpName = "$($Name)PublicIp",
        [string] $PublicIpDnsLabel = "$Name-$Random".ToLower(),
        [string] $PublicIpAllocationMethod = "Static",
        [int] $PublicIpIdleTimeoutInMinutes = 4,

        [string] $NsgName = "$($Name)Nsg",
        [int[]] $NsgOpenPorts = $null,

        [string] $NicName = "$($Name)Nic"

        # Storage - OS Disk Size.
        # Compute: "this goes above and beyond the 80% scenario".
    )

    try {

        # Build credentials.

        $userName = $env:UserName;
        $ptPassword = -join ((33..122) | Get-Random -Count 20 | ForEach-Object { [char]$_ });
        $password = ConvertTo-SecureString $ptPassword -AsPlainText -Force;
        $creds = New-Object System.Management.Automation.PSCredential ($env:UserName, $password);

        # Set the smart defaults.

        if($Location -eq "") {
            # TODO: Infer the location somehow?
            $Location = "westus2";
        }

        if($NsgOpenPorts -eq $null) {
            # TODO: Infer the ports to open from the image types.
            $NsgOpenPorts = @(3389,5985);
        }

        # Get image aliases.

        # TODO: Properly set images from below.  Put this in its own "ensure" method?
        $images = Invoke-WebRequest "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/arm-compute/quickstart-templates/aliases.json" | ConvertFrom-Json;

        # Set variables.

        $fqdn = "$PublicIpDnsLabel.$Location.cloudapp.azure.com";

        # Create!

        Write-Info "Ensuring resource group...";
        $rg = Use-ResourceGroup `
            -ResourceGroup $ResourceGroup `
            -Location $Location;

        Write-Info "Ensuring Vnet...";
        $vnet = Use-Vnet `
            -Name $VnetName `
            -ResourceGroup $ResourceGroup `
            -Location $Location `
            -SubnetAddressPrefix $SubnetAddressPrefix `
            -VnetAddressPrefix $VnetAddressPrefix;

        Write-Info "Ensuring public IP...";
        $pip = Use-Pip `
            -Name $PublicIpName `
            -ResourceGroup $ResourceGroup `
            -Location $Location `
            -DnsLabel $PublicIpDnsLabel `
            -AllocationMethod $PublicIpAllocationMethod `
            -IdleTimeoutInMinutes $PublicIpIdleTimeoutInMinutes;

        Write-Info "Ensuring NSG...";
        $nsg = Use-Nsg `
            -Name $NsgName `
            -ResourceGroup $ResourceGroup `
            -Location $Location `
            -OpenPorts $NsgOpenPorts;

        Write-Info "Ensuring NIC...";
        $nic = Use-Nic `
            -Name $NicName `
            -ResourceGroup $ResourceGroup `
            -Location $Location `
            -SubnetId $vnet.Subnets[0].Id `
            -PublicIpAddressId $pip.Id `
            -NetworkSecurityGroupId $nsg.Id;

        # TODO: Add disk options (https://docs.microsoft.com/en-us/azure/virtual-machines/scripts/virtual-machines-windows-powershell-sample-create-vm-from-managed-os-disks?toc=%2fpowershell%2fmodule%2ftoc.json)?
        # https://docs.microsoft.com/en-us/powershell/module/azurerm.compute/set-azurermvmosdisk?view=azurermps-4.2.0

        # Create a virtual machine configuration
        $vmConfig = New-AzureRmVMConfig -VMName $Name -VMSize  $Size `
            | Set-AzureRmVMOperatingSystem -Windows -ComputerName $Name -Credential $creds `
            | Set-AzureRmVMSourceImage `
                -PublisherName MicrosoftWindowsServer `
                -Offer WindowsServer `
                -Skus 2016-Datacenter `
                -Version latest `
            | Add-AzureRmVMNetworkInterface -Id $nic.Id

        # Create a virtual machine
        $vm = New-AzureRmVM -ResourceGroupName $resourceGroup -Location $location -VM $vmConfig

        # Write info about VM.

        # TODO: Remove these and make this a formatter.
        # Write-Info "$($tab)Resource group: $rgName.";
        # Write-Info "$($tab)VM Name: MyVm$random.";
        # Write-Info "$($tab)Location: $location.";
        # Write-Info "$($tab)FQDN: $fqdn.";
        Write-Info "$($tab)Username: $username.";
        Write-Info "$($tab)Password: $ptPassword.";

        return $vm;
    } catch {
        Write-Error $_;
        Write-Error "Something went wrong.  Issue the command again: it is idempotent. :)";
    }
}

Export-ModuleMember -Function New-AzVm

# Helpers.

function Use-ResourceGroup {
    param (
        [Parameter(Mandatory=$true)] [string] $ResourceGroup,
        [Parameter(Mandatory=$true)] [string] $Location
    )

    $rg = Get-AzureRmResourceGroup `
        | Where-Object { $_.ResourceGroupName -eq $ResourceGroup } `
        | Select-Object -First 1 -Wait;

    if($rg -eq $null) {
        return New-AzureRmResourceGroup -Name $ResourceGroup -Location $Location;
    } else {
        return $rg;
    }
}

function Use-Vnet {
    param (
        [Parameter(Mandatory=$true)] [string] $Name,
        [Parameter(Mandatory=$true)] [string] $ResourceGroup,
        [Parameter(Mandatory=$true)] [string] $Location,
        [Parameter(Mandatory=$true)] [string] $SubnetAddressPrefix,
        [Parameter(Mandatory=$true)] [string] $VnetAddressPrefix
    )

    $vnet = Get-AzureRmVirtualNetwork | Where-Object { $_.Name -eq $Name } | Select-Object -First 1 -Wait;

    if($vnet -eq $null) {
        # Create a subnet configuration.
        $subnetConfig = New-AzureRmVirtualNetworkSubnetConfig `
            -Name "$($Name)Subnet" `
            -AddressPrefix $SubnetAddressPrefix;

        # Create a virtual network.
        return New-AzureRmVirtualNetwork `
            -ResourceGroupName $ResourceGroup `
            -Location $Location `
            -Name $Name `
            -AddressPrefix $VnetAddressPrefix `
            -Subnet $subnetConfig
    } else {
        return $vnet;
    }
}

function Use-Pip {
    param (
        [Parameter(Mandatory=$true)] [string] $Name,
        [Parameter(Mandatory=$true)] [string] $ResourceGroup,
        [Parameter(Mandatory=$true)] [string] $Location,
        [Parameter(Mandatory=$true)] [string] $DnsLabel,
        [Parameter(Mandatory=$true)] [string] $AllocationMethod,
        [Parameter(Mandatory=$true)] [int] $IdleTimeoutInMinutes
    )

    $pip = Get-AzureRmPublicIpAddress | Where-Object { $_.Name -eq $Name } | Select-Object -First 1 -Wait;

    if($pip -eq $null) {
        # Create a public IP address and specify a DNS name.
        return New-AzureRmPublicIpAddress `
            -ResourceGroupName $ResourceGroup `
            -Location $Location `
            -Name $Name `
            -DomainNameLabel $DnsLabel `
            -AllocationMethod $AllocationMethod `
            -IdleTimeoutInMinutes $IdleTimeoutInMinutes;
    } else {
        return $pip;
    }
}

function Use-Nsg {
    param (
        [Parameter(Mandatory=$true)] [string] $Name,
        [Parameter(Mandatory=$true)] [string] $ResourceGroup,
        [Parameter(Mandatory=$true)] [string] $Location,
        [Parameter(Mandatory=$true)] [int[]] $OpenPorts
    )

    $nsg = Get-AzureRmNetworkSecurityGroup | Where-Object { $_.Name -eq $Name } | Select-Object -First 1 -Wait;

    if($nsg -eq $null) {
        $rules = New-Object `
            "System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.PSSecurityRule]";
        $priority = 1000;

        foreach($port in $OpenPorts)
        {
            $nsgRule = New-AzureRmNetworkSecurityRuleConfig `
                -Name myNetworkSecurityGroupRuleRDP `
                -Protocol Tcp `
                -Direction Inbound `
                -Priority $priority `
                -SourceAddressPrefix * `
                -SourcePortRange * `
                -DestinationAddressPrefix * `
                -DestinationPortRange $port `
                -Access Allow;
            $rules.Add($nsgRule);

            $priority--;
        }

        # Create an NSG.
        return New-AzureRmNetworkSecurityGroup `
            -ResourceGroupName $ResourceGroup `
            -Location $Location `
            -Name $Name `
            -SecurityRules $rules;
    } else {
        return $nsg;
    }
}

function Use-Nic {
    param (
        [Parameter(Mandatory=$true)] [string] $Name,
        [Parameter(Mandatory=$true)] [string] $ResourceGroup,
        [Parameter(Mandatory=$true)] [string] $Location,
        [Parameter(Mandatory=$true)] [string] $SubnetId,
        [Parameter(Mandatory=$true)] [string] $PublicIpAddressId,
        [Parameter(Mandatory=$true)] [psobject] $NetworkSecurityGroupId
    )

    $nic = Get-AzureRmNetworkInterface | Where-Object { $_.Name -eq $Name } | Select-Object -First 1 -Wait;

    if($nic -eq $null) {
        # Create a virtual network card and associate with public IP address and NSG
        return New-AzureRmNetworkInterface `
            -Name $Name `
            -ResourceGroupName $resourceGroup `
            -Location $location `
            -SubnetId $SubnetId `
            -PublicIpAddressId $PublicIpAddressId `
            -NetworkSecurityGroupId $NetworkSecurityGroupId.ToString();
    } else {
        return $nic;
    }
}

function Write-Info {
    param (
        [Parameter(Position=0, Mandatory=$true, ValueFromPipeline=$true)] [String] $Text
    )

    Write-Host $Text -ForegroundColor Cyan;
}

function Get-Hash {
    param (
        [Parameter(Position=0, Mandatory=$true, ValueFromPipeline=$true)] [String] $TextToHash,
        [int] $Count = 10
    )

    $hasher = new-object System.Security.Cryptography.SHA256Managed;
    $toHash = [System.Text.Encoding]::UTF8.GetBytes($TextToHash);
    $hashByteArray = $hasher.ComputeHash($toHash);

    foreach($byte in $hashByteArray)
    {
         $res += $byte.ToString();
    }

    return $res.substring(0, $Count);
}
