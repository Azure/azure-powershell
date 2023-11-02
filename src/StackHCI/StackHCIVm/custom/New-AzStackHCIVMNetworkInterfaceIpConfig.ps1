
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
The operation to create  network interface ip config.
.Description
The operation to create  network interface ip config.

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


function New-AzStackHciVMNetworkInterfaceIpConfig{
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # PrivateIPAddress - Private IP address of the IP configuration.
    ${IpAddress},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The ARM resource id of the Subnet.
    ${SubnetId}
)
    $IpConfig = @{}

    $IpConfig["Name"] = "ipconfig"
    if ($SubnetId -notmatch $lnetRegex){
    Write-Error "Invalid SubnetId: $SubnetId" -ErrorAction Stop
    }
    $IpConfig["SubnetId"] = $SubnetId

    if ($IpAddress){
      if ($IpAddress -notmatch $ipv4Regex){
          Write-Error "Invalid Ip Address provided : $IpAddress" -ErrorAction Stop
      } 
    $IpConfig["IPAddress"] = $IpAddress   
    }
  
    return $IpConfig

}

