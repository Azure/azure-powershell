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
Tests API Management Create List Remove operations.
#>
function Test-CrudApiManagement
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $secondApiManagementName = Get-ApiManagementServiceName
    $secondOrganization = "second.apimpowershellorg"
    $secondAdminEmail = "second.apim@powershell.org"
    $secondSku = "Standard"
    $secondSkuCapacity = 2

    try
    {
        # Create Resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        
        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual "Developer" $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual "None" $result.VpnType

        # Get SSO token
        $token = Get-AzureRmApiManagementSsoToken -ResourceGroupName $resourceGroupName -Name $apiManagementName
        Assert-NotNull $token

        # List services within the resource group
        $apimServicesInGroup = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName
        Assert-True {$apimServicesInGroup.Count -ge 1}
        
        #Create Second Service
        $secondResult = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $secondApiManagementName -Organization $secondOrganization -AdminEmail $secondAdminEmail -Sku $secondSku -Capacity $secondSkuCapacity
        Assert-AreEqual $resourceGroupName $secondResult.ResourceGroupName
        Assert-AreEqual $secondApiManagementName $secondResult.Name
        Assert-AreEqual $location $secondResult.Location
        Assert-AreEqual $secondSku $secondResult.Sku
        Assert-AreEqual $secondSkuCapacity $secondResult.Capacity

        # Get SSO token
        $secondToken = Get-AzureRmApiManagementSsoToken -ResourceGroupName $resourceGroupName -Name $secondApiManagementName
        Assert-NotNull $secondToken

        # List all services
        $allServices = Get-AzureRmApiManagement
        Assert-True {$allServices.Count -ge 2}
        
        $found = 0
        for ($i = 0; $i -lt $allServices.Count; $i++)
        {
            if ($allServices[$i].Name -eq $apiManagementName)
            {
                $found = $found + 1
                Assert-AreEqual $location $allServices[$i].Location
                Assert-AreEqual $resourceGroupName $allServices[$i].ResourceGroupName
        
                Assert-AreEqual "Developer" $allServices[$i].Sku
                Assert-AreEqual 1 $allServices[$i].Capacity
            }

            if ($allServices[$i].Name -eq $secondApiManagementName)
            {
                $found = $found + 1
                Assert-AreEqual $location $allServices[$i].Location
                Assert-AreEqual $resourceGroupName $allServices[$i].ResourceGroupName
        
                Assert-AreEqual $secondSku $allServices[$i].Sku
                Assert-AreEqual $secondSkuCapacity $allServices[$i].Capacity
            }
        }
        Assert-True {$found -eq 2} "Api Management services created earlier is not found."
        
         # Delete listed services in the ResourceGroup
        Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName | Remove-AzureRmApiManagement

        $allServices = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName
        Assert-AreEqual 0 $allServices.Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests API Management Backup/Restore operations.
#>
function Test-BackupRestoreApiManagement
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $resourceGroupName = Get-ResourceGroupName
    $storageLocation = Get-ProviderLocation "Microsoft.ClassicStorage/storageAccounts"
    $storageAccountName = Get-ApiManagementServiceName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $containerName = "backups"
    $backupName = $apiManagementName + ".apimbackup"

    
    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

        # Create storage account    
        New-AzureRmStorageAccount -StorageAccountName $storageAccountName -Location $storageLocation -ResourceGroupName $resourceGroupName -Type Standard_LRS
        $storageKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName).Key1
        $storageContext = New-AzureStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageKey
        
        # Create API Management service
        $apiManagementService = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail

        # Backup API Management service
        Backup-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -TargetContainerName $containerName -TargetBlobName $backupName

        # Restore API Management service
        $restoreResult = Restore-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -SourceContainerName $containerName -SourceBlobName $backupName -PassThru

        Assert-AreEqual $resourceGroupName $restoreResult.ResourceGroupName
        Assert-AreEqual $apiManagementName $restoreResult.Name
        Assert-AreEqual $location $restoreResult.Location
        Assert-AreEqual "Developer" $restoreResult.Sku
        Assert-AreEqual 1 $restoreResult.Capacity
        Assert-AreEqual "Succeeded" $restoreResult.ProvisioningState
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName    
    }   
}

