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
function Test-AzMaintenanceConfiguration
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    #$location = Get-ProviderLocation "Microsoft.Maintenance/MaintenanceConfigurations"
    $location = "eastus2euap"
    $maintenanceScope = "Host"
    $Visibility = "Custom"
    $StartDateTime = "2021-10-09 12:30"
    $Timezone = "Pacific Standard Time"
    $RecurEvery = "Day"
    $Duration = "05:00"
    $ExpirationDateTime = "9999-12-31 23:59";

    $resourceGroupName1 = "powershellrg"
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

        $maintenanceConfigurationCreated1 = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName1 -MaintenanceScope $maintenanceScope -Location $location -Visibility $Visibility -StartDateTime $StartDateTime -RecurEvery $RecurEvery -Timezone $Timezone -ExpirationDateTime $ExpirationDateTime -Duration $Duration
		Write-Host "Created configuration $maintenanceConfigurationName1"
		Write-Output $maintenanceConfigurationCreated1
        
        Assert-AreEqual $maintenanceConfigurationCreated1.Name $maintenanceConfigurationName1
        Assert-AreEqual $maintenanceConfigurationCreated1.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated1.MaintenanceScope $maintenanceScope
		Assert-AreEqual $maintenanceConfigurationCreated1.Type "Microsoft.Maintenance/MaintenanceConfigurations"
        Assert-AreEqual $maintenanceConfigurationCreated1.Visibility $Visibility
        Assert-AreEqual $maintenanceConfigurationCreated1.StartDateTime $StartDateTime
        Assert-AreEqual $maintenanceConfigurationCreated1.ExpirationDateTime $ExpirationDateTime
        Assert-AreEqual $maintenanceConfigurationCreated1.Duration $Duration
        Assert-AreEqual $maintenanceConfigurationCreated1.RecurEvery $RecurEvery
        Assert-AreEqual $maintenanceConfigurationCreated1.Timezone $Timezone
        
        $retrievedMaintenanceConfigurationByRG = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $retrievedMaintenanceConfigurationByRG

        $retrievedMaintenanceConfigurationByName = Get-AzMaintenanceConfiguration -Name $maintenanceConfigurationName1
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $retrievedMaintenanceConfigurationByName

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
Test New-AzMaintenanceConfiguration, Get-AzMaintenanceConfiguration, Remove-AzMaintenanceConfiguration
#>
function Test-AzMaintenanceConfigurationInGuestPatch
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    $maintenanceScope = "InGuestPatch"
    $Visibility = "Custom"
    $StartDateTime = "2021-10-09 12:30"
    $Timezone = "Pacific Standard Time"
    $RecurEvery = "2Months Third Monday Offset3"
    $Duration = "01:00"
    $ExpirationDateTime = "9999-12-31 23:59";
    $WindowsParameterClassificationToInclude = "FeaturePack","ServicePack";
    $WindowParameterKbNumberToInclude = "KB123456","KB123466";
    $WindowParameterKbNumberToExclude = "KB123456","KB123466";
    $RebootOption = "IfRequired";
    $LinuxParameterClassificationToInclude = "Other";
    $LinuxParameterPackageNameMaskToInclude = "apt","httpd";
    $LinuxParameterPackageNameMaskToExclude = "ppt","userpk";
    $PreTask = "[{'source' :'/subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourceGroups/DefaultResourceGroup-EUS/providers/Microsoft.Automation/automationAccounts/Automate-42c974dd-2c03-4f1b-96ad-b07f050aaa74-EUS/runbooks/foo', 'taskScope': 'Global', 'parameters': { 'arg1': 'value1'}}]";
    $PostTask = "[{'source' :'/subscriptions/a18897a6-7e44-457d-9260-f2854c0aca42/resourceGroups/azemailerbackup-rg/providers/Microsoft.Logic/workflows/azemailerdataprotector', 'taskScope': 'Resource', 'parameters': { 'arg1': 'value1'}}]";

    $resourceGroupName1 = "powershellrg"
    $maintenanceConfigurationName1 = Get-RandomMaintenanceConfigurationName  
        
    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        Write-Host "Created RG $location"

        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location -Timezone $Timezone -StartDateTime $StartDateTime -ExpirationDateTime $ExpirationDateTime -Duration $Duration -RecurEvery $RecurEvery -InstallPatchRebootSetting $RebootOption -WindowParameterClassificationToInclude $WindowsParameterClassificationToInclude -WindowParameterKbNumberToInclude $WindowParameterKbNumberToInclude -WindowParameterKbNumberToExclude $WindowParameterKbNumberToExclude -LinuxParameterPackageNameMaskToInclude $LinuxParameterPackageNameMaskToInclude -LinuxParameterClassificationToInclude $LinuxParameterClassificationToInclude -LinuxParameterPackageNameMaskToExclude $LinuxParameterPackageNameMaskToExclude -PreTask $PreTask -PostTask $PostTask

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

        $maintenanceConfigurationCreated1 = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName1 -MaintenanceScope $maintenanceScope -Location $location -Timezone $Timezone -StartDateTime $StartDateTime -ExpirationDateTime $ExpirationDateTime -Duration $Duration -RecurEvery $RecurEvery -InstallPatchRebootSetting $RebootOption -WindowParameterClassificationToInclude $WindowsParameterClassificationToInclude -WindowParameterKbNumberToInclude $WindowParameterKbNumberToInclude -WindowParameterKbNumberToExclude $WindowParameterKbNumberToExclude -LinuxParameterPackageNameMaskToInclude $LinuxParameterPackageNameMaskToInclude -LinuxParameterClassificationToInclude $LinuxParameterClassificationToInclude -LinuxParameterPackageNameMaskToExclude $LinuxParameterPackageNameMaskToExclude -PreTask $PreTask -PostTask $PostTask -WindowParameterExcludeKbRequiringReboot $true

        Write-Host "Created configuration $maintenanceConfigurationName1"
        Write-Output $maintenanceConfigurationCreated1
        
        Write-Host "Get configuration $maintenanceConfigurationName1"

        $maintenanceConfigurationCreated1 = Get-AzMaintenanceConfiguration -ResourceGroup $resourceGroupName1 -Name  $maintenanceConfigurationName1

        Assert-AreEqual $maintenanceConfigurationCreated1.Name $maintenanceConfigurationName1
        Assert-AreEqual $maintenanceConfigurationCreated1.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated1.MaintenanceScope $maintenanceScope
        Assert-AreEqual $maintenanceConfigurationCreated1.Type "Microsoft.Maintenance/MaintenanceConfigurations"
        Assert-AreEqual $maintenanceConfigurationCreated1.Visibility $Visibility
        Assert-AreEqual $maintenanceConfigurationCreated1.StartDateTime $StartDateTime
        Assert-AreEqual $maintenanceConfigurationCreated1.ExpirationDateTime $ExpirationDateTime
        Assert-AreEqual $maintenanceConfigurationCreated1.Duration $Duration
        Assert-AreEqual $maintenanceConfigurationCreated1.RecurEvery $RecurEvery
        Assert-AreEqual $maintenanceConfigurationCreated1.Timezone $Timezone
        Assert-AreEqual $maintenanceConfigurationCreated1.InstallPatchRebootSetting $RebootOption
        Assert-AreEqual $maintenanceConfigurationCreated1.WindowParameterClassificationToInclude.Count 2
        Assert-True { $maintenanceConfigurationCreated1.WindowParameterClassificationToInclude.Contains("FeaturePack") }
        Assert-True { $maintenanceConfigurationCreated1.WindowParameterClassificationToInclude.Contains("ServicePack") }
        Assert-AreEqual $maintenanceConfigurationCreated1.LinuxParameterClassificationToInclude.Count 1
        Assert-True { $maintenanceConfigurationCreated1.LinuxParameterClassificationToInclude.Contains("Other") }
        Assert-AreEqual $maintenanceConfigurationCreated1.LinuxParameterPackageNameMaskToInclude.Count 2
        Assert-True { $maintenanceConfigurationCreated1.LinuxParameterPackageNameMaskToInclude.Contains("apt") }
        Assert-True { $maintenanceConfigurationCreated1.LinuxParameterPackageNameMaskToInclude.Contains("httpd") }
        
        $retrievedMaintenanceConfigurationByRG = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $retrievedMaintenanceConfigurationByRG

        $retrievedMaintenanceConfigurationByName = Get-AzMaintenanceConfiguration -Name $maintenanceConfigurationName1
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $retrievedMaintenanceConfigurationByName

        $allMaintenanceConfigInSubscription = Get-AzMaintenanceConfiguration
        $maintenanceConfigurationNameInstance = $allMaintenanceConfigInSubscription | ?{ $_.Name -eq $maintenanceConfigurationName}

        $maintenanceConfigurationNameInstance.LinuxParameterPackageNameMaskToInclude.Add("package3")

        # Act
        Update-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Configuration  $maintenanceConfigurationNameInstance
        $updatedMRPConfig = Get-AzMaintenanceConfiguration -ResourceGroup $resourceGroupName -Name  $maintenanceConfigurationName

        # Assert
        Assert-AreEqual $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Count 3
        Assert-True { $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Contains("apt") }
        Assert-True { $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Contains("httpd") }
        Assert-True { $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Contains("package3") }

        # Default patch config
        $maintenanceConfigurationName2 = Get-RandomMaintenanceConfigurationName
        $deafultPatchConfig = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName2 -MaintenanceScope $maintenanceScope -Location $location -Timezone $Timezone -StartDateTime $StartDateTime -ExpirationDateTime $ExpirationDateTime -Duration $Duration -RecurEvery $RecurEvery

        Assert-AreEqual $deafultPatchConfig.WindowParameterClassificationToInclude.Count 0
        Assert-AreEqual $deafultPatchConfig.LinuxParameterClassificationToInclude.Count 0
        Assert-AreEqual $deafultPatchConfig.LinuxParameterPackageNameMaskToInclude.Count 0
        
        # Update default patch config
        $deafultPatchConfig.RecurEvery = "6Days"
        Update-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName2 -Configuration  $deafultPatchConfig
        $updatedMRPConfig = Get-AzMaintenanceConfiguration -ResourceGroup $resourceGroupName1 -Name  $maintenanceConfigurationName2

        Assert-AreEqual $updatedMRPConfig.RecurEvery "6Days"
        Assert-AreEqual $updatedMRPConfig.WindowParameterClassificationToInclude.Count 0
        Assert-AreEqual $updatedMRPConfig.LinuxParameterClassificationToInclude.Count 0
        Assert-AreEqual $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Count 0

        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Force
        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName1 -Force
        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName2 -Force
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
Test New-AzMaintenanceConfiguration, Get-AzMaintenancePublicConfiguration, Remove-AzMaintenanceConfiguration
#>
function Test-AzMaintenancePublicConfiguration
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    $maintenanceScope = "SQLDB"
    $Visibility = "Public"
    $StartDateTime = "2022-09-09 12:30"
    $Timezone = "Pacific Standard Time"
    $RecurEvery = "Day"
    $Duration = "05:00"
    $ExtensionProperties = @{}
    $ExtensionProperties.Add('publicMaintenanceConfigurationId', $maintenanceConfigurationName)
    $ExtensionProperties.Add('isAvailable', 'true')

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
		Write-Host "Created RG $location"

        $maintenanceConfigurationCreated1 = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location -Visibility $Visibility -StartDateTime $StartDateTime -RecurEvery $RecurEvery -Timezone $Timezone -ExtensionProperty $ExtensionProperties -Duration $Duration
		Write-Host "Created configuration $maintenanceConfigurationName"
		Write-Output $maintenanceConfigurationCreated1
        
        Assert-AreEqual $maintenanceConfigurationCreated1.Name $maintenanceConfigurationName
        Assert-AreEqual $maintenanceConfigurationCreated1.Location $location
        Assert-AreEqual $maintenanceConfigurationCreated1.MaintenanceScope $maintenanceScope
		Assert-AreEqual $maintenanceConfigurationCreated1.Type "Microsoft.Maintenance/MaintenanceConfigurations"
        Assert-AreEqual $maintenanceConfigurationCreated1.Visibility $Visibility
        Assert-AreEqual $maintenanceConfigurationCreated1.StartDateTime $StartDateTime
        Assert-AreEqual $maintenanceConfigurationCreated1.Duration $Duration
        Assert-AreEqual $maintenanceConfigurationCreated1.RecurEvery $RecurEvery
        Assert-AreEqual $maintenanceConfigurationCreated1.Timezone $Timezone

        $retrievedMaintenanceConfigurationByName = Get-AzMaintenancePublicConfiguration -Name $maintenanceConfigurationName
        Assert-MaintenanceConfiguration $maintenanceConfigurationCreated1 $retrievedMaintenanceConfigurationByName

        $allRetrievedMaintenanceConfigurations = Get-AzMaintenancePublicConfiguration -ResourceGroup $resourceGroupName
        $configCount = ($allRetrievedMaintenanceConfigurations | where { $_.name -eq  $maintenanceConfigurationName }).Count

        Assert-AreEqual $configCount 1

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
Test New-AzConfigurationAssignment, Get-AzConfigurationAssignment, Remove-AzConfigurationAssignment
#>
function Test-AzConfigurationAssignment
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    $maintenanceScope = "Host"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location

		$configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName mrptest$location -ResourceParentType hostGroups -ResourceParentName mrpdhg$location -ResourceType hosts -ResourceName mrpdh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationCreated.Id -Location $location

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationCreated.Id

        $retrievedConfigurationAssignmentList = Get-AzConfigurationAssignment -ResourceGroupName mrptest$location -ResourceParentType hostGroups -ResourceParentName mrpdhg$location -ResourceType hosts -ResourceName mrpdh$location -ProviderName Microsoft.Compute

        Assert-AreEqual $retrievedConfigurationAssignmentList.Count 1
        #Assert-ConfigurationAssignment $configurationAssignmentCreated $retrievedConfigurationAssignmentList[0]

        Remove-AzConfigurationAssignment -ResourceGroupName mrptest$location -ResourceParentType hostGroups -ResourceParentName mrpdhg$location -ResourceType hosts -ResourceName mrpdh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -Force

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
    $location = "eastus2euap"
    $maintenanceScope = "Host"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location

		$configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName mrptest$location -ResourceParentType hostGroups -ResourceParentName mrpdhg$location -ResourceType hosts -ResourceName mrpdh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationCreated.Id -Location $location

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationCreated.Id

        $retrievedMaintenanceUpdateList = Get-AzMaintenanceUpdate -ResourceGroupName mrptest$location -ResourceParentType hostGroups -ResourceParentName mrpdhg$location -ResourceType hosts -ResourceName mrpdh$location -ProviderName Microsoft.Compute
		Assert-NotNull $retrievedMaintenanceUpdateList

        Remove-AzConfigurationAssignment -ResourceGroupName mrptest$location -ResourceParentType hostGroups -ResourceParentName mrpdhg$location -ResourceType hosts -ResourceName mrpdh$location -ProviderName Microsoft.Compute -ConfigurationAssignmentName $maintenanceConfigurationName -Force

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

    #Assert-AreEqual $Actual.Name $Expected.Name
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

    #Assert-AreEqual $Actual.Name $Expected.Name
    Assert-AreEqual $Actual.MaintenanceConfigurationId $Expected.MaintenanceConfigurationId
	Assert-AreEqual $Actual.ResourceId $Expected.ResourceId
}
