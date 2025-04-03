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
function Test-GetAzMaintenanceConfiguration
{
    $resourceGroups = @()
    $maintenanceConfigurations = @()
    $numConfigsToTest = 2
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    $maintenanceScope = "Host"
    $visibility = "Custom"
    $startDateTime = "2024-08-05 12:30"
    $timezone = "Pacific Standard Time"
    $recurEvery = "Day"
    $duration = "05:00"
    $expirationDateTime = "9999-12-31 23:59"
    
    try
    {

        # Create and validate maintenance configurations in a loop
        for ($i = 1; $i -le $numConfigsToTest; $i++) {
            $resourceGroupName = Get-RandomResourceGroupName
            $resourceGroups += $resourceGroupName

            # Create Resource Group
            New-AzResourceGroup -Name $resourceGroupName -Location $location
            Write-Host "Created Resource Group $resourceGroupName in $location"

            # Create Maintenance Configuration
            $maintenanceConfiguration = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location -Visibility $visibility -StartDateTime $startDateTime -Timezone $timezone -RecurEvery $recurEvery -Duration $duration -ExpirationDateTime $expirationDateTime
            Write-Host "Created Maintenance Configuration $maintenanceConfigurationName in $resourceGroupName"

            # Store the configuration for further validation
            $maintenanceConfigurations += $maintenanceConfiguration

            # Validate Maintenance Configuration
            Assert-AreEqual $maintenanceConfiguration.Name $maintenanceConfigurationName
            Assert-AreEqual $maintenanceConfiguration.Location $location
            Assert-AreEqual $maintenanceConfiguration.MaintenanceScope $maintenanceScope
            Assert-AreEqual $maintenanceConfiguration.Visibility $visibility
            Assert-AreEqual $maintenanceConfiguration.StartDateTime $startDateTime
            Assert-AreEqual $maintenanceConfiguration.Timezone $timezone
            Assert-AreEqual $maintenanceConfiguration.RecurEvery $recurEvery
            Assert-AreEqual $maintenanceConfiguration.Duration $duration
            Assert-AreEqual $maintenanceConfiguration.ExpirationDateTime $expirationDateTime

            # Retrieve and Validate Maintenance Configuration with ResourceGroupName
            $retrievedMaintenanceConfiguration = Get-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName
            Assert-AreEqual $retrievedMaintenanceConfiguration.Name $maintenanceConfigurationName
            Assert-AreEqual $retrievedMaintenanceConfiguration.Location $location
            Assert-AreEqual $retrievedMaintenanceConfiguration.MaintenanceScope $maintenanceScope
            Assert-AreEqual $retrievedMaintenanceConfiguration.Visibility $visibility
            Assert-AreEqual $retrievedMaintenanceConfiguration.StartDateTime $startDateTime
            Assert-AreEqual $retrievedMaintenanceConfiguration.Timezone $timezone
            Assert-AreEqual $retrievedMaintenanceConfiguration.RecurEvery $recurEvery
            Assert-AreEqual $retrievedMaintenanceConfiguration.Duration $duration
            Assert-AreEqual $retrievedMaintenanceConfiguration.ExpirationDateTime $expirationDateTime
        }

        # Retrieve Maintenance Configurations without ResourceGroupName and validate it returns a list
        $retrievedConfigurations = Get-AzMaintenanceConfiguration -Name $maintenanceConfigurationName

        # Validate that the returned object is a list containing two objects
        if ($retrievedConfigurations.Count -ne $numConfigsToTest) {
            throw "Expected $numConfigsToTest maintenance configurations, but found $($retrievedConfigurations.Count)."
        } else {
            Write-Host "Retrieved $($retrievedConfigurations.Count) maintenance configurations."
        }

        # Update the configurations & Testing 2 sifferent input styles
        for ($i = 0; $i -lt $retrievedConfigurations.Count; $i++) {
            try {
                Update-AzMaintenanceConfiguration -ResourceGroupName $resourceGroups[$i] -Name $maintenanceConfigurationName -Configuration $retrievedConfigurations[$i]
                $retrievedConfigurations[$i] | Update-AzMaintenanceConfiguration -ResourceGroupName $resourceGroups[$i] -Name $maintenanceConfigurationName
            }
            catch {
                throw "Caught Exception while updating maintenance configuration in $resourceGroups[$i]."
            }
        }

    }
    finally
    {
        # Cleanup in a loop
        foreach ($resourceGroupName in $resourceGroups) {
            try {
                Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Force
                Remove-AzResourceGroup -Name $resourceGroupName -Force
                Write-Host "Cleaned up Resource Group $resourceGroupName and Maintenance Configuration $maintenanceConfigurationName"
            }
            catch {
                throw "Caught Exception while deleting resourceGroup in $resourceGroupName."
            }
            
        }
    }
}


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
    $Duration = "02:00"
    $ExpirationDateTime = "9999-12-31 23:59";
    $WindowsParameterClassificationToInclude = "FeaturePack","ServicePack";
    $WindowParameterKbNumberToInclude = "KB123456","KB123466";
    $WindowParameterKbNumberToExclude = "KB123456","KB123466";
    $RebootOption = "IfRequired";
    $LinuxParameterClassificationToInclude = "Other";
    $LinuxParameterPackageNameMaskToInclude = "apt","httpd";
    $LinuxParameterPackageNameMaskToExclude = "ppt","userpk";

    $resourceGroupName1 = "powershellrg"
    $maintenanceConfigurationName1 = Get-RandomMaintenanceConfigurationName  
        
    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        Write-Host "Created RG $location"

        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location -Timezone $Timezone -StartDateTime $StartDateTime -ExpirationDateTime $ExpirationDateTime -Duration $Duration -RecurEvery $RecurEvery -InstallPatchRebootSetting $RebootOption -WindowParameterClassificationToInclude $WindowsParameterClassificationToInclude -WindowParameterKbNumberToInclude $WindowParameterKbNumberToInclude -WindowParameterKbNumberToExclude $WindowParameterKbNumberToExclude -LinuxParameterPackageNameMaskToInclude $LinuxParameterPackageNameMaskToInclude -LinuxParameterClassificationToInclude $LinuxParameterClassificationToInclude -LinuxParameterPackageNameMaskToExclude $LinuxParameterPackageNameMaskToExclude -ExtensionProperty @{inGuestPatchMode="User"}

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

        $maintenanceConfigurationCreated1 = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName1 -MaintenanceScope $maintenanceScope -Location $location -Timezone $Timezone -StartDateTime $StartDateTime -ExpirationDateTime $ExpirationDateTime -Duration $Duration -RecurEvery $RecurEvery -InstallPatchRebootSetting $RebootOption -WindowParameterClassificationToInclude $WindowsParameterClassificationToInclude -WindowParameterKbNumberToInclude $WindowParameterKbNumberToInclude -WindowParameterKbNumberToExclude $WindowParameterKbNumberToExclude -LinuxParameterPackageNameMaskToInclude $LinuxParameterPackageNameMaskToInclude -LinuxParameterClassificationToInclude $LinuxParameterClassificationToInclude -LinuxParameterPackageNameMaskToExclude $LinuxParameterPackageNameMaskToExclude -WindowParameterExcludeKbRequiringReboot $true -ExtensionProperty @{inGuestPatchMode="User"}

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
        $maintenanceConfigurationNameInstance.InstallPatchRebootSetting = "AlwaysReboot"

        # Act
        Update-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -Configuration  $maintenanceConfigurationNameInstance
        $updatedMRPConfig = Get-AzMaintenanceConfiguration -ResourceGroup $resourceGroupName -Name  $maintenanceConfigurationName

        # Assert
        Assert-AreEqual $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Count 3
        Assert-True { $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Contains("apt") }
        Assert-True { $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Contains("httpd") }
        Assert-True { $updatedMRPConfig.LinuxParameterPackageNameMaskToInclude.Contains("package3") }
        Assert-AreEqual $updatedMRPConfig.InstallPatchRebootSetting "AlwaysReboot"

        # Default patch config
        $maintenanceConfigurationName2 = Get-RandomMaintenanceConfigurationName
        $deafultPatchConfig = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName1 -Name $maintenanceConfigurationName2 -MaintenanceScope $maintenanceScope -Location $location -Timezone $Timezone -StartDateTime $StartDateTime -ExpirationDateTime $ExpirationDateTime -Duration $Duration -RecurEvery $RecurEvery  -ExtensionProperty @{inGuestPatchMode="Platform"}

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
    $maintenanceConfigurationInGuestPatchName = Get-RandomMaintenanceConfigurationName
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
Test New-AzConfigurationAssignment, Get-AzConfigurationAssignment, Remove-AzConfigurationAssignment
#>
function Test-AzConfigurationAssignmentDynamicGroupForSubscription
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $maintenanceConfigurationInGuestPatchName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    ## Create ResourceGroup before recording test
    $resourceGroupNameForConfigAssignment = "mrppowershelleastus2euap"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
       
        ### InGuestPatch maintenance config
        $maintenanceConfigurationInGuestPatchCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationInGuestPatchName -MaintenanceScope "InGuestPatch" -Location $location -Timezone "UTC" -StartDateTime "2025-10-09 12:30" -Duration "3:00" -RecurEvery "Day" -LinuxParameterPackageNameMaskToInclude "apt","httpd" -ExtensionProperty @{inGuestPatchMode="User"} -InstallPatchRebootSetting "IfRequired"

        ## Dynamic Group Subscription level
        # Dyamic scope ResourceGroup assignment
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id

        # Dyamic scope ResourceGroup assignment locations filter
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id -FilterLocation eastus2euap,centraluseuap

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[0] "eastus2euap"
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[1] "centraluseuap"

        # Dyamic scope ResourceGroup assignment locations and resourceType filter
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id -FilterLocation eastus2euap,centraluseuap -FilterResourceType microsoft.compute/virtualmachines,microsoft.hybridcompute/machines

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[0] "eastus2euap"
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[1] "centraluseuap"
        Assert-AreEqual $configurationAssignmentCreated.FilterResourceType.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterResourceType[0] "microsoft.compute/virtualmachines"
        Assert-AreEqual $configurationAssignmentCreated.FilterResourceType[1] "microsoft.hybridcompute/machines"

        # Dyamic scope ResourceGroup assignment tags, locations, os Filter
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id -FilterLocation eastus2euap,centraluseuap -FilterOsType Windows,Linux -FilterTag '{"tagKey1" : ["tagKey1Value1", "tagKey1Value2"], "tagKey2" : ["tagKey2Value1", "tagKey2Value2", "tagKey2Value3"] }' -FilterOperator "Any"

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[0] "eastus2euap"
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[1] "centraluseuap"
        Assert-AreEqual $configurationAssignmentCreated.FilterOsType.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterOsType[0] "Windows"
        Assert-AreEqual $configurationAssignmentCreated.FilterOsType[1] "Linux"
        Assert-AreEqual $configurationAssignmentCreated.FilterTag '{"tagKey1":["tagKey1Value1","tagKey1Value2"],"tagKey2":["tagKey2Value1","tagKey2Value2","tagKey2Value3"]}'
        Assert-AreEqual $configurationAssignmentCreated.FilterOperator "Any"

         # Get configuration assignment
        $retrievedRGConfigurationAssignmentList = Get-AzConfigurationAssignment -ConfigurationAssignmentName $maintenanceConfigurationName
        Assert-AreEqual $retrievedRGConfigurationAssignmentList.Count 1

        # Delete configuration assignment
        Remove-AzConfigurationAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -Force
        
        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationInGuestPatchName -Force
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
function Test-AzConfigurationAssignmentDynamicGroupForResourceGroup
{
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $maintenanceConfigurationInGuestPatchName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    ## Create ResourceGroup before recording test
    $resourceGroupNameForConfigAssignment = "mrppowershelleastus2euap"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
       
        ### InGuestPatch maintenance config
        $maintenanceConfigurationInGuestPatchCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationInGuestPatchName -MaintenanceScope "InGuestPatch" -Location $location -Timezone "UTC" -StartDateTime "2025-10-09 12:30" -Duration "3:00" -RecurEvery "Day" -LinuxParameterPackageNameMaskToInclude "apt","httpd" -ExtensionProperty @{inGuestPatchMode="User"} -InstallPatchRebootSetting "IfRequired"

        # Dyamic Scope - Resource Group
        # Dyamic scope ResourceGroup assignment locations filter
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName $resourceGroupNameForConfigAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id -Location $location -FilterLocation eastus2euap,centraluseuap

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[0] "eastus2euap"
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[1] "centraluseuap"

        # Dyamic scope ResourceGroup assignment locations and resourceType filter
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName $resourceGroupNameForConfigAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id -Location $location -FilterLocation eastus2euap,centraluseuap -FilterResourceType microsoft.compute/virtualmachines,microsoft.hybridcompute/machines

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[0] "eastus2euap"
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[1] "centraluseuap"
        Assert-AreEqual $configurationAssignmentCreated.FilterResourceType.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterResourceType[0] "microsoft.compute/virtualmachines"
        Assert-AreEqual $configurationAssignmentCreated.FilterResourceType[1] "microsoft.hybridcompute/machines"

        # Dyamic scope ResourceGroup assignment tags, locations, os Filter
        $configurationAssignmentCreated = New-AzConfigurationAssignment -ResourceGroupName $resourceGroupNameForConfigAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id -Location $location -FilterLocation eastus2euap,centraluseuap -FilterOsType Windows,Linux -FilterTag '{"tagKey1" : ["tagKey1Value1", "tagKey1Value2"], "tagKey2" : ["tagKey2Value1", "tagKey2Value2", "tagKey2Value3"] }' -FilterOperator "Any"

        Assert-AreEqual $configurationAssignmentCreated.Name $maintenanceConfigurationName
		Assert-AreEqual $configurationAssignmentCreated.Type "Microsoft.Maintenance/configurationAssignments"
        Assert-AreEqual $configurationAssignmentCreated.MaintenanceConfigurationId $maintenanceConfigurationInGuestPatchCreated.Id
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[0] "eastus2euap"
        Assert-AreEqual $configurationAssignmentCreated.FilterLocation[1] "centraluseuap"
        Assert-AreEqual $configurationAssignmentCreated.FilterOsType.Count 2
        Assert-AreEqual $configurationAssignmentCreated.FilterOsType[0] "Windows"
        Assert-AreEqual $configurationAssignmentCreated.FilterOsType[1] "Linux"
        Assert-AreEqual $configurationAssignmentCreated.FilterTag '{"tagKey1":["tagKey1Value1","tagKey1Value2"],"tagKey2":["tagKey2Value1","tagKey2Value2","tagKey2Value3"]}'
        Assert-AreEqual $configurationAssignmentCreated.FilterOperator "Any"

        # Get Resource Group configuration assignment
        $retrievedRGConfigurationAssignmentList = Get-AzConfigurationAssignment -ResourceGroupName $resourceGroupNameForConfigAssignment -ConfigurationAssignmentName $maintenanceConfigurationName
        Assert-AreEqual $retrievedRGConfigurationAssignmentList.Count 1

        # Delete  Resource Group configuration assignment
        Remove-AzConfigurationAssignment -ResourceGroupName $resourceGroupNameForConfigAssignment -ConfigurationAssignmentName $maintenanceConfigurationName -Force

        Remove-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationInGuestPatchName -Force

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
Test New-AzMaintenanceConfiguration, New-AzApplyUpdate, Remove-AzMaintenanceConfiguration
#>
function Test-AzApplyUpdateCancelConfiguration
{
    $actualStartTime = (Get-Date -AsUTC).AddMinutes(12)

    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $location = "eastus2euap"
    $maintenanceScope = "InGuestPatch"
    $duration = "02:00"
    $actualStartDateTime = $actualStartTime.ToString("yyyy-MM-dd HH:mm")
    $startDateTime = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("startDateTime", $actualStartDateTime)
    $expirationDateTime = "9999-12-31 00:00"
    $recurEvery = "Day"
    $timezone = "UTC"
    $visibility = "Custom"
    $extensionProperties = @{InGuestPatchMode="User"}
    $linuxParameterClassificationToInclude = @("Security", "Critical")
    $installPatchRebootSetting = "Always"

    $providerName = "Microsoft.Maintenance"
    $resourceType = "maintenanceConfigurations"
    $actualApplyUpdateName = $actualStartTime.ToString("yyyyMMddHHmm00")
    $applyUpdateName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("applyUpdateName", $actualApplyUpdateName)
    $status = "Cancel"

    try 
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        ### InGuestPatch maintenance config
        $maintenanceConfigurationCreated = New-AzMaintenanceConfiguration -ResourceGroupName $resourceGroupName -Name $maintenanceConfigurationName -MaintenanceScope $maintenanceScope -Location $location -Timezone $timezone -StartDateTime $startDateTime -ExpirationDateTime $expirationDateTime -Duration $duration -RecurEvery $recurEvery -ExtensionProperty $extensionProperties -Visibility $visibility -LinuxParameterClassificationToInclude $linuxParameterClassificationToInclude -InstallPatchRebootSetting $installPatchRebootSetting

        Assert-AreEqual $maintenanceConfigurationCreated.Name $maintenanceConfigurationName

        ### Wait for configuration cancellation window to start
        Start-TestSleep -Seconds (4 * 60)

        ### Cancel the config
        $cancelResponse =  New-AzApplyUpdate -ResourceGroupName $resourceGroupName -ProviderName $providerName -ResourceType $resourceType -ResourceName $maintenanceConfigurationName -ApplyUpdateName $applyUpdateName -Status $status

        Assert-AreEqual $cancelResponse.Status "Cancelled"

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
Test New-AzMaintenanceConfiguration, New-AzConfigurationAssignment, Get-AzApplyUpdate
#>
function Test-GetAzApplyUpdateWithParentResource
{
    $actualStartTime = (Get-Date -AsUTC).AddMinutes(12)
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $dedicatedHostGroupName = Get-RandomDedicatedHostGroupName
    $dedicatedHostName = Get-RandomDedicatedHostName
    $location = "eastus"
    $maintenanceScope = "Host"
    $duration = "02:00"
    $actualStartDateTime = $actualStartTime.ToString("yyyy-MM-dd HH:mm")
    $startDateTime = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("startDateTime", $actualStartDateTime)
    $expirationDateTime = "9999-12-31 00:00"
    $recurEvery = "Day"
    $timezone = "UTC"
    $providerName = "Microsoft.Compute"
    $resourceType = "hosts"
    $resourceParentType = "hostGroups"
    $applyUpdateName = "default"

    try 
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        $dedicatedHostId = New-DedicatedHost $dedicatedHostName $dedicatedHostGroupName $resourceGroupName $location

        ### Host maintenance config
        $maintenanceConfiguration = New-AzMaintenanceConfiguration `
            -ResourceGroupName $resourceGroupName `
            -Name $maintenanceConfigurationName `
            -MaintenanceScope $maintenanceScope `
            -Location $location `
            -Timezone $timezone `
            -StartDateTime $startDateTime `
            -ExpirationDateTime $expirationDateTime `
            -Duration $duration `
            -RecurEvery $recurEvery

        Assert-AreEqual $maintenanceConfiguration.Name $maintenanceConfigurationName

        ### Wait few minutes so that the resource is available for configuration assignment
        Start-TestSleep -Seconds (15 * 60)

        ### Create configuration assignment
        $configurationAssignment = New-AzConfigurationAssignment `
           -ResourceGroupName $resourceGroupName `
           -Location $location `
           -ResourceName $dedicatedHostName `
           -ResourceType $resourceType `
           -ResourceParentName $dedicatedHostGroupName `
           -ResourceParentType $resourceParentType `
           -ProviderName $providerName `
           -ConfigurationAssignmentName $maintenanceConfigurationName `
           -MaintenanceConfigurationId $maintenanceConfiguration.Id

        Assert-AreEqual $configurationAssignment.Name $maintenanceConfigurationName

        ### Make Get-AzApplyUpdate call
        $applyUpdateResponse = Get-AzApplyUpdate `
            -ResourceGroupName $resourceGroupName `
            -ProviderName $providerName `
            -ResourceType $resourceType `
            -ResourceName $dedicatedHostName `
            -ResourceParentType $resourceParentType `
            -ResourceParentName $dedicatedHostGroupName `
            -ApplyUpdateName $applyUpdateName

        Assert-AreEqual $applyUpdateResponse.ResourceId $dedicatedHostId
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test New-AzMaintenanceConfiguration, New-AzConfigurationAssignment, Get-AzApplyUpdate
#>
function Test-GetAzApplyUpdateWithoutParentResource
{
    $actualStartTime = (Get-Date -AsUTC).AddMinutes(12)
    $resourceGroupName = Get-RandomResourceGroupName
    $maintenanceConfigurationName = Get-RandomMaintenanceConfigurationName
    $virtualMachineName = Get-RandomVirtualMachineName
    $location = "westus"
    $maintenanceScope = "InGuestPatch"
    $duration = "02:00"
    $actualStartDateTime = $actualStartTime.ToString("yyyy-MM-dd HH:mm")
    $startDateTime = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("startDateTime", $actualStartDateTime)
    $expirationDateTime = "9999-12-31 00:00"
    $recurEvery = "Day"
    $timezone = "UTC"
    $extensionProperty = @{"inGuestPatchMode"="User"}
    $rebootOption = "IfRequired";
    $windowsParameterClassificationToInclude = "FeaturePack","ServicePack";
    $windowsParameterKbNumberToInclude = "KB123456","KB123466";
    $windowsParameterKbNumberToExclude = "KB123456","KB123466";
    $linuxParameterClassificationToInclude = "Other";
    $linuxParameterPackageNameMaskToInclude = "apt","httpd";
    $linuxParameterPackageNameMaskToExclude = "ppt","userpk";
    $providerName = "Microsoft.Compute"
    $resourceType = "virtualmachines"
    $applyUpdateName = "default"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        $virtualMachineId = New-VirtualMachine $virtualMachineName $resourceGroupName $location

        ### InGuestPatch maintenance config
        $maintenanceConfiguration = New-AzMaintenanceConfiguration `
            -ResourceGroupName $resourceGroupName `
            -Name $maintenanceConfigurationName `
            -MaintenanceScope $maintenanceScope `
            -Location $location `
            -Timezone $timezone `
            -StartDateTime $startDateTime `
            -ExpirationDateTime $expirationDateTime `
            -Duration $duration `
            -RecurEvery $recurEvery `
            -ExtensionProperty $extensionProperty `
            -InstallPatchRebootSetting $rebootOption `
            -WindowParameterClassificationToInclude $windowsParameterClassificationToInclude `
            -WindowParameterKbNumberToInclude $windowsParameterKbNumberToInclude `
            -WindowParameterKbNumberToExclude $windowsParameterKbNumberToExclude `
            -LinuxParameterPackageNameMaskToInclude $linuxParameterPackageNameMaskToInclude `
            -LinuxParameterClassificationToInclude $linuxParameterClassificationToInclude `
            -LinuxParameterPackageNameMaskToExclude $linuxParameterPackageNameMaskToExclude

        Assert-AreEqual $maintenanceConfiguration.Name $maintenanceConfigurationName

        ### Wait few minutes so that the resource is available for configuration assignment
        Start-TestSleep -Seconds (15 * 60)

        ### Create configuration assignment
        $configurationAssignment = New-AzConfigurationAssignment `
           -ResourceGroupName $resourceGroupName `
           -Location $location `
           -ResourceName $virtualMachineName `
           -ResourceType $resourceType `
           -ProviderName $providerName `
           -ConfigurationAssignmentName $maintenanceConfigurationName `
           -MaintenanceConfigurationId $maintenanceConfiguration.Id

        Assert-AreEqual $configurationAssignment.Name $maintenanceConfigurationName

        ### Make Get-AzApplyUpdate call
        $applyUpdateResponse = Get-AzApplyUpdate `
            -ResourceGroupName $resourceGroupName `
            -ProviderName $providerName `
            -ResourceType $resourceType `
            -ResourceName $virtualMachineName `
            -ApplyUpdateName $applyUpdateName

        Assert-AreEqual $applyUpdateResponse.ResourceId $virtualMachineId
    }
    finally
    {
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
