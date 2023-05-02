# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Test Get-AzAttestationPolicySigners
#>
#------------------------------Get-AzAttestationPolicySigners-----------------------------------
function Test-GetAttestationPolicySigners
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location -PolicySigningCertificateKeyPath .\SamplePolicySignerFiles\cert1.pem

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		$policySigners = Get-AzAttestationPolicySigners -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName
		Assert-NotNull $policySigners
		Assert-AreEqual $policySigners.CertificateCount 1
		Assert-NotNull $policySigners.Jwt
		Assert-NotNull $policySigners.Certificates
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

function Test-GetDefaultProviderPolicySigners
{
	$location = "East US"
	   
	$policySigners = Get-AzAttestationPolicySigners -DefaultProvider -Location $location
	Assert-NotNull $policySigners
	Assert-AreEqual $policySigners.CertificateCount 0
	Assert-NotNull $policySigners.Jwt
	Assert-NotNull $policySigners.Certificates
}

<#
.SYNOPSIS
Test Add-AzAttestationPolicySigner
#>
#-------------------------------Add-AzAttestationPolicySigner-----------------------------------
function Test-AddAttestationPolicySigner
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location -PolicySigningCertificateKeyPath .\SamplePolicySignerFiles\cert1.pem

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		$signer = Get-Content -Path .\SamplePolicySignerFiles\cert2.signed.txt
		$policySigners = Add-AzAttestationPolicySigner -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Signer $signer
		Assert-NotNull $policySigners
		Assert-AreEqual $policySigners.CertificateCount 2
		Assert-NotNull $policySigners.Jwt
		Assert-NotNull $policySigners.Certificates
	}
	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Remove-AzAttestationPolicySigner
#>
#------------------------------Remove-AzAttestationPolicySigner-----------------------------------
function Test-RemoveAttestationPolicySigner
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location -PolicySigningCertificateKeyPath .\SamplePolicySignerFiles\cert1.pem

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		$signer = Get-Content -Path .\SamplePolicySignerFiles\cert2.signed.txt
		$policySigners = Add-AzAttestationPolicySigner -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Signer $signer
		Assert-NotNull $policySigners
		Assert-AreEqual $policySigners.CertificateCount 2
		Assert-NotNull $policySigners.Jwt
		Assert-NotNull $policySigners.Certificates

		$policySigners = Remove-AzAttestationPolicySigner -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Signer $signer
		Assert-NotNull $policySigners
		Assert-AreEqual $policySigners.CertificateCount 1
		Assert-NotNull $policySigners.Jwt
		Assert-NotNull $policySigners.Certificates
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}