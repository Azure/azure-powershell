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

    $resourceGroup = "resourceGroupAutorest" + RandomString -allChars $false -len 6
    $namespaceName = "namespaceName" + RandomString -allChars $false -len 6
    $authRule = "auth-rule" + RandomString -allChars $false -len 6
    $eventHubAuthRule = "auth-rule" + RandomString -allChars $false -len 6
    $appGroup = "appGroup" + RandomString -allChars $false -len 6
    $schemaGroup = "schemaGroup" + RandomString -allChars $false -len 6
    $eventHub = "eventHub" + RandomString -allChars $false -len 6
    $cluster = "cluster" + RandomString -allChars $false -len 6

    New-AzResourceGroup -Name $resourceGroup -Location eastus

    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("namespace", $namespaceName)
    $env.Add("authRule", $authRule)
    $env.Add("eventHubAuthRule", $eventHubAuthRule)
    $env.Add("appGroup", $appGroup)
    $env.Add("schemaGroup", $schemaGroup)
    $env.Add("eventHub", $eventHub)
    $env.Add("createdCluster", "TestClusterAutomatic")
    $env.Add("cluster", $cluster)
    $env.Add("clusterResourceGroup", "AutomatedPowershellTesting")
    $env.Add("consumerGroup", "default")

    $eventHubTemplate = Get-Content .\test\deployment-template\parameter.json | ConvertFrom-Json
    $eventHubTemplate.parameters.namespace_name.value = $namespaceName
    $eventHubTemplate.parameters.namespace_auth_rule_name.value = $authRule
    $eventHubTemplate.parameters.eventhub_auth_rule_name.value = $eventHubAuthRule
    $eventHubTemplate.parameters.eventhub_name.value = $eventHub
    $eventHubTemplate.parameters.schema_group_name.value = $schemaGroup
    $eventHubTemplate.parameters.appgroup_name.value = $appGroup
    $eventHubTemplate.parameters.resourcegroup_name.value = $resourceGroup
    Set-Content -Path .\test\deployment-template\parameter.json -Value (ConvertTo-Json $eventHubTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\template.json -TemplateParameterFile .\test\deployment-template\parameter.json -Name eventHubTemplate -ResourceGroupName $resourceGroup

    $resourceNames = Get-Content .\test\deployment-template\pre-created-resources\parameter.json | ConvertFrom-Json
    $env.Add("storageAccountId", $resourceNames.parameters.storageAccountId.Value)
    $env.Add("blobContainer", $resourceNames.parameters.blobContainer.Value)

    Write-Host -ForegroundColor Magenta "Deployed template"

    # For any resources you created for test, you should add it to $env here.
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

