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


$global:SkippedTests = @(
)

$global:Location = "local"
$global:Provider = "Microsoft.Backup.Admin"
$global:ResourceGroupName = "System.local"
$global:username = "azurestack\AzureStackAdmin"
[SecureString]$global:password = ConvertTo-SecureString -String "password" -AsPlainText -Force
$global:path = "\\su1fileserver\SU1_Infrastructure_2\BackupStore"
$global:encryptionCertBase64 = "ZW5jcnlwdGlvbkNlcnQ="
$global:encryptionCertPath = "$env:temp\encryptionCert.cer"
$global:isBackupSchedulerEnabled = $false
$global:backupFrequencyInHours = 10
$global:backupRetentionPeriodInDays = 6
$global:decryptionCertBase64 = "ZGVjcnlwdGlvbkNlcnQ="
$global:decryptionCertPath = "$env:temp\decryptionCert.pfx"
$global:decryptionCertPassword = ConvertTo-SecureString -String "decryptionCertPassword" -AsPlainText -Force

$global:Client = $null

if (-not $global:RunRaw) {
    $scriptBlock = {
        if ($null -eq $global:Client) {
            $global:Client = Get-MockClient -ClassName 'BackupAdminClient' -TestName $global:TestName -Verbose
        }
        return $global:Client
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
