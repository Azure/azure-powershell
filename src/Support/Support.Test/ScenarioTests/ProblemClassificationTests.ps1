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
Gets complete list of problem classification for a service by id.
#>
function Get-AzSupportProblemClassificationServiceName
{
    $queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Name

    $propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification"

	$queryResult = Get-AzSupportProblemClassification -ServiceId $serviceName
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
Gets a single problem classification for a service using Name alias
#>
function Get-AzSupportProblemClassificationAllParametersNameAlias
{
    $queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Name

    $propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification"

	$queryResult = Get-AzSupportProblemClassification -ServiceName $serviceName
	$problemClassificationName = $queryResult[0].Name

	$queryResult = Get-AzSupportProblemClassification -ServiceName $serviceName -Name $problemClassificationName

	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}

<#
.SYNOPSIS
Gets a single problem classification for a service using Id
#>
function Get-AzSupportProblemClassificationAllParametersId
{
    $queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Name

    $propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification"

	$queryResult = Get-AzSupportProblemClassification -ServiceName $serviceName
	$problemClassificationName = $queryResult[0].Name

	$queryResult = Get-AzSupportProblemClassification -ServiceId $serviceName -Id $problemClassificationName

	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}

<#
.SYNOPSIS
Gets a single problem classification for a service using complete resource id
#>
function Get-AzSupportProblemClassificationAllParametersResourceId
{
    $queryResult = Get-AzSupportService 
	$serviceName = $queryResult[0].Id

    $propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification"

	$queryResult = Get-AzSupportProblemClassification -ServiceName $serviceName
	$problemClassificationName = $queryResult[0].Id

	$queryResult = Get-AzSupportProblemClassification -ServiceId $serviceName -Id $problemClassificationName

	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}

<#
.SYNOPSIS
Gets complete list of problem classification for a service using parent service object
#>
function Get-AzSupportProblemClassificationParentObjectServiceName
{
    $queryResult = Get-AzSupportService 
	$serviceObject = $queryResult[0]

    $propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification"

	$queryResult = Get-AzSupportService -Name $serviceObject.Name | Get-AzSupportProblemClassification
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
Gets a single problem classification for a service using parent serive object
#>
function Get-AzSupportProblemClassificationParentObjectAllParameters
{
    $queryResult = Get-AzSupportService 
	$serviceObject = $queryResult[0]

    $propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification"

	$queryResult = Get-AzSupportService -Name $serviceObject.Name | Get-AzSupportProblemClassification
	$problemClassificationName = $queryResult[0].Name

	$queryResult = Get-AzSupportService -Name $serviceObject.Name | Get-AzSupportProblemClassification -Name $problemClassificationName

	Assert-NotNull  $queryResult

	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult $propertiesCount
	Assert-IsInstance $queryResult.Name String
}
