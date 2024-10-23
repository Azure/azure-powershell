function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}

function setupEnv() {
    Connect-AzAccount -UseDeviceAuthentication

    $env.resourceGroup = 'd4s-v2' + (RandomString -allChars $false -len 6)
    Set-AzContext -Tenant '72f988bf-86f1-41af-91ab-2d7cd011db47' -SubscriptionId 'f5f18ed8-74de-4917-9f69-d5f7e877104c'
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'
    $SAPrefix = "d4sv2sa"
    $env.ResourceId0 = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroup)/providers/Microsoft.Storage/storageAccounts/${SAPrefix}0"
    $env.ResourceId1 = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroup)/providers/Microsoft.Storage/storageAccounts/${SAPrefix}1"
    $env.ResourceId2 = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroup)/providers/Microsoft.Storage/storageAccounts/${SAPrefix}2"
    $env.ResourceId3 = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroup)/providers/Microsoft.Storage/storageAccounts/${SAPrefix}3"

    Write-Host -ForegroundColor Green "Creating test group $($env.ResourceGroup)..."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    Write-Host -ForegroundColor Green 'The test group create completed.'

    Write-Host -ForegroundColor Green "Deploying storage accounts..."
    New-AzDeployment -Mode Incremental -TemplateFile test/deploymentTemplates/template.json -TemplateParameterFile test/deploymentTemplates/parameters.json -ResourceGroupName $env.resourceGroup


    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    Write-Host $env
}

function cleanupEnv() {
    # Removing resourcegroup will clean all the resources created for testing.
    Write-Host -ForegroundColor Green "Deleteing resource group..."
    Remove-AzResourceGroup -Name $env.resourceGroup -SubscriptionId $env.SubscriptionId
}

