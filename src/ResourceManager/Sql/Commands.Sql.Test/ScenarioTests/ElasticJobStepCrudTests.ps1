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
	Tests creating a job step
#>
function Test-CreateJobStep
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-CreateJobStepWithDefaultParam $a1
		Test-CreateJobStepWithJobObject $a1
		Test-CreateJobStepWithJobResourceId $a1
	  Test-CreateJobStepWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests getting a job step
#>
function Test-GetJobStep
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-GetJobStepWithDefaultParam $a1
		Test-GetJobStepWithJobObject $a1
		Test-GetJobStepWithJobResourceId $a1
	  Test-GetJobStepWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests updating a job step
#>
function Test-UpdateJobStep
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-UpdateJobStepWithDefaultParam $a1
		Test-UpdateJobStepWithInputObject $a1
		Test-UpdateJobStepWithResourceId $a1
	  Test-UpdateJobStepWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests removing a job step
#>
function Test-RemoveJobStep
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-RemoveJobStepWithDefaultParam $a1
		Test-RemoveJobStepWithInputObject $a1
		Test-RemoveJobStepWithResourceId $a1
	  Test-RemoveJobStepWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests creating a job step with default param
#>
function Test-CreateJobStepWithDefaultParam ($a1)
{
	# Setup
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$schemaName = Get-SchemaName
	$tableName = Get-TableName

	# Test add job step using min params
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -JobName $j1.JobName -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.CommandText $ct1
	Assert-Null $js1.Output

	# Test add job step using max params - output database object
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -JobName $j1.JobName -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseObject $db1 -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName

	# Test add job step using max params - output database resource id
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -JobName $j1.JobName -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseResourceId $db1.ResourceId -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName
}

<#
	.SYNOPSIS
	Tests creating a job step with job object
#>
function Test-CreateJobStepWithJobObject ($a1)
{
	# Setup
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$schemaName = Get-SchemaName
	$tableName = Get-TableName

	# Test add job step using min params
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -JobObject $j1 -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.CommandText $ct1
	Assert-Null $js1.Output

	# Test add job step using max params - output database object
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -JobObject $j1 -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseObject $db1 -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName

	# Test add job step using max params - output database resource id
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -JobObject $j1 -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseResourceId $db1.ResourceId -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName
}

<#
	.SYNOPSIS
	Tests creating a job step with job resource id
#>
function Test-CreateJobStepWithJobResourceId ($a1)
{
	# Setup
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$schemaName = Get-SchemaName
	$tableName = Get-TableName

	# Test add job step using min params
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -JobResourceId $j1.ResourceId -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.CommandText $ct1
	Assert-Null $js1.Output

	# Test add job step using max params - output database object
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -JobResourceId $j1.ResourceId -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseObject $db1 -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName

	# Test add job step using max params - output database resource id
	$jsn1 = Get-JobStepName
	$js1 = Add-AzureRmSqlElasticJobStep -JobResourceId $j1.ResourceId -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseResourceId $db1.ResourceId -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName
}

<#
	.SYNOPSIS
	Tests creating a job step with piping
#>
function Test-CreateJobStepWithPiping ($a1)
{
	# Setup
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$schemaName = Get-SchemaName
	$tableName = Get-TableName

	# Test add job step using min params
	$jsn1 = Get-JobStepName
	$js1 = $j1 | Add-AzureRmSqlElasticJobStep -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.CommandText $ct1
	Assert-Null $js1.Output

	# Test add job step using max params - output database object
	$jsn1 = Get-JobStepName
	$js1 = $j1 | Add-AzureRmSqlElasticJobStep -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseObject $db1 -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName

	# Test add job step using max params - output database resource id
	$jsn1 = Get-JobStepName
	$js1 = $j1 | Add-AzureRmSqlElasticJobStep -Name $jsn1 -TargetGroupName $tg1.TargetGroupName -CredentialName $jc1.CredentialName -CommandText $ct1 -TimeoutSeconds 1000 -RetryAttempts 100 -InitialRetryIntervalSeconds 10 -MaximumRetryIntervalSeconds 1000 -RetryIntervalBackoffMultiplier 5.0 -OutputDatabaseResourceId $db1.ResourceId -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName -OutputSchemaName $schemaName
	Assert-AreEqual $js1.ResourceGroupName $a1.ResourceGroupName
	Assert-AreEqual $js1.ServerName $a1.ServerName
	Assert-AreEqual $js1.AgentName $a1.AgentName
	Assert-AreEqual $js1.JobName $j1.JobName
	Assert-AreEqual $js1.StepName $jsn1
	Assert-AreEqual $js1.TargetGroupName $tg1.TargetGroupName
	Assert-AreEqual $js1.CredentialName $jc1.CredentialName
	Assert-AreEqual $js1.ExecutionOptions.TimeoutSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryAttempts 100
	Assert-AreEqual $js1.ExecutionOptions.InitialRetryIntervalSeconds 10
	Assert-AreEqual $js1.ExecutionOptions.MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $js1.ExecutionOptions.RetryIntervalBackoffMultiplier 5.0
	Assert-AreEqual $js1.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $js1.Output.ServerName $db1.ServerName
	Assert-AreEqual $js1.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $js1.Output.SchemaName $schemaName
	Assert-AreEqual $js1.Output.TableName $tableName
	Assert-AreEqual $js1.Output.Credential $jc1.CredentialName
}

