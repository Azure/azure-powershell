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

function Test-AccountRelatedCmdlets
{
  $rgName = "CosmosDBResourceGroup89"
  $location = "East US"
  $locationlist = "East US", "West US"
  $locationlist2 = "East US", "UK South", "UK West", "South India"
  $locationlist3 = "West US", "East US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  $cosmosDBAccountName = "cosmosdb67"

  #use an existing account with the following information for Account Update Operations
  $cosmosDBExistingAccountName = "dbaccount30" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $IpRule = "201.168.50.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}
  $publicNetworkAccess = "Enabled"
  $networkAclBypass = "AzureServices"
  $networkAclBypassResourceId = "/subscriptions/subId/resourcegroups/rgName/providers/Microsoft.Synapse/workspaces/workspaceName"

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -Location $location -IpRule $IpRule -Tag $tags -EnableVirtualNetwork  -EnableMultipleWriteLocations  -EnableAutomaticFailover -ApiKind "MongoDB" -PublicNetworkAccess $publicNetworkAccess -EnableFreeTier 0 -EnableAnalyticalStorage 0 -ServerVersion "3.2" -NetworkAclBypass $NetworkAclBypass
  
  Assert-AreEqual $cosmosDBAccountName $cosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $cosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $cosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $cosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $cosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $cosmosDBAccount.EnableMultipleWriteLocations 1
  Assert-AreEqual $cosmosDBAccount.IsVirtualNetworkFilterEnabled 1
  Assert-AreEqual $cosmosDBAccount.PublicNetworkAccess $publicNetworkAccess
  Assert-AreEqual $cosmosDBAccount.ApiProperties.ServerVersion "3.2"
  Assert-AreEqual $cosmosDBAccount.EnableAnalyticalStorage 0
  Assert-AreEqual $cosmosDBAccount.EnableFreeTier 0
  Assert-AreEqual $cosmosDBAccount.NetworkAclBypass $NetworkAclBypass
  Assert-AreEqual $cosmosDBAccount.NetworkAclBypassResourceIds.Count 0

  # create an existing database
  Try {
    $NewDuplicateCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -Location $location -IpRule $IpRule -Tag $tags -EnableVirtualNetwork  -EnableMultipleWriteLocations  -EnableAutomaticFailover -ApiKind "MongoDB" -PublicNetworkAccess $publicNetworkAccess -EnableFreeTier 0 -EnableAnalyticalStorage 0 -ServerVersion "3.2"
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRule $IpRule -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 -PublicNetworkAccess $publicNetworkAccess -NetworkAclBypass $NetworkAclBypass -NetworkAclBypassResourceId $networkAclBypassResourceId

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1
  Assert-AreEqual $updatedCosmosDBAccount.PublicNetworkAccess $publicNetworkAccess
  Assert-AreEqual $updatedCosmosDBAccount.NetworkAclBypass $NetworkAclBypass
  Assert-AreEqual $updatedCosmosDBAccount.NetworkAclBypassResourceIds.Count 1

  $cosmosDBAccountKey = Get-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname
  Assert-NotNull $cosmosDBAccountKey

  $cosmosDBAccountConnectionStrings = Get-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname -Type "ConnectionStrings"
  Assert-NotNull $cosmosDBAccountConnectionStrings

  $cosmosDBAccountReadOnlyKeys = Get-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname -Type "ReadOnlyKeys"
  Assert-NotNull $cosmosDBAccountReadOnlyKeys

  $RegeneratedKey = New-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname -KeyKind "primary"
  Assert-NotNull $RegeneratedKey 

  $IsAccountDeleted = Remove-AzCosmosDBAccount -Name $cosmosDBAccountName -ResourceGroupName $rgName -PassThru
  Assert-AreEqual $IsAccountDeleted true
}

function Test-AccountRelatedCmdletsUsingRid
{
  $FailoverPolicy = "UK West", "East US", "UK South", "South India"
  $locationlist2 = "UK South"

  #use an existing account with the following properties
  $cosmosDBExistingAccountName = "dbaccount27" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $IpRule = "201.168.50.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
  $cosmosDBAccountByRid = Get-AzCosmosDBAccount -ResourceId $cosmosDBAccount.Id

  Assert-AreEqual $cosmosDBAccountByRid.Name $cosmosDBAccount.Name
  Assert-AreEqual $cosmosDBAccountByRid.ConsistencyPolicy.DefaultConsistencyLevel $cosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual $cosmosDBAccountByRid.ConsistencyPolicy.MaxIntervalInSeconds $cosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual $cosmosDBAccountByRid.ConsistencyPolicy.MaxStalenessPrefix $cosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $cosmosDBAccountByRid.EnableAutomaticFailover $cosmosDBAccount.EnableAutomaticFailover 
  Assert-AreEqual $cosmosDBAccountByRid.EnableMultipleWriteLocations $cosmosDBAccount.EnableMultipleWriteLocations
  Assert-AreEqual $cosmosDBAccountByRid.IsVirtualNetworkFilterEnabled $cosmosDBAccount.IsVirtualNetworkFilterEnabled

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceId $cosmosDBAccount.Id -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRule $IpRule -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
      do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $cosmosDBAccountKey = Get-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id
  Assert-NotNull $cosmosDBAccountKey

  $cosmosDBAccountConnectionStrings = Get-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id -Type "ConnectionStrings"
  Assert-NotNull $cosmosDBAccountConnectionStrings

  $cosmosDBAccountReadOnlyKeys = Get-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id -Type "ReadOnlyKeys"
  Assert-NotNull $cosmosDBAccountReadOnlyKeys

  $RegeneratedKey = New-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id -KeyKind "secondaryReadonly"
  Assert-NotNull $RegeneratedKey
}

function Test-AccountRelatedCmdletsUsingObject
{
  #use an existing account with the following properties
  $cosmosDBExistingAccountName = "dbaccount27" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $IpRule = "201.168.50.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
 
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -InputObject $cosmosDBAccount -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRule $IpRule -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
      do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $cosmosDBAccountKey = Get-AzCosmosDBAccountKey -InputObject $cosmosDBAccount
  Assert-NotNull $cosmosDBAccountKey

  $cosmosDBAccountConnectionStrings = Get-AzCosmosDBAccountKey -InputObject $cosmosDBAccount -Type "ConnectionStrings"
  Assert-NotNull $cosmosDBAccountConnectionStrings

  $cosmosDBAccountReadOnlyKeys = Get-AzCosmosDBAccountKey -InputObject $cosmosDBAccount -Type "ReadOnlyKeys"
  Assert-NotNull $cosmosDBAccountReadOnlyKeys

  $RegeneratedKey = New-AzCosmosDBAccountKey -InputObject $cosmosDBAccount -KeyKind "primaryReadonly" 
  Assert-NotNull $RegeneratedKey

  $IsAccountDeleted = Remove-AzCosmosDBAccount -InputObject $cosmosDBAccount -PassThru
  Assert-AreEqual $IsAccountDeleted true
}

function Test-AddRegionOperation
{
  $rgName = "CosmosDBResourceGroup4"
  $location = "East US"
  $locationlist = "East US", "West US"
  $cosmosDBAccountName = "testupdateregionpowershell"
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location $location

  try {
      try {  
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $location  -EnableMultipleWriteLocations  -EnableAutomaticFailover
        do 
        {
            $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
        } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")
      }
        Catch{
            Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
        }

    $updatedCosmosDBAccount = Update-AzCosmosDBAccountRegion -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $locationlist
    $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
    Assert-AreEqual $cosmosDBAccount.Locations.Count $updatedCosmosDBAccount.Locations.Count - 1 
   }
  finally{
      #unable to delete account immediately after adding region
      #Remove-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  }
}

function Test-PrivateEndpoint
{
  # Setup
  $location = "East US"
  $peName = "mype";
  $storageAccount = "xdmsa2";
  $vnetName = "MyVnetPE"
	
  $cosmosDBAccountName = "db945" 
  $rgname = "CosmosDBResourceGroup9507"

  try{
      $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName
      $resourceId = $cosmosDBAccount.Id

      $peSubnet = New-AzVirtualNetworkSubnetConfig -Name peSubnet -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
      $vnetPE = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $peSubnet
        
      $plsConnection= New-AzPrivateLinkServiceConnection -Name plsConnection -PrivateLinkServiceId  $resourceId -GroupId 'Sql'
      $privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName $rgname -Name $peName -Location $location -Subnet $vnetPE.subnets[0] -PrivateLinkServiceConnection $plsConnection -ByManualRequest

      $pecGet = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
      Assert-NotNull $pecGet;
      Assert-AreEqual "Pending" $pecGet.PrivateLinkServiceConnectionState.Status

      # Approve Private Endpoint Connection
      $pecApprove = Approve-AzPrivateEndpointConnection -ResourceId $pecGet.Id
      Assert-NotNull $pecApprove;

      $pecGet2 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
      do 
      {
        $pecGet2 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
      } while ($pecGet2.PrivateLinkServiceConnectionState.Status -ne "Approved")

      # Remove Private Endpoint Connection
      $pecRemove = Remove-AzPrivateEndpointConnection -ResourceId $pecGet.Id -PassThru -Force
      Assert-AreEqual true $pecRemove

      $pecGet3 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
      do 
      {
        $pecGet3 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $resourceId
      } while (($pecGet3) -ne $null)
  }
  finally{
      Remove-AzPrivateEndpoint -ResourceGroupName $rgname -Name $peName -Force
      Remove-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Force
  }
}
