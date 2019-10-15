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
Gets and removes custom domain with running endpoint.
#>
function Test-SqlCmdlets
{
  $rgname = "testResourceGroupName"
  $preferedlocation = "East US"
  $locationlist = "East US", "West US"
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgname  -Location $preferedlocation

  $cosmosDBAccountName1 = "testcosmosdbaccountpowershellcmdlets" 

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName1 -Location  $locationlist
  Assert-AreEqual $cosmosDBAccountName1 $cosmosDBAccount.Name

  $sqlDatabaseName = "testsqldb"
  $cosmosDBSqlDatabase = Set-AzCosmosDBSqlDatabase -AccountName $cosmosDBAccountName1 -Name  $sqlDatabaseName -ResourceGroupName $rgname
  Assert-AreEqual $sqlDatabaseName $cosmosDBSqlDatabase.SqlDatabaseId

  $sqlContainerName = "testcontainer"
  $cosmosDBSqlContainer = Set-AzCosmosDBSqlContainer -AccountName $cosmosDBAccountName1 -DatabaseName $sqlDatabaseName -Name $sqlContainerName -ResourceGroupName $rgname -TtlInSeconds 10
  Assert-AreEqual $sqlContainerName $cosmosDBSqlContainer.SqlContainerId
}