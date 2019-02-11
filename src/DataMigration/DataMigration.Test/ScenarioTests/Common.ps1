# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

function Create-ResourceGroupForTest
{
	$useExistingService = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigBool("useExistingService")
	$location = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("Location")
	$rg = $null
	if($useExistingService)
	{
		$rgName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("ResourceGroupName")
		$rg = Get-AzResourceGroup -Name $rgName -Location $location
	}else{
		$rgName = Get-ResourceGroupName
		$rg = New-AzResourceGroup -Name $rgName -Location $location
	}

	Assert-NotNull $rg

	return $rg
}

function Remove-ResourceGroupForTest ($rg)
{
	if([Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigBool("cleanup")){
		Remove-AzResourceGroup -Name $rg.ResourceGroupName -Force
	}
}

function Get-ResourceGroupName
{
    return getDmsAssetName "DmResource"
}

function Get-ServiceName
{
    return getDmsAssetName "DmService"
}

function Get-ProjectName
{
    return getDmsAssetName "DmProject"
}

function Get-TaskName
{
    return getDmsAssetName "DmTask"
}

function Get-DbName
{
    return getDmsAssetName "DmDbName"
}

function Create-DataMigrationService($rg)
{
	$useExistingService = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigBool("useExistingService")
	$service = $null
	if($useExistingService){
		$serviceName = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("ServiceName")
		$result = Get-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $serviceName
		Assert-AreEqual 1 $result.Count
		$service = $result[0]
	}else{
		$serviceName = Get-ServiceName
		$virtualSubNetId = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("VIRTUAL_SUBNET_ID")
		$sku = "Premium_4vCores"
		$service = New-AzDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $ServiceName -Location $rg.Location -Sku $sku -VirtualSubnetId $virtualSubNetId
	}

	Assert-NotNull $service

	return $service
}

function Create-ProjectSqlSqlDb($rg, $service)
{
	return Create-Project $rg $service SQLDB
}

function Create-ProjectSqlSqlDbMi($rg, $service)
{
	return Create-Project $rg $service SQLMI
}

function Create-Project($rg, $service, $targetPlatform)
{
	$ProjectName = Get-ProjectName
	$db1 = New-ProjectDbInfos
	$db2 = New-ProjectDbInfos
	$dbList = @($db1, $db2)
	$sourceConnInfo = New-SourceSqlConnectionInfo
	$targetConnInfo = New-TargetSqlConnectionInfo

    $project = New-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $ProjectName -Location $rg.Location -SourceType SQL -TargetType $targetPlatform -SourceConnection $sourceConnInfo -TargetConnection $targetConnInfo -DatabaseInfo $dbList

	return $project
}

function Create-ProjectMongoDbMongoDb($rg, $service)
{
	$ProjectName = Get-ProjectName
	$sourceConnInfo = New-SourceMongoDbConnectionInfo
	$targetConnInfo = New-TargetMongoDbConnectionInfo

    $project = New-AzDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $ProjectName -Location $rg.Location -SourceType MongoDb -TargetType MongoDb -SourceConnection $sourceConnInfo -TargetConnection $targetConnInfo

	return $project
}

function New-SourceMongoDbConnectionInfo
{
	$sourceConn = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("MONGODB_SOURCE_CONNECTIONSTRING")
	$connectioninfo = New-AzDmsConnInfo -ServerType MongoDb -ConnectionString $sourceConn
	return $connectioninfo
}

function New-TargetMongoDbConnectionInfo
{
	$cosmosConn = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("COSMOSDB_TARGET_CONNECTIONSTRING")
	$connectioninfo = New-AzDmsConnInfo -ServerType MongoDb -ConnectionString $cosmosConn
	return $connectioninfo
}

function getDmsAssetName($prefix)
{    
    $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName("testName",$prefix+"-PsTestRun")

    return $assetName
}

function New-SourceSqlConnectionInfo
{
	$dataSource = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQL_SOURCE_DATASOURCE")
	$connectioninfo = New-AzDmsConnInfo -ServerType SQL -DataSource $dataSource -AuthType SqlAuthentication -TrustServerCertificate:$true

	return $connectioninfo
}

function New-TargetSqlConnectionInfo
{
	$dataSource = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDB_TARGET_DATASOURCE")
	$connectioninfo = New-AzDmsConnInfo -ServerType SQL -DataSource $dataSource -AuthType SqlAuthentication -TrustServerCertificate:$true

	return $connectioninfo
}

function New-TargetSqlMiConnectionInfo
{
	$dataSource = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("SQLDBMI_TARGET_DATASOURCE")
	$connectioninfo = New-AzDmsConnInfo -ServerType SQL -DataSource $dataSource -AuthType SqlAuthentication -TrustServerCertificate:$true

	return $connectioninfo
}

function Get-Creds($userName, $password)
{
	$secpasswd = ConvertTo-SecureString -String $password -AsPlainText -Force
	$creds = New-Object System.Management.Automation.PSCredential ($userName, $secpasswd)

	return $creds
}

function New-ProjectDbInfos
{
	$dbName = Get-DbName

	$dbInfo = New-AzDataMigrationDatabaseInfo -SourceDatabaseName $dbName

	return $dbInfo
}

function SleepTask($value){
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		Start-Sleep -s $value
	}else{
		Start-Sleep -s 0
	}
}

function New-TargetSqlMiSyncConnectionInfo
{
	$miResourceId = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("MI_RESOURCE_ID")
	$connectioninfo = New-AzDmsConnInfo -ServerType SQLMI -MiResourceId $miResourceId

	return $connectioninfo
}

function New-AzureActiveDirectoryApp
{
	$pwd = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("AZURE_AAD_APP_KEY")
	$appId = [Microsoft.Azure.Commands.DataMigrationConfig]::GetConfigString("AZURE_AAD_APP_ID")

	$secpasswd = ConvertTo-SecureString $pwd -AsPlainText -Force
	$app = New-AzDmsAadApp -ApplicationId $appId -AppKey $secpasswd
	return $app
}