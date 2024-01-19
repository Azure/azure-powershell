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
	Tests refresh external governance status
#>

function Test-RefreshSqlInstanceExternalGovernanceCmdlet ($location = "eastus2euap")
{
	#Test scenario
	try
	{
		Write-Debug "Creating test MI"
		$rg = Create-ResourceGroupForTest
		$managedInstance = Create-ManagedInstanceForTest $rg $null $null $true
		$managedInstanceName = $managedInstance.ManagedInstanceName
		
		$job = Invoke-AzSqlInstanceExternalGovernanceStatusRefresh -ResourceGroupName $rg -InstanceName $managedInstanceName
		
		$job | Wait-Job
		
		$result = $job.Output
		
		Assert-NotNull $result
		Assert-AreEqual $result.managedInstanceName $server
		Assert-AreEqual $result.status "Succeeded"
		Assert-AreEqual $result.type "Microsoft.Sql/locations/refreshExternalGovernanceStatusOperationResults"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
