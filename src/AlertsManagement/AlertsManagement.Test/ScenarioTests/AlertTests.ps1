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
Test Alerts Operations
#>
function Test-AlertChangeState
{
	# Get latest alert
	$alerts = Get-AzAlert -State "New" -TimeRange 1h
	$alert = $alerts[0]

	$oldState = $alert.State
	$newState = "Closed"
	$updatedAlert = Update-AzAlertState -AlertId $alert.Id -State $newState
	Assert-AreEqual $newState $updatedAlert.State

	# Revert the state change operation
	$alert = Update-AzAlertState -AlertId $alert.Id -State $oldState
}

function Test-AlertsSummary
{
	$summary = Measure-AzAlertStatistic -GroupBy "severity,alertstate"

	Assert-AreEqual "severity" $summary.GroupBy
	Assert-NotNull $summary.TotalAlerts

	ForEach ($item in $summary.AggregatedCounts.Content){
		Assert-AreEqual "alertState" $item.GroupedBy
		Assert-NotNull $item.Count
	}
} 

function Test-GetAlertsFilteredByParameters
{
	$severityFilter = "Sev3"
	$monitorServiceFilter = "Platform"
	$alerts = Get-AzAlert -Severity $severityFilter -MonitorService $monitorServiceFilter
	ForEach ($alert in $alerts){
		Assert-AreEqual $severityFilter $alert.Severity
		Assert-AreEqual $monitorServiceFilter $alert.MonitorService
	}
}