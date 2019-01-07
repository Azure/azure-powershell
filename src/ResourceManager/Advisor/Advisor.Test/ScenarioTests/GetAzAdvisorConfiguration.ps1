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
Get list of configurations for this subscription
#>
function Get-AzAdvisorConfigurationNoParameter
{
	$propertiesCount = 4
	$cmdletReturnType = "Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData"
	$TypeValue = "Microsoft.Advisor/Configurations"

	$queryResult = Get-AzAdvisorConfiguration 
		
	Assert-IsInstance $queryResult $cmdletReturnType
	
	Assert-NotNull  $queryResult
	for ($i = 0; $i -lt $queryResult.Count; $i++){
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-IsInstance $queryResult[$i].id String
		Assert-AreEqual $queryResult[$i].Type $TypeValue
	}	
}