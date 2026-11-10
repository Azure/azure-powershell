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
Creates a unique name for a resource group
#>
function Get-ResourceGroupName
{
    return getAssetName
}


<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
      Remove-AzResourceGroup -Name $rgname -Force
}

<#
.SYNOPSIS
Creates a new resource group
#>
function Create-ResourceGroup
{
	$resourceGroupName = Get-ResourceGroupName
	return New-AzResourceGroup -Name $resourceGroupName -Location WestUS
}

<#
.SYNOPSIS
Waits until the host name of a new attestation provider resolves, which can take a few minutes after it is created
#>
function Wait-AttestationProviderDns($attestationProvider, [int]$timeoutSeconds = 300)
{
	$hostName = ([Uri]$attestationProvider.AttestUri).Host
	$deadline = (Get-Date).AddSeconds($timeoutSeconds)
	while ($true)
	{
		try
		{
			[System.Net.Dns]::GetHostAddresses($hostName) | Out-Null
			return
		}
		catch
		{
			if ((Get-Date) -gt $deadline)
			{
				throw "Host name $hostName of attestation provider $($attestationProvider.Name) did not resolve within $timeoutSeconds seconds."
			}
			Start-TestSleep -Seconds 10
		}
	}
}

<#
.SYNOPSIS
Base64Url encodes text or bytes
#>
function ConvertTo-Base64Url($value)
{
	$bytes = if ($value -is [byte[]]) { $value } else { [System.Text.Encoding]::UTF8.GetBytes([string]$value) }
	return [Convert]::ToBase64String($bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_')
}

<#
.SYNOPSIS
Decodes Base64Url text
#>
function ConvertFrom-Base64Url([string]$value)
{
	$base64 = $value.Replace('-', '+').Replace('_', '/')
	$base64 = $base64.PadRight($base64.Length + (4 - $base64.Length % 4) % 4, '=')
	return [System.Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($base64))
}

<#
.SYNOPSIS
Creates an unsigned policy JWT whose "AttestationPolicy" claim holds the Base64Url encoded policy
#>
function New-UnsignedPolicyJwt([string]$policyText)
{
	$header = ConvertTo-Base64Url '{"alg":"none"}'
	$body = ConvertTo-Base64Url (@{ AttestationPolicy = (ConvertTo-Base64Url $policyText) } | ConvertTo-Json -Compress)
	return "$header.$body."
}

<#
.SYNOPSIS
Creates an RSA key and a self-signed certificate for signing policy management tokens
#>
function New-PolicySigningCertificate([string]$subject)
{
	$key = [System.Security.Cryptography.RSA]::Create(2048)
	$request = [System.Security.Cryptography.X509Certificates.CertificateRequest]::new("CN=$subject", $key, [System.Security.Cryptography.HashAlgorithmName]::SHA256, [System.Security.Cryptography.RSASignaturePadding]::Pkcs1)
	$certificate = $request.CreateSelfSigned([DateTimeOffset]::UtcNow.AddDays(-1), [DateTimeOffset]::UtcNow.AddDays(30))
	return [pscustomobject]@{ Key = $key; Certificate = $certificate }
}

<#
.SYNOPSIS
Writes a certificate as a PEM file
#>
function Export-PemCertificate($certificate, [string]$path)
{
	$base64 = [Convert]::ToBase64String($certificate.RawData, [Base64FormattingOptions]::InsertLineBreaks)
	Set-Content -Path $path -Value "-----BEGIN CERTIFICATE-----`n$base64`n-----END CERTIFICATE-----"
}

<#
.SYNOPSIS
Creates a policy management token: a JWT signed by an existing policy signer whose body names a certificate
in the given claim ("policyCertificate", or "maa-policyCertificate" for the earlier API version)
#>
function New-PolicyCertificateJwt($signer, $certificateToChange, [string]$claimName = "policyCertificate")
{
	$header = ConvertTo-Base64Url (@{ alg = "RS256"; x5c = @([Convert]::ToBase64String($signer.Certificate.RawData)) } | ConvertTo-Json -Compress)
	$jwk = @{ kty = "RSA"; x5c = @([Convert]::ToBase64String($certificateToChange.RawData)) }
	$body = ConvertTo-Base64Url (@{ $claimName = $jwk } | ConvertTo-Json -Compress -Depth 5)
	$signature = $signer.Key.SignData([System.Text.Encoding]::ASCII.GetBytes("$header.$body"), [System.Security.Cryptography.HashAlgorithmName]::SHA256, [System.Security.Cryptography.RSASignaturePadding]::Pkcs1)
	return "$header.$body.$(ConvertTo-Base64Url $signature)"
}

