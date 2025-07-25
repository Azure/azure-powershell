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

    # Create test clusters: New-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName22 -NodeVmSize "Standard_D2pls_v5" -GenerateSshKey
    $resourceGroupCluster = 'ClusterForFleet-Test'
    try {
        Get-AzResourceGroup -Name $resourceGroupCluster -ErrorAction Stop
    } catch {
        New-AzResourceGroup -Name $resourceGroupCluster -Location eastus
    }

    $createKubernetesVersion = '1.27.7'
    # create default version 1.27.7, cluster upgrading will block the removation of memeber
    $env.UpgradeKubernetesVersion = '1.27.7'
    $clusterName11 = 'FleetCluster11'
    $clusterName12 = 'FleetCluster12'
    $clusterName21 = 'FleetCluster21'
    $clusterName22 = 'FleetCluster22'
    try {
        $cluster11 = Get-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName11 -ErrorAction Stop
        Write-Host "Cluster 11 created"
    } catch {
        Write-Host "Cluster 11 creating"
        $cluster11 = New-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName11 -NodeVmSize "Standard_D2pls_v5" -EnableManagedIdentity -KubernetesVersion $createKubernetesVersion
    }

    try {
        $cluster12 = Get-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName12 -ErrorAction Stop
        Write-Host "Cluster 12 created"
    } catch {
        Write-Host "Cluster 12 creating"
        $cluster12 = New-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName12 -NodeVmSize "Standard_D2pls_v5" -EnableManagedIdentity -KubernetesVersion $createKubernetesVersion
    }
    
    try {
        $cluster21 = Get-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName21 -ErrorAction Stop
        Write-Host "Cluster 21 created"
    } catch {
        Write-Host "Cluster 21 creating"
        $cluster21 = New-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName21 -NodeVmSize "Standard_D2pls_v5" -EnableManagedIdentity -KubernetesVersion $createKubernetesVersion
    }
    
    try {
        $cluster22 = Get-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName22 -ErrorAction Stop
        Write-Host "Cluster 22 created"
    } catch {
        Write-Host "Cluster 22 creating"
        $cluster22 = New-AzAksCluster -ResourceGroupName $resourceGroupCluster -Name $clusterName22 -NodeVmSize "Standard_D2pls_v5" -EnableManagedIdentity -KubernetesVersion $createKubernetesVersion
    }
    # $env.clusterID11 = '/subscriptions/'+$env.SubscriptionId+'/resourceGroups/'+$resourceGroupCluster+'/providers/microsoft.containerservice/managedClusters/FleetCluster11'
    # $env.clusterID12 = '/subscriptions/'+$env.SubscriptionId+'/resourceGroups/'+$resourceGroupCluster+'/providers/microsoft.containerservice/managedClusters/FleetCluster12'
    # $env.clusterID21 = '/subscriptions/'+$env.SubscriptionId+'/resourceGroups/'+$resourceGroupCluster+'/providers/microsoft.containerservice/managedClusters/FleetCluster21'
    # $env.clusterID22 = '/subscriptions/'+$env.SubscriptionId+'/resourceGroups/'+$resourceGroupCluster+'/providers/microsoft.containerservice/managedClusters/FleetCluster22'
    $env.clusterID11 = $cluster11.Id
    $env.clusterID12 = $cluster12.Id
    $env.clusterID21 = $cluster21.Id
    $env.clusterID22 = $cluster22.Id

    $env.resourceGroup = 'FLEET-TEST'
    $env.resourceGroup2 = 'FLEET2-TEST'
    $env.Location = "eastus"

    $env.testFleet1 = 'testfleet1'
    $env.testFleet2 = 'testfleet2'
    $env.testFleet3 = 'testfleet3'
    $env.testFleetMember1 = 'testfletmember1'
    $env.testFleetMember2 = 'testfleetmember2'
    $env.testFleetMember3 = 'testfletmember3'
    $env.testFleetMember4 = 'testfleetmember4'
    $env.testUpdateRun1 = 'testupdaterun1'
    $env.testUpdateRun2 = 'testupdaterun2'
    $env.testUpdateStrategy1 = 'testupdatestrategy1'
    $env.testUpdateStrategy2 = 'testupdatestrategy2'
    $env.testGroup1 = 'testgroup1a'
    $env.testGroup2 = 'testgroup2a'

    Write-Host "Start to create test resource group" $env.resourceGroup
    try {
        Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction Stop
        Write-Host "Get created group"
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup -Location $env.Location
    }
    Write-Host "Start to create test resource group" $env.resourceGroup2
    try {
        Get-AzResourceGroup -Name $env.resourceGroup2 -ErrorAction Stop
        Write-Host "Get created group"
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup2 -Location $env.Location
    }

    $managementIdenetityName = 'fleetTestUserAssigned'
    try {
        $fleetTestUserAssigned = Get-AzUserAssignedIdentity -Name $managementIdenetityName -ResourceGroupName $env.resourceGroup2 -ErrorAction Stop
    }
    catch {
        $fleetTestUserAssigned = New-AzUserAssignedIdentity -Name $managementIdenetityName -ResourceGroupName $env.resourceGroup2 -Location $env.Location
    }
    $env.managementIdenetityID = $fleetTestUserAssigned.Id

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzUserAssignedIdentity -Name $managementIdenetityName -ResourceGroupName $env.resourceGroup2
    Remove-AzResourceGroup -Name $env.resourceGroup
    Remove-AzResourceGroup -Name $env.resourceGroup2
}

