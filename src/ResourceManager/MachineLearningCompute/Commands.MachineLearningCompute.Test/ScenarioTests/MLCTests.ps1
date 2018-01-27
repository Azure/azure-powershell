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
Creates an operationalization cluster for use in tests.
#>
function GetDefaultClusterProperties
{
    $orchestratorType = "Kubernetes"
    $location = "East US 2 EUAP"
    $clusterType = "ACS"
    $description = "Deployed from powershell"

    $containerServiceProps = New-Object Microsoft.Azure.Management.MachineLearningCompute.Models.AcsClusterProperties($orchestratorType)
    $cluster = New-Object Microsoft.Azure.Management.MachineLearningCompute.Models.OperationalizationCluster `
		-Property @{Location = $location; ClusterType = $clusterType; ContainerService = $containerServiceProps; Description = $description}

	$psCluster = New-Object Microsoft.Azure.Commands.MachineLearningCompute.Models.PSOperationalizationCluster($cluster)

    return $psCluster
}

<#
.SYNOPSIS
Creates a local operationalization cluster for use in tests.
#>
function GetDefaultLocalClusterProperties
{
    $location = "East US 2 EUAP"
    $clusterType = "Local"
    $description = "Deployed from powershell"

    $cluster = New-Object Microsoft.Azure.Management.MachineLearningCompute.Models.OperationalizationCluster `
		-Property @{Location = $location; ClusterType = $clusterType; Description = $description}

	$psCluster = New-Object Microsoft.Azure.Commands.MachineLearningCompute.Models.PSOperationalizationCluster($cluster)

    return $psCluster
}

<#
.SYNOPSIS
Creates a resource group for the test to be run in.
#>
function SetupTest([String] $ResourceGroupName, [String] $Location = "East US 2")
{
    Write-Debug "Create resource group"
    Write-Debug " Resource Group Name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location -Force
}

<#
.SYNOPSIS
Deletes all resources created by the tests.
#>
function TeardownTest([String] $ResourceGroupName, [String] $ManagedByResourceGroupName)
{
	if (!$ManagedByResourceGroupName)
	{
		$ManagedByResourceGroupName = GetManagedByResourceGroupName -ResourceGroupName $ResourceGroupName
	}

    Write-Debug "Delete resource group"
    Write-Debug " Resource Group Name : $ResourceGroupName"
    Remove-AzureRmResourceGroup -Name $ResourceGroupName -Force

	Write-Debug "Deleting managed by resource group: $ManagedByResourceGroupName"
	Remove-AzureRmResourceGroup -Name $ManagedByResourceGroupName -Force
}

<#
.SYNOPSIS
Deletes all resources created by the tests.
#>
function GetUniqueName([String] $prefix)
{
	$suffix = getAssetName
	return "$prefix-$suffix"
}

<#
.SYNOPSIS
Gets the managed by resource group name
#>
function GetManagedByResourceGroupName([String] $ResourceGroupName)
{
	$cluster = Get-AzureRmMlOpCluster -ResourceGroupName $ResourceGroupName
	$success = $cluster.StorageAccount.ResourceId -match "$ResourceGroupName-azureml-\w{5}"
	$managedByResourceGroupName = $matches[0]
	return $managedByResourceGroupName
}

