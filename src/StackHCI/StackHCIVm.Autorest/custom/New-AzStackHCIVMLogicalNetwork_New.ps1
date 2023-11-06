
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
The operation to create or update a logical network.
Please note some properties can be set only during logical network creation.
.Description
The operation to create or update a logical network.
Please note some properties can be set only during logical network creation.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

SUBNET <ISubnet[]>: Subnet - list of subnets under the logical network
  [AddressPrefix <String>]: The address prefix for the subnet: Cidr for this subnet - IPv4, IPv6.
  [IPAllocationMethod <IPAllocationMethodEnum?>]: IPAllocationMethod - The IP address allocation method. Possible values include: 'Static', 'Dynamic'
  [IPConfigurationReference <ISubnetPropertiesFormatIPConfigurationReferencesItem[]>]: IPConfigurationReferences - list of IPConfigurationReferences
    [Id <String>]: IPConfigurationID
  [IPPool <IIPPool[]>]: network associated pool of IP Addresses
    [End <String>]: End of the IP address pool
    [Name <String>]: Name of the IP-Pool
    [Start <String>]: Start of the IP address pool
    [Type <IPPoolTypeEnum?>]: Type of the IP Pool [vm, vippool]
  [Name <String>]: Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
  [PropertiesAddressPrefixes <String[]>]: List of address prefixes for the subnet.
  [Route <IRoute[]>]: Collection of routes contained within a route table.
    [AddressPrefix <String>]: The destination CIDR to which the route applies.
    [Name <String>]: Name - name of the subnet
    [NextHopIPAddress <String>]: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
  [Vlan <Int32?>]: Vlan to use for the subnet
.Link
https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhcivmlogicalnetwork
#>

