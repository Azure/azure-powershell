function Test-NewAccount {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location

	try {
		#act
		$sut = New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Basic'
		$sutPremium = New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Premium'
		
		#assert
		Assert-NotNullOrEmpty $sut
		Assert-AreEqual $sut.AccountName $accountName
		Assert-AreEqual $sut.Location $location
		Assert-AreEqual $sut.Sku 'Basic'

		Assert-NotNullOrEmpty $sutPremium
		Assert-AreEqual $sutPremium.AccountName $accountName
		Assert-AreEqual $sutPremium.Location $location
		Assert-AreEqual $sutPremium.Sku 'Premium'
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-GetAccount {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$location = 'eastus'
	$sku = 'Basic'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku $sku

	try {
		#act
		$sut = Get-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName
		
		#assert
		Assert-NotNullOrEmpty $sut
		Assert-AreEqual $sut.AccountName $accountName
		Assert-AreEqual $sut.Location $location
		Assert-AreEqual $sut.Sku $sku
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-RemoveAccount {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$location = 'eastus'
	$sku = 'Basic'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku $sku

	try {
		#act
		Remove-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName
		$sut = Get-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName
		
		#assert
		Assert-Null $sut
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-ListAccount {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$accountName2 = getRandomItemName
	$location = 'eastus'
	$sku = 'Basic'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku $sku
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName2 -Location $location -Sku $sku

	try {
		#act
		$sut = Get-CodesigningAccount -ResourceGroupName $rgName
		
		#assert
		Assert-NotNull $sut
		Assert-True { $sut.Count -eq 2 }
		Assert-True { $accountName -in $sut.AccountName }
		Assert-True { $accountName2 -in $sut.AccountName }
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-AccountAvailable {
	# arrange
	$subscription = Get-SubscriptionID
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	try	{
		#act
		$sut = Test-CodesigningAccountNameAvailability -AccountName $accountName -SubscriptionID $subscription
		
		#assert
		Assert-NotNullOrEmpty $sut
		Assert-True $sut.NameAvailable
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-AccountNotAvailable {
	# arrange
	$subscription = Get-SubscriptionID
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$location = 'eastus'
	$sku = 'Basic'
	
	New-AzResourceGroup -Name $rgName -Location $location
	try	{
		#act
		New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku $sku
		$sut = Test-CodesigningAccountNameAvailability -AccountName $accountName -SubscriptionID $subscription
		
		# assert
		Assert-NotNullOrEmpty $sut
		Assert-False $sut.NameAvailable
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}

function Test-UpdateAccountSku {
	# arrange
	$rgName = getRandomItemName
	$accountName = getRandomItemName
	$location = 'eastus'
	
	New-AzResourceGroup -Name $rgName -Location $location
	New-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Location $location -Sku 'Basic'
	
	try {
		#act
		$sut = Update-CodesigningAccount -ResourceGroupName $rgName -AccountName $accountName -Sku 'Premium'
		
		Assert-NotNullOrEmpty $sut
		Assert-AreEqual $sut.AccountName $accountName
		Assert-AreEqual $sut.Location $location
		Assert-AreEqual $sut.Sku 'Premium'
	}
	finally {
		#cleanup
		Remove-AzResourceGroup -Name $rgName -Force
	}
}