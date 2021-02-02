
function GetRestoreType {
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
			$allowedValues = $manifest.allowedRestoreModes | Join-String -Separator ', '
			$errormsg = "Specified Restore Mode is not supported for DatasourceType " + $DatasourceType + ". Allowed Values are " + $allowedValues
			throw $errormsg
		}

		if($manifest.allowedRestoreTargetTypes.Contains($RestoreTargetType) -eq $false)
		{
			$allowedValues = $manifest.allowedRestoreTargetTypes | Join-String -Separator ', '
			$errormsg = "Specified Restore Target Type is not supported for DatasourceType " + $DatasourceType + ". Allowed Values are " + $allowedValues
			throw $errormsg
		}
	}
}