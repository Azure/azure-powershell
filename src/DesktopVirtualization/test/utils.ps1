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
    $null = $env.Add("ResourceGroup", "jushiah-appattach")
    $null = $env.Add("Location", "West Central US")
    $null = $env.Add("HostPool", "jushiahappattach")
    $null = $env.Add("HostPoolArmPath", "/subscriptions/5c14a947-e099-4b3f-932e-6e836da92be6/resourcegroups/jushiah-appattach/providers/Microsoft.DesktopVirtualization/hostPools/jushiahappattach")
    $null = $env.Add("RemoteApplicationGroup", "jushiah-appattach-rag")
    $null = $env.Add("DesktopApplicationGroup", "jushiahappattach-DAG")
    $null = $env.Add("MSIXImagePath", "\\stgeorgi-0\temp\AdobeReaders\adobereader.vhdx")
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