<#
	.SYNOPSIS
	Tests updating a job step with default param
#>
function Test-UpdateJobStepWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$tg2 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$ct2 = "SELECT 2"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$schemaName = "schema1"
	$schemaName2 = "schema2"
	$tableName = "table1"
	$tableName2 = "table2"

	# Test update step's target group
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -TargetGroupName $tg2.TargetGroupName
	Assert-AreEqual $resp.TargetGroupName $tg2.TargetGroupName

	# Test update step's credential
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -CredentialName $jc2.CredentialName
	Assert-AreEqual $resp.CredentialName $jc2.CredentialName

	# Test update step's command text
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -CommandText $ct2
	Assert-AreEqual $resp.CommandText $ct2

	# Test add output using output database object
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -OutputDatabaseObject $db1 -OutputSchemaName $schemaName -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output target using output database resource id
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -OutputDatabaseResourceId $db1.ResourceId
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output schema name
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -OutputSchemaName $schemaName2
	Assert-AreEqual $resp.Output.SchemaName $schemaName2

	# Test update output table name
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -OutputTableName $tableName2
	Assert-AreEqual $resp.Output.TableName $tableName2

	# Test update output credential name
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -OutputCredentialName $jc2.CredentialName
	Assert-AreEqual $resp.Output.Credential $jc2.CredentialName

	# Test update job step remove output
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -RemoveOutput
	Assert-Null $resp.Output

	# Test update execution option timeout seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -TimeoutSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.TimeoutSeconds 100

	# Test update execution option retry attempts
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -RetryAttempts 1000
	Assert-AreEqual $resp.ExecutionOptions.RetryAttempts 1000

	# Test update execution option initial retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -InitialRetryIntervalSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.InitialRetryIntervalSeconds 100

	# Test update execution option maximum retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $resp.ExecutionOptions.MaximumRetryIntervalSeconds 1000

	# Test update execution option maximum retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName -RetryIntervalBackoffMultiplier 5.2
	Assert-AreEqual $resp.ExecutionOptions.RetryIntervalBackoffMultiplier 5.2
}

<#
	.SYNOPSIS
	Tests updating a job step with input object
#>
function Test-UpdateJobStepWithInputObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$tg2 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$ct2 = "SELECT 2"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$schemaName = "schema1"
	$schemaName2 = "schema2"
	$tableName = "table1"
	$tableName2 = "table2"

	# Test update step's target group
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -TargetGroupName $tg2.TargetGroupName
	Assert-AreEqual $resp.TargetGroupName $tg2.TargetGroupName

	# Test update step's credential
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -CredentialName $jc2.CredentialName
	Assert-AreEqual $resp.CredentialName $jc2.CredentialName

	# Test update step's command text
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -CommandText $ct2
	Assert-AreEqual $resp.CommandText $ct2

	# Test add output using output database object
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -OutputDatabaseObject $db1 -OutputSchemaName $schemaName -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output target using output database resource id
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -OutputDatabaseResourceId $db1.ResourceId
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName

	# Test update output schema name
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -OutputSchemaName $schemaName2
	Assert-AreEqual $resp.Output.SchemaName $schemaName2

	# Test update output table name
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -OutputTableName $tableName2
	Assert-AreEqual $resp.Output.TableName $tableName2

	# Test update output credential name
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -OutputCredentialName $jc2.CredentialName
	Assert-AreEqual $resp.Output.Credential $jc2.CredentialName

	# Test update job step remove output
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -RemoveOutput
	Assert-Null $resp.Output

	# Test update execution option timeout seconds
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -TimeoutSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.TimeoutSeconds 100

	# Test update execution option retry attempts
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -RetryAttempts 1000
	Assert-AreEqual $resp.ExecutionOptions.RetryAttempts 1000

	# Test update execution option initial retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -InitialRetryIntervalSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.InitialRetryIntervalSeconds 100

	# Test update execution option maximum retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $resp.ExecutionOptions.MaximumRetryIntervalSeconds 1000

	# Test update execution option maximum retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -InputObject $js1 -RetryIntervalBackoffMultiplier 5.2
	Assert-AreEqual $resp.ExecutionOptions.RetryIntervalBackoffMultiplier 5.2
}

