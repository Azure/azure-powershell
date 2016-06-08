# ----------------------------------------------------------------------------------
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

function TestImportWithRequestObject
{
    ####################################################
    # Import Database
    
    $status = $null
    
    ###########
    # Test the first parameter set

    $BlobName = $DatabaseName1 + ".bacpac"
    $dbName = $DatabaseName1 + "-import1"
    Write-Output "Importing from Blob: $BlobName"

    $Request = Start-AzureSqlDatabaseImport -SqlConnectionContext $context -StorageContainer $container `
        -DatabaseName $dbName -BlobName $BlobName
    Assert {$Request} "Failed to initiate the first import opertaion"
    $id = ($Request.RequestGuid)
    Write-Output "Request Id for import1: $id"

    GetOperationStatus $Request
    
    # Make sure that the database was indeed imported
    $importedDatabase = Get-AzureSqlDatabase -ConnectionContext $context -DatabaseName $dbName
    Assert {$importedDatabase} "The database was not properly imported"
}

function TestImportCommandHelper
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [ValidateNotNullOrEmpty()]
        [scriptblock]
        $Command
    )

    $Request = & $Command
    $Request = $Request[0]
    
    Assert {$Request} "Failed to initiate the import operation"
    $id = ($Request.RequestGuid)
    Write-Output "Request Id for import: $id"

    GetOperationStatus $Request
        
    # Make sure that the database was indeed imported
    $importedDatabase = Get-AzureSqlDatabase -ConnectionContext $context -DatabaseName $dbName
    Assert {$importedDatabase} "The database was not properly imported"
}

function TestImportWithRequestObjectAndOptionalParameters
{
    ####################################################
    # Import Database
    $status = $null
    
    ###########
    # Test Import with optional parameters
    
    $BlobName = $DatabaseName1 + ".bacpac"
    Write-Output "Importing from Blob: $BlobName"
    
    Write-Output "Running test for import with optional edition parameter"
    $dbName = $DatabaseName1 + "Options-edition"
    Write-Output "Database name: $dbName"
    TestImportCommandHelper `
        { Start-AzureSqlDatabaseImport -SqlConnectionContext $context -StorageContainer $container `
                -DatabaseName $dbName -BlobName $BlobName -Edition "Business" }
                
    Write-Output "Running test for import with optional size parameter"
    $dbName = $DatabaseName1 + "Options-size"
    Write-Output "Database name: $dbName"
    TestImportCommandHelper `
        { Start-AzureSqlDatabaseImport -SqlConnectionContext $context -StorageContainer $container `
                -DatabaseName $dbName -BlobName $BlobName -DatabaseMaxSize 5 }
                
    Write-Output "Running test for import with optional edition and size parameter"
    $dbName = $DatabaseName1 + "Options-edition"
    Write-Output "Database name: $dbName"
    TestImportCommandHelper `
        { Start-AzureSqlDatabaseImport -SqlConnectionContext $context -StorageContainer $container `
                -DatabaseName $dbName -BlobName $BlobName -Edition "Business" -DatabaseMaxSize 20 }
}

function TestImportWithRequestId
{
    ###########
    # Test the second parameter set

    $BlobName2 = $DatabaseName2 + ".bacpac"
    $dbName = $DatabaseName2 + "-import3"
    Write-Output "Importing from Blob: $BlobName2"

    $Request = Start-AzureSqlDatabaseImport -SqlConnectionContext $context -StorageContext $StgCtx `
        -StorageContainerName $ContainerName -DatabaseName $dbName -BlobName $BlobName2
    Assert {$Request} "Failed to initiate the third import opertaion"
    $id = ($Request.RequestGuid)
    Write-Output "Request Id for Import: $id"
    
    GetOperationStatusWithRequestId $Request.RequestGuid $server.ServerName $Username $Password
    
    # Make sure that the database was indeed imported
    $importedDatabase = Get-AzureSqlDatabase -ConnectionContext $context -DatabaseName $dbName
    Assert {$importedDatabase} "The database was not properly imported"
}