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

function Scenerio1-DeleteByName
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$false, Position=0)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.IServerDataServiceContext]
        $Context,

		[Parameter(Mandatory=$false, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ServerName
	)

	if($Context)
	{
		# Delete database by pasing database name
		$database = New-AzureSqlDatabase -Context $context -DatabaseName $Name

		Write-Output "Deleting Database by passing Database Name ..."
		Remove-AzureSqlDatabase $context $database.Name -Force
		Write-Output "Done"
    
		$getDroppedDatabase = Get-AzureSqlDatabase -ConnectionContext $context `
			| Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not dropped"
	}
	elseif ($ServerName)
	{
		$database = New-AzureSqlDatabase -ServerName $ServerName -DatabaseName $Name
    
		######################################################################
		# Delete database by pasing database object
		Write-Output "Deleting Database by passing Database object ..."
		Remove-AzureSqlDatabase -ServerName $Servername $database -Force
		Write-Output "Done"
    
		$getDroppedDatabase = Get-AzureSqlDatabase -ServerName $Servername | Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not dropped"
    
		######################################################################
		# Delete database without specifying -ServerName using db name
		$database = New-AzureSqlDatabase -ServerName $Servername -DatabaseName $Name
		Write-Output "Deleting Database by name without using -ServerName identifier ..."
		Remove-AzureSqlDatabase $Servername $database.Name -Force
		Write-Output "Done"
    
		$getDroppedDatabase = Get-AzureSqlDatabase -ServerName $Servername | Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not dropped"    
	}
}

function Scenerio2-DeleteByObject
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$false, Position=0)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.IServerDataServiceContext]
        $Context,

		[Parameter(Mandatory=$false, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ServerName
	)

	if($Context)
	{
		$database = New-AzureSqlDatabase -Context $context -DatabaseName $Name

		# Delete database by pasing database object
		Write-Output "Deleting Database by passing Database object ..."
		Remove-AzureSqlDatabase $context $database -Force
		Write-Output "Done"
    
		$getDroppedDatabase = Get-AzureSqlDatabase -ConnectionContext $context `
			| Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not dropped"
	}
	elseif ($ServerName)
	{
		$database = New-AzureSqlDatabase -ServerName $ServerName -DatabaseName $Name
    
		######################################################################
		# Delete database by pasing database object
		Write-Output "Deleting Database by passing Database object ..."
		Remove-AzureSqlDatabase -ServerName $Servername $database -Force
		Write-Output "Done"
    
		$getDroppedDatabase = Get-AzureSqlDatabase -ServerName $Servername | Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not dropped"
    
		######################################################################
		# Delete database without specifying -ServerName  using db object
		$database = New-AzureSqlDatabase -ServerName $Servername -DatabaseName $Name
		Write-Output "Deleting Database by name without using -ServerName identifier ..."
		Remove-AzureSqlDatabase $Servername $database -Force
		Write-Output "Done"
    
		$getDroppedDatabase = Get-AzureSqlDatabase -ServerName $Servername | Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not dropped"    
	}
}