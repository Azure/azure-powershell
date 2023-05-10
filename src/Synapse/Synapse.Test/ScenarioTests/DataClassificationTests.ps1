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
Tests end to end scenario of Data Classification on a SQL pool.
TODO: currently ther is no Rank property in SDK model so we
comment some assertions out for now.
#>
function Test-DataClassificationOnSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlDataClassificationTestEnvironment $testSuffix
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix

	try
	{
		# Get recommended sensitivity labels, and verify.
		$recommendations = Get-AzSynapseSqlPoolSensitivityRecommendation -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName
		
		$recommendationsCount = ($recommendations.SensitivityLabels).count
		Assert-AreEqual 4 $recommendationsCount
		
		$firstRecommendation = ($recommendations.SensitivityLabels)[0]
		$firstSchemaName = $firstRecommendation.SchemaName
		$firstTableName = $firstRecommendation.TableName
		$firstColumnName = $firstRecommendation.ColumnName
		$firstInformationType = $firstRecommendation.InformationType
		$firstSensitivityLabel = $firstRecommendation.SensitivityLabel
		#$firstRank = $firstRecommendation.Rank

		Assert-AreEqual "dbo" $firstSchemaName
		Assert-AreEqual "Persons" $firstTableName
		Assert-NotNullOrEmpty $firstColumnName
		Assert-NotNullOrEmpty $firstInformationType
		Assert-NotNullOrEmpty $firstSensitivityLabel
		#Assert-NotNullOrEmpty $firstRank

		$secondRecommendation = ($recommendations.SensitivityLabels)[1]
		$secondSchemaName = $secondRecommendation.SchemaName
		$secondTableName = $secondRecommendation.TableName
		$secondColumnName = $secondRecommendation.ColumnName
		$secondInformationType = $secondRecommendation.InformationType
		$secondSensitivityLabel = $secondRecommendation.SensitivityLabel
		#$secondRank = $secondRecommendation.Rank

		Assert-AreEqual "dbo" $secondSchemaName
		Assert-AreEqual "Persons" $secondTableName
		Assert-NotNullOrEmpty $secondColumnName
		Assert-NotNullOrEmpty $secondInformationType
		Assert-NotNullOrEmpty $secondSensitivityLabel
		#Assert-NotNullOrEmpty $secondRank

		# Set first two sensitivity labels as recommended and verify.
		# Second label is set using pipeline.
		Set-AzSynapseSqlPoolSensitivityClassification -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName -InformationType $firstInformationType -SensitivityLabel $firstSensitivityLabel
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Set-AzSynapseSqlPoolSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName -InformationType $secondInformationType -SensitivityLabel $secondSensitivityLabel

		$allClassifications = Get-AzSynapseSqlPoolSensitivityClassification -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 2 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.workspaceName $allClassifications.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $allClassifications.SqlPoolName
		
		$firstClassification = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityClassification -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName
		Assert-AreEqual 1 ($firstClassification.SensitivityLabels).count
		$classification = ($firstClassification.SensitivityLabels)[0]
		Assert-AreEqual $firstSchemaName $classification.SchemaName
		Assert-AreEqual $firstTableName $classification.TableName
		Assert-AreEqual $firstColumnName $classification.ColumnName
		Assert-AreEqual $firstInformationType $classification.InformationType
		Assert-AreEqual $firstSensitivityLabel $classification.SensitivityLabel
		#Assert-AreEqual $firstRank $classification.Rank

		$secondClassification = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		Assert-AreEqual 1 ($secondClassification.SensitivityLabels).count
		$classification = ($secondClassification.SensitivityLabels)[0]
		Assert-AreEqual $secondSchemaName $classification.SchemaName
		Assert-AreEqual $secondTableName $classification.TableName
		Assert-AreEqual $secondColumnName $classification.ColumnName
		Assert-AreEqual $secondInformationType $classification.InformationType
		Assert-AreEqual $secondSensitivityLabel $classification.SensitivityLabel
		#Assert-AreEqual $secondRank $classification.Rank

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName
		Assert-AreEqual 2 ($recommendations.SensitivityLabels).count

		# Remove second classification and verify
		Remove-AzSynapseSqlPoolSensitivityClassification -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		
		$allClassifications = Get-AzSynapseSqlPoolSensitivityClassification -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 1 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.workspaceName $allClassifications.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $allClassifications.SqlPoolName

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual 3 ($recommendations.SensitivityLabels).count
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName

		# Classify, using pipeline, all recommended columns, and verify.
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation | Set-AzSynapseSqlPoolSensitivityClassification
		
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName
		Assert-AreEqual 0 ($recommendations.SensitivityLabels).count

		$allClassifications = Get-AzSynapseSqlPoolSensitivityClassification -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 4 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.workspaceName $allClassifications.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $allClassifications.SqlPoolName

		# Remove, using pipeline, second classification and verify
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Remove-AzSynapseSqlPoolSensitivityClassification -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName
		
		$allClassifications = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityClassification
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 3 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.workspaceName $allClassifications.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $allClassifications.SqlPoolName

		# Remove, using pipeline, all classifications, and verify.
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityClassification | Remove-AzSynapseSqlPoolSensitivityClassification
		$allClassifications = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityClassification
		$allClassificationsCount = ($allClassifications.SensitivityLabels).count
		Assert-AreEqual 0 $allClassificationsCount
		Assert-AreEqual $params.rgname $allClassifications.ResourceGroupName
		Assert-AreEqual $params.workspaceName $allClassifications.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $allClassifications.SqlPoolName
	}
	finally
	{
		# Cleanup
		Remove-DataClassificationTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Assert the given string is not null or empty
#>
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
			  workspaceName = "dc-ws" +$testSuffix;
			  sqlPoolName = "dcpool" + $testSuffix;
			  storageAccountName = "dccmdletstorage" + $testSuffix;
			  fileSystemName = "dccmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
			  perfLevel = 'DW200c'
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-DataClassificationTestEnvironment ($testSuffix)
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-SqlDataClassificationTestEnvironment ($testSuffix, $location = "eastus")
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	
	New-AzResourceGroup -Name $params.rgname -Location $location

    New-AzStorageAccount -ResourceGroupName $params.rgname -Name $params.storageAccountName -Location $location -SkuName Standard_GRS -Kind StorageV2 -EnableHierarchicalNamespace $true

	$password = $params.pwd
    $secureString = ($password | ConvertTo-SecureString -asPlainText -Force)
    $credentials = new-object System.Management.Automation.PSCredential($params.loginName, $secureString)
    New-AzSynapseWorkspace -ResourceGroupName  $params.rgname -WorkspaceName $params.workspaceName -Location $location -SqlAdministratorLoginCredential $credentials -DefaultDataLakeStorageAccountName $params.storageAccountName -DefaultDataLakeStorageFilesystem $params.fileSystemName
	New-AzSynapseFirewallRule -ResourceGroupName  $params.rgname -WorkspaceName $params.workspaceName -StartIpAddress 0.0.0.0 -EndIpAddress 255.255.255.255 -FirewallRuleName "dcRule"

	# Enable Advanced Data Security
	Enable-AzSynapseSqlAdvancedDataSecurity -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -DoNotConfigureVulnerabilityAssessment

	New-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -PerformanceLevel $params.perfLevel
	
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record")
	{
		$fullWorkspaceName = $params.workspaceName + ".sql.azuresynapse.net"
		$login = $params.loginName
		$sqlPoolName = $params.sqlPoolName

		$connection = New-Object System.Data.SqlClient.SqlConnection
		$connection.ConnectionString = "Server=$fullWorkspaceName;uid=$login;pwd=$password;Database=$sqlPoolName;Integrated Security=False;"
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

<#
.SYNOPSIS
Tests enable and disable recommdations on columns in a SQL pool.
#>
function Test-EnableDisableRecommendationsOnSqlPool
{
	# Setup
	$testSuffix = getAssetName
	Create-SqlDataClassificationTestEnvironment $testSuffix
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix

	try
	{
		# Get recommended sensitivity labels, and verify.
		$recommendations = Get-AzSynapseSqlPoolSensitivityRecommendation -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName

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

		# Disable first two recommdations, second recommdation is disabled using pipeline.
		Disable-AzSynapseSqlPoolSensitivityRecommendation -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -SchemaName $firstSchemaName -TableName $firstTableName -ColumnName $firstColumnName
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Disable-AzSynapseSqlPoolSensitivityRecommendation -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName
		Assert-AreEqual 2 ($recommendations.SensitivityLabels).count

		# Verify disabled recommdations are not part of the new recommdations.
		Assert-AreNotEqual $firstColumnName ($recommendations.SensitivityLabels)[0].ColumnName
		Assert-AreNotEqual $firstColumnName ($recommendations.SensitivityLabels)[1].ColumnName
		Assert-AreNotEqual $secondColumnName ($recommendations.SensitivityLabels)[0].ColumnName
		Assert-AreNotEqual $secondColumnName ($recommendations.SensitivityLabels)[1].ColumnName

		# Enable second disabled recommdation.
		Enable-AzSynapseSqlPoolSensitivityRecommendation -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName

		# Get, using pipeline, recommended sensitivity labels, and verify.
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual 3 ($recommendations.SensitivityLabels).count
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName

		# Verify disabled recommdation is not part of the new recommdations.
		Assert-AreNotEqual $firstColumnName ($recommendations.SensitivityLabels)[0].ColumnName
		Assert-AreNotEqual $firstColumnName ($recommendations.SensitivityLabels)[1].ColumnName
		Assert-AreNotEqual $firstColumnName ($recommendations.SensitivityLabels)[2].ColumnName

		# Disable, using pipeline, all recommended columns.
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation | Disable-AzSynapseSqlPoolSensitivityRecommendation

		# Verify no recommdations are retrieved since all are disabled.
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName
		Assert-AreEqual 0 ($recommendations.SensitivityLabels).count

		# Enable, using pipeline, second disabled recommdation and verify
		Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Enable-AzSynapseSqlPoolSensitivityRecommendation -SchemaName $secondSchemaName -TableName $secondTableName -ColumnName $secondColumnName

		# Verify enabled recommdation is now part of the recommendations.
		$recommendations = Get-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName | Get-AzSynapseSqlPoolSensitivityRecommendation
		Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		Assert-AreEqual $params.workspaceName $recommendations.WorkspaceName
		Assert-AreEqual $params.sqlPoolName $recommendations.SqlPoolName
		Assert-AreEqual 1 ($recommendations.SensitivityLabels).count

		$recommendation = ($recommendations.SensitivityLabels)[0]
		Assert-AreEqual $secondSchemaName $recommendation.SchemaName
		Assert-AreEqual $secondTableName $recommendation.TableName
		Assert-AreEqual $secondColumnName $recommendation.ColumnName
		Assert-NotNullOrEmpty $recommendation.InformationType
		Assert-NotNullOrEmpty $recommendation.SensitivityLabel
	}
	finally
	{
		# Cleanup
		Remove-DataClassificationTestEnvironment $testSuffix
	}
}
