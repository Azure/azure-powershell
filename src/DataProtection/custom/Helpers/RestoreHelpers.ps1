﻿
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
		elseif($type -eq "PointInTimeBased"){
			return "AzureBackupRecoveryTimeBasedRestoreRequest"
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
        $RestoreTargetType,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.Boolean]
        $ItemLevelRecovery
	)

	process
	{
		Write-Debug -Message $DatasourceType
		Write-Debug -Message $RestoreMode
		Write-Debug -Message $RestoreTargetType
		Write-Debug -Message $ItemLevelRecovery

		$manifest = LoadManifest -DatasourceType $DatasourceType
		if($manifest.allowedRestoreModes.Contains($RestoreMode) -eq $false)
		{
			$allowedValues = [System.String]::Join(', ', $manifest.allowedRestoreModes)
			$errormsg = "Specified RecoveryPoint type is not supported for DatasourceType " + $DatasourceType
			throw $errormsg
		}
		
		if($manifest.allowedRestoreTargetTypes.Contains($RestoreTargetType) -eq $false)
		{
			$allowedValues = [System.String]::Join(', ', $manifest.allowedRestoreTargetTypes)
			$errormsg = "Specified RestoreType is not supported for DatasourceType " + $DatasourceType + ". Allowed Values are " + $allowedValues
			throw $errormsg
		}

		if(!($manifest.itemLevelRecoveyEnabled) -and $ItemLevelRecovery){
			$errormsg = "Specified DatasourceType " + $DatasourceType + " doesn't support Item Level Recovery"
			throw $errormsg
		}		
	}
}