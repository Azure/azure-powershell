﻿# ----------------------------------------------------------------------------------
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
Neagtive Test, no user input for the parameters. 
#>
function Set-AzureRmAdvisorConfigurationNoParameterSet
{
		Assert-ThrowsContains { Set-AzureRmAdvisorConfiguration } "Cannot process command because of one or more missing mandatory parameters: LowCpuThreshold."
}

<#
.SYNOPSIS
Sets configuration for lowCPUThreshold property for the current subscription set in powershell session.
#>
function Set-AzureRmAdvisorConfigurationWithLowCpu
{
	$propertiesCount = 4
	$lowCpuThresholdParameter = 20
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter 
			
	Assert-NotNull  $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-PropertiesCount $queryResult[$i] $propertiesCount	
		Assert-IsInstance $queryResult[$i].id String
		Assert-NotNull $queryResult[$i].Properties.exclude String
		Assert-NotNull $queryResult[$i].Properties.lowCpuThreshold String
		Assert-AreEqual $queryResult[$i].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
		Assert-AreEqual $queryResult[$i].Type $TypeValue
	}
	
}

# Negative Test, bad input for LowCpuThreshold
function Set-AzureRmAdvisorConfigurationBadUserInputLowCpu-Negative
{
	$lowCpuThresholdParameter = 25
	Assert-ThrowsContains { Set-AzureRMAdvisorConfiguration -L $lowCpuThresholdParameter  } "User provided input for -LowCpuThreshold is not an accpeted value. Accepted values are 0, 5, 10, 15, 20."   						
}

function Set-AzureRmAdvisorConfigurationByLowCpuExclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
		$ExcludePropertyValue = "false"
		$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult
		for ($i = 0; $i -lt $queryResult.Count; $i++)
		{
			Assert-PropertiesCount $queryResult[$i] $propertiesCount	
			Assert-IsInstance $queryResult[$i].id String
			Assert-NotNull $queryResult[$i].Properties.exclude String
			Assert-NotNull $queryResult[$i].Properties.lowCpuThreshold String
			Assert-AreEqual $queryResult[$i].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
			Assert-AreEqual $queryResult[$i].Type $TypeValue
		}
	}Finally{
		$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter
	}
}

function Set-AzureRmAdvisorConfigurationPipelineByLowCpuExclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
		$ExcludePropertyValue = "false"
		$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Get-AzureRmAdvisorConfiguration | Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E 
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult

		for ($i = 0; $i -lt $queryResult.Count; $i++)
		{
			Assert-PropertiesCount $queryResult[$i] $propertiesCount	
			Assert-IsInstance $queryResult[$i].id String
			Assert-NotNull $queryResult[$i].Properties.exclude String
			Assert-NotNull $queryResult[$i].Properties.lowCpuThreshold String
			Assert-AreEqual $queryResult[$i].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
			Assert-AreEqual $queryResult[$i].Type $TypeValue
		}
	}Finally{
		$queryResult = Get-AzureRmAdvisorConfiguration | Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter 
	}
}
<#
.SYNOPSIS
Run simple query
#>

function Set-AzureRmAdvisorConfigurationWithRg
{
	$propertiesCount = 4
	$RgName = "testing"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzureRmAdvisorConfiguration -Rg $RgName 
	#Assert-IsInstance $queryResult Object[]
		
	Assert-IsInstance $queryResult $cmdletReturnType
	
	Assert-NotNull  $queryResult

	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-PropertiesCount $queryResult[$i] $propertiesCount	
		Assert-IsInstance $queryResult[$i].id String
		Assert-NotNull $queryResult[$i].Properties.exclude String
		Assert-Null $queryResult[$i].Properties.lowCpu String
		Assert-AreEqual $queryResult[$i].Type $TypeValue
	}
}

function Set-AzureRmAdvisorConfigurationByRgExclude
{
	$propertiesCount = 4
	$RgName = "testing"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzureRmAdvisorConfiguration -Rg $RgName 
			
	Assert-IsInstance $queryResult $cmdletReturnType
	
	Assert-NotNull  $queryResult
	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-PropertiesCount $queryResult[$i] $propertiesCount	
		Assert-IsInstance $queryResult[$i].id String
		Assert-NotNull $queryResult[$i].Properties.exclude String
		Assert-Null $queryResult[$i].Properties.lowCpu String
		Assert-AreNotEqual $queryResult[$i].Properties.exclude 	True
		Assert-AreEqual $queryResult[$i].Type $TypeValue
	}
}