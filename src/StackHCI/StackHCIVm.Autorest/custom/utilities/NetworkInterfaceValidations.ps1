function Confirm-IpConfigrations{
[Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.DoNotExportAttribute()]
param(
    [Parameter()]
    [System.Collections.Hashtable[]]
    $IpConfigurations
)
     foreach ($IpConfig in $IpConfigurations){
        foreach ($Key in $IpConfig.Keys){
            if($Key.ToLower() -eq "gateway"){
                if ($IpConfig[$Key] -notmatch $ipv4Regex){
                    Write-Error "Invalid Gateway Address : $IpConfig[$Key]" -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "name"){ 
                
            } elseif ($Key.ToLower() -eq "prefixlength"){
                if ($IpConfig[$Key]  -gt 32 -and $IpConfig[$Key]  -lt 0){
                    Write-Error "Invalid Prefix Length : $IpConfig[$Key] " -ErrorAction Stop
                }
            } elseif ($Key.ToLower() -eq "ipaddress") {
                if ($IpConfig[$Key] -notmatch $ipv4Regex){
                  Write-Error "Invalid Ip Address provided : $IpConfig[$Key]" -ErrorAction Stop
                } 
            } elseif ($Key.ToLower() -eq "ipallocationmethod"){
                if ($IpConfig[$Key].ToLower() -ne "dynamic" -and $IpConfig[$Key].ToLower() -ne "static"){
                    Write-Error "Invalid Ip Allocation method provided: $IpConfig[$Key]. Accepted values are 'Dynamic' or 'Static'" -ErrorAction Stop
                }
            }  elseif ($Key.ToLower() -eq "subnetid"){
                if ($IpConfig[$Key]-notmatch $vnetRegex){
                    Write-Error "Invalid SubnetId: $IpConfig[$Key]" -ErrorAction Stop
                }
            } else {
                  Write-Error "Invalid Key specified in IpConfigurations object: $IpConfig[$Key]" -ErrorAction Stop
            }

        }
    }

}