<#
	.SYNOPSIS
	Tests updating a job step with resource id
#>
function Test-UpdateJobStepWithResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$tg2 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$ct2 = "SELECT 2"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$schemaName = "schema1"
	$schemaName2 = "schema2"
	$tableName = "table1"
	$tableName2 = "table2"

	# Test update step's target group
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -TargetGroupName $tg2.TargetGroupName
	Assert-AreEqual $resp.TargetGroupName $tg2.TargetGroupName

	# Test update step's credential
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -CredentialName $jc2.CredentialName
	Assert-AreEqual $resp.CredentialName $jc2.CredentialName

	# Test update step's command text
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -CommandText $ct2
	Assert-AreEqual $resp.CommandText $ct2

	# Test add output using output database object
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -OutputDatabaseObject $db1 -OutputSchemaName $schemaName -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output target using output database resource id
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -OutputDatabaseResourceId $db1.ResourceId
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output schema name
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -OutputSchemaName $schemaName2
	Assert-AreEqual $resp.Output.SchemaName $schemaName2

	# Test update output table name
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -OutputTableName $tableName2
	Assert-AreEqual $resp.Output.TableName $tableName2

	# Test update output credential name
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -OutputCredentialName $jc2.CredentialName
	Assert-AreEqual $resp.Output.Credential $jc2.CredentialName

	# Test update job step remove output
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -RemoveOutput
	Assert-Null $resp.Output

	# Test update execution option timeout seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -TimeoutSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.TimeoutSeconds 100

	# Test update execution option retry attempts
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -RetryAttempts 1000
	Assert-AreEqual $resp.ExecutionOptions.RetryAttempts 1000

	# Test update execution option initial retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -InitialRetryIntervalSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.InitialRetryIntervalSeconds 100

	# Test update execution option maximum retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $resp.ExecutionOptions.MaximumRetryIntervalSeconds 1000

	# Test update execution option maximum retry interval seconds
	$resp = Set-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId -RetryIntervalBackoffMultiplier 5.2
	Assert-AreEqual $resp.ExecutionOptions.RetryIntervalBackoffMultiplier 5.2
}

<#
	.SYNOPSIS
	Tests updating a job step with piping
#>
function Test-UpdateJobStepWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$jc2 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$tg2 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$ct2 = "SELECT 2"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	$db1 = $a1 | Get-AzureRmSqlDatabase
	$schemaName = "schema1"
	$schemaName2 = "schema2"
	$tableName = "table1"
	$tableName2 = "table2"

	# Test update step's target group
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -TargetGroupName $tg2.TargetGroupName
	Assert-AreEqual $resp.TargetGroupName $tg2.TargetGroupName

	# Test update step's credential
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -CredentialName $jc2.CredentialName
	Assert-AreEqual $resp.CredentialName $jc2.CredentialName

	# Test update step's command text
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -CommandText $ct2
	Assert-AreEqual $resp.CommandText $ct2

	# Test add output using output database object
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -OutputDatabaseObject $db1 -OutputSchemaName $schemaName -OutputTableName $tableName -OutputCredentialName $jc1.CredentialName
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output target using output database resource id
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -OutputDatabaseResourceId $db1.ResourceId
	Assert-AreEqual $resp.Output.ResourceGroupName $db1.ResourceGroupName
	Assert-AreEqual $resp.Output.ServerName $db1.ServerName
	Assert-AreEqual $resp.Output.DatabaseName $db1.DatabaseName
	Assert-AreEqual $resp.Output.SchemaName $schemaName
	Assert-AreEqual $resp.Output.TableName $tableName
	Assert-AreEqual $resp.Output.Credential $jc1.CredentialName

	# Test update output schema name
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -OutputSchemaName $schemaName2
	Assert-AreEqual $resp.Output.SchemaName $schemaName2

	# Test update output table name
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -OutputTableName $tableName2
	Assert-AreEqual $resp.Output.TableName $tableName2

	# Test update output credential name
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -OutputCredentialName $jc2.CredentialName
	Assert-AreEqual $resp.Output.Credential $jc2.CredentialName

	# Test update job step remove output
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -RemoveOutput
	Assert-Null $resp.Output

	# Test update execution option timeout seconds
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -TimeoutSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.TimeoutSeconds 100

	# Test update execution option retry attempts
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -RetryAttempts 1000
	Assert-AreEqual $resp.ExecutionOptions.RetryAttempts 1000

	# Test update execution option initial retry interval seconds
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -InitialRetryIntervalSeconds 100
	Assert-AreEqual $resp.ExecutionOptions.InitialRetryIntervalSeconds 100

	# Test update execution option maximum retry interval seconds
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -MaximumRetryIntervalSeconds 1000
	Assert-AreEqual $resp.ExecutionOptions.MaximumRetryIntervalSeconds 1000

	# Test update execution option maximum retry interval seconds
	$resp = $js1 | Set-AzureRmSqlElasticJobStep -RetryIntervalBackoffMultiplier 5.2
	Assert-AreEqual $resp.ExecutionOptions.RetryIntervalBackoffMultiplier 5.2
}

