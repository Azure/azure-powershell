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

Describe 'New-AzKustoCluster' {
    It 'Create' {
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
            $expectedException = Get-Cluster-Not-Exist-Message -ResourceGroupName $resourceGroupName -ClusterName $clusterName 
            $capacity = Get-Cluster-Default-Capacity

            Write-Host "Creating resource"
            New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

            $clusterCreated = New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -SkuName $skuName -SkuTier $skuTier
            Validate_Cluster $clusterCreated $clusterName $resourceGroupName  $location  "Running" "Succeeded" $resourceType $skuName $skuTier $capacity
        
            [array]$clusterGet = Get-AzKustoCluster -ResourceGroupName $resourceGroupName
            $clusterGetItem = $clusterGet[0]
            Validate_Cluster $clusterGetItem $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $skuName $skuTier $capacity

            $updatedCluster = Update-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSkuName -Tier $skuTier
            Validate_Cluster $updatedCluster $clusterName $resourceGroupName  $location "Running" "Succeeded" $resourceType $updatedSkuName skuTier $capacity

            Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
            Ensure_Cluster_Not_Exist $resourceGroupName $clusterName $expectedException
        }
        finally
        {
            # cleanup the resource group that was used in case it still exists. This is a best effort task, we ignore failures here.
            #Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
            #Invoke-HandledCmdlet -Command {Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue} -IgnoreFailures
        }
    }
}

function Validate_Cluster{
	Param ([Object]$Cluster,
		[string]$ClusterName,
		[string]$ResourceGroup,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
		[string]$ResourceType,
        [string]$SkuName,
        [string]$SkuTier,
		[int]$Capacity)
	Assert-AreEqual $ClusterName $Cluster.Name
	Assert-AreEqual $ResourceGroup $Cluster.ResourceGroup
	Assert-AreEqual $Location $Cluster.Location
	Assert-AreEqual $State $Cluster.State
	Assert-AreEqual $ProvisioningState $Cluster.ProvisioningState
	Assert-AreEqual $ResourceType $Cluster.Type
    Assert-AreEqual $SkuName $Cluster.Sku.Name
    Assert-AreEqual $SkuTier $Cluster.Sku.Tier 
	Assert-AreEqual $Capacity $Cluster.Capacity 
}

function Ensure_Cluster_Not_Exist {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
		[string]$ExpectedErrorMessage)
		$expectedException = $false
		try
        {
			Get-AzKustoCluster -ResourceGroupName $ResourceGroupName -Name $ClusterName
        }
        catch
        {
            if ($_ -Match $ExpectedErrorMessage)
            {
                $expectedException = $true
            }
        }
        if (-not $expectedException)
        {
            throw "Expected exception from calling Get-AzKustoCluster was not caught: '$expectedErrorMessage'."
        }
}
