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
    Run AzureStack fabric admin drive tests.

.DESCRIPTION
    Run AzureStack fabric admin drive tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\Drive.Tests.ps1
    Describing Drives
     [+] TestListDrives 348ms
     [+] TestGetDrive 135ms
     [+] TestGetAllDrives 204ms

.EXAMPLE
    PS C:\> .\src\Drive.Tests.ps1 -RunRaw $true
    Describing Drives
     [+] TestListDrives 3.01s
     [+] TestGetDrive 3.43s
     [+] TestGetAllDrives 12.1s

.NOTES
    Author: Yuxing Zhou
	Copyright: Microsoft
    Date:   October 31, 2018
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

    Describe "Drives" -Tags @('Drive', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateDrive {
                param(
                    [Parameter(Mandatory = $true)]
                    $Volume
                )

                $Drive          | Should Not Be $null

                # Resource
                $Drive.Id       | Should Not Be $null
                $Drive.Location | Should Not Be $null
                $Drive.Name     | Should Not Be $null
                $Drive.Type     | Should Not Be $null

                # Drive
                $Drive.StorageNode        | Should Not Be $null
                $Drive.SerialNumber       | Should Not Be $null
                $Drive.HealthStatus       | Should Not Be $null
                $Drive.OperationalStatus  | Should Not Be $null
                $Drive.Usage              | Should Not Be $null
                $Drive.CanPool            | Should Not Be $null
                $Drive.CannotPoolReason   | Should Not Be $null
                $Drive.PhysicalLocation   | Should Not Be $null
                $Drive.Model              | Should Not Be $null
                $Drive.MediaType          | Should Not Be $null
                $Drive.CapacityGB         | Should Not Be $null
                $Drive.Description        | Should Not Be $null
                $Drive.Action             | Should Not Be $null
            }

            function AssertDrivesAreSame {
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

                    # Drive
                    $Found.StorageNode        | Should Be $Expected.StorageNode
                    $Found.SerialNumber       | Should Be $Expected.SerialNumber
                    $Found.HealthStatus       | Should Be $Expected.HealthStatus
                    $Found.OperationalStatus  | Should Be $Expected.OperationalStatus
                    $Found.Usage              | Should Be $Expected.Usage
                    $Found.CanPool            | Should Be $Expected.CanPool
                    $Found.CannotPoolReason   | Should Be $Expected.CannotPoolReason
                    $Found.PhysicalLocation   | Should Be $Expected.PhysicalLocation
                    $Found.Model              | Should Be $Expected.Model
                    $Found.MediaType          | Should Be $Expected.MediaType
                    $Found.CapacityGB         | Should Be $Expected.CapacityGB
                    $Found.Description        | Should Be $Expected.Description
                    $Found.Action             | Should Be $Expected.Action

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListDrives" -Skip:$('TestListDrives' -in $global:SkippedTests) {
            $global:TestName = 'TestListDrives'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($storageSubSystem in $storageSubSystems) {
                    $drives = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                    $drives | Should Not Be $null
                    foreach ($drive in $drives) {
                        ValidateDrive $drive
                    }
                }
            }
        }


        it "TestGetDrive" -Skip:$('TestGetDrive' -in $global:SkippedTests) {
            $global:TestName = 'TestGetDrive'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($storageSubSystem in $storageSubSystems) {
                    $drives = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                    foreach ($drive in $drives) {
                        $retrieved = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $drive.Name
                        AssertDrivesAreSame -Expected $drive -Found $retrieved
                        break
                    }
                    break
                }
                break
            }
        }

        it "TestGetAllDrives" -Skip:$('TestGetAllDrives' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllDrives'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $storageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($storageSubSystem in $storageSubSystems) {
                    $drives = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name
                    foreach ($drive in $drives) {
                        $retrieved = Get-AzsDrive -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -StorageSubSystem $storageSubSystem.Name -Name $drive.Name
                        AssertDrivesAreSame -Expected $drive -Found $retrieved
                    }
                }
            }
        }
    }
}
