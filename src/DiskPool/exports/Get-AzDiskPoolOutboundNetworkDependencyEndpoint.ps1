
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
Gets the network endpoints of all outbound dependencies of a Disk Pool
.Description
Gets the network endpoints of all outbound dependencies of a Disk Pool
.Example
PS C:\>  Get-AzDiskPoolOutboundNetworkDependencyEndpoint -DiskPoolName disk-pool-1 -ResourceGroupName storagepool-rg-test | ft -Wrap

Category              Endpoint
--------              --------
Microsoft Event Hub   {{
                        "domainName": "evhns-rp-prod-eus2euap.servicebus.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
Microsoft Service Bus {{
                        "domainName": "sb-rp-prod-eus2euap.servicebus.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
Microsoft Storage     {{
                        "domainName": "strpprodeus2euap.blob.core.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }, {
                        "domainName": "stbsprodeus2euap.blob.core.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
Microsoft Apt Mirror  {{
                        "domainName": "azure.archive.ubuntu.com",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IOutboundEnvironmentEndpoint
.Link
https://docs.microsoft.com/powershell/module/az.diskpool/get-azdiskpooloutboundnetworkdependencyendpoint
#>
function Get-AzDiskPoolOutboundNetworkDependencyEndpoint {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IOutboundEnvironmentEndpoint])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the Disk Pool.
    ${DiskPoolName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            List = 'Az.DiskPool.private\Get-AzDiskPoolOutboundNetworkDependencyEndpoint_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
