function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus2euap'
    $env.enterpriseAppId = '00000000-0000-0000-0000-000000000000'
    # For any resources you created for test, you should add it to $env here.
    # Generate random string for use in test.
    $env.resourceGroup = 'Datadogmonitor-rg-' + (RandomString -allChars $false -len 6)
    $env.monitorName01 = 'monitor'+ (RandomString -allChars $false -len 6)
    $env.monitorName02 = 'monitor'+ (RandomString -allChars $false -len 6)
    $env.monitorName03 = 'monitor'+ (RandomString -allChars $false -len 6)

    # Create a resource group.
    Write-Host -ForegroundColor Green "Create a $($env.resourceGroup) resource group for test."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Create two monitor for use in test.
    Write-Host -ForegroundColor Green "Create two $($env.monitorName01) and $($env.monitorName02) for test."
    New-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -SkuName 'drawdown_testing_20200904_Monthly' -Location 'eastus2euap' -UserInfoEmailAddress 'user@microsoft.com' -UserInfoName 'user' -UserInfoPhoneNumber '11111111111' -IdentityType SystemAssigned
    New-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02 -SkuName 'drawdown_testing_20200904_Monthly' -Location 'eastus2euap' -UserInfoEmailAddress 'user@microsoft.com' -UserInfoName 'user' -UserInfoPhoneNumber '11111111111' -IdentityType SystemAssigned
    
    # Eable SSO 
    Write-Host -ForegroundColor Green "Enable SSO for $($env.monitorName01) monitor."
    New-AzDatadogSingleSignOnConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default' -SingleSignOnState Enable -EnterpriseAppId $env.enterpriseAppId
    
    # Create tag rules
    Write-Host -ForegroundColor Green "Create default tag rule $($env.monitorName01) monitor."
    $ftobjArray = @()
    $ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
    $ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
    New-AzDatadogTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default' -LogRuleFilteringTag $ftobjArray

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Green "Remove $($env.resourceGroup) resource group for clean all created resource."
    Remove-AzResourceGroup -Name $env.resourceGroup

}

