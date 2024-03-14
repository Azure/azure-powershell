
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
Download compliance needs, like: Compliance Report, Resource List.
.Description
Download compliance needs, like: Compliance Report, Resource List.

.Outputs
System.Boolean
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/invoke-azacatdownloadreport
#>
function Invoke-AzAcatDownloadReport {
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Report Name.
        ${ReportName},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.DownloadType])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.DownloadType]
        # Indicates the download type.
        ${DownloadType},

        [Parameter(Mandatory)]
        [System.String]
        # File download destination path.
        ${Path},

        [Parameter(Mandatory)]
        [System.String]
        # Downloaded file name.
        ${Name},

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
        $Token = Get-Token
        $RuntimeParams = Get-Runtime-Parameters -PSBoundParameters $PSBoundParameters

        $Snapshot = Az.AppComplianceAutomation.internal\Get-AzAppComplianceAutomationSnapshot `
            -ReportName $ReportName `
            -Select "snapshotName" -SkipToken "0" -Top 1 -XmsAadUserToken $Token `
            @RuntimeParams
        
        if ($Snapshot.Count -le 0) {
            Write-Error "Your report is being generated. It might take up to 24 hours to generate your first report."
        }
        $SnapshotName = $Snapshot[0].SnapshotName

        $Content = Az.AppComplianceAutomation.internal\Invoke-AzAppComplianceAutomationDownloadSnapshot `
            -ReportName $ReportName -SnapshotName $SnapshotName `
            -DownloadType $DownloadType -XmsAadUserToken $Token `
            @RuntimeParams

        $SavePath = Join-Path $Path -ChildPath $Name

        if ($DownloadType -eq "ResourceList") {
            $SavePath += ".csv"
            $Content.ResourceList | Export-Csv -Path $SavePath -NoTypeInformation
        }

        if ($DownloadType -eq "ComplianceReport") {
            $SavePath += ".csv"
            $Content.ComplianceReport | Export-Csv -Path $SavePath -NoTypeInformation
        }

        if ($DownloadType -eq "CompliancePdfReport") {
            $SavePath += ".pdf"
            $Url = $Content.CompliancePdfReportSasUri
            Invoke-WebRequest $Url -OutFile $SavePath
        }

        if ($DownloadType -eq "ComplianceDetailedPdfReport") {
            $SavePath += ".pdf"
            $Url = $Content.CompliancePdfReportSasUri
            Invoke-WebRequest $Url -OutFile $SavePath
        }

        Get-ChildItem -Path $SavePath
    }
}
