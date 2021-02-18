
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
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.ICostManagementIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICostManagementIdentity>: Identity Parameter
  [AlertId <String>]: Alert ID
  [ExportName <String>]: Export Name.
  [ExternalCloudProviderId <String>]: This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.
  [ExternalCloudProviderType <ExternalCloudProviderType?>]: The external cloud provider type associated with dimension/query operations. This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.
  [Id <String>]: Resource identity path
  [Scope <String>]: The scope associated with view operations. This includes 'subscriptions/{subscriptionId}' for subscription scope, 'subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for BillingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for InvoiceSection scope, 'providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, 'providers/Microsoft.CostManagement/externalBillingAccounts/{externalBillingAccountName}' for External Billing Account scope and 'providers/Microsoft.CostManagement/externalSubscriptions/{externalSubscriptionName}' for External Subscription scope.
  [ViewName <String>]: View name
.Link
https://docs.microsoft.com/en-us/powershell/module/az.costmanagement/update-azcostmanagementexport
#>
function Update-AzCostManagementExport {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('ExportName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # Export Name.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [System.String]
    # This parameter defines the scope of costmanagement from different perspectives 'Subscription','ResourceGroup' and 'Provide Service'.
    ${Scope},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.ICostManagementIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String[]]
    # Array of column names to be included in the export.
    # If not provided then the export will include all available columns.
    # The available columns can vary by customer channel (see examples).
    ${ConfigurationColumn},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType]
    # The granularity of rows in the export.
    # Currently only 'Daily' is supported.
    ${DataSetGranularity},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType]
    # The time frame for pulling data for the export.
    # If custom, then a specific time period must be provided.
    ${DefinitionTimeframe},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType]
    # The type of the export.
    # Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide data for charges or amortization for service reservations.
    ${DefinitionType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The name of the container where exports will be uploaded.
    ${DestinationContainer},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The resource id of the storage account where exports will be delivered.
    ${DestinationResourceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # The name of the directory where exports will be uploaded.
    ${DestinationRootFolderPath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.String]
    # eTag of the resource.
    # To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.
    ${ETag},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType]
    # The format of the export being delivered.
    # Currently only 'Csv' is supported.
    ${Format},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The start date of recurrence.
    ${RecurrencePeriodFrom},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The end date of recurrence.
    ${RecurrencePeriodTo},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType]
    # The schedule recurrence.
    ${ScheduleRecurrence},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType])]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType]
    # The status of the export's schedule.
    # If 'Inactive', the export's schedule is paused.
    ${ScheduleStatus},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The start date for export data.
    ${TimePeriodFrom},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Category('Body')]
    [System.DateTime]
    # The end date for export data.
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
        try {
            $CommonPSBoundParameters = @{}
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
                $CommonPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
            }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
                $CommonPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
            }
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $CommonPSBoundParameters['SubscriptionId'] = $SubscriptionId
            }
            if($PSBoundParameters['InputObject'] -ne $null)
            {
                $InputExportObject = $PSBoundParameters['InputObject']
                $getExport = Get-AzCostManagementExport -InputObject $InputExportObject @CommonPSBoundParameters
            }else{
                $InputExportScope = $PSBoundParameters['Scope']
                $InputExportName = $PSBoundParameters['Name']
                $getExport = Get-AzCostManagementExport -Scope $InputExportScope -Name $InputExportName @CommonPSBoundParameters
            }
            
            $null = $PSBoundParameters.Add("ETag",$getExport.Etag)
            if($PSBoundParameters['DataSetGranularity'] -eq $null)
            {
                $null = $PSBoundParameters.Add("DataSetGranularity",$getExport.DataSetGranularity)
            }
            if($PSBoundParameters['DefinitionTimeframe'] -eq $null)
            {
                $null = $PSBoundParameters.Add("DefinitionTimeframe",$getExport.DefinitionTimeframe)
            }
            if($PSBoundParameters['DefinitionType'] -eq $null)
            {
                $null = $PSBoundParameters.Add("DefinitionType",$getExport.DefinitionType)
            }
            if($PSBoundParameters['DestinationContainer'] -eq $null)
            {
                $null = $PSBoundParameters.Add("DestinationContainer",$getExport.DestinationContainer)
            }
            if($PSBoundParameters['DestinationResourceId'] -eq $null)
            {
                $null = $PSBoundParameters.Add("DestinationResourceId",$getExport.DestinationResourceId)
            }
            if($PSBoundParameters['DestinationRootFolderPath'] -eq $null)
            {
                $null = $PSBoundParameters.Add("DestinationRootFolderPath",$getExport.DestinationRootFolderPath)
            }
            if($PSBoundParameters['Format'] -eq $null)
            {
                $null = $PSBoundParameters.Add("Format",$getExport.Format)
            }
            if($PSBoundParameters['RecurrencePeriodFrom'] -eq $null)
            {
                $null = $PSBoundParameters.Add("RecurrencePeriodFrom",$getExport.RecurrencePeriodFrom)
            }
            if($PSBoundParameters['RecurrencePeriodTo'] -eq $null)
            {
                $null = $PSBoundParameters.Add("RecurrencePeriodTo",$getExport.RecurrencePeriodTo)
            }
            if($PSBoundParameters['ScheduleStatus'] -eq $null)
            {
                $null = $PSBoundParameters.Add("ScheduleStatus",$getExport.ScheduleStatus)
            }
            if($PSBoundParameters['ScheduleRecurrence'] -eq $null)
            {
                $null = $PSBoundParameters.Add("ScheduleRecurrence",$getExport.ScheduleRecurrence)
            }
            Az.CostManagement.internal\Update-AzCostManagementExport @PSBoundParameters
        } catch {
            throw
        }
    }
}