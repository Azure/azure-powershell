
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
Get the AppComplianceAutomation report and its properties.
.Description
Get the AppComplianceAutomation report and its properties.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/get-azacatreport
#>
function Get-AzAcatReport {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IReportResource])]
    [CmdletBinding(DefaultParameterSetName = 'List', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Get', Mandatory)]
        [Alias('ReportName')]
        [System.String]
        # Report Name.
        ${Name},

        [Parameter(ParameterSetName = 'List')]
        [System.String]
        # OData Select statement.
        # Limits the properties on each entry to just those requested, e.g.
        # ?$select=reportName,id.
        ${Select},

        [Parameter(ParameterSetName = 'List')]
        [System.String]
        # Skip over when retrieving results.
        ${SkipToken},

        [Parameter(ParameterSetName = 'List')]
        [System.Int32]
        # Number of elements to return when retrieving results.
        ${Top},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

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
        Az.AppComplianceAutomation.internal\Get-AzAppComplianceAutomationReport @PSBoundParameters
    }
}
