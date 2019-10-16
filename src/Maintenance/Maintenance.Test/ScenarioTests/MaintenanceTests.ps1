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
Test New-AzMaintenanceConfiguration, Get-AzMaintenanceConfiguration, Remove-AzMaintenanceConfiguration
#>
function Test-AzureRmMaintenanceConfiguration
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = Get-ProviderLocation "Microsoft.Maintenance/MaintenanceConfigurations"
    $maintenanceScope = "Host"
	$maintenanceConfiguration = New-object


    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope

        Assert-AreEqual $maintenanceConfigurationCreated.ResourceGroupName $resourceGroupName
        Assert-AreEqual $maintenanceConfigurationCreated.Name $maintenanceConfigurationName
        Assert-AreEqual $maintenanceConfigurationCreated.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated.MaintenanceScope $maintenanceScope


        $retrievedMaintenanceConfiguration = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $retrievedMaintenanceConfiguration

        $retrievedMaintenanceConfigurationList = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName
        Assert-AreEqual $retrievedMaintenanceConfigurationList.Count 1
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $retrievedMaintenanceConfigurationList[0]

        $retrievedMaintenanceConfiguration | Remove-AzMaintenanceConfiguration
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test New-AzMaintenanceConfiguration, Get-AzMaintenanceConfiguration, Remove-AzMaintenanceConfiguration
#>
function Test-AzureRmMaintenanceConfigurationWithResourceScope
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = Get-ProviderLocation "Microsoft.Maintenance/MaintenanceConfigurations"
    $maintenanceScope = "Resource"


    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope

        Assert-AreEqual $maintenanceConfigurationCreated.ResourceGroupName $resourceGroupName
        Assert-AreEqual $maintenanceConfigurationCreated.Name $maintenanceConfigurationName
        Assert-AreEqual $maintenanceConfigurationCreated.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated.MaintenanceScope $maintenanceScope


        $retrievedMaintenanceConfiguration = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $retrievedMaintenanceConfiguration

        $retrievedMaintenanceConfigurationList = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName
        Assert-AreEqual $retrievedMaintenanceConfigurationList.Count 1
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $retrievedMaintenanceConfigurationList[0]

        $retrievedMaintenanceConfiguration | Remove-AzMaintenanceConfiguration
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}


<#
.SYNOPSIS
Assert a maintenace configuration object.

.PARAMETER expected
The expected maintenace configuration object.

.PARAMETER actual
The actual maintenace configuration object.
#>
function Assert-MaintenanceConfiguration
{
    Param
    (
        [parameter(position=0)]
        $Expected,
        [parameter(position=1)]
        $Actual
    )

    Assert-AreEqual $Actual.ResourceGroupName $Expected.ResourceGroupName
    Assert-AreEqual $Actual.Name $Expected.Name
    Assert-AreEqual $Actual.Location $Expected.Location
    Assert-AreEqual $Actual.MaintenanceType $Expected.MaintenanceType
}