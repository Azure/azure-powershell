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
Gets complete list of services.
#>
function Get-AzSupportServiceNoParameter
{
    $propertiesCount = 5
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportService"

	$queryResult = Get-AzSupportService 
	Assert-NotNull  $queryResult

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-IsInstance $queryResult[$i] $cmdletReturnType
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-IsInstance $queryResult[$i].Name String
	}
}

<#
.SYNOPSIS
Get service by name
#>
function Get-AzSupportServiceByNameParameterSetUsingNameAlias
{
	$propertiesCount = 5
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportService"

	$queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Name

	$queryResult = Get-AzSupportService -Name $serviceName
	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}

<#
.SYNOPSIS
Get service by name
#>
function Get-AzSupportServiceByNameParameterSetUsingId
{
	$propertiesCount = 5
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportService"

	$queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Name

	$queryResult = Get-AzSupportService -Id $serviceName
	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}

<#
.SYNOPSIS
Get service by name
#>
function Get-AzSupportServiceByNameParameterSetUsingCompleteResourceId
{
	$propertiesCount = 5
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportService"

	$queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Id

	$queryResult = Get-AzSupportService -Id $serviceName
	Assert-NotNull $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
	Assert-AreEqual $serviceName $queryResult[0].Id
}

