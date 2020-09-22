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
	Tests creating a database
#>
function Test-ExportDatabase
{
	# Setup	
    $testSuffix = 90070
    $createServer = $true
    $createDatabase = $true
    $createFirewallRule = $true
    $operationName = "Export"
    $succeeded = $true     
   
    Verify-ImportExport $testSuffix $createServer $createDatabase $createFirewallRule $operationName $succeeded
}

function Test-ImportNewDatabase
{
	# Setup	
    $testSuffix = 90071
    $createServer = $true
    $createDatabase = $false
    $createFirewallRule = $true
    $operationName = "ImportNew"
    $succeeded = $true

    Verify-ImportExport $testSuffix $createServer $createDatabase $createFirewallRule $operationName $succeeded
}

 function Verify-ImportExport($testSuffix, $createServer, $createDatabase, $createFirewallRule, $operationName, $succeeded)
 {
	# Setup	   
    $params = Get-SqlDatabaseImportExportTestEnvironmentParameters  $testSuffix
    $rg = New-AzResourceGroup -Name $params.rgname -Location $params.location
    $export = "Export"
    $importNew = "ImportNew"

	try
	{
        Assert-NotNull $params.storageKey
        Assert-NotNull $params.importBacpacUri
        Assert-NotNull $params.exportBacpacUri

        $password = $params.password
        $secureString = ($password | ConvertTo-SecureString -asPlainText -Force) 
        $credentials = new-object System.Management.Automation.PSCredential($params.userName, $secureString) 	
        if($createServer -eq $true){
            $server = New-AzSqlServer -ResourceGroupName  $params.rgname -ServerName $params.serverName -ServerVersion $params.version -Location $params.location -SqlAdministratorCredentials $credentials       
        }

        if($createDatabase -eq $true){
            $standarddb = New-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
        }
        
        if($createFirewallRule -eq $true){
            New-AzSqlServerFirewallRule -ResourceGroupName  $params.rgname -ServerName $params.serverName -AllowAllAzureIPs
        }

        $operationStatusLink = ""
                
        if($operationName -eq $export){
            # Export database.       
            $exportResponse = New-AzSqlDatabaseExport -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageKeyType $params.storageKeyType -StorageKey $params.storageKey -StorageUri $params.exportBacpacUri -AdministratorLogin $params.userName -AdministratorLoginPassword $secureString -AuthenticationType $params.authType
            Write-Output "Assert-NotNull exportResponse"
            Assert-NotNull $exportResponse
            Write-Output (ConvertTo-Json $exportResponse)
            #$operationStatusLink = $exportResponse.OperationStatusLink
            #Assert-AreEqual $exportResponse.ResourceGroupName $params.rgname
            #Assert-AreEqual $exportResponse.ServerName $params.serverName
            #Assert-AreEqual $exportResponse.DatabaseName $params.databaseName
            #Assert-AreEqual $exportResponse.StorageKeyType $params.storageKeyType
            #Assert-Null $exportResponse.StorageKey
            #Assert-AreEqual $exportResponse.StorageUri $params.exportBacpacUri
            #Assert-AreEqual $exportResponse.AdministratorLogin $params.userName
            #Assert-Null $exportResponse.AdministratorLoginPassword
            #Assert-AreEqual $exportResponse.AuthenticationType $params.authType
        }

        if($operationName -eq $importNew){
            $importResponse = New-AzSqlDatabaseImport -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageKeyType $params.storageKeyType -StorageKey $params.storageKey -StorageUri $params.importBacpacUri -AdministratorLogin $params.userName -AdministratorLoginPassword $secureString -Edition $params.databaseEdition -ServiceObjectiveName $params.serviceObjectiveName -DatabaseMaxSizeBytes $params.databaseMaxSizeBytes -AuthenticationType $params.authType
            Write-Output "Assert-NotNull importResponse"
            Assert-NotNull $importResponse
            Write-Output (ConvertTo-Json $importResponse)
            #$operationStatusLink = $importResponse.OperationStatusLink
            #Assert-AreEqual $importResponse.ResourceGroupName $params.rgname
            #Assert-AreEqual $importResponse.ServerName $params.serverName
            #Assert-AreEqual $importResponse.DatabaseName $params.databaseName
            #Assert-AreEqual $importResponse.StorageKeyType $params.storageKeyType
            #Assert-Null $importResponse.StorageKey
            #Assert-AreEqual $importResponse.StorageUri $params.importBacpacUri
            #Assert-AreEqual $importResponse.AdministratorLogin $params.userName
            #Assert-Null $importResponse.AdministratorLoginPassword
            #Assert-AreEqual $importResponse.AuthenticationType $params.authType
            #Assert-AreEqual $importResponse.Edition $params.databaseEdition
            #Assert-AreEqual $importResponse.ServiceObjectiveName $params.serviceObjectiveName
            #Assert-AreEqual $importResponse.DatabaseMaxSizeBytes $params.databaseMaxSizeBytes
        }
    }
    finally
    {
       Remove-ResourceGroupForTest $rg
    }
}