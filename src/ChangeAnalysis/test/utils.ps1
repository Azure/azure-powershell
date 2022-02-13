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
    $env.location = 'East US'
    # For any resources you created for test, you should add it to $env here.

    # Create the test group
    Write-Host -ForegroundColor Green "start to create test group"
    $env.resourceGroup = 'changeanalysis-rg-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Deploy keyvault for test
    Write-Host -ForegroundColor Green "Deloying Key Vault..." 
    $kvName = 'keyvalult-' + (RandomString -allChars $false -len 6)
    $kvPara = Get-Content .\test\deployment-templates\key-vault\parameters.json | ConvertFrom-Json
    $kvPara.parameters.vaults_name.value = $kvName
    set-content -Path .\test\deployment-templates\key-vault\parameters.json -Value (ConvertTo-Json $kvPara)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\key-vault\template.json -TemplateParameterFile .\test\deployment-templates\key-vault\parameters.json -ResourceGroupName $env.resourceGroup
    
    $env.keyvaultId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.KeyVault/vaults/$kvName"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Clear-AzResourceGroup -Name $env.resourceGroup
}

