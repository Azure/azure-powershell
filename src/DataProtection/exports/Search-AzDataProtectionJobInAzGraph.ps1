
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
Searches for Backup Jobs in Azure Resource Graph and retrieves the expected entries
.Description
Searches for Backup Jobs in Azure Resource Graph and retrieves the expected entries
.Example
PS C:\> $endtime = get-date
PS C:\> $starttime = $endtime.AddHours(-5)
PS C:\> Search-AzDataProtectionJobInAzGraph -Subscription "xxx-xxx-xxx" -ResourceGroup sarath-rg -Vault sarath-vault -DatasourceType AzureDisk -StartTime $starttime -EndTime $endtime

Name                                 Type
----                                 ----
1c1d56c2-b21a-4038-ba46-3c1a0089e66a microsoft.dataprotection/backupvaults/backupjobs
79f2804d-a39d-487e-91b5-f2eceffcbb7a microsoft.dataprotection/backupvaults/backupjobs
96238abd-6ff3-48e0-8c07-0eabd6928a17 microsoft.dataprotection/backupvaults/backupjobs
.Example
PS C:\> Search-AzDataProtectionJobInAzGraph -Subscription "xxxx-xxx-xxx" -ResourceGroup sarath-rg -Vault sarath-vault -DatasourceType AzureDisk -Operation OnDemandBackup

Name                                 Type
----                                 ----
11bc277d-9448-446a-9e79-4721858524d6 microsoft.dataprotection/backupvaults/backupjobs
16d7b56a-e169-41d1-aa10-cafcc19c8e12 microsoft.dataprotection/backupvaults/backupjobs
1b0b17e3-398f-4265-9d03-ffc1e21fa73a microsoft.dataprotection/backupvaults/backupjobs

.Outputs
System.Management.Automation.PSObject
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/search-azdataprotectionjobinazgraph
#>
function Search-AzDataProtectionJobInAzGraph {
[OutputType([PSObject])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Subscription of Vault
    ${Subscription},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
    # Datasource Type
    ${DatasourceType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Resource Group of Vault
    ${ResourceGroup},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String[]]
    # Name of the vault
    ${Vault},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.DateTime]
    # Start Time filter for the backup Job
    ${StartTime},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.DateTime]
    # End Time filter for the Backup Job
    ${EndTime},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.JobOperation[]]
    # Operation filter for the backup job
    ${Operation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.JobStatus[]]
    # Status filter for the backup job
    ${Status}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.DataProtection.custom\Search-AzDataProtectionJobInAzGraph';
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
