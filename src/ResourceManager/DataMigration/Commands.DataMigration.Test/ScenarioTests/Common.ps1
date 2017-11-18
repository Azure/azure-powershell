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
	$useExistingService = ToBool(Get-EnvironmentVariable("useExistingService"))
	$location = Get-EnvironmentVariable("Location")
	$rg = $null
	if($useExistingService)
	{
		$rgName = Get-EnvironmentVariable("ResourceGroupName")
		$rg = Get-AzureRmResourceGroup -Name $rgName -Location $location
	}else{
		$rgName = Get-ResourceGroupName
		$rg = New-AzureRmResourceGroup -Name $rgName -Location $location
	}

	Assert-NotNull $rg

	return $rg
}

function Remove-ResourceGroupForTest ($rg)
{
	if(ToBool(Get-EnvironmentVariable("cleanup"))){
		Remove-AzureRmResourceGroup -Name $rg.ResourceGroupName -Force
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
	$useExistingService = ToBool(Get-EnvironmentVariable("useExistingService"))
	$service = $null
	if($useExistingService){
		$serviceName = Get-EnvironmentVariable("ServiceName")
		$result = Get-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $serviceName
		Assert-AreEqual 1 $result.Count
		$service = $result[0]
	}else{
		$serviceName = Get-ServiceName
		$virtualSubNetId = Get-EnvironmentVariable("VIRTUAL_SUBNET_ID")
		$sku = "Basic_2vCores"
		$service = New-AzureRmDataMigrationService -ResourceGroupName $rg.ResourceGroupName -ServiceName $ServiceName -Location $rg.Location -Sku $sku -VirtualSubnetId $virtualSubNetId
	}

	Assert-NotNull $service

	return $service
}

function Create-ProjectSqlSqlDb($rg, $service)
{
	$ProjectName = Get-ProjectName
	$db1 = New-ProjectDbInfos
	$db2 = New-ProjectDbInfos
	$dbList = @($db1, $db2)
	$sourceConnInfo = New-SourceSqlConnectionInfo
	$targetConnInfo = New-TargetSqlConnectionInfo

    $project = New-AzureRmDataMigrationProject -ResourceGroupName $rg.ResourceGroupName -ServiceName $service.Name -ProjectName $ProjectName -Location $rg.Location -SourceType SQL -TargetType SQLDB -SourceConnection $sourceConnInfo -TargetConnection $targetConnInfo -DatabaseInfo $dbList

	return $project
}

function getDmsAssetName($prefix)
{    
    $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName("testName",$prefix+"-PsTestRun")

    return $assetName
}

function New-SourceSqlConnectionInfo
{
	$dataSource = Get-EnvironmentVariable("SQL_SOURCE_DATASOURCE")
	$connectioninfo = New-AzureRmDmsConnInfo -ServerType SQL -DataSource $dataSource -AuthType SqlAuthentication -TrustServerCertificate:$true

	return $connectioninfo
}

function New-TargetSqlConnectionInfo
{
	$dataSource = Get-EnvironmentVariable("SQLDB_TARGET_DATASOURCE")
	$connectioninfo = New-AzureRmDmsConnInfo -ServerType SQL -DataSource $dataSource -AuthType SqlAuthentication -TrustServerCertificate:$true

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

	$dbInfo = New-AzureRmDataMigrationDatabaseInfo -SourceDatabaseName $dbName

	return $dbInfo
}

function Get-EnvironmentVariable($envVar)
{
	$value = [System.Environment]::GetEnvironmentVariable($envVar)

	if ([string]::IsNullOrEmpty($value)){
		$value = getDmsAssetName $envVar
	}

	return $value;
}

function ToBool($value)
{
	$result = $false
	try {
		$result = [System.Convert]::ToBoolean($value)
		}
	catch [FormatException]
	{
		$result = $false
	}

return $result
}

function SleepTask($value){
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		Start-Sleep -s $value
	}else{
		Start-Sleep -s 0
	}
}