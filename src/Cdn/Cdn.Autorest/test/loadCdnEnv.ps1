. (Join-Path $PSScriptRoot 'loadEnv.ps1')

$classicResourceGroupName = $env.ResourceGroupName
if ($env.ClassicCdnProfileResourceId) {
    if ($env.ClassicCdnProfileResourceId -notmatch '^/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/Microsoft\.Cdn/profiles/([^/]+)$') {
        throw 'ClassicCdnProfileResourceId must identify an existing Microsoft.Cdn/profiles resource.'
    }
    if ($Matches[1] -ne $env.SubscriptionId) {
        throw 'ClassicCdnProfileResourceId must belong to the configured test subscription.'
    }
    $classicResourceGroupName = $Matches[2]
    $env.ClassicCdnProfileName = $Matches[3]
}
$env | Add-Member -NotePropertyName ClassicCdnResourceGroupName -NotePropertyValue $classicResourceGroupName -Force
