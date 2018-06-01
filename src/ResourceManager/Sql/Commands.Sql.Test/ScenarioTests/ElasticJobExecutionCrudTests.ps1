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
	Tests starting a job with default parameters
#>
function Test-StartJob
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	# Setup SELECT 1 script on control db
	$script = "SELECT 1"
	$s1 = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
	$serverLogin = $s1.SqlAdministratorLogin
	$serverPassword = "t357ingP@s5w0rd!"
	$credential = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$jc1 = $a1 | New-AzureRmSqlElasticJobCredential -Name (Get-UserName) -Credential $credential
	$tg1 = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name (Get-TargetGroupName)
	$tg1 | Add-AzureRmSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName
	$j1 = Create-JobForTest $a1
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $script

	try
	{
		# Start job
		$je = Start-AzureRmSqlElasticJob -ResourceGroupName $j1.ResourceGroupName -ServerName $j1.ServerName -AgentName $j1.AgentName -JobName $j1.JobName
		$je = Start-AzureRmSqlElasticJob -JobObject $j1
		$je = Start-AzureRmSqlElasticJob -JobResourceId $j1.ResourceId
		$je = $j1 | Start-AzureRmSqlElasticJob

		Assert-AreEqual $je.ResourceGroupName $j1.ResourceGroupName
		Assert-AreEqual $je.ServerName $j1.ServerName
		Assert-AreEqual $je.AgentName $j1.AgentName
		Assert-AreEqual $je.JobName $j1.JobName
		Assert-NotNull $je.JobExecutionId
		Assert-AreEqual 1 $je.JobVersion
		Assert-AreEqual Created $je.Lifecycle
		Assert-AreEqual Created $je.ProvisioningState
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}

}

<#
	.SYNOPSIS
	Tests starting a job with default parameters
