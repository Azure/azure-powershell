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
function Test-StartStopManagedInstance
{
	$rg = Create-ResourceGroupForTest

	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedInstanceName = Get-ManagedInstanceName

 	try
 	{
		 $managedInstance = Create-ManagedInstanceForTest $rg

		 Stop-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName
		 Start-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName

		 $mi = Get-AzSqlInstance -Name $managedInstance.ManagedInstanceName -ResourceGroupName $rg.ResourceGroupName

		 $mi | Stop-AzSqlInstance
		 $mi | Start-AzSqlInstance
 	}
 	finally
 	{
		Remove-ResourceGroupForTest $rg
 	}
}
