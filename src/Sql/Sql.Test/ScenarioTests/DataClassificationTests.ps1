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

<#
.SYNOPSIS
Tests end to end scenario of Data Classification on a SQL managed database.
#>
function Test-BasicDataClassificationOnSqlManagedDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-ManagedDataClassificationTestEnvironment $testSuffix
	$params = Get-DataClassificationManagedTestEnvironmentParameters $testSuffix

	try
	{
		# Get recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlInstanceDatabaseSensitivityRecommendation -ResourceGroupName $params.rgname -InstanceName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual 0 ($recommendations.SensitivityLabels).count
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.serverName $recommendations.InstanceName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.serverName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityRecommendation 
		Assert-AreEqual 0 ($recommendations.SensitivityLabels).count
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.serverName $recommendations.InstanceName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName

		# Get sensitivity classifications and verify.
		$allClassifications = Get-AzSqlInstanceDatabaseSensitivityClassification -ResourceGroupName $params.rgname -InstanceName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual 0 ($allClassifications.SensitivityLabels).count
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
		
		# Get, using pipeline, sensitivity classifications and verify.
		$allClassifications = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.serverName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification
		Assert-AreEqual 0 ($allClassifications.SensitivityLabels).count
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName

		# Classify as recommended and verify.
		Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.serverName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityRecommendation | Set-AzSqlInstanceDatabaseSensitivityClassification
		
		# Remove classified columns.
		Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.serverName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification | Remove-AzSqlInstanceDatabaseSensitivityClassification
	}
	finally
	{
		# Cleanup
		Remove-DataClassificationManagedTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests end to end scenario of Data Classification on a SQL managed database.
#>
function Test-DataClassificationOnSqlManagedDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-ManagedDataClassificationTestEnvironment $testSuffix
	$params = Get-DataClassificationManagedTestEnvironmentParameters $testSuffix

	try
	{
		# Get recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlInstanceDatabaseSensitivityRecommendation -ResourceGroupName $params.rgname -InstanceName $params.ServerName -DatabaseName $params.databaseName
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.ServerName $recommendations.InstanceName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		
		$recommendationsCount = ($recommendations.SensitivityLabels).count
		Assert-AreEqual 4 $recommendationsCount
		
		$firstRecommendation = ($recommendations.SensitivityLabels)[0]
		$firstSchemaName = $firstRecommendation.SchemaName
		$firstTableName = $firstRecommendation.TableName
		$firstColumnName = $firstRecommendation.ColumnName
		$firstInformationType = $firstRecommendation.InformationType
		$firstSensitivityLabel = $firstRecommendation.SensitivityLabel

		Assert-AreEqual "dbo" $firstSchemaName
		Assert-AreEqual "Persons" $firstTableName
		Assert-NotNullOrEmpty $firstColumnName
		Assert-NotNullOrEmpty $firstInformationType
		Assert-NotNullOrEmpty $firstSensitivityLabel

		$secondRecommendation = ($recommendations.SensitivityLabels)[1]
		$secondSchemaName = $secondRecommendation.SchemaName
		$secondTableName = $secondRecommendation.TableName
		$secondColumnName = $secondRecommendation.ColumnName
		$secondInformationType = $secondRecommendation.InformationType
		$secondSensitivityLabel = $secondRecommendation.SensitivityLabel

		Assert-AreEqual "dbo" $secondSchemaName
		Assert-AreEqual "Persons" $secondTableName
		Assert-NotNullOrEmpty $secondColumnName
		Assert-NotNullOrEmpty $secondInformationType
		Assert-NotNullOrEmpty $secondSensitivityLabel

		# Set first two sensitivity labels as recommended and verify.
		# Second label is set using pipeline.
		Set-AzSqlInstanceDatabaseSensitivityClassification -ResourceGroupName $params.rgname -InstanceName $params.ServerName -DatabaseName $params.databaseName -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName -InformationType $firstInformationType -SensitivityLabel $firstSensitivityLabel
		Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Set-AzSqlInstanceDatabaseSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName -InformationType $secondInformationType -SensitivityLabel $secondSensitivityLabel
		
		$allClassifications = Get-AzSqlInstanceDatabaseSensitivityClassification -ResourceGroupName $params.rgname -InstanceName $params.ServerName -DatabaseName $params.databaseName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 2 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.ServerName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
		
		$firstClassification = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName
		Assert-AreEqual 1 ($firstClassification.SensitivityLabels).count
		$classification = ($firstClassification.SensitivityLabels)[0]
		Assert-AreEqual $firstSchemaName $classification.SchemaName
		Assert-AreEqual $firstTableName $classification.TableName
		Assert-AreEqual $firstColumnName $classification.ColumnName
		Assert-AreEqual $firstInformationType $classification.InformationType
		Assert-AreEqual $firstSensitivityLabel $classification.SensitivityLabel
		
		$secondClassification = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		Assert-AreEqual 1 ($secondClassification.SensitivityLabels).count
		$classification = ($secondClassification.SensitivityLabels)[0]
		Assert-AreEqual $secondSchemaName $classification.SchemaName
		Assert-AreEqual $secondTableName $classification.TableName
		Assert-AreEqual $secondColumnName $classification.ColumnName
		Assert-AreEqual $secondInformationType $classification.InformationType
		Assert-AreEqual $secondSensitivityLabel $classification.SensitivityLabel
		
		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.ServerName $recommendations.InstanceName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		Assert-AreEqual 2 ($recommendations.SensitivityLabels).count
		
		# Remove second classification and verify
		Remove-AzSqlInstanceDatabaseSensitivityClassification -ResourceGroupName $params.rgname -InstanceName $params.ServerName -DatabaseName $params.databaseName -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		
		$allClassifications = Get-AzSqlInstanceDatabaseSensitivityClassification -ResourceGroupName $params.rgname -InstanceName $params.ServerName -DatabaseName $params.databaseName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 1 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.ServerName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
		 
		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityRecommendation
		Assert-AreEqual 3 ($recommendations.SensitivityLabels).count
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.ServerName $recommendations.InstanceName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		
		# Classify, using pipeline, all recommended columns, and verify.
		Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityRecommendation | Set-AzSqlInstanceDatabaseSensitivityClassification
		
		$recommendations = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.ServerName $recommendations.InstanceName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		Assert-AreEqual 0 ($recommendations.SensitivityLabels).count
		
		$allClassifications = Get-AzSqlInstanceDatabaseSensitivityClassification -ResourceGroupName $params.rgname -InstanceName $params.ServerName -DatabaseName $params.databaseName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 4 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.ServerName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
		
		# Remove, using pipeline, second classification and verify
		Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Remove-AzSqlInstanceDatabaseSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		
		$allClassifications = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 3 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.ServerName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
		
		# Remove, using pipeline, all classifications, and verify.
		Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification | Remove-AzSqlInstanceDatabaseSensitivityClassification
		$allClassifications = Get-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.ServerName -Name $params.databaseName | Get-AzSqlInstanceDatabaseSensitivityClassification
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 0 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.ServerName $allClassifications.InstanceName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
	}
	finally
	{
		# Cleanup
		Remove-DataClassificationManagedTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests end to end scenario of Data Classification on a SQL database.
#>
function Test-DataClassificationOnSqlDatabase
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlDataClassificationTestEnvironment $testSuffix
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix

	try
	{
		# Get recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlDatabaseSensitivityRecommendation -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.serverName $recommendations.ServerName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		
		$recommendationsCount = ($recommendations.SensitivityLabels).count
		Assert-AreEqual 4 $recommendationsCount
		
		$firstRecommendation = ($recommendations.SensitivityLabels)[0]
		$firstSchemaName = $firstRecommendation.SchemaName
		$firstTableName = $firstRecommendation.TableName
		$firstColumnName = $firstRecommendation.ColumnName
		$firstInformationType = $firstRecommendation.InformationType
		$firstSensitivityLabel = $firstRecommendation.SensitivityLabel

		Assert-AreEqual "dbo" $firstSchemaName
		Assert-AreEqual "Persons" $firstTableName
		Assert-NotNullOrEmpty $firstColumnName
		Assert-NotNullOrEmpty $firstInformationType
		Assert-NotNullOrEmpty $firstSensitivityLabel

		$secondRecommendation = ($recommendations.SensitivityLabels)[1]
		$secondSchemaName = $secondRecommendation.SchemaName
		$secondTableName = $secondRecommendation.TableName
		$secondColumnName = $secondRecommendation.ColumnName
		$secondInformationType = $secondRecommendation.InformationType
		$secondSensitivityLabel = $secondRecommendation.SensitivityLabel

		Assert-AreEqual "dbo" $secondSchemaName
		Assert-AreEqual "Persons" $secondTableName
		Assert-NotNullOrEmpty $secondColumnName
		Assert-NotNullOrEmpty $secondInformationType
		Assert-NotNullOrEmpty $secondSensitivityLabel

		# Set first two sensitivity labels as recommended and verify.
		# Second label is set using pipeline.
		Set-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName -InformationType $firstInformationType -SensitivityLabel $firstSensitivityLabel
		Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Set-AzSqlDatabaseSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName -InformationType $secondInformationType -SensitivityLabel $secondSensitivityLabel

		$allClassifications = Get-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 2 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.ServerName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
		
		$firstClassification = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityClassification -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName
		Assert-AreEqual 1 ($firstClassification.SensitivityLabels).count
		$classification = ($firstClassification.SensitivityLabels)[0]
		Assert-AreEqual $firstSchemaName $classification.SchemaName
		Assert-AreEqual $firstTableName $classification.TableName
		Assert-AreEqual $firstColumnName $classification.ColumnName
		Assert-AreEqual $firstInformationType $classification.InformationType
		Assert-AreEqual $firstSensitivityLabel $classification.SensitivityLabel

		$secondClassification = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		Assert-AreEqual 1 ($secondClassification.SensitivityLabels).count
		$classification = ($secondClassification.SensitivityLabels)[0]
		Assert-AreEqual $secondSchemaName $classification.SchemaName
		Assert-AreEqual $secondTableName $classification.TableName
		Assert-AreEqual $secondColumnName $classification.ColumnName
		Assert-AreEqual $secondInformationType $classification.InformationType
		Assert-AreEqual $secondSensitivityLabel $classification.SensitivityLabel

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.serverName $recommendations.ServerName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		Assert-AreEqual 2 ($recommendations.SensitivityLabels).count

		# Remove second classification and verify
		Remove-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		
		$allClassifications = Get-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 1 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.ServerName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityRecommendation
		Assert-AreEqual 3 ($recommendations.SensitivityLabels).count
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.serverName $recommendations.ServerName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName

		# Classify, using pipeline, all recommended columns, and verify.
		Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityRecommendation | Set-AzSqlDatabaseSensitivityClassification
		
		$recommendations = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.serverName $recommendations.ServerName
		Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		Assert-AreEqual 0 ($recommendations.SensitivityLabels).count

		$allClassifications = Get-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 4 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.ServerName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName

		# Remove, using pipeline, second classification and verify
		Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Remove-AzSqlDatabaseSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		
		$allClassifications = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityClassification
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 3 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.ServerName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName

		# Remove, using pipeline, all classifications, and verify.
		Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityClassification | Remove-AzSqlDatabaseSensitivityClassification
		$allClassifications = Get-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName | Get-AzSqlDatabaseSensitivityClassification
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 0 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.serverName $allClassifications.ServerName
		Assert-AreEqual $params.databaseName $allClassifications.DatabaseName
	}
	finally
	{
		# Cleanup
		Remove-DataClassificationTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests corresponding errors are raised when setting sensitivity classification.
#>
function Test-ErrorIsThrownWhenInvalidClassificationIsSet
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlDataClassificationTestEnvironment $testSuffix
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix

	try
	{
		# Get recommended sensitivity labels, and verify.
		$recommendations = Get-AzSqlDatabaseSensitivityRecommendation -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		
		$recommendation = ($recommendations.SensitivityLabels)[0]
		$schemaName = $recommendation.SchemaName
		$tableName = $recommendation.TableName
		$columnName = $recommendation.ColumnName
		$informationType = $recommendation.InformationType
		$sensitivityLabel = $recommendation.SensitivityLabel
		
		# Provide illegal information type, and verify error is raised.
		$badInformationType =  $informationType + $informationType
		$badInformationTypeMessage = "Information Type '" + $badinformationType + "' is not part of Information Protection Policy. Please add '" + $badinformationType + "' to the Information Protection Policy, or use one of the following: "
		Assert-ThrowsContains -script { Set-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName `
		-DatabaseName $params.databaseName -SchemaName $schemaName -TableName $tableName -ColumnName $columnName -InformationType $badInformationType `
		-SensitivityLabel $sensitivityLabel} -message $badInformationTypeMessage

		# Provide illegal sensitivity label, and verify error is raised.
		$badSensitivityLabel = $sensitivityLabel + $sensitivityLabel
		$badSensitivityLabelMessage = "Sensitivity Label '" + $badSensitivityLabel + "' is not part of Information Protection Policy. Please add '" + $badSensitivityLabel + "' to the Information Protection Policy, or use one of the following: "
		Assert-ThrowsContains -script { Set-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName `
		-DatabaseName $params.databaseName -SchemaName $schemaName -TableName $tableName -ColumnName $columnName -InformationType $badInformationType `
		-SensitivityLabel $badSensitivityLabel} -message $badSensitivityLabelMessage
		
		# Do not provide neither information type nor sensitivity label, and verify error is raised.
		$message = "Value is not specified neither for InformationType parameter nor for SensitivityLabel parameter"
		Assert-ThrowsContains -script { Set-AzSqlDatabaseSensitivityClassification -ResourceGroupName $params.rgname -ServerName $params.serverName `
		-DatabaseName $params.databaseName -SchemaName $schemaName -TableName $tableName -ColumnName $columnName} -message $message
	}
	finally
	{
		# Cleanup
		Remove-DataClassificationTestEnvironment $testSuffix
	}
}

function Assert-NotNullOrEmpty ($str)
{
	Assert-NotNull $str
	Assert-AreNotEqual "" $str
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-DataClassificationTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "dc-cmdlet-test-rg" +$testSuffix;
			  serverName = "dc-cmdlet-server" +$testSuffix;
			  databaseName = "dc-cmdlet-db" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
		}
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-DataClassificationManagedTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "cl_one";
			  serverName = "dc-cmdlet-server" +$testSuffix;
			  databaseName = "dc-cmdlet-db" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
		}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-ManagedDataClassificationTestEnvironment ($testSuffix, $location = "North Europe")
{
	$params = Get-DataClassificationManagedTestEnvironmentParameters $testSuffix
	
	New-AzureRmResourceGroup -Name $params.rgname -Location $location
	
	# Setup VNET 
	$vnetName = "cl_initial"
	$subnetName = "Cool"
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id
	
	$credentials = Get-ServerCredential
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"
	$collation = "SQL_Latin1_General_CP1_CI_AS"

	$managedInstance = New-AzSqlInstance -ResourceGroupName $params.rgname -Name $params.serverName `
 			-Location $location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName

	New-AzSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.serverName -Name $params.databaseName -Collation $collation
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-DataClassificationManagedTestEnvironment ($testSuffix)
{
	$params = Get-DataClassificationManagedTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-DataClassificationTestEnvironment ($testSuffix)
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-SqlDataClassificationTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	
	New-AzResourceGroup -Name $params.rgname -Location $location

	$password = $params.pwd
    $secureString = ($password | ConvertTo-SecureString -asPlainText -Force)
    $credentials = new-object System.Management.Automation.PSCredential($params.loginName, $secureString)
    New-AzSqlServer -ResourceGroupName  $params.rgname -ServerName $params.serverName -ServerVersion $serverVersion -Location $location -SqlAdministratorCredentials $credentials
	New-AzSqlServerFirewallRule -ResourceGroupName  $params.rgname -ServerName $params.serverName -StartIpAddress 0.0.0.0 -EndIpAddress 255.255.255.255 -FirewallRuleName "dcRule"


	New-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record")
	{
		$fullServerName = $params.serverName + ".database.windows.net"
		$login = $params.loginName
		$databaseName = $params.databaseName

		$connection = New-Object System.Data.SqlClient.SqlConnection
		$connection.ConnectionString = "Server=$fullServerName;uid=$login;pwd=$password;Database=$databaseName;Integrated Security=False;"
		try
		{
			$connection.Open()

			$command = $connection.CreateCommand()
			$command.CommandText = "CREATE TABLE Persons (PersonID int, LastName varchar(255), FirstName varchar(255), Address varchar(255), City varchar(255));"
			$command.ExecuteReader()
		}
		finally
		{
			$connection.Close()
		}
	}
}