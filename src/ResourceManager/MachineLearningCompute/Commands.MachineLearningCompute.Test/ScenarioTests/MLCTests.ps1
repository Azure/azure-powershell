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

function TeardownTest([String] $ResourceGroupName)
{
    Write-Debug "Delete resource group"
    Write-Debug " Resource Group Name : $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $ResourceGroupName -Force

	foreach ($g in Find-AzureRmResourceGroup)
	{
		if ($g.Name -match "$ResourceGroupName-azureml-\w{5}")
		{
			Write-Debug "Deleting managed by resource group: $($g.Name)"
			Remove-AzureRmResourceGroup -Name $g.Name -Force
		}
	}
}

<#
.SYNOPSIS
Tests creating, getting, and removing an operationalization cluster.
#>
function Test-NewGetRemove
{
    # Setup
    $resourceGroupName = "mlcrp-cmdlet-test-new-get-remove"
    $clusterName = "mlcrp-cmdlet-test-new-get-remove"

    SetupTest $resourceGroupName

    # Create the cluster
    $result = New-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location "East US 2 EUAP" `
		-ClusterType "ACS" -Description "Powershell test cluster" -OrchestratorType "Kubernetes" `
		-ClientId "2eca32f5-01fc-4778-ba29-d6b6ecbee43b" -Secret "18p/wFeFaDBpakQw1eBqDejXa5jpB+EjI9ekQOzvUW0=" `
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

    # Remove the cluster
    Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName | Remove-AzureRmMlOpCluster 

    Assert-ThrowsContains { Get-AzureRmMlOpCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

    # Cleanup
    TeardownTest $resourceGroupName
}

<#
.SYNOPSIS
Tests getting the access keys of an operationalization cluster.
#>
function Test-GetKeys
{
    # Setup
    $resourceGroupName = "mlcrp-cmdlet-test-keys"
    $clusterName = "mlcrp-cmdlet-test-keys"

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
    TeardownTest $resourceGroupName
}

<#
.SYNOPSIS
Tests checking if there is an update available for a operationalization cluster's system services.
#>
function Test-UpdateSystemServices
{
    # Setup
    $resourceGroupName = "mlcrp-cmdlet-test-system-update"
    $clusterName = "mlcrp-cmdlet-test-system-update"

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

    ## Cleanup
    TeardownTest $resourceGroupName
}