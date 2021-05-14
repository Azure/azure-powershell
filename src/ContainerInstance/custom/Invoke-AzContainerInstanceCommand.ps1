
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
Executes a command for a specific container instance in a specified resource group and container group.
.Description
Executes a command for a specific container instance in a specified resource group and container group.
.Example
PS C:\> Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello" -TerminalSizeCol 12 -TerminalSizeRow 12

Password                                           WebSocketUri
--------                                           ------------
****************** wss://bridge-linux-xx.eastus.management.azurecontainer.io/exec/caas-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/bridge-xxxxxxxxxxxxxxx?rows=12&cols=12api-version=2018-02-01-preview

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecResponse
.Link
https://docs.microsoft.com/powershell/module/az.containerinstance/invoke-azcontainerinstancecommand
#>
function Invoke-AzContainerInstanceCommand {
  [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecResponse])]
  [CmdletBinding(DefaultParameterSetName='ExecuteExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
  param(
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
      [System.String]
      # The name of the container group.
      ${ContainerGroupName},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
      [System.String]
      # The name of the container instance.
      ${ContainerName},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
      [System.String]
      # The name of the resource group.
      ${ResourceGroupName},
  
      [Parameter()]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
      [System.String]
      # Subscription credentials which uniquely identify Microsoft Azure subscription.
      # The subscription ID forms part of the URI for every service call.
      ${SubscriptionId},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
      [System.String]
      # The command to be executed.
      ${Command},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
      [System.Int32]
      # The column size of the terminal
      ${TerminalSizeCol},
  
      [Parameter(Mandatory)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
      [System.Int32]
      # The row size of the terminal
      ${TerminalSizeRow},
  
      [Parameter()]
      [Alias('AzureRMContext', 'AzureCredential')]
      [ValidateNotNull()]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Azure')]
      [System.Management.Automation.PSObject]
      # The credentials, account, tenant, and subscription used for communication with Azure.
      ${DefaultProfile},
  
      [Parameter(DontShow)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
      [System.Management.Automation.SwitchParameter]
      # Wait for .NET debugger to attach
      ${Break},
  
      [Parameter(DontShow)]
      [ValidateNotNull()]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SendAsyncStep[]]
      # SendAsync Pipeline Steps to be appended to the front of the pipeline
      ${HttpPipelineAppend},
  
      [Parameter(DontShow)]
      [ValidateNotNull()]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SendAsyncStep[]]
      # SendAsync Pipeline Steps to be prepended to the front of the pipeline
      ${HttpPipelinePrepend},
  
      [Parameter(DontShow)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
      [System.Uri]
      # The URI for the proxy server to use
      ${Proxy},
  
      [Parameter(DontShow)]
      [ValidateNotNull()]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
      [System.Management.Automation.PSCredential]
      # Credentials for a proxy server to use for the remote call
      ${ProxyCredential},
  
      [Parameter(DontShow)]
      [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
      [System.Management.Automation.SwitchParameter]
      # Use the default credentials for the proxy
      ${ProxyUseDefaultCredentials}
  )
    process {
      try {
        Az.ContainerInstance.internal\Invoke-AzContainerInstanceCommand @PSBoundParameters
      } catch {
        throw
      }
    }
  }
