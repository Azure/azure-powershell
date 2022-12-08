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
    # For any resources you created for test, you should add it to $env here.\
    $env.location = 'westcentralus'
    $env.resourceGroup = "voiceservices-rg" + (RandomString -allChars $false -len 6)
    $env.gatewayName01 = "vsgateway-" + (RandomString -allChars $false -len 6)
    $env.gatewayName02 = "vsgateway-" + (RandomString -allChars $false -len 6)
    $env.gatewayName03 = "vsgateway-" + (RandomString -allChars $false -len 6)
    $env.contactName02 = "contact-" + (RandomString -allChars $false -len 6)
    $env.testlineName02 = "contact-" + (RandomString -allChars $false -len 6)

    Write-Host "start to create test group"
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    Write-Host "Create a communications gateway for test"
    $region = @()
    $region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast -PrimaryRegionOperatorAddress '198.51.100.1'
    $region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast2 -PrimaryRegionOperatorAddress '198.51.100.2'
    New-AzVoiceServicesCommunicationsGateway -ResourceGroupName $env.resourceGroup -Name $env.gatewayName01 -Location $env.location -Codec 'PCMA' -E911Type 'Standard' -Platform 'OperatorConnect' -ServiceLocation $region 
   
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

