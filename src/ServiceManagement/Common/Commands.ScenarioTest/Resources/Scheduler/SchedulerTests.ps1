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

########################## Scheduler End to End Scenario Tests #############################

<#
.SYNOPSIS
Scheduler End to End
#>
function Test-SchedulerEndToEnd
{
	#Verify number of regions returned for sub is 10
	$schedulerRegions = Get-AzureSchedulerLocation
	Assert-AreEqual '18' $schedulerRegions.Count
	$schedulerRegions
	
	#Create a job collection and verify job collection is successfully created
	$jcName = "testFromPSScenario"
	$jcLocation = "West US"	
	New-AzureSchedulerJobCollection -Location $jcLocation -JobCollectionName $jcName -Plan Standard
		
	$createdSchedulerJobCollection = Get-AzureSchedulerJobCollection -Location $jcLocation -JobCollectionName $jcName
	Assert-AreEqual 'Standard' $createdSchedulerJobCollection.Plan
	Assert-AreEqual $jcName $createdSchedulerJobCollection.JobCollectionName
	Assert-AreEqual '50' $createdSchedulerJobCollection.MaxJobCount
	
	#Put a job in the job collection and verify the status
	$jobName = "testFromPSScenarioJob"	
	New-AzureSchedulerHttpJob -Location $jcLocation -JobCollectionName $jcName -JobName $jobName -Method GET -URI http://www.bing.com
		
	$createdJob = Get-AzureSchedulerJob -Location $jcLocation -JobCollectionName $jcName -JobName $jobName
	Assert-AreEqual 'Enabled' $createdJob.Status
	Assert-AreEqual $jobName $createdJob.JobName

	#Delete the job and job collection
	Remove-AzureSchedulerJob -Location $jcLocation -JobCollectionName $jcName -JobName $jobName -Force	
	$response = Remove-AzureSchedulerJobCollection -Location $jcLocation -JobCollectionName $jcName -Force
	Assert-AreEqual 'True' $response
}