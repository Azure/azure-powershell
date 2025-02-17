
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
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an in-memory object for AutomationRunbookReceiver.
.Description
Create an in-memory object for AutomationRunbookReceiver.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.AutomationRunbookReceiver
.Link
https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupautomationrunbookreceiverobject
#>
function New-AzActionGroupAutomationRunbookReceiverObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.AutomationRunbookReceiver')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The Azure automation account Id which holds this runbook and authenticate to Azure resource.")]
        [string]
        $AutomationAccountId,
        [Parameter(Mandatory, HelpMessage="Indicates whether this instance is global runbook.")]
        [bool]
        $IsGlobalRunbook,
        [Parameter(HelpMessage="Indicates name of the webhook.")]
        [string]
        $Name,
        [Parameter(Mandatory, HelpMessage="The name for this runbook.")]
        [string]
        $RunbookName,
        [Parameter(HelpMessage="The URI where webhooks should be sent.")]
        [string]
        $ServiceUri,
        [Parameter(HelpMessage="Indicates whether to use common alert schema.")]
        [bool]
        $UseCommonAlertSchema,
        [Parameter(Mandatory, HelpMessage="The resource id for webhook linked to this runbook.")]
        [string]
        $WebhookResourceId
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.AutomationRunbookReceiver]::New()

        if ($PSBoundParameters.ContainsKey('AutomationAccountId')) {
            $Object.AutomationAccountId = $AutomationAccountId
        }
        if ($PSBoundParameters.ContainsKey('IsGlobalRunbook')) {
            $Object.IsGlobalRunbook = $IsGlobalRunbook
        }
        if ($PSBoundParameters.ContainsKey('Name')) {
            $Object.Name = $Name
        }
        if ($PSBoundParameters.ContainsKey('RunbookName')) {
            $Object.RunbookName = $RunbookName
        }
        if ($PSBoundParameters.ContainsKey('ServiceUri')) {
            $Object.ServiceUri = $ServiceUri
        }
        if ($PSBoundParameters.ContainsKey('UseCommonAlertSchema')) {
            $Object.UseCommonAlertSchema = $UseCommonAlertSchema
        }
        if ($PSBoundParameters.ContainsKey('WebhookResourceId')) {
            $Object.WebhookResourceId = $WebhookResourceId
        }
        return $Object
    }
}

