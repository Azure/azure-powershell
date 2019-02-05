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
Tests the common usages and scenarios of the cmdlets.
#>
function Test-TestStreamingAnalyticsE2E
{
    $resourceGroup = "ASASDK"
    $jobName = "TestJobPS"
	$inputName = "Input"
	$outputName = "Output"
	$transformationName = "transform1"
	$functionName = "scoreTweet"
	$expectedContainerName = "samples"
	$expectedTableName = "Samples"
	$expectedStreamingUnits = 1
	$expectedBatchSize = 10

	# Gets should throw when the resource doesn't exist
	Assert-Throws { Get-AzStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup }
	Assert-Throws { Get-AzStreamAnalyticsInput -Name $inputName -JobName $jobName -ResourceGroupName $resourceGroup }
	Assert-Throws { Get-AzStreamAnalyticsOutput -Name $outputName -JobName $jobName -ResourceGroupName $resourceGroup }
	Assert-Throws { Get-AzStreamAnalyticsTransformation -Name $transformationName -JobName $jobName -ResourceGroupName $resourceGroup }
	Assert-Throws { Get-AzStreamAnalyticsFunction -Name $functionName -JobName $jobName -ResourceGroupName $resourceGroup }

	# Create Job
	$actual =  New-AzStreamAnalyticsJob -File .\Resources\job.json -ResourceGroupName $resourceGroup -Name $jobName -Force
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual "West US" $actual.Location
	Assert-AreEqual "Created" $actual.JobState
	Assert-AreEqual "Succeeded" $actual.ProvisioningState
	Assert-AreEqual $expectedContainerName $actual.Properties.Inputs[0].Properties.Datasource.Container
	Assert-AreEqual $expectedTableName $actual.Properties.Outputs[0].Datasource.Table
	Assert-AreEqual $expectedStreamingUnits $actual.Properties.Transformation.StreamingUnits
	Assert-AreEqual $expectedBatchSize $actual.Properties.Functions[0].Properties.Binding.BatchSize
	$expected = Get-AzStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $expected.JobName $actual.JobName	
	Assert-AreEqual $expected.Location $actual.Location	
	Assert-AreEqual $expected.JobState $actual.JobState	
	Assert-AreEqual $expected.ProvisioningState $actual.ProvisioningState
	Assert-AreEqual $expected.Properties.Inputs[0].Properties.Datasource.Container $actual.Properties.Inputs[0].Properties.Datasource.Container
	Assert-AreEqual $expected.Properties.Outputs[0].Properties.Datasource.Table $actual.Properties.Outputs[0].Properties.Datasource.Table
	Assert-AreEqual $expected.Properties.Transformation.StreamingUnits $actual.Properties.Transformation.StreamingUnits
	Assert-AreEqual $expected.Properties.Functions[0].Properties.Binding.BatchSize $actual.Properties.Functions[0].Properties.Binding.BatchSize

	# Get Job Input
	$actual = Get-AzStreamAnalyticsInput -JobName $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $inputName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedContainerName $actual.Properties.Datasource.Container

    # Get Job Output
	$actual = Get-AzStreamAnalyticsOutput -JobName $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $outputName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedTableName $actual.Properties.Datasource.Table

	# Get Job transformation
	$actual = Get-AzStreamAnalyticsTransformation -JobName $jobName -Name $transformationName -ResourceGroupName $resourceGroup
	Assert-AreEqual $transformationName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedStreamingUnits $actual.Properties.StreamingUnits

	# Get Job function
	$actual = Get-AzStreamAnalyticsFunction -JobName $jobName -Name $functionName -ResourceGroupName $resourceGroup
	Assert-AreEqual $functionName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedBatchSize $actual.Properties.Binding.BatchSize

	# New Input (Patch)
    $actual = New-AzStreamAnalyticsInput -File .\Resources\Input.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $inputName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedContainerName $actual.Properties.Datasource.Container

    # Test Input 
    $actual = Test-AzStreamAnalyticsInput -JobName $jobName -Name Input -ResourceGroupName $resourceGroup
	$expected = "True"
	Assert-AreEqual $expected $actual

	# New Output (Patch)
	$actual = New-AzStreamAnalyticsOutput -File .\Resources\Output.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $outputName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedTableName $actual.Properties.Datasource.Table

	# Test Output
    $actual = Test-AzStreamAnalyticsOutput -JobName $jobName -Name $outputName -ResourceGroupName $resourceGroup	
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Create transformation (Patch)
	$actual = New-AzStreamAnalyticsTransformation -File .\Resources\Transformation.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $transformationName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedStreamingUnits $actual.Properties.StreamingUnits

	# New Function (Patch)
    $actual = New-AzStreamAnalyticsFunction -File .\Resources\Function.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $functionName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual $expectedBatchSize $actual.Properties.Binding.BatchSize

	# Test Function
    $actual = Test-AzStreamAnalyticsFunction -JobName $jobName -Name $functionName -ResourceGroupName $resourceGroup	
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Get Quota
    $actual = Get-AzStreamAnalyticsQuota -Location "West US"	
	$expected = 0
	Assert-AreEqual $expected $actual.CurrentCount

    # Start Job
    $actual = Start-AzStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup -OutputStartMode CustomTime -OutputStartTime 2012-12-12T12:12:12Z
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Get Quota
    $actual = Get-AzStreamAnalyticsQuota -Location "West US"	
	$expected = 1
	Assert-AreEqual $expected $actual.CurrentCount

	#Get Diagnostics
	$actual = Get-AzStreamAnalyticsInput -JobName $jobName -ResourceGroupName $resourceGroup
	Assert-NotNull $actual
	Assert-NotNull $actual.Properties.Diagnostics
	Assert-NotNull $actual.Properties.Diagnostics.Conditions
	Assert-NotNull $actual.Properties.Diagnostics.Conditions.Message

	# Stop Job
    $actual = Stop-AzStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup	
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Get Function Default Definition
	$actual = Get-AzStreamAnalyticsDefaultFunctionDefinition -File .\Resources\RetrieveDefaultFunctionDefinitionRequest.json -Name $functionName -JobName $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $functionName $actual.Name
	Assert-AreEqual $jobName $actual.JobName
	Assert-AreEqual $resourceGroup $actual.ResourceGroupName
	Assert-AreEqual 1000 $actual.Properties.Binding.BatchSize

	# Remove Function
    $actual = Remove-AzStreamAnalyticsFunction -JobName $jobName -Name $functionName -ResourceGroupName $resourceGroup
	$expected = "True"
	Assert-AreEqual $expected $actual

    # Remove Output
    $actual = Remove-AzStreamAnalyticsOutput -JobName $jobName -Name Output -ResourceGroupName $resourceGroup
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Remove Input
    $actual = Remove-AzStreamAnalyticsInput -JobName $jobName -Name Input -ResourceGroupName $resourceGroup
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Gets should throw when the resource doesn't exist
	Assert-Throws { Get-AzStreamAnalyticsInput -Name $inputName -JobName $jobName -ResourceGroupName $resourceGroup }
	Assert-Throws { Get-AzStreamAnalyticsOutput -Name $outputName -JobName $jobName -ResourceGroupName $resourceGroup }
	Assert-Throws { Get-AzStreamAnalyticsFunction -Name $functionName -JobName $jobName -ResourceGroupName $resourceGroup }

	# Remove Job
    $actual = Remove-AzStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Gets should throw when the resource doesn't exist
	Assert-Throws { Get-AzStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup }
}