
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
#>
function Invoke-AzCostManagementQuery {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryResult])]
[CmdletBinding(DefaultParameterSetName='UsageExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UsageExpanded', Mandatory, HelpMessage="This includes 'subscriptions/{subscriptionId}/' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # The scope associated with query and export operations.
    # This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId} for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.
    ${Scope},

    [Parameter(ParameterSetName='UsageExpanded1', Mandatory, HelpMessage="This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
    ${ExternalCloudProviderId},

    [Parameter(ParameterSetName='UsageExpanded1', Mandatory, HelpMessage="The external cloud provider type associated with dimension/query operations.")]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExternalCloudProviderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExternalCloudProviderType]
    # The external cloud provider type associated with dimension/query operations.
    # This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
    ${ExternalCloudProviderType},

    [Parameter(ParameterSetName='UsageExpanded', Mandatory, HelpMessage="The time frame for pulling data for the query.")]
    [Parameter(ParameterSetName='UsageExpanded1', Mandatory, HelpMessage="The time frame for pulling data for the query.")]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType]
    # The time frame for pulling data for the query.
    # If custom, then a specific time period must be provided.
    ${Timeframe},

    [Parameter(ParameterSetName='UsageExpanded', Mandatory, HelpMessage="The type of the query.")]
    [Parameter(ParameterSetName='UsageExpanded1', Mandatory, HelpMessage="The type of the query.")]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType]
    # The type of the query.
    ${Type},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage="Array of column names to be included in the query.")]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="Array of column names to be included in the query.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String[]]
    # Array of column names to be included in the query.
    # Any valid query column name is allowed.
    # If not provided, then query includes all columns.
    ${ConfigurationColumn},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage="Dictionary of aggregation expression to use in the query.")]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="Dictionary of aggregation expression to use in the query.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryDatasetAggregation]))]
    [System.Collections.Hashtable]
    # Dictionary of aggregation expression to use in the query.
    # The key of each item in the dictionary is the alias for the aggregated column.
    # Query can have up to 2 aggregation clauses.
    ${DatasetAggregation},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage="Has filter expression to use in the query.")]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="Has filter expression to use in the query.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryFilter]
    # Has filter expression to use in the query.
    # To construct, see NOTES section for DATASETFILTER properties and create a hash table.
    ${DatasetFilter},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage="The granularity of rows in the query.")]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="The granularity of rows in the query.")]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType]
    # The granularity of rows in the query.
    ${DatasetGranularity},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage='Array of group by expression to use in the query.')]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="Array of group by expression to use in the query.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryGrouping[]]
    # Array of group by expression to use in the query.
    # Query can have up to 2 group by clauses.
    # To construct, see NOTES section for DATASETGROUPING properties and create a hash table.
    ${DatasetGrouping},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage="The start date to pull data from.")]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="The start date to pull data from.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The start date to pull data from.
    ${TimePeriodFrom},

    [Parameter(ParameterSetName='UsageExpanded', HelpMessage="The end date to pull data to.")]
    [Parameter(ParameterSetName='UsageExpanded1', HelpMessage="The end date to pull data to.")]
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

  process {
    $ApiVersion = '2019-11-01'
    $URL = ''
    if ($PSBoundParameters.ContainsKey('ExternalCloudProviderType')) {
      $URL = [System.Text.RegularExpressions.Regex]::Replace(
                      "providers/Microsoft.CostManagement/$ExternalCloudProviderType/$ExternalCloudProviderId/query?api-version=$ApiVersion" ,"\\?&*$|&*$|(\\?)&+|(&)&+","$1$2")
    } else {
      $URL = [System.Text.RegularExpressions.Regex]::Replace(
                      "$Scope/providers/Microsoft.CostManagement/query?api-version=$ApiVersion", "\\?&*$|&*$|(\\?)&+|(&)&+","$1$2")
    }

    $Request = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryDefinition]::New()
    if ($PSBoundParameters.ContainsKey('ConfigurationColumn')) {
      $Request.ConfigurationColumn = $ConfigurationColumn
    }
    if ($PSBoundParameters.ContainsKey('DatasetAggregation')) {
      $Request.DatasetAggregation = $DatasetAggregation
    }
    if ($PSBoundParameters.ContainsKey('DatasetFilter')) {
      $Request.DatasetFilter = $DatasetFilter
    }
    if ($PSBoundParameters.ContainsKey('DatasetGranularity')) {
      $Request.DatasetGranularity = $DatasetGranularity
    }
    if ($PSBoundParameters.ContainsKey('DatasetGrouping')) {
      $Request.DatasetGrouping = $DatasetGrouping
    }
    if ($PSBoundParameters.ContainsKey('TimePeriodFrom')) {
      $Request.TimePeriodFrom = $TimePeriodFrom
    }
    if ($PSBoundParameters.ContainsKey('TimePeriodTo')) {
      $Request.TimePeriodTo = $TimePeriodTo
    }
    if ($PSBoundParameters.ContainsKey('Timeframe')) {
      $Request.Timeframe = $Timeframe
    }
    if ($PSBoundParameters.ContainsKey('Type')) {
      $Request.Type = $Type
    }
    $Result = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryResult]::New()
    $SkipToken = $null
    $RowList = New-Object System.Collections.Generic.List[System.Collections.Generic.List[string]]
    while ($true) {
      $Response = Invoke-AzCostManagementUsageQueryInternal -URL $URL -SkipToken $SkipToken -Payload $Request.ToJsonString() -Scope $Scope
      $Result.Column = $Response.Column
      foreach ($Row in $Response.Row) {
        $RowList.Add($Row)
      }
      if ($null -ne $Response.NextLink -and '' -ne $Response.nextlink)
      {
        $SkipToken = $Response.nextLink
      } else {
        break
      }
    }
    $Result.Row = $RowList
    return $Result
  }
}

function Invoke-AzCostManagementUsageQueryInternal {
  [OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryResult])]
  param(
    [System.String]
    ${URL},
    [System.String]
    ${SkipToken},
    [System.String]
    ${Payload},
    [System.String]
    ${Scope}
  )
  process {
    if ($null -ne $SkipToken -and $SkipToken -ne '') {
      $URL = "$URL&$SkipToken"
    }
    $ResponseContent = (Invoke-AzRest -Path $URL -Payload $Payload -Method POST).Content | ConvertFrom-Json

    $Result = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryResult]::New()
    if ($null -ne $ResponseContent.Properties.NextLink)
    {
      $Result.NextLink = $ResponseContent.Properties.NextLink.split('&')[1]
    }

    $ColumnList = New-Object System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IQueryColumn]
    foreach ($Column in $ResponseContent.Properties.Columns) {
      Write-Host $Column.ToString()
      $QueryColumn = [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.QueryColumn]::New()
      $QueryColumn.Name = $Column.Name
      $QueryColumn.Type = $Column.Type
      $ColumnList.Add($QueryColumn)
    }
    $Result.Column = $ColumnList

    $RowList = New-Object System.Collections.Generic.List[System.Collections.Generic.List[string]]
    foreach ($Row in $ResponseContent.Properties.Rows) {
      $QueryRow = New-Object System.Collections.Generic.List[string]
      foreach ($Item in $Row) {
        $QueryRow.Add($Item.ToString())
      }
      $RowList.Add($QueryRow)
    }
    $Result.Row = $RowList

    return $Result
  }
}
