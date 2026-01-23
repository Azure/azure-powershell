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
Test Fleet CRUD cmdlets using Name parameter set
#>
function Test-FleetCreateUpdateGetCmdlets
{
  $rgName = "CosmosDBFleetResourceGroup01"
  $FleetName = "fleet001"
  $FleetName2 = "fleet002"
  $location = "East US"

  Try {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

      # Create a new fleet
      $NewFleet = New-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName -Location $location
      Assert-AreEqual $NewFleet.Name $FleetName
      Assert-NotNull $NewFleet.Properties
      Assert-NotNull $NewFleet.Id

      # Get an existing fleet
      $Fleet = Get-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName
      Assert-AreEqual $NewFleet.Id $Fleet.Id
      Assert-AreEqual $NewFleet.Name $Fleet.Name
      Assert-NotNull $Fleet.Properties

      # List all fleets under the resource group
      $ListFleets = Get-AzCosmosDBFleet -ResourceGroupName $rgName
      Assert-NotNull($ListFleets)
      Assert-True { $ListFleets.Count -ge 1 }

      # List all fleets under subscription
      $ListAllFleets = Get-AzCosmosDBFleet
      Assert-NotNull($ListAllFleets)

      # Delete a fleet
      $IsFleetRemoved = Remove-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName -PassThru
      Assert-AreEqual $IsFleetRemoved $true
  }
  Finally {
      Remove-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName
      Remove-AzResourceGroup -ResourceGroupName $rgName -Force
  }
}

<#
.SYNOPSIS
Test Fleet with tags
#>
function Test-FleetWithTags
{
  $rgName = "CosmosDBFleetResourceGroup04"
  $FleetName = "fleet005"
  $location = "East US"
  
  $tags = @{
      "Environment" = "Test"
      "Department" = "Engineering"
      "Project" = "FleetTesting"
  }

  Try {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

      # Create a new fleet with tags
      $NewFleet = New-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName -Location $location -Tag $tags
      Assert-AreEqual $NewFleet.Name $FleetName
      Assert-NotNull $NewFleet.Tags
      Assert-AreEqual $NewFleet.Tags["Environment"] "Test"
      Assert-AreEqual $NewFleet.Tags["Department"] "Engineering"

      # Get fleet and verify tags
      $Fleet = Get-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName
      Assert-AreEqual $Fleet.Tags["Environment"] "Test"

      # Delete fleet
      Remove-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName -PassThru
  }
  Finally {
      Remove-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName
      Remove-AzResourceGroup -ResourceGroupName $rgName -Force
  }
}
