function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord)
{
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache)
    { return $this[$key]
    } else
    { $this[$key] = $val; return $val
    } } -Name 'AddWithCache'
function setupEnv()
{
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $env.ResourceGroupName = 'azwps-test-rg'
    $env.Location = 'eastus'
    $env.WpsPrefix = 'azwps-'
    $env.Wps1 = $env.WpsPrefix + '1'
    $env.Wps2 = $env.WpsPrefix +'2'
    $env.Hub1 = "hub1"
    $env.Hub2 = "hub2"
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live')
    {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)

    Write-Host -ForegroundColor Green "Start to creating resource group for test..."
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location
    Write-Host -ForegroundColor Green "Resource group created successfully."
    $createWpsJob1 = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $env.Wps1 -Location $env.Location -SkuName Standard_S1 -AsJob
    $createWpsJob2 = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $env.Wps2 -Location $env.Location -SkuName Standard_S1 -AsJob
    $createHubJob1 = New-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $env.Hub1 -AsJob
    $createHubJob2 = New-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $env.Hub2 -AsJob
    Wait-Job $createWpsJob1, $createWpsJob2, $createHubJob1, $createHubJob2
}
function cleanupEnv()
{
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName
}

