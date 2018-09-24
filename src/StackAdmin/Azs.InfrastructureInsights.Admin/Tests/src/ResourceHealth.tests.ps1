﻿# ----------------------------------------------------------------------------------
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
    PS C:\> .\src\ResourceHealth.Tests.ps1
	Describing ResourceHealths
	[+] TestListResourceHealths 1.2s
	[+] TestGetResourceHealth 94ms
	[+] TestGetAllResourceHealths 116ms

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

    Describe "ResourceHealths" -Tags @('ResourceHealth', 'InfrastructureInsightsAdmin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateResourceHealth {
                param(
                    [Parameter(Mandatory = $true)]
                    $ResourceHealth
                )

                $ResourceHealth          | Should Not Be $null

                # Resource
                $ResourceHealth.Id       | Should Not Be $null
                $ResourceHealth.Location | Should Not Be $null
                $ResourceHealth.Name     | Should Not Be $null
                $ResourceHealth.Type     | Should Not Be $null

                # Scale Unit Node
                $ResourceHealth.AlertSummary    	| Should Not Be $null
                $ResourceHealth.HealthState     	| Should Not Be $null
                # Sometimes this can be null??
                #$ResourceHealth.Namespace  			| Should Not Be $null
                $ResourceHealth.RegistrationId  	| Should Not Be $null
                $ResourceHealth.ResourceDisplayName	| Should Not Be $null
                $ResourceHealth.ResourceLocation	| Should Not Be $null
                $ResourceHealth.ResourceName		| Should Not Be $null
                $ResourceHealth.ResourceType		| Should Not Be $null
                $ResourceHealth.ResourceURI			| Should Not Be $null
                $ResourceHealth.RoutePrefix			| Should Not Be $null
                $ResourceHealth.RpRegistrationId	| Should Not Be $null
            }

            function AssertResourceHealthsAreSame {
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

                    # Resource Health
                    if ($Expected.AlertSummary -eq $null) {
                        $Found.AlertSummary | Should be $null
                    } else {
                        $Found.AlertSummary                     | Should Not Be $null
                        $Found.AlertSummary.CriticalAlertCount  | Should Be $Expected.AlertSummary.CriticalAlertCount
                        $Found.AlertSummary.WarningAlertCount  	| Should Be $Expected.AlertSummary.WarningAlertCount
                    }

                    $Found.HealthState      	| Should Be $Expected.HealthState
                    $Found.NamespaceProperty	| Should Be $Expected.NamespaceProperty
                    $Found.RegistrationId       | Should Be $Expected.RegistrationId
                    $Found.ResourceDisplayName  | Should Be $Expected.ResourceDisplayName
                    $Found.ResourceLocation   	| Should Be $Expected.ResourceLocation
                    $Found.ResourceName      	| Should Be $Expected.ResourceName
                    $Found.ResourceType  		| Should Be $Expected.ResourceType
                    $Found.ResourceURI  		| Should Be $Expected.ResourceURI
                    $Found.RoutePrefix  		| Should Be $Expected.RoutePrefix
                    $Found.RpRegistrationId  	| Should Be $Expected.RpRegistrationId
                }
            }
        }

        AfterEach {
            $global:Client = $null
        }


        it "TestListResourceHealths" -Skip:$('TestListResourceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestListResourceHealths'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {
                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {
                    $ResourceHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationName $serviceHealth.Name
                    foreach ($ResourceHealth in $ResourceHealths) {
                        ValidateResourceHealth -ResourceHealth $ResourceHealth
                    }
                }
            }
        }


        it "TestGetResourceHealth" -Skip:$('TestGetResourceHealth' -in $global:SkippedTests) {
            $global:TestName = 'TestGetResourceHealth'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {

                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {

                    $infraRoleHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationName $serviceHealth.Name
                    foreach ($infraRoleHealth in $infraRoleHealths) {

                        $retrieved = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationName $serviceHealth.Name -Name $infraRoleHealth.Name
                        AssertResourceHealthsAreSame -Expected $infraRoleHealth -Found $retrieved
                        break
                    }
                    break
                }
                break
            }
        }

        it "TestGetAllResourceHealths" -Skip:$('TestGetAllResourceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllResourceHealths'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {

                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {

                    $infraRoleHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationName $serviceHealth.Name
                    foreach ($infraRoleHealth in $infraRoleHealths) {

                        $retrieved = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationName $serviceHealth.Name -Name $infraRoleHealth.Name
                        AssertResourceHealthsAreSame -Expected $infraRoleHealth -Found $retrieved
                    }
                }
            }
        }

        it "TestGetAllResourceHealths" -Skip:$('TestGetAllResourceHealths' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllResourceHealths'

            $RegionHealths = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName
            foreach ($RegionHealth in $RegionHealths) {

                $ServiceHealths = Get-AzsRPHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
                foreach ($serviceHealth in $ServiceHealths) {

                    $infraRoleHealths = Get-AzsRegistrationHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name -ServiceRegistrationName $serviceHealth.Name
                    foreach ($infraRoleHealth in $infraRoleHealths) {

                        $infraRoleHealth | Should not be $null

                        $retrieved = $infraRoleHealth | Get-AzsRegistrationHealth
                        AssertResourceHealthsAreSame -Expected $infraRoleHealth -Found $retrieved
                    }
                }
            }
        }
    }
}