<#
.SYNOPSIS
Tests UpdateAzureApiManagementDeployment.
#>
function Test-UpdateApiManagementDeployment
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1    
    $resourceGroupName = Get-ResourceGroupName
    
    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        
        # Create API Management service
        New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity

        # Get API Management and:
        #- 1) Scale master region to 'Premium' 2 units
        $sku = "Premium"
        $capacity = 2

        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName
        $service.Sku = $sku;
        $service.Capacity = $capacity

        # - 2) Add new region 1 unit
        $region1Location = Get-ProviderLocations "Microsoft.ApiManagement/service" | Where {$_ -ne $location} | Select -First 1
        $region1Sku = "Premium"
        $service.AddRegion($region1Location, $region1Sku)

        Update-AzureRmApiManagementDeployment -ApiManagement $service

        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName

        Assert-AreEqual $resourceGroupName $service.ResourceGroupName
        Assert-AreEqual $apiManagementName $service.Name
        Assert-AreEqual $location $service.Location
        Assert-AreEqual $sku $service.Sku
        Assert-AreEqual $capacity $service.Capacity
        Assert-AreEqual "Succeeded" $service.ProvisioningState

        Assert-AreEqual 1 $service.AdditionalRegions.Count
        $found = 0
        for ($i = 0; $i -lt $service.AdditionalRegions.Count; $i++)
        {
            if ($service.AdditionalRegions[$i].Location -eq $region1Location)
            {
                $found = $found + 1
                Assert-AreEqual $region1Sku $service.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $service.AdditionalRegions[$i].Capacity
                Assert-Null $service.AdditionalRegions[$i].VirtualNetwork
            }
        }

        Assert-True {$found -eq 1} "Api Management regions created earlier is not found."
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests SetApiManagementDeploymentExternalVirtualNetwork
#>
function Test-SetApiManagementDeploymentExternalVirtualNetwork
{
    # Setup
    $location = "North Central US"    
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    $subnetResourceId = "/subscriptions/20010222-2b48-4245-a95c-090db6312d5f/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/apimvnettest/subnets/default"

    try
    {
        # Create the resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

        # Create API Management service
        New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity
               
        # Create a Virtual Network Object
        $virtualNetwork = New-AzureRmApiManagementVirtualNetwork -Location $location -SubnetResourceId $subnetResourceId

        # Get the service
        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName    
        $service.VirtualNetwork = $virtualNetwork
        $service.VpnType = "External"

        # Update the Deployment with Virtual Network
        Update-AzureRmApiManagementDeployment -ApiManagement $service

        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName

        Assert-AreEqual $resourceGroupName $service.ResourceGroupName
        Assert-AreEqual $apiManagementName $service.Name
        Assert-AreEqual $location $service.Location
        Assert-AreEqual "Succeeded" $service.ProvisioningState
        Assert-AreEqual "External" $service.VpnType
        Assert-NotNull $service.VirtualNetwork
        Assert-NotNull $service.VirtualNetwork.SubnetResourceId
        Assert-AreEqual $subnetResourceId $service.VirtualNetwork.SubnetResourceId
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName    
    }
}

