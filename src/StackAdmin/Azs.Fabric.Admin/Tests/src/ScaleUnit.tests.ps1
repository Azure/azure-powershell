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
    Run AzureStack fabric admin scale unit tests.

.DESCRIPTION
    Run AzureStack fabric admin scale unit tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\ScaleUnit.Tests.ps1
	Describing ScaleUnits
	 [+] TestListScaleUnits 155ms
	 [+] TestGetScaleUnit 117ms
	 [+] TestGetAllScaleUnits 81ms

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

    Describe "ScaleUnits" -Tags @('ScaleUnit', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateScaleUnit {
                param(
                    [Parameter(Mandatory = $true)]
                    $ScaleUnit
                )

                $ScaleUnit          | Should Not Be $null

                # Resource
                $ScaleUnit.Id       | Should Not Be $null
                $ScaleUnit.Location | Should Not Be $null
                $ScaleUnit.Name     | Should Not Be $null
                $ScaleUnit.Type     | Should Not Be $null

                # Scale Unit
                $ScaleUnit.LogicalFaultDomain  | Should Not Be $null
                $ScaleUnit.ScaleUnitType       | Should Not Be $null
                $ScaleUnit.State               | Should Not Be $null
                $ScaleUnit.TotalCapacity       | Should Not Be $null
            }

            function AssertScaleUnitsAreSame {
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

                    # Scale Unit
                    $Found.LogicalFaultDomain  | Should Be $Expected.LogicalFaultDomain
                    $Found.Model               | Should Be $Expected.Model


                    if ($Expected.Nodes -eq $null) {
                        $Found.Nodes        | Should be $null
                    }
                    else {
                        $Found.Nodes        | Should not be $null
                        $Found.Nodes.Count  | Should be $Expected.Nodes.Count
                    }

                    $Found.ScaleUnitType  | Should Be $Expected.ScaleUnitType
                    $Found.State          | Should Be $Expected.State

                    if ($Expected.TotalCapacity -eq $null) {
                        $Found.TotalCapacity           | Should be $null
                    }
                    else {
                        $Found.TotalCapacity           | Should not be $null
                        $Found.TotalCapacity.Cores     | Should be $Expected.TotalCapacity.Cores
                        $Found.TotalCapacity.MemoryGB  | Should be $Expected.TotalCapacity.MemoryGB
                    }
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListScaleUnits" -Skip:$('TestListScaleUnits' -in $global:SkippedTests) {
            $global:TestName = 'TestListScaleUnits'
            $ScaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            $ScaleUnits | Should Not Be $null
            foreach ($ScaleUnit in $ScaleUnits) {
                ValidateScaleUnit -ScaleUnit $ScaleUnit
            }
        }


        it "TestGetScaleUnit" -Skip:$('TestGetScaleUnit' -in $global:SkippedTests) {
            $global:TestName = 'TestGetScaleUnit'

            $ScaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($ScaleUnit in $ScaleUnits) {
                $retrieved = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $ScaleUnit.Name
                AssertScaleUnitsAreSame -Expected $ScaleUnit -Found $retrieved
                break
            }
        }

        it "TestGetAllScaleUnits" -Skip:$('TestGetAllScaleUnits' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllScaleUnits'

            $ScaleUnits = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($ScaleUnit in $ScaleUnits) {
                $retrieved = Get-AzsScaleUnit -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $ScaleUnit.Name
                AssertScaleUnitsAreSame -Expected $ScaleUnit -Found $retrieved
            }
        }
    }
}
