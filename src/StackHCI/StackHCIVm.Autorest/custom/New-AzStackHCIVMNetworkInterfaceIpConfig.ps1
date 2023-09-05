function New-AzStackHciVMNetworkInterfaceIpConfig{
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Gateway for network interface
    ${Gateway},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # PrivateIPAddress - Private IP address of the IP configuration.
    ${IpAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
    ${IpAllocationMethod},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.Int32]
    # Prefix Length for network interface
    ${PrefixLength},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The ARM resource id of the Subnet.
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

