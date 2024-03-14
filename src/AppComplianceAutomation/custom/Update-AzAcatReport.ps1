
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
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
Update an exiting AppComplianceAutomation report.
.Description
Update an exiting AppComplianceAutomation report.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/update-azacatreport
#>
function Update-AzAcatReport {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'Update', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory)]
        [Alias('ReportName')]
        [System.String]
        # Report Name.
        ${Name},

        [Parameter(ParameterSetName = 'Update', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource]
        # A class represent a AppComplianceAutomation report resource update properties.
        # To construct, see NOTES section for PARAMETER properties and create a hash table.
        ${Parameter},

        [Parameter(ParameterSetName = 'UpdateExpanded')]
        [System.String]
        # Report offer Guid.
        ${OfferGuid},

        [Parameter(ParameterSetName = 'UpdateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IResourceMetadata[]]
        # List of resource data.
        # To construct, see NOTES section for RESOURCE properties and create a hash table.
        ${Resource},

        [Parameter(ParameterSetName = 'UpdateExpanded')]
        [System.String]
        # Report collection trigger time's time zone, the available list can be obtained by executing "Get-TimeZone -ListAvailable" in PowerShell.An example of valid timezone id is "Pacific Standard Time".
        ${TimeZone},

        [Parameter(ParameterSetName = 'UpdateExpanded')]
        [System.DateTime]
        # Report collection trigger time.
        ${TriggerTime},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $PSBoundParameters = Add-Custom-Header -PSBoundParameters $PSBoundParameters
        $RuntimeParams = Get-Runtime-Parameters -PSBoundParameters $PSBoundParameters

        # Onboard if update resource ids
        if (($PSBoundParameters.ContainsKey("Resource")) -or ($PSBoundParameters.ContainsKey("Parameter") -and ($Parameter.Resource -ne $null))) {
            if ($PSBoundParameters.ContainsKey("Parameter")) {
                $ResourceIds = Get-ResourceId-Array -Resources $Parameter.Resource
            }
            else {
                $ResourceIds = Get-ResourceId-Array -Resources $Resource
            }
            $Subscriptions = Get-Resource-Subscriptions -Resources $ResourceIds
            Az.AppComplianceAutomation.internal\Invoke-AzAppComplianceAutomationOnboard -SubscriptionId $Subscriptions `
                -XmsAadUserToken $PSBoundParameters.XmsAadUserToken `
                @RuntimeParams
        }

        # Update report
        if ($PSBoundParameters.ContainsKey("Parameter")) {
            $Parameter |
            Az.AppComplianceAutomation.internal\Update-AzAppComplianceAutomationReport -Name $Name `
                -XmsAadUserToken $PSBoundParameters.XmsAadUserToken `
                @RuntimeParams
        }
        else {
            Az.AppComplianceAutomation.internal\Update-AzAppComplianceAutomationReport @PSBoundParameters
        }
    }
}
