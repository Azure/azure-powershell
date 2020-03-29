$TestMode='playback'
$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function Validate_Database {
	Param ([Object]$Database,
		[string]$DatabaseFullName,
		[string]$Location,
		[string]$ResourceType,
		[timespan]$SoftDeletePeriodInDays,
		[timespan]$HotCachePeriodInDays)
		$Database.Name | Should Be $DatabaseFullName
		$Database.Location | Should Be $Location
		$Database.Type | Should Be $ResourceType
		$Database.SoftDeletePeriod | Should Be $SoftDeletePeriodInDays 
		$Database.HotCachePeriod | Should Be $HotCachePeriodInDays
}

function Ensure_Database_Not_Exist {
	Param ([String]$ResourceGroupName,
			[String]$ClusterName,
			[string]$DatabaseName,
		[string]$ExpectedErrorMessage)
		$exists = $true
		try
        {
			Get-AzKustoDatabase -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName -Name $DatabaseName
        }
        catch
        {
            $exists = $false
        }
        if ($exists)
        {
            throw "Database '$DatabaseName' should not exist."
        }
}

Describe 'Set-AzKustoDatabase' {
    It 'AllTests' {
        try
        {  
            $location = Get-Location
            $resourceGroupName = Get-RG-Name
            $clusterName = Get-Cluster-Name
            $skuName = Get-SkuName
            $skuTier = Get-SkuTier
            $databaseName = Get-Database-Name
            $resourceType =  Get-Database-Type
            $softDeletePeriodInDays =  Get-Soft-Delete-Period-In-Days
            $hotCachePeriodInDays =  Get-Hot-Cache-Period-In-Days
            $databaseFullName = "$clusterName/$databaseName"
            $expectedException = Get-Database-Not-Exist-Message -DatabaseName $databaseName
            
            $softDeletePeriodInDaysUpdated = Get-Updated-Soft-Delete-Period-In-Days
            $hotCachePeriodInDaysUpdated = Get-Updated-Hot-Cache-Period-In-Days

            #create cluster for the databases
            #New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
            New-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -SkuName $skuName -SkuTier $skuTier

            $databaseProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ReadWriteDatabase -Property @{Location=$location; SoftDeletePeriod=$softDeletePeriodInDays; HotCachePeriod=$hotCachePeriodInDays}
            $databaseCreated = New-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Parameter $databaseProperties
            Validate_Database $databaseCreated $databaseFullName $location $resourceType $softDeletePeriodInDays $hotCachePeriodInDays

            $databaseGetItem = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
            Validate_Database $databaseGetItem $databaseFullName $location $resourceType $softDeletePeriodInDays $hotCachePeriodInDays
            
            $databaseProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ReadWriteDatabase -Property @{SoftDeletePeriod= $softDeletePeriodInDaysUpdated; HotCachePeriod=$hotCachePeriodInDaysUpdated}
            $databaseUpdatedWithParameters = Update-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName -Parameter $databaseProperties
            Validate_Database $databaseUpdatedWithParameters $databaseFullName $location $resourceType $softDeletePeriodInDaysUpdated $hotCachePeriodInDaysUpdated

            Remove-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
            Ensure_Database_Not_Exist $resourceGroupName $clusterName $databaseName $expectedException
        }
        finally
        {
    		# delete the cluster. This is a best effort task, we ignore failures here.
            Invoke-HandledCmdlet -Command {Remove-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -ErrorAction SilentlyContinue} -IgnoreFailures
        }
    }
}
