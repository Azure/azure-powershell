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
function Set-AzureRmAdvisorConfigurationWithLowCpu
{
	$propertiesCount = 4
	$lowCpuThresholdParameter = 20
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter 
			
	Assert-NotNull  $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType

	Assert-PropertiesCount $queryResult[0] $propertiesCount	
	Assert-IsInstance $queryResult[0].id String
	Assert-NotNull $queryResult[0].Properties.exclude String
	Assert-NotNull $queryResult[0].Properties.lowCpuThreshold String
	Assert-AreEqual $queryResult[0].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
	Assert-AreEqual $queryResult[0].Type $TypeValue
}

# Negative Test, bad input for Exclude
function Set-AzureRmAdvisorConfigurationBadUserInputExclude-Negative
{
	$propertiesCount = 4
	$lowCpuThresholdParameter = 20
	$IncludeValue = "true"

	# $queryResult = Set-AzureRMAdvisorConfiguration -L $lowCpuThresholdParameter -E trueeee 
	Assert-ThrowsContains { Set-AzureRMAdvisorConfiguration -L $lowCpuThresholdParameter -E trueeee  } "User provided input for -Include (or) -Exclude is not an accpeted value. Accepted values are true (or) false."   			
}

# Negative Test, bad input for LowCpuThreshold
function Set-AzureRmAdvisorConfigurationBadUserInputLowCpu-Negative
{
	$propertiesCount = 4
	$lowCpuThresholdParameter = 25
	$IncludeValue = "true"

	# $queryResult = Set-AzureRMAdvisorConfiguration -L $lowCpuThresholdParameter
	Assert-ThrowsContains { Set-AzureRMAdvisorConfiguration -L $lowCpuThresholdParameter  } "User provided input for -LowCpuThreshold is not an accpeted value. Accepted values are 0, 5, 10, 15, 20."   						
	
}

<#
.SYNOPSIS
Sets configuration for lowCPUThreshold property and also whether to include this at the filtering or not for the current subscription set in powershell session.
#>
function Set-AzureRmAdvisorConfigurationByLowCpuInclude
{
	try{
		
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$IncludeValue = "true"
		$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
		$ExcludePropertyValue = "true"
			$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -I $IncludeValue
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult

		Assert-PropertiesCount $queryResult[0] $propertiesCount	
		Assert-IsInstance $queryResult[0].id String
		Assert-NotNull $queryResult[0].Properties.exclude String
		Assert-NotNull $queryResult[0].Properties.lowCpuThreshold String
		Assert-AreEqual $queryResult[0].Properties.exclude 	$ExcludePropertyValue
		Assert-AreEqual $queryResult[0].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
		Assert-AreEqual $queryResult[0].Type $TypeValue

		}Finally{
			$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E true
		}
}

function Set-AzureRmAdvisorConfigurationByLowCpuExclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$ExcludeValue = "true"
		$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
		$ExcludePropertyValue = "false"
		$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E $ExcludeValue
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult

		Assert-PropertiesCount $queryResult[0] $propertiesCount	
		Assert-IsInstance $queryResult[0].id String
		Assert-NotNull $queryResult[0].Properties.exclude String
		Assert-NotNull $queryResult[0].Properties.lowCpuThreshold String
		Assert-AreEqual $queryResult[0].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
		Assert-AreEqual $queryResult[0].Type $TypeValue
	}Finally{
		$queryResult = Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -I true
	}
}

function Set-AzureRmAdvisorConfigurationPipelineByLowCpuInclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$IncludeValue = "true"
		$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
		$ExcludePropertyValue = "true"
			$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Get-AzureRmAdvisorConfiguration | Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -I $IncludeValue
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult

		Assert-PropertiesCount $queryResult[0] $propertiesCount	
		Assert-IsInstance $queryResult[0].id String
		Assert-NotNull $queryResult[0].Properties.exclude String
		Assert-NotNull $queryResult[0].Properties.lowCpuThreshold String
		Assert-AreEqual $queryResult[0].Properties.exclude 	$ExcludePropertyValue
		Assert-AreEqual $queryResult[0].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
		Assert-AreEqual $queryResult[0].Type $TypeValue
	
	}Finally{
		$queryResult = Get-AzureRmAdvisorConfiguration | Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E true
	}
}

function Set-AzureRmAdvisorConfigurationPipelineByLowCpuExclude
{
	try{
		$propertiesCount = 4
		$lowCpuThresholdParameter = 20
		$ExcludeValue = "true"
		$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
		$ExcludePropertyValue = "false"
		$TypeValue = "Microsoft.Advisor/Configurations"

		$queryResult = Get-AzureRmAdvisorConfiguration | Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E $ExcludeValue
		
		Assert-IsInstance $queryResult $cmdletReturnType
	
		Assert-NotNull  $queryResult

		Assert-PropertiesCount $queryResult[0] $propertiesCount	
		Assert-IsInstance $queryResult[0].id String
		Assert-NotNull $queryResult[0].Properties.exclude String
		Assert-NotNull $queryResult[0].Properties.lowCpuThreshold String
		Assert-AreEqual $queryResult[0].Properties.lowCpuThreshold 	$lowCpuThresholdParameter
		Assert-AreNotEqual  $queryResult[0].Properties.exclude 	true
		Assert-AreEqual $queryResult[0].Type $TypeValue
	}Finally{
		$queryResult = Get-AzureRmAdvisorConfiguration | Set-AzureRmAdvisorConfiguration -L $lowCpuThresholdParameter -E true
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

	Assert-PropertiesCount $queryResult[0] $propertiesCount	
	Assert-IsInstance $queryResult[0].id String
	Assert-NotNull $queryResult[0].Properties.exclude String
	Assert-Null $queryResult[0].Properties.lowCpu String
	Assert-AreEqual $queryResult[0].Type $TypeValue	
}

function Set-AzureRmAdvisorConfigurationByRgInclude
{
	$propertiesCount = 4
	$RgName = "testing"
	$IncludeValue = "true"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
	$ExcludePropertyValue = "true"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzureRmAdvisorConfiguration -Rg $RgName -I $IncludeValue

	Assert-NotNull  $queryResult
	Assert-IsInstance $queryResult $cmdletReturnType
	Assert-PropertiesCount $queryResult[0] $propertiesCount	
	Assert-IsInstance $queryResult[0].id String
	Assert-NotNull $queryResult[0].Properties.exclude String
	Assert-Null $queryResult[0].Properties.lowCpu String
	Assert-AreEqual $queryResult[0].Properties.exclude 	$ExcludePropertyValue
	Assert-AreEqual $queryResult[0].Type $TypeValue
}

function Set-AzureRmAdvisorConfigurationByRgExclude
{
	$propertiesCount = 4
	$ExcludeValue = "true"
	$RgName = "testing"
	$cmdletReturnType = "System.Collections.Generic.List[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]"
	$ExcludePropertyValue = "false"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Set-AzureRmAdvisorConfiguration -Rg $RgName -E $ExcludeValue
			
	Assert-IsInstance $queryResult $cmdletReturnType
	
	Assert-NotNull  $queryResult

	Assert-PropertiesCount $queryResult[0] $propertiesCount	
	Assert-IsInstance $queryResult[0].id String
	Assert-NotNull $queryResult[0].Properties.exclude String
	Assert-Null $queryResult[0].Properties.lowCpu String
	Assert-AreNotEqual  $queryResult[0].Properties.exclude 	true
	Assert-AreEqual $queryResult[0].Type $TypeValue
}