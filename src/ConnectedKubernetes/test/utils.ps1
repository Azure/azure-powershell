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
    Write-Host -ForegroundColor Yellow "WARNING: Expected that the user has kubeconfig and cluster-admin access as well helm3 installed, please check if installed Helm3 and Kubectl."
    
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $clusterNameEUS1 = RandomString -allChars $false -len 6
    $clusterNameEUS2 = RandomString -allChars $false -len 6
    $env.Add("clusterNameEUS1", $clusterNameEUS1)
    $env.Add("clusterNameEUS2", $clusterNameEUS2)

    $K8sName = RandomString -allChars $false -len 6
    $env.Add("K8sName", $K8sName)

    $env.Add("locationEUS","eastus")

    $resourceGroupEUS = "testgroup" + $env.locationEUS
    $env.Add("resourceGroupEUS", $resourceGroupEUS)
    
    $kubeContext = 'youriKubtest'
    $env.Add('kubeContext', $kubeContext)

    write-host "1. start to create test group..."
    New-AzResourceGroup -Name $env.resourceGroupEUS -Location "eastus"

    write-host "1. Create a Connected Kubernetes..."
    New-AzConnectedKubernetes -ClusterName $env.clusterNameEUS2 -ResourceGroupName $env.resourceGroupEUS -Location $env.locationEUS -KubeConfig $HOME\.kube\config -KubeContext $env.kubeContext

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroupEUS
}

