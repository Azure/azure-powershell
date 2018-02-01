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
Tests location completer
#>
function Test-LocationCompleter
{
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\Microsoft.Azure.Commands.ResourceManager.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$resourceTypes = @("Microsoft.Batch/operations")
	$locations = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.LocationCompleterAttribute]::FindLocations($resourceTypes, 60)
	$expectedResourceType = Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.Batch" | Where-Object {$_.ResourceTypes.ResourceTypeName -eq "operations"}
	$expectedLocations = $expectedResourceType.Locations | ForEach-Object {"`'" + $_ + "`'"}
	Assert-AreEqualArray $locations $expectedLocations
}


<#
.SYNOPSIS
Tests resource group completer
#>
function Test-ResourceGroupCompleter
{
	$filePath = Join-Path -Path $PSScriptRoot -ChildPath "\Microsoft.Azure.Commands.ResourceManager.Common.dll"
	$assembly = [System.Reflection.Assembly]::LoadFrom($filePath)
	$resourceGroups = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceGroupCompleterAttribute]::GetResourceGroups(60)
	$expectResourceGroups = Get-AzureRmResourceGroup | ForEach-Object {$_.ResourceGroupName}
	Assert-AreEqualArray $resourceGroups $expectResourceGroups
}