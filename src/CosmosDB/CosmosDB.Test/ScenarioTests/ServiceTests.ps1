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
Test Service CRUD operations using Name parameter set
#>

function Test-ServiceRelatedCmdlets{
  $resourceGroupName = "cdbrg-service-sqld"
  $accountName = "cdbacct-service-sqld"
  $location = "East US 2"
  $serviceName = "sqlDedicatedGateway"
  $instanceSize = "Cosmos.D4s"
  $instanceCount = "1"

  Try
  {
    New-AzResourceGroup -ResourceGroupName $resourceGroupName -Location $location
    $account = New-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName -Location $location
    $service = New-AzCosmosDBService -ResourceGroupName $resourceGroupName -AccountName $accountName -ServiceName $serviceName -InstanceCount $instanceCount -InstanceSize $instanceSize
    Assert-AreEqual $service.InstanceCount $instanceCount

    $service = Get-AzCosmosDBService -ResourceGroupName $resourceGroupName -AccountName $accountName -ServiceName $serviceName
    Assert-AreEqual $service.InstanceCount $instanceCount

    Remove-AzCosmosDBService -ResourceGroupName $resourceGroupName -AccountName $accountName -ServiceName $serviceName
  }
  Finally
  {
    Remove-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName
    Remove-AzResourceGroup -Name $resourceGroupName
  }
}