<#
.SYNOPSIS
Tests SetApiManagementDeploymentExternalVirtualNetwork
#>
function Test-SetApiManagementDeploymentInternalVirtualNetwork
{
        # Setup
    $location = "North Central US"    
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    $subnetResourceId = "/subscriptions/20010222-2b48-4245-a95c-090db6312d5f/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/apimvnettest/subnets/default"

    try
    {
        # Create the resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

        # Create API Management service
        New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity

        # Create a Virtual Network Object
        $virtualNetwork = New-AzureRmApiManagementVirtualNetwork -Location $location -SubnetResourceId $subnetResourceId

        # Get the service
        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName    
        $service.VirtualNetwork = $virtualNetwork
        $service.VpnType = "Internal"

        # Update the Deployment with Virtual Network
        Update-AzureRmApiManagementDeployment -ApiManagement $service

        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName

        Assert-AreEqual $resourceGroupName $service.ResourceGroupName
        Assert-AreEqual $apiManagementName $service.Name
        Assert-AreEqual $location $service.Location
        Assert-AreEqual "Succeeded" $service.ProvisioningState
        Assert-AreEqual "Internal" $service.VpnType
        Assert-NotNull $service.VirtualNetwork
        Assert-NotNull $service.VirtualNetwork.SubnetResourceId
        Assert-AreEqual $subnetResourceId $service.VirtualNetwork.SubnetResourceId
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName    
    }
}

<#
.SYNOPSIS
Tests UpdateAzureApiManagementDeployment using pipeline and helper cmdlets.
#>
function Test-UpdateApiManagementDeploymentWithHelpersAndPipeline
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    
    try
    {
        # Create a resource group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location    

        # Create API Management service
        $service = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity

        # Get API Management and:
        #- 1) Scale master region to 'Premium' 2
        $sku = "Premium"
        $capacity = 2

        # - 2) Add new 'Premium' region 1 unit
        $region1Location = Get-ProviderLocations "Microsoft.ApiManagement/service" | Where {$_ -ne $location} | Select -First 1
        $region1Sku = "Premium"

        Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName |
        Update-AzureRmApiManagementRegion -Sku $sku -Capacity $capacity |
        Add-AzureRmApiManagementRegion -Location $region1Location -Sku $region1Sku |
        Update-AzureRmApiManagementDeployment

        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName

        Assert-AreEqual $resourceGroupName $service.ResourceGroupName
        Assert-AreEqual $apiManagementName $service.Name
        Assert-AreEqual $location $service.Location
        Assert-AreEqual $sku $service.Sku
        Assert-AreEqual $capacity $service.Capacity
        Assert-AreEqual "Succeeded" $service.ProvisioningState

        Assert-AreEqual 1 $service.AdditionalRegions.Count

        $found = 0
        for ($i = 0; $i -lt $service.AdditionalRegions.Count; $i++)
        {
            if ($service.AdditionalRegions[$i].Location -eq $region1Location)
            {
                $found = $found + 1
                Assert-AreEqual $region1Sku $service.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $service.AdditionalRegions[$i].Capacity
                Assert-Null $service.AdditionalRegions[$i].VirtualNetwork
            }
        }
        
        Assert-True {$found -eq 1} "Api Management regions created earlier is not found."
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests ImportApiManagementHostnameCertificate.
#>
function Test-ImportApiManagementHostnameCertificate
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $certFilePath = "$TestOutputRoot\testcertificate.pfx";
    $certPassword = "g0BdrCRORWI2ctk_g5Wdf5QpTsI9vxnw";        
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName    
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
        
    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location    

        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity |
        Get-AzureRmApiManagement |
        Import-AzureRmApiManagementHostnameCertificate -HostnameType "Proxy" -PfxPath $certFilePath -PfxPassword $certPassword -PassThru

        Assert-AreEqual "CN=*.powershelltest.net" $result.Subject
        Assert-AreEqual "E861A19B22EE98AC71F84AC00C5A05E2E7206820" $result.Thumbprint
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName    
    }
}

