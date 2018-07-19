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
    Run AzureStack fabric admin volume tests.

.DESCRIPTION
    Run AzureStack fabric admin volume tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\Volume.Tests.ps1
	Describing StoragePools
	 [+] TestListVolumes 237ms
	 [+] TestGetVolume 128ms
	 [+] TestGetAllVolumes 98ms

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
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Fabric.Admin {

    Describe "StoragePools" -Tags @('StoragePool', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateVolume {
                param(
                    [Parameter(Mandatory = $true)]
                    $Volume
                )

                $Volume          | Should Not Be $null

                # Resource
                $Volume.Id       | Should Not Be $null
                $Volume.Location | Should Not Be $null
                $Volume.Name     | Should Not Be $null
                $Volume.Type     | Should Not Be $null

                # Storage Pool
                $Volume.FileSystem       | Should Not Be $null
                $Volume.RemainingSizeGB  | Should Not Be $null
                $Volume.SizeGB           | Should Not Be $null
                $Volume.VolumeLabel      | Should Not Be $null
            }

            function AssertVolumesAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                }
                else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Storage Pool
                    $Found.FileSystem       | Should Be $Expected.FileSystem
                    $Found.RemainingSizeGB  | Should Be $Expected.RemainingSizeGB
                    $Found.SizeGB           | Should Be $Expected.SizeGB
                    $Found.VolumeLabel      | Should Be $Expected.VolumeLabel

                }
            }
        }


        it "TestListVolumes" -Skip:$('TestListVolumes' -in $global:SkippedTests) {
            $global:TestName = 'TestListVolumes'

            $storageSystems = Get-AzsStorageSystem -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($storageSystem in $storageSystems) {
                $StoragePools = Get-AzsStoragePool -ResourceGroupName $global:ResourceGroupName -Location $Location -StorageSystem $storageSystem.Name
                foreach ($StoragePool in $StoragePools) {
                    $volumes = Get-AzsInfrastructureVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -StorageSystem $storageSystem.Name -StoragePool $StoragePool.Name
                    $volumes | Should Not Be $null
                    foreach ($volume in $volumes) {
                        ValidateVolume $volume
                    }
                }
            }
        }


        it "TestGetVolume" -Skip:$('TestGetVolume' -in $global:SkippedTests) {
            $global:TestName = 'TestGetVolume'

            $storageSystems = Get-AzsStorageSystem -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($storageSystem in $storageSystems) {
                $StoragePools = Get-AzsStoragePool -ResourceGroupName $global:ResourceGroupName -Location $Location -StorageSystem $storageSystem.Name
                foreach ($StoragePool in $StoragePools) {
                    $volumes = Get-AzsInfrastructureVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -StorageSystem $storageSystem.Name -StoragePool $StoragePool.Name
                    foreach ($volume in $volumes) {
                        $retrieved = Get-AzsInfrastructureVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -StoragePool $StoragePool.Name -StorageSystem $storageSystem.Name -Name $volume.Name
                        AssertVolumesAreSame -Expected $volume -Found $retrieved
                        break
                    }
                    break
                }
                break
            }
        }

        it "TestGetAllVolumes" -Skip:$('TestGetAllVolumes' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllVolumes'

            $storageSystems = Get-AzsStorageSystem -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($storageSystem in $storageSystems) {
                $StoragePools = Get-AzsStoragePool -ResourceGroupName $global:ResourceGroupName -Location $Location -StorageSystem $storageSystem.Name
                foreach ($StoragePool in $StoragePools) {
                    $volumes = Get-AzsInfrastructureVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -StorageSystem $storageSystem.Name -StoragePool $StoragePool.Name
                    foreach ($volume in $volumes) {
                        $retrieved = Get-AzsInfrastructureVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -StoragePool $StoragePool.Name -StorageSystem $storageSystem.Name -Name $volume.Name
                        AssertVolumesAreSame -Expected $volume -Found $retrieved
                    }
                }
            }
        }
    }
}
