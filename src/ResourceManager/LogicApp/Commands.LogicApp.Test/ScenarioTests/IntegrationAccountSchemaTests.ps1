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
Test New-AzureRmIntegrationAccountSchema command
#>
function Test-CreateIntegrationAccountSchema
{
	$schemaFilePath = "$TestOutputRoot\Resources\OrderFile.xsd"
	$schemaContent = [IO.File]::ReadAllText($schemaFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountSchemaName1 = getAssetname	
	$integrationAccountSchemaName2 = getAssetname	
	$integrationAccountSchemaName3 = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountSchema1 =  New-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName1 -SchemaDefinition $schemaContent 
	Assert-AreEqual $integrationAccountSchemaName1 $integrationAccountSchema1.Name

	$integrationAccountSchema2 =  New-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName2 -SchemaFilePath $schemaFilePath
	Assert-AreEqual $integrationAccountSchemaName2 $integrationAccountSchema2.Name

	$integrationAccountSchema3 =  New-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName3 -SchemaFilePath $schemaFilePath -SchemaType "Xml" -ContentType "application/xml"
	Assert-AreEqual $integrationAccountSchemaName3 $integrationAccountSchema3.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountSchema command
#>
function Test-GetIntegrationAccountSchema
{
	$schemaFilePath = "$TestOutputRoot\Resources\OrderFile.xsd"
	$schemaContent = [IO.File]::ReadAllText($schemaFilePath)	
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountSchemaName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountSchema =  New-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName -SchemaDefinition $schemaContent
	Assert-AreEqual $integrationAccountSchemaName $integrationAccountSchema.Name

	$result =  Get-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName
	Assert-AreEqual $integrationAccountSchemaName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-AreEqual $integrationAccountSchemaName $result1.Name
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountSchema command
#>
function Test-RemoveIntegrationAccountSchema
{
	$schemaFilePath = "$TestOutputRoot\Resources\OrderFile.xsd"
	$schemaContent = [IO.File]::ReadAllText($schemaFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountSchemaName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountSchema =  New-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName -SchemaDefinition $schemaContent
	Assert-AreEqual $integrationAccountSchemaName $integrationAccountSchema.Name

	Remove-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountSchema command
#>
function Test-UpdateIntegrationAccountSchema
{
	$schemaFilePath = "$TestOutputRoot\Resources\OrderFile.xsd"
	$schemaContent = [IO.File]::ReadAllText($schemaFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountSchemaName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountSchema =  New-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName -SchemaDefinition $schemaContent
	Assert-AreEqual $integrationAccountSchemaName $integrationAccountSchema.Name

	$integrationAccountSchemaUpdated =  Set-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName -SchemaDefinition $schemaContent -Force
	Assert-AreEqual $integrationAccountSchemaName $integrationAccountSchema.Name

	$integrationAccountSchemaUpdated =  Set-AzureRmIntegrationAccountSchema -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -SchemaName $integrationAccountSchemaName -SchemaDefinition $schemaContent -Force
	Assert-AreEqual $integrationAccountSchemaName $integrationAccountSchema.Name
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}