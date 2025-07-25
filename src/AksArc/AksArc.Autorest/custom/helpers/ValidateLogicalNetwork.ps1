function ValidateLogicalNetwork {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [PSCustomObject]
        $lnet,

        [Parameter(Mandatory)]
        [System.String]
        $ControlPlaneIP
    )
    process {
        if (-Not (IsValidIp $ControlPlaneIP)) {
            return "Control Plane HostIP $ControlPlaneIP is not a valid IP address. Read aka.ms/aks-arc-networking-requirements for more information."
        }

        $lnetName = $lnet.name

        if ($lnet.properties.dhcpOptions.length -eq 0) {
            return "For creating Kubernetes clusters, DNS server in the logical network is a required input. Logical network $lnetName does not have a DNS server. Update the logical network or use a new logical network with a DNS server."
        }

        # Loop through subnets
        for ($i = 0; $i -lt $lnet.properties.subnets.length; $i++) {

            $addressPrefix = $lnet.properties.subnets.properties.addressPrefix
            $prefixStart, $prefixEnd = cidrToIpRange $addressPrefix

            if ($lnet.properties.subnets[$i].properties.ipAllocationMethod -ceq "dynamic") {
                $retErr = "Logical network $lnetName with IP allocation method Dynamic is not supported. Create a new or use an existing logical network of Static IP allocation method. Read aka.ms/aks-arc-networking-requirements for more information."
                Continue
            }

            if ($lnet.properties.subnets[$i].properties.ipPools.length -eq 0) {
                $retErr = "Logical network $lnetName does not have an ippool. Read aka.ms/aks-arc-networking-requirements for more information."
                Continue
            }

            # Loop through ip pools
            for ($j = 0; $j -lt $lnet.properties.subnets[$i].properties.ipPools.length; $j++) {
                $ipPoolStart = $lnet.properties.subnets[$i].properties.ipPools[$j].start
                $ipPoolEnd = $lnet.properties.subnets[$i].properties.ipPools[$j].end
        
                if (-Not (IsValidIp $ipPoolStart)) {
                    $retErr = "Logical network $lnetName does not have a valid ip pool start address $ipPoolStart. Read aka.ms/aks-arc-networking-requirements for more information."
                    Continue
                }
        
                if (-Not (IsValidIp $ipPoolEnd)) {
                    $retErr = "Logical network $lnetName does not have a valid ip pool end address $ipPoolEnd. Read aka.ms/aks-arc-networking-requirements for more information."
                    Continue
                }
        
                if (-Not (IsIpAddressInRange $ControlPlaneIP $prefixStart $prefixEnd)) {
                    $retErr = "The control plane IP $ControlPlaneIP should be within the address prefixes $addressPrefix of the logical network $lnetName, but outside the IP pool $ipPoolStart - $ipPoolEnd. Read aka.ms/aks-arc-networking-requirements for more information."
                    Continue
                }
        
                if (IsIpAddressInRange $ControlPlaneIP $ipPoolStart $ipPoolEnd) {
                    $retErr = "The control plane IP $ControlPlaneIP should be within the address prefixes $addressPrefix of the logical network $lnetName, but outside the IP pool $ipPoolStart - $ipPoolEnd. Read aka.ms/aks-arc-networking-requirements for more information."
                    Continue
                }
            }
            if (-Not $retErr) {
                return
            }
        }

        return $retErr
    }
}

function IsValidIp {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [string] $ipAddress
    ) 

    if ([ipaddress]::TryParse($ipAddress, [ref][ipaddress]::Loopback)) {
        return $true
    } else {
        return $false
    }
}

function IsIpAddressInRange {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
      [System.Version] $IPAddress,
      [System.Version] $FromAddress,
      [System.Version] $ToAddress
    )
    $FromAddress -le $IPAddress -and $IPAddress -le $ToAddress
  }

function cidrToIpRange {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param (
        [string] $cidrNotation
    )

    $addr, $maskLength = $cidrNotation -split '/'
    [int]$maskLen = 0
    if (-not [int32]::TryParse($maskLength, [ref] $maskLen)) {
        throw "Cannot parse CIDR mask length string: '$maskLen'"
    }
    if (0 -gt $maskLen -or $maskLen -gt 32) {
        throw "CIDR mask length must be between 0 and 32"
    }
    $ipAddr = [Net.IPAddress]::Parse($addr)
    if ($ipAddr -eq $null) {
        throw "Cannot parse IP address: $addr"
    }
    if ($ipAddr.AddressFamily -ne [Net.Sockets.AddressFamily]::InterNetwork) {
        throw "Can only process CIDR for IPv4"
    }

    $shiftCnt = 32 - $maskLen
    $mask = -bnot ((1 -shl $shiftCnt) - 1)
    $ipNum = [Net.IPAddress]::NetworkToHostOrder([BitConverter]::ToInt32($ipAddr.GetAddressBytes(), 0))
    $ipStart = ($ipNum -band $mask)
    $ipEnd = ($ipNum -bor (-bnot $mask))

    # return as tuple of strings:
    ([BitConverter]::GetBytes([Net.IPAddress]::HostToNetworkOrder($ipStart)) | ForEach-Object { $_ } ) -join '.'
    ([BitConverter]::GetBytes([Net.IPAddress]::HostToNetworkOrder($ipEnd)) | ForEach-Object { $_ } ) -join '.'
}