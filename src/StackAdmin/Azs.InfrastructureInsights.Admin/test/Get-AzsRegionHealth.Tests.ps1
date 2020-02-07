$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsRegionHealth.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

InModuleScope Azs.InfrastructureInsights.Admin {

	Describe "RegionHealths" -Tags @('RegionHealth', 'InfrastructureInsightsAdmin') {

        #. $PSScriptRoot\Common.ps1

		BeforeEach  {

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
				$RegionHealth.AlertSummaryCriticalAlertCount  | Should Not Be $null
				$RegionHealth.AlertSummaryWarningAlertCount   | Should Not Be $null

				$RegionHealth.AlertSummaryCriticalAlertCount  | Should BeGreaterThan -1
				$RegionHealth.AlertSummaryWarningAlertCount   | Should BeGreaterThan -1

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

		it "TestListRegionHealths" -Skip:$('TestListRegionHealths' -in $global:SkippedTests) {
			$global:TestName = 'TestListRegionHealths'

			$RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
			$RegionHealths | Should Not Be $null
			foreach($RegionHealth in $RegionHealths) {
				ValidateRegionHealth -Region $RegionHealth
			}
	    }


		it "TestGetRegionHealth" -Skip:$('TestGetRegionHealth' -in $global:SkippedTests) {
            $global:TestName = 'TestGetRegionHealth'

			$RegionHealths = Get-AzsRegionHealth -Location $global:Location  -ResourceGroupName $global:ResourceGroupName
			foreach($RegionHealth in $RegionHealths) {
				$retrieved = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
				AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
				return
			}
		}

		it "TestGetAllRegionHealths" -Skip:$('TestGetAllRegionHealths' -in $global:SkippedTests) {
			$global:TestName = 'TestGetAllRegionHealths'

			$RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
			foreach($RegionHealth in $RegionHealths) {
				$retrieved = Get-AzsRegionHealth -ResourceGroupName $global:ResourceGroupName -Location $RegionHealth.Name
				AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
			}
		}

		it "TestGetAllRegionHealths" -Skip:$('TestGetAllRegionHealths' -in $global:SkippedTests) {
			$global:TestName = 'TestGetAllRegionHealths'


			$RegionHealths = Get-AzsRegionHealth -Location $global:Location -ResourceGroupName $global:ResourceGroupName
			foreach($RegionHealth in $RegionHealths) {

				$retrieved = $RegionHealth | Get-AzsRegionHealth
				AssertRegionHealthsAreSame -Expected $RegionHealth -Found $retrieved
			}
		}

    }
}