﻿# ----------------------------------------------------------------------------------
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
function Test-AzMaintenanceConfiguration
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = Get-ProviderLocation "Microsoft.Maintenance/MaintenanceConfigurations"
    $maintenanceScope = "Host"

    $resourceGroupName1 = Get-RandomResourceGroupName
    $maintenanceConfigurationName1 = Get-RandomMaintenanceConfigurationName  
        
    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
		Write-Host "Created RG $location"

        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location
		Write-Host "Created configuration $maintenanceConfigurationName"
		Write-Output $maintenanceConfigurationCreated

        Assert-AreEqual $maintenanceConfigurationCreated.Name $maintenanceConfigurationName
        Assert-AreEqual $maintenanceConfigurationCreated.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated.MaintenanceScope $maintenanceScope
		Assert-AreEqual $maintenanceConfigurationCreated.Type "Microsoft.Maintenance/MaintenanceConfigurations"

        $retrievedMaintenanceConfiguration = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $retrievedMaintenanceConfiguration

        New-AzResourceGroup -Name $resourceGroupName1 -Location $location
		Write-Host "Created RG $location"

        $maintenanceConfigurationCreated1 = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName1 -MaintenanceScope $maintenanceScope -Location $location
		Write-Host "Created configuration $maintenanceConfigurationName1"
		Write-Output $maintenanceConfigurationCreated1
        
        Assert-AreEqual $maintenanceConfigurationCreated1.Name $maintenanceConfigurationName1
        Assert-AreEqual $maintenanceConfigurationCreated1.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated1.MaintenanceScope $maintenanceScope
		Assert-AreEqual $maintenanceConfigurationCreated1.Type "Microsoft.Maintenance/MaintenanceConfigurations"
        
        $retrievedMaintenanceConfigurationByRG = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $retrievedMaintenanceConfigurationByRG

        $retrievedMaintenanceConfigurationByName = Get-AzMaintenanceConfiguration -Name $maintenanceConfigurationName1
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $retrievedMaintenanceConfigurationByName

        $allRetrievedMaintenanceConfigurations = Get-AzMaintenanceConfiguration
        foreach ($config in $allRetrievedMaintenanceConfigurations) 
        {
            if($config.Name -eq $maintenanceConfigurationName)
            {
                Assert-MaintenanceConfiguration $maintenanceConfigurationCreated $config
            }
            else
            {
                Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $config
            }
        }

        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Force
        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName1 -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
        Clean-ResourceGroup $resourceGroupName1
    }
}

<#
.SYNOPSIS
Test New-AzConfigurationAssignment, Get-AzConfigurationAssignment, Remove-AzConfigurationAssignment
#>
function Test-AzConfigurationAssignment
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = "westus2"
    $maintenanceScope = "Host"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location

		$configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationCreated.Id -Location $location

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationCreated.Id

        $retrievedConfigurationAssignmentList = Get-AzConfigurationAssignment -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute

        Assert-AreEqual $retrievedConfigurationAssignmentList.Count 1
        #Assert-ConfigurationAssignment $configurationAssignmentCreated $retrievedConfigurationAssignmentList[0]

        Remove-AzConfigurationAssignment -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -Force

		Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test New-AzConfigurationAssignment, Get-AzMaintenanceUpdate, Remove-AzConfigurationAssignment
#>
function Test-AzMaintenanceUpdate
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
	$virtualMachineName = Get-RandomMaintenanceConfigurationName
    $location = "westus2"
    $maintenanceScope = "Host"


    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location

		$configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationCreated.Id -Location $location

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationCreated.Id

        $retrievedMaintenanceUpdateList = Get-AzMaintenanceUpdate -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute
		Assert-NotNull $retrievedMaintenanceUpdateList

        Remove-AzConfigurationAssignment -ResourceGroupName smdtest$location -ResourceParentType hostGroups -ResourceParentName smddhg$location -ResourceType hosts -ResourceName smddh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -Force

		Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Force
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

    Assert-AreEqual $Actual.Name $Expected.Name
    Assert-AreEqual $Actual.Location $Expected.Location
    Assert-AreEqual $Actual.MaintenanceType $Expected.MaintenanceType
}

<#
.SYNOPSIS
Assert a configuration assignment object.

.PARAMETER expected
The expected configuration assignment object.

.PARAMETER actual
The actual configuration assignment object.
#>
function Assert-ConfigurationAssignment
{
    Param
    (
        [parameter(position=0)]
        $Expected,
        [parameter(position=1)]
        $Actual
    )

    Assert-AreEqual $Actual.Name $Expected.Name
    Assert-AreEqual $Actual.MaintenanceConfigurationId $Expected.MaintenanceConfigurationId
	Assert-AreEqual $Actual.ResourceId $Expected.ResourceId
}