function New-AzStackHCIVmLogicalNetwork {
  [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks])]
  [CmdletBinding( PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
  param(
      [Parameter(Mandatory)]
      [Alias('LogicalNetworkName')]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
      [System.String]
      # Name of the virtual network
      ${Name},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
      [System.String]
      # The name of the resource group.
      # The name is case insensitive.
      ${ResourceGroupName},

      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
      [System.String]
      # The ID of the target subscription.
      ${SubscriptionId},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # The geo-location where the resource lives
      ${Location},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # The name of the extended location.
      ${CustomLocationId},
   
      [Parameter()]
      [AllowEmptyCollection()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String[]]
      # The list of DNS servers IP addresses.
      ${DnsServer},
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags]))]
      [System.Collections.Hashtable]
      # Resource tags.
      ${Tag},
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # Name of the network switch to be used for VMs
      ${VMSwitchName},
  
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String[]]
      # List of address prefixes for the subnet.
      $AddressPrefix,
  
      [Parameter()]
      [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPAllocationMethodEnum])]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # The IP address allocation method. Possible values include: 'Static', 'Dynamic'
      $IpAllocationMethod, 
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # End of the ip address pool
      $IpPoolEnd, 
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # Start of the ip address pool
      $IpPoolStart, 
  
      [Parameter()]
      [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPPoolTypeEnum])]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # Ip pool type
      $IpPoolType, 
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.Collections.Hashtable[]]
      # Network associated pool of IP Addresses
      $IpPool,
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.Collections.Hashtable[]]
      # Collection of routes contained within a route table.
      $Route, 
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.String]
      # Name of the subnet
      $SubnetName, 
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.Collections.Hashtable[]]
      # List of subnets under the virtual network
      $Subnets, 
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
      [System.Int32]
      # Vlan to use for the subnet
      $Vlan 
  
  )
  
      if ($Name -notmatch $vnetNameRegex){
        Write-Error "Invalid Name:  $Name. The name must start with an alphanumeric character, contain all alphanumeric characters or '-' or '_' or '.' and end with an alphanumeric character or '_'. The max length is 64 characters." -ErrorAction Stop
      }
  
      if ($CustomLocationId -notmatch $customLocationRegex){
        Write-Error "Invalid CustomLocationId: $CustomLocationId" -ErrorAction Stop
      } 
  
      if ($DnsServer){
        foreach ($DnsServ in $DnsServer){
          if ($DnsServ -notmatch $ipv4Regex){
              Write-Error "Invalid ipaddress provided for Dns Servers : $DnsServ." -ErrorAction Stop
          }
        }
      }
  
      if ($Subnets){
        Confirm-Subnets -Subnets $Subnets
        $null = $PSBoundParameters.Remove("Subnets")
        $PSBoundParameters.Add("Subnet", $Subnets)
  
      } else{
          $Subnet = @{}
          if ($IpAllocationMethod){
            if ($IpAllocationMethod.ToLower() -ne "dynamic" -and $IpAllocationMethod.ToLower() -ne "static"){
              Write-Error "Invalid Ip Allocation method provided: $IpAllocationMethod. Accepted values are 'dynamic' or 'static'" -ErrorAction Stop
            }
            $IpAllocationMethod = $IpAllocationMethod.ToLower()
            
            if ($IpAllocationMethod -eq "static"){
              $Subnet["IPAllocationMethod"] = 'Static'
              if (-Not $AddressPrefix){
                Write-Error "Invalid Configuration for Static IpAllocationMethod. AddressPrefix are required for Static IpAllocationMethod." -ErrorAction Stop
              }
            }
          } else {
            $Subnet["IPAllocationMethod"] = 'Dynamic'
          }
  
          if ($IpPoolStart -and $IpPoolEnd){
            if($IpPoolStart -notmatch $ipv4Regex){
              Write-Error "Invalid Ip Address provided : $IpPoolStart" -ErrorAction Stop
            }
  
            if($IpPoolEnd -notmatch $ipv4Regex){
              Write-Error "Invalid Ip Address provided : $IpPoolEnd" -ErrorAction Stop
            }
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
  
          if ($IpPool){
            Confirm-IpPools -IpPools $IpPool
            $Subnet["IPPool"] = $IpPool
          }
  
          if($Vlan){
            if ($Vlan -gt 4094 -or $Vlan -lt 1){
              Write-Error "Invalid value for Vlan : $Vlan. Valid range is 1-4094" -ErrorAction Stop
            }
            $Subnet["Vlan"] = $Vlan
          }
  
          if ($SubnetName){
            if ($SubnetName -notmatch $subnetNameRegex){
               Write-Error "Invalid SubnetName: $SubnetName. The name must start with an alphanumeric character, contain all alphanumeric characters or '-' or '_' or '.' and end with an alphanumeric character or '_'. The max length is 80 characters." -ErrorAction Stop
            }
            $Subnet["Name"] = $SubnetName
          }
  
          if ($AddressPrefix){
            foreach ($addPrefix in $AddressPrefix){
              if ($addPrefix -notmatch $cidrRegex){
                Write-Error "Invalid AddressPrefix: $addPrefix. Please use valid CIDR format." -ErrorAction Stop
              }
            }
  
            if ($AddressPrefix.length -eq 1){
              $Subnet["AddressPrefix"] = $AddressPrefix[0]
            } else {
              $Subnet["AddressPrefixes"] = $AddressPrefix
            }
  
          }
  
          if ($Route){
            Confirm-Routes -Routes $Route
            $Subnet["Route"] = $Route
  
          }
        
          $null = $PSBoundParameters.Remove("IpAllocationMethod")
          $null = $PSBoundParameters.Remove("IpPoolStart")
          $null = $PSBoundParameters.Remove("IpPoolEnd")
          $null = $PSBoundParameters.Remove("IpPoolType")
          $null = $PSBoundParameters.Remove("AddressPrefix")
          $null = $PSBoundParameters.Remove("Vlan")
          $null = $PSBoundParameters.Remove("SubnetName")
          $null = $PSBoundParameters.Remove("IpPool")
          $null = $PSBoundParameters.Remove("Route")
          $PSBoundParameters.Add("Subnet", $Subnet)
  
      } 
     
      return Az.StackHCIVm.internal\New-AzStackHCIVmLogicalNetwork @PSBoundParameters
  }
  