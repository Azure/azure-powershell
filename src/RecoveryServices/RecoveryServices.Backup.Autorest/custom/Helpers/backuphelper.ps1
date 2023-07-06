function Get-containerNameFromArmId {
	param(
		[System.String]$Id
	)	
	$containerName = (($Id -split "protectionContainers/")[1] -split "/")[0]
	return $containerName

}

function Get-ProtectableItemNameFromArmId {
	param(
		[System.String]$Id
	)	
	$ItemName = (($Id -split "protectableItems/")[1] -split "/")[0]
	return $ItemName

}

function Get-ProtectedItemNameFromArmId {
	param(
		[System.String]$Id
	)	
	$ItemName = (($Id -split "protectedItems/")[1] -split "/")[0]
	return $ItemName

}	