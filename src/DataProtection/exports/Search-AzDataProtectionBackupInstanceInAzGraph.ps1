
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
Searches for Backup instances in Azure Resource Graph and retrieves the expected entries
.Description
Searches for Backup instances in Azure Resource Graph and retrieves the expected entries
.Example
PS C:\> Search-AzDataProtectionBackupInstanceInAzGraph -Subscription "xxxx-xxx-xxx" -DatasourceType AzureDisk

Name                                                                                                                   Type
----                                                                                                                   ----
ContosoDemoVM_DataDisk_0-ContosoDemoVM_DataDisk_0-5f7b2a1f-f1ab-4abe-aadf-e7dc48238157                                 microsoft.dataprotection/backupvaults/backupinstance
ContosoDemoVM_OsDisk_1_84b542ec38a447cea-ContosoDemoVM_OsDisk_1_84b542ec38a447cea-9bdcbd90-3555-4651-93b8-8265e1b5c07a microsoft.dataprotection/backupvaults/backupinstance
DataDisk1-DataDisk1-0c71e6bf-9289-483c-8e27-aa6c0df60078                                                               microsoft.dataprotection/backupvaults/backupinstance
rraj-StandardHDD-rraj-StandardHDD-85d0a3f4-7fa8-46c7-bf83-0dee27eac08e                                                 microsoft.dataprotection/backupvaults/backupinstance
sakaarhotfixtest_disk1_86d713f7b80e493b9-sakaarhotfixtest_disk1_86d713f7b80e493b9-be214c89-c07d-41f0-8362-b78d58d5506f microsoft.dataprotection/backupvaults/backupinstance
pracdisk-pracdisk-643fac7d-0816-4056-8908-d0ef8b63b047                                                                 microsoft.dataprotection/backupvaults/backupinstance
test1-test1-59f95871-de81-4051-95e7-ee6c4e5b30e0                                                                       microsoft.dataprotection/backupvaults/backupinstance
anubhwus-test-anubhwus-test-5fe6ce14-fbd2-4641-80d0-f8f8b254601d                                                       microsoft.dataprotection/backupvaults/backupinstance
.Example
PS C:\> Search-AzDataProtectionBackupInstanceInAzGraph -Subscription "xxxx-xxx-xxx" -DatasourceType AzureDisk -ResourceGroup @("sarath-rg", "sarath-rg2")

Name                                                           Type                                                  BackupInstanceName
----                                                           ----                                                  ------------------
sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea74df26d4a8 microsoft.dataprotection/backupvaults/backupinstances sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea7
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166     microsoft.dataprotection/backupvaults/backupinstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e59
sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6bad4305a   microsoft.dataprotection/backupvaults/backupinstances sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6b
.Example
PS C:\> Search-AzDataProtectionBackupInstanceInAzGraph -Subscription "xxxx-xxx-xxx" -DatasourceType AzureDisk -ResourceGroup @("sarath-rg", "sarath-rg2") -ProtectionStatus  ProtectionConfigured

Name                                                           Type                                                  BackupInstanceName
----                                                           ----                                                  ------------------
sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea74df26d4a8 microsoft.dataprotection/backupvaults/backupinstances sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea7
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166     microsoft.dataprotection/backupvaults/backupinstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e59
sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6bad4305a   microsoft.dataprotection/backupvaults/backupinstances sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6b

.Outputs
System.Management.Automation.PSObject
.Link
https://docs.microsoft.com/powershell/module/az.dataprotection/search-azdataprotectionbackupinstanceinazgraph
#>
function Search-AzDataProtectionBackupInstanceInAzGraph {
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
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProtectionStatus[]]
    # Protection Status of the item
    ${ProtectionStatus}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.DataProtection.custom\Search-AzDataProtectionBackupInstanceInAzGraph';
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
