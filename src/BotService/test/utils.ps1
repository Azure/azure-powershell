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
    $env.location = 'eastus'
    Write-Host "You need to import Az.Resources first"
    Import-Module Az.Resources
    Import-Module Az.Websites
    # For any resources you created for test, you should add it to $env here.
    $WebApplicationName1 = 'WebApplication-' + (RandomString -allChars $false -len 6)
    $WebApplicationName2 = 'WebApplication-' + (RandomString -allChars $false -len 6)
    $NewBotService1 = 'BotService-' + (RandomString -allChars $false -len 6)
    $NewBotService2 = 'BotService-' + (RandomString -allChars $false -len 6)

    $null = $env.Add('WebApplicationName1', $WebApplicationName1)
    $null = $env.Add('WebApplicationName2', $WebApplicationName2)
    $null = $env.Add('NewBotService1', $NewBotService1)
    $null = $env.Add('NewBotService2', $NewBotService2)

    Write-Host -ForegroundColor Green "Create test group..."
    $ResourceGroupName = 'youriBotService-rg-' + (RandomString -allChars $false -len 6)
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
}

