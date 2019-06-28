<#
.SYNOPSIS
Test New-AzAttestation
#>
#------------------------------Create-AzAttestation-----------------------------------
function Test-CreateAttestation
{
	$unknownRGName = getAssetName
	$attestationName = getAssetName
    $attestationPolicy = "SgxDisableDebugMode"

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestation -Name $attestationName -ResourceGroupName $rgName.ResourceGroupName -AttestationPolicy $attestationPolicy
		
		Assert-NotNull attestationCreated
		Assert-AreEqual $attestationName $attestationCreated.Name
		Assert-NotNull attestationCreated.AttesUri
		Assert-NotNull attestationCreated.Id
		Assert-NotNull attestationCreated.Status
		
		# Test throws for existing attestation
		Assert-Throws { New-AzAttestation -Name $attestationName  -ResourceGroupName $rgName.ResourceGroupName -AttestationPolicy $attestationPolicy}

		# Test throws for resourcegroup nonexistent
		Assert-Throws { New-AzAttestation -Name $attestationName -ResourceGroupName $unknownRGName -AttestationPolicy $attestationPolicy}
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Get-AzAttestation
#>
#------------------------------Get-AzAttestation-----------------------------------
function Test-GetAttestation
{	
	$attestationName = getAssetName
	$attestationPolicy = "SgxDisableDebugMode"
	try
	{
	    $rgName = Create-ResourceGroup
		New-AzAttestation -Name $attestationName -ResourceGroupName $rgName.ResourceGroupName -AttestationPolicy $attestationPolicy

		$got = Get-AzAttestation  -Name $attestationName  -ResourceGroupName $rgName.ResourceGroupName
		Assert-NotNull got
		Assert-AreEqual $attestationName $got.Name
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Remove-AzAttestation
#>
#------------------------------Remove-AzAttestation-----------------------------------
function Test-DeleteAttestationByName
{
	$attestationName = getAssetName
	$attestationPolicy = "SgxDisableDebugMode"
	try
	{
		$rgName = Create-ResourceGroup
		New-AzAttestation -Name $attestationName -ResourceGroupName $rgName.ResourceGroupName -AttestationPolicy $attestationPolicy
		Remove-AzAttestation  -Name $attestationName  -ResourceGroupName $rgName.ResourceGroupName -Force
		$deletedAttestation= Get-AzAttestation  -Name $attestationName  -ResourceGroupName $rgName.ResourceGroupName
		Assert-Null $deletedAttestation
	}
	
	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}