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
	$enableTls=@{"Tls10" = "True"}
	$enable3DES=@{"TripleDes168" = "True"}
	$thirdApiManagementName = Get-ApiManagementServiceName
	$thirdSku = "Consumption"
	$thirdServiceLocation = "West Europe"

    try {
        # Create Resource Group
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
		# enable TLS and 3DES CipherSuite
		$sslSetting = New-AzApiManagementSslSetting -FrontendProtocol $enableTls -CipherSuite $enable3DES
        # Create API Management service
        $result = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -SslSetting $sslSetting

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual "Developer" $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-NotNull $result.DeveloperPortalUrl
        Assert-NotNull $result.PortalUrl
        Assert-NotNull $result.RuntimeUrl
        Assert-NotNull $result.ManagementApiUrl
        Assert-AreEqual "None" $result.VpnType
		Assert-NotNull $result.SslSetting
		Assert-AreEqual "True" $result.SslSetting.FrontendProtocol["Tls10"]
		Assert-AreEqual "True" $result.SslSetting.CipherSuite["TripleDes168"]

        # Get SSO token
        $token = Get-AzApiManagementSsoToken -ResourceGroupName $resourceGroupName -Name $apiManagementName
        Assert-NotNull $token

        # List services within the resource group
        $apimServicesInGroup = Get-AzApiManagement -ResourceGroupName $resourceGroupName
        Assert-True {$apimServicesInGroup.Count -ge 1}
        
        #Create Second Service
        $secondResult = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $secondApiManagementName -Organization $secondOrganization -AdminEmail $secondAdminEmail -Sku $secondSku -Capacity $secondSkuCapacity
        Assert-AreEqual $resourceGroupName $secondResult.ResourceGroupName
        Assert-AreEqual $secondApiManagementName $secondResult.Name
        Assert-AreEqual $location $secondResult.Location
        Assert-AreEqual $secondSku $secondResult.Sku
        Assert-AreEqual $secondSkuCapacity $secondResult.Capacity

        # Get SSO token
        $secondToken = Get-AzApiManagementSsoToken -ResourceGroupName $resourceGroupName -Name $secondApiManagementName
        Assert-NotNull $secondToken

        # List all services
        $allServices = Get-AzApiManagement
        Assert-True {$allServices.Count -ge 2}
				
        #Create Third Service of Consumption SKU
        $thirdResult = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $thirdServiceLocation -Name $thirdApiManagementName -Organization $secondOrganization -AdminEmail $secondAdminEmail -Sku $thirdSku
        Assert-AreEqual $resourceGroupName $thirdResult.ResourceGroupName
        Assert-AreEqual $thirdApiManagementName $thirdResult.Name
        Assert-AreEqual $thirdServiceLocation $thirdResult.Location
        Assert-AreEqual $thirdSku $thirdResult.Sku

		# List all services
        $allServices = Get-AzApiManagement
        Assert-True {$allServices.Count -ge 3}
		        
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
			
            if ($allServices[$i].Name -eq $thirdApiManagementName) {
                $found = $found + 1
                Assert-AreEqual $thirdServiceLocation $allServices[$i].Location
                Assert-AreEqual $resourceGroupName $allServices[$i].ResourceGroupName
        
                Assert-AreEqual $thirdSku $allServices[$i].Sku
            }
        }
        Assert-True {$found -eq 3} "Api Management services created earlier is not found."
        
        # Delete listed services in the ResourceGroup
        Get-AzApiManagement -ResourceGroupName $resourceGroupName | Remove-AzApiManagement

        $allServices = Get-AzApiManagement -ResourceGroupName $resourceGroupName
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
        New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

        # Create storage account    
        New-AzStorageAccount -StorageAccountName $storageAccountName -Location $storageLocation -ResourceGroupName $resourceGroupName -Type Standard_LRS
        $storageKey = (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName).Key1
        $storageContext = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageKey
        
        # Create API Management service
        $apiManagementService = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail

        # Backup API Management service
        Backup-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -TargetContainerName $containerName -TargetBlobName $backupName

        # Restore API Management service
        $restoreResult = Restore-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -SourceContainerName $containerName -SourceBlobName $backupName -PassThru

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
    $primarylocation = "East US"
    $secondarylocation = "South Central US"
    $resourceGroupName = Get-ResourceGroupName    
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    $primarySubnetResourceId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/powershellvneteastus/subnets/default"
    $additionalSubnetResourceId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/powershellvnetscu/subnets/default"
    $vpnType = "External" 
 
    try {
        # Create Resource Group
        New-AzResourceGroup -Name $resourceGroupName -Location $primarylocation
 
        # Create a Virtual Network Object
        $virtualNetwork = New-AzApiManagementVirtualNetwork -SubnetResourceId $primarySubnetResourceId
         
        # Create API Management service in External VNET
        $result = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $primarylocation -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -VpnType $vpnType -VirtualNetwork $virtualNetwork -Sku $sku -Capacity $capacity
 
        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $primarylocation $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual $vpnType $result.VpnType
        Assert-Null $result.PrivateIPAddresses
        Assert-NotNull $result.PublicIPAddresses
        Assert-AreEqual $primarySubnetResourceId $result.VirtualNetwork.SubnetResourceId

		$networkStatus = Get-AzApiManagementNetworkStatus -ResourceGroupName $resourceGroupName -Name $apiManagementName
        Assert-NotNull $networkStatus
		Assert-NotNull $networkStatus.DnsServers
		Assert-NotNull $networkStatus.ConnectivityStatus

        # Get the service and switch to internal Virtual Network
        $service = Get-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName
        $vpnType = "Internal"
        $service.VirtualNetwork = $virtualNetwork
        $service.VpnType = $vpnType
        # update the SKU to Premium SKU
        $sku = "Premium"
        $service.Sku = $sku
        
        # Create Virtual Network Object for Additional region
        $additionalRegionVirtualNetwork = New-AzApiManagementVirtualNetwork -SubnetResourceId $additionalSubnetResourceId

        $service = Add-AzApiManagementRegion -ApiManagement $service -Location $secondarylocation -VirtualNetwork $additionalRegionVirtualNetwork
        # Update the Deployment into Internal Virtual Network
        $service = Set-AzApiManagement -InputObject $service -PassThru

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

		# check the network status for the service.
		$networkStatus = Get-AzApiManagementNetworkStatus -ApiManagementObject $service
        Assert-NotNull $networkStatus
		Assert-NotNull $networkStatus.DnsServers
		Assert-NotNull $networkStatus.ConnectivityStatus

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
    $location = "East US"
    $certFilePath = "$TestOutputRoot/powershelltest.pfx";
    $certPassword = "Password";
    $certSubject = "CN=*.msitesting.net"
    $certThumbprint = "8E989652CABCF585ACBFCB9C2C91F1D174FDB3A2"
    $portalHostName = "portalsdk.msitesting.net"
    $devPortalHostName = "devportalsdk.msitesting.net"
    $proxyHostName1 = "gateway1.msitesting.net"
    $proxyHostName2 = "powershelltest.current.int-azure-api.net"
    $managementHostName = "mgmt.msitesting.net"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Premium" # Multiple hostname is only supported in Premium SKU
    $capacity = 1
    $keyVaultId = "https://powershell-apim-kv.vault.azure.net/secrets/powershell-current"
    $identityClientId = "4b7fdc4d-a154-4830-b399-46a12da1a1e2"
    $userIdentity = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/powershellTestUserIdentity"
    
    try {
        # Create resource group    
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        #Create Custom Hostname configuration
        $securePfxPassword = ConvertTo-SecureString $certPassword -AsPlainText -Force
        $customProxy1 = New-AzApiManagementCustomHostnameConfiguration -Hostname $proxyHostName1 `
                          -HostnameType Proxy -PfxPath $certFilePath -PfxPassword $securePfxPassword -DefaultSslBinding
        $customProxy2 = New-AzApiManagementCustomHostnameConfiguration -Hostname $proxyHostName2 `
                          -HostnameType Proxy -KeyVaultId $keyVaultId -IdentityClientId $identityClientId
        $customPortal = New-AzApiManagementCustomHostnameConfiguration -Hostname $portalHostName -HostnameType Portal -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $customDevPortal = New-AzApiManagementCustomHostnameConfiguration -Hostname $devPortalHostName -HostnameType DeveloperPortal -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $customMgmt = New-AzApiManagementCustomHostnameConfiguration -Hostname $managementHostName -HostnameType Management -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $customHostnames = @($customProxy1, $customProxy2, $customPortal, $customMgmt, $customDevPortal)

        # UserAssigned Identity
        $userIdentities = @($userIdentity)

        # Create API Management service
        $result = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $location `
                   -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -Sku $sku `
                   -UserAssignedIdentity $userIdentities -Capacity $capacity -CustomHostnameConfiguration $customHostnames

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual "None" $result.VpnType
         # validate ApiManagement Identity
        Assert-AreEqual "UserAssigned" $result.Identity.Type;
        
        #validate the Proxy Custom Hostname configuration
        Assert-NotNull $result.ProxyCustomHostnameConfiguration
        Assert-AreEqual 3 $result.ProxyCustomHostnameConfiguration.Count
        for ($i = 0; $i -lt $result.ProxyCustomHostnameConfiguration.Count; $i++) {
            if ($result.ProxyCustomHostnameConfiguration[$i].Hostname -eq $proxyHostName1) {
                $found = $found + 1
                Assert-AreEqual Proxy $result.ProxyCustomHostnameConfiguration[$i].HostnameType
                Assert-NotNull $result.ProxyCustomHostnameConfiguration[$i].CertificateInformation.Thumbprint
                Assert-True {$result.ProxyCustomHostnameConfiguration[$i].DefaultSslBinding}
                Assert-False {$result.ProxyCustomHostnameConfiguration[$i].NegotiateClientCertificate}                
                Assert-Null $result.ProxyCustomHostnameConfiguration[$i].KeyVaultId
                Assert-Null $result.ProxyCustomHostnameConfiguration[$i].IdentityClientId
            }
            if ($result.ProxyCustomHostnameConfiguration[$i].Hostname -eq $proxyHostName2) {
                $found = $found + 1
                Assert-AreEqual Proxy $result.ProxyCustomHostnameConfiguration[$i].HostnameType
                Assert-NotNull $result.ProxyCustomHostnameConfiguration[$i].CertificateInformation.Thumbprint
                # default sslbinding is true for second hostname also, as the ssl certificate is same
                Assert-False {$result.ProxyCustomHostnameConfiguration[$i].DefaultSslBinding}
                Assert-False {$result.ProxyCustomHostnameConfiguration[$i].NegotiateClientCertificate}
                Assert-AreEqual $keyVaultId $result.ProxyCustomHostnameConfiguration[$i].KeyVaultId
                Assert-AreEqual $identityClientId $result.ProxyCustomHostnameConfiguration[$i].IdentityClientId
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

        #validate the DeveloperPortal custom hostname configuration
        Assert-NotNull $result.DeveloperPortalHostnameConfiguration
        Assert-AreEqual $devPortalHostName $result.DeveloperPortalHostnameConfiguration.Hostname
        Assert-AreEqual DeveloperPortal $result.DeveloperPortalHostnameConfiguration.HostnameType
        Assert-AreEqual $certThumbprint $result.DeveloperPortalHostnameConfiguration.CertificateInformation.Thumbprint

        #scm configuration is null
        Assert-Null $result.ScmCustomHostnameConfiguration
        
        # now delete all but one Proxy Custom Hostname
        $result.ManagementCustomHostnameConfiguration = $null
        $result.PortalCustomHostnameConfiguration = $null
        $result.DeveloperPortalHostnameConfiguration = $null
        $result.ProxyCustomHostnameConfiguration = @($customProxy1)

        # add a system certificate
        $certificateStoreLocation = "CertificateAuthority"
        $systemCert = New-AzApiManagementSystemCertificate -StoreName $certificateStoreLocation -PfxPath $certFilePath -PfxPassword $securePfxPassword
        $result.SystemCertificates = @($systemCert)
        
        # apply the new configuration
        $result = Set-AzApiManagement -InputObject $result -PassThru 

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
        }

        #validate the portal custom hostname configuration
        Assert-Null $result.PortalCustomHostnameConfiguration
        #validate the developerPortal custom hostname configuration
        Assert-Null $result.DeveloperPortalHostnameConfiguration
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
Tests API Management Create with 2 Additional Region
Then remove one Additional Region and scale up another additional region and Enable Msi Identity
#>
function Test-ApiManagementWithAdditionalRegionsCRUD {
    # Setup
    $location = "West US 2"  
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Premium"
    $capacity = 2
    $zones = @("1", "2")
    $firstAdditionalRegionLocation = "East US"
    $secondAdditionalRegionLocation = "South Central US"
    $userIdentity = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/powershellTestUserIdentity"
		
    try {
        # Create Resource Group
        New-AzResourceGroup -Name $resourceGroupName -Location $location
		
        $firstAdditionalRegion = New-AzApiManagementRegion -Location $firstAdditionalRegionLocation `
                                  -Capacity $capacity -Zone $zones -DisableGateway $true
        $secondAdditionalRegion = New-AzApiManagementRegion -Location $secondAdditionalRegionLocation `
                                   -Capacity $capacity -Zone $zones -DisableGateway $true
        $regions = @($firstAdditionalRegion, $secondAdditionalRegion)
        
        $userIdentities = @($userIdentity)

        # Create API Management service
        $result = New-AzApiManagement -ResourceGroupName $resourceGroupName `
                       -Location $location -Name $apiManagementName -Organization $organization `
                       -AdminEmail $adminEmail -Sku $sku -Capacity $capacity -AdditionalRegions $regions `
                       -UserAssignedIdentity $userIdentities -Zone $zones -DisableGateway $false -MinimalControlPlaneApiVersion "2019-12-01"

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual $capacity $result.Capacity
        Assert-AreEqual "None" $result.VpnType
        Assert-AreEqual 2 $result.Zone.Count
        Assert-AreEqual $false $result.DisableGateway
		
        Assert-AreEqual 2 $result.AdditionalRegions.Count
        $found = 0
        for ($i = 0; $i -lt $result.AdditionalRegions.Count; $i++) {
            if ($result.AdditionalRegions[$i].Location.Replace(" ", "") -eq $firstAdditionalRegionLocation.Replace(" ", "")) {
                $found = $found + 1
                Assert-AreEqual $sku $result.AdditionalRegions[$i].Sku
                Assert-AreEqual $capacity $result.AdditionalRegions[$i].Capacity
                Assert-Null $result.AdditionalRegions[$i].VirtualNetwork
                Assert-AreEqual $true $result.AdditionalRegions[$i].DisableGateway
                Assert-AreEqual 2 $result.AdditionalRegions[$i].Zone.Count
            }
            if ($result.AdditionalRegions[$i].Location.Replace(" ", "") -eq $secondAdditionalRegionLocation.Replace(" ", "")) {
                $found = $found + 1
                Assert-AreEqual $sku $result.AdditionalRegions[$i].Sku
                Assert-AreEqual $capacity $result.AdditionalRegions[$i].Capacity
                Assert-Null $result.AdditionalRegions[$i].VirtualNetwork
                Assert-AreEqual $true $result.AdditionalRegions[$i].DisableGateway
                Assert-AreEqual 2 $result.AdditionalRegions[$i].Zone.Count
            }
        }

        # validate ApiManagement Identity
        Assert-AreEqual "UserAssigned" $result.Identity.Type;
 #       Assert-Null $result.Identity.PrincipalId;
 #       Assert-Null $result.Identity.TenantId;
        Assert-NotNull $result.Identity.UserAssignedIdentity;
        foreach ($key in $result.Identity.UserAssignedIdentity.Keys) { 
            Assert-AreEqual $userIdentity $key;
            Assert-NotNull $result.Identity.UserAssignedIdentity[$key].PrincipalId
            Assert-NotNull $result.Identity.UserAssignedIdentity[$key].ClientId
        } 

        #remove the first additional region and scale up second additional region
        $newAdditionalRegionCapacity = 2
        $apimService = Get-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName
        $apimService = Remove-AzApiManagementRegion -ApiManagement $apimService -Location $firstAdditionalRegionLocation
        $apimService = Update-AzApiManagementRegion -ApiManagement $apimService -Location $secondAdditionalRegionLocation `
                                -Capacity $newAdditionalRegionCapacity -Sku $sku -Zone "1" -DisableGateway $false

        # Set the ApiManagement service and Enable Msi idenity on the service
        $updatedService = Set-AzApiManagement -InputObject $apimService -SystemAssignedIdentity -UserAssignedIdentity $userIdentities -PassThru
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
                Assert-AreEqual $false $updatedService.AdditionalRegions[$i].DisableGateway
                Assert-AreEqual 1 $updatedService.AdditionalRegions[$i].Zone.Count
            }
        }

        # validate ApiManagement Identity
        Assert-AreEqual "SystemAssigned, UserAssigned" $updatedService.Identity.Type;
        Assert-NotNull $updatedService.Identity.PrincipalId;
        Assert-NotNull $updatedService.Identity.TenantId;
        Assert-NotNull $updatedService.Identity.UserAssignedIdentity;
        foreach ($key in $updatedService.Identity.UserAssignedIdentity.Keys) 
        { 
            Assert-AreEqual $userIdentity $key;
            Assert-NotNull $updatedService.Identity.UserAssignedIdentity[$key].PrincipalId
            Assert-NotNull $updatedService.Identity.UserAssignedIdentity[$key].ClientId
        }

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
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # Create a Virtual Network Object
        $virtualNetwork = New-AzApiManagementVirtualNetwork -Location $location -SubnetResourceId $subnetResourceId
        
        # Create API Management service
        $result = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -VpnType $vpnType -VirtualNetwork $virtualNetwork -Sku $sku -Capacity $capacity

        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $location $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual $vpnType $result.VpnType
        Assert-AreEqual $subnetResourceId $result.VirtualNetwork.SubnetResourceId

        # Delete listed services in the ResourceGroup
        Get-AzApiManagement -ResourceGroupName $resourceGroupName | Remove-AzApiManagement

        $allServices = Get-AzApiManagement -ResourceGroupName $resourceGroupName
        Assert-AreEqual 0 $allServices.Count
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
function Test-ApiManagementVirtualNetworkStv2CRUD {
    # Setup
    $primarylocation = "East US"
    $secondarylocation = "South Central US"
    $resourceGroupName = Get-ResourceGroupName
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $sku = "Developer"
    $capacity = 1
    $primarySubnetResourceId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/powershellvneteastus/subnets/stv2subnet"
    $primaryPublicIPAddressId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/publicIPAddresses/powershellvneteastusip";
    $primaryPublicIPAddressId2 = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/publicIPAddresses/powershellvneteastusip2";
    $additionalSubnetResourceId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/virtualNetworks/powershellvnetscu/subnets/stv2subnet"
    $additionalPublicIPAddressId = "/subscriptions/a200340d-6b82-494d-9dbf-687ba6e33f9e/resourceGroups/powershelltest/providers/Microsoft.Network/publicIPAddresses/powershellvnetscuip";
    $vpnType = "External" 
 
    try {
        # Create Resource Group
        New-AzResourceGroup -Name $resourceGroupName -Location $primarylocation
 
        # Create a Virtual Network Object
        $virtualNetwork = New-AzApiManagementVirtualNetwork -SubnetResourceId $primarySubnetResourceId
         
        # Create API Management service in External VNET
        $result = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $primarylocation -Name $apiManagementName -Organization $organization -AdminEmail $adminEmail -VpnType $vpnType `
                    -VirtualNetwork $virtualNetwork -PublicIpAddressId $primaryPublicIPAddressId -Sku $sku -Capacity $capacity 
 
        Assert-AreEqual $resourceGroupName $result.ResourceGroupName
        Assert-AreEqual $apiManagementName $result.Name
        Assert-AreEqual $primarylocation $result.Location
        Assert-AreEqual $sku $result.Sku
        Assert-AreEqual 1 $result.Capacity
        Assert-AreEqual $vpnType $result.VpnType
        Assert-Null $result.PrivateIPAddresses
        Assert-NotNull $result.PublicIPAddresses
        Assert-AreEqual $primarySubnetResourceId $result.VirtualNetwork.SubnetResourceId
        

		$networkStatus = Get-AzApiManagementNetworkStatus -ResourceGroupName $resourceGroupName -Name $apiManagementName
        Assert-NotNull $networkStatus
		Assert-NotNull $networkStatus.DnsServers
		Assert-NotNull $networkStatus.ConnectivityStatus

        # Get the service and switch to internal Virtual Network
        $service = Get-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName
        $vpnType = "Internal"
        $service.VirtualNetwork = $virtualNetwork
        $service.PublicIpAddressId = $primaryPublicIPAddressId2
        $service.VpnType = $vpnType
        # update the SKU to Premium SKU
        $sku = "Premium"
        $service.Sku = $sku
        
        # Create Virtual Network Object for Additional region
        $additionalRegionVirtualNetwork = New-AzApiManagementVirtualNetwork -SubnetResourceId $additionalSubnetResourceId

        $service = Add-AzApiManagementRegion -ApiManagement $service -Location $secondarylocation `
                    -VirtualNetwork $additionalRegionVirtualNetwork -PublicIpAddressId $additionalPublicIPAddressId
        # Update the Deployment into Internal Virtual Network
        $service = Set-AzApiManagement -InputObject $service -PassThru

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
                Assert-NotNull $service.AdditionalRegions[$i].PublicIpAddressId
            }
        }
        
        Assert-True {$found -eq 1} "Api Management regions created earlier is not found."

		# check the network status for the service.
		$networkStatus = Get-AzApiManagementNetworkStatus -ApiManagementObject $service
        Assert-NotNull $networkStatus
		Assert-NotNull $networkStatus.DnsServers
		Assert-NotNull $networkStatus.ConnectivityStatus

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
function Test-BackupRestoreApiManagementUsingManagedIdentity {
    # Setup
    $location = Get-ProviderLocation "Microsoft.ApiManagement/service"
    $resourceGroupName = Get-ResourceGroupName
    $storageLocation = "westus2"
    $storageAccountName = "apimbackupmsi"
    $msiClientId = "a6270d0c-7d86-478b-8cbe-dc9047ba54f7"
    $msiUserAssignedId = "/subscriptions/4f5285a3-9fd7-40ad-91b1-d8fc3823983d/resourceGroups/net-sdk-backup-restore/providers/Microsoft.ManagedIdentity/userAssignedIdentities/apim-backup-restore-msi"
    $apiManagementName = Get-ApiManagementServiceName
    $organization = "apimpowershellorg"
    $adminEmail = "apim@powershell.org"
    $containerName = "backups"
    $backupName = $apiManagementName + ".apimbackup"

    
    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

        # Create storage account context
        $storageContext = New-AzStorageContext -StorageAccountName $storageAccountName
        
        # Create API Management service
        $apiManagementService = New-AzApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName `
                -Organization $organization -AdminEmail $adminEmail -UserAssignedIdentity @($msiUserAssignedId)

        # Backup API Management service
        Backup-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext `
                    -TargetContainerName $containerName -TargetBlobName $backupName -AccessType "UserAssignedManagedIdentity" -IdentityClientId $msiClientId

        # Restore API Management service
        $restoreResult = Restore-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext `
                -SourceContainerName $containerName -SourceBlobName $backupName -AccessType "UserAssignedManagedIdentity" -IdentityClientId $msiClientId -PassThru

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