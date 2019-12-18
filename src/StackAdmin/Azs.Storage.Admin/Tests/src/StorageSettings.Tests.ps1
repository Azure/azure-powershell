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
    Run AzureStack Storage Settings admin tests

.DESCRIPTION
    Run AzureStack Storage Settings tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\StorageSettings.Tests.ps1
Describing Setting
	  [+] TestGetStorageSettings 352ms
	  [+] TestUpdateStorageSettings 335ms
.NOTES
    Author: Wenjia Lu
	Copyright: Microsoft
    Date:   August 14, 2019
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Storage.Admin {

    Describe "Setting" -Tags @('Setting', 'Azs.Storage.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateSetting {
                param(
                    [Parameter(Mandatory = $true)]
                    $Setting
                )
                $setting													| Should Not Be $null
                $setting.RetentionPeriodForDeletedStorageAccountsInDays		| Should Not Be $null
            }

            function AssertAreEqual {
                param(
                    [Parameter(Mandatory = $true)]
                    $expected,
                    [Parameter(Mandatory = $true)]
                    $found
                )
                # Resource
                if ($null -eq $expected) {
                    $found												     | Should Be $null
                }
                else {
                    $found												     | Should Not Be $null
                    # Validate Farm properties
                    $expected.RetentionPeriodForDeletedStorageAccountsInDays | Should Be $found.RetentionPeriodForDeletedStorageAccountsInDays
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestGetStorageSettings" -Skip:$('TestGetStorageSettings' -in $global:SkippedTests) {
            $global:TestName = 'TestGetStorageSettings'

            $result = Get-AzsStorageSettings -Location $global:Location 
            $result  | Should Not Be $null
            ValidateSetting -Setting $result
        }

        It "TestUpdateStorageSettings" -Skip:$('TestUpdateStorageSettings' -in $global:SkippedTests) {
            $global:TestName = 'TestUpdateStorageSettings'

            $originalDays = (Get-AzsStorageSettings -Location $global:Location).RetentionPeriodForDeletedStorageAccountsInDays
            $targetDays = $originalDays + 1
            $result = Update-AzsStorageSettings -Location $global:Location -RetentionPeriodForDeletedStorageAccountsInDays $targetDays
            $result  | Should Not Be $null
            $result.RetentionPeriodForDeletedStorageAccountsInDays | Should Be $targetDays
        }
    }
}
