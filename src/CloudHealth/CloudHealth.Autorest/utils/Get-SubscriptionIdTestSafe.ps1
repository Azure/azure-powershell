param()
if ($env:AzPSAutorestTestPlaybackMode) {
    $loadEnvPath = Join-Path $PSScriptRoot '..' 'test' 'loadEnv.ps1'
    . ($loadEnvPath)
    return $env.SubscriptionId
}
return (Get-AzContext).Subscription.Id