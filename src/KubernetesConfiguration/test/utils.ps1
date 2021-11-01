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

    $k8sNameEUAP = RandomString -allChars $false -len 6
    $k8sNameCUS = RandomString -allChars $false -len 6

    $clusterNameEUAP = RandomString -allChars $false -len 6
    $clusterNameCUS = RandomString -allChars $false -len 6

    $extensionNameEUAP1 = RandomString -allChars $false -len 6

    $kubernetesConfigurationNameCUS1 = RandomString -allChars $false -len 6
    $kubernetesConfigurationNameCUS2 = RandomString -allChars $false -len 6

    $env.Add("k8sNameEUAP", $k8sNameEUAP)
    $env.Add("k8sNameCUS", $k8sNameCUS)

    $env.Add("clusterNameEUAP", $clusterNameEUAP)
    $env.Add("clusterNameCUS", $clusterNameCUS)

    $env.Add("extensionNameEUAP1", $extensionNameEUAP1)

    $env.Add("kubernetesConfigurationNameCUS1", $kubernetesConfigurationNameCUS1)
    $env.Add("kubernetesConfigurationNameCUS2", $kubernetesConfigurationNameCUS2)

    $env.Add("locationEUAP", "eastus2euap")
    $env.Add("locationCUS", "centralus")

    $resourceGroupEUAP = "testgroup" + $env.locationEUAP
    $resourceGroupCUS = "testgroup" + $env.locationCUS

    $env.Add("resourceGroupEUAP", $resourceGroupEUAP)
    $env.Add("resourceGroupCUS", $resourceGroupCUS)

    write-host "1. start to create test group..."
    New-AzResourceGroup -Name $env.resourceGroupEUAP -Location "eastus"
    write-host "1. az aks create..."
    az aks create --name $env.k8sNameEUAP --resource-group $env.resourceGroupEUAP --kubernetes-version 1.20.9 --vm-set-type AvailabilitySet
    write-host "1. az aks get-credentials..."
    az aks get-credentials --resource-group $env.resourceGroupEUAP --name $env.k8sNameEUAP
    write-host "1. az connectedk8s connect..."
    az connectedk8s connect --name $env.clusterNameEUAP --resource-group $env.resourceGroupEUAP --location $env.locationEUAP

    write-host "2. start to create test group..."
    New-AzResourceGroup -Name $env.resourceGroupCUS -Location "eastus"
    write-host "2. az aks create..."
    az aks create --name $env.k8sNameCUS --resource-group $env.resourceGroupCUS --kubernetes-version 1.20.9 --vm-set-type AvailabilitySet
    write-host "2. az aks get-credentials..."
    az aks get-credentials --resource-group $env.resourceGroupCUS --name $env.k8sNameCUS
    write-host "2. az connectedk8s connect..."
    az connectedk8s connect --name $env.clusterNameCUS --resource-group $env.resourceGroupCUS --location $env.locationCUS

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    Remove-AzResourceGroup -Name $env.resourceGroupEUAP
    Remove-AzResourceGroup -Name $env.resourceGroupCUS
}