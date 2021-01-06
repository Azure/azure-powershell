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

function Test-RestoreFromNewAccountCmdlets
{
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup27"
  $location = "West US"
  $restoreTimestampInUtc = "2020-08-07T16:36:49+0000"
  $cosmosDBAccountName = "restored-continuous-db2121-1"
  $sourceCosmosDBAccountName = "continuous-db2121"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";

  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName  
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId

  Assert-NotNull $sourceRestorableAccount.Id
  Assert-NotNull $sourceRestorableAccount.Location
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountInstanceId
  Assert-AreEqual $sourceRestorableAccount.DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountName
  Assert-NotNull $sourceRestorableAccount.CreationTime

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -RestoreSourceId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore
 
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName
  
}

function Test-RestoreAccountCmdlets
{
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup27"
  $location = "West US"
  $restoreTimestampInUtc = "2020-08-07T16:36:49+0000"
  $cosmosDBAccountName = "restored2-continuous-db2121-2"
  $sourceCosmosDBAccountName = "continuous-db2121"
  $databaseName = "TestDB1";

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName
}