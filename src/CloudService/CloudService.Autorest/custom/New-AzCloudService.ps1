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
#>

function New-AzCloudService {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudService')]
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
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudServiceExtensionProfile]
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
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudServiceTags]))]
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

        try {
            $getCS = Get-azcloudservice -resourcegroupname $ResourceGroupName -name $name -ErrorAction Stop
        }
        catch {
            # CloudService does not exist in that name/resource group
        }
        finally {
            if ($null -ne $getCS){
                throw "A Cloud Service resource with name: '" +$name + "' already exists in Resource Group: '" + $ResourceGroupName + "'. Please try another name."
            }
        }

        if (-not (Test-Path $ConfigurationFile))  
        {
            throw "Cannot find file: " + $ConfigurationFile 
        }
        if (-not (Test-Path $DefinitionFile))
        {
            throw "Cannot find file: " + $DefinitionFile
        }
        if ($PSBoundParameters.ContainsKey("PackageFile")){
            if (-not (Test-Path $PackageFile))
            {
                throw "Cannot find file: " + $PackageFile
            }
            $extn = [IO.Path]::GetExtension($PackageFile)
            if ($extn -ne ".cspkg" )
            {
                throw "The Definition File must have the file extension '.cspkg'"
            }
        }

        [xml]$csdef = Get-Content -Path $DefinitionFile
        [xml]$cscfg = Get-Content -Path $ConfigurationFile
        $Configuration = Get-Content -Path $ConfigurationFile | Out-String

        # do validation 
        $passMemory = @{}
        validation $cscfg $csdef $PSBoundParameters ([ref]$passMemory)

        # create resources
        If ($passMemory.ipFound -eq $false){
            Write-Host("Creating ReservedIP")
            $null = New-AzPublicIpAddress -ResourceGroupName $ResourceGroupName -Name $passMemory.ipName -location $location -Sku Basic -AllocationMethod Static -WarningAction SilentlyContinue 
        }
        If ($passMemory.vNetFound -eq $False){
            # create subnets first 
            $subnetsList = @()
            $subnetCount = 0
            If ($True -eq $passMemory.CreateInternalLoadBalancer){
                $aSubnet = New-AzVirtualNetworkSubnetConfig -Name $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.Loadbalancer.FrontendIPConfiguration.subnet -AddressPrefix "10.0.0.0/24" -WarningAction SilentlyContinue 
                $subnetsList = $subnetsList + @($aSubnet)
                $subnetCount = $subnetCount + 1
                $passMemory.Add("theSubnet", $aSubnet)
            }

            foreach ($instaceAddress in $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.InstanceAddress) {
                if ( ($subnetsList.count -eq 0) -or (-not ($subnetsList.name.tolower()).contains($instaceAddress.subnets.subnet.Name.tolower())) ){
                    $addressPrefix = "10.0." + $subnetCount + ".0/24"
                    $aSubnet = New-AzVirtualNetworkSubnetConfig -Name $instaceAddress.subnets.subnet.Name -AddressPrefix $addressPrefix -WarningAction SilentlyContinue 
                    $subnetsList = $subnetsList + @($aSubnet)
                    $subnetCount = $subnetCount + 1
                }
            }

            # vnet
            Write-Host("Creating Virtual Network")
            $null = New-AzVirtualNetwork -name $passMemory.vnetName -resourcegroupname $resourcegroupname -location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnetsList 
        }

        # if -storageaccount is given, upload to packageUrl to blob 
        if ($PSBoundParameters.ContainsKey("StorageAccount")) 
        {
            Write-Host("Uploading the csdef to a blob in the Storage Account.")
            $storageAccountObjs = Get-AzStorageAccount
            foreach ($storageAccountObj in $storageAccountObjs) {
                if ($storageAccountObj.StorageAccountName.tolower() -eq $storageAccount.tolower()){
                    break
                }
            }
            $containerName = "cloudservicecontainer"
            # check if container exists
            try {
                $container = get-azstorageContainer -context $storageAccountObj.context -name $containerName -ErrorAction Stop
            }
            catch {
                # does not exist
                $container = New-AzStorageContainer -Name $containerName -Context $storageAccountObj.Context -Permission Blob
            }
            
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
                $publicIp = New-AzPublicIpAddress -Name $publicIPName -ResourceGroupName $ResourceGroupName -Location $Location -AllocationMethod Dynamic -IpAddressVersion IPv4 -DomainNameLabel $DnsName -Sku Basic -WarningAction SilentlyContinue 
                $null = $PSBoundParameters.Remove("DnsName")
            }
            else {
                $publicIp = New-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $ResourceGroupName -Location $Location -AllocationMethod Dynamic -IpAddressVersion IPv4 -Sku Basic -WarningAction SilentlyContinue 
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
            $keyVault = $passMemory.KeyVault 
            $certSecretList = $passMemory.certSecretList

            $secretGroup = New-AzCloudServiceVaultSecretGroupObject -Id $keyVault.ResourceId -CertificateUrl $certSecretList 
            $osProfile = @{secret = @($secretGroup)}

            $null = $PSBoundParameters.Remove("keyvaultname")
            $null = $PSBoundParameters.Add("OSProfile", $osProfile)
        }

        # Role Profile 
        $roleProfileList = @()

        foreach ($role in $cscfg.ServiceConfiguration.Role) {
            # find in csdef
            $RoleFoundinCsDef = $false
            foreach ($webRole in $csdef.ServiceDefinition.WebRole) {
                if ($role.name -eq $webRole.name){
                    $RoleFoundinCsDef = $true
                    $defRole = $webRole
                    break
                }
            }
            if (-not $RoleFoundinCsDef){
                foreach ($workerRole in $csdef.ServiceDefinition.WorkerRole) {
                    if($role.name -eq $workerRole.name){
                        $RoleFoundinCsDef = $true
                        $defRole = $workerRole
                        break
                    }
                }
            }

            $newRole = New-AzCloudServiceRoleProfilePropertiesObject -Name $defRole.Name -SkuName $defRole.vmsize -SkuTier 'Standard' -SkuCapacity $role.Instances.count 
            $roleProfileList = $roleProfileList + @($newRole)
        }

        $roleProfile = @{role = $roleProfileList} 
        $null = $PSBoundParameters.Add("roleProfile", $RoleProfile)

        
        $null = $PSBoundParameters.Remove("DefinitionFile")
        $null = $PSBoundParameters.Remove("ConfigurationFile")
        $null = $PSBoundParameters.Add("Configuration", $Configuration)

        

        # Perform action
        Write-Host("Creating the Cloud Service resource.")
        Az.CloudService\New-AzCloudService @PSBoundParameters
    }

}

