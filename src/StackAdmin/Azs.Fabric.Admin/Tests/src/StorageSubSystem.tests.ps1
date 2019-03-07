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
    Run AzureStack fabric admin storage subsystem tests.

.DESCRIPTION
    Run AzureStack fabric admin storage subsystem tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\StorageSubSystem.Tests.ps1
    Describing StorageSubSystems
     [+] TestListStorageSubSystems 187ms
     [+] TestGetStorageSubSystem 98ms
     [+] TestGetAllStorageSubSystems 79ms
     [+] TestGetInvaildStorageSubSystem 78ms

.EXAMPLE
    PS C:\> .\src\StorageSubSystem.Tests.ps1 -RunRaw $true
    Describing StorageSubSystems
     [+] TestListStorageSubSystems 1.56s
     [+] TestGetStorageSubSystem 1.98s
     [+] TestGetAllStorageSubSystems 2.07s
     [+] TestGetInvaildStorageSubSystem 1.58s

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

    Describe "StorageSubSystems" -Tags @('StorageSubSystem', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateStorageSubSystem {
                param(
                    [Parameter(Mandatory = $true)]
                    $StorageSubSystem
                )

                $StorageSubSystem          | Should Not Be $null

                # Resource
                $StorageSubSystem.Id       | Should Not Be $null
                $StorageSubSystem.Location | Should Not Be $null
                $StorageSubSystem.Name     | Should Not Be $null
                $StorageSubSystem.Type     | Should Not Be $null

                # Storage Subsystem
                $StorageSubSystem.TotalCapacityGB      | Should Not Be $null
                $StorageSubSystem.RemainingCapacityGB  | Should Not Be $null
                $StorageSubSystem.HealthStatus         | Should Not Be $null
                $StorageSubSystem.OperationalStatus    | Should Not Be $null
                $StorageSubSystem.RebalanceStatus      | Should Not Be $null
            }

            function AssertStorageSubSystemsAreSame {
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

                    # Storage System
                    $Found.TotalCapacityGB      | Should Be $Expected.TotalCapacityGB
                    $Found.RemainingCapacityGB  | Should Be $Expected.RemainingCapacityGB
                    $Found.HealthStatus         | Should Be $Expected.HealthStatus
                    $Found.OperationalStatus    | Should Be $Expected.OperationalStatus
                    $Found.RebalanceStatus      | Should Be $Expected.RebalanceStatus
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListStorageSubSystems" -Skip:$('TestListStorageSubSystems' -in $global:SkippedTests) {
            $global:TestName = 'TestListStorageSubSystems'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $StorageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                $StorageSubSystems | Should Not Be $null
                foreach ($StorageSubSystem in $StorageSubSystems) {
                    ValidateStorageSubSystem -StorageSubSystem $StorageSubSystem
                }
            }
        }


        it "TestGetStorageSubSystem" -Skip:$('TestGetStorageSubSystem' -in $global:SkippedTests) {
            $global:TestName = 'TestGetStorageSubSystem'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $StorageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($StorageSubSystem in $StorageSubSystems) {
                    $retrieved = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -Name $StorageSubSystem.Name
                    AssertStorageSubSystemsAreSame -Expected $StorageSubSystem -Found $retrieved
                    break
                }
                break
            }
        }

        it "TestGetAllStorageSubSystems" -Skip:$('TestGetAllStorageSubSystems' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllStorageSubSystems'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $StorageSubSystems = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name
                foreach ($StorageSubSystem in $StorageSubSystems) {
                    $retrieved = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -Name $StorageSubSystem.Name
                    AssertStorageSubSystemsAreSame -Expected $StorageSubSystem -Found $retrieved
                }
            }
        }

        it "TestGetInvaildStorageSubSystem" -Skip:$('TestGetInvaildStorageSubSystem' -in $global:SkippedTests) {
            $global:TestName = 'TestGetInvaildStorageSubSystem'

            $scaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($scaleUnit in $scaleUnits) {
                $invaildStorageSubSystemName = "invaildstoragesubsystemname"
                $retrieved = Get-AzsStorageSubSystem -ResourceGroupName $global:ResourceGroupName -Location $Location -ScaleUnit $scaleUnit.Name -Name $invaildStorageSubSystemName
                $retrieved | Should Be $null
                break
            }
        }
    }
}
