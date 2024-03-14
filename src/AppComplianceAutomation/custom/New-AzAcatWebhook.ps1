
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
Create a new AppComplianceAutomation webhook or update an exiting AppComplianceAutomation webhook.
.Description
Create a new AppComplianceAutomation webhook or update an exiting AppComplianceAutomation webhook.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatwebhook
#>
function New-AzAcatWebhook {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource])]
    [CmdletBinding(DefaultParameterSetName = 'CreateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [Alias('WebhookName')]
        [System.String]
        # Webhook Name.
        ${Name},

        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [System.String]
        # Report Name.
        ${ReportName},

        [Parameter(ParameterSetName = 'Create', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource]
        # A class represent an AppComplianceAutomation webhook resource.
        ${Parameter},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.EnableSslVerification])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.EnableSslVerification]
        # whether to enable ssl verification
        ${EnableSslVerification},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [System.Management.Automation.SwitchParameter]
        # whether to disable webhook
        ${Disable},

        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [System.String]
        # whether to send notification under any event.
        ${TriggerMode},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [AllowEmptyCollection()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.NotificationEvent])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.NotificationEvent[]]
        # under which event notification should be sent.
        ${Event},

        [Parameter(ParameterSetName = 'CreateExpanded', Mandatory)]
        [System.String]
        # webhook payload url
        ${PayloadUrl},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [System.String]
        # content type
        ${ContentType},

        [Parameter(ParameterSetName = 'CreateExpanded')]
        [System.Security.SecureString]
        # webhook secret token.
        # If not set, this field value is null; otherwise, please set a string value.
        ${Secret},

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
        if (-Not $PSBoundParameters.ContainsKey("ContentType")) {
            $PSBoundParameters.Add("ContentType", "application/json")
        }
        
        if (-Not $PSBoundParameters.ContainsKey("EnableSslVerification")) {
            $PSBoundParameters.Add("EnableSslVerification", "true")
        }

        if ($PSBoundParameters.Disable -eq $true) {
            $PSBoundParameters.Add("Status", "Disabled")
        }
        else {
            $PSBoundParameters.Add("Status", "Enabled")
        }
        $null = $PSBoundParameters.Remove("Disable")

        if ($PSBoundParameters.TriggerMode -eq "all") {
            $PSBoundParameters.Add("SendAllEvent", "true")
            $PSBoundParameters.Add("Event", @())
        }
        else {
            $PSBoundParameters.Add("SendAllEvent", "false")
        }
        $null = $PSBoundParameters.Remove("TriggerMode")

        if ($PSBoundParameters.ContainsKey("Secret")) {
            $PSBoundParameters.Add("UpdateWebhookKey", "true")

            $Decoded = ConvertFrom-SecureString -AsPlainText $Secret
            $PSBoundParameters.Add("WebhookKey", $Decoded)
            $null = $PSBoundParameters.Remove("Secret")
        }
        else {
            $PSBoundParameters.Add("UpdateWebhookKey", "false")
        }

        $PSBoundParameters = Add-Custom-Header -PSBoundParameters $PSBoundParameters
        $RuntimeParams = Get-Runtime-Parameters -PSBoundParameters $PSBoundParameters
        
        if ($PSBoundParameters.ContainsKey("Parameter")) {
            $Parameter |
            Az.AppComplianceAutomation.internal\New-AzAppComplianceAutomationWebhook -Name $Name -ReportName $ReportName `
                -XmsAadUserToken $PSBoundParameters.XmsAadUserToken `
                @RuntimeParams
        }
        else {
            Az.AppComplianceAutomation.internal\New-AzAppComplianceAutomationWebhook @PSBoundParameters
        }
    }
}
