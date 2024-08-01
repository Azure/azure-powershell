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
.Synopsis
Create a hive catalog configured as a Trino cluster.
.Description
Create a hive catalog configured as a Trino cluster.
.Example
$catalogName="{your catalog name}"
$metastoreDbConnectionURL="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=truetrustServerCertificate=true;loginTimeout=30;"
$metastoreDbUserName="{your db user name}"
$metastoreDbPasswordSecret="{secretName}"
$metastoreWarehouseDir="abfs://{your container name}@{your adls gen2 endpoint}/{your path}"

New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName $catalogName -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastoreDbPasswordSecret
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHiveCatalogOption
.Link
https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksTrinoHiveCatalogObject
#>
function New-AzHdInsightOnAksTrinoHiveCatalogObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHiveCatalogOption])]
    [CmdletBinding(DefaultParameterSetName = 'Create', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # Name of trino catalog which should use specified hive metastore.
        ${CatalogName},

        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # Connection string for hive metastore database.
        ${MetastoreDbConnectionUrl},
        
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # User name for hive metastore database.
        ${MetastoreDbConnectionUserName},

        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # Password secret for hive metastore database.
        ${MetastoreDbConnectionPasswordSecret},
        
        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # Warehouse directory for hive metastore database.
        ${MetastoreWarehouseDir}
    )
    process {
        try {
            $trinoHiveCatalogOption = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.HiveCatalogOption -Property `
            @{CatalogName                           = $CatalogName;
                MetastoreDbConnectionUrl            = $MetastoreDbConnectionUrl;
                MetastoreDbConnectionUserName       = $MetastoreDbConnectionUserName;
                MetastoreDbConnectionPasswordSecret = $MetastoreDbConnectionPasswordSecret;
                MetastoreWarehouseDir               = $MetastoreWarehouseDir
            }
            return $trinoHiveCatalogOption
        }
        catch {
            throw
        }
    }
}