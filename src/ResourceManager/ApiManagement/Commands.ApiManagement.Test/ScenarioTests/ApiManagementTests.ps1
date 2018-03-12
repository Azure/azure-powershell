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
function Test-CrudApiManagement {
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $secondApiManagementName = Get-ApiManagementServiceName
    $secondOrganization = "second.apimpowershellorg"
    $secondAdminEmail = "second.apim@powershell.org"
    $secondSku = "Basic"
    $secondSkuCapacity = 2

    try {
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
        for ($i = 0; $i -lt $allServices.Count; $i++) {
            if ($allServices[$i].Name -eq $apiManagementName) {
                $found = $found + 1
                Assert-AreEqual $location $allServices[$i].Location
                Assert-AreEqual $resourceGroupName $allServices[$i].ResourceGroupName
        
                Assert-AreEqual "Developer" $allServices[$i].Sku
                Assert-AreEqual 1 $allServices[$i].Capacity
            }

            if ($allServices[$i].Name -eq $secondApiManagementName) {
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
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests API Management Backup/Restore operations.
#>
function Test-BackupRestoreApiManagement {
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

    
    try {
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
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName    
    }   
}

<#
.SYNOPSIS
Tests ApiManagementVirtualNetworkCRUD
#>
function Test-ApiManagementVirtualNetworkCRUD {
    # Setup
    $primarylocation = "North Central US"
    $secondarylocation = "South Central US"
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    $primarySubnetResourceId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/powershellvnetncu/subnets/default"
    $additionalSubnetResourceId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/powershellvnetscu/subnets/default"
    $vpnType = "External" 
 
    try {
        # Create Resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $primarylocation
 
        # Create a Virtual Network Object
        $virtualNetwork = New-AzureRmApiManagementVirtualNetwork -Location $primarylocation -SubnetResourceId $primarySubnetResourceId
         
        # Create API Management service in External VNET
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $primarylocation -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -VpnType $vpnType -VirtualNetwork $virtualNetwork -Sku $sku -Capacity $capacity
 
        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $primarylocation $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual $vpnType $result.VpnType
        Assert-Null $result.PrivateIPAddresses
        Assert-NotNull $result.PublicIPAddresses
        Assert-AreEqual $primarySubnetResourceId $result.VirtualNetwork.SubnetResourceId

        # Get the service and switch to internal Virtual Network
        $service = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName
        $vpnType = "Internal"
        $service.VirtualNetwork = $virtualNetwork
        $service.VpnType = $vpnType
        # update the SKU to Premium SKU
        $sku = "Premium"
        $service.Sku = $sku
        
        # Create Virtual Network Object for Additional region
        $additionalRegionVirtualNetwork = New-AzureRmApiManagementVirtualNetwork -Location $secondarylocation -SubnetResourceId $additionalSubnetResourceId

        $service = Add-AzureRmApiManagementRegion -ApiManagement $service -Location $secondarylocation -VirtualNetwork $additionalRegionVirtualNetwork
        # Update the Deployment into Internal Virtual Network
        $service = Set-AzureRmApiManagement -ApiManagement $service -PassThru

        Assert-AreEqual $resourceGroupName $service.ResourceGroupName
        Assert-AreEqual $apiManagementName $service.Name
        Assert-AreEqual $sku $service.Sku
        Assert-AreEqual $primarylocation $service.Location
        Assert-AreEqual "Succeeded" $service.ProvisioningState
        Assert-AreEqual $vpnType $service.VpnType
        Assert-NotNull $service.VirtualNetwork
        Assert-NotNull $service.VirtualNetwork.SubnetResourceId
        Assert-NotNull $service.PrivateIPAddresses
        Assert-NotNull $service.PublicIPAddresses
        Assert-AreEqual $primarySubnetResourceId $service.VirtualNetwork.SubnetResourceId

        # Validate the additional region
        Assert-AreEqual 1 $service.AdditionalRegions.Count
        $found = 0
        for ($i = 0; $i -lt $service.AdditionalRegions.Count; $i++) {
            if ($service.AdditionalRegions[$i].Location -eq $secondarylocation) {
                $found = $found + 1
                Assert-AreEqual $sku $service.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $service.AdditionalRegions[$i].Capacity
                Assert-NotNull $service.AdditionalRegions[$i].VirtualNetwork
                Assert-AreEqual $additionalSubnetResourceId $service.AdditionalRegions[$i].VirtualNetwork.SubnetResourceId
                Assert-NotNull $service.AdditionalRegions[$i].PrivateIPAddresses
                Assert-NotNull $service.AdditionalRegions[$i].PublicIPAddresses
            }
        }
        
        Assert-True {$found -eq 1} "Api Management regions created earlier is not found."
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName    
    }
}

<#
.SYNOPSIS
Tests ApiManagementHostnames CRUD
Creates a service with multiple proxy hostname and custom hostname for portal and management
Then updates the service by removing all but just one proxy hostname and adding an intermediate certificate 
#>
function Test-ApiManagementHostnamesCRUD {
    # Setup
    $location = "North Central US"
    $certFilePath = "$TestOutputRoot\powershelltest.pfx";
    $certPassword = "Password";
    $certSubject = "CN=*.msitesting.net"
    $certThumbprint = "8E989652CABCF585ACBFCB9C2C91F1D174FDB3A2"
    $portalHostName = "portalsdk.msitesting.net"
    $proxyHostName1 = "gateway1.msitesting.net"
    $proxyHostName2 = "gateway2.msitesting.net"
    $managementHostName = "mgmt.msitesting.net"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Premium" # Multiple hostname is only supported in Premium SKU
    $capacity = 1
    
    try {
        # Create resource group    
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

        #Create Custom Hostname configuration
        $securePfxPassword = ConvertTo-SecureString $certPassword -AsPlainText -Force
        $customProxy1 = New-AzureRmApiManagementCustomHostnameConfiguration -Hostname $proxyHostName1 -HostnameType Proxy -PfxPath $certFilePath -PfxPassword $securePfxPassword -DefaultSslBinding
        $customProxy2 = New-AzureRmApiManagementCustomHostnameConfiguration -Hostname $proxyHostName2 -HostnameType Proxy -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $customPortal = New-AzureRmApiManagementCustomHostnameConfiguration -Hostname $portalHostName -HostnameType Portal -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $customMgmt = New-AzureRmApiManagementCustomHostnameConfiguration -Hostname $managementHostName -HostnameType Management -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $customHostnames = @($customProxy1, $customProxy2, $customPortal, $customMgmt)

        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity -CustomHostnameConfiguration $customHostnames

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual "None" $result.VpnType
        
        #validate the Proxy Custom Hostname configuration
        Assert-NotNull $result.ProxyCustomHostnameConfiguration
        Assert-AreEqual 2 $result.ProxyCustomHostnameConfiguration.Count
        for ($i = 0; $i -lt $result.ProxyCustomHostnameConfiguration.Count; $i++) {
            if ($result.ProxyCustomHostnameConfiguration[$i].Hostname -eq $proxyHostName1) {
                $found = $found + 1
                Assert-AreEqual Proxy $result.ProxyCustomHostnameConfiguration[$i].HostnameType
                Assert-AreEqual $certThumbprint $result.ProxyCustomHostnameConfiguration[$i].CertificateInformation.Thumbprint
                Assert-True {$result.ProxyCustomHostnameConfiguration[$i].DefaultSslBinding}
                Assert-False {$result.ProxyCustomHostnameConfiguration[$i].NegotiateClientCertificate}
                Assert-Null $result.ProxyCustomHostnameConfiguration[$i].KeyVaultId
            }
            if ($result.ProxyCustomHostnameConfiguration[$i].Hostname -eq $proxyHostName2) {
                $found = $found + 1
                Assert-AreEqual Proxy $result.ProxyCustomHostnameConfiguration[$i].HostnameType
                Assert-AreEqual $certThumbprint $result.ProxyCustomHostnameConfiguration[$i].CertificateInformation.Thumbprint
                # default sslbinding is true for second hostname also, as the ssl certificate is same
                Assert-True {$result.ProxyCustomHostnameConfiguration[$i].DefaultSslBinding}
                Assert-False {$result.ProxyCustomHostnameConfiguration[$i].NegotiateClientCertificate}
                Assert-Null $result.ProxyCustomHostnameConfiguration[$i].KeyVaultId
            }
        }

        #validate the portal custom hostname configuration
        Assert-NotNull $result.PortalCustomHostnameConfiguration
        Assert-AreEqual $portalHostName $result.PortalCustomHostnameConfiguration.Hostname
        Assert-AreEqual Portal $result.PortalCustomHostnameConfiguration.HostnameType
        Assert-AreEqual $certThumbprint $result.PortalCustomHostnameConfiguration.CertificateInformation.Thumbprint

        #validate the management custom hostname configuration
        Assert-NotNull $result.ManagementCustomHostnameConfiguration
        Assert-AreEqual $managementHostName $result.ManagementCustomHostnameConfiguration.Hostname
        Assert-AreEqual Management $result.ManagementCustomHostnameConfiguration.HostnameType
        Assert-AreEqual $certThumbprint $result.ManagementCustomHostnameConfiguration.CertificateInformation.Thumbprint

        #scm configuration is null
        Assert-Null $result.ScmCustomHostnameConfiguration
        
        # now delete all but one Proxy Custom Hostname         
        $result.ManagementCustomHostnameConfiguration = $null
        $result.PortalCustomHostnameConfiguration = $null
        $result.ProxyCustomHostnameConfiguration = @($customProxy1)

        # add a system certificate
        $certificateStoreLocation = "CertificateAuthority"
        $systemCert = New-AzureRmApiManagementSystemCertificate -StoreName $certificateStoreLocation -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $result.SystemCertificates = @($systemCert)
        
        # apply the new configuration
        $result = Set-AzureRmApiManagement -ApiManagement $result -PassThru 

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual "None" $result.VpnType
        
        #validate the Proxy Custom Hostname configuration
        Assert-NotNull $result.ProxyCustomHostnameConfiguration
        Assert-AreEqual 1 $result.ProxyCustomHostnameConfiguration.Count
        for ($i = 0; $i -lt $result.ProxyCustomHostnameConfiguration.Count; $i++) {
            if ($result.ProxyCustomHostnameConfiguration[$i].Hostname -eq $proxyHostName1) {
                $found = $found + 1
                Assert-AreEqual Proxy $result.ProxyCustomHostnameConfiguration[$i].HostnameType
                Assert-AreEqual $certThumbprint $result.ProxyCustomHostnameConfiguration[$i].CertificateInformation.Thumbprint
                Assert-True {$result.ProxyCustomHostnameConfiguration[$i].DefaultSslBinding}
                Assert-False {$result.ProxyCustomHostnameConfiguration[$i].NegotiateClientCertificate}
                Assert-Null $result.ProxyCustomHostnameConfiguration[$i].KeyVaultId
            }
        }

        #validate the portal custom hostname configuration
        Assert-Null $result.PortalCustomHostnameConfiguration
        #validate the management custom hostname configuration
        Assert-Null $result.ManagementCustomHostnameConfiguration
        #scm configuration is null
        Assert-Null $result.ScmCustomHostnameConfiguration
        #validate the system certificates
        Assert-NotNull $result.SystemCertificates
        Assert-AreEqual 1 $result.SystemCertificates.Count
        Assert-AreEqual $certificateStoreLocation $result.SystemCertificates.StoreName
        Assert-AreEqual $certThumbprint $result.SystemCertificates.CertificateInformation.Thumbprint
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName   
    }
}


<#
.SYNOPSIS
Tests UpdateAzureApiManagementDeployment using pipeline and helper cmdlets.
#>
function Test-UpdateApiManagementDeployment {
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    
    try {
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
        for ($i = 0; $i -lt $service.AdditionalRegions.Count; $i++) {
            if ($service.AdditionalRegions[$i].Location -eq $region1Location) {
                $found = $found + 1
                Assert-AreEqual $region1Sku $service.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $service.AdditionalRegions[$i].Capacity
                Assert-Null $service.AdditionalRegions[$i].VirtualNetwork
            }
        }
        
        Assert-True {$found -eq 1} "Api Management regions created earlier is not found."
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests SetApiManagementHostnames.
#>
function Test-SetApiManagementHostnames {
    # Setup
    $location = "North Central US"
    $certFilePath = "$TestOutputRoot\powershelltest.pfx";
    $certPassword = "Password";
    $certSubject = "CN=*.msitesting.net"
    $certThumbprint = "8E989652CABCF585ACBFCB9C2C91F1D174FDB3A2"
    $portalHostName = "onesdk.msitesting.net"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    
    try {
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
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName   
    }
}


<#
.SYNOPSIS
Tests API Management Create with 2 Additional Region
Then remove one Additional Region and scale up another additional region and Enable Msi Identity
#>
function Test-ApiManagementWithAdditionalRegionsCRUD {
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"  
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Premium"
    $capacity = 1
    $firstAdditionalRegionLocation = "East US"
    $secondAdditionalRegionLocation = "South Central US"
		
    try {
        # Create Resource Group
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $location
		
        $firstAdditionalRegion = New-AzureRmApiManagementRegion -Location $firstAdditionalRegionLocation
        $secondAdditionalRegion = New-AzureRmApiManagementRegion -Location $secondAdditionalRegionLocation
        $regions = @($firstAdditionalRegion, $secondAdditionalRegion)
        
        # Create API Management service
        $result = New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku -Capacity $capacity -AdditionalRegions $regions

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual $capacity $result.Capacity
        Assert-AreEqual "None" $result.VpnType
		
        Assert-AreEqual 2 $result.AdditionalRegions.Count
        $found = 0
        for ($i = 0; $i -lt $result.AdditionalRegions.Count; $i++) {
            if ($result.AdditionalRegions[$i].Location.Replace(" ", "") -eq $firstAdditionalRegionLocation.Replace(" ", "")) {
                $found = $found + 1
                Assert-AreEqual $sku $result.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $result.AdditionalRegions[$i].Capacity
                Assert-Null $result.AdditionalRegions[$i].VirtualNetwork
            }
            if ($result.AdditionalRegions[$i].Location.Replace(" ", "") -eq $secondAdditionalRegionLocation.Replace(" ", "")) {
                $found = $found + 1
                Assert-AreEqual $sku $result.AdditionalRegions[$i].Sku
                Assert-AreEqual 1 $result.AdditionalRegions[$i].Capacity
                Assert-Null $result.AdditionalRegions[$i].VirtualNetwork
            }
        }

        #remove the first additional region and scale up second additional region
        $newAdditionalRegionCapacity = 2
        $apimService = Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName
        $apimService = Remove-AzureRmApiManagementRegion -ApiManagement $apimService -Location $firstAdditionalRegionLocation
        $apimService = Update-AzureRmApiManagementRegion -ApiManagement $apimService -Location $secondAdditionalRegionLocation -Capacity $newAdditionalRegionCapacity -Sku $sku

        # Set the ApiManagement service and Enable Msi idenity on the service
        $updatedService = Set-AzureRmApiManagement -ApiManagement $apimService -AssignIdentity -PassThru
        Assert-AreEqual $resourceGroupName $updatedService.ResourceGroupName
        Assert-AreEqual $apiManagementName $updatedService.Name
        Assert-AreEqual $location $updatedService.Location
        Assert-AreEqual $sku $updatedService.Sku
        Assert-AreEqual $capacity $updatedService.Capacity
        Assert-AreEqual "None" $updatedService.VpnType
		
        Assert-AreEqual 1 $updatedService.AdditionalRegions.Count
        $found = 0
        # Validate the Additional Region capacity
        for ($i = 0; $i -lt $updatedService.AdditionalRegions.Count; $i++) {            
            if ($updatedService.AdditionalRegions[$i].Location.Replace(" ", "") -eq $secondAdditionalRegionLocation.Replace(" ", "")) {
                $found = $found + 1
                Assert-AreEqual $sku $updatedService.AdditionalRegions[$i].Sku
                Assert-AreEqual $newAdditionalRegionCapacity $updatedService.AdditionalRegions[$i].Capacity
                Assert-Null $updatedService.AdditionalRegions[$i].VirtualNetwork
            }
        }

        # validate ApiManagement Identity
        Assert-AreEqual "SystemAssigned" $updatedService.Identity.Type;
        Assert-NotNull $updatedService.Identity.PrincipalId;
        Assert-NotNull $updatedService.Identity.TenantId;
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests API Management Create in External VpnType ARM VNET Subnet.
#>
function Test-CrudApiManagementWithExternalVpn {
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


    try {
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
    finally {
        # Cleanup
        Clean-ResourceGroup $resourceGroupName
    }
}