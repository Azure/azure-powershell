# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http:#www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

function Scenario1-UpdateWithObject
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
	
	$edition = "Business"
	$maxSizeGB = "10"

	Write-Output "Starting Test Scenario 1"

	if($Context)
	{
		Write-Output "Updating Database $Name edition to $edition and maxSizeGB to $maxSizeGB ..."
		Set-AzureSqlDatabase $context $database -Edition $edition -MaxSizeGB $maxSizeGB -Force
		Write-Output "Done"

		$updatedDatabase = Get-AzureSqlDatabase $context -DatabaseName $database.Name
		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $database.Name -ExpectedCollationName `
			$database.CollationName -ExpectedEdition $edition -ExpectedMaxSizeGB $maxSizeGB -ExpectedIsReadOnly `
			$database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot -ExpectedIsSystemObject `
			$database.IsSystemObject "S1-Context $context"
	}
	elseif ($serverName)
	{
		Write-Output "Updating Database $Name edition to $edition and maxSizeGB to $maxSizeGB ..."
		Set-AzureSqlDatabase -ServerName $ServerName $database -Edition $edition -MaxSizeGB $maxSizeGB -Force
		Write-Output "Done"

		$updatedDatabase = Get-AzureSqlDatabase -ServerName $ServerName -DatabaseName $database.Name
		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $database.Name -ExpectedCollationName `
			$database.CollationName -ExpectedEdition $edition -ExpectedMaxSizeGB $maxSizeGB -ExpectedIsReadOnly `
			$database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot -ExpectedIsSystemObject `
			$database.IsSystemObject "S1-ServerName"
	}
}

function Scenario2-UpdateWithName
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
	
	$edition = "Web"
	$maxSizeGB = "5"
	
	Write-Output "Starting Test Scenario 2"

	if($Context)
	{
		Write-Output "Updating Database $Name edition Back to $edition ..."
		Set-AzureSqlDatabase $context $database.Name -Edition $edition -MaxSizeGB $maxSizeGB -Force
		Write-Output "Done"

		$updatedDatabase = Get-AzureSqlDatabase $context -Database $database
		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $database.Name -ExpectedCollationName `
				$database.CollationName -ExpectedEdition $edition -ExpectedMaxSizeGB $maxSizeGB -ExpectedIsReadOnly `
				$database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot -ExpectedIsSystemObject `
				$database.IsSystemObject "S2-Context $context"
	}
	elseif ($serverName)
	{
		Write-Output "Updating Database $Name edition Back to $edition ..."
		Set-AzureSqlDatabase -ServerName $ServerName $database.Name -Edition $edition -MaxSizeGB $maxSizeGB -Force
		Write-Output "Done"

		$updatedDatabase = Get-AzureSqlDatabase -ServerName $ServerName -Database $database
		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $database.Name -ExpectedCollationName `
			$database.CollationName -ExpectedEdition $edition -ExpectedMaxSizeGB $maxSizeGB -ExpectedIsReadOnly `
			$database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot -ExpectedIsSystemObject `
			$database.IsSystemObject "S2-ServerName"
	}
}

function Scenario3-RenameDatabase
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
	
	Write-Output "Starting Test Scenario 3"

	$NewName = $Name + "-updated"

	if($Context)
	{
		Write-Output "Renaming a database from $Name to $NewName..."
		$updatedDatabase = Set-AzureSqlDatabase $context $database -NewName $NewName -PassThru -Force
		Write-Output "Done"

		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $NewName -ExpectedCollationName `
				$database.CollationName -ExpectedEdition $database.Edition -ExpectedMaxSizeGB $database.MaxSizeGB `
				-ExpectedIsReadOnly $database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot `
				-ExpectedIsSystemObject $database.IsSystemObject "S3-Context-1 $context"

		$updatedDatabase = Get-AzureSqlDatabase $context -DatabaseName $NewName
		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $NewName -ExpectedCollationName `
				$database.CollationName -ExpectedEdition $database.Edition -ExpectedMaxSizeGB $database.MaxSizeGB `
				-ExpectedIsReadOnly $database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot `
				-ExpectedIsSystemObject $database.IsSystemObject "S3-Context-2 $context"
    
		$database = Get-AzureSqlDatabase $context | Where-Object {$_.Name -eq $Name}
		Assert {!$getDroppedDatabase} "Database is not Renamed"
	}
	elseif ($serverName)
	{
		Write-Output "Renaming a database from $Name to $NewName..."
		$updatedDatabase = Set-AzureSqlDatabase -ServerName $ServerName $database -NewName $NewName -PassThru -Force
		Write-Output "Done"

		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $NewName -ExpectedCollationName `
			$database.CollationName -ExpectedEdition $database.Edition -ExpectedMaxSizeGB $database.MaxSizeGB `
			-ExpectedIsReadOnly $database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot `
			-ExpectedIsSystemObject $database.IsSystemObject  "S3-ServerName-1"

		$updatedDatabase = Get-AzureSqlDatabase -ServerName $ServerName -DatabaseName $NewName
		Validate-SqlDatabase -Actual $updatedDatabase -ExpectedName $NewName -ExpectedCollationName `
			$database.CollationName -ExpectedEdition $database.Edition -ExpectedMaxSizeGB $database.MaxSizeGB `
			-ExpectedIsReadOnly $database.IsReadOnly -ExpectedIsFederationRoot $database.IsFederationRoot `
			-ExpectedIsSystemObject $database.IsSystemObject  "S3-ServerName-2"
	}
}