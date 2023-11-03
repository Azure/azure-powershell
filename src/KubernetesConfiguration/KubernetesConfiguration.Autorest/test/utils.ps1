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

    $k8sName1 = RandomString -allChars $false -len 6

    $flux1 = RandomString -allChars $false -len 6
    $flux2 = RandomString -allChars $false -len 6

    $clusterName = RandomString -allChars $false -len 6

    $extensionName = RandomString -allChars $false -len 6

    $kubernetesConfigurationName1 = RandomString -allChars $false -len 6
    $kubernetesConfigurationName2 = RandomString -allChars $false -len 6

    $env.Add("k8sName1", $k8sName1)

    $env.Add("flux1", $flux1)
    $env.Add("flux2", $flux2)

    $env.Add("clusterName", $clusterName)

    $env.Add("extensionName", $extensionName)

    $env.Add("kubernetesConfigurationName1", $kubernetesConfigurationName1)
    $env.Add("kubernetesConfigurationName2", $kubernetesConfigurationName2)

    $env.Add("location", "eastus")

    $resourceGroup = "testgroup" + $env.k8sName1
    $env.Add("resourceGroup", $resourceGroup)

    write-host "1. start to create test group..."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    write-host "2. az aks create..."
    az aks create --name $env.k8sName1 --resource-group $env.resourceGroup --kubernetes-version 1.25.5 --vm-set-type AvailabilitySet

    write-host "3. az aks get-credentials..."
    az aks get-credentials --name $env.k8sName1 --resource-group $env.resourceGroup

    write-host "4. az connectedk8s connect..."
    az connectedk8s connect --name $env.clusterName --resource-group $env.resourceGroup --location $env.location

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Remove-AzResourceGroup -Name $env.resourceGroup
}