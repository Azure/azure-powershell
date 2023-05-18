function New-AzAzureStackHciNetworkInterfaceIpConfig{
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # List of DNS server IP Addresses for the interface
    ${Gateway},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # List of DNS server IP Addresses for the interface
    ${IpAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # List of DNS server IP Addresses for the interface
    ${IpAllocationMethod},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.Int32]
    # List of DNS server IP Addresses for the interface
    ${PrefixLength},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # List of DNS server IP Addresses for the interface
    ${SubnetId}
)
    $IpConfig = @{}

 
    if ($SubnetId -notmatch $vnetRegex){
    Write-Error "Invalid SubnetId: $SubnetId" -ErrorAction Stop
    }
    $IpConfig["SubnetId"] = $SubnetId
    

    if ($IpAllocationMethod){
          if ($IpAllocationMethod.ToLower() -ne "dynamic" -and $IpAllocationMethod.ToLower() -ne "static"){
            Write-Error "Invalid Ip Allocation method provided: $IpAllocationMethod. Accepted values are 'Dynamic' or 'Static'" -ErrorAction Stop
          }
          $IpAllocationMethod = $IpAllocationMethod.ToLower()
          
          if ($IpAllocationMethod -eq "static"){
            $IpConfig["PrivateIPAllocationMethod"] = 'Static'

            if (-Not $IpAddress){
              Write-Error "IpAddress is required for Static confguration." -ErrorAction Stop
            } else {
                if ($IpAddress -notmatch $ipv4Regex){
                  Write-Error "Invalid Ip Address provided : $IpAddress" -ErrorAction Stop
                } 
                $IpConfig["IPAddress"] = $IpAddress      
            }

            if ($Gateway){
              if ($Gateway-notmatch $ipv4Regex){
                Write-Error "Invalid Gateway Address : $Gateway" -ErrorAction Stop
              }
              $IpConfig["Gateway"] = $Gateway
            }

            if ($PrefixLength){
              if ($PrefixLength -gt 32 -and $PrefixLength -lt 0){
                Write-Error "Invalid Prefix Length : $PrefixLength" -ErrorAction Stop
              }
              $IpConfig["PrefixLength"] = [System.String]$PrefixLength
            }


          }else {
            $IpConfig["IPAllocationMethod"] = 'Dynamic'
          }

    }

    return $IpConfig

}

