
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
Gets default policy template for a selected datasource type.
.Description
Gets default policy template for a selected datasource type.
.Example
PS C:\> Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionpolicytemplate
#>
function Get-AzDataProtectionPolicyTemplate {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
    # Datasource Type
    ${DatasourceType}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.DataProtection.custom\Get-AzDataProtectionPolicyTemplate';
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
