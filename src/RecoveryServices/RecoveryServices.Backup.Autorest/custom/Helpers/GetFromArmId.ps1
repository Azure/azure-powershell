function Get-ContainerNameFromArmId {
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

function Get-SbscriptionIdFromArmId {
	param(
		[System.String]$Id
	)	
	$subscriptionId = (($Id -split "/subscriptions/")[1] -split "/")[0]
	return $subscriptionId
}

function Get-ResourceGroupNameFromArmId {
	param(
		[System.String]$Id
	)	
	$resourceGroupName = (($Id -split "/resourceGroups/")[1] -split "/")[0]
	return $resourceGroupName
}

function Get-VaultNameFromArmId {
	param(
		[System.String]$Id
	)	
	$vaultName = (($Id -split "/vaults/")[1] -split "/")[0]
	return $vaultName
}