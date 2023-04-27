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
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    $null = $env.Add("rstr1", $rstr1)
    $null = $env.Add("rstr2", $rstr2)
    $null = $env.Add("rstr3", $rstr3)
    $resourceGroup = 'prometheus-rg-' + $rstr1
    $null = $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus
    $email1 = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'user1@example.com'
    $actiongroup = Set-AzActionGroup -Name $rstr1 -ResourceGroupName $resourceGroup -ShortName $rstr1 -Receiver $email1
    $rule1 = New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m" -Expression 'histogram_quantile(0.99, sum(rate(jobs_duration_seconds_bucket{service="billing-processing"}[5m])) by (job_type))'
    $scope = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lnxtest/providers/microsoft.monitor/accounts/lnxmonitorworkspace"
    New-AzPrometheusRuleGroup -ResourceGroupName $resourceGroup -RuleGroupName $rstr1 -Location eastus -Rule $rule1 -Scope $scope -Enabled
    New-AzPrometheusRuleGroup -ResourceGroupName $resourceGroup -RuleGroupName $rstr3 -Location eastus -Rule $rule1 -Scope $scope -Enabled

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    Remove-AzResourceGroup -Name $env.resourceGroup
}

