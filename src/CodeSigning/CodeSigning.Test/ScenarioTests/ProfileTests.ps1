function Test-NewProfile {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$profileName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Basic'

	try {
		#act
		$sut = New-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName `
			-ProfileType 'PublicTrust' -IdentityValidationId '00000000-1234-5678-3333-444444444444'
		
		#assert
		Assert-NotNullOrEmpty $sut
		Assert-AreEqual $sut.ProfileName $profileName
		Assert-AreEqual $sut.ProfileType 'PublicTrust'
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}


function Test-GetProfile {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$profileName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Basic'
	New-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName `
		-ProfileType 'PublicTrust' -IdentityValidationId '00000000-1234-5678-3333-444444444444'

	try {
		#act
		$sut = Get-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName
		#assert
		Assert-NotNullOrEmpty $sut
		Assert-AreEqual $sut.ProfileName $profileName
		Assert-AreEqual $sut.ProfileType 'PublicTrust'
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-RemoveProfile {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$profileName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Basic'
	New-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName `
		-ProfileType 'PublicTrust' -IdentityValidationId '00000000-1234-5678-3333-444444444444'

	try {
		#act
		Remove-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName
		$sut = Get-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName

		#assert
		Assert-Null $sut
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

Function Test-ListProfile {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$profileName = getRandomItemName
	$profileName2 = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Premium'
	New-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName `
		-ProfileType 'PublicTrust' -IdentityValidationId '00000000-1234-5678-3333-444444444444'
	New-CertificateProfile -AccountName $accountName -ProfileName $profileName2 -ResourceGroupName $rgName `
		-ProfileType 'PublicTrust' -IdentityValidationId '00000000-1234-5678-3333-444444444444'

	try {
		#act
		$sut = Get-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName
		#assert
		Assert-NotNullOrEmpty $sut
		Assert-True { $sut.Count -eq 2 }
		Assert-True { $profileName -in $sut.ProfileName }
		Assert-True { $profileName2 -in $sut.ProfileName }
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-RevokeProfile {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$profileName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Basic'
	$profile = New-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName `
		-ProfileType 'PublicTrust' -IdentityValidationId '00000000-1234-5678-3333-444444444444'
	$certificate = $profile.Certificates


	try {
		#act
		$sut = Revoke-CertificateProfile -AccountName $accountName -ProfileName $profileName -ResourceGroupName $rgName `
			-EffectiveAt (Get-Date) -Reason 'KeyCompromise' -SerialNumber $certificate.SerialNumber `
			-Thumbprint $certificate.Thumbprint -Remarks 'Test'
		
		#assert
		Assert-True $sut
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}