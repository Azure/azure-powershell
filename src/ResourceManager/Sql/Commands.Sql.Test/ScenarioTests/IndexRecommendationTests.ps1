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
    Tests getting index recommendations
#>
function Test-GetIndexRecommendations
{
    # Get all recommended indexes for server
    $response = Get-AzureRmSqlDatabaseIndexRecommendations -ResourceGroup Group-6 -ServerName witest-eus
    ValidateResponse($response)
    Assert-AreEqual "Active" $response[0].State

    # Get all recommended indexes for database
    $response = Get-AzureRmSqlDatabaseIndexRecommendations -ResourceGroup Group-6 -ServerName witest-eus -DatabaseName witestdb-eus
    ValidateResponse($response)
    Assert-AreEqual "Active" $response[0].State

    # Get recommended indexes by name
    $response = Get-AzureRmSqlDatabaseIndexRecommendations -ResourceGroup Group-6 -ServerName witest-eus -DatabaseName witestdb-eus -IndexRecommendationName nci_wi_Clusters_034590D0-0378-4AB9-96D5-C144B14F6A9B
    ValidateResponse($response)
    Assert-AreEqual "Active" $response[0].State
}

<#
    .SYNOPSIS
    Tests starting and canceling index operation
#>
function Test-CreateIndex
{
    # Start index operation
    $response = Start-AzureRmSqlDatabaseExecuteIndexRecommendation -ResourceGroup Group-6 -ServerName witest-eus -DatabaseName witestdb-eus -IndexRecommendationName nci_wi_Clusters_034590D0-0378-4AB9-96D5-C144B14F6A9B    
    Assert-AreEqual "Pending" $response[0].State

    # Start index operation
    $response = Stop-AzureRmSqlDatabaseExecuteIndexRecommendation -ResourceGroup Group-6 -ServerName witest-eus -DatabaseName witestdb-eus -IndexRecommendationName nci_wi_Clusters_034590D0-0378-4AB9-96D5-C144B14F6A9B
    Assert-AreEqual "Active" $response[0].State
}

function ValidateResponse($response) 
{
    Assert-NotNull $response
    Assert-AreEqual 1 $response.Count        
    Assert-AreEqual "nci_wi_Clusters_034590D0-0378-4AB9-96D5-C144B14F6A9B" $response[0].Name
    Assert-AreEqual "Create" $response[0].Action
    Assert-AreEqual '07/21/2015 17:12:32' $response[0].Created
    Assert-AreEqual "NONCLUSTERED" $response[0].IndexType
    Assert-AreEqual '07/21/2015 17:12:32' $response[0].LastModified
    Assert-AreEqual "dbo" $response[0].Schema    
    Assert-AreEqual "Clusters" $response[0].Table
}