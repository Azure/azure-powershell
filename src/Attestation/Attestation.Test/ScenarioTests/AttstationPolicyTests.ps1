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
Test Get-AzAttestationPolicy
#>
#------------------------------Get-AzAttestationPolicy-----------------------------------
function Test-GetAttestationPolicy
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"
	$teeType = "SgxEnclave"

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location
		Wait-AttestationProviderDns $attestationCreated

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		$getPolicy = Get-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType
		Assert-NotNull $getPolicy.Jwt
		Assert-NotNull $getPolicy.Text
		Assert-AreEqual "none" $getPolicy.Algorithm
		Assert-True { $getPolicy.JwtLength -gt 0 }
		Assert-True { $getPolicy.TextLength -gt 0 }
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

function Test-GetDefaultProviderPolicy
{
	$location = "East US"

	foreach ($teeType in @("SgxEnclave", "TdxVm"))
	{
		$getPolicy = Get-AzAttestationPolicy -DefaultProvider -Location $location -Tee $teeType
		Assert-NotNull $getPolicy.Jwt
		Assert-NotNull $getPolicy.Text
		Assert-AreEqual "none" $getPolicy.Algorithm
		Assert-True { $getPolicy.JwtLength -gt 0 }
		Assert-True { $getPolicy.TextLength -gt 0 }
	}
}

<#
.SYNOPSIS
Test Reset-AzAttestationPolicy
#>
#------------------------------Reset-AzAttestationPolicy-----------------------------------
function Test-ResetAttestationPolicy
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"
	$teeType = "SgxEnclave"
	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location
		Wait-AttestationProviderDns $attestationCreated

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		$getPolicy = Get-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType
		Assert-NotNull $getPolicy
        $resetPolicyResponse = Reset-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType -PassThru
		Assert-AreEqual $resetPolicyResponse $true
	}
	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Set-AzAttestationPolicy
#>
#------------------------------Set-AzAttestationPolicy-----------------------------------
function Test-SetAttestationPolicy
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"
	$teeType = "SgxEnclave"
	$policyText = 'version= 1.0;authorizationrules{c:[type=="$is-debuggable"] => permit();};issuancerules{c:[type=="$is-debuggable"] => issue(type="is-debuggable", value=c.value);c:[type=="$sgx-mrsigner"] => issue(type="sgx-mrsigner", value=c.value);c:[type=="$sgx-mrenclave"] => issue(type="sgx-mrenclave", value=c.value);c:[type=="$product-id"] => issue(type="product-id", value=c.value);c:[type=="$svn"] => issue(type="svn", value=c.value);c:[type=="$tee"] => issue(type="tee", value=c.value);c:[type=="$tee-future"] => issue(type="tee-future", value=c.value);};'
	$policyJwt = New-UnsignedPolicyJwt $policyText
	$genericPolicyText = 'version= 1.0;authorizationrules{=> permit();};issuancerules{};'

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location
		Wait-AttestationProviderDns $attestationCreated

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType -Policy $policyJwt -PolicyFormat Jwt -PassThru
		Assert-AreEqual $setPolicyResponse $true
		$getPolicy = Get-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType
		Assert-AreEqual $policyText $getPolicy.Text

		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType -Policy $policyText -PassThru
		Assert-AreEqual $setPolicyResponse $true

		# TdxVm is only available with the current API version
		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee TdxVm -Policy $genericPolicyText -PassThru
		Assert-AreEqual $setPolicyResponse $true
		$getPolicy = Get-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee TdxVm
		Assert-AreEqual $genericPolicyText $getPolicy.Text

		# VBSEnclave is the earlier name of the Tpm policy
		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee VBSEnclave -Policy $genericPolicyText -PassThru
		Assert-AreEqual $setPolicyResponse $true
		$getPolicy = Get-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee Tpm
		Assert-AreEqual $genericPolicyText $getPolicy.Text
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Set-AzAttestationPolicy with a policy JWT whose policy is not Base64Url encoded, which only the earlier API version accepts
#>
function Test-SetAttestationPolicyLegacyFormats
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"
	# A policy JWT in the earlier format: the policy in the "AttestationPolicy" claim is not Base64Url encoded
	$unencodedPolicyJwt = "eyJhbGciOiJub25lIn0.eyJBdHRlc3RhdGlvblBvbGljeSI6ICJ7XHJcbiAgICBcIiR2ZXJzaW9uXCI6IDEsXHJcbiAgICBcIiRhbGxvdy1kZWJ1Z2dhYmxlXCIgOiB0cnVlLFxyXG4gICAgXCIkY2xhaW1zXCI6W1xyXG4gICAgICAgIFwiaXMtZGVidWdnYWJsZVwiICxcclxuICAgICAgICBcInNneC1tcnNpZ25lclwiLFxyXG4gICAgICAgIFwic2d4LW1yZW5jbGF2ZVwiLFxyXG4gICAgICAgIFwicHJvZHVjdC1pZFwiLFxyXG4gICAgICAgIFwic3ZuXCIsXHJcbiAgICAgICAgXCJ0ZWVcIixcclxuICAgICAgICBcIk5vdERlYnVnZ2FibGVcIlxyXG4gICAgXSxcclxuICAgIFwiTm90RGVidWdnYWJsZVwiOiB7XCJ5ZXNcIjp7XCIkaXMtZGVidWdnYWJsZVwiOnRydWUsIFwiJG1hbmRhdG9yeVwiOnRydWUsIFwiJHZpc2libGVcIjpmYWxzZX19LFxyXG4gICAgXCJpcy1kZWJ1Z2dhYmxlXCIgOiBcIiRpcy1kZWJ1Z2dhYmxlXCIsXHJcbiAgICBcInNneC1tcnNpZ25lclwiIDogXCIkc2d4LW1yc2lnbmVyXCIsXHJcbiAgICBcInNneC1tcmVuY2xhdmVcIiA6IFwiJHNneC1tcmVuY2xhdmVcIixcclxuICAgIFwicHJvZHVjdC1pZFwiIDogXCIkcHJvZHVjdC1pZFwiLFxyXG4gICAgXCJzdm5cIiA6IFwiJHN2blwiLFxyXG4gICAgXCJ0ZWVcIiA6IFwiJHRlZVwiXHJcbn0ifQ."
	$policyText = (ConvertFrom-Base64Url $unencodedPolicyJwt.Split('.')[1] | ConvertFrom-Json).AttestationPolicy

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location
		Wait-AttestationProviderDns $attestationCreated
		Assert-NotNull $attestationCreated

		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee SgxEnclave -Policy $unencodedPolicyJwt -PolicyFormat Jwt -PassThru -WarningVariable warnings
		Assert-AreEqual $setPolicyResponse $true
		Assert-True { $warnings.Count -gt 0 }
		$getPolicy = Get-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee SgxEnclave
		Assert-AreEqual $policyText $getPolicy.Text

		# The earlier API version does not support TdxVm
		Assert-Throws { Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee TdxVm -Policy $unencodedPolicyJwt -PolicyFormat Jwt }
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}