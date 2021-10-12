
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
Create Organization resource
.Description
Create Organization resource
.Example
PS C:\> New-AzConfluentOrganization -ResourceGroupName azure-rg-test -Name confluentorg-02-pwsh -Location eastus -OfferDetailId "confluent-cloud-azure-prod" -OfferDetailPlanId "confluent-cloud-azure-payg-prod" -OfferDetailPlanName "Confluent Cloud - Pay as you Go" -OfferDetailPublisherId "confluentinc" -OfferDetailTermUnit "P1M" -UserDetailEmailAddress "xxxx@microsoft.com"

Location Name                   Type
-------- ----                   ----
eastus   confluentorg-02-pwsh Microsoft.Confluent/organizations

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResource
.Link
https://docs.microsoft.com/powershell/module/az.confluent/new-azconfluentorganization
#>
function New-AzConfluentOrganization {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('OrganizationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Path')]
    [System.String]
    # Organization resource name
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Path')]
    [System.String]
    # Resource group name
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Microsoft Azure subscription id
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Location of Organization resource
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Offer Id
    ${OfferDetailId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Offer Plan Id
    ${OfferDetailPlanId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Offer Plan Name
    ${OfferDetailPlanName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Publisher Id
    ${OfferDetailPublisherId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Offer Plan Term unit
    ${OfferDetailTermUnit},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags]))]
    [System.Collections.Hashtable]
    # Organization resource tags
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Email address
    ${UserDetailEmailAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # First name
    ${UserDetailFirstName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Body')]
    [System.String]
    # Last name
    ${UserDetailLastName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            CreateExpanded = 'Az.Confluent.private\New-AzConfluentOrganization_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
