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
    # The context in which the tests are run will change the tenant and subscription ID when -record is run. 
    # Currently the scaling tests need to be run in a context with @microsoft, while the other tests are run with a test account
    # Modify the env.json manually after recording the necessary tests to get around this issue.
    $null = $env.Add("Scaling_Location", "eastus2")
    $null = $env.Add("Scaling_SubscriptionId", "9b5711b9-2151-4555-91bf-e0b7f803682f")
    $null = $env.Add("Scaling_ResourceGroup", "dallintest")
    $null = $env.Add("Scaling_HostPoolArmPath", "/subscriptions/9b5711b9-2151-4555-91bf-e0b7f803682f/resourceGroups/dallintest/providers/Microsoft.DesktopVirtualization/hostpools/dallintest-hp")
    $null = $env.Add("Scaling_HostPoolArmPath2", "/subscriptions/9b5711b9-2151-4555-91bf-e0b7f803682f/resourceGroups/dallintest/providers/Microsoft.DesktopVirtualization/hostpools/dallintest-hp-2")
    $null = $env.Add("Scaling_RemoteApplicationGroup", "dallintest-hp-DAG")
    $null = $env.Add("Scaling_HostPool", "damagleb-hp")
    $null = $env.Add("Scaling_HostPool2", "damagleb-hp-2")
    $null = $env.Add("Scaling_Tenant", "72f988bf-86f1-41af-91ab-2d7cd011db47")
    $null = $env.Add("Scaling_MSIXImagePath", "C:\\msix\\singlemsix.vhd")
    $null = $env.Add("Scaling_DesktopApplicationGroup", "damagleb-hp-DAG")
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}
