
function Test-CosmosDbRestoreResourceIdentifier {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter()]
		[AllowNull()]
		[AllowEmptyCollection()]
		[System.String[]]
		$ResourceIdentifier
	)

	if ($null -eq $ResourceIdentifier -or $ResourceIdentifier.Count -eq 0) {
		throw "Please provide at least one ResourceIdentifier for AzureCosmosDB. Use database or database/container identifiers."
	}
	if ($ResourceIdentifier.Count -gt 50) {
		throw "AzureCosmosDB supports at most 50 ResourceIdentifier entries per restore request."
	}

	# Cosmos resource names are case-sensitive. Never normalize names or expand
	# databases using the current source inventory instead of the recovery point.
	$seen = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
	$databases = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
	$containerDatabases = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
	for ($index = 0; $index -lt $ResourceIdentifier.Count; $index++) {
		$identifier = $ResourceIdentifier[$index]
		if ([string]::IsNullOrWhiteSpace($identifier) -or $identifier -match '[\\?#\p{Cc}]') {
			throw "ResourceIdentifier at index $index is invalid. Use a literal database or database/container identifier."
		}
		$segments = $identifier.Split('/')
		if ($segments.Count -gt 2 -or @($segments | Where-Object { [string]::IsNullOrWhiteSpace($_) }).Count -gt 0) {
			throw "ResourceIdentifier '$identifier' is invalid. Use database or database/container with no empty segments."
		}
		if (-not $seen.Add($identifier)) {
			throw "ResourceIdentifier '$identifier' is specified more than once. Remove exact duplicate identifiers."
		}
		if ($segments.Count -eq 1) {
			if ($containerDatabases.Contains($identifier)) {
				throw "ResourceIdentifier '$identifier' overlaps a selected container in that database. Select either the database or its containers."
			}
			$null = $databases.Add($identifier)
		}
		else {
			if ($databases.Contains($segments[0])) {
				throw "ResourceIdentifier '$identifier' overlaps the selected database '$($segments[0])'. Select either the database or its containers."
			}
			$null = $containerDatabases.Add($segments[0])
		}
	}
}

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
        $ItemLevelRecovery,

		[Parameter(Mandatory=$false)]        
        [System.String]
        $SecretStoreURI
	)

	process
	{
		Write-Debug "Validating Restore Options"
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
			$errormsg = "Specified DatasourceType " + $DatasourceType + " doesn't support item level recovery"
			throw $errormsg
		}
		
		#  if RestoreAsFiles and itemLevelRecovey passed together
		if(($RestoreTargetType -eq "RestoreAsFiles") -and $ItemLevelRecovery){
			$errormsg = "RestoreType RestoreAsFiles doesn't support item level recovery"
			throw $errormsg
		}

		if(($RestoreTargetType -eq "RestoreAsFiles") -and ($SecretStoreURI -ne $null) -and ($SecretStoreURI -ne "")){
			$errormsg = "RestoreType RestoreAsFiles doesn't support secret store authentication"
			throw $errormsg
		}
	}
}