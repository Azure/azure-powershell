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

# Default job collection values
$location = "West US"
$plan = "Standard"
$maxJobCount = 50
$maxRecurrence = "Every 1 Minute"
$jobCollectionState = "Enabled"


<#
.SYNOPSIS
Test creation of job collection. 
#>
function Test-CreateJobCollection
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    
    try
    {
        # Create job collection with Standard Plan
        $jobCollectionName = "CreateJobCollectionWithStandardPlan"
        
        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Create job collection with P10Premium plan.
        $jobCollectionName = "CreateJobCollectionWithP10PremimPlan"
        $plan = "P10Premium"

        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Create job collection with P20Premium plan.
        $jobCollectionName = "CreateJobCollectionWithP20PremimPlan"
        $plan = "P20Premium"
        $maxJobCount = 1000

        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Create job collection with Free plan
        $jobCollectionName = "CreateJobCollectionWithFreePlan"
        $plan = "Free"
        $maxJobCount = 5
        $maxRecurrence = "Every 1 Hour"
        
        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}


<#
.SYNOPSIS
Test creation of "free" job collection. 
#>
function Test-CreateJobCollectionWithInvalidInput
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    $jobCollectionName = "CreateJobCollectionWithInvalidInput"
        
    try
    {
        # Invalid maximum job count tests.
        $exceptionMessage = "The maximum job count quota has a value that is too large"

        # Free plan MaxJobCount = 5
        $plan = "Free"
        $maxJobCount = 6

        Assert-ThrowsContains { New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan -MaxJobCount $maxJobCount } $exceptionMessage

        # Standard plan MaxJobCount = 50
        $plan = "Standard"
        $maxJobCount = 51
        Assert-ThrowsContains { New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan -MaxJobCount $maxJobCount } $exceptionMessage

        # P10Premium plan MaxJobCount = 50
        $plan = "P10Premium"
        $maxJobCount = 51
        Assert-ThrowsContains { New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan -MaxJobCount $maxJobCount } $exceptionMessage

        # P20Premium plan MaxJobCount = 50
        $plan = "P20Premium"
        $maxJobCount = 1001
        Assert-ThrowsContains { New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan -MaxJobCount $maxJobCount } $exceptionMessage

        # Invalid maximum recurrence tests.		
        # Free plan maximum recurrence is 1 hour.
        $exceptionMessage = "The provided MaxRecurrence for job collection Quota '00:59:00' exceeds the permissible limit for Free collections '01:00:00'."
        $plan = "Free"
        $maxJobCount = 5
        $interval = 59
        $frequency = "Minute"
        Assert-Throws { New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan -MaxJobCount $maxJobCount -Interval $interval -Frequency $frequency } $exceptionMessage
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests whether user could create job collection with non default params.
#>
function Test-CreateJobCollectionWithNonDefaultParams
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    $jobCollectionName = "CreateJobCollectionWithNonDefaultParams"
    $maxJobCount = 49
    $interval = 3
    $frequency = "Minute"
    $maxRecurrence = "Every 3 Minute"

    try
    {
        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location -Plan $plan -MaxJobCount $maxJobCount -Frequency $frequency -Interval $interval
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests whether user could update job collection.
#>
function Test-UpdateJobCollection
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    $jobCollectionName = "TestJobCollection"	

    try
    {
        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Update max job count.
        $maxJobCount = 49

        $jobCollectionDefinition = Set-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -MaxJobCount $maxJobCount
         ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Update recurrence interval.
        $interval = 2
        $frequency = "Week"

        $maxRecurrence = "Every 2 Week"
        $jobCollectionDefinition = Set-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Frequency $frequency -Interval $interval
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Update Plan to Free
        $plan = "Free"
        $maxJobCount = 5
        $maxRecurrence = "Every 1 Hour"

        $jobCollectionDefinition = Set-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Plan $plan
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Update Plan to P20Premium
        $plan = "P20Premium"
        $maxJobCount = 1000
        $maxRecurrence = "Every 1 Minute"

        $jobCollectionDefinition = Set-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Plan $plan
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests whether user could get job collection and remove job collection.
#>
function Test-GetRemoveJobCollection
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    $jobCollectionName = "TestJobCollection"	

    try
    {
        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Get job collection.
        $jobCollectionDefinition = Get-AzureRMSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition
    
        # Remove job collection.
        Remove-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
    
        # Get job collection should throw exception.
        $exceptionMessage = "'Microsoft.Scheduler/jobcollections/$jobCollectionName' under resource group '$resourceGroupName' was not found."
        Assert-ThrowsContains { Get-AzureRMSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName } $exceptionMessage
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests enable/disable job collection.
#>
function Test-EnableDisableJobCollection
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    $jobCollectionName = "TestJobCollection"	

    try
    {
        $jobCollectionDefinition = New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Disable job collection.
        $jobCollectionState = "Disabled"
        Disable-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
        $jobCollectionDefinition = Get-AzureRMSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition

        # Enable job collection.
        $jobCollectionState = "Enabled"
        Enable-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
        $jobCollectionDefinition = Get-AzureRMSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
        ValidateJobCollection $resourceGroupName $jobCollectionName $location $plan $maxJobCount $maxRecurrence $jobCollectionState $jobCollectionDefinition
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Validate job collection.
#>
function ValidateJobCollection(
    [String]$resourceGroupname, 
    [String]$jobCollectionName, 
    [String]$location, 
    [String]$plan, 
    [String]$maxJobCount, 
    [string]$maxRecurrence,
    [string]$jobCollectionState,
    [Microsoft.Azure.Commands.Scheduler.Models.PSJobCollectionDefinition]$jobCollectionDefinition)
{
    # Assert-AreEqual Expected Actual
    Assert-AreEqual $resourceGroupName $jobCollectionDefinition.ResourceGroupName 
    Assert-AreEqual $jobCollectionName $jobCollectionDefinition.JobCollectionName
    Assert-AreEqual $location $jobCollectionDefinition.Location
    Assert-AreEqual $plan $jobCollectionDefinition.Plan
    Assert-AreEqual $maxJobCount $jobCollectionDefinition.MaxJobCount
    Assert-AreEqual $maxRecurrence $jobCollectionDefinition.MaxRecurrence
    Assert-AreEqual $jobCollectionState $jobCollectionDefinition.State
}