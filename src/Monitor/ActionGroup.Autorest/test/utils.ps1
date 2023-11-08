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

    $env.resourceGroup = 'Monitor-ActionGroup'
    $env.region = 'northcentralus'
    
    Write-Host "Start to create test resource group" $env.resourceGroup
    try {
        Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction Stop
        Write-Host "Get created group"
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup -Location $env.region
    }

    $env.useremail = 'v-jiaji@microsoft.com'
    $env.emailreceiver1 = 'emailreceiver1'
    $env.emailreceiver2 = 'emailreceiver2'
    $env.userphone = '18964587446'
    $env.phonecountry = '86'
    $env.smsreceiver = 'smsreceiver'

    $env.actiongroupname = 'actiongroupGet'
    $env.actiongroup1 = 'actiongroup1'
    $env.actiongroup3 = 'actiongroup3'

    $env.EventHubNamespaceName = "Namespace$(Get-Random)"
    New-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -NamespaceName $env.EventHubNamespaceName -Location $env.region
    $env.eventHubName = "testEventHub$(Get-Random)"
    New-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.EventHubNamespaceName -EventHubName $env.eventHubName
    Write-Host "create test event hub namespace" $env.EventHubNamespaceName
    Write-Host "create test event hub" $env.eventHubName

    Write-Host "Start to create test action group" $env.actiongroupname
    $email1 = New-AzActionGroupEmailReceiverObject -EmailAddress $env.useremail -Name $env.emailreceiver1
    $sms1 = New-AzActionGroupSmsReceiverObject -CountryCode $env.phonecountry -Name $env.smsreceiver -PhoneNumber $env.userphone
    $ag = New-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup -Location southcentralus -EmailReceiver $email1 -SmsReceiver $sms1 -ShortName ag1

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzActionGroup -Name 'actiongroupGet' -ResourceGroupName 'Monitor-ActionGroup'
}

