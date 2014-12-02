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
Nagative test. Get resources from an non-existing empty group.
#>
function Test-TestStreamingAnalyticsE2E
{
    $resourceGroup = "StreamAnalytics-Default-West-US"
    $jobName = "TestJobPS"
	$inputName = "Input"
	$outputName = "Output"
	$transformationName = "transform1"

    # Create Job
	$actual =  New-AzureStreamAnalyticsJob -File .\Resources\job.json -ResourceGroupName $resourceGroup -Name $jobName -Force
	$expected = Get-AzureStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $expected.Name $actual.Name	

	# Get Job Input
	$actual = Get-AzureStreamAnalyticsInput -JobName $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $inputName $actual.Name

    # Get Job Output
	$actual = Get-AzureStreamAnalyticsOutput -JobName $jobName -ResourceGroupName $resourceGroup
	Assert-AreEqual $outputName $actual.Name

	# Get Job transformation
	$actual = Get-AzureStreamAnalyticsTransformation -JobName $jobName -Name $transformationName -ResourceGroupName $resourceGroup
	Assert-AreEqual $transformationName $actual.Name

	# New Input (Patch)
    $actual = New-AzureStreamAnalyticsInput -File .\Resources\Input.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $inputName $actual.Name

    # Test Input 
    $actual = Test-AzureStreamAnalyticsInput -JobName $jobName -Name Input -ResourceGroupName $resourceGroup
	$expected = "True"
	Assert-AreEqual $expected $actual

	# New Output (Patch)
	$actual = New-AzureStreamAnalyticsOutput -File .\Resources\Output.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $outputName $actual.Name

	# Test Output
    $actual = Test-AzureStreamAnalyticsOutput -JobName $jobName -Name $outputName -ResourceGroupName $resourceGroup	
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Create transformation (Patch)
	$actual = New-AzureStreamAnalyticsTransformation -File .\Resources\Transformation.json -JobName $jobName -ResourceGroupName $resourceGroup -Force
	Assert-AreEqual $transformationName $actual.Name

	# Get Quota
    $actual = Get-AzureStreamAnalyticsQuota -Location "West US"	
	$expected = 0
	Assert-AreEqual $expected $actual.CurrentCount

    # Start Job
    $actual = Start-AzureStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup	
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Get Quota
    $actual = Get-AzureStreamAnalyticsQuota -Location "West US"	
	$expected = 1
	Assert-AreEqual $expected $actual.CurrentCount

	# Stop Job
    $actual = Stop-AzureStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup	
	$expected = "True"
	Assert-AreEqual $expected $actual

    # Remove Output
    $actual = Remove-AzureStreamAnalyticsOutput -JobName $jobName -Name Output -ResourceGroupName $resourceGroup -Force
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Remove Input
    $actual = Remove-AzureStreamAnalyticsInput -JobName $jobName -Name Input -ResourceGroupName $resourceGroup -Force
	$expected = "True"
	Assert-AreEqual $expected $actual

	# Remove Job
    $actual = Remove-AzureStreamAnalyticsJob -Name $jobName -ResourceGroupName $resourceGroup -Force
	$expected = "True"
	Assert-AreEqual $expected $actual
}