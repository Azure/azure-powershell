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
.Synopsis
Create a CloudService Resource
.Description
Create a CloudService Resource 
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudservice
#>

function New-AzCloudService {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
        [Alias('CloudServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the cloud service.
        ${Name},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the resource group.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage')]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [System.String]
        # Resource location.
        ${Location},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [System.String]
        # Specifies the XML service configuration (.cscfg) for the cloud service.
        ${ConfigurationFile},
        
        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory, HelpMessage="Path to .csdef file.")]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory, HelpMessage="Path to .csdef file.")]
        [System.String]
        # Specifies the XML service definitions (.csdef) for the cloud service. 
        ${DefinitionFile},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory, HelpMessage='URL that refers to the location of the service package in the Blob service.')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [System.String]
        # Specifies a URL that refers to the location of the service package in the Blob service.
        # The service package URL can be Shared Access Signature (SAS) URI from any storage account.This is a write-only property and is not returned in GET calls.
        ${PackageUrl},

        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory, HelpMessage='Path to .cspkg file. It will be uploaded to a blob')]
        [System.String]
        ${PackageFile},

        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory, HelpMessage='Name of the storage account that will store the Package file.')]
        [System.String]
        ${StorageAccount},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', HelpMessage="Describes a cloud service extension profile.")]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', HelpMessage="Describes a cloud service extension profile.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile]
        # Describes a cloud service extension profile.
        # To construct, see NOTES section for EXTENSIONPROFILE properties and create a hash table.
        ${ExtensionProfile},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', HelpMessage="Indicates whether to start the cloud service immediately after it is created.")]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', HelpMessage="Indicates whether to start the cloud service immediately after it is created.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # (Optional) Indicates whether to start the cloud service immediately after it is created.
        # The default value is `true`.If false, the service model is still deployed, but the code is not run immediately.
        # Instead, the service is PoweredOff until you call Start, at which time the service will be started.
        # A deployed service still incurs charges, even if it is poweredoff.
        ${StartCloudService},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage')]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', HelpMessage="Update mode for the cloud service.")]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', HelpMessage="Update mode for the cloud service.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode])]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode]
        # Update mode for the cloud service.
        # Role instances are allocated to update domains when the service is deployed.
        # Updates can be initiated manually in each update domain or initiated automatically in all update domains.Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />If not specified, the default value is Auto.
        # If set to Manual, PUT UpdateDomain must be called to apply the update.
        # If set to Auto, the update is automatically applied to each update domain in sequence.
        ${UpgradeMode},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', HelpMessage= "Name of Dns to be used for the CloudService resource.")]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', HelpMessage= "Name of Dns to be used for the CloudService resource.")]
        [System.String]
        # Name of Dns to be used for the CloudService resource
        ${DnsName},

        [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', HelpMessage= "Name of the KeyVault to be used for the CloudService resource.")]
        [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', HelpMessage= "Name of the KeyVault to be used for the CloudService resource.")]
        [System.String]
        # Name of the KeyVault to be used for the CloudService resource
        ${KeyVaultName}
    )

    process {
        Import-Module Az.Network
        Import-Module Az.KeyVault
        Import-Module Az.Storage

        # extract csdef/cscfg 

        if (-not (Test-Path $ConfigurationFile))  
        {
            Write-Error "Cannot find file $ConfigurationFile. Please make sure it exists!"
            exit 1
        }
        if (-not (Test-Path $DefinitionFile))
        {
            Write-Error "Cannot find file $DefinitionFile. Please make sure it exists!"
            exit 1
        }
        [xml]$csdef = Get-Content -Path $DefinitionFile
        [xml]$cscfg = Get-Content -Path $ConfigurationFile
        $Configuration = Get-Content -Path $ConfigurationFile | Out-String

        # do validation 
        $passMemory = @{}
        validation $cscfg $csdef $PSBoundParameters ([ref]$passMemory)

        
        # if -storageaccount is given, upload to packageUrl to blob 
        if ($PSBoundParameters.ContainsKey("StorageAccount")) 
        {
            Write-Host("Uploading the csdef to a blob in the Storage Account.")
            $storageAccountObj = Get-AzStorageAccount -resourceGroupName $ResourceGroupName -name $storageAccount
            $container = New-AzStorageContainer -Name ($name.tolower()+'-container') -Context $storageAccountObj.Context -Permission Blob 
            
            # Upload your Cloud Service package (cspkg) to the storage account.
            $tokenStartTime = Get-Date 
            $tokenEndTime = $tokenStartTime.AddYears(1) 
            $cspkgBlob = Set-AzStorageBlobContent -File $PackageFile -Container $container.name -Blob ($name + ".cspkg") -Context $storageAccountObj.Context 
            $cspkgToken = New-AzStorageBlobSASToken -Container $container.name -Blob $cspkgBlob.Name -Permission rwd -StartTime $tokenStartTime -ExpiryTime $tokenEndTime -Context $storageAccountObj.Context 
            $cspkgUrl = $cspkgBlob.ICloudBlob.Uri.AbsoluteUri + $cspkgToken 
            
            $null = $PSBoundParameters.Remove("StorageAccount")
            $null = $PSBoundParameters.Remove("PackageFile")
            $null = $PSBoundParameters.Add("packageURL", $cspkgURL)
        }

        # network profile
        if ( $null -eq $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP ){
            # Create a public IP address and (optionally) set the DNS label property of the public IP address. If you are using a static IP, it needs to referenced as a Reserved IP in Service Configuration file.
            $publicIpName = $name + "Ip"
            if ($PSBoundParameters.ContainsKey("DnsName")) 
            {
                $publicIp = New-AzPublicIpAddress -Name $publicIPName -ResourceGroupName $ResourceGroupName -Location $Location -AllocationMethod Dynamic -IpAddressVersion IPv4 -DomainNameLabel $DnsName -Sku Basic
                $null = $PSBoundParameters.Remove("DnsName")
            }
            else {
                $publicIp = New-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $ResourceGroupName -Location $Location -AllocationMethod Dynamic -IpAddressVersion IPv4 -Sku Basic
            } 
        }
        else {
            $publicIpName = $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP.Name
        }
        
            # Create Network Profile Object and associate public IP address to the frontend of the platform created load balancer.
        $publicIP = Get-AzPublicIpAddress -ResourceGroupName $ResourceGroupName -Name $publicIpName  
        $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name ($name+'LbFe') -PublicIPAddressId $publicIP.Id 
        $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name ($name + 'LB') -FrontendIPConfiguration $feIpConfig 
        $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}
        
        If ( $null -ne $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.loadBalancer){
            $privateLB = $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.loadBalancer
            $feIpConfig2 = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name ($privateLB.name + 'Fe') -privateIPAddress $privateLB.FrontendIPConfiguration.staticVirtualNetworkIPAddress -subnetId $passMemory.theSubnet.Id
            $loadBalancerConfig2 = New-AzCloudServiceLoadBalancerConfigurationObject -Name $privateLB.name -FrontendIPConfiguration $feIpConfig2
            $networkProfile = @{loadBalancerConfiguration = @($loadBalancerConfig, $loadBalancerConfig2)}
        }

        $null = $PSBoundParameters.Add("NetworkProfile", $networkProfile)

    
        # OS Profile
        if ($PSBoundParameters.ContainsKey("KeyVaultName")) {
            $keyVault = Get-AzKeyVault -ResourceGroupName $resourcegroupname -VaultName $keyVaultName 

            $certSecretList = @()

            foreach ($role in $cscfg.ServiceConfiguration.Role){
                foreach ($cert in $role.Certificates.Certificate){
                    #if ( "Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" -ne $cert.Name){
                    $aCert = Get-AzKeyVaultCertificate -vaultName $keyvaultName -name $cert.name
                    $certSecretList = $certSecretList + $aCert.SecretId
                    #}
                }
            }

            $secretGroup = New-AzCloudServiceVaultSecretGroupObject -Id $keyVault.ResourceId -CertificateUrl $certSecretList 
            $osProfile = @{secret = @($secretGroup)}

            $null = $PSBoundParameters.Remove("keyvaultname")
            $null = $PSBoundParameters.Add("OSProfile", $osProfile)
        }

        # Role Profile 

        $cfg_role1 = $cscfg.ServiceConfiguration.Role[0]
        $def_role1 = $csdef.ServiceDefinition.($cfg_role1.name)
        $role1 = New-AzCloudServiceRoleProfilePropertiesObject -Name $def_role1.Name -SkuName $def_role1.vmsize -SkuTier 'Standard' -SkuCapacity $cfg_role1.Instances.count 
        
        if ( $cscfg.ServiceConfiguration.Role.count -eq 2 )   
        {
            $cfg_role2 = $cscfg.ServiceConfiguration.Role[1]
            $def_role2 = $csdef.ServiceDefinition.($cfg_role2.name)
            $role2 = New-AzCloudServiceRoleProfilePropertiesObject -Name $def_role2.Name -SkuName $def_role2.vmsize -SkuTier 'Standard' -SkuCapacity $cfg_role2.Instances.count 

            $roleProfile = @{role = @($role1, $role2)} 
        }
        else
        {
            $roleProfile = @{role = @($role1)} 
        }

        $null = $PSBoundParameters.Add("roleProfile", $RoleProfile)

        
        $null = $PSBoundParameters.Remove("DefinitionFile")
        $null = $PSBoundParameters.Remove("ConfigurationFile")
        $null = $PSBoundParameters.Add("Configuration", $Configuration)

        

        # Perform action

        # If these variants should call back to the original cmdlet, use splatting to pass the existing set of parameters
        Write-Host("Creating the Cloud Service resource.")
        Az.CloudService\New-AzCloudService @PSBoundParameters
    }

}

