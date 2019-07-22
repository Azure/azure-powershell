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


#################################
## HealthcareApis Cmdlets			   ##
#################################

$global:resourceType = "Microsoft.HealthcareApis/services"

<#
.SYNOPSIS
Tests CRUD Operations for HealthcareApisFhirService.
#>
function Test-AzRmHealthcareApisFhirService{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = "West US"
	
	try
	{
		# Test
		# Create Resource Group
		New-AzResourceGroup -Name $rgname -Location $location

		# Create App
		$created = New-AzRmHealthcareApisFhirService -Name $accountname -ResourceGroupName  $rgname -Location $location;
		$actual = Get-AzRmHealthcareApisFhirService -ResourceGroupName $rgname -Name $rname

		#$list = Get-AzHealthcareApisFhirService -ResourceGroupName $rgname
	
		# Assert
		Assert-AreEqual $actual.Name $rname
		Assert-AreEqual $actual.Subdomain $subdomain
		Assert-AreEqual $actual.DisplayName $displayName
		Assert-AreEqual $actual.Tag.Item($tagkey) $tagvalue
		Assert-AreEqual 1 @($list).Count
		Assert-AreEqual $actual.Name $list[0].Name
	}
	finally{
		# Clean up
		Remove-AzResourceGroup -Name $rgname -Force
	}
}