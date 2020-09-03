
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
Lists the access key for the specified configuration store.
.Description
Lists the access key for the specified configuration store.
.Example
PS C:\> Get-AzAppConfigurationStoreKey -Name appconfig-test01 -ResourceGroupName azpwsh-manual-test

ConnectionString                                                                                                                     LastModified        Name                ReadOnly Value
----------------                                                                                                                     ------------        ----                -------- -----
Endpoint=https://appconfig-test01.azconfig.io;Id=TvV0-l0-s0:osSixtp4xggJYFlsJyYl;Secret=Bfxnosrs952PTGxvb2bdFtlTDCBPFDTlBATuEO5kRbc= 5/7/2020 9:09:27 AM Primary             False    Bfxnosrs952PTGxvb2bdFtlTDCBPFDTlBATuEO5k...
Endpoint=https://appconfig-test01.azconfig.io;Id=gcxl-l0-s0:JfSn6JA9UFkRj7/3GVTu;Secret=0fH4qQ+LLvKUKEiT3kICQTEbV0WNMi4xNu9RZxPx6X0= 5/7/2020 9:09:27 AM Secondary           False    0fH4qQ+LLvKUKEiT3kICQTEbV0WNMi4xNu9RZxPx...
Endpoint=https://appconfig-test01.azconfig.io;Id=Sl1p-l0-s0:jVozhIOYoXZ9k5pCjWa2;Secret=bAmj8BqcHguVraXNAJfuD1bDR+gzlfk2hf8ZSZhE9Ik= 5/7/2020 9:09:27 AM Primary Read Only   True     bAmj8BqcHguVraXNAJfuD1bDR+gzlfk2hf8ZSZhE...
Endpoint=https://appconfig-test01.azconfig.io;Id=htND-l0-s0:GN83PmhOFYlAlcXHN2/6;Secret=n2tp5evU2F4Z1QkctG2TgZkgMxojEkod3KTEaEgcSMQ= 5/7/2020 9:09:27 AM Secondary Read Only True     n2tp5evU2F4Z1QkctG2TgZkgMxojEkod3KTEaEgc...

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IApiKey
.Link
https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/get-azappconfigurationstorekey
#>
function Get-AzAppConfigurationStoreKey {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IApiKey])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Path')]
    [System.String]
    # The name of the configuration store.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Path')]
    [System.String]
    # The name of the resource group to which the container registry belongs.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Microsoft Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
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
            List = 'Az.AppConfiguration.private\Get-AzAppConfigurationStoreKey_List';
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
