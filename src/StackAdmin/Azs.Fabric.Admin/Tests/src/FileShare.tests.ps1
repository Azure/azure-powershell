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
    Run AzureStack fabric admin infrastructure share tests.

.DESCRIPTION
    Run AzureStack fabric admin infrastructure share tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\InfrastructureShare.Tests.ps1
	Describing InfrastructureShares
	 [+] TestListFileShares 178ms
	 [+] TestGetFileShare 100ms
	 [+] TestGetAllFileShares 174ms

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

    Describe "InfrastructureShares" -Tags @('FileShare', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateFileShare {
                param(
                    [Parameter(Mandatory = $true)]
                    $Share
                )

                $FileShare          | Should Not Be $null

                # Resource
                $FileShare.Id       | Should Not Be $null
                $FileShare.Location | Should Not Be $null
                $FileShare.Name     | Should Not Be $null
                $FileShare.Type     | Should Not Be $null

                # FileShare
                $FileShare.AssociatedVolume  | Should not be $null
                $FileShare.UncPath           | Should not be $null

            }

            function AssertFileSharesAreSame {
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

                    # FileShare
                    $Found.AssociatedVolume    | Should Be $Expected.AssociatedVolume
                    $Found.UncPath             | Should Be $Expected.UncPath

                }
            }
        }

        AfterEach {
            $global:Client = $null
        }

        It "TestListFileShares" -Skip:$('TestListFileShares' -in $global:SkippedTests) {
            $global:TestName = 'TestListFileShares'
            $fileShares = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $Location
            $fileShares | Should not be $null
            foreach ($fileShare in $fileShares) {
                ValidateFileShare -Share $fileShare
            }
        }

        It "TestGetFileShare" -Skip:$('TestGetFileShare' -in $global:SkippedTests) {
            $global:TestName = 'TestGetFileShare'

            $fileShares = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $Location
            if ($fileShares -and $fileShares.Count -gt 0) {
                $fileShare = $fileShares[0]
                $retrieved = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $fileShare.Name

                AssertFileSharesAreSame -Expected $fileShare -Found $retrieved
            }
        }

        It "TestGetAllFileShares" -Skip:$('TestGetAllFileShares' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllFileShares'

            $fileShares = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $Location
            foreach ($fileShare in $fileShares) {
                $retrieved = Get-AzsInfrastructureShare -ResourceGroupName $global:ResourceGroupName -Location $Location -Name $fileShare.Name
                AssertFileSharesAreSame -Expected $fileShare -Found $retrieved
            }
        }
    }
}
