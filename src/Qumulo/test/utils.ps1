function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
    #provided by service, ID:fc35d936-3b89-41f8-8110-a24b56826c37
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    
    $virtualNetworkName = 'eastus-ps-vnet'
    $env.Add('virtualNetworkName', $virtualNetworkName)

    $resourceGroup = 'ps-test'
    $env.Add('resourceGroup', $resourceGroup)

    $subnetName = 'qumulo-vnet'
    $env.Add('subnetName', $subnetName)

    # $subnetString = '/subscriptions/$env.SubscriptionId/resourceGroups/$env.resourceGroup/providers/Microsoft.Network/virtualNetworks/$env.virtualNetworkName/subnets/$env.subnetName'
    # $env.Add('subnetString', $subnetString)

    $qumulo1Name = 'qumulo-rs-01'
    $env.Add('qumulo1Name', $qumulo1Name)

    $qumulo2Name = 'qumulo-rs-02'
    $env.Add('qumulo2Name', $qumulo2Name)

    $region = 'eastus'
    $env.Add('region', $region)

    $secureString = '1qaz@WSX'
    $env.Add('secureString', $secureString)

    $testerEmail = 'v-jiaji@microsoft.com'
    $env.Add('testerEmail', $testerEmail)

    #Marketplace
    $planID = 'qumulo-on-azure-v1%%gmz7xq9ge3py%%P1M'
    $env.Add('planID', $planID)
    $offerID = 'qumulo-saas-mpp'
    $env.Add('offerID', $offerID)
    $publisherID = 'qumulo1584033880660'
    $env.Add('publisherID', $publisherID)
    #create test group
    #New-AzResourceGroup -Name $env.resourceGroup -Location $env.region

    #manually create VirtualNetwork env
    # New VirtualNetwork { Name $env.virtualNetworkName, ResourceGroup $env.resourceGroup, Location $env.region, AddressPrefix "10.23.0.0/16"}
    # Add VirtualNetwork SubnetConfig { Name $env.subnetName, AddressPrefix "10.23.1.0/24", Delegation Service Name "Qumulo.Storage/fileSystems"}
    
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}