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

function Test-ManagedDatabaseMoveByNameParameterSet
{
	#$rg = Create-ResourceGroupForTest
	$defaultParams = Get-DefaultManagedInstanceParameters
	$managedDatabaseName = Get-ManagedDatabaseName
	$collation = "SQL_Latin1_General_CP1_CI_AS"

	try
	{
		#$managedInstanceSourceJob = Create-ManagedInstanceForTestAsJob $rg
		#$managedInstanceTargetJob = Create-ManagedInstanceForTestAsJob $rg
		#
		#$managedInstanceSourceJob | Wait-Job
		#$managedInstanceSource = $managedInstanceSourceJob.Output
		#
		#$managedInstanceTargetJob | Wait-Job
		#$managedInstanceTarget = $managedInstanceTargetJob.Output

		$rg = Get-AzResourceGroup -Name "customerexperienceteam_rg" -Location "westcentralus"
		$managedInstanceSource = Get-AzSqlInstance -Name "source-mi" -ResourceGroupName ToMove
		$managedInstanceTarget = Get-AzSqlInstance -Name brka0190 -ResourceGroupName "customerexperienceteam_rg"

		$rgName = $rg.ResourceGroupName
		$managedInstance = $managedInstanceSource.ManagedInstanceName
		$managedDatabase = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstanceSource.ManagedInstanceName -Name $managedDatabaseName -Collation $collation
		
		Start-TestSleep -Seconds 300

		Move-AzSqlInstanceDatabase `
			-ResourceGroupName $rg.ResourceGroupName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName `
			-TargetInstanceName $managedInstanceTarget.ManagedInstanceName
			-TargetResourceGroupName "customerexperienceteam_rg"

		$moveOperation = Get-AzSqlInstanceDatabaseMoveOperation `
			-ResourceGroupName $rg.ResourceGroupName `
			-InstanceName $managedInstanceSource.ManagedInstanceName `
			-Name $managedDatabaseName

		Assert-NotNull $moveOperation
		Assert-AreEqual $moveOperation.TargetManagedInstanceName $managedInstanceTarget.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceManagedInstanceName $managedInstanceSource.ManagedInstanceName
		Assert-AreEqual $moveOperation.SourceDatabaseName $managedDatabaseName
		Assert-AreEqual $moveOperation.OperationMode "Move"


	}
	finally
	{
		#Remove-ResourceGroupForTest $rg
	}
}