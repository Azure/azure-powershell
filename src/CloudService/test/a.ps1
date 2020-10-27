$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

# TODO: Remove this once we have defined customized cmdlet
function New-AzCloudServiceRemoteDesktopExtensionObject {
  param(
    [Parameter(Mandatory=$true)]
    [string] $Name,
	
    [Parameter(Mandatory=$true)]
    [PSCredential] $Credential,
	
    [DateTime] $Expiration = (Get-Date),
	
    [string] $TypeHandlerVersion,
	
    [string[]] $RolesAppliedTo
  )

  $RDPPublisher = "Microsoft.Windows.Azure.Extensions"
  $RDPExtensionType = "RDP"
  
  $rdpSetting = "<PublicConfig><UserName>$Credential.UserName</UserName><Expiration>$Expiration</Expiration></PublicConfig>";
  $rdpProtectedSetting = "<PrivateConfig><Password>$Credential.Password</Password></PrivateConfig>";

  return New-AzCloudServiceExtensionObject -Name $Name -Publisher $RDPPublisher -Type $RDPExtensionType -TypeHandlerVersion $TypeHandlerVersion -Setting $rdpSetting -ProtectedSetting $rdpProtectedSetting -RolesAppliedTo $RolesAppliedTo
}

$subnetName = "WebTier"
$vnetName = "CSCmdletTestVnet"

$role1Name = "WebRole"
$role2Name = "WorkerRole"

$roleSkuName = "Standard_D1_v2"
$roleSkuTier = "Standard"
$roleSkuCapacity = 2

# Following values are optional to update
$prefix = "CSCmdletTest"
$uniqueKey = (New-Guid).ToString("N").Substring(0, 8)

# Storage Account variables
$storageName = $prefix.ToLower() + $uniqueKey + "sa"
$containerName = $prefix.ToLower() + "container"
$storageSku = "Standard_RAGRS"
$storageKind = "StorageV2"
$cspkgFilePath = (Resolve-Path $env.CspkgFile).Path
$cspkgName = Split-Path $cspkgFilePath -leaf
$tokenStartTime = Get-Date
$tokenEndTime = $tokenStartTime.AddYears(1)

# Vnet variables
$addressPrefix = "10.0.0.0/24"

# Public IP variables
$publicIpName = $prefix + "PublicIp"
$allocationMethod = "Dynamic"
$IpAddressVersion = "IPv4"
$publicIpSku = "Basic"
$dnsPrefix = $prefix.ToLower() + $uniqueKey + "dnsprefix"

# Cloud Service network profile variables
$frontEndName = $prefix + "LBFE"
$loadBalancerName = $prefix + "LB"

# Cloud Service variables
$upgradeMode = "Auto"
$rdpUserName = "AzureUser"
$rdpPassword = $uniqueKey
$rdpExpiration = (Get-Date).AddYears(1)

# Read Configuration File
Write-Host "Reading Configuration"  
$cscfgText = [IO.File]::ReadAllText((Resolve-Path $env.CscfgFile).Path)

# Create ResourceGroup
Write-Host "Creating ResourceGroup"
New-AzResourceGroup -ResourceGroupName $env.ResourceGroupName -Location $env.Location

# Create Storage Account and upload package
Write-Host "Uploading Package"
$storageAccount = New-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $storageName -Location $env.Location -SkuName $storageSku -Kind $storageKind
$container = New-AzStorageContainer -Name $containerName -Context $storageAccount.Context -Permission blob
$blob = Set-AzStorageBlobContent -File $cspkgFilePath -Container $containerName -Blob $cspkgName -Context $storageAccount.Context
$token = New-AzStorageBlobSASToken -Container $containerName -Blob $blob.Name -Permission rwd -StartTime $tokenStartTime -ExpiryTime $tokenEndTime -Context $storageAccount.Context
$cspkgUrl = $blob.ICloudBlob.Uri.AbsoluteUri + $token

# Create Virtual Network
Write-Host "Creating Virtual Network"
$subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $addressPrefix -WarningAction SilentlyContinue
$virtualNetwork = New-AzVirtualNetwork -Name $vnetName -Location $env.Location -ResourceGroupName $env.ResourceGroupName -AddressPrefix $addressPrefix -Subnet $subnet

# Create Public IP
Write-Host "Creating Public IP"
$publicIp = New-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -AllocationMethod $allocationMethod -IpAddressVersion $IpAddressVersion -DomainNameLabel $dnsPrefix -Sku $publicIpSku

# Create Role Profile
$role1 = New-AzCloudServiceRoleProfilePropertiesObject -Name $role1Name -SkuName $roleSkuName -SkuTier $roleSkuTier -SkuCapacity $roleSkuCapacity
$role2 = New-AzCloudServiceRoleProfilePropertiesObject -Name $role2Name -SkuName $roleSkuName -SkuTier $roleSkuTier -SkuCapacity $roleSkuCapacity
$roles = @($role1, $role2)

# TODO: Create OS Profile

# Create Network Profile
$feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name $frontEndName -PublicIPAddressId $publicIp.Id
$loadBalancerId = $publicIp.Id.Substring(0, $publicIp.Id.IndexOf("publicIPAddresses")) + "loadBalancers/" + $loadBalancerName
$networkProfile = New-AzCloudServiceLoadBalancerConfigurationObject -Name $loadBalancerName -Id $loadBalancerId -FrontendIPConfiguration $feIpConfig

# Create Extension Profile
$extensionName = "RDPExtension"
$publisher = "Microsoft.Windows.Azure.Extensions"
$type = "RDP"
$version = "1.2.1"
$autoUpgradeMinorVersion = $true
$rdpSetting=@{"PublicConfig" = @{"Expiration" = $rdpExpiration; "UserName" = $rdpUserName}}
$rdpProtectedSetting=@{"PrivateConfig" = @{"Password" = $rdpPassword}}
$extension = New-AzCloudServiceExtensionObject -Name $extensionName -Publisher $publisher -Type $type -TypeHandlerVersion $version -Setting $rdpSetting -ProtectedSetting $rdpProtectedSetting -AutoUpgradeMinorVersion $autoUpgradeMinorVersion


[SecureString]$securePassword = ConvertTo-SecureString $rdpPassword -AsPlainText -Force
[PSCredential]$credential = New-Object System.Management.Automation.PSCredential ($rdpUserName, $securePassword)
$extension = New-AzCloudServiceRemoteDesktopExtensionObject -Name $extensionName -Credential $credential -Expiration $rdpExpiration -TypeHandlerVersion $version

# Create Cloud Service
Write-Host "Creating Cloud Service"
$cloudService = New-AzCloudService                                            `
                  -Name $env.CloudServiceName                                 `
                  -ResourceGroupName $env.ResourceGroupName                   `
                  -Location $env.Location                                     `
                  -PackageUrl $cspkgUrl                                       `
                  -Configuration $cscfgText                                 `
                  -UpgradeMode $upgradeMode                                   `
                  -RoleProfileRole $roles                                     `
                  -NetworkProfileLoadBalancerConfiguration $networkProfile    `
                  -ExtensionProfileExtension $extension