<#
.SYNOPSIS
Tests SetApiManagementHostnames.
#>
function Test-SetApiManagementHostnames
{
    # Setup
    $location = "North Central US"
    $certFilePath = "$TestOutputRoot\testcertificate.pfx";
    $certPassword = "g0BdrCRORWI2ctk_g5Wdf5QpTsI9vxnw";
    $certSubject = "CN=*.powershelltest.net"
    $certThumbprint = "E861A19B22EE98AC71F84AC00C5A05E2E7206820"
    $portalHostName = "onesdk.powershelltest.net"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    
    try
    {
        # Create resource group    
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
        
        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity

        #Import the Custom Domain Certificate
        $certUploadResult = Import-AzureRmApiManagementHostnameCertificate -ResourceGroupName $resourceGroupName -Name $apiManagementName -HostnameType "Portal" -PfxPath $certFilePath -PfxPassword $certPassword -PassThru

        Assert-AreEqual $certSubject $certUploadResult.Subject
        Assert-AreEqual $certThumbprint $certUploadResult.Thumbprint

        # set portal hostname
        $portalHostnameConf = New-AzureRmApiManagementHostnameConfiguration -CertificateThumbprint $certThumbprint -Hostname $portalHostName
        $result = Set-AzureRmApiManagementHostnames -Name $apiManagementName -ResourceGroupName $resourceGroupName –PortalHostnameConfiguration $portalHostnameConf -PassThru

        Assert-AreEqual $portalHostName $result.PortalHostnameConfiguration.Hostname
        Assert-AreEqual $certSubject $result.PortalHostnameConfiguration.HostnameCertificate.Subject
        Assert-Null $result.ProxyHostnameConfiguration

        # set default hostnames
        $result = Set-AzureRmApiManagementHostnames -Name $apiManagementName -ResourceGroupName $resourceGroupName

        Assert-Null $result.ProxyHostnameConfiguration
        Assert-Null $result.PortalHostnameConfiguration
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName   
    }
}


<#
.SYNOPSIS
Tests API Management Create with 1 Additional Region
#>
function Test-CrudApiManagementWithAdditionalRegions
{
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"  
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Premium"
    $capacity = 1
		
    try
    {
        # Create Resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		
		# - 2) Add new 'Premium' region 1 unit
        $additionalRegionLocation = Get-ProviderLocations "Microsoft.ApiManagement/service" | Where {$_ -ne $location} | Select -First 1        

		$additionalRegion = New-AzureRmApiManagementRegion -Location $additionalRegionLocation
		$regions = @($additionalRegion)
        
        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity -AdditionalRegions $regions

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual $capacity $result.Capacity
        Assert-AreEqual "None" $result.VpnType
		
		Assert-AreEqual 1 $result.AdditionalRegions.Count
        $found = 0
        for ($i = 0; $i -lt $result.AdditionalRegions.Count; $i++)
        {
            if ($result.AdditionalRegions[$i].Location -eq $additionalRegionLocation)
            {
                $found = $found + 1
                Assert-AreEqual $sku $result.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $result.AdditionalRegions[$i].Capacity
                Assert-Null $result.AdditionalRegions[$i].VirtualNetwork
            }
        }       
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests API Management Create in External VpnType ARM VNET Subnet.
#>
function Test-CrudApiManagementWithExternalVpn
{
    # Setup
   # Setup
    $location = "North Central US"    
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    $subnetResourceId = "/subscriptions/20010222-2b48-4245-a95c-090db6312d5f/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/apimvnettest/subnets/default"
	$vpnType = "External"


    try
    {
        # Create Resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

		 # Create a Virtual Network Object
        $virtualNetwork = New-AzureRmApiManagementVirtualNetwork -Location $location -SubnetResourceId $subnetResourceId
        
        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -VpnType $vpnType -VirtualNetwork $virtualNetwork -Sku $sku -Capacity $capacity

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual $vpnType $result.VpnType
		Assert-AreEqual $subnetResourceId $result.VirtualNetwork.SubnetResourceId

         # Delete listed services in the ResourceGroup
        Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName | Remove-AzureRmApiManagement

        $allServices = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName
        Assert-AreEqual 0 $allServices.Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}