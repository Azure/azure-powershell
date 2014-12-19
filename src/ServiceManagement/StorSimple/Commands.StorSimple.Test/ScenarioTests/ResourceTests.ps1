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
Tests creating new resource group and a simple resource.
#>
function Test-GetResourcesCheckCount
{
	$resources = Get-AzureStorSimpleResource
	Assert-AreNotEqual 0 @($resources).Count
}

function Test-GetResources
{
	$resources = Get-AzureStorSimpleResource

	foreach($resource in $resources)
	{
		Assert-NotNull $resource.ResourceName "ResourceName is empty"
		Assert-NotNull $resource.CloudServiceName "CloudServiceName is empty"
		Assert-NotNull $resource.ResourceNameSpace "ResourceNameSpace is empty"
		Assert-NotNull $resource.ResourceType "ResourceType is empty"
		Assert-NotNull $resource.StampId "StampId is empty"
		Assert-NotNull $resource.ResourceId "ResourceId is empty"
		Assert-NotNull $resource.BackendStampId "BackendStampId is empty"
		Assert-NotNull $resource.ResourceState "ResourceState is empty"
	}
}

function Test-SetResources-IncorrectResourceName
{
	# Set an invalid resource
	$invalidName="123#$%"
    $ErrorActionPreference = "Stop"
    $exceptionEncountered = $false
    try
    {
	    $output = Select-AzureStorSimpleResource -ResourceName $invalidName
    }
    catch
    {
        $exceptionEncountered = $true
    }

	Assert-AreEqual $exceptionEncountered $true
}

function Test-SetResources-DirectInput
{
	# Get a resource name to set
	$resourceName = "OneSDK-Resource"

	# Set the resource Name
	$output = Select-AzureStorSimpleResource -ResourceName $resourceName
	Assert-AreEqual $output.ResourceName $resourceName
}

function Test-SetResources-PipedInput
{
	# Get a resource name to set
	$resource = (Get-AzureStorSimpleResource) | Where-Object {$_.ResourceName -eq 'OneSDK-Resource'}
	

	# Set the resource Name
	$output = $resource | Select-AzureStorSimpleResource 
	Assert-AreEqual $output.ResourceName $resource.ResourceName
}

function Test-GetResourceContext
{
	# Get a resource name to set
	$resource = (Get-AzureStorSimpleResource) | Where-Object {$_.ResourceName -eq 'OneSDK-Resource'}

	# Set the resource Name
	$output = $resource | Select-AzureStorSimpleResource 
	$context = Get-AzureStorSimpleResourceContext
	Assert-AreEqual $context.ResourceId $resource.ResourceId 'ResourceId doesnt match'
	Assert-AreEqual $context.ResourceName $resource.ResourceName 'ResourceName doesnt match'
}