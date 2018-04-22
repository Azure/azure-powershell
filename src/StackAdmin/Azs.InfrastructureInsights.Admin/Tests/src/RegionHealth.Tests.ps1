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
    PS C:\> .\src\RegionHealth.Tests.ps1
	Describing RegionHealths
	[+] TestListRegionHealths 182ms
	[+] TestGetRegionHealth 112ms
	[+] TestGetAllRegionHealths 113ms

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
$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.InfrastructureInsights.Admin {

	Describe "RegionHealths" -Tags @('RegionHealth', 'InfrastructureInsightsAdmin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateMetrics{
				param(
					$Metrics
				)
				$Metrics        | Should not be $null
				$Metrics.Name   | Should not be $null
				$Metrics.Unit   | Should not be $null
				$Metrics.Value  | Should not be $null
			}

			function ValidateUsageMetrics {
				param(
				$UsageMetrics
				)
				$UsageMetrics               | Should not be $null
				$UsageMetrics.MetricsValue  | Should not be $null
				$UsageMetrics.Name          | Should not be $null

				foreach($metrics in $UsageMetrics.MetricsValue) {
					ValidateMetrics $metrics
				}
			}

			function ValidateRegionHealth {
				param(
					[Parameter(Mandatory=$true)]
					$RegionHealth
				)

				$RegionHealth          | Should Not Be $null

				# Resource
				$RegionHealth.Id       | Should Not Be $null
				$RegionHealth.Location | Should Not Be $null
				$RegionHealth.Name     | Should Not Be $null
				$RegionHealth.Type     | Should Not Be $null

				# Region Health
				$RegionHealth.AlertSummary                     | Should Not Be $null
				$RegionHealth.AlertSummary.CriticalAlertCount  | Should Not Be $null
				$RegionHealth.AlertSummary.WarningAlertCount   | Should Not Be $null

				$RegionHealth.AlertSummary.CriticalAlertCount  | Should BeGreaterThan -1
				$RegionHealth.AlertSummary.WarningAlertCount   | Should BeGreaterThan -1

				foreach($usageMetrics in $RegionHealth.UsageMetrics) {
					ValidateUsageMetrics $usageMetrics
				}
			}

			function AssertRegionHealthsAreSame {
				param(
					[Parameter(Mandatory=$true)]
					$Expected,

					[Parameter(Mandatory=$true)]
					$Found
				)
				if($Expected -eq $null) {
					$Found | Should Be $null
				} else {
					$Found                  | Should Not Be $null

					# Resource
					$Found.Id               | Should Be $Expected.Id
					$Found.Location         | Should Be $Expected.Location
					$Found.Name             | Should Be $Expected.Name
					$Found.Type             | Should Be $Expected.Type

					# Region Health
					$Found.AlertSummary.CriticalAlertCount  | Should Be $Expected.AlertSummary.CriticalAlertCount
					$Found.AlertSummary.WarningAlertCount   | Should Be $Expected.AlertSummary.WarningAlertCount



				}
			}
		}


		It "TestListRegionHealths" {
			$global:TestName = 'TestListRegionHealths'

			$RegionHealths = Get-AzsRegionHealth -ResourceGroupName $ResourceGroupName
			$RegionHealths | Should Not Be $null
			foreach($RegionHealth in $RegionHealths) {
				ValidateRegionHealth -Region $RegionHealth
			}
	    }


		It "TestGetRegionHealth" {
            $global:TestName = 'TestGetRegionHealth'

			$RegionHealths = Get-AzsRegionHealth -ResourceGroupName $ResourceGroupName
			foreach($RegionHealth in $RegionHealths) {
				$regionName = Extract-Name -Name $RegionHealth.Name

				$retrieved = Get-AzsRegionHealth -ResourceGroupName $ResourceGroupName -Location $regionName
				AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
				return
			}
		}

		It "TestGetAllRegionHealths" {
			$global:TestName = 'TestGetAllRegionHealths'


			$RegionHealths = Get-AzsRegionHealth -ResourceGroupName $ResourceGroupName
			foreach($RegionHealth in $RegionHealths) {
				$regionName = Extract-Name -Name $RegionHealth.Name

				$retrieved = Get-AzsRegionHealth -ResourceGroupName $ResourceGroupName -Location $regionName
				AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
			}
		}

		It "TestRegionHealthsPipeline" {
			$global:TestName = 'TestGetAllRegionHealths'


			$RegionHealths = Get-AzsRegionHealth -ResourceGroupName $ResourceGroupName
			foreach($RegionHealth in $RegionHealths) {

				$retrieved = $RegionHealth | Get-AzsRegionHealth
				AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
			}
		}

    }
}
