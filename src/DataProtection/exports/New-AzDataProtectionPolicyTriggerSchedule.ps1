
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
Creates new Schedule object
.Description
Creates new Schedule object
.Example
PS C:\> $date = get-date
PS C:\> New-AzDataProtectionPolicyTriggerSchedule -ScheduleDays $date -IntervalType Daily -IntervalCount 1

R/2021-03-03T12:49:55+05:30/P1D
.Example
PS C:\> $date = get-date
PS C:\> New-AzDataProtectionPolicyTriggerSchedule -ScheduleDays $date -IntervalType Hourly -IntervalCount 4

R/2021-03-03T12:49:55+05:30/PT4H

.Outputs
System.String[]
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/new-azdataprotectionpolicytriggerschedule
#>
function New-AzDataProtectionPolicyTriggerSchedule {
[OutputType([System.String[]])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.DateTime[]]
    # Source Datastore
    ${ScheduleDays},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency]
    # Source Datastore
    ${IntervalType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.Int32]
    # interval count
    ${IntervalCount}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.DataProtection.custom\New-AzDataProtectionPolicyTriggerSchedule';
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