<#
.SYNOPSIS
Tests creating, getting, and removing an operationalization cluster.
#>
function Test-NewGetRemove
{
    # Setup
    $resourceGroupName = GetUniqueName("mlcrp-cmdlet-test-new")
    $clusterName = GetUniqueName("mlcrp-cmdlet-test-new")

    SetupTest $resourceGroupName

    # Create the cluster
    $result = New-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location "East US 2" `
		-ClusterType "ACS" -Description "Powershell test cluster" -OrchestratorType "Kubernetes" `
		-ClientId "00000000-0000-0000-0000-000000000000" -Secret "abcde" `
		-MasterCount 1 -AgentCount 2 -AgentVmSize Standard_D3_v2

    Assert-True { $result.ProvisioningState -eq "Succeeded" }
    
    # Get the cluster
    $result = Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName

    Assert-True { $result.ProvisioningState -eq "Succeeded" }

    # Get the cluster by resource group name
    $result = Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName

    Assert-NotNull { $result }
    $clusterExists = $False

    Foreach ($c in $result)
    {
        If ($c.Name -eq $clusterName)
        {
            $clusterExists = $True
        }
    }

    Assert-True { $clusterExists }

    # Get the cluster by listing the clusters in the subscription
    $result = Get-AzureRmMlOpCluster

    $clusterExists = $False

    Foreach ($c in $result)
    {
        If ($c.Name -eq $clusterName)
        {
            $clusterExists = $True
        }
    }

    Assert-True { $clusterExists }

	# Get the managed by resource group name before deleting
	$managedByResourceGroupName = GetManagedByResourceGroupName -ResourceGroupName $resourceGroupName

    # Remove the cluster
    Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName | Remove-AzureRmMlOpCluster 

    Assert-ThrowsContains { Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

    # Cleanup
    TeardownTest -ResourceGroupName $resourceGroupName -ManagedByResourceGroupName $managedByResourceGroupName
}

<#
.SYNOPSIS
Tests getting the access keys of an operationalization cluster.
#>
function Test-GetKeys
{
    # Setup
    $resourceGroupName = GetUniqueName("mlcrp-cmdlet-test-keys")
    $clusterName = GetUniqueName("mlcrp-cmdlet-test-keys")

    SetupTest $resourceGroupName

    # Create the cluster
    $cluster = GetDefaultClusterProperties
    $result = New-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Cluster $cluster

    Assert-True { $result.ProvisioningState -eq "Succeeded" }

    # Get the keys
    $keys = Get-AzureRmMlOpClusterKey -ResourceGroupName $resourceGroupName -Name $clusterName

    Assert-NotNull { $keys.StorageAccount.ResourceId }
    Assert-NotNull { $keys.StorageAccount.PrimaryKey }
    Assert-NotNull { $keys.StorageAccount.SecondaryKey }

    Assert-NotNull { $keys.ContainerRegistry.LoginServer }
    Assert-NotNull { $keys.ContainerRegistry.Password }
    Assert-NotNull { $keys.ContainerRegistry.Password2 }
    Assert-NotNull { $keys.ContainerRegistry.Username }

    Assert-NotNull { $keys.ContainerService.AcsKubeConfig }
    Assert-NotNull { $keys.ContainerService.ImagePullSecretName }

    Assert-NotNull { $keys.AppInsights.AppId }
    Assert-NotNull { $keys.AppInsights.InstrumentationKey }

    # Get the keys - pipelining
    $keys = Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName | Get-AzureRmMlOpClusterKey

    Assert-NotNull { $keys.StorageAccount.ResourceId }
    Assert-NotNull { $keys.StorageAccount.PrimaryKey }
    Assert-NotNull { $keys.StorageAccount.SecondaryKey }

    Assert-NotNull { $keys.ContainerRegistry.LoginServer }
    Assert-NotNull { $keys.ContainerRegistry.Password }
    Assert-NotNull { $keys.ContainerRegistry.Password2 }
    Assert-NotNull { $keys.ContainerRegistry.Username }

    Assert-NotNull { $keys.ContainerService.AcsKubeConfig }
    Assert-NotNull { $keys.ContainerService.ImagePullSecretName }

    Assert-NotNull { $keys.AppInsights.AppId }
    Assert-NotNull { $keys.AppInsights.InstrumentationKey }

    # Cleanup
    TeardownTest -ResourceGroupName $resourceGroupName
}

<#
.SYNOPSIS
Tests checking if there is an update available for a operationalization cluster's system services.
#>
function Test-UpdateSystemServices
{
    # Setup
    $resourceGroupName = GetUniqueName("mlcrp-cmdlet-test-system-update")
    $clusterName = GetUniqueName("mlcrp-cmdlet-test-system-update")

    SetupTest $resourceGroupName

    # Create the cluster
    $cluster = GetDefaultClusterProperties
    $result = New-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Cluster $cluster

	# Test for updates
	$updateAvailability = Test-AzureRmMlOpClusterSystemServicesUpdateAvailability -ResourceGroupName $resourceGroupName -Name $clusterName
    Assert-NotNull { $updateAvailability }

	# Test for updates - pipelining
	$updateAvailability = Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName | Test-AzureRmMlOpClusterSystemServicesUpdateAvailability 
    Assert-NotNull { $updateAvailability }

	# Update the cluster
	$updateResult = Update-AzureRmMlOpClusterSystemService -ResourceGroupName $resourceGroupName -Name $clusterName
    Assert-True { $updateResult.UpdateStatus -eq "Succeeded" }
	Assert-NotNull { $updateResult.UpdateStartedOn }
	Assert-NotNull { $updateResult.UpdateCompletedOn }

	$updateAvailability = Test-AzureRmMlOpClusterSystemServicesUpdateAvailability -ResourceGroupName $resourceGroupName -Name $clusterName
    Assert-True { $updateAvailability.UpdatesAvailable -eq "No" }

    # Cleanup
    TeardownTest -ResourceGroupName $resourceGroupName
}

<#
.SYNOPSIS
Tests setting the properties of an operationalization cluster.
#>
function Test-Set
{
    # Setup
    $resourceGroupName = GetUniqueName("mlcrp-cmdlet-test-set")
    $clusterName = GetUniqueName("mlcrp-cmdlet-test-set")

    SetupTest $resourceGroupName

    # Create the cluster
    $cluster = GetDefaultClusterProperties
    $createdCluster = New-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Cluster $cluster

	# Update the cluster
	$newAgentCount = $createdCluster.ContainerService.AgentCount + 1
	$updatedCluster = Set-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -AgentCount $newAgentCount
    Assert-True { $updatedCluster.ProvisioningState -eq "Succeeded" }
	Assert-True { $updatedCluster.ContainerService.AgentCount -eq $newAgentCount }

	# Update the cluster with input object
	$newAgentCount = $newAgentCount - 1
	$updatedCluster.ContainerService.AgentCount = $newAgentCount
	$updatedCluster = Set-AzureRmMlOpCluster -InputObject $updatedCluster
    Assert-True { $updatedCluster.ProvisioningState -eq "Succeeded" }
	Assert-True { $updatedCluster.ContainerService.AgentCount -eq $newAgentCount }

	# Update the cluster with resource id
	$newAgentCount = $newAgentCount + 1
	$updatedCluster = Set-AzureRmMlOpCluster -ResourceId $updatedCluster.Id -AgentCount $newAgentCount
    Assert-True { $updatedCluster.ProvisioningState -eq "Succeeded" }
	Assert-True { $updatedCluster.ContainerService.AgentCount -eq $newAgentCount }

    # Cleanup
    TeardownTest -ResourceGroupName $resourceGroupName
}

function Test-RemoveIncludeAllResources
{
    $resourceGroupName = GetUniqueName("mlcrp-cmdlet-test-remove-all")
    $clusterName = GetUniqueName("mlcrp-cmdlet-test-remove-all")

    SetupTest $resourceGroupName

    # Create the cluster
    $cluster = GetDefaultLocalClusterProperties
    $createdCluster = New-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Cluster $cluster

	# Get the managed by resource group name before deleting
	$managedByResourceGroupName = GetManagedByResourceGroupName -ResourceGroupName $resourceGroupName

	# Delete the cluster
	Remove-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -IncludeAllResources

    Assert-Throws ( Get-AzureRmResourceGroup -ResourceGroupName $managedByResourceGroupName )

    # Cleanup
	Remove-AzureRmResourceGroup -ResourceGroupName $resourceGroupName -Force
}
