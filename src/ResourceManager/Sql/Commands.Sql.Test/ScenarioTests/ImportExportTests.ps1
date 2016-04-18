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
    $testSuffix = 90063
    $createServer = $true
    $createDatabase = $true
    $createFirewallRule = $true
    $operationName = "Export"
    $succeeded = $true     
   
    Verify-ImportExport $testSuffix $createServer $createDatabase $createFirewallRule $operationName $succeeded
}

function Test-ImportDatabase
{
	# Setup	
    $testSuffix = 90062
    $createServer = $true
    $createDatabase = $false
    $createFirewallRule = $true
    $operationName = "Import"
    $succeeded = $true

    Verify-ImportExport $testSuffix $createServer $createDatabase $createFirewallRule $operationName $succeeded
}

 function Verify-ImportExport($testSuffix, $createServer, $createDatabase, $createFirewallRule, $operationName, $succeeded)
 {
	# Setup	   
    $params = Get-SqlDatabaseImportExportTestEnvironmentParameters  $testSuffix
    $rg = New-AzureRmResourceGroup -Name $params.rgname -Location $params.location
    $export = "Export"
    $import = "Import"

	try
	{       
        Assert-NotNull $params.storageKey
        Assert-NotNull $params.importBacpacUri
        Assert-NotNull $params.exportBacpacUri

        $password = $params.password
        $secureString = ($password | ConvertTo-SecureString -asPlainText -Force) 
        $credentials = new-object System.Management.Automation.PSCredential($params.userName, $secureString) 	
        if($createServer -eq $true){
            $server = New-AzureRmSqlServer -ResourceGroupName  $params.rgname -ServerName $params.serverName -ServerVersion $params.version -Location $params.location -SqlAdministratorCredentials $credentials       
        }

        if($createDatabase -eq $true){
            $standarddb = New-AzureRmSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
        }
        
        if($createFirewallRule -eq $true){
            New-AzureRmSqlServerFirewallRule -ResourceGroupName  $params.rgname -ServerName $params.serverName -AllowAllAzureIPs
        }

        $operationStatusLink = ""
                
        if($operationName -eq $export){
            # Export database.       
            $exportResponse = New-AzureRmSqlDatabaseExport -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageKeyType $params.storageKeyType -StorageKey $params.storageKey -StorageUri $params.exportBacpacUri -AdministratorLogin $params.userName -AdministratorLoginPassword $secureString -AuthenticationType Sql
            Assert-NotNull $exportResponse
            $operationStatusLink = $exportResponse.OperationStatusLink            
        }

        if($operationName -eq $import){
            $importResponse = New-AzureRmSqlDatabaseImport -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageKeyType $params.storageKeyType -StorageKey $params.storageKey -StorageUri $params.importBacpacUri -AdministratorLogin $params.userName -AdministratorLoginPassword $secureString -Edition Standard -ServiceObjectiveName S0 -DatabaseMaxSize 5000000 -AuthenticationType Sql
            Assert-NotNull $importResponse
            $operationStatusLink = $importResponse.OperationStatusLink
        }
		
        Assert-NotNull $operationStatusLink		

        #Get status
        $statusInProgress = "InProgress"
        $statusSucceeded = "Succeeded"
        $status = "InProgress"

        if($succeeded -eq $true){
            Write-Output "Getting Status" 
            while($status -eq $statusInProgress){
                $statusResponse = Get-AzureRmSqlDatabaseImportExportStatus -OperationStatusLink $operationStatusLink
                Write-Output "Import Export Status Message:" + $statusResponse.StatusMessage           
                $status = $statusResponse.Status
            }
            Assert-AreEqual $status $statusSucceeded
            Write-Output "ImportExportStatus:" + $status 
        }      
    }
    finally
    {
       Remove-ResourceGroupForTest $rg
    }
}