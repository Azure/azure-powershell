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
.SYNOPSIS
    Run AzureStack KeyVault admin edge gateway tests.

.DESCRIPTION
    Run AzureStack KeyVault admin edge gateway tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Quota.Tests.ps1
    Describing KeyVaultQuotas
	 [+] TestListQuotas 81ms

.NOTES
    Author: Microsoft
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.KeyVault.Admin {

    Describe "KeyVaultQuotas" -Tags @('KeyVaultQuotas', 'Azs.KeyVault.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {
        }


        it "TestListQuotas" -Skip:$('TestListQuotas' -in $global:SkippedTests) {
            $global:TestName = 'TestListQuotas'

            $quotas = Get-AzsKeyVaultQuota -Location $global:Location
            $quotas  | Should Not Be $null
        }
    }
}
