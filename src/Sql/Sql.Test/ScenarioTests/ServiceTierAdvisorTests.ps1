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
    Tests getting database upgrade hints
#>
function Test-GetUpgradeDatabaseHint
{
    $response = Get-AzureRmSqlDatabaseUpgradeHint -ResourceGroupName TestRg -ServerName test-srv-v1
    Assert-NotNull $response
    Assert-AreEqual 1 $response.Count
    Assert-AreEqual test-db-v1 $response[0].Name
    Assert-AreEqual Premium $response[0].TargetEdition
    Assert-AreEqual P2 $response[0].TargetServiceLevelObjective

    $response = Get-AzureRmSqlDatabaseUpgradeHint -ResourceGroupName TestRg -ServerName test-srv-v1 -DatabaseName test-db-v1 
    Assert-NotNull $response
    Assert-AreEqual 1 $response.Count
    Assert-AreEqual test-db-v1 $response[0].Name
    Assert-AreEqual Standard $response[0].TargetEdition
    Assert-AreEqual S0 $response[0].TargetServiceLevelObjective

    $response = Get-AzureRmSqlDatabaseUpgradeHint -ResourceGroupName TestRg -ServerName test-srv-v1 -ExcludeElasticPoolCandidates 1
    Assert-NotNull $response
    Assert-AreEqual 1 $response.Count
    Assert-AreEqual test-db-v1 $response[0].Name
    Assert-AreEqual Premium $response[0].TargetEdition
    Assert-AreEqual P2 $response[0].TargetServiceLevelObjective

    $response = Get-AzureRmSqlDatabaseUpgradeHint -ResourceGroupName TestRg -ServerName test-srv-v1 -DatabaseName test-db-v1 -ExcludeElasticPoolCandidates 1
    Assert-NotNull $response
     Assert-AreEqual 1 $response.Count
    Assert-AreEqual test-db-v1 $response[0].Name
    Assert-AreEqual Standard $response[0].TargetEdition
    Assert-AreEqual S0 $response[0].TargetServiceLevelObjective
}

<# 
    .SYNOPSIS
    Tests getting server upgrade hint
#>
function Test-GetUpgradeServerHint
{
    $response = Get-AzureRmSqlServerUpgradeHint -ResourceGroupName TestRg -ServerName test-srv-v1
    Assert-NotNull $response
    Assert-AreEqual 1 $response.Databases.Count
    Assert-AreEqual test-db-v1 $response.Databases[0].Name
    Assert-AreEqual Standard $response.Databases[0].TargetEdition
    Assert-AreEqual S0 $response.Databases[0].TargetServiceLevelObjective

    $response = Get-AzureRmSqlServerUpgradeHint -ResourceGroupName TestRg -ServerName test-srv-v1 -ExcludeElasticPools 1
    Assert-NotNull $response
    Assert-AreEqual 1 $response.Databases.Count
    Assert-AreEqual test-db-v1 $response.Databases[0].Name
    Assert-AreEqual Standard $response.Databases[0].TargetEdition
    Assert-AreEqual S0 $response.Databases[0].TargetServiceLevelObjective
}