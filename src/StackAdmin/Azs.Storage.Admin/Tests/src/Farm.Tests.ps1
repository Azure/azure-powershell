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
    Run AzureStack Farm admin tests

.DESCRIPTION
    Run AzureStack Farm admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\Farm.Tests.ps1
    Describing Farm
	  [+] TestGetFarm 3.79s
	  [+] TestListFarms 1.03s
	  [+] TestListAllFarmMetricDefinitions 1.25s
	  [+] TestListAllFarmMetrics 1.78s
	  [+] TestForAllFarmsStartGarbageCollection 31.68s
.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 20, 2018
#>
param(
	[bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)
$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Storage.Admin {

	Describe "Farm" -Tags @('Farm', 'Azs.Storage.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateFarm {
				param(
					[Parameter(Mandatory=$true)]
					$farm
				)
				# Resource
				$farm														| Should Not Be $null

				# Validate Farm properties
				$farm.BandwidthThrottleIsEnabled							| Should Not Be $null
				$farm.CorsAllowedOriginsList								| Should Not Be $null
				$farm.DataCenterUriHostSuffixes								| Should Not Be $null
				$farm.DefaultEgressThresholdInGbps							| Should Not Be $null
				$farm.DefaultIngressThresholdInGbps							| Should Not Be $null
				$farm.DefaultIntranetEgressThresholdInGbps					| Should Not Be $null
				$farm.DefaultIntranetIngressThresholdInGbps					| Should Not Be $null
				$farm.DefaultRequestThresholdInTps							| Should Not Be $null
				$farm.DefaultThrottleProbabilityDecayIntervalInSeconds		| Should Not Be $null
				$farm.DefaultTotalEgressThresholdInGbps						| Should Not Be $null
				$farm.DefaultTotalIngressThresholdInGbps					| Should Not Be $null
				$farm.FeedbackRefreshIntervalInSeconds						| Should Not Be $null
				$farm.GracePeriodForFullThrottlingInRefreshIntervals		| Should Not Be $null
				$farm.GracePeriodMaxThrottleProbability						| Should Not Be $null
				$farm.HostStyleHttpPort										| Should Not Be $null
				$farm.HostStyleHttpsPort									| Should Not Be $null
				$farm.MinimumEgressThresholdInGbps							| Should Not Be $null
				$farm.MinimumIngressThresholdInGbps							| Should Not Be $null
				$farm.MinimumIntranetEgressThresholdInGbps					| Should Not Be $null
				$farm.MinimumIntranetIngressThresholdInGbps					| Should Not Be $null
				$farm.MinimumRequestThresholdInTps							| Should Not Be $null
				$farm.MinimumTotalEgressThresholdInGbps						| Should Not Be $null
				$farm.MinimumTotalIngressThresholdInGbps					| Should Not Be $null
				$farm.NumberOfAccountsToSync								| Should Not Be $null
				$farm.OverallEgressThresholdInGbps							| Should Not Be $null
				$farm.OverallIngressThresholdInGbps							| Should Not Be $null
				$farm.OverallIntranetEgressThresholdInGbps					| Should Not Be $null
				$farm.OverallIntranetIngressThresholdInGbps					| Should Not Be $null
				$farm.OverallRequestThresholdInTps							| Should Not Be $null
				$farm.OverallTotalEgressThresholdInGbps						| Should Not Be $null
				$farm.OverallTotalIngressThresholdInGbps					| Should Not Be $null
				$farm.OverallIntranetEgressThresholdInGbps					| Should Not Be $null
				$farm.RetentionPeriodForDeletedStorageAccountsInDays		| Should Not Be $null
				$farm.SettingsPollingIntervalInSecond						| Should Not Be $null
				$farm.SettingsStore											| Should Not Be $null
				$farm.ToleranceFactorForEgress								| Should Not Be $null
				$farm.ToleranceFactorForIngress								| Should Not Be $null
				$farm.ToleranceFactorForIntranetEgress						| Should Not Be $null
				$farm.ToleranceFactorForIntranetIngress						| Should Not Be $null
				$farm.ToleranceFactorForTotalEgress							| Should Not Be $null
				$farm.ToleranceFactorForTotalIngress						| Should Not Be $null
				$farm.ToleranceFactorForTps									| Should Not Be $null
				$farm.UsageCollectionIntervalInSeconds						| Should Not Be $null
				$farm.Location												| Should Not Be $null
				$farm.Id													| Should Not Be $null
				$farm.Name													| Should Not Be $null
				$farm.Type													| Should Not Be $null
			}

			function AssertAreEqual {
				param(
					[Parameter(Mandatory=$true)]
					$expected,
					[Parameter(Mandatory=$true)]
					$found
				)
				# Resource
				if($expected -eq $null){
					$found												    | Should Be $null
				}
				else{
					$found												    | Should Not Be $null
					# Validate Farm properties
					$expected.BandwidthThrottleIsEnabled | Should Be $found.BandwidthThrottleIsEnabled
					$expected.CorsAllowedOriginsList | Should Be $found.CorsAllowedOriginsList
					$expected.DataCenterUriHostSuffixes | Should Be $found.DataCenterUriHostSuffixes
					$expected.DefaultEgressThresholdInGbps | Should Be $found.DefaultEgressThresholdInGbps
					$expected.DefaultIngressThresholdInGbps | Should Be $found.DefaultIngressThresholdInGbps
					$expected.DefaultIntranetEgressThresholdInGbps | Should Be $found.DefaultIntranetEgressThresholdInGbps
					$expected.DefaultIntranetIngressThresholdInGbps | Should Be $found.DefaultIntranetIngressThresholdInGbps
					$expected.DefaultRequestThresholdInTps | Should Be $found.DefaultRequestThresholdInTps
					$expected.DefaultThrottleProbabilityDecayIntervalInSeconds | Should Be $found.DefaultThrottleProbabilityDecayIntervalInSeconds
					$expected.DefaultTotalEgressThresholdInGbps | Should Be $found.DefaultTotalEgressThresholdInGbps
					$expected.DefaultTotalIngressThresholdInGbps | Should Be $found.DefaultTotalIngressThresholdInGbps
					$expected.FeedbackRefreshIntervalInSeconds | Should Be $found.FeedbackRefreshIntervalInSeconds
					$expected.GracePeriodForFullThrottlingInRefreshIntervals | Should Be $found.GracePeriodForFullThrottlingInRefreshIntervals
					$expected.GracePeriodMaxThrottleProbability | Should Be $found.GracePeriodMaxThrottleProbability
					$expected.HostStyleHttpPort | Should Be $found.HostStyleHttpPort
					$expected.HostStyleHttpsPort | Should Be $found.HostStyleHttpsPort
					$expected.Id | Should Be $found.Id
					$expected.Location | Should Be $found.Location
					$expected.MinimumEgressThresholdInGbps | Should Be $found.MinimumEgressThresholdInGbps
					$expected.MinimumIngressThresholdInGbps | Should Be $found.MinimumIngressThresholdInGbps
					$expected.MinimumIntranetEgressThresholdInGbps | Should Be $found.MinimumIntranetEgressThresholdInGbps
					$expected.MinimumIntranetIngressThresholdInGbps | Should Be $found.MinimumIntranetIngressThresholdInGbps
					$expected.MinimumRequestThresholdInTps | Should Be $found.MinimumRequestThresholdInTps
					$expected.MinimumTotalEgressThresholdInGbps | Should Be $found.MinimumTotalEgressThresholdInGbps
					$expected.MinimumTotalIngressThresholdInGbps | Should Be $found.MinimumTotalIngressThresholdInGbps
					$expected.Name | Should Be $found.Name
					$expected.NumberOfAccountsToSync | Should Be $found.NumberOfAccountsToSync
					$expected.OverallEgressThresholdInGbps | Should Be $found.OverallEgressThresholdInGbps
					$expected.OverallIngressThresholdInGbps | Should Be $found.OverallIngressThresholdInGbps
					$expected.OverallIntranetEgressThresholdInGbps | Should Be $found.OverallIntranetEgressThresholdInGbps
					$expected.OverallIntranetIngressThresholdInGbps | Should Be $found.OverallIntranetIngressThresholdInGbps
					$expected.OverallRequestThresholdInTps | Should Be $found.OverallRequestThresholdInTps
					$expected.OverallTotalEgressThresholdInGbps | Should Be $found.OverallTotalEgressThresholdInGbps
					$expected.OverallTotalIngressThresholdInGbps | Should Be $found.OverallTotalIngressThresholdInGbps
					$expected.OverallIntranetEgressThresholdInGbps | Should Be $found.OverallIntranetEgressThresholdInGbps
					$expected.RetentionPeriodForDeletedStorageAccountsInDays | Should Be $found.RetentionPeriodForDeletedStorageAccountsInDays
					$expected.SettingsPollingIntervalInSecond | Should Be $found.SettingsPollingIntervalInSecond
					$expected.SettingsStore | Should Be $found.SettingsStore
				}
			}
		}

		It "TestGetFarm" {
			$global:TestName = 'TestGetFarm'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				$result = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup -Name (Select-Name $farm.Name)
				$result  | Should Not Be $null
				ValidateFarm -Farm $result
				AssertAreEqual -expected $farm -found $result
			}
		}

		It "TestListFarms" {
			$global:TestName = 'TestListFarms'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				ValidateFarm -Farm $farm
			}
		}

		It "TestListAllFarmMetricDefinitions" {
			$global:TestName = 'TestListAllFarmMetricDefinitions'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				$result = Get-AzsStorageFarmMetricDefinition -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name)
				$result  | Should Not Be $null
			}
		}

		It "TestListAllFarmMetrics" {
			$global:TestName = 'TestListAllFarmMetrics'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				$result = Get-AzsStorageFarmMetric -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name)
				$result  | Should Not Be $null
			}
		}

		# Record new tests
		It "TestForAllFarmsStartGarbageCollection" -Skip {
			$global:TestName = 'TestForAllFarmsStartGarbageCollection'

			$farms =  Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroup
			foreach($farm in $farms) {
				Start-AzsReclaimStorageCapacity -ResourceGroupName $global:ResourceGroup -FarmName (Select-Name $farm.Name) -Force
			}
		}
	}
}
