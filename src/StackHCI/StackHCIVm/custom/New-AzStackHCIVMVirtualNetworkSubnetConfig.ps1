
function New-AzStackHciVMVirtualNetworkSubnetConfig{
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # List of address prefixes for the subnet.
    $AddressPrefixes,

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The IP address allocation method. Possible values include: 'Static', 'Dynamic'
    $IpAllocationMethod, 

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # End of the ip address pool
    $IpPoolEnd, 

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Start of the ip address pool
    $IpPoolStart, 

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Ip pool type
    $IpPoolType, 

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.Collections.Hashtable[]]
    # Network associated pool of IP Addresses
    $IpPools,

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.Collections.Hashtable[]]
    # Collection of routes contained within a route table.
    $Routes, 

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Name of the subnet
    $SubnetName, 

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.Int32]
    # Vlan to use for the subnet
    $Vlan
)
    $Subnet = @{}
    if ($IpAllocationMethod){
        if ($IpAllocationMethod.ToLower() -ne "dynamic" -and $IpAllocationMethod.ToLower() -ne "static"){
        Write-Error "Invalid Ip Allocation method provided: $IpAllocationMethod. Accepted values are 'dynamic' or 'static'" -ErrorAction Stop
        }
        $IpAllocationMethod = $IpAllocationMethod.ToLower()
        
        if ($IpAllocationMethod -eq "static"){
            $Subnet["IPAllocationMethod"] = 'Static'
            if(-Not ($IpPools -or ($IpPoolEnd -and $IpPoolStart))){
                Write-Error "IpPools or IpPoolStart and IpPoolEnd required for IpAllocationMethod Static."
            } 
            if (-Not $AddressPrefixes){
                Write-Error "AddressPrefixes required for IpAllocationMethod Static."
            }
        }
    } 
    else {
        $Subnet["IPAllocationMethod"] = 'Dynamic'
    }

    if ($IpPoolStart -and $IpPoolEnd){
        $IpPool = @{End = $IpPoolEnd; Start = $IpPoolStart}
        if ($IpPoolType){
        $IpPoolType = $IpPoolType.ToLower()
        if ($IpPoolType -ne "vm" -and $IpPoolType -ne "vippool"){
            Write-Error "Invalid IpPoolType provided: $IpPoolType. Accepted values are 'vm' and 'vippool'."
        }
        $IpPool['Type'] = $IpPoolType
        }
        $Subnet["IPPool"] = @($IpPool)
    } elseif ($IpPoolStart -or $IpPoolEnd){
        Write-Error "Both IpPoolStart and IpPoolEnd must be specified together." -ErrorAction Stop
    }

    if ($IpPools){
        Confirm-IpPools -IpPools $IpPools
        $Subnet["IPPool"] = $IpPools
    }

    if( $Vlan){
        if ($Vlan -gt 4094 -or $Vlan -lt 1){
        Write-Error "Invalid value for Vlan : $Vlan. Valid range is 1-4094"
        }
        $Subnet["Vlan"] = $Vlan
    }

    if ($SubnetName){
        if ($SubnetName -notmatch $subnetNameRegex){
            Write-Error "Invalid SubnetName: $SubnetName. The name must start with an alphanumeric character, contain all alphanumeric characters or '-' or '_' or '.' and end with an alphanumeric character or '_'. The max length is 80 characters." -ErrorAction Stop
        }
        $Subnet["Name"] = $SubnetName
    }

    if ($AddressPrefixes){
        foreach ($addressPrefix in $AddressPrefixes){
            if ($addressPrefix -notmatch $cidrRegex){
                Write-Error "Invalid AddressPrefix: $addressPrefix. Please use valid CIDR format." -ErrorAction Stop
            }
        }

        if ($AddressPrefixes.length -eq 1){
            $Subnet["AddressPrefix"] = $AddressPrefixes[0]
        } else {
            $Subnet["AddressPrefixes"] = $AddressPrefixes
        }
    }

    if ($Routes){
        Confirm-Routes -Routes $Routes
        $Subnet["Route"] = $Routes
    }

        return $Subnet  
} 