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
	  [+] TestListAllStorageQuotas 771ms
	  [+] TestGetStorageQuota 1.24s
	  [+] TestGetAllStorageQuotas 2.21s
	  [+] TestCreateStorageQuota 3.06s
	  [+] TestUpdateStorageQuota 2.66s
	  [+] TestDeleteStorageQuota 1.53s

.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 28, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Storage.Admin {

    Describe "StorageQuotas" -Tags @('StorageQuotas', 'Azs.Storage.Admin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

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
                if ($expected -eq $null) {
                    $found												    | Should Be $null
                } else {
                    $found												    | Should Not Be $null
                    # Validate Storage quota properties
                    $expected.CapacityInGb | Should Be $found.CapacityInGb
                    $expected.NumberOfStorageAccounts | Should Be $found.NumberOfStorageAccounts
                }
            }
        }

        It "TestListAllStorageQuotas" {
            $global:TestName = 'TestListAllStorageQuotas'

            $quotas = Get-AzsStorageQuota -Location $global:Location
            foreach ($quota in $quotas) {
                ValidateStorageQuota -storageQuota $quota
            }
        }

        It "TestGetStorageQuota" {
            $global:TestName = 'TestGetStorageQuota'

            $quotas = Get-AzsStorageQuota -Location $global:Location
            $quota = Get-AzsStorageQuota -Location $global:Location -Name (Select-Name $quotas[0].Name)
            ValidateStorageQuota -storageQuota $quota
            AssertAreEqual -expected $quotas[0] -found $quota
        }

        It "TestGetAllStorageQuotas" {
            $global:TestName = 'TestGetAllStorageQuotas'

            $quotas = Get-AzsStorageQuota -Location $global:Location
            foreach ($quota in $quotas) {
                $result = Get-AzsStorageQuota -Location $global:Location -Name (Select-Name $quota.Name)
                ValidateStorageQuota -storageQuota $quota
                AssertAreEqual -expected $quota -found $result
            }
        }

        It "TestCreateStorageQuota" {
            $global:TestName = 'TestCreateStorageQuota'

            $name = "TestCreateQuota"
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
            $quota = New-AzsStorageQuota -CapacityInGb 1000 -NumberOfStorageAccounts 100 -Location $global:Location -Name $name
            $quota      |    Should Not Be $null
            $quota.CapacityInGb | Should Be 1000
            $quota.NumberOfStorageAccounts | Should Be 100
            $result = Get-AzsStorageQuota -Location $global:Location -Name $name
            ValidateStorageQuota -storageQuota $result
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
        }

        # Recorded test sessions cannot deal with two PUTs on the same URIs but with different bodies.
        It "TestUpdateStorageQuota" {
            $global:TestName = 'TestUpdateStorageQuota'

            $name = "TestUpdateQuota"

            $quota = Get-AzsStorageQuota -Name $name -Location $global:Location
            if($quota -eq $null) {
                $quota = New-AzsStorageQuota -CapacityInGb 10 -NumberOfStorageAccounts 123 -Location $global:Location -Name $name
            }

            $quota | Should Not Be $null

            $CapInGB = $quota.CapacityInGb + 1
            $NumStorageAccounts = $quota.NumberOfStorageAccounts + 1

            $updated = Set-AzsStorageQuota `
                -CapacityInGb $CapInGB `
                -NumberOfStorageAccounts $NumStorageAccounts `
                -Location $global:Location `
                -Name $name `
                -Force

            ValidateStorageQuota -storageQuota $updated
            $updated.CapacityInGb               | Should Be $CapInGB
            $updated.NumberOfStorageAccounts    | Should Be $NumStorageAccounts

            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
        }

        It "TestDeleteStorageQuota" {
            $global:TestName = 'TestDeleteStorageQuota'

            $name = "TestDeleteQuota"
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
            $quota = New-AzsStorageQuota -CapacityInGb 1000 -NumberOfStorageAccounts 50 -Location $global:Location -Name $name
            $quota      |    Should Not Be $null
            $quota.CapacityInGb | Should Be 1000
            $quota.NumberOfStorageAccounts | Should Be 50
            Remove-AzsStorageQuota -Location $global:Location -Name $name -Force
        }
    }
}
