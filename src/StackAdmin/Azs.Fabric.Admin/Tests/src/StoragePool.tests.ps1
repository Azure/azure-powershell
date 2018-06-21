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
    Run AzureStack fabric admin edge gateway tests.

.DESCRIPTION
    Run AzureStack fabric admin edge gateway tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\StoragePool.Tests.ps1
	Describing StoragePools
	 [+] TestListStoragePools 124ms
	 [+] TestGetStoragePool 107ms
	 [+] TestGetAllStoragePools 78ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Fabric.Admin {

    Describe "StoragePools" -Tags @('StoragePool', 'Azs.Fabric.Admin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidateStoragePool {
                param(
                    [Parameter(Mandatory = $true)]
                    $StoragePool
                )

                $StoragePool          | Should Not Be $null

                # Resource
                $StoragePool.Id       | Should Not Be $null
                $StoragePool.Location | Should Not Be $null
                $StoragePool.Name     | Should Not Be $null
                $StoragePool.Type     | Should Not Be $null

                # Storage Pool
                $StoragePool.SizeGB   | Should Not Be $null
            }

            function AssertStoragePoolsAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                } else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Storage Pool
                    $Found.SizeGB          | Should Be $Expected.SizeGB

                }
            }
        }


        It "TestListStoragePools" {
            $global:TestName = 'TestListStoragePools'

            $storageSystems = Get-AzsStorageSystem -ResourceGroupName $ResourceGroup -Location $Location
            $storageSystems | Should not be $null
            foreach ($storageSystem in $storageSystems) {
                $StoragePools = Get-AzsStoragePool -ResourceGroupName $ResourceGroup -Location $Location -StorageSystem $storageSystem.Name
                $StoragePools | Should Not Be $null
                foreach ($StoragePool in $StoragePools) {
                    ValidateStoragePool -StoragePool $StoragePool
                }
            }
        }


        It "TestGetStoragePool" {
            $global:TestName = 'TestGetStoragePool'

            $storageSystems = Get-AzsStorageSystem -ResourceGroupName $ResourceGroup -Location $Location
            foreach ($storageSystem in $storageSystems) {
                $StoragePools = Get-AzsStoragePool -ResourceGroupName $ResourceGroup -Location $Location -StorageSystem $storageSystem.Name
                foreach ($StoragePool in $StoragePools) {
                    $retrieved = Get-AzsStoragePool -ResourceGroupName $ResourceGroup -Location $Location -StorageSystem $storageSystem.Name -Name $StoragePool.Name
                    AssertStoragePoolsAreSame -Expected $StoragePool -Found $retrieved
                    break
                }
                break
            }
        }

        It "TestGetAllStoragePools" {
            $global:TestName = 'TestGetAllStoragePools'

            $storageSystems = Get-AzsStorageSystem -ResourceGroupName $ResourceGroup -Location $Location
            foreach ($storageSystem in $storageSystems) {
                $StoragePools = Get-AzsStoragePool -ResourceGroupName $ResourceGroup -Location $Location -StorageSystem $storageSystem.Name
                foreach ($StoragePool in $StoragePools) {
                    $retrieved = Get-AzsStoragePool -ResourceGroupName $ResourceGroup -Location $Location -StorageSystem $storageSystem.Name -Name $StoragePool.Name
                    AssertStoragePoolsAreSame -Expected $StoragePool -Found $retrieved
                }
            }
        }
    }
}