function validation
{
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotExportAttribute()]
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

    Write-Host("Checking validations on the .cscfg and .csdef files.")

    # Network configuration missing in configuration
    If ( ($null -eq $cscfg.ServiceConfiguration.NetworkConfiguration) -or (($cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite | Measure-Object | Select-Object -expandproperty count) -eq 0) -or (($cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.InstanceAddress.Subnets | Measure-Object | Select-Object -ExpandProperty count) -eq 0) )
    {
        throw "The network configuration is missing from the configuration file. Please add the network configuration to the configuration file."
    }

    # CS definition and configuration match
    if (($cscfg.ServiceConfiguration.Role | Measure-Object | Select-Object -ExpandProperty count) -eq 1){
        $csCfgRoleNames = @($cscfg.ServiceConfiguration.Role.name.tolower())
    }elseif(($cscfg.ServiceConfiguration.Role | Measure-Object | Select-Object -ExpandProperty count) -gt 1){
        $csCfgRoleNames = $cscfg.ServiceConfiguration.Role.name.tolower()
    }

    $csDefRoleNames = @()
    if (($csdef.ServiceDefinition.WebRole | Measure-Object | select-object -expandproperty count) -eq 1){
        $csDefRoleNames = @($csdef.ServiceDefinition.WebRole.name.tolower())
    }elseif (($csdef.ServiceDefinition.WebRole | Measure-Object | select-object -expandproperty count) -gt 1) {
        $csDefRoleNames = $csdef.ServiceDefinition.WebRole.name.tolower()
    }
    if (($csdef.ServiceDefinition.WorkerRole | Measure-Object | select-object -expandproperty count) -eq 1){
        $csDefRoleNames = $csDefRoleNames + @($csdef.ServiceDefinition.WorkerRole.name.tolower())
    }elseif (($csdef.ServiceDefinition.WorkerRole | Measure-Object | select-object -expandproperty count) -gt 1) {
        $csDefRoleNames = $csDefRoleNames + $csdef.ServiceDefinition.WorkerRole.name.tolower()
    }

    foreach ($aRoleName in $csCfgRoleNames){
        if (-not $csDefRoleNames.contains($aRoleName)){
            throw "The CSCFG did not match the CSDEF. More details: No role named '" + $aRoleName + "' found in the service definition file. For more details please refer to : https://aka.ms/cses-cscfg-csdef"
        }
    }
    foreach ($aRoleName in $csDefRoleNames){
        if (-not $csCfgRoleNames.contains($aRoleName)){
            throw "The CSCFG did not match the CSDEF. More details: No role named '" + $aRoleName + "' found in the service configuration file. For more details please refer to : https://aka.ms/cses-cscfg-csdef"
        }
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
                    throw "The service definition file does not provide a certificate definition for certificate '" + $cert.name + "' for role '"+ $role.name +"'. For more details please refer to : https://aka.ms/cses-cscfg-csdef"
                }
                if ($certList.Count -eq 0 -or -not $certList.thumbprint.Contains($cert.thumbprint))
                {
                    $certList = $certList + $cert
                }
            }
        }
    }

    # Existing Virtual Network Location Mismatch
    # check if vnet exists
    $vnetNameSplitCount = ($cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.name).split().count
    if (3 -eq $vnetNameSplitCount){
        
        $vnetNameFormat = ($cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.name).split()
        if ("group" -ne $vnetNameFormat[0].tolower()){
            throw "VirtualNetworkSite name should be formated either ""{Name}"" or ""Group {ResourceGroupName} {Name}""."
        }
        
        $passMemory.Add("vnetName", $vnetNameFormat[2])

        # look for the vnet
        try {
            $thevnet = Get-AzVirtualNetwork -ResourceGroupName $vnetNameFormat[1] -Name $vnetNameFormat[2] -ErrorAction Stop
            if ($thevnet.location.replace(" ","").tolower() -eq $Location.replace(" ","").tolower()){
                $vnetFound = $true
            }else {
                $vnetLocationMatch = $false
            }
        }
        catch {
            $vnetFound = $false
        }

    } elseif (1 -eq $vnetNameSplitCount) {
        $passMemory.Add("vnetName", $cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.name)
        try {
            $thevnet = Get-AzVirtualNetwork -name $cscfg.ServiceConfiguration.NetworkConfiguration.VirtualNetworkSite.name -ResourceGroupName $ResourceGroupName -ErrorAction Stop
            if ($thevnet.location.replace(" ","").tolower() -eq $Location.replace(" ","").tolower()){
                $vnetFound = $true
            }
            else {
                $vnetLocationMatch = $false
            }
        }
        catch {
            $vnetFound = $false
        }
    }else {
        throw "VirtualNetworkSite name should be formated either ""{Name}"" or ""Group {ResourceGroupName} {Name}""."
    }

    If($false -eq $vnetLocationMatch){
        throw "The location for the cloud service (" + $location + ") and virtual network ("+ $thevnet.location +") are different. The location of the cloud service needs to match the location of the virtual network. Change the location of the cloud service to match the virtual network or change the resource group of the cloud service to try to resolve this issue."
    }

    $passMemory.Add("vnetFound", $vnetFound)

    If ($vnetFound){
        If (1 -eq $theVNet.subnets.count){
            $vnetSubnets = @($theVnet.Subnets)
        }
        else {
            $vnetSubnets = $theVnet.subnets
        }
    
        # Existing Virtual Network Missing Subnets  
        foreach ($instaceAddress in $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.InstanceAddress) {
            if (-not ($vnetSubnets.name.tolower()).contains($instaceAddress.subnets.subnet.Name.tolower())){
                throw "Subnet defined in the CSCFG file: '" + $instaceAddress.subnets.subnet.Name + "' could not be found in the Virtual Network: '" + $theVNet.name + "'. Please add the subnet to the virtual network."
            }
        }
    }


    # Internal load balancer private ip contained in subnet 
    If ( $null -ne $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.loadBalancer){
        $InternalLBFEConfig = $cscfg.ServiceConfiguration.NetworkConfiguration.loadBalancers.Loadbalancer.FrontendIPConfiguration 
        If ($vnetFound){
            $theSubnet = $thevnet.Subnets | where-object {$_.Name.tolower() -eq $InternalLBFEConfig.subnet.tolower()}
            If ($null -eq $theSubnet){
                throw "Subnet defined in the CSCFG file: '" + $InternalLBFEConfig.subnet + "' could not be found in the Virtual Network: '" + $theVNet.name + "'. Please add the subnet to the virtual network."
            }
            $passMemory.Add("theSubnet", $theSubnet)
            $addressPrefix = $theSubnet.AddressPrefix
        }
        else{
            $passMemory.Add("CreateInternalLoadBalancer", $true)
            $addressPrefix = "10.0.0.0/24" 
        }

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
            If ($vnetFound){
                throw "The internal load balancer subnet '" + $InternalLBFEConfig.subnet + "' does not contain the private IP " + $LBIP + ". Update the subnet within the Virtual Network to include the Private IP."
            }else{
                throw "The default internal load balancer subnet which will be created: '"+ $addressPrefix +"' does not contain the private IP " + $LBIP + ". Either update private IP or provided an already created virtual network and subnet."
            }
        }
    }
    
    if ( $null -ne $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP ){
        
        $IpNameSplitCount = ($cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP.Name).split().count
        if (3 -eq $IpNameSplitCount){
            
            $IpNameFormat = ($cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP.Name).split()
            if ("group" -ne $IpNameFormat[0].tolower()){
                throw "ReservedIP name should be formated either ""{Name}"" or ""Group {ResourceGroupName} {Name}""."
            }
            $passMemory.Add("ipName", $IpNameFormat[2])

            # look for the Ip
            try {
                $theIpObj = Get-AzPublicIpAddress -ResourceGroupName $IpNameFormat[1] -Name $IpNameFormat[2] -ErrorAction Stop
                if ($theIpObj.location.replace(" ","").tolower() -eq $Location.replace(" ","").tolower()){
                    $ipFound = $true
                }else {
                    $ipLocationMatch = $false
                }
            }
            catch {
                $ipFound = $false
            }

        }elseif (1 -eq $IpNameSplitCount) {
            $passMemory.Add("ipName", $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP.Name)
            try {
                $theIpObj = Get-AzPublicIpAddress -name $cscfg.ServiceConfiguration.NetworkConfiguration.AddressAssignments.ReservedIPs.ReservedIP.Name -ResourceGroupName $ResourceGroupName -ErrorAction Stop
                # Existing Reserved (Static) IP Location Mismatch
                if ($theIpObj.Location.replace(" ","").tolower() -eq $location.replace(" ","").tolower()) {
                    $ipFound = $true
                } else {
                    $ipLocationMatch = $false
                }
            }
            catch {
                $ipFound = $false
            }
        } else {
            throw "ReservedIP name should be formated either ""{Name}"" or ""Group {ResourceGroupName} {Name}""."
        }

        If ($false -eq $IpLocationMatch){
            throw "The location for the Cloud Service (" + $location + ") and the Public IP Address (" + $theIPObj.location + ") are different. The location of the Cloud Service needs to match the location of the Public IP Address. Change the location of the Cloud Service to match the Public IP Address or change the resource group of the Cloud Service to try to resolve the issue."
        }
        
        $passMemory.Add("ipFound", $ipFound)

        If ($ipFound){
            
            # Existing Reserved (Static) IP In Use
            if ($null -ne $theIPObj.IPConfiguration){
                throw "The Public IP provided in the CSCFG: '" + $theIPObj.name + "' is currently in use by another resource."
            }

            # Existing Reserved (Static) IP Incorrect Sku
            if ("Basic" -ne $theIPObj.Sku.Name){
                throw "The Public IP provided in the CSCFG: '" + $theIPObj.name + "' must have a 'Basic' SKU."
            }

            # Existing Reserved (Static) IP Address Incorrect Version
            if ("IPv4" -ne $theIPObj.PublicIPAddressVersion){
                throw "The Public IP provided in the CSCFG: '" + $theIPObj.name + "' uses IPv6 and an IPv4 public IP address is needed."
            }

            # Existing Reserved (Static) IP Incorrect Allocation
            if ("Static" -ne $theIPObj.PublicIPAllocationMethod){
                throw "The Public IP provided in the CSCFG: '" + $theIPObj.name + "' uses a dynamic allocation and a static allocation is needed."
            }
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
                $passMemory.Add("KeyVault", $theKV)
            }
        }
        If (-not $keyvaultFound){
            throw "No KeyVault named '" + $keyvaultname + "' was found in " + $Location
        }

        # Keyvault has virtual machine deployment permission and user has list and get permissions
        If (-not $theKV.EnabledForDeployment){
            throw "The Key vault is not enabled for deployment. The Key Vault must have 'Azure Virtual Machines for deployment' access enabled. Please run the following cmdlets to enable access: Set-AzKeyVaultAccessPolicy -VaultName " + $keyvaultname + " -ResourceGroupName " +$resourcegroupname +" -EnabledForDeployment"
        }

        try {
            $certsInKV = Get-AzKeyVaultCertificate -VaultName $keyvaultname -ErrorAction Stop
        }
        catch [Microsoft.Azure.KeyVault.Models.KeyVaultErrorException]{
            $KVnoPolicy = $true
        }
        finally {
            If ($KVnoPolicy){
              throw "The certificates must have 'Get' and 'List' permissions enabled on the Key Vault. Please run the following cmdlets to enable access: Set-AzKeyVaultAccessPolicy -VaultName " + $keyvaultname +" -ResourceGroupName " + $theKV.resourcegroupname + " -UserPrincipalName 'user@domain.com' -PermissionsToCertificates create,get,list,delete "  
            }
        }

        # All certificates are found in the keyvault
        $certsObjsFromKeyvault = @()
        $certSecretList = @()
        foreach ($cert in $CertsInKV) {
            $certsObjsFromKeyvault = $certsObjsFromKeyvault + (Get-AzKeyVaultCertificate -VaultName $keyvaultname -name $cert.name)
        }
        foreach ($certFromFiles in $certList){
            $thumbprintFound = $false
            foreach ($certFromKV in $certsObjsFromKeyvault){
                if ($certFromFiles.thumbprint -eq $certFromKV.thumbprint){
                    $thumbprintFound = $true
                    $certSecretList = $certSecretList + $certFromKV.SecretId
                }
            }
            if (-not $thumbprintFound){
                throw "The thumbprints specified in the CSCFG could not be found in the Key Vault. Add the missing certificates in Key Vault: '" + $keyvaultName + "'. Missing thumbprint: '" + $certFromFiles.name + " " + $certFromFiles.thumbprint +"'. To understand more about how to use KeyVault for certificates, please follow the documentation at https://aka.ms/cses-kv"
            }
        }
        $passMemory.Add("certSecretList", $certSecretList)
    }

    if ($params.ContainsKey("StorageAccount")) {
        $storAccs = Get-AzStorageAccount
        if (-not ($storAccs.StorageAccountName.tolower()).contains($storageAccount.tolower())){
            throw "The provided Storage Account: '" + $storageAccount + "' does not exist."
        }
    }
}
