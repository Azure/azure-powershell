# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
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

function Update-AzLabServicesSchedule_Lab {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    ${Lab},

    [Parameter(Mandatory)]
    [System.String]
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.String]
    ${Note},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.DateTime]
    ${RecurrencePatternExpirationDate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.RecurrenceFrequency]
    ${RecurrencePatternFrequency},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.Int32]
    ${RecurrencePatternInterval},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.WeekDay[]]
    ${RecurrencePatternWeekDay},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.DateTime]
    ${StartAt},
    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.DateTime]
    ${StopAt},
    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [System.String]
    ${TimeZoneId},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {
    $PSBoundParameters = $Lab.BindResourceParameters($PSBoundParameters)
    
    $PSBoundParameters.Remove("Lab") > $null
    return Az.LabServices\Update-AzLabServicesSchedule @PSBoundParameters
}

}
