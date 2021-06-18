
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
Accept marketplace terms.
.Description
Accept marketplace terms.
.Example
PS C:\> New-AzConfluentMarketplaceAgreement -Accepted

Name    Type
----    ----
default Microsoft.Confluent/agreement

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResource
.Link
https://docs.microsoft.com/powershell/module/az.confluent/new-azconfluentmarketplaceagreement
#>
function New-AzConfluentMarketplaceAgreement {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Microsoft Azure subscription id
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If any version of the terms have been accepted, otherwise false.
    ${Accepted},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Link to HTML with Microsoft and Publisher terms.
    ${LicenseTextLink},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Plan identifier string.
    ${Plan},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Link to the privacy policy of the publisher.
    ${PrivacyPolicyLink},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Product identifier string.
    ${Product},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Publisher identifier string.
    ${Publisher},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.DateTime]
    # Date and time in UTC of when the terms were accepted.
    # This is empty if Accepted is false.
    ${RetrieveDatetime},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Terms signature.
    ${Signature},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
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
            CreateExpanded = 'Az.Confluent.private\New-AzConfluentMarketplaceAgreement_CreateExpanded';
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
