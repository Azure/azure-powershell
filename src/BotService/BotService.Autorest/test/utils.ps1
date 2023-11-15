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
    $env.location = 'westus'
    Write-Host "You need to import Az.Resources first"
    Import-Module Az.Resources
    Import-Module Az.Websites
    # For any resources you created for test, you should add it to $env here.
    $WebApplication1 = '2d00693f-17b0-4b43-b850-1d3fb485272e'
    $WebApplication2 = '88527e5d-3cc9-4c64-905e-f6d4f59a45f3'
    $WebApplication3 = '51f84f37-0b28-4e00-9ea6-576e2db57dd2'
    $WebApplication4 = 'e55b126c-e2e4-4259-a3c0-1101ab7a908a'
    $NewBotService1 = 'BotService-' + (RandomString -allChars $false -len 6)
    $NewBotService2 = 'BotService-' + (RandomString -allChars $false -len 6)
    $NewBotService3 = 'BotService-' + (RandomString -allChars $false -len 6)
    $NewBotService4 = 'BotService-' + (RandomString -allChars $false -len 6)

    $Secret = "youriSecret"
    $null = $env.Add('WebApplication1', $WebApplication1)
    $null = $env.Add('WebApplication2', $WebApplication2)
    $null = $env.Add('WebApplication3', $WebApplication3)
    $null = $env.Add('WebApplication4', $WebApplication4)
    $null = $env.Add('NewBotService1', $NewBotService1)
    $null = $env.Add('NewBotService2', $NewBotService2)
    $null = $env.Add('NewBotService3', $NewBotService3)
    $null = $env.Add('NewBotService4', $NewBotService4)
    $null = $env.Add('Secret', $Secret)
    

    Write-Host -ForegroundColor Green "Creating test group..."
    $ResourceGroupName = 'youriBotService-rg-' + (RandomString -allChars $false -len 6)
    Write-Host $ResourceGroupName
    New-AzResourceGroup -Name $ResourceGroupName -Location $env.location
    $null = $env.Add('ResourceGroupName', $ResourceGroupName)
    Write-Host -ForegroundColor Green 'The test group created.'

    Write-Host -ForegroundColor Green "Creating new bot service for Get test..."
    New-AzBotService -Name $NewBotService1 -ResourceGroupName $ResourceGroupName -ApplicationId $WebApplication1 -Sku F0 -Description "description"
    Write-Host -ForegroundColor Green 'New bot service created.'

    Write-Host -ForegroundColor Green "Creating new bot service for Remove test..."
    New-AzBotService -Name $NewBotService4 -ResourceGroupName $ResourceGroupName -ApplicationId $WebApplication4 -Sku F0 -Description "description"
    Write-Host -ForegroundColor Green 'New bot service created.'

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName
}

