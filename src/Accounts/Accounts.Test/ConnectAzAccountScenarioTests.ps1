# -----------------------------------------------------------------------------------
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
Populate 1 context
#>
function Test-MaxContextPopulationWithSpecifiedValue
{
	$authenticationString=$Env:TEST_CSM_ORGID_AUTHENTICATION

	$applicationId=$authenticationString.SubString($authenticationString.IndexOf("ServicePrincipal=")+"ServicePrincipal=".length,36)
	$password=$authenticationString.SubString($authenticationString.IndexOf("ServicePrincipalSecret=")+"ServicePrincipalSecret=".length,34)
	$secret = ConvertTo-SecureString -String $password -AsPlainText -Force
	$tenantId=$authenticationString.SubString($authenticationString.IndexOf("TenantId=")+"TenantId=".length,36)
	
	$credential = New-Object -TypeName System.Management.Automation.PSCredential($applicationId, $secret)	

	$maxContextPopulation=1
		
	Connect-AzAccount -ServicePrincipal -Credential $credential -Tenant $tenantId -MaxContextPopulation $maxContextPopulation

	$subscriptionCount=(Get-AzSubscription).count
	If ($subscriptionCount  -le $maxContextPopulation)  
	{
		Assert-AreEqual $subscriptionCount (Get-AzContext -ListAvailable).count
	} 
	Else  
	{
		# subtract 1 only for test freamwork 
		Assert-AreEqual $maxContextPopulation ((Get-AzContext -ListAvailable).count-1)
	}

}

<#
.SYNOPSIS
Populate contexts by default
#>

function Test-MaxContextPopulationWithDefaultValue
{	
	$authenticationString=$Env:TEST_CSM_ORGID_AUTHENTICATION
	$applicationId=$authenticationString.SubString($authenticationString.IndexOf("ServicePrincipal=")+"ServicePrincipal=".length,36)
	$password=$authenticationString.SubString($authenticationString.IndexOf("ServicePrincipalSecret=")+"ServicePrincipalSecret=".length,34)
	$secret = ConvertTo-SecureString -String $password -AsPlainText -Force
	$tenantId=$authenticationString.SubString($authenticationString.IndexOf("TenantId=")+"TenantId=".length,36)
	
	$credential = New-Object -TypeName System.Management.Automation.PSCredential($applicationId, $secret)	
	Connect-AzAccount -ServicePrincipal -Credential $credential -Tenant $tenantId	

	$defaultContextPopulation=25
	$subscriptionCount=(Get-AzSubscription).count

	If ($subscriptionCount  -le $defaultContextPopulation)  
	{
		Assert-AreEqual $subscriptionCount (Get-AzContext -ListAvailable).count
	} 
	Else  
	{
		# subtract 1 only for test freamwork 
		Assert-AreEqual $defaultContextPopulation ((Get-AzContext -ListAvailable).count-1)
	}
}

<#
.SYNOPSIS
Populate all contexts
#>
function Test-MaxContextPopulationGetAll
{	
	$authenticationString=$Env:TEST_CSM_ORGID_AUTHENTICATION
	$applicationId=$authenticationString.SubString($authenticationString.IndexOf("ServicePrincipal=")+"ServicePrincipal=".length,36)
	$password=$authenticationString.SubString($authenticationString.IndexOf("ServicePrincipalSecret=")+"ServicePrincipalSecret=".length,34)
	$secret = ConvertTo-SecureString -String $password -AsPlainText -Force
	$tenantId=$authenticationString.SubString($authenticationString.IndexOf("TenantId=")+"TenantId=".length,36)
	
	$credential = New-Object -TypeName System.Management.Automation.PSCredential($applicationId, $secret)	
	
	Connect-AzAccount -ServicePrincipal -Credential $credential -Tenant $tenantId -MaxContextPopulation -1

	Assert-AreEqual (Get-AzSubscription).count (Get-AzContext -ListAvailable).count
	
}
