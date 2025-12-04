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
Test Fleetspace CRUD cmdlets
#>
function Test-FleetspaceCreateUpdateGetCmdlets
{
  $rgName = "CosmosDBFleetResourceGroup05fs"
  $FleetName = "fleet006"
  $FleetspaceName = "fleetspace001"
  $location = "West Central US"

  Try {
      # Create resource group and fleet
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
      $NewFleet = New-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName -Location $location
      Start-TestSleep -Seconds 30

      # Create a new fleetspace
      $NewFleetspace = New-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName -FleetspaceApiKind "NoSQL" -ServiceTier "GeneralPurpose" -DataRegion @("westcentralus") -ThroughputPoolMinThroughput 100000 -ThroughputPoolMaxThroughput 1000000
      Start-TestSleep -Seconds 30
      Assert-AreEqual $NewFleetspace.Name $FleetspaceName
      Assert-AreEqual $NewFleetspace.FleetspaceApiKind "NoSQL"
      Assert-AreEqual $NewFleetspace.ServiceTier "GeneralPurpose"
      Assert-NotNull $NewFleetspace.Id

      # Get an existing fleetspace
      $Fleetspace = Get-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName
      Assert-AreEqual $NewFleetspace.Id $Fleetspace.Id
      Assert-AreEqual $NewFleetspace.Name $Fleetspace.Name
      Assert-NotNull $Fleetspace.DataRegions

      # Update fleetspace throughput
      $UpdatedFleetspace = Update-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName -ThroughputPoolMinThroughput 2000 -ThroughputPoolMaxThroughput 15000
      Assert-AreEqual $UpdatedFleetspace.Name $FleetspaceName
      Assert-AreEqual $UpdatedFleetspace.ThroughputPoolConfiguration.MinThroughput 2000
      Assert-AreEqual $UpdatedFleetspace.ThroughputPoolConfiguration.MaxThroughput 15000

      # List all fleetspaces under fleet
      $ListFleetspaces = Get-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName
      Assert-NotNull($ListFleetspaces)
      Assert-True { $ListFleetspaces.Count -ge 1 }

      # Delete a fleetspace
      $IsFleetspaceRemoved = Remove-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName -PassThru
      Assert-AreEqual $IsFleetspaceRemoved $true
  }
  Finally {
      Remove-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName
      Remove-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName
      Remove-AzResourceGroup -ResourceGroupName $rgName -Force
  }
}

<#
.SYNOPSIS
Test FleetspaceAccount CRUD cmdlets
#>
function Test-FleetspaceAccountCmdlets
{
  $rgName = "CosmosDBFleetResourceGroup07fsa"
  $FleetName = "fleet008"
  $FleetspaceName = "fleetspace003"
  $FleetspaceAccountName = "fleetaccount001"
  $AccountName = "cosmosdb-account-001"
  $location = "West Central US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
      # Create resource group, fleet, and fleetspace
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
      $NewFleet = New-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName -Location $location
      Start-TestSleep -Seconds 30
      $NewFleetspace = New-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName -FleetspaceApiKind "NoSQL" -ServiceTier "GeneralPurpose" -DataRegion @("eastus")
      Start-TestSleep -Seconds 30

      # Create a CosmosDB account to associate
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
      Wait-CosmosAccountProvisioned -ResourceGroupName $rgName -AccountName $AccountName

      # Get the account to obtain resource ID and location
      $account = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
      
      # Add fleetspace account
      $NewFleetspaceAccount = Add-AzCosmosDBFleetspaceAccount -ResourceGroupName $rgName -FleetName $FleetName -FleetspaceName $FleetspaceName -Name $FleetspaceAccountName -GlobalDatabaseAccountResourceId $account.Id -GlobalDatabaseAccountLocation $account.Location
      Assert-AreEqual $NewFleetspaceAccount.Name $FleetspaceAccountName
      Assert-NotNull $NewFleetspaceAccount.GlobalDatabaseAccountProperties

      # Get fleetspace account
      $FleetspaceAccount = Get-AzCosmosDBFleetspaceAccount -ResourceGroupName $rgName -FleetName $FleetName -FleetspaceName $FleetspaceName -Name $FleetspaceAccountName
      Assert-AreEqual $NewFleetspaceAccount.Id $FleetspaceAccount.Id

      # List all fleetspace accounts
      $ListAccounts = Get-AzCosmosDBFleetspaceAccount -ResourceGroupName $rgName -FleetName $FleetName -FleetspaceName $FleetspaceName
      Assert-NotNull($ListAccounts)
      Assert-True { $ListAccounts.Count -ge 1 }

      # Remove fleetspace account
      $IsRemoved = Remove-AzCosmosDBFleetspaceAccount -ResourceGroupName $rgName -FleetName $FleetName -FleetspaceName $FleetspaceName -Name $FleetspaceAccountName -PassThru
      Assert-AreEqual $IsRemoved $true
  }
  Finally {
      Remove-AzCosmosDBFleetspaceAccount -ResourceGroupName $rgName -FleetName $FleetName -FleetspaceName $FleetspaceName -Name $FleetspaceAccountName
      Remove-AzCosmosDBFleetspace -ResourceGroupName $rgName -FleetName $FleetName -Name $FleetspaceName
      Remove-AzCosmosDBFleet -ResourceGroupName $rgName -Name $FleetName
      Remove-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
      Remove-AzResourceGroup -ResourceGroupName $rgName -Force
  }
}

<#
.SYNOPSIS
Helper function to wait for Cosmos DB account provisioning
#>
function Wait-CosmosAccountProvisioned {
    param(
        [Parameter(Mandatory = $true)][string]$ResourceGroupName,
        [Parameter(Mandatory = $true)][string]$AccountName,
        [int]$TimeoutSeconds = 600,
        [int]$PollIntervalSeconds = 10
    )
    $start = Get-Date
    while($true) {
        try {
            $acct = Get-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName -Name $AccountName -ErrorAction Stop
            if ($acct -and $acct.ProvisioningState -eq 'Succeeded') { return }
        } catch {
            # swallow transient errors while resource propagates
        }
        if ((Get-Date) -gt $start.AddSeconds($TimeoutSeconds)) {
            throw "Cosmos DB account '$AccountName' in resource group '$ResourceGroupName' did not reach ProvisioningState=Succeeded within $TimeoutSeconds seconds."
        }
        Start-TestSleep -s $PollIntervalSeconds
    }
}
