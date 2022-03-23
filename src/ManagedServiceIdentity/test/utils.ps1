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
    $env.location = 'Central US'
    $env.resourceGroup = 'identity-' + (RandomString -len 8)
    $env.appServicePlanName = 'appServicePlan' + (RandomString -len 6)
    $env.appServiceName = 'appService' + (RandomString -len 6)

    $env.userIdentityName01 = 'identity' + (RandomString -len 6)
    $env.userIdentityName02 = 'identity' + (RandomString -len 6)
    $env.userIdentityName03 = 'identity' + (RandomString -len 6)
    
    Write-Host "start to create test group"
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    Write-Host "Deploying app service plan..."
    $appServicePlan = Get-Content .\test\deployment-templates\app-serviceplan\parameters.json | ConvertFrom-Json
    $appServicePlan.parameters.serviceplan_name.value = $env.appServicePlanName
    Set-Content -Path .\test\deployment-templates\app-serviceplan\parameters.json -Value (ConvertTo-Json $appServicePlan)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\app-serviceplan\template.json -TemplateParameterFile .\test\deployment-templates\app-serviceplan\parameters.json -Name nsg -ResourceGroupName $env.resourceGroup

    Write-Host "Deploying app service..."
    $appService = Get-Content .\test\deployment-templates\app-service\parameters.json | ConvertFrom-Json
    $appService.parameters.service_name.value = $env.appServiceName
    $appService.parameters.servicePlan_id.value = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/serverfarms/$($env.appServicePlanName)"
    Set-Content -Path .\test\deployment-templates\app-service\parameters.json -Value (ConvertTo-Json $appService)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\app-service\template.json -TemplateParameterFile .\test\deployment-templates\app-service\parameters.json -Name nsg -ResourceGroupName $env.resourceGroup

    $env.appServiceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Web/sites/$($env.appServiceName)"

    Write-Host "Create user assigned identity."
    New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName01 -Location $env.location

    Write-Host "Setup test environment completed."

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

