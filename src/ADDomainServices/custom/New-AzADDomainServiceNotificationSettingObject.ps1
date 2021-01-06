
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for NotificationSettings
.Description
Create a in-memory object for NotificationSettings

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServiceNotificationSettingsObject
#>
function New-AzADDomainServiceNotificationSettingObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The list of additional recipients.")]
        [string[]]
        $AdditionalRecipient,
        [Parameter(HelpMessage="Should domain controller admins be notified.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $NotifyDcAdmin,
        [Parameter(HelpMessage="Should global admins be notified.")]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        $NotifyGlobalAdmin
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings]::New()

        $Object.AdditionalRecipient = $AdditionalRecipient
        $Object.NotifyDcAdmin = $NotifyDcAdmin
        $Object.NotifyGlobalAdmin = $NotifyGlobalAdmin
        return $Object
    }
}

