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
    Run AzureStack Acquisition admin acquisition location test

.DESCRIPTION
    Run AzureStack Acquisition admin acquisition location tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Acquisitions.Tests.ps1
    Describing Acquisitions
	 [+] TestListAcquisition 1.81s

.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 24, 2018
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

    Describe "Acquisition" -Tags @('Acquisition', 'Azs.Storage.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateAcquisition {
                param(
                    [Parameter(Mandatory = $true)]
                    $Acquisition
                )
                # Resource
                $Acquisition             | Should Not Be $null

                # Validate acquisition properties
                $Acquisition.Id					| Should Not Be $null
                $Acquisition.Name				| Should Not Be $null
                $Acquisition.Type				| Should Not Be $null
                $Acquisition.FilePath			| Should Not Be $null
                $Acquisition.Maximumblobsize    | Should Not Be $null
                $Acquisition.Status				| Should Not Be $null
                $Acquisition.Storageaccount     | Should Not Be $null
                $Acquisition.Container			| Should Not Be $null
                $Acquisition.Blob				| Should Not Be $null
            }
        }

        AfterEach {
            $global:Client = $null
        }

        it "TestListAllAcquisitions" -Skip:$('TestListAllAcquisitions' -in $global:SkippedTests) {
            $global:TestName = 'TestListAllAcquisitions'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $acquisitions = Get-AzsStorageAcquisition -ResourceGroupName $global:ResourceGroupName -FarmName $farm.Name
                foreach ($acquisition in $acquisitions) {
                    ValidateAcquisition -Acquisition $acquisition
                }
            }
        }
    }
}
