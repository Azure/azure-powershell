
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

<#
.Synopsis
Creates a new criteria object
.Description
Creates a new criteria object
.Example
PS C:\> New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfDay

ObjectType                  AbsoluteCriterion DaysOfTheWeek MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- ------------- ------------ ------------ ---------------
ScheduleBasedBackupCriteria {FirstOfDay}
.Example
PS C:\> New-AzDataProtectionPolicyTagCriteriaClientObject -DaysOfWeek @("Sunday", "Monday")

ObjectType                  AbsoluteCriterion DaysOfTheWeek    MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- -------------    ------------ ------------ ---------------
ScheduleBasedBackupCriteria                   {Sunday, Monday}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedBackupCriteria
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionpolicytagcriteriaclientobject
#>
function New-AzDataProtectionPolicyTagCriteriaClientObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IScheduleBasedBackupCriteria])]
[CmdletBinding(DefaultParameterSetName='ScheduleCriteria', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='AbsoluteCriteria', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteTagCriteria]
    # Absolute criteria
    ${AbsoluteCriteria},

    [Parameter(ParameterSetName='ScheduleCriteria')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DaysOfWeek[]]
    # Days of the week
    ${DaysOfWeek},

    [Parameter(ParameterSetName='ScheduleCriteria')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeeksOfMonth[]]
    # Weeks of the month.
    ${WeeksOfMonth},

    [Parameter(ParameterSetName='ScheduleCriteria')]
    [Parameter(ParameterSetName='MonthlyCriteria')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.MonthsOfYear[]]
    # Months of the year.
    ${MonthsOfYear},

    [Parameter(ParameterSetName='ScheduleCriteria')]
    [Parameter(ParameterSetName='MonthlyCriteria')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.DateTime[]]
    # Schedule times.
    ${ScheduleTimes},

    [Parameter(ParameterSetName='MonthlyCriteria', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Days of the month.
    # Allowed values are 1 to 28 and Last
    ${DaysOfMonth}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            AbsoluteCriteria = 'Az.DataProtection.custom\New-AzDataProtectionPolicyTagCriteriaClientObject';
            ScheduleCriteria = 'Az.DataProtection.custom\New-AzDataProtectionPolicyTagCriteriaClientObject';
            MonthlyCriteria = 'Az.DataProtection.custom\New-AzDataProtectionPolicyTagCriteriaClientObject';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