<#
	.SYNOPSIS
	Tests removing a job step with default param
#>
function Test-RemoveJobStepWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with default params
	$resp = Remove-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName
}

<#
	.SYNOPSIS
	Tests removing a job step with input object
#>
function Test-RemoveJobStepWithInputObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with input object
	$resp = Remove-AzureRmSqlElasticJobStep -InputObject $js1
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName
}

<#
	.SYNOPSIS
	Tests removing a job step with resource id
#>
function Test-RemoveJobStepWithResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with resource id
	$resp = Remove-AzureRmSqlElasticJobStep -ResourceId $js1.ResourceId
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName
}

<#
	.SYNOPSIS
	Tests removing a job step with piping
#>
function Test-RemoveJobStepWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"

	# Create 2 steps
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	$js2 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with piping
	$resp = $js1 | Remove-AzureRmSqlElasticJobStep
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName

	# Test remove all steps from job - should only have 1 left
	$allStepsForJob = $j1 | Get-AzureRmSqlElasticJobStep
	$resp = $allStepsForJob | Remove-AzureRmSqlElasticJobStep
	Assert-AreEqual $resp.Count 1
}

<#
	.SYNOPSIS
	Tests getting one or more job steps using default param
#>
function Test-GetJobStepWithDefaultParam ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with default params
	$resp = Get-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName -Name $js1.StepName
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName

	# Test get all steps
	$resp = Get-AzureRmSqlElasticJobStep -ResourceGroupName $js1.ResourceGroupName -ServerName $js1.ServerName -AgentName $js1.AgentName -JobName $js1.JobName
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests getting one or more job steps using job object
#>
function Test-GetJobStepWithJobObject ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with job object
	$resp = Get-AzureRmSqlElasticJobStep -JobObject $j1 -Name $js1.StepName
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName

	# Test get all steps
	$resp = Get-AzureRmSqlElasticJobStep -JobObject $j1
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests getting one or more job steps using job resource id
#>
function Test-GetJobStepWithJobResourceId ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with resource id
	$resp = Get-AzureRmSqlElasticJobStep -JobResourceId $j1.ResourceId -Name $js1.StepName
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName

	# Test get all steps
	$resp = Get-AzureRmSqlElasticJobStep -JobResourceId $j1.ResourceId
	Assert-True { $resp.Count -ge 2 }
}

<#
	.SYNOPSIS
	Tests getting one or more job steps using piping
#>
function Test-GetJobStepWithPiping ($a1)
{
	# Setup
	$jc1 = Create-JobCredentialForTest $a1
	$tg1 = Create-TargetGroupForTest $a1
	$j1 = Create-JobForTest $a1
	$ct1 = "SELECT 1"
	$js1 = Create-JobStepForTest $j1 $tg1 $jc1 $ct1
	Create-JobStepForTest $j1 $tg1 $jc1 $ct1

	# Test with resource id
	$resp = $j1 | Get-AzureRmSqlElasticJobStep -Name $js1.StepName
	Assert-AreEqual $resp.ResourceGroupName $js1.ResourceGroupName
	Assert-AreEqual $resp.ServerName $js1.ServerName
	Assert-AreEqual $resp.AgentName $js1.AgentName
	Assert-AreEqual $resp.JobName $js1.JobName
	Assert-AreEqual $resp.StepName $js1.StepName
	Assert-AreEqual $resp.TargetGroupName $js1.TargetGroupName
	Assert-AreEqual $resp.CredentialName $js1.CredentialName

	# Test get all steps
	$resp = $j1 | Get-AzureRmSqlElasticJobStep
	Assert-True { $resp.Count -ge 2 }
}