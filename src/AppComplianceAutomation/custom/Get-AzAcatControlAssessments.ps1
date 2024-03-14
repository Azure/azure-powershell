
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
Get the AppComplianceAutomation report's control assessments.
.Description
Get the AppComplianceAutomation report's control assessments.

.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/get-azacatcontrolassessments
#>
function Get-AzAcatControlAssessments {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.ICategory[]])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Report Name.
        ${ReportName},

        [Parameter()]
        [System.String]
        # Compliance Status.
        ${ComplianceStatus},

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
        $Token = Get-Token
        $RuntimeParams = Get-Runtime-Parameters -PSBoundParameters $PSBoundParameters
        
        $Snapshot = Az.AppComplianceAutomation.internal\Get-AzAppComplianceAutomationSnapshot `
            -ReportName $ReportName `
            -SkipToken "0" -Top 1 -XmsAadUserToken $Token `
            @RuntimeParams
        
        if ($Snapshot.Count -le 0) {
            Write-Error "Your report is being generated. It might take up to 24 hours to generate your first report."
        }

        $Categories = $Snapshot[0].ComplianceResult[0].Category

        if ($PSBoundParameters.ContainsKey("ComplianceStatus")) {
            Get-FilteredControlAssessments -Categories $Categories -ComplianceStatus $ComplianceStatus
        }
        else {
            $Categories
        }
    }
}
