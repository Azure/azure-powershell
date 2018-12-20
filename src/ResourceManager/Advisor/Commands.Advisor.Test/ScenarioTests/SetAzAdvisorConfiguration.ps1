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
Sets configuration for lowCPUThreshold property for the current subscription set in powershell session.
#>
function Set-AzAdvisorConfigurationWithLowCpu
{
	$propertiesCount = 4
	$lowCpuThresholdParameter = 20
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzAdvisorConfiguration -LowCpuThreshold $lowCpuThresholdParameter 
			
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
function Set-AzAdvisorConfigurationBadUserInputLowCpu-Negative
{
	$lowCpuThresholdParameter = 25
	Assert-ThrowsContains { Set-AzAdvisorConfiguration -LowCpuThreshold $lowCpuThresholdParameter }  "Cannot validate argument on parameter 'LowCpuThreshold'. The argument "25" does not belong to the set "0,5,10,15,20" specified by the ValidateSet attribute"
}

function Set-AzAdvisorConfigurationByLowCpuExclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData"
		$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Set-AzAdvisorConfiguration -LowCpuThreshold $lowCpuThresholdParameter -Exclude
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult
		for ($i = 0; $i -lt $queryResult.Count; $i++)
		{
			Assert-PropertiesCount $queryResult[$i] $propertiesCount	
			Assert-IsInstance $queryResult[$i].id String
			Assert-AreEqual $queryResult[$i].Properties.exclude $True
			Assert-NotNull $queryResult[$i].Properties.lowCpuThreshold String
			Assert-AreEqual $queryResult[$i].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
			Assert-AreEqual $queryResult[$i].Type $TypeValue
		}
	}Finally{
		$queryResult = Set-AzAdvisorConfiguration -LowCpuThreshold $lowCpuThresholdParameter
	}
}

function Set-AzAdvisorConfigurationPipelineByLowCpuExclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData"
		$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Get-AzAdvisorConfiguration | Set-AzAdvisorConfiguration -LowCpuThreshold $lowCpuThresholdParameter 
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult

		for ($i = 0; $i -lt $queryResult.Count; $i++)
		{
			Assert-PropertiesCount $queryResult[$i] $propertiesCount	
			Assert-IsInstance $queryResult[$i].id String
			Assert-NotNull $queryResult[$i].Properties.lowCpuThreshold String
			Assert-AreEqual $queryResult[$i].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
			Assert-AreEqual $queryResult[$i].Type $TypeValue
		}
	}Finally{
		$queryResult = Get-AzAdvisorConfiguration | Set-AzAdvisorConfiguration -LowCpuThreshold $lowCpuThresholdParameter 
	}
}
<#
.SYNOPSIS
Run simple query
#>

function Set-AzAdvisorConfigurationWithRg
{
	$propertiesCount = 4
	$RgName = "testing"
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzAdvisorConfiguration -ResourceGroupName $RgName 
		
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

function Set-AzAdvisorConfigurationByRgExclude
{
	$propertiesCount = 4
	$RgName = "testing"
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzAdvisorConfiguration -ResourceGroupName $RgName 
			
	Assert-IsInstance $queryResult $cmdletReturnType
	
	Assert-NotNull  $queryResult
	for ($i = 0; $i -lt $queryResult.Count; $i++)
	{
		Assert-PropertiesCount $queryResult[$i] $propertiesCount	
		Assert-IsInstance $queryResult[$i].id String
		Assert-NotNull $queryResult[$i].Properties.exclude String
		Assert-Null $queryResult[$i].Properties.lowCpu String
		Assert-AreEqual $queryResult[$i].Properties.exclude	$False
		Assert-AreEqual $queryResult[$i].Type $TypeValue
	}
}