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

function Scenerio1-CreateWithRequiredParameters
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
		# Create Database with only required parameters
		Write-Output "Creating Database $Name ..."
		$database = New-AzureSqlDatabase -Context $context -DatabaseName $Name
		Write-Output "Done"
		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedEdition $defaultEdition -ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly $defaultIsReadOnly `
			-ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject $defaultIsSystemObject
    
		# Get Database by database name
		$database = Get-AzureSqlDatabase -Context $context -DatabaseName $Name
		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedEdition $defaultEdition -ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly $defaultIsReadOnly `
			-ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject $defaultIsSystemObject
    
		# Get Database by database name
		$database = Get-AzureSqlDatabase $context -DatabaseName $Name
		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedEdition $defaultEdition -ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly $defaultIsReadOnly `
			-ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject $defaultIsSystemObject
    
		# Get Database by database name
		$database = Get-AzureSqlDatabase -ConnectionContext $context -DatabaseName $Name
		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedEdition $defaultEdition -ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly $defaultIsReadOnly `
			-ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject $defaultIsSystemObject
	}
	elseif ($ServerName)
	{
		# Create Database with only required parameters
		Write-Output "Creating Database $Name ..."
		$database = New-AzureSqlDatabase -ServerName $ServerName -DatabaseName $Name
		Write-Output "Done"

		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedEdition $defaultEdition -ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly `
			$defaultIsReadOnly -ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject `
			$defaultIsSystemObject

		# Get Database by database name
		$database = Get-AzureSqlDatabase -ServerName $ServerName -DatabaseName $Name

		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedEdition $defaultEdition -ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly `
			$defaultIsReadOnly -ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject `
			$defaultIsSystemObject
			
		$database = Get-AzureSqlDatabase $ServerName -DatabaseName $Name

		Validate-SqlDatabase -Actual $database -ExpectedName $Name -ExpectedCollationName $defaultCollation `
			-ExpectedMaxSizeGB $defaultMaxSizeGB -ExpectedIsReadOnly $defaultIsReadOnly `
			-ExpectedEdition $defaultEdition -ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject `
			$defaultIsSystemObject
	}
}

function Scenerio2-CreateWithOptionalParameters
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
    
	$Name = $Name + "1"

	if($Context)
	{
		# Create Database with all optional parameters
		Write-Output "Creating Database $Name ..."
		$database2 = New-AzureSqlDatabase $context $Name -Collation $defaultCollation -Edition "Business" `
				-MaxSizeGB 20 -Force
		Write-Output "Done"
    
		Validate-SqlDatabase -Actual $database2 -ExpectedName $Name -ExpectedCollationName $defaultCollation `
				-ExpectedEdition "Business" -ExpectedMaxSizeGB "20" -ExpectedIsReadOnly $defaultIsReadOnly `
				-ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject $defaultIsSystemObject

		# Get Database by database object
		$database2 = Get-AzureSqlDatabase -Context $context -Database $database2
		Validate-SqlDatabase -Actual $database2 -ExpectedName $Name -ExpectedCollationName $defaultCollation `
				-ExpectedEdition "Business" -ExpectedMaxSizeGB "20" -ExpectedIsReadOnly $defaultIsReadOnly `
				-ExpectedIsFederationRoot $defaultIsFederationRoot -ExpectedIsSystemObject $defaultIsSystemObject
            
		# Get Databases with no filter
		$databases = Get-AzureSqlDatabase -Context $context | Where-Object {$_.Name.StartsWith($NameStartWith)}
		Assert {$databases.Count -eq 2} "Get database should have returned 2 database, but returned $databases.Count"
	}
	elseif ($ServerName)
	{
		# Create Database with all optional parameters
		Write-Output "Creating Database $Name ..."
		$database2 = New-AzureSqlDatabase -ServerName $ServerName $Name -Collation `
			"SQL_Latin1_General_CP1_CS_AS" -Edition "Business" -MaxSizeGB 20 -Force
		Write-Output "Done"
    
		Validate-SqlDatabase -Actual $database2 -ExpectedName $Name -ExpectedCollationName `
			"SQL_Latin1_General_CP1_CS_AS" -ExpectedEdition "Business" -ExpectedMaxSizeGB "20" `
			-ExpectedIsReadOnly $defaultIsReadOnly -ExpectedIsFederationRoot $defaultIsFederationRoot `
			-ExpectedIsSystemObject $defaultIsSystemObject

		$database2 = Get-AzureSqlDatabase -ServerName $ServerName -Database $database2
			
		# Get Database by database object
		Validate-SqlDatabase -Actual $database2 -ExpectedName $Name -ExpectedCollationName `
			"SQL_Latin1_General_CP1_CS_AS" -ExpectedEdition "Business" -ExpectedMaxSizeGB "20" `
			-ExpectedIsReadOnly $defaultIsReadOnly -ExpectedIsFederationRoot $defaultIsFederationRoot `
			-ExpectedIsSystemObject $defaultIsSystemObject
			
		# Get Databases with no filter
		$databases = (Get-AzureSqlDatabase -ServerName $ServerName) | `
			Where-Object {$_.Name.StartsWith($NameStartWith)}
		$count = $databases.Count

		Assert {$count -eq 2} "Get database should have returned 2 database, but returned $count"
	}
}
