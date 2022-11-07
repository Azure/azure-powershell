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
	$teeType = "SgxEnclave"

	$getPolicy = Get-AzAttestationPolicy -DefaultProvider -Location $location -Tee $teeType
	Assert-NotNull $getPolicy.Jwt
	Assert-NotNull $getPolicy.Text
	Assert-AreEqual "none" $getPolicy.Algorithm
	Assert-True { $getPolicy.JwtLength -gt 0 }
	Assert-True { $getPolicy.TextLength -gt 0 }
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
# DO NOT RECORD/PLAYBACK THIS TEST, IT WILL FAIL DUE TO AN EXPIRING JWT TOKEN!
#------------------------------Set-AzAttestationPolicy-----------------------------------
function Test-SetAttestationPolicy
{
	$unknownRGName = getAssetName
	$attestationProviderName = getAssetName
	$location = "East US"
	$teeType = "SgxEnclave"
	$policyJwt = "eyJhbGciOiJub25lIn0.eyJBdHRlc3RhdGlvblBvbGljeSI6ICJ7XHJcbiAgICBcIiR2ZXJzaW9uXCI6IDEsXHJcbiAgICBcIiRhbGxvdy1kZWJ1Z2dhYmxlXCIgOiB0cnVlLFxyXG4gICAgXCIkY2xhaW1zXCI6W1xyXG4gICAgICAgIFwiaXMtZGVidWdnYWJsZVwiICxcclxuICAgICAgICBcInNneC1tcnNpZ25lclwiLFxyXG4gICAgICAgIFwic2d4LW1yZW5jbGF2ZVwiLFxyXG4gICAgICAgIFwicHJvZHVjdC1pZFwiLFxyXG4gICAgICAgIFwic3ZuXCIsXHJcbiAgICAgICAgXCJ0ZWVcIixcclxuICAgICAgICBcIk5vdERlYnVnZ2FibGVcIlxyXG4gICAgXSxcclxuICAgIFwiTm90RGVidWdnYWJsZVwiOiB7XCJ5ZXNcIjp7XCIkaXMtZGVidWdnYWJsZVwiOnRydWUsIFwiJG1hbmRhdG9yeVwiOnRydWUsIFwiJHZpc2libGVcIjpmYWxzZX19LFxyXG4gICAgXCJpcy1kZWJ1Z2dhYmxlXCIgOiBcIiRpcy1kZWJ1Z2dhYmxlXCIsXHJcbiAgICBcInNneC1tcnNpZ25lclwiIDogXCIkc2d4LW1yc2lnbmVyXCIsXHJcbiAgICBcInNneC1tcmVuY2xhdmVcIiA6IFwiJHNneC1tcmVuY2xhdmVcIixcclxuICAgIFwicHJvZHVjdC1pZFwiIDogXCIkcHJvZHVjdC1pZFwiLFxyXG4gICAgXCJzdm5cIiA6IFwiJHN2blwiLFxyXG4gICAgXCJ0ZWVcIiA6IFwiJHRlZVwiXHJcbn0ifQ."
	$policyText = 'version= 1.0;authorizationrules{c:[type=="$is-debuggable"] => permit();};issuancerules{c:[type=="$is-debuggable"] => issue(type="is-debuggable", value=c.value);c:[type=="$sgx-mrsigner"] => issue(type="sgx-mrsigner", value=c.value);c:[type=="$sgx-mrenclave"] => issue(type="sgx-mrenclave", value=c.value);c:[type=="$product-id"] => issue(type="product-id", value=c.value);c:[type=="$svn"] => issue(type="svn", value=c.value);c:[type=="$tee"] => issue(type="tee", value=c.value);c:[type=="$tee-future"] => issue(type="tee-future", value=c.value);};'

	# Prevent this script from inadvertantly running in Record or Playback modes
	try
	{
		if (((Get-ChildItem Env:\HttpRecorderMode).Value -eq "Playback") -or ((Get-ChildItem Env:\HttpRecorderMode).Value -eq "Record"))
		{
			return
		}
	}
	catch
	{
		return
	}

	try
	{
	    $rgName = Create-ResourceGroup
		$attestationCreated = New-AzAttestationProvider -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Location $location

		Assert-NotNull $attestationCreated
		Assert-AreEqual $attestationProviderName $attestationCreated.Name
		Assert-AreEqual $location $attestationCreated.Location
		Assert-NotNull $attestationCreated.AttestUri
		Assert-NotNull $attestationCreated.Id
		Assert-NotNull $attestationCreated.Status

		# NOTE: Set-AzAttestionPolicy does not work in recording/playback mode because the recorded JWT token expires and then fails validation
		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType -Policy $policyJwt -PolicyFormat Jwt -PassThru
		Assert-AreEqual $setPolicyResponse $true

		$setPolicyResponse = Set-AzAttestationPolicy -Name $attestationProviderName -ResourceGroupName $rgName.ResourceGroupName -Tee $teeType -Policy $policyText -PassThru
		Assert-AreEqual $setPolicyResponse $true
	}

	finally
	{
		Clean-ResourceGroup $rgName.ResourceGroupName
	}
}