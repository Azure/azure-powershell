function Test-AddAzManagedHsmKey {
	Param(
		[parameter(Mandatory=$true)]
		[String]
		$hsmName,
		[parameter(Mandatory=$true)]
		[String]
		$keyName,
		[parameter(Mandatory=$true)]
		[String]
		$keyType,
		[parameter(Mandatory=$false)]
		[String]
		$curveName
	)
	if($keyType -eq "EC" || $keyType -eq "EC-HSM"){
		Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType -CurveName $curveName
	}
	else {
		Add-AzManagedHsmKey -HsmName $hsmName -Name $keyName -KeyType $keyType
	}
}