function validation
{
    param(
        [Parameter()]
        [object]
        ${cscfg},
        [Parameter()]
        [object]
        ${csdef},
        [Parameter()]
        [Hashtable]
        $params,
        [Parameter()]
        [Hashtable]
        [ref]$passMemory
    )

    Write-Host("Checking validations on the cscfg and csdef files.")
    # Network configuration missing in configuration
    If ( $null -eq $cscfg.ServiceConfiguration.NetworkConfiguration -or $cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.count -eq 0 -or $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.InstanceAddress.Subnets.count -eq 0)
    {
        Write-Error("The network configuration is missing from the configuration file. Please add the network configuration to the configuration file.")
        exit 1
    }

    # CS definition and configuration match
    If ($cscfg.ServiceConfiguration.Role[0].Name -ne $csdef.ServiceDefinition.($cscfg.ServiceConfiguration.Role[0].Name).name) 
    {
        Write-Error("The CSCFG did not match the CSDEF. More details: No role named '" + ($cscfg.ServiceConfiguration.Role[0].Name) + "' found in the service definition file. For more details please refer to : https://aka.ms/cses-cscfg-csdef")
        exit 1
    }
    If ($cscfg.ServiceConfiguration.Role.count -eq 2 -and $cscfg.ServiceConfiguration.Role[1].Name -ne $csdef.ServiceDefinition.($cscfg.ServiceConfiguration.Role[1].Name).name)
    {
        Write-Error("The CSCFG did not match the CSDEF. More details: No role named '" + ($cscfg.ServiceConfiguration.Role[1].Name) + "' found in the service definition file. For more details please refer to : https://aka.ms/cses-cscfg-csdef")
        exit 1
    }

    $certList = @()
    foreach ($role in $cscfg.ServiceConfiguration.Role){
        $defCerts = ($csdef.ServiceDefinition.childnodes | where-object {$_.name.tolower() -eq $role.name.tolower()}).Certificates.Certificate
        If ( 1 -eq $defCerts.count ){
            $defCerts = @($defCerts)
        }
        foreach ($cert in $role.Certificates.Certificate){
            if ( "Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" -ne $cert.Name){
                # CS definition and configuration match
                if ( -not $defCerts.name.tolower().Contains($cert.Name.tolower())){
                    Write-Error("The service definition file does not provide a certificate definition for certificate '" + $cert.name + "' for role '"+ $role.name +"'. For more details please refer to : https://aka.ms/cses-cscfg-csdef")
                    exit 1
                }
                $certList = $certList + $cert
            }
        }
    }

    # Existing Virtual Network Location Mismatch
    $vnets = Get-AzVirtualNetwork -name $cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.name
    If (0 -eq $vnets.count){
        Write-Error("Could not find the provided Virtual Network: '" + $cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.name +"'" )
        exit 1
    }

    $vnetFound = $false
    foreach ($vnet in $vnets) {
        if ($vnet.location.replace(" ","").tolower() -eq $Location.replace(" ","").tolower()){
            $vnetFound = $true
            $theVNet = $vnet
        }
    }
    if (-not $vnetFound){
        Write-Error("The location of the Cloud Service needs to match the location of the virtual network.")
        exit 1
    }

    If (1 -eq $theVNet.subnets.count){
        $vnetSubnets = @($theVnet.Subnets)
    }
    else {
        $vnetSubnets = $theVnet.subnets
    }

    # Existing Virtual Network Missing Subnets  
    foreach ($instaceAddress in $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.InstanceAddress) {
        if (-not ($vnetSubnets.name.tolower()).contains($instaceAddress.subnets.subnet.Name.tolower())){
            Write-Error("Subnet defined in the CSCFG file: '" + $instaceAddress.subnets.subnet.Name + "' could not be found in the Virtual Network: '" + $theVNet.name + "'. Please add the subnet to the virtual network.")
            exit 1
        }
    }

    # Internal load balancer private ip contained in subnet 
    If ( $null -ne $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.loadBalancer){
        $InternalLBFEConfig = $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.Loadbalancer.FrontendIPConfiguration 
        $theSubnet = $thevnet.Subnets | where-object {$_.Name.tolower() -eq $InternalLBFEConfig.subnet.tolower()}
        $addressPrefix = $theSubnet.AddressPrefix

        $maskNumber = $addressPrefix.split("/")[1]

        $subnetAddress = $addressPrefix.split("/")[0]
        $subnetBinary = -join ($subnetAddress -split '\.' | ForEach-Object {
            [System.Convert]::ToString($_,2).PadLeft(8,'0')
        })

        $LBIP = $InternalLBFEConfig.staticVirtualNetworkIPAddress
        $LBIPBinary = -join ($LBIP -split '\.' | ForEach-Object {
            [System.Convert]::ToString($_,2).PadLeft(8,'0')
        })

        If ($subnetBinary.substring(0,$maskNumber)  -ne $LBIPbinary.substring(0,$maskNumber)){
            Write-Error("The internal load balancer subnet '" + $InternalLBFEConfig.subnet + "' does not contain the private IP " + $LBIP + ". Update the subnet within the Virtual Network to include the Private IP.")
            exit 1
        }

        $passMemory.Add("theSubnet", $theSubnet)
    }
    
    if ( $null -ne $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP ){
        $IpName = $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP.Name
        $ipObjs = Get-AzPublicIpAddress -name $ipname 

        If (0 -eq $ipObjs.count){
            Write-Error("Public IP: '" + $Ipname + "' was not found. Please check your CSCFG file and provide an existing Public IP.")
            exit 1
        }
        
        # Existing Reserved (Static) IP Location Mismatch
        $ipFound = $false
        foreach ($ipObj in $IpObjs) {
            if ($ipObj.Location.replace(" ","").tolower() -eq $location.replace(" ","").tolower()){
                $ipFound = $true
                $theIPObj = $ipobj
            }
        }
        if (-not $ipFound){
            Write-Error("The location for the cloud service ("+ $location +") and public IP address ("+ $ipObjs[0].location +") are different. The location of the cloud service needs to match the location of the public IP address. Change the location of the cloud service to match the public IP address or change the resource group of the cloud service to try to resolve the issue.")
            exit 1
        }


        # Existing Reserved (Static) IP In Use
        if ($null -ne $theIPObj.IPConfiguration){
            Write-Error("The Public IP provided in the CSCFG: '" + $theIPObj.name + "' is currently in use by another resource.")
            exit 1 
        }

        # Existing Reserved (Static) IP Incorrect Sku
        if ("Basic" -ne $theIPObj.Sku.Name){
            Write-Error("The Public IP provided in the CSCFG: '" + $theIPObj.name + "' must have a 'Basic' SKU.")
            Exit 1
        }

        # Existing Reserved (Static) IP Incorrect Allocation
        if ("Static" -ne $theIPObj.PublicIPAllocationMethod){
            Write-Error("The Public IP provided in the CSCFG: '" + $theIPObj.name + "' uses a dynamic allocation and a static allocation is needed.")
            exit 1
        }

        # Existing Reserved (Static) IP Address Incorrect Version
        if ("IPv4" -ne $theIPObj.PublicIPAddressVersion){
            Write-Error("The Public IP provided in the CSCFG: '" + $theIPObj.name + "' uses IPv6 and an IPv4 public IP address is needed.")
            exit 1
        }
    }

    if ($params.ContainsKey("KeyVaultName")) {
        # Keyvault in same location 
        $keyVaultsWithName = Get-AzKeyVault -vaultName $keyvaultname 
        $keyvaultFound = $false
        foreach ($kv in $keyVaultsWithName) {
            if ($kv.location.replace(" ","").tolower() -eq $location.replace(" ","").tolower()) {
                $keyvaultFound = $true
                $theKV = Get-AzKeyVault -vaultName $keyvaultname -resourceGroupName $kv.resourcegroupname
            }
        }
        If (-not $keyvaultFound){
            Write-Error("No KeyVault named '" + $keyvaultname + "' was found in " + $Location)
            exit 1
        }

        # Keyvault has virtual machine deployment permission and user has list and get permissions
        If (-not $theKV.EnabledForDeployment){
            Write-Error("The Key vault is not enabled for deployment. The Key Vault must have 'Azure Virtual Machines for deployment' access enabled. Please run the following cmdlets to enable access: Set-AzKeyVaultAccessPolicy -VaultName " + $keyvaultname + " -ResourceGroupName " +$resourcegroupname +" -EnabledForDeployment")
            exit 1
        }

        $PolicyFound = $false
        foreach ($accessPolicy in $theKV.accessPolicies) {
            if ($accessPolicy.DisplayName -Match (get-azcontext).Account.id){
                if ($accessPolicy.PermissionsToCertificates -contains "Get" -and $accessPolicy.PermissionsToCertificates -contains "List"){
                    $PolicyFound = $true
                }
            }
        }

        If (-not $PolicyFound){
            Write-Error("The certificates must have 'Get' and 'List' permissions enabled on the Key Vault. Please run the following cmdlets to enable access: Set-AzKeyVaultAccessPolicy -VaultName " + $keyvaultname +" -ResourceGroupName " + $resourcegroupname + " -UserPrincipalName 'user@domain.com' -PermissionsToCertificates create,get,list,delete ")
            exit 1
        }

        # All certificates are found in the keyvault
        $certsInKV = Get-AzKeyVaultCertificate -VaultName $keyvaultname
        $certsThumbprints = @()
        foreach ($cert in $CertsInKV) {
            $certsThumbprints = $certsThumbprints + (Get-AzKeyVaultCertificate -VaultName $keyvaultname -name $cert.name).thumbprint
        }
        foreach ($cert in $certList){
            if (-not $certsThumbprints.Contains($cert.thumbprint)){
                Write-Error("The thumbprints specified in the CSCFG could not be found in the Key Vault. Add the missing certificates in '" + $keyvaultName + "'. Missing thumbprint: '" + $cert.name + " " + $cert.thumbprint +"'. To understand more about how to use KeyVault for certificates, please follow the documentation at https://aka.ms/cses-kv")
            }
        }
    }
}