#>
function Test-StartJobWait
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	# Setup SELECT 1 script on control db
	$script = "SELECT 1"
	$s1 = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
	$serverLogin = $s1.SqlAdministratorLogin
	$serverPassword = "t357ingP@s5w0rd!"
	$credential = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$jc1 = $a1 | New-AzureRmSqlElasticJobCredential -Name (Get-UserName) -Credential $credential
	$tg1 = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name (Get-TargetGroupName)
	$tg1 | Add-AzureRmSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName
	$j1 = Create-JobForTest $a1
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $script

	try
	{
		# Start job - test wait
		$je = $j1 | Start-AzureRmSqlElasticJob -Wait

		Assert-AreEqual $je.ResourceGroupName $j1.ResourceGroupName
		Assert-AreEqual $je.ServerName $j1.ServerName
		Assert-AreEqual $je.AgentName $j1.AgentName
		Assert-AreEqual $je.JobName $j1.JobName
		Assert-NotNull $je.JobExecutionId
		Assert-AreEqual 1 $je.JobVersion
		Assert-AreEqual Succeeded $je.Lifecycle
		Assert-AreEqual Succeeded $je.ProvisioningState
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests stop job
#>
function Test-StopJob
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	$script = "WAITFOR DELAY '00:10:00'"
	$s1 = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
	$serverLogin = $s1.SqlAdministratorLogin
	$serverPassword = "t357ingP@s5w0rd!"
	$credential = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$jc1 = $a1 | New-AzureRmSqlElasticJobCredential -Name (Get-UserName) -Credential $credential
	$tg1 = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name (Get-TargetGroupName)
	$tg1 | Add-AzureRmSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName
	$j1 = Create-JobForTest $a1
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $script

	# Start
	$je = $j1 | Start-AzureRmSqlElasticJob

	try
	{
		# Stop
		$resp = Stop-AzureRmSqlElasticJob -ResourceGroupName $je.ResourceGroupName -ServerName $je.ServerName `
			-AgentName $je.AgentName -JobName $j1.JobName -JobExecutionId $je.JobExecutionId
		$resp = Stop-AzureRmSqlElasticJob -JobExecutionObject $je
		$resp = Stop-AzureRmSqlElasticJob -JobExecutionResourceId $je.ResourceId
		$resp = $je | Stop-AzureRmSqlElasticJob

		Assert-AreEqual $je.ResourceGroupName $j1.ResourceGroupName
		Assert-AreEqual $je.ServerName $j1.ServerName
		Assert-AreEqual $je.AgentName $j1.AgentName
		Assert-AreEqual $je.JobName $j1.JobName
		Assert-NotNull $je.JobExecutionId
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}

}

<#
	.SYNOPSIS
	Tests get job execution with agent object
#>
function Test-GetJobExecution
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	$script = "SELECT 1"
	$s1 = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
	$serverLogin = $s1.SqlAdministratorLogin
	$serverPassword = "t357ingP@s5w0rd!"
	$credential = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$jc1 = $a1 | New-AzureRmSqlElasticJobCredential -Name (Get-UserName) -Credential $credential
	$tg1 = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name (Get-TargetGroupName)
	$tg1 | Add-AzureRmSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName
	$j1 = Create-JobForTest $a1
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $script
	$je = $j1 | Start-AzureRmSqlElasticJob -Wait

	try
	{
		# Get with default param
		$allExecutions = Get-AzureRmSqlElasticJobExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName `
			-AgentName $a1.AgentName -Count 10
		$jobExecutions = Get-AzureRmSqlElasticJobExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName `
			-AgentName $a1.AgentName -JobName $j1.JobName -Count 10
		$jobExecution = Get-AzureRmSqlElasticJobExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName `
			-AgentName $a1.AgentName -JobName $j1.JobName -JobExecutionId $je.JobExecutionId

		# Test agent resource id
		$allExecutions = Get-AzureRmSqlElasticJobExecution -AgentObject $a1 -Count 10
		$jobExecutions = Get-AzureRmSqlElasticJobExecution -AgentObject $a1 -JobName $j1.JobName -Count 10
		$jobExecution = Get-AzureRmSqlElasticJobExecution -AgentObject $a1 -JobName $j1.JobName -JobExecutionId $je.JobExecutionId

		# Test agent resource id
		$allExecutions = Get-AzureRmSqlElasticJobExecution -AgentResourceId $a1.ResourceId -Count 10
		$jobExecutions = Get-AzureRmSqlElasticJobExecution -AgentResourceId $a1.ResourceId -JobName $j1.JobName -Count 10
		$jobExecution = Get-AzureRmSqlElasticJobExecution -AgentResourceId $a1.ResourceId -JobName $j1.JobName -JobExecutionId $je.JobExecutionId

		# Test piping
		$allExecutions = $a1 | Get-AzureRmSqlElasticJobExecution -Count 10
		$jobExecutions = $a1 | Get-AzureRmSqlElasticJobExecution -JobName $j1.JobName -Count 10
		$jobExecution = $a1 | Get-AzureRmSqlElasticJobExecution -JobName $j1.JobName -JobExecutionId $je.JobExecutionId

		# Test values from job execution model
		Assert-AreEqual $je.ResourceGroupName $jobExecution.ResourceGroupName
		Assert-AreEqual $je.ServerName $jobExecution.ServerName
		Assert-AreEqual $je.AgentName $jobExecution.AgentName
		Assert-AreEqual $je.JobName $jobExecution.JobName
		Assert-AreEqual $je.JobExecutionId $jobExecution.JobExecutionId
		Assert-AreEqual $je.Lifecycle $jobExecution.Lifecycle
		Assert-AreEqual $je.ProvisioningState $jobExecution.ProvisioningState
		Assert-AreEqual $je.LastMessage $jobExecution.LastMessage
		Assert-AreEqual $je.CurrentAttemptStartTime $jobExecution.CurrentAttemptStartTime
		Assert-AreEqual $je.StartTime $jobExecution.StartTime
		Assert-AreEqual $je.EndTime $jobExecution.EndTime
		Assert-AreEqual $je.JobVersion $jobExecution.JobVersion

		# There should be no active executions
		$allExecutions = $a1 | Get-AzureRmSqlElasticJobExecution -Count 10 -CreateTimeMin "2018-05-31T23:58:57" -CreateTimeMax "2018-07-31T23:58:57" -EndTimeMin "2018-06-30T23:58:57" -EndTimeMax "2018-07-31T23:58:57" -Active
		$jobExecutions = $a1 | Get-AzureRmSqlElasticJobExecution -Count 10 -CreateTimeMin "2018-05-31T23:58:57" -CreateTimeMax "2018-07-31T23:58:57" -EndTimeMin "2018-06-30T23:58:57" -EndTimeMax "2018-07-31T23:58:57" -Active
		Assert-Null $allExecutions
		Assert-Null $jobExecutions
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests get job step executions
#>
function Test-GetJobStepExecution
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	$script = "SELECT 1"
	$s1 = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
	$serverLogin = $s1.SqlAdministratorLogin
	$serverPassword = "t357ingP@s5w0rd!"
	$credential = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$jc1 = $a1 | New-AzureRmSqlElasticJobCredential -Name (Get-UserName) -Credential $credential
	$tg1 = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name (Get-TargetGroupName)
	$tg1 | Add-AzureRmSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName
	$j1 = Create-JobForTest $a1
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $script
	$je = $j1 | Start-AzureRmSqlElasticJob -Wait

	try
	{
		# Test job step execution default param
		$allStepExecutions = Get-AzureRmSqlElasticJobStepExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -JobName $j1.JobName -JobExecutionId $je.JobExecutionId
		$stepExecution = Get-AzureRmSqlElasticJobStepExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -JobName $j1.JobName -JobExecutionId $je.JobExecutionId -StepName $js1.StepName

		# Test job step job execution object
		$allStepExecutions = Get-AzureRmSqlElasticJobStepExecution -JobExecutionObject $je
		$stepExecution = Get-AzureRmSqlElasticJobStepExecution -JobExecutionObject $je -StepName $js1.StepName

		# Test job step job execution resource id
		$allStepExecutions = Get-AzureRmSqlElasticJobStepExecution -JobExecutionResourceId $je.ResourceId
		$stepExecution = Get-AzureRmSqlElasticJobStepExecution -JobExecutionResourceId $je.ResourceId -StepName $js1.StepName

		# Test job step execution piping
		$allStepExecutions = $je | Get-AzureRmSqlElasticJobStepExecution
		$stepExecution = $je | Get-AzureRmSqlElasticJobStepExecution -StepName $js1.StepName

		# Test values from job execution model
		Assert-AreEqual $stepExecution.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $stepExecution.ServerName $a1.ServerName
		Assert-AreEqual $stepExecution.AgentName $a1.AgentName
		Assert-AreEqual $stepExecution.JobName $j1.JobName
		Assert-NotNull  $stepExecution.JobExecutionId
		Assert-NotNull 	$stepExecution.StepName

		# Test filters
		$allStepExecutions = $je | Get-AzureRmSqlElasticJobStepExecution -CreateTimeMin "2018-05-31T23:58:57" `
			-CreateTimeMax "2018-07-31T23:58:57" -EndTimeMin "2018-06-30T23:58:57" -EndTimeMax "2018-07-31T23:58:57" -Active
		Assert-Null $allStepExecutions
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests get job target executions
#>
function Test-GetJobTargetExecution
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	$script = "SELECT 1"
	$s1 = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName
	$serverLogin = $s1.SqlAdministratorLogin
	$serverPassword = "t357ingP@s5w0rd!"
	$credential = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$jc1 = $a1 | New-AzureRmSqlElasticJobCredential -Name (Get-UserName) -Credential $credential
	$tg1 = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name (Get-TargetGroupName)
	$tg1 | Add-AzureRmSqlElasticJobTarget -ServerName $a1.ServerName -DatabaseName $a1.DatabaseName
	$j1 = Create-JobForTest $a1
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $script
	$je = $j1 | Start-AzureRmSqlElasticJob -Wait

	try
	{
		# Test job target execution default param
		$allTargetExecutions = Get-AzureRmSqlElasticJobTargetExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName `
			-AgentName $a1.AgentName -JobName $j1.JobName -JobExecutionId $je.JobExecutionId -Count 10
		$stepTargetExecutions = Get-AzureRmSqlElasticJobTargetExecution -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName `
			-AgentName $a1.AgentName -JobName $j1.JobName -JobExecutionId $je.JobExecutionId -StepName $js1.StepName -Count 10

		# Test job target job execution object
		$allTargetExecutions = Get-AzureRmSqlElasticJobTargetExecution -JobExecutionObject $je -Count 10
		$stepTargetExecutions = Get-AzureRmSqlElasticJobTargetExecution -JobExecutionObject $je -StepName $js1.StepName -Count 10

		# Test job target job execution resource id
		$allTargetExecutions = Get-AzureRmSqlElasticJobTargetExecution -JobExecutionResourceId $je.ResourceId -Count 10
		$stepTargetExecutions = Get-AzureRmSqlElasticJobTargetExecution -JobExecutionResourceId $je.ResourceId -StepName $js1.StepName -Count 10

		# Test job target execution piping
		$allTargetExecutions = $je | Get-AzureRmSqlElasticJobTargetExecution -Count 10
		$stepTargetExecutions = $je | Get-AzureRmSqlElasticJobTargetExecution -StepName $js1.StepName -Count 10

		$targetExecution = $stepTargetExecutions[0]

		# Test values from job target execution model
		Assert-AreEqual $targetExecution.ResourceGroupName $a1.ResourceGroupName
		Assert-AreEqual $targetExecution.ServerName $a1.ServerName
		Assert-AreEqual $targetExecution.AgentName $a1.AgentName
		Assert-AreEqual $targetExecution.JobName $j1.JobName
		Assert-NotNull  $targetExecution.JobExecutionId
		Assert-NotNull 	$targetExecution.StepName
		Assert-AreEqual $targetExecution.TargetServerName $a1.ServerName
		Assert-AreEqual $targetExecution.TargetDatabaseName $a1.DatabaseName

		# Test job target execution piping
		$allTargetExecutions = $je | Get-AzureRmSqlElasticJobTargetExecution -Count 10 -CreateTimeMin "2018-05-31T23:58:57" -CreateTimeMax "2018-07-31T23:58:57" -EndTimeMin "2018-06-30T23:58:57" -EndTimeMax "2018-07-31T23:58:57" -Active
		$stepTargetExecutions = $je | Get-AzureRmSqlElasticJobTargetExecution -StepName $js1.StepName -Count 10 -CreateTimeMin "2018-05-31T23:58:57" -CreateTimeMax "2018-07-31T23:58:57" -EndTimeMin "2018-06-30T23:58:57" -EndTimeMax "2018-07-31T23:58:57" -Active
		Assert-Null $allTargetExecutions
		Assert-Null $stepTargetExecutions
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}