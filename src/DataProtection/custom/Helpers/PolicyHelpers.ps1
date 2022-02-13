
function GetBackupFrequencyString {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency]
		$frequency,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.Int32]
		$count
	)

	process {
		$freq = $frequency.ToString()
		if($freq -eq "Weekly")
		{
			return "P1W"
		}

		if($freq -eq "Daily")
		{
			return "P1D"
		}

		if($freq -eq "Hourly")
		{
			return "PT" + $count.ToString() + "H"
		}
	}
}

function GetTaggingPriority {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$Name
	)

	process{
		$priorityMap = @{"Default"=99;"Daily"=25;"Weekly"=20;"Monthly"=15;"Yearly"=10}
		return $priorityMap[$Name]
	}
}

function ValidateBackupSchedule
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String[]]
		$Schedule
	)

	process
	{
		$manifest = LoadManifest -DatasourceType $DatasourceType
		if($manifest.policySettings.backupScheduleSupported -eq $false)
		{
			$message = "Adding Backup Schedule is not supported for Datasource Type " + $DatasourceType
			throw $message
		}

		$backupFrequencyMap = @{"D"="Daily";"H"="Hourly";"W"="Weekly"}
		if($manifest.policySettings.supportedBackupFrequency.Contains($backupFrequencyMap[$Schedule[0][-1].ToString()]) -eq $false)
		{
			$message = $backupFrequencyMap[$Schedule[0][-1].ToString()] + " Backup Schedule is not supported for Datasource Type " + $DatasourceType
			throw $message
		}
	}
}

function GetBackupFrequenceFromTimeInterval
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String[]]
		$RepeatingTimeInterval
	)

	process
	{
		$backupFrequencyMap = @{"D"="Daily";"H"="Hourly";"W"="Weekly"}
		return "Backup" + $backupFrequencyMap[$RepeatingTimeInterval[0][-1].ToString()]
	}
}