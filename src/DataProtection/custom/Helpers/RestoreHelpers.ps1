
function GetRestoreType {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreRequestType]
        $RestoreType
	)

	process {
		$type = $RestoreType.ToString()
		if($type -eq "RecoveryPointBased"){
			return "AzureBackupRecoveryPointBasedRestoreRequest"
		}
	}
}

function ValidateRestoreOptions {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DatasourceType,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $RestoreMode,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $RestoreTargetType
	)

	process
	{
		$manifest = LoadManifest -DatasourceType $DatasourceType
		if($manifest.allowedRestoreModes.Contains($RestoreMode) -eq $false)
		{
			$allowedValues = [System.String]::Join(', ', $manifest.allowedRestoreModes)
			$errormsg = "Specified Restore Mode is not supported for DatasourceType " + $DatasourceType
			throw $errormsg
		}

		if($manifest.allowedRestoreTargetTypes.Contains($RestoreTargetType) -eq $false)
		{
			$allowedValues = [System.String]::Join(', ', $manifest.allowedRestoreTargetTypes)
			$errormsg = "Specified Restore Target Type is not supported for DatasourceType " + $DatasourceType + ". Allowed Values are " + $allowedValues
			throw $errormsg
		}
	}
}