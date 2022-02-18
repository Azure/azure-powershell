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
    $ServiceKey = "xxxxx-33333-xxxxx-33333"
    $VendorSubscription = "xxxxx-11111-xxxxx-11111"
    $PreviewSubscription = "xxxxx-00000-xxxxx-00000"
    $RoleName = "myRole"

    # Also input the values of these existing resources. Create these resources before running the tests.
    $existingDevice = "existingDevice"
    $existingResourceGroup = "existingResourceGroup"
    $existingVendor = "existingVendor"
    $existingVnf = "existingVnf"

    $env.Add("storage", $storage)
    $env.Add("ServiceKey", $ServiceKey)
    $env.Add("PreviewSubscription", $PreviewSubscription)
    $env.Add("VendorSubscription", $VendorSubscription)
    $env.Add("RoleName", $RoleName)
    $env.Add("Location", "eastus")

    $env.Add("existingDevice", $existingDevice)
    $env.Add("existingResourceGroup", $existingResourceGroup)
    $env.Add("existingVendor", $existingVendor)
    $env.Add("existingVnf", $existingVnf)

    $ResourceGroupName1 = "testgroup-network1"
    $ResourceGroupName2 = "testgroup-network2"
    $env.Add("ResourceGroupName1", $ResourceGroupName1)
    $env.Add("ResourceGroupName2", $ResourceGroupName2)

    New-AzResourceGroup -Name $env.ResourceGroupName1 -Location $env.Location
    New-AzResourceGroup -Name $env.ResourceGroupName2 -Location $env.Location

    $DeviceName1 = "testdevice1"
    $DeviceName2 = "testdevice2"
    $env.Add("DeviceName1", $DeviceName1)
    $env.Add("DeviceName2", $DeviceName2)

    $AzureStackEdgeId = "/subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/existingResourceGroup/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/existingAse"
    $env.Add("AzureStackEdgeId", $AzureStackEdgeId)
    
    $ase = New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId $env.AzureStackEdgeId

    $VendorName1 = "testvendor1"
    $VendorName2 = "testvendor2"
    $env.Add("VendorName1", $VendorName1)
    $env.Add("VendorName2", $VendorName2)

    $Vnf2 = "testvnf2"
    $Vnf3 = "testvnf3"
    $env.Add("Vnf2", $Vnf2)
    $env.Add("Vnf3", $Vnf3)

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
}

