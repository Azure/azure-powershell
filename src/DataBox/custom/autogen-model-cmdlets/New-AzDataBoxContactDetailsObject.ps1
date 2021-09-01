
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
    Create a in-memory object for ContactDetails
    .Description
    Create a in-memory object for ContactDetails

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ContactDetails
    .Link
    https://docs.microsoft.com/powershell/module/az.DataBox/new-AzDataBoxContactDetailsObject
    #>
    function New-AzDataBoxContactDetailsObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ContactDetails')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(Mandatory, HelpMessage="Contact name of the person.")]
            [string]
            $ContactName,
            [Parameter(Mandatory, HelpMessage="List of Email-ids to be notified about job progress.")]
            [string[]]
            $EmailList,
            [Parameter(HelpMessage="Mobile number of the contact person.")]
            [string]
            $Mobile,
            [Parameter(HelpMessage="Notification preference for a job stage.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.INotificationPreference[]]
            $NotificationPreference,
            [Parameter(Mandatory, HelpMessage="Phone number of the contact person.")]
            [string]
            $Phone,
            [Parameter(HelpMessage="Phone extension number of the contact person.")]
            [string]
            $PhoneExtension
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ContactDetails]::New()
    
            $Object.ContactName = $ContactName
            $Object.EmailList = $EmailList
            $Object.Mobile = $Mobile
            $Object.NotificationPreference = $NotificationPreference
            $Object.Phone = $Phone
            $Object.PhoneExtension = $PhoneExtension
            return $Object
        }
    }
    
