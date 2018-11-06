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
    Describing Volumes
     [+] TestListVolumes 160ms
     [+] TestGetVolume 81ms
     [+] TestGetAllVolumes 137ms

.EXAMPLE
    PS C:\> .\src\Volume.Tests.ps1 -RunRaw $true
    Describing Volumes
     [+] TestListVolumes 7.53s
     [+] TestGetVolume 3.02s
     [+] TestGetAllVolumes 3.08s

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

    Describe "Volumes" -Tags @('Volume', 'Azs.Fabric.Admin') {

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

                # Volume
                $Volume.TotalCapacityGB      | Should Not Be $null
                $Volume.RemainingCapacityGB  | Should Not Be $null
                $Volume.HealthStatus         | Should Not Be $null
                $Volume.OperationalStatus    | Should Not Be $null
                $Volume.RepairStatus         | Should Not Be $null
                $Volume.Description          | Should Not Be $null
                $Volume.Action               | Should Not Be $null
                $Volume.VolumeLabel          | Should Not Be $null
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

                    # Volume
                    $Found.TotalCapacityGB      | Should Be $Expected.TotalCapacityGB
                    $Found.RemainingCapacityGB  | Should Be $Expected.RemainingCapacityGB
                    $Found.HealthStatus         | Should Be $Expected.HealthStatus
                    $Found.OperationalStatus    | Should Be $Expected.OperationalStatus
                    $Found.RepairStatus         | Should Be $Expected.RepairStatus
                    $Found.Description          | Should Be $Expected.Description
                    $Found.Action               | Should Be $Expected.Action
                    $Found.VolumeLabel          | Should Be $Expected.VolumeLabel

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListVolumes" -Skip:$('TestListVolumes' -in $global:SkippedTests) {
            $global:TestName = 'TestListVolumes'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($storageSubSystem in $storageSubSystems) {
                    $volumes = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                    $volumes | Should Not Be $null
                    foreach ($volume in $volumes) {
                        ValidateVolume $volume
                    }
                }
            }
        }


        it "TestGetVolume" -Skip:$('TestGetVolume' -in $global:SkippedTests) {
            $global:TestName = 'TestGetVolume'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($storageSubSystem in $storageSubSystems) {
                    $volumes = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                    foreach ($volume in $volumes) {
                        $retrieved = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $volume.Name
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

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($storageSubSystem in $storageSubSystems) {
                    $volumes = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                    foreach ($volume in $volumes) {
                        $retrieved = Get-AzsVolume -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $volume.Name
                        AssertVolumesAreSame -Expected $volume -Found $retrieved
                    }
                }
            }
        }
    }
}
