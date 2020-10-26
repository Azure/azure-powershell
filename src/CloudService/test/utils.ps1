function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function RemoveFile([string]$fileName) {
    if (Test-Path $fileName) {
      Remove-Item $fileName
    }
}

function CreateCloudService([string]$publicIpName, [string]$cloudServiceName) {
    import-module az.storage
    # Create Public IP
	Write-Host -ForegroundColor Yellow "Creating Public IP" $publicIpName
    $publicIp = New-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -AllocationMethod "Dynamic" -IpAddressVersion "IPv4" -DomainNameLabel ("cscmdlettest" + (RandomString $false 8)) -Sku "Basic"
    
    # Create Network Profile
    $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name "cscmdlettestLBFE" -PublicIPAddressId $publicIp.Id
    $networkProfile = New-AzCloudServiceLoadBalancerConfigurationObject -Name "cscmdlettestLB" -FrontendIPConfiguration $feIpConfig

    # Create Role Profile
    $role1 = New-AzCloudServiceCloudServiceRoleProfilePropertiesObject -Name "WebRole" -SkuName "Standard_D1_v2" -SkuTier "Standard" -SkuCapacity 2
    $role2 = New-AzCloudServiceCloudServiceRoleProfilePropertiesObject -Name "WorkerRole" -SkuName "Standard_D1_v2" -SkuTier "Standard" -SkuCapacity 2
    $roles = @($role1, $role2)

    # Create RDP Extension Profile
    [SecureString]$securePassword = ConvertTo-SecureString (RandomString $false 8) -AsPlainText -Force
    [PSCredential]$credential = New-Object System.Management.Automation.PSCredential ("userazure", $securePassword)
	$rdpExpiration = (Get-Date).AddYears(1)
	$extension = New-AzCloudServiceRemoteDesktopExtensionObject -Name "RDPExtension" -Credential $credential -Expiration $rdpExpiration -TypeHandlerVersion "1.2.1"

    # Read Configuration File
	$cscfgFilePath = Join-Path $PSScriptRoot $env.CscfgFile
    $cscfgText = [IO.File]::ReadAllText($cscfgFilePath)

    # Create Cloud Service
	Write-Host -ForegroundColor Yellow "Creating Cloud Service" $cloudServiceName
    $cloudService = New-AzCloudService                                            `
                      -Name $CloudServiceName                                     `
                      -ResourceGroupName $env.ResourceGroupName                   `
                      -Location $env.Location                                     `
                      -PackageUrl $env.CspkgUrl                                   `
                      -Configuration $cscfgText                                   `
                      -UpgradeMode "Auto"                                         `
                      -RoleProfileRole $roles                                     `
                      -NetworkProfileLoadBalancerConfiguration $networkProfile    `
                      -ExtensionProfileExtension $extension
}

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
	
    $env.ResourceGroupName = "cscmdlettest" + (RandomString $false 8)
    $env.Location = "EastUS2EUAP"
    $env.CloudServiceName = "cscmdlettest" +  (RandomString $false 8)
	
    $env.CscfgFile = "test-artifacts\CSCmdletTest.cscfg"
	$env.CspkgFile = "test-artifacts\CSCmdletTest.cspkg"
	$env.RoleInstanceName = "WebRole_IN_0"
	
	$env.RDPOutputFile = Join-Path $PSScriptRoot ((RandomString $false 8) + ".rdp")
	
    $cspkgFilePath = Join-Path $PSScriptRoot $env.CspkgFile
	
    # Create ResourceGroup
	Write-Host -ForegroundColor Yellow "Creating ResourceGroup" $env.ResourceGroupName
    New-AzResourceGroup -ResourceGroupName $env.ResourceGroupName -Location $env.Location

    # Create Storage Account and upload package
	$storageName = "cscmdlettest" + (RandomString $false 8)
	$containerName = "cscmdlettestcontainer"
	Write-Host -ForegroundColor Yellow "Creating Storage Account" $storageName
    $storageAccount = New-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $storageName -Location $env.Location -SkuName "Standard_RAGRS" -Kind "StorageV2"
    $container = New-AzStorageContainer -Name $containerName -Context $storageAccount.Context -Permission blob
    $blob = Set-AzStorageBlobContent -File $cspkgFilePath -Container $containerName -Blob "CSCmdletTest.cspkg" -Context $storageAccount.Context
    $tokenStartTime = Get-Date
    $tokenEndTime = $tokenStartTime.AddYears(1)
    $token = New-AzStorageBlobSASToken -Container $containerName -Blob $blob.Name -Permission rwd -StartTime $tokenStartTime -ExpiryTime $tokenEndTime -Context $storageAccount.Context
    $env.CspkgUrl = $blob.ICloudBlob.Uri.AbsoluteUri + $token

    # Create Virtual Network
	Write-Host -ForegroundColor Yellow "Creating Virtual Network CSCmdletTestVnet"
    $subnet = New-AzVirtualNetworkSubnetConfig -Name "WebTier" -AddressPrefix "10.0.0.0/24" -WarningAction SilentlyContinue
    $virtualNetwork = New-AzVirtualNetwork -Name "CSCmdletTestVnet" -Location $env.Location -ResourceGroupName $env.ResourceGroupName -AddressPrefix "10.0.0.0/24" -Subnet $subnet

	$publicIpName = "cscmdlettestnewcsip"
	Write-Host -ForegroundColor Yellow "Creating Public IP" $publicIpName
    $publicIp = New-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -AllocationMethod "Dynamic" -IpAddressVersion "IPv4" -DomainNameLabel ("cscmdlettest" + (RandomString $false 8)) -Sku "Basic"
    $env.NewCSPublicIPId = $publicIp.Id

	CreateCloudService "cscmdlettestip" $env.CloudServiceName

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean resources you create for testing
	#Write-Host -ForegroundColor Yellow "Removing ResourceGroup" $env.ResourceGroupName
	#Remove-AzResourceGroup -ResourceGroupName $env.ResourceGroupName
	RemoveFile $env.RDPOutputFile
}

