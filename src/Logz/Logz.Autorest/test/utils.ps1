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
    $env.location = 'westus2'
    $env.userEmail = 'v-diya@microsoft.com'
    $env.userFirstName = 'Lucas'
    $env.userLastName = 'Yao'
    $env.userPhone = '1111111111'

    $env.monitorName01 = "monitor-" + (RandomString -allChars $false -len 6)
    $env.monitorName02 = "monitor-" + (RandomString -allChars $false -len 6)
    $env.monitorName03 = "monitor-" + (RandomString -allChars $false -len 6)
    $env.monitorName04 = "monitor-" + (RandomString -allChars $false -len 6)

    $env.subAccountName01 = "subAccount" + (RandomString -allChars $false -len 6)
    $env.subAccountName02 = "subAccount" + (RandomString -allChars $false -len 6)
    $env.subAccountName03 = "subAccount" + (RandomString -allChars $false -len 6)
    $env.subAccountName04 = "subAccount" + (RandomString -allChars $false -len 6)
    $env.subAccountName05 = "subAccount" + (RandomString -allChars $false -len 6)
    $env.subAccountName06 = "subAccount" + (RandomString -allChars $false -len 6)

    # Create the test group
    Write-Host -ForegroundColor Green "start to create test group"
    $env.resourceGroup = 'logz-rg-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # # Create logz for use in the test.
    # Write-Host -ForegroundColor Green "Create logz monitor and sub account for use in the test"
    New-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
    New-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
    
    New-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.subAccountName01 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
    New-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.subAccountName02 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
    

    New-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name $env.subAccountName03 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
    New-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name $env.subAccountName04 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName                        
    
    New-AzLogzMonitorTagRule -ResourceGroupName $env.resourceGroup-MonitorName $env.monitorName01
    New-AzLogzMonitorSSOConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
    New-AzLogzSubAccountTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubAccountName $env.subAccountName01
    New-AzLogzSubAccountTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -SubAccountName $env.subAccountName02
    Write-Host -ForegroundColor Green "Compelted create logz monitor and sub account."

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

