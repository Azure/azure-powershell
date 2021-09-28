
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
Create or update a Maps Account.
A Maps Account holds the keys which allow access to the Maps REST APIs.
.Description
Create or update a Maps Account.
A Maps Account holds the keys which allow access to the Maps REST APIs.
.Example
PS C:\> New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus

Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount
.Link
https://docs.microsoft.com/powershell/module/az.maps/new-azmapsaccount
#>
function New-AzMapsAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('AccountName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [System.String]
    # The name of the Maps Account.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name])]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name]
    # The name of the SKU, in standard format (such as S0).
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support.
    # This will disable Shared Keys authentication from any usage.
    ${DisableLocalAuth},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind])]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind]
    # Get or Set Kind property.
    ${Kind},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
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
            CreateExpanded = 'Az.Maps.private\New-AzMapsAccount_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
