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
    
    # For any resources you created for test, you should add it to $env here.
    $env.ReportName = "powershell-test-report-fordelete"
    $env.GeneratedReportName = "powershell-test-report"
    $env.ResourceId = "/subscriptions/f744fbde-a95f-437e-8fcf-38f9324e3d9c/resourceGroups/github-action-deploy/providers/Microsoft.Storage/storageAccounts/storexahdnmg5xqlduarm"
    $env.TimeZone = "Pacific Standard Time"
    $env.WebhookName = "test-webhook-fordelete"
    $env.PreparedWebhookName = "test-webhook"
    $env.PayloadUrl = "https://a.b.c.com"
    $env.NewPayloadUrl = "https://a.b.com"
    $env.Secret = "testSecret"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

