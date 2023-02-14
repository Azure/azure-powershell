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
Test New-AzIntegrationAccountPartner command
#>
function Test-CreateIntegrationAccountPartner
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName 

	$integrationAccountPartnerName = getAssetname
	$integrationAccountPartnerName1 = getAssetname

	$businessIdentities = @(
             ("01","Test1"),
             ("02","Test2"),
             ("As2Identity","Test3"),
             ("As2Identity","Test4")
            )

	$businessIdentities1 = @(
             ("As2Identity","Test4")
            )

	$integrationAccountPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	$integrationAccountPartner1 =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName1 -BusinessIdentities $businessIdentities1
	Assert-AreEqual $integrationAccountPartnerName1 $integrationAccountPartner1.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountPartner command
#>
function Test-GetIntegrationAccountPartner
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName 

	$integrationAccountPartnerName = getAssetname

	$businessIdentities = @(
             ("ZZ","AA"),
             ("XX","GG")
            )

	$integrationAccountPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	$result =  Get-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName
	Assert-AreEqual $integrationAccountPartnerName $result.Name

	$result1 =  Get-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountPartner command : Paging test
#>
function Test-ListIntegrationAccountPartner
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName 

	$businessIdentities = @(("ZZ","AA"),("XX","GG"))

	$val=0
	while($val -ne 1)
	{
		$val++ ;
		$integrationAccountPartnerName = getAssetname
		New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	}

	$result =  Get-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 1 }

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}


<#
.SYNOPSIS
Test Remove-AzIntegrationAccountPartner command
#>
function Test-RemoveIntegrationAccountPartner
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountPartnerName = getAssetname
	$businessIdentities = @(
             ("ZZ","AA"),
             ("XX","GG")
            )

	$integrationAccountPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	Remove-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -Force	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzIntegrationAccountPartner command
#>
function Test-UpdateIntegrationAccountPartner
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountPartnerName = getAssetname
	$businessIdentities = @(
             ("ZZ","AA"),
             ("SS","FF")
            )

	$businessIdentities1 = @(
             ("CC","VV")
            )

	$integrationAccountPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	$integrationAccountPartnerUpdated = Set-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $integrationAccountPartnerName -BusinessIdentities $businessIdentities1	-Force
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartnerUpdated.Name
	#Assert-AreEqual $businessIdentities1 $integrationAccountPartnerUpdated.businessIdentities
	
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}