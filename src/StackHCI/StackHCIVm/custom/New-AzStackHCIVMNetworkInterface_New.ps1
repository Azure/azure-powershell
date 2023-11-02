
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
The operation to create or update a network interface.
Please note some properties can be set only during network interface creation.
.Description
The operation to create or update a network interface.
Please note some properties can be set only during network interface creation.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.INetworkInterfaces
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

IPCONFIGURATION <IIPConfiguration[]>: IPConfigurations - A list of IPConfigurations of the network interface.
  [IPAddress <String>]: PrivateIPAddress - Private IP address of the IP configuration.
  [Name <String>]: Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
  [SubnetId <String>]: ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmnetworkinterface
#>
function New-AzStackHciVMNetworkInterface {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.INetworkInterfaces])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('NetworkInterfaceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # Name of the Network Interface
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The name of the extended location.
    ${CustomLocationId},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # List of DNS server IP Addresses for the interface
    ${DnsServers},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # PrivateIPAddress - Private IP address of the IP configuration.
    ${IpAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # MacAddress - The MAC address of the network interface.
    ${MacAddress},
    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    #  The ARM resource id of the Subnet.
    ${SubnetId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    #  The name of the Subnet.
    ${SubnetName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Resource Group of the Subnet.
    ${SubnetResourceGroup},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.Collections.Hashtable[]]
    # A list of IPConfigurations of the network interface.
    ${IpConfigurations},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api30.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tags}

)

  if ($Name -notmatch $nicNameRegex){
      Write-Error "Invalid Name:  $Name. The name must start with an alphanumeric character, contain all alphanumeric characters or '-' or '_' or '.' and end with an alphanumeric character or '_'. The max length is 80 characters." -ErrorAction Stop
  }
  if ($CustomLocationId -notmatch $customLocationRegex){
      Write-Error "Invalid CustomLocationId: $CustomLocationId" -ErrorAction Stop
  } 
  if ($MacAddress){
    if ($MacAddress -notmatch $macAddressRegex){
      Write-Error "Invalid MacAddress: $MacAddress." -ErrorAction Stop
    }
  }
  if ($DnsServers){
      foreach ($DnsServer in $DnsServers){
        if ($DnsServer -notmatch $ipv4Regex){
            Write-Error "Invalid ipaddress provided for Dns Servers : $DnsServer." -ErrorAction Stop
        }
      }
  }


  if ($IpConfigurations){
    $PSBoundParameters.Add("IPConfiguration", $IpConfigurations)

  } else {
    $IpConfig = @{}
    if ($SubnetName){
      $rg = $ResourceGroupName
      if ($SubnetResourceGroup){
        $rg = $SubnetResourceGroup
      }
      $SubnetId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/logicalNetworks/$SubnetName"
      $null = $PSBoundParameters.Remove("SubnetName")
      $null = $PSBoundParameters.Remove("SubnetResourceGroup")
    }

    if (-Not $SubnetId){
      Write-Error "No Subnet provided. Either IpConfigurations or SubnetId or SubnetName is required." -ErrorAction Stop
    } else {
      if ($SubnetId -notmatch $vnetRegex){
        Write-Error "Invalid SubnetId: $SubnetId" -ErrorAction Stop
      }
      
      $subnet = Az.StackHciVM\Get-AzStackHciVMLogicalNetwork -ResourceId $SubnetId  -ErrorAction SilentlyContinue

      if ($subnet -eq $null){
        Write-Error "A Logical Network with id : $SubnetId does not exist." -ErrorAction Stop
      }
      
      $IpConfig["SubnetId"] = $SubnetId
    }

   
    if ($IpAddress){
      if ($IpAddress -notmatch $ipv4Regex){
          Write-Error "Invalid Ip Address provided : $IpAddress" -ErrorAction Stop
      } 
      $IpConfig["IPAddress"] = $IpAddress   
    }
    

    $null = $PSBoundParameters.Remove("SubnetId")
    $null = $PSBoundParameters.Remove("IpAddress")

    $PSBoundParameters.Add("IPConfiguration", $IpConfig)

  }

    return Az.StackHciVM.internal\New-AzStackHciVMNetworkInterface @PSBoundParameters

}
