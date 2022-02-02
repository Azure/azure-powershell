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

    $k8sName = RandomString -allChars $false -len 6
    $clusterName = RandomString -allChars $false -len 6
    $extensionName = RandomString -allChars $false -len 6
    $clusterLocationName = RandomString -allChars $false -len 6
    $clusterLocationName2 = RandomString -allChars $false -len 6

    $env.Add("k8sName", $k8sName)
    $env.Add("clusterName", $clusterName)
    $env.Add("extensionName", $extensionName)
    $env.Add("clusterLocationName", $clusterLocationName)
    $env.Add("clusterLocationName2", $clusterLocationName2)

    $env.Add("location", "eastus")

    # Create the test group
    $resourceGroup = "testgroup" + $env.clusterLocationName
    $env.Add("resourceGroup", $resourceGroup)
    
    write-host "1. start to create test group..."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    write-host "1. az aks create..."
    az aks create --name $env.k8sName --resource-group $env.resourceGroup --kubernetes-version 1.20.9 --vm-set-type AvailabilitySet

    write-host "1. az aks get-credentials..."
    az aks get-credentials --resource-group $env.resourceGroup --name $env.k8sName

    write-host "1. az connectedk8s connect..."
    az connectedk8s connect --name $env.clusterName --resource-group $env.resourceGroup --location $env.location
    
    write-host "1. az k8s-extension create..."
    az k8s-extension create -c $env.clusterName -g $env.resourceGroup --name $env.extensionName --cluster-type connectedClusters --extension-type microsoft.arcdataservices --auto-upgrade false --scope cluster --release-namespace arc --config Microsoft.CustomLocation.ServiceAccount=sa-bootstrapper
    
    az k8s-extension show -g $env.resourceGroup -c $env.clusterName --name $env.extensionName --cluster-type connectedclusters
    
    $HostResourceId = az connectedk8s show -n $env.clusterName -g $env.resourceGroup --query id -o tsv
    
    $ClusterExtensionId = az k8s-extension show --name $env.extensionName --cluster-type connectedClusters -c $env.clusterName -g $env.resourceGroup --query id -o tsv
    
    $env.Add("HostResourceId", $HostResourceId)
    $env.Add("ClusterExtensionId", $ClusterExtensionId)
    
    # Wait for extension creation to complete
    Start-Sleep –s 180
    
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    Remove-AzResourceGroup -Name $env.resourceGroup
}

