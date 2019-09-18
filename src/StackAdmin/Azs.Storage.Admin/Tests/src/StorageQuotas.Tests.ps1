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
    Run AzureStack StorageQuotas admin tests

.DESCRIPTION
    Run AzureStack StorageQuotas admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\StorageQuota.Tests.ps1
    Describing StorageQuotas
 	  [+] TestListAllStorageQuotas 447ms
 	  [+] TestGetStorageQuota 366ms
 	  [+] TestGetAllStorageQuotas 1.51s
 	  [+] TestCreateStorageQuota 456ms
 	  [+] TestUpdateStorageQuota 818ms
	  [+] TestDeleteStorageQuota 653ms

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

    Describe "StorageQuotas" -Tags @('StorageQuotas', 'Azs.Storage.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateStorageQuota {
                param(
                    [Parameter(Mandatory = $true)]
                    $storageQuota
                )
                # Resource
                $storageQuota								| Should Not Be $null

                # Validate Storage quota properties
                $storageQuota.CapacityInGb				| Should Not Be $null
                $storageQuota.NumberOfStorageAccounts					| Should Not Be $null
                $storageQuota.Type	| Should Not Be $null
                $storageQuota.Id							| Should Not Be $null
                $storageQuota.Location					| Should Not Be $null
                $storageQuota.Name						| Should Not Be $null
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
                    $found												    | Should Be $null
                }
                else {
                    $found												    | Should Not Be $null
                    # Validate Storage quota properties
                    $expected.CapacityInGb | Should Be $found.CapacityInGb
                    $expected.NumberOfStorageAccounts | Should Be $found.NumberOfStorageAccounts
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        it "TestListAllStorageQuotas" -Skip:$('TestListAllStorageQuotas' -in $global:SkippedTests) {
            $global:TestName = 'TestListAllStorageQuotas'

            $quotas = Get-AzsStorageQuota -Location $global:Location
            foreach ($quota in $quotas.Value) {
                ValidateStorageQuota -storageQuota $quota
            }
        }

        it "TestGetStorageQuota" -Skip:$('TestGetStorageQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestGetStorageQuota'

            $quotas = Get-AzsStorageQuota -Location $global:Location
            $quotas = $quotas.Value
            $quotaName = $quotas[0].Name.Substring($quotas[0].Name.IndexOf("/") + 1)
            $quota = Get-AzsStorageQuota -Location $global:Location -Name $quotaName
            ValidateStorageQuota -storageQuota $quota
            AssertAreEqual -expected $quotas[0] -found $quota
        }

        it "TestGetAllStorageQuotas" -Skip:$('TestGetAllStorageQuotas' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllStorageQuotas'

            $quotas = Get-AzsStorageQuota -Location $global:Location
            $quotas = $quotas.Value
            foreach ($quota in $quotas) {
                $quotaName = $quota.Name.Substring($quotas[0].Name.IndexOf("/") + 1)
                $result = Get-AzsStorageQuota -Location $global:Location -Name $quotaName
                ValidateStorageQuota -storageQuota $quota
                AssertAreEqual -expected $quota -found $result
            }
        }

        it "TestCreateStorageQuota" -Skip:$('TestCreateStorageQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateStorageQuota'

            $name = "TestCreateQuota"
            $quota = New-AzsStorageQuota -CapacityInGb 100000000 -NumberOfStorageAccounts 1000000000 -Location $global:Location -Name $name
            $quota                          | Should Not Be $null
            $quota.CapacityInGb             | Should Be 100000000
            $quota.NumberOfStorageAccounts  | Should Be 1000000000
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
        }

        # Recorded test sessions cannot deal with two PUTs on the same URIs but with different bodies.
        it "TestUpdateStorageQuota" -Skip:$('TestUpdateStorageQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestUpdateStorageQuota'

            $name = "TestUpdateQuota"

            $quota = New-AzsStorageQuota -CapacityInGb 50 -NumberOfStorageAccounts 100 -Location $global:Location -Name $name

            $quota | Should Not Be $null

            $CapInGB = 123
            $NumStorageAccounts = 10

            $updated = Set-AzsStorageQuota `
                -CapacityInGb $CapInGB `
                -NumberOfStorageAccounts $NumStorageAccounts `
                -Location $global:Location `
                -Name $name

            ValidateStorageQuota -storageQuota $updated
            $updated.CapacityInGb               | Should Be $CapInGB
            $updated.NumberOfStorageAccounts    | Should Be $NumStorageAccounts

            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
        }

        it "TestDeleteStorageQuota" -Skip:$('TestDeleteStorageQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestDeleteStorageQuota'

            $name = "TestDeleteQuota"
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
            $quota = New-AzsStorageQuota -CapacityInGb 50 -NumberOfStorageAccounts 100 -Location $global:Location -Name $name
            $quota      |    Should Not Be $null
            $quota.CapacityInGb | Should Be 50
            $quota.NumberOfStorageAccounts | Should Be 100
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
        }
    }
}
