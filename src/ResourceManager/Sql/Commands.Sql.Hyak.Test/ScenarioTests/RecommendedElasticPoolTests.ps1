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
    Tests listing all recommended elastic pools for server
#>
function Test-ElasticPoolRecommendation
{
    $response = Get-AzureRmSqlElasticPoolRecommendation -ResourceGroupName TestRg -ServerName test-srv-v1
    Assert-NotNull $response
    Assert-AreEqual 2 $response.Count

    Assert-AreEqual "ElasticPool2" $response[1].Name
    Assert-AreEqual "Standard" $response[1].Edition
    Assert-AreEqual 1000 $response[1].Dtu
    Assert-AreEqual 100 $response[1].DatabaseDtuMin
    Assert-AreEqual 200 $response[1].DatabaseDtuMax
    Assert-AreEqual 0 $response[1].IncludeAllDatabases
    Assert-AreEqual 1 $response[1].DatabaseCollection.Count
    Assert-AreEqual master $response[1].DatabaseCollection[0]
}