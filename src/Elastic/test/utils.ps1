function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | ForEach-Object {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | ForEach-Object {[char]$_})
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
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.TenantId = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    $env.location = "eastus"
    $env.userEmail = (Get-AzContext).Account.Id
    $env.sku = "ess-monthly-consumption_Monthly"

    $env.monitorName01 = 'monitor' + (RandomString -allChars $false -len 6)
    $env.monitorName02 = 'monitor' + (RandomString -allChars $false -len 6)
    $env.monitorName03 = 'monitor' + (RandomString -allChars $false -len 6)
    $env.monitorName04 = 'monitor' + (RandomString -allChars $false -len 6)
    $env.monitorName05 = 'monitor' + (RandomString -allChars $false -len 6)

    $env.ipFilterName01 = 'ip-filter-' + (RandomString -allChars $false -len 6)
    $env.ipFilterName02 = 'ip-filter-' + (RandomString -allChars $false -len 6)
    $env.ipFilterName03 = 'ip-filter-' + (RandomString -allChars $false -len 6)

    $env.plFilterName01 = 'pl-filter-' + (RandomString -allChars $false -len 6)
    $env.plFilterName02 = 'pl-filter-' + (RandomString -allChars $false -len 6)
    $env.plFilterName03 = 'pl-filter-' + (RandomString -allChars $false -len 6)

    $env.peName = 'pe-' + (RandomString -allChars $false -len 6)

    $env.linuxVMName = 'vm-linux-' + (RandomString -allChars $false -len 6)

    # Create the test group
    Write-Host -ForegroundColor Green "Start to create resource group"
    $env.resourceGroup = 'elastic-rg-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Create two elastics for use in the test.
    Write-Host -ForegroundColor Green "Create two monitors for use in the test"
    New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
    New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail

    $feSnetName = 'fe-snet'
    $beSnetName = 'be-snet'
    $oSnetName = 'o-snet'
    $feSnet = New-AzVirtualNetworkSubnetConfig -Name $feSnetName -AddressPrefix "10.0.1.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $beSnet = New-AzVirtualNetworkSubnetConfig -Name $beSnetName -AddressPrefix "10.0.2.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $oSnet = New-AzVirtualNetworkSubnetConfig -Name $oSnetName -AddressPrefix "10.0.3.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled -PrivateLinkServiceNetworkPoliciesFlag Disabled
    $vnet = New-AzVirtualNetwork -ResourceGroupName $env.resourceGroup -Name 'vnet' -Location $env.location -AddressPrefix "10.0.0.0/16" -Subnet $feSnet, $beSnet, $oSnet
    $feSnet = $vnet.Subnets | Where-Object Name -eq $feSnetName
    $oSnet = $vnet.Subnets | Where-Object Name -eq $oSnetName
    $feIpCfg = New-AzLoadBalancerFrontendIpConfig -Name 'fe-ipcfg' -Subnet $feSnet -PrivateIpAddress "10.0.1.10"
    $bePoolCfg = New-AzLoadBalancerBackendAddressPoolConfig -Name 'be-poolcfg'
    $lb = New-AzLoadBalancer -ResourceGroupName $env.resourceGroup -Name 'lb' -Location $env.location -FrontendIpConfiguration $feIpCfg -BackendAddressPool $bePoolCfg -Sku Standard
    $plsIpCfg = New-AzPrivateLinkServiceIpConfig -Name 'pls-ipcfg' -PrivateIpAddress "10.0.3.10" -Subnet $oSnet
    $feIpCfg = $lb | Get-AzLoadBalancerFrontendIpConfig
    $pls = New-AzPrivateLinkService -ResourceGroupName $env.resourceGroup -Name 'pls' -Location $env.location -IpConfiguration $plsIpCfg -LoadBalancerFrontendIpConfiguration $feIpCfg
    $plsConn = New-AzPrivateLinkServiceConnection -Name 'pls-conn' -PrivateLinkServiceId $pls.Id
    New-AzPrivateEndpoint -ResourceGroupName $env.resourceGroup -Name $env.peName -Location $env.location -Subnet $feSnet -PrivateLinkServiceConnection $plsConn

    $linuxVM = New-AzVM -ResourceGroupName $env.resourceGroup -Name $env.linuxVMName -Location $env.location -Image Ubuntu2204 -Size Standard_DS1_v2 -Credential (New-Object System.Management.Automation.PSCredential "LinuxAdmin", (ConvertTo-SecureString -String "Password123!" -AsPlainText -Force))
    $env.VMResourceId = $linuxVM.Id

    # Create
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}
