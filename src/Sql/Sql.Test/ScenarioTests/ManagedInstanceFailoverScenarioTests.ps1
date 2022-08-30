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

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"

<#
.SYNOPSIS
Tests Managed Instance failover.
#>
function Test-FailoverManagedInstance
{
	try
	{
		# Setup
		$rg = Create-ResourceGroupForTest

		# Initiate sync create of managed instance.
		$managedInstance1Job = Create-ManagedInstanceForTestAsJob $rg
		$managedInstance2Job = Create-ManagedInstanceForTestAsJob $rg

		$managedInstance = Create-ManagedInstanceForTest $rg
		
		# Wait for first full backup
		Wait-Seconds 300
		$job = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -AsJob
		$job | Wait-Job

		try
		{
			Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -AsJob
		}
		catch
		{
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover on the managed instance")
		}

		$managedInstance1Job | Wait-Job
		$managedInstance1 = $managedInstance1Job.Output

		# PassThru #
		############

		# Wait for first full backup
		Wait-Seconds 120
		$output = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -PassThru
		Assert-True { $output }

		$managedInstance2Job | Wait-Job
		$managedInstance2 = $managedInstance2Job.Output

		# Piping #
		##########

		# Wait for first full backup
		Wait-Seconds 60
		Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance2.ManagedInstanceName | Invoke-AzSqlInstanceFailover
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
