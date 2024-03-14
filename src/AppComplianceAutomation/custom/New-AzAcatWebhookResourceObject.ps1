
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
Create an in-memory object for WebhookResource.
.Description
Create an in-memory object for WebhookResource.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource
.Link
https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatwebhookresourceobject
#>
function New-AzAcatWebhookResourceObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.EnableSslVerification])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.EnableSslVerification]
        # whether to enable ssl verification
        ${EnableSslVerification},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # whether to disable webhook
        ${Disable},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.SendAllEvents])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.SendAllEvents]
        # whether to send notification under any event.
        ${TriggerMode},

        [Parameter()]
        [AllowEmptyCollection()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.NotificationEvent])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.NotificationEvent[]]
        # under which event notification should be sent.
        ${Event},

        [Parameter()]
        [System.String]
        # webhook payload url
        ${PayloadUrl},

        [Parameter()]
        [System.String]
        # content type
        ${ContentType},

        [Parameter()]
        [System.Security.SecureString]
        # webhook secret token.
        # If not set, this field value is null; otherwise, please set a string value.
        ${Secret}
    )

    process {
        $Object = @{}

        if ($PSBoundParameters.ContainsKey("PayloadUrl")) {
            $Object.Add("PayloadUrl", $PayloadUrl)
        }

        if (-Not $PSBoundParameters.ContainsKey("ContentType")) {
            $Object.Add("ContentType", "application/json")
        }
        else {
            $Object.Add("ContentType", $ContentType)
        }

        if ($PSBoundParameters.ContainsKey("EnableSslVerification")) {
            $Object.EnableSslVerification = $EnableSslVerification
        }
        else {
            $Object.EnableSslVerification = "true"
        }

        if ($PSBoundParameters.Disable -eq $true) {
            $Object.Status = "Disabled"
        }
        else {
            $Object.Status = "Enabled"
        }

        if ($PSBoundParameters.TriggerMode -eq "all") {
            $Object.SendAllEvent = "true"
            $Object.Event = @()
        }
        else {
            $Object.SendAllEvent = "false"
        }

        if ($PSBoundParameters.ContainsKey("Secret")) {
            $Object.UpdateWebhookKey = "true"
            $Decoded = ConvertFrom-SecureString -AsPlainText $Secret
            $Object.WebhookKey = $Decoded
        }
        else {
            $Object.UpdateWebhookKey = "false"
        }
        return [Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.WebhookResource]::DeserializeFromDictionary($Object)
    }
}
