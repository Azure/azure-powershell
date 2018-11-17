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
    Run AzureStack fabric admin edge gateway pool tests.

.DESCRIPTION
    Run AzureStack fabric admin edge gateway pool tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\ServiceHealth.Tests.ps1
	Describing AzsServiceHealths
	[+] TestListAzsServiceHealths 241ms
	[+] TestGetAzsServiceHealth 139ms
	[+] TestGetAllAzsServiceHealths 493ms

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

InModuleScope Azs.InfrastructureInsights.Admin {

    Describe "AzsServiceHealths" -Tags @('AzsServiceHealth', 'InfrastructureInsightsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateAzsServiceHealth {
                param(
                    [Parameter(Mandatory = $true)]
                    $ServiceHealth
                )

                $ServiceHealth          | Should Not Be $null

                # Resource
                $ServiceHealth.Id       | Should Not Be $null
                $ServiceHealth.Location | Should Not Be $null
                $ServiceHealth.Name     | Should Not Be $null
                $ServiceHealth.Type     | Should Not Be $null

                # Service Health
                $ServiceHealth.AlertSummary  	| Should Not Be $null
                $ServiceHealth.DisplayName  	| Should Not Be $null
                $ServiceHealth.HealthState  	| Should Not Be $null
                $ServiceHealth.InfraURI  		| Should Not Be $null
                #$ServiceHealth.Namespace        | Should Not Be $null
                $ServiceHealth.RegistrationId   | Should Not Be $null
                $ServiceHealth.RoutePrefix      | Should Not Be $null
                $ServiceHealth.ServiceLocation	| Should Not Be $null
            }

            function AssertAzsServiceHealthsAreSame {
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

                    # Service Health
                    if ($Expected.AlertSummary -eq $null) {
                        $Found.AlertSummary        				| Should Be $null
                    } else {
                        $Found.AlertSummary        				| Should Not Be $null
                        $Found.AlertSummary.CriticalAlertCount  | Should Be $Expected.AlertSummary.CriticalAlertCount
                        $Found.AlertSummary.WarningAlertCount  	| Should Be $Expected.AlertSummary.WarningAlertCount
                    }

                    $Found.DisplayName  	| Should Be $Expected.DisplayName
                    $Found.HealthState  	| Should Be $Expected.HealthState
                    $Found.InfraURI  		| Should Be $Expected.InfraURI
                    #$Found.Namespace  		| Should Be $Expected.Namespace
                    $Found.RegistrationId	| Should Be $Expected.RegistrationId
                    $Found.RoutePrefix  	| Should Be $Expected.RoutePrefix
                    $Found.ServiceLocation  | Should Be $Expected.ServiceLocation


                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListServiceHealths" -Skip:$('TestListServiceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestListServiceHealths'


            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    ValidateAzsServiceHealth -ServiceHealth $serviceHealth
                }
            }
        }

        it "TestGetServiceHealth" -Skip:$('TestGetServiceHealth' -in $global:SkippedTests) {
            $global:TestName = 'TestGetServiceHealth'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $retrieved = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -Name $serviceHealth.Name
                    AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                    break
                }
                break
            }
        }

        it "TestGetAllServiceHealths" -Skip:$('TestGetAllServiceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllServiceHealths'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $retrieved = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -Name $serviceHealth.Name
                    AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                }
            }
        }



        it "TestGetAllServiceHealths" -Skip:$('TestGetAllServiceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllServiceHealths'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $retrieved = $serviceHealth | Get-AzsRPHealth
                    AssertAzsServiceHealthsAreSame -Expected $serviceHealth -Found $retrieved
                }
            }
        }
    }
}
