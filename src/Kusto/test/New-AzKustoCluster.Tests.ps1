$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function Validate_Cluster{
	Param ([Object]$Cluster,
		[string]$ClusterName,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
		[string]$ResourceType,
        [string]$SkuName,
        [string]$SkuTier,
		[int]$Capacity)
	$Cluster.Name | Should Be $ClusterName
	$Cluster.Location | Should Be $Location
	$Cluster.State | Should Be $State
	$Cluster.ProvisioningState | Should Be  $ProvisioningState
	$Cluster.Type | Should Be $ResourceType
    $Cluster.SkuName | Should Be $SkuName
    $Cluster.SkuTier | Should Be $SkuTier 
	$Cluster.SkuCapacity | Should Be $Capacity
}

function Ensure_Cluster_Not_Exist {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
		[string]$ExpectedErrorMessage)
		$exists = $true
		try
        {
            Get-AzKustoCluster -ResourceGroupName $ResourceGroupName -Name $ClusterName
        }
        catch
        {
            $exists = $false
        }
        if ($exists)
        {
            throw "Cluster '$ClusterName' should not exist."
        }
}

Describe 'New-AzKustoCluster' {
    It 'AllTests' {
        try
        {  
            Write-Host "Starting"
            $location = Get-Location
            $resourceGroupName = Get-RG-Name
            $clusterName = Get-Cluster-Name
            $skuName = Get-SkuName
            $skuTier = Get-SkuTier
            $updatedSkuName = Get-Updated-SkuName
            $resourceType =  Get-Cluster-Resource-Type
            $capacity = Get-Cluster-Default-Capacity

            $clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -SkuName $skuName -SkuTier $skuTier
            Validate_Cluster $clusterCreated $clusterName  $location  "Running" "Succeeded" $resourceType $skuName $skuTier $capacity
        
            [array]$clusterGet = Get-AzKustoCluster -ResourceGroupName $resourceGroupName
            $clusterGetItem = $clusterGet[0]
            Validate_Cluster $clusterGetItem $clusterName $location "Running" "Succeeded" $resourceType $skuName $skuTier $capacity

            $updatedCluster = Update-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSkuName -SkuTier $skuTier
            Validate_Cluster $updatedCluster $clusterName $location "Running" "Succeeded" $resourceType $updatedSkuName $skuTier $capacity

            Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
            Ensure_Cluster_Not_Exist $resourceGroupName $clusterName
        }
        finally
        {
            # cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
            Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
        }
    }
}
