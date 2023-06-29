function Get-containerName {
	param(
		[System.String]$Id
	)	
	$containerName = (($Id -split "protectionContainers/")[1] -split "/")[0]
	return $containerName

}

function Get-ItemName {
	param(
		[System.String]$Id
	)	
	$ItemName = (($Id -split "protectableItems/")[1] -split "/")[0]
	return $ItemName

}
	