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
    Run AzureStack subscription admin tests.

.DESCRIPTION
    Run AzureStack subscriptions admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Location.Tests.ps1
	Describing Location
	  [+] TestListLocations 130ms
	  [+] TestGetAllLocations 93ms
	  [+] TestGetLocation 140ms

.NOTES
    Author: Mike Giesler
	Copyright: Microsoft
    Date:   March 16, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Subscriptions.Admin {

    Describe "Location" -Tags @('Locations', 'SubscriptionsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateLocation {
                param(
                    [Parameter(Mandatory = $true)]
                    $Location
                )
                # Overall
                $Location               | Should Not Be $null

                # Resource
                $Location.Id            | Should Not Be $null
                $Location.Name          | Should Not Be $null

                # Location
                $Location.DisplayName   | Should Not Be $null
                $Location.Latitude      | Should Not Be $null
                $Location.Longitude     | Should Not Be $null
            }

            function AssertLocationsSame {
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
                    $Found.Name             | Should Be $Expected.Name

                    # Location
                    $Found.DisplayName      | Should Be $Expected.DisplayName
                    $Found.Latitude         | Should Be $Expected.Latitude
                    $Found.Longitude        | Should Be $Expected.Longitude
                }
            }
        }

        it "TestListLocations" -Skip:$('TestListLocations' -in $global:SkippedTests) {
            $global:TestName = 'TestListLocations'

            $allLocations = Get-AzsLocation
            $global:ResourceGroupNames = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]

            foreach ($Location in $allLocations) {
                ValidateLocation $location
            }
        }

        it "TestGetAllLocations" -Skip:$('TestGetAllLocations' -in $global:SkippedTests) {
            $global:TestName = "TestGetAllLocations"

            $allLocations = Get-AzsLocation
            foreach ($Location in $allLocations) {
                $location2 = Get-AzsLocation -Name $location.Name
                AssertLocationsSame $location $location2
            }
        }

        it "TestGetLocation" -Skip:$('TestGetLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestGetLocation'

            $Location = (Get-AzsLocation)[0]
            $Location | Should Not Be $null
            $Location2 = Get-AzsLocation -Name $Location.Name
            AssertLocationsSame $Location $Location2
        }
    }
}
