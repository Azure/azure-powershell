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
    $env.Location = 'eastus'
    # For any resources you created for test, you should add it to $env here.
    $env.HealthBot1 = 'yourihealthbot' + (RandomString -allChars $false -len 6)
    $env.HealthBot2 = 'yourihealthbot' + (RandomString -allChars $false -len 6)
    $null = $env.Add('S1', 'S1')
    $null = $env.Add('F0', 'F0')

    Write-Host -ForegroundColor Green "Create test group..."
    $ResourceGroupName = 'youriADDomain-rg-' + (RandomString -allChars $false -len 6)
    Write-Host $ResourceGroupName
    New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

    $null = $env.Add('ResourceGroupName', $ResourceGroupName)
    Write-Host -ForegroundColor Green 'The test group create completed.'

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

