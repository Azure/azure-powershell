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
    $null = $env.Add("ResourceGroup", "datr-canadaeast")
    $null = $env.Add("Location", "canadaeast")
    $null = $env.Add("HostPool", "datr-hp2")
    $null = $env.Add("HostPoolArmPath", "/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/datr-hp2")
    $null = $env.Add("RemoteApplicationGroup", "datr-hp2-RAG")
    $null = $env.Add("DesktopApplicationGroup", "datr-hp2-DAG")
    $null = $env.Add("MSIXImagePath", "C:\msix\singlemsix.vhd")
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

