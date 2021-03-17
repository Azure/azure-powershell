function AddFilterToQuery {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Query,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FilterKey,

		[Parameter(Mandatory=$true)]
        [System.String[]]
        $FilterValues
	)
	
	process{

		if(($FilterValues -ne $null) -and ($FilterValues.Length -ne 0))
		{
			$updatedQuery = $Query
			$filterValueJoin = [System.String]::Join("','", $FilterValues)
			$updatedQuery += " | where " + $FilterKey + " in~ ('" + $filterValueJoin + "')"
			return $updatedQuery
		}

		return $Query
	}
}

function CheckResourceGraphModuleDependency
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param() 

	process
	{
		$module = Get-InstalledModule | Where-Object {$_.Name -eq "Az.ResourceGraph"}
		if($module -eq $null)
		{
			$message = "Az.ResourceGraph Module must be installed to run this command. Please run 'Install-Module -Name Az.ResourceGraph' to install and continue."
			throw $message
		}
	}
}

function GetBackupInstanceARGQuery
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param()

	process
	{
		$query = "RecoveryServicesResources | where type =~ 'microsoft.dataprotection/backupvaults/backupinstances'"
		$query += "| extend vaultName = split(split(id, '/Microsoft.DataProtection/backupVaults/')[1],'/')[0]"
		$query += "| extend protectionState = properties.currentProtectionState"

		return $query
	}
}

function GetBackupJobARGQuery
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param()

	process
	{
		$query = "RecoveryServicesResources | where type =~ 'microsoft.dataprotection/backupvaults/backupjobs'"
		$query += "| extend vaultName = properties.vaultName"
		$query += "| extend status = properties.status"
		$query += "| extend operation = case( tolower(properties.operationCategory) startswith 'backup' and properties.isUserTriggered == 'true', strcat('OnDemand',properties.operationCategory)"
		$query += ", tolower(properties.operationCategory) startswith 'backup' and properties.isUserTriggered == 'false', strcat('Scheduled', properties.operationCategory)"
		$query += ", type =~ 'microsoft.dataprotection/backupVaults/backupJobs', properties.operationCategory, 'Invalid')"

		return $query
	}
}