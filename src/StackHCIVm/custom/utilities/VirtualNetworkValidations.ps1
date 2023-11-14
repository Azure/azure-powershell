function Confirm-IpPools{
[Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.DoNotExportAttribute()]
param(
    [Parameter()]
    [System.Collections.Hashtable[]]
    $IpPools
)

    foreach ($IpPool in $IpPools){
        foreach ($Key in $IpPool.Keys){
            if($Key.ToLower() -eq "end"){
                if ($IpPool[$Key] -notmatch $ipv4Regex){
                    Write-Error "Invalid ipaddress provided for IpPoolEnd : $IpPool[$Key]." -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "start"){ 
                if ($IpPool[$Key] -notmatch $ipv4Regex){
                    Write-Error "Invalid ipaddress provided for IpPoolStart : $IpPool[$Key]." -ErrorAction Stop
                }

            } elseif($Key.ToLower() -eq "type"){
                if ($IpPool[$Key] -ne "vm" -and  $IpPool[$Key] -ne "vippool"){
                    Write-Error  "Invalid IpPoolType provided: $IpPool[$Key]. Accepted values are 'vm' and 'vippool'." -ErrorAction Stop
                }

            } else {
                Write-Error "Invalid Key specified in IpPool object. Accpeted values are 'Start', 'End', and 'Type'." -ErrorAction Stop
            }
        }
    }
} 

function Confirm-Routes{
[Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.DoNotExportAttribute()]
param(
    [Parameter()]
    [System.Collections.Hashtable[]]
    $Routes 
)

    foreach ($Route in $Routes){
       foreach ($Key in $Route.Keys){
            if($Key.ToLower() -eq "addressprefix"){
                if ($Route[$Key] -notmatch $cidrRegex){
                    Write-Error "Invalid ipaddress provided for AddressPrefix for route : $Route[$Key]." -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "name"){ 
                if ($Route[$Key] -notmatch $subnetNameRegex){
                    Write-Error "Invalid subnet name provided for route: $Route[$Key]." -ErrorAction Stop
                }

            } elseif($Key.ToLower() -eq "nexthopipaddress"){
                if ($Route[$Key] -notmatch $ipv4Regex){
                    Write-Error  "Invalid ipaddress provided for NextHopIPAddress for route: $Route[$Key]." -ErrorAction Stop
                }

            } else {
                Write-Error "Invalid Key specified in IpPool object. Accpeted values are 'AddressPrefix', 'Name', and 'NextHopIPAddress'." -ErrorAction Stop
            }
        }
    }
} 

function Confirm-Subnets{
[Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.DoNotExportAttribute()]
param(
    [Parameter()]
    [System.Collections.Hashtable[]]
    $Subnets
)
    foreach ($Subnet in $Subnets){
        foreach ($Key in $Subnet.Keys){
            if($Key.ToLower() -eq "addressprefix"){
                if ($Subnet[$Key] -notmatch $cidrRegex){
                    Write-Error "Invalid ipaddress provided for AddressPrefix for subnet : $Subnet[$Key]." -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "ipallocationmethod"){
                if ($Subnet[$Key] -ne "Dynamic" -and $Subnet[$Key] -ne "Static"){
                    Write-Error "Invalid Ip Allocation method provided: $IpAllocationMethod. Accepted values are 'Dynamic' or 'Static'" -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "ippool"){
                Confirm-IpPools -IpPools $Subnet[$Key] 
            } elseif ($Key.ToLower() -eq "addressprefixes"){
                foreach ($addressPrefix in $Subnet[$Key]){
                    if ($addressPrefix -notmatch $cidrRegex){
                        Write-Error "Invalid AddressPrefix: $addressPrefix. Please use valid CIDR format." -ErrorAction Stop
                    }
                }
            } elseif ($Key.ToLower() -eq "name"){
                if ($Subnet[$Key] -notmatch $subnetNameRegex){
                    Write-Error "Invalid SubnetName:  $Subnet[$Key]. The name must start with an alphanumeric character, contain all alphanumeric characters or '-' or '_' or '.' and end with an alphanumeric character or '_'. The max length is 80 characters." -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "route"){
                Confirm-Routes -Routes $Subnet[$Key] 
            } elseif ($Key.ToLower() -eq "vlan"){
                if ($Subnet[$Key] -gt 4094 -or $Subnet[$Key] -lt 1){
                    Write-Error "Invalid value for Vlan : $Subnet[$Key]. Valid range is 1-4094"
                }
            } else {
                Write-Error "Invalid Key specified in Subnet object: $Subnet."
            }

        }
    }  
} 