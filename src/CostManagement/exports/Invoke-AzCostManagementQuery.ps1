
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
Query the usage data for scope defined.
.Description
Query the usage data for scope defined.
.Example
PS C:\> Invoke-AzCostManagementQuery -Scope "/subscriptions/***********" -Timeframe MonthToDate -Type Usage -DatasetGranularity 'Daily'

Column                Row
------                ---
{UsageDate, Currency} {20201101 USD, 20201102 USD, 20201103 USD, 20201104 USD…}
.Example
PS C:\> $dimensions = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Value 'API'
$filter = New-AzCostManagementQueryFilterObject -Dimensions $dimensions
Invoke-AzCostManagementQuery -Type Usage -Scope "subscriptions/***********" -DatasetGranularity 'Monthly' -DatasetFilter $filter -Timeframe MonthToDate -Debug


Column                   Row
------                   ---
{BillingMonth, Currency} {}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DATASETFILTER <IQueryFilter>: Has filter expression to use in the query.
  [And <IQueryFilter[]>]: The logical "AND" expression. Must have at least 2 items.
  [Dimensions <IQueryComparisonExpression>]: Has comparison expression for a dimension
    Name <String>: The name of the column to use in comparison.
    Value <String[]>: Array of values to use for comparison
  [Not <IQueryFilter>]: The logical "NOT" expression.
  [Or <IQueryFilter[]>]: The logical "OR" expression. Must have at least 2 items.
  [Tag <IQueryComparisonExpression>]: Has comparison expression for a tag

DATASETGROUPING <IQueryGrouping[]>: Array of group by expression to use in the query.
  Name <String>: The name of the column to group.
  Type <QueryColumnType>: Has type of the column to group.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.costmanagement/invoke-azcostmanagementquery
#>
function Invoke-AzCostManagementQuery {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult])]
[CmdletBinding(DefaultParameterSetName='UsageExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UsageExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # This includes 'subscriptions/{subscriptionId}/' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.
    ${Scope},

    [Parameter(ParameterSetName='UsageExpanded1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
    ${ExternalCloudProviderId},

    [Parameter(ParameterSetName='UsageExpanded1', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExternalCloudProviderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExternalCloudProviderType]
    # The external cloud provider type associated with dimension/query operations.
    ${ExternalCloudProviderType},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType]
    # The time frame for pulling data for the query.
    ${Timeframe},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType]
    # The type of the query.
    ${Type},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String[]]
    # Array of column names to be included in the query.
    ${ConfigurationColumn},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation]))]
    [System.Collections.Hashtable]
    # Dictionary of aggregation expression to use in the query.
    ${DatasetAggregation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter]
    # Has filter expression to use in the query.
    # To construct, see NOTES section for DATASETFILTER properties and create a hash table.
    ${DatasetFilter},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType]
    # The granularity of rows in the query.
    ${DatasetGranularity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[]]
    # Array of group by expression to use in the query.
    # To construct, see NOTES section for DATASETGROUPING properties and create a hash table.
    ${DatasetGrouping},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The start date to pull data from.
    ${TimePeriodFrom},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The end date to pull data to.
    ${TimePeriodTo},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Runtime')]
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
            UsageExpanded = 'Az.CostManagement.custom\Invoke-AzCostManagementQuery';
            UsageExpanded1 = 'Az.CostManagement.custom\Invoke-AzCostManagementQuery';
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
