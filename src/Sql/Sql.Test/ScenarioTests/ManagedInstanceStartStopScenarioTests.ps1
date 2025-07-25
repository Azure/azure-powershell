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
	Tests starting and stopping a managed instance
#>
function Test-ManualStartStopManagedInstance
{
	$rg = Create-ResourceGroupForTest

 	try
 	{
		 $managedInstance = Create-ManagedInstanceForTest $rg $null $null $true

		 Stop-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName -Force
		 Start-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName -Force

		 $mi = Get-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName

		 $mi | Stop-AzSqlInstance -Force
		 $mi | Start-AzSqlInstance -Force
 	}
 	finally
 	{
		Remove-ResourceGroupForTest $rg
 	}
}


<#
	.SYNOPSIS
	Tests scheduling starting and stopping a managed instance
#>
function Test-ScheduleStartStopManagedInstance
{
	$rg = Create-ResourceGroupForTest

 	try
 	{
		 $managedInstance = Create-ManagedInstanceForTest $rg $null $null $true
		 $managedInstanceName = $managedInstance.ManagedInstanceName

		 $scheduleItem = New-AzSqlInstanceScheduleItem -StartDay Monday -StartTime "04:00" -StopDay Friday -StopTime "14:00"

		 $managedInstanceSchedule = New-AzSqlInstanceStartStopSchedule `
				-InstanceName $managedInstanceName `
				-ResourceGroupName $rg.ResourceGroupName `
				-Description "powershell schedule" `
				-ScheduleList $scheduleItem `
				-TimeZone "Central Europe Standard Time" `
				-Force

		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StartDay $scheduleItem.StartDay
		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StartTime $scheduleItem.StartTime
		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StopDay $scheduleItem.StopDay
		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StopTime $scheduleItem.StopTime

		$managedInstanceSchedule = Get-AzSqlInstanceStartStopSchedule `
				-InstanceName $managedInstanceName `
				-ResourceGroupName $rg.ResourceGroupName

		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StartDay $scheduleItem.StartDay
		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StartTime $scheduleItem.StartTime
		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StopDay $scheduleItem.StopDay
		 Assert-AreEqual $managedInstanceSchedule.ScheduleList[0].StopTime $scheduleItem.StopTime

		Remove-AzSqlInstanceStartStopSchedule `
				-InstanceName $managedInstanceName `
				-ResourceGroupName $rg.ResourceGroupName `
				-Force

		Assert-Throws { Get-AzSqlInstanceStartStopSchedule -InstanceName $managedInstanceName -ResourceGroupName $rg.ResourceGroupName }
 	}
 	finally
 	{
		Remove-ResourceGroupForTest $rg
 	}
}
