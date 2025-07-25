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

    $caCertificate = "a" + (RandomString -allChars $false -len 6)
    $channel = "a" + (RandomString -allChars $false -len 6)
    $client = "a" + (RandomString -allChars $false -len 6)
    $clientGroup = "a" + (RandomString -allChars $false -len 6)
    $domain = "a" + (RandomString -allChars $false -len 6)
    $domainEventSub = "a" + (RandomString -allChars $false -len 6)
    $domainTopic = "a" + (RandomString -allChars $false -len 6)
    $domainTopicEventSub = "a" + (RandomString -allChars $false -len 6)
    $eventSub = "a" + (RandomString -allChars $false -len 6)
    $namespace = "a" + (RandomString -allChars $false -len 6)
    $namespace2 = "a" + (RandomString -allChars $false -len 6)
    $namespaceTopic = "a" + (RandomString -allChars $false -len 6)
    $namespaceTopicEventSub = "a" + (RandomString -allChars $false -len 6)
    $partnerConfiguration = "a" + (RandomString -allChars $false -len 6)
    $partnerDestination = "a" + (RandomString -allChars $false -len 6)
    $partnerNamespace = "a" + (RandomString -allChars $false -len 6)
    $partnerRegistration = "a" + (RandomString -allChars $false -len 6)
    $partnerTopicEventSub = "a" + (RandomString -allChars $false -len 6)
    $permissionBind = "a" + (RandomString -allChars $false -len 6)
    $sysTopic = "a" + (RandomString -allChars $false -len 6)
    $sysTopicEventSub = "a" + (RandomString -allChars $false -len 6)
    $topic = "a" + (RandomString -allChars $false -len 6)
    $TopicEventSub = "a" + (RandomString -allChars $false -len 6)
    $topicSpace = "a" + (RandomString -allChars $false -len 6)
    
    $env.Add("caCertificate", $caCertificate)
    $env.Add("channel", $channel)
    $env.Add("client", $client)
    $env.Add("clientGroup", $clientGroup)
    $env.Add("domain", $domain)
    $env.Add("domainEventSub", $domainEventSub)
    $env.Add("domainTopic", $domainTopic)
    $env.Add("domainTopicEventSub", $domainTopicEventSub)
    $env.Add("eventSub", $eventSub)
    $env.Add("namespace", $namespace)
    $env.Add("namespace2", $namespace2)
    $env.Add("namespaceTopic", $namespaceTopic)
    $env.Add("namespaceTopicEventSub", $namespaceTopicEventSub)
    $env.Add("partnerConfiguration", $partnerConfiguration)
    $env.Add("partnerDestination", $partnerDestination)
    $env.Add("partnerNamespace", $partnerNamespace)
    $env.Add("partnerRegistration", $partnerRegistration)
    $env.Add("partnerTopicEventSub", $partnerTopicEventSub)
    $env.Add("permissionBind", $permissionBind)
    $env.Add("sysTopic", $sysTopic)
    $env.Add("sysTopicEventSub", $sysTopicEventSub)
    $env.Add("topic", $topic)
    $env.Add("TopicEventSub", $TopicEventSub)
    $env.Add("topicSpace", $topicSpace)
    
    $EndpointUrl = "https://azpssite04.azurewebsites.net/api/updates"
    $env.Add("EndpointUrl", $EndpointUrl)

    $StorageAccount = "azpssa0430"
    $env.Add("StorageAccount", $StorageAccount)

    $env.Add("location", "eastus")

    # Create the test group
    # Need to create env: App Server, App Server plan, Application Insights, Function App, Managed Identity, Storage account, Smart detector alert rule
    write-host "start to create test group"
    $resourceGroup = "azps_test_group_eventgrid"
    $env.Add("resourceGroup", $resourceGroup)

    # New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    New-AzEventGridNamespace -Name $env.namespace -ResourceGroupName $env.resourceGroup -Location $env.location -TopicSpaceConfigurationState Enabled

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
}

