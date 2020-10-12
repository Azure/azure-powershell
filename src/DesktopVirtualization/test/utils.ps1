function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function setupEnv() {
    $env = @{}
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    $null = $env.Add("ResourceGroup", "shhirji-ps-unittest")
    $null = $env.Add("Location", "ukwest")
    $null = $env.Add("HostPool", "shhirji-hp-ps-unittest")
    $null = $env.Add("HostPoolArmPath", "/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/shhirji-ps-unittest/providers/Microsoft.DesktopVirtualization/hostPools/shhirji-hp-ps-unittest")
    $null = $env.Add("RemoteApplicationGroup", "shhirji-ps-unittest-RAG")
    $null = $env.Add("DesktopApplicationGroup", "shhirji-hp-ps-unittest-DAG")
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

