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
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    # Please input this value, when you want run it
    $storage = ""
    $ServiceKey = ""
    $PreviewSubscription = ""

    $env.Add("storage", $storage)
    $env.Add("ServiceKey", $ServiceKey)
    $env.Add("PreviewSubscription", $PreviewSubscription)

    $env.Add("Location", "eastus")

    $ResourceGroupName1 = "testgroup-network1"
    $ResourceGroupName2 = "testgroup-network2"
    $ResourceGroupName3 = "testgroup-network3"
    $env.Add("ResourceGroupName1", $ResourceGroupName1)
    $env.Add("ResourceGroupName2", $ResourceGroupName2)
    $env.Add("ResourceGroupName3", $ResourceGroupName3)

    New-AzResourceGroup -Name $env.ResourceGroupName1 -Location $env.Location
    New-AzResourceGroup -Name $env.ResourceGroupName2 -Location $env.Location
    New-AzResourceGroup -Name $env.ResourceGroupName3 -Location $env.Location

    $DeviceName1 = "testdevice1"
    $DeviceName2 = "testdevice2"
    $DeviceName3 = "testdevice3"
    $env.Add("DeviceName1", $DeviceName1)
    $env.Add("DeviceName2", $DeviceName2)
    $env.Add("DeviceName3", $DeviceName3)

    $AzureStackEdgeId = "/subscriptions/${env.SubscriptionId}/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse"
    $env.Add("AzureStackEdgeId", $AzureStackEdgeId)
    
    $ase = New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId $env.AzureStackEdgeId
    New-AzConnectedNetworkDevice -Name $env.DeviceName3 -ResourceGroupName $env.ResourceGroupName3 -Location $env.Location -Property $ase

    $VendorName1 = "testvendor1"
    $VendorName2 = "testvendor2"
    $VendorName3 = "testvendor3"
    $env.Add("VendorName1", $VendorName1)
    $env.Add("VendorName2", $VendorName2)
    $env.Add("VendorName3", $VendorName3)

    New-AzConnectedNetworkVendor -Name $env.VendorName3

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName1
    Remove-AzResourceGroup -Name $env.ResourceGroupName2
    Remove-AzResourceGroup -Name $env.ResourceGroupName3
}

