
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

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.INetworkInterfaces
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
function New-AzStackHCIVMNetworkInterface {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.INetworkInterfaces])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('NetworkInterfaceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # Name of the Network Interface
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The name of the extended location.
    ${CustomLocationId},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String[]]
    # List of DNS server IP Addresses for the interface
    ${DnsServer},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # PrivateIPAddress - Private IP address of the IP configuration.
    ${IpAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # MacAddress - The MAC address of the network interface.
    ${MacAddress},
    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    #  The ARM resource id of the Subnet.
    ${SubnetId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    #  The name of the Subnet.
    ${SubnetName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # Resource Group of the Subnet.
    ${SubnetResourceGroup},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.Collections.Hashtable[]]
    # A list of IPConfigurations of the network interface.
    ${IpConfiguration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}

)

  if ($Name -notmatch $nicNameRegex){
      Write-Error "Invalid Name:  $Name. The name must start with an alphanumeric character, contain all alphanumeric characters or '-' or '_' or '.' and end with an alphanumeric character or '_'. The max length is 80 characters." -ErrorAction Stop
  }
  if ($CustomLocationId -notmatch $customLocationRegex){
      Write-Error "Invalid CustomLocationId: $CustomLocationId" -ErrorAction Stop
  } 

  $null = $PSBoundParameters.Remove("MacAddress")
  $null = $PSBoundParameters.Remove("DnsServer")
  $null = $PSBoundParameters.Remove("Tag")


  if (-Not $IpConfiguration){
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
      }
        
      $null = $PSBoundParameters.Remove("Name")
      $null = $PSBoundParameters.Remove("ResourceGroupName")
      $null = $PSBoundParameters.Remove("SubscriptionId")
      $null = $PSBoundParameters.Remove("Location")
      $null = $PSBoundParameters.Remove("CustomLocationId")
      $null = $PSBoundParameters.Remove("SubnetId")
      $null = $PSBoundParameters.Remove("IpAddress")
       
      $PSBoundParameters.Add("ResourceId", $SubnetId)
      $subnet = Az.StackHCIVM\Get-AzStackHCIVMLogicalNetwork @PSBoundParameters


      if ($subnet -eq $null) {
        Write-Error "A Logical Network with id : $SubnetId does not exist." -ErrorAction Stop
      }   

      $IpConfig["SubnetId"] = $SubnetId

      $null = $PSBoundParameters.Remove("ResourceId")
      $PSBoundParameters.Add("Name", $Name)
      $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
      $PSBoundParameters.Add("SubscriptionId", $SubscriptionId)
      $PSBoundParameters.Add("Location", $Location)
      $PSBoundParameters.Add("CustomLocationId", $CustomLocationId)

      
    
      if ($IpAddress){
        if ($IpAddress -notmatch $ipv4Regex){
            Write-Error "Invalid Ip Address provided : $IpAddress" -ErrorAction Stop
        } 
        $IpConfig["IPAddress"] = $IpAddress   
      }
      

      $PSBoundParameters.Add("IPConfiguration", $IpConfig)

  }
  
  if ($MacAddress){
    if ($MacAddress -notmatch $macAddressRegex){
      Write-Error "Invalid MacAddress: $MacAddress." -ErrorAction Stop
    }
    $PSBoundParameters.Add("MacAddress", $MacAddress)
  }

  if ($DnsServer){
      foreach ($DnsServ in $DnsServer){
        if ($DnsServ -notmatch $ipv4Regex){
            Write-Error "Invalid ipaddress provided for Dns Servers : $DnsServ." -ErrorAction Stop
        }
      }
      $PSBoundParameters.Add("DnsServer", $DnsServer)
  }

  if ($Tag){
    $PSBoundParameters.Add("Tag", $Tag)
  }
  
  try{
    Az.StackHCIVM.internal\New-AzStackHCIVMNetworkInterface -ErrorAction Stop @PSBoundParameters 
  } catch {
    $e = $_
    if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
        Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
    } else {
        Write-Error $e.Exception.Message -ErrorAction Stop
    }
  }
  
}
