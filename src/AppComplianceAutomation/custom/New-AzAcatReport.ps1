
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
Create a new AppComplianceAutomation report or update an exiting AppComplianceAutomation report.
.Description
Create a new AppComplianceAutomation report or update an exiting AppComplianceAutomation report.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatreport
#>
function New-AzAcatReport {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource])]
    [CmdletBinding(DefaultParameterSetName = 'CreateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [Alias('ReportName')]
        [System.String]
        # Report Name.
        ${Name},

        [Parameter(ParameterSetName = 'Create', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource]
        # A class represent an AppComplianceAutomation report resource.
        ${Parameter},

        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IResourceMetadata[]]
        # List of resource data.
        ${Resource},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [System.String]
        # Report collection trigger time's time zone, the available list can be obtained by executing "Get-TimeZone -ListAvailable" in PowerShell.An example of valid timezone id is "Pacific Standard Time".
        ${TimeZone},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [System.DateTime]
        # Report collection trigger time.
        ${TriggerTime},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [System.String]
        # Report offer Guid.
        ${OfferGuid},

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

        # Set default parameters
        if (-Not $PSBoundParameters.ContainsKey("TimeZone")) {
            $TimeZone = (Get-TimeZone).StandardName
            $PSBoundParameters.Add("TimeZone", $TimeZone)
        }
        if (-Not $PSBoundParameters.ContainsKey("TriggerTime")) {
            $TriggerTime = Get-Nearest-Time
            $PSBoundParameters.Add("TriggerTime", $TriggerTime)
        }
        $PSBoundParameters = Add-Custom-Header -PSBoundParameters $PSBoundParameters
        $RuntimeParams = Get-Runtime-Parameters -PSBoundParameters $PSBoundParameters

        # Onboard
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
        
        # Create report
        if ($PSBoundParameters.ContainsKey("Parameter")) {
            $Parameter |
            Az.AppComplianceAutomation.internal\New-AzAppComplianceAutomationReport -Name $Name `
                -XmsAadUserToken $PSBoundParameters.XmsAadUserToken `
                @RuntimeParams
        }
        else {
            Az.AppComplianceAutomation.internal\New-AzAppComplianceAutomationReport @PSBoundParameters
        }
    }
}
