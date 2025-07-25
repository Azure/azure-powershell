
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
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.
.Description
The operation to create or update a export.
Update operation requires latest eTag to be set in the request.
You may obtain the latest eTag by performing a get operation.
Create operation does not require eTag.
#>
function New-AzCostManagementExport {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IExport])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ExportName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # Export Name.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # This parameter defines the scope of costmanagement from different perspectives 'Subscription','ResourceGroup' and 'Provide Service'.
    ${Scope},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String[]]
    # Array of column names to be included in the export.
    # If not provided then the export will include all available columns.
    # The available columns can vary by customer channel (see examples).
    ${ConfigurationColumn},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PSArgumentCompleterAttribute("Daily")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The granularity of rows in the export.
    # Currently only 'Daily' is supported.
    ${DataSetGranularity},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PSArgumentCompleterAttribute("MonthToDate", "BillingMonthToDate", "TheLastMonth", "TheLastBillingMonth", "WeekToDate", "Custom")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The time frame for pulling data for the export.
    # If custom, then a specific time period must be provided.
    ${DefinitionTimeframe},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PSArgumentCompleterAttribute("Usage", "ActualCost", "AmortizedCost")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The type of the export.
    # Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide data for charges or amortization for service reservations.
    ${DefinitionType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The name of the container where exports will be uploaded.
    # If the container does not exist it will be created.
    ${DestinationContainer},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The resource id of the storage account where exports will be delivered.
    # This is not required if a sasToken and storageAccount are specified.
    ${DestinationResourceId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The name of the directory where exports will be uploaded.
    ${DestinationRootFolderPath},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # A SAS token for the storage account.
    # For a restricted set of Azure customers this together with storageAccount can be specified instead of resourceId.
    # Note: the value returned by the API for this property will always be obfuscated.
    # Returning this same obfuscated value will not result in the SAS token being updated.
    # To update this value a new SAS token must be specified.
    ${DestinationSasToken},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The storage account where exports will be uploaded.
    # For a restricted set of Azure customers this together with sasToken can be specified instead of resourceId.
    ${DestinationStorageAccount},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # eTag of the resource.
    # To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.
    ${ETag},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PSArgumentCompleterAttribute("Csv")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The format of the export being delivered.
    # Currently only 'Csv' is supported.
    ${Format},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If set to true, exported data will be partitioned by size and placed in a blob directory together with a manifest file.
    # Note: this option is currently available only for modern commerce scopes.
    ${PartitionData},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The start date of recurrence.
    ${RecurrencePeriodFrom},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The end date of recurrence.
    ${RecurrencePeriodTo},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PSArgumentCompleterAttribute("Daily", "Weekly", "Monthly", "Annually")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The schedule recurrence.
    ${ScheduleRecurrence},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PSArgumentCompleterAttribute("Active", "Inactive")]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The status of the export's schedule.
    # If 'Inactive', the export's schedule is paused.
    ${ScheduleStatus},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The start date for export data.
    ${TimePeriodFrom},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The end date for export data.
    ${TimePeriodTo},

    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # Path of Json file supplied to the Create operation
    ${JsonFilePath},

    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # Json string supplied to the Create operation
    ${JsonString},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
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
        Az.CostManagement.internal\New-AzCostManagementExport @PSBoundParameters
    }
}
