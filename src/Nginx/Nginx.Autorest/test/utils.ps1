function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % { [char]$_ })
    }
    else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % { [char]$_ })
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $testNumber = $(Get-Random -Minimum 0 -Maximum 1000)
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.resourceGroup = ('testing-rg' + $testNumber)
    $env.nginxDeployment1 = ('azpwshnginx' + $testNumber)
    $env.nginxCert = 'testcert'
    $env.nginxNewCert = 'testnewcert'
    $env.nginxConf = 'default'
    $env.nginxFilePath = 'nginx.conf'
    $env.nginxFileContent = 'aHR0cCB7DQogICAgdXBzdHJlYW0gYXBwIHsNCiAgICAgICAgc2VydmVyIDE3Mi4yNy4wLjQ6ODA7DQogICAgfQ0KICAgIHNlcnZlciB7DQogICAgICAgIGxpc3RlbiA4MDsNCiAgICAgICAgbG9jYXRpb24gLyB7DQogICAgICAgICAgICBkZWZhdWx0X3R5cGUgdGV4dC9odG1sOw0KICAgICAgICAgICAgcmV0dXJuIDIwMCAnPCFET0NUWVBFIGh0bWw+PGgxIHN0eWxlPSJmb250LXNpemU6MzBweDsiPkhlbGxvIGZyb20gTmdpbnggV2ViIFNlcnZlciE8L2gxPlxuJzsNCiAgICAgICAgfQ0KICAgICAgICBsb2NhdGlvbiAvYXBwLyB7DQogICAgICAgICAgICBwcm94eV9wYXNzIGh0dHA6Ly9hcHAuYmxvYi5jb3JlLndpbmRvd3MubmV0LzsNCiAgICAgICAgICAgIHByb3h5X2h0dHBfdmVyc2lvbiAxLjE7DQogICAgICAgICAgICBwcm94eV9yZWFkX3RpbWVvdXQgNjAwOw0KCSAgICAgICAgcHJveHlfY29ubmVjdF90aW1lb3V0IDYwMDsNCgkgICAgICAgIHByb3h5X3NlbmRfdGltZW91dCA2MDA7DQogICAgICAgIH0NCiAgICB9DQp9'
    $env.location = "eastus2"
    $env.pubip = ("testpubip" + $testNumber)
    $env.vnet = ("testvnet" + $testNumber)
    $env.subnet = "default"
    $env.userAssignedMI = ("testusermi" + $testNumber)
    $env.keyvault = ("tkv" + $testNumber)
    $env.delegation = "NGINX.NGINXPLUS/nginxDeployments"

    Write-Host "setting up env for AzNginx testing"
    
    # create resource group for testing
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # create user assigned managed identity
    $identity = New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userAssignedMI -Location $env.location

    # create key vault
    $keyvault = New-AzKeyVault -Name $env.keyvault -ResourceGroupName $env.resourceGroup -Location $env.location
    $Policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName "CN=nginxpwshtesting.com" -IssuerName "Self" -ValidityInMonths 6 -ReuseKeyOnRenewal
    $certKV = Add-AzKeyVaultCertificate -VaultName $env.keyvault -Name $env.nginxCert -CertificatePolicy $Policy

    # getting the keyvault certificate secretid
    $certVersion = "/" + (Get-AzKeyVaultcertificate -VaultName $env.keyvault -name $env.nginxCert).version 
    $kvcertsecretid = (Get-AzKeyVaultcertificate -VaultName $env.keyvault -name $env.nginxCert).secretid.Replace(":443", "").Replace($certVersion, "")
    $env.kvcertsecretid = $kvcertsecretid

    # create public ip
    $ip = @{
        Name              = $env.pubip
        ResourceGroupName = $env.resourceGroup
        Location          = $env.location
        Sku               = "Standard"
        AllocationMethod  = "Static"
        IpAddressVersion  = "IPv4"
        Zone              = 2
    }
    $publicIp = New-AzPublicIpAddress @ip -Force

    # create virtual network
    $vnet = @{
        Name              = $env.vnet
        ResourceGroupName = $env.resourceGroup
        Location          = $env.location
        AddressPrefix     = "10.0.0.0/16"
    }
    $virtualNetwork = New-AzVirtualNetwork @vnet -Force

    # create subnet
    $subnet = @{
        Name           = $env.subnet
        VirtualNetwork = $virtualNetwork
        AddressPrefix  = "10.0.0.0/24"
    }
    $subnetConfig = Add-AzVirtualNetworkSubnetConfig @subnet
    $virtualNetwork | Set-AzVirtualNetwork

    # delegate the subnet to NGINX.NGINXPLUS/nginxDeployments
    $vnet = Get-AzVirtualNetwork -Name $env.vnet -ResourceGroupName $env.resourceGroup
    $subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.subnet -VirtualNetwork $vnet
    $subnet = Add-AzDelegation -Name "delegation" -ServiceName $env.delegation -Subnet $subnet
    Set-AzVirtualNetwork -VirtualNetwork $vnet

    # create the nginxaas resource
    $publicIp = New-AzNginxPublicIPAddressObject -Id $publicIp.Id
    $networkProfile = New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress = @($publicIp) } -NetworkInterfaceConfiguration @{SubnetId = $subnet.Id }
    $nginxDeployment = New-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup -Location $env.location -NetworkProfile $networkProfile -SkuName standard_Monthly_gmz7xq9ge3py -IdentityType "SystemAssigned" 
    $nginxDeployment.ProvisioningState | Should -Be "Succeeded"
    $nginxDeployment.Name | Should -Be $env.nginxDeployment1

    # assigning role
    $keyVaultId = $keyVault.ResourceId
    $roleDefinition = Get-AzRoleDefinition -Name "Key Vault Administrator"
    $roleAssignment = New-AzRoleAssignment -ObjectId $nginxDeployment.IdentityPrincipalId  -RoleDefinitionId $roleDefinition.Id -Scope $keyVaultId
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    Write-Host "finished setting up env for AzNginx testing"
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host "cleaning up resources"
    Remove-AzResourceGroup -Name $env.resourceGroup
    Write-Host "cleaned up resources"
}
