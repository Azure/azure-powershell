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


########################################
## Manage IotDps Certificate Cmdlets  ##
########################################

<#
.SYNOPSIS
Test Iot Hub Device Provisioning Service Certificate cmdlets for CRUD operations 
#>

function Test-AzureIotDpsCertificateLifeCycle
{
	$Location = Get-Location "Microsoft.Devices" "Device Provisioning Service" 
	$IotDpsName = getAssetName 
	$ResourceGroupName = getAssetName 
	$TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;

	# Constant variable
	$certificatePath = "$TestOutputRoot\rootCertificate.cer"
	$verifyCertificatePath = "$TestOutputRoot\verifyCertificate.cer"
	$certificateSubject = "CN=TestCertificate"
	$certificateType = "Microsoft.Devices/provisioningServices/Certificates"
	$certificateName = "TestCertificate"

	# Create or Update Resource Group
	$resourceGroup = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub Device Provisioning Service
	$iotDps = New-AzureRmIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -Location $Location
	Assert-True { $iotDps.Name -eq $IotDpsName }

	# Add certificate to Iot Hub Device Provisioning Service
	New-CARootCert $certificateSubject $certificatePath
	$newCertificate = Add-AzureRmIoTDpsCertificate -ResourceGroupName $ResourceGroupName -Name $IotDpsName -CertificateName $certificateName -Path $certificatePath
	Assert-True { $newCertificate.Properties.Subject -eq $certificateSubject }
	Assert-False { $newCertificate.Properties.IsVerified }
	Assert-True { $newCertificate.Type -eq $certificateType }
	Assert-True { $newCertificate.CertificateName -eq $certificateName }

	# List all certificates in Iot Hub Device Provisioning Service
	$certificates = Get-AzureRmIoTDpsCertificate -ResourceGroupName $ResourceGroupName -Name $IotDpsName
	Assert-True { $certificates.Count -gt 0}

	# Get certificate from Iot Hub Device Provisioning Service
	$certificate = Get-AzureRmIoTDpsCertificate -ResourceGroupName $ResourceGroupName -Name $IotDpsName -CertificateName $certificateName
	Assert-True { $certificate.Properties.Subject -eq $certificateSubject }
	Assert-False { $certificate.Properties.IsVerified }
	Assert-True { $certificate.Type -eq $certificateType }
	Assert-True { $certificate.CertificateName -eq $certificateName }

	# Generate Verification Code
	$certificateWithVerificationCode = Get-AzureRmIoTDpsCertificate -ResourceGroupName $ResourceGroupName -Name $IotDpsName -CertificateName $certificateName | New-AzureRmIotDpsCVC
	Assert-True { $certificateWithVerificationCode.Properties.Subject -eq $certificateSubject }
	Assert-NotNull { $certificateWithVerificationCode.Properties.VerificationCode }

	# Proof-of-Possession
	New-CAVerificationCert $certificateWithVerificationCode.Properties.VerificationCode $certificateSubject $verifyCertificatePath
	$verifiedCertificate = Get-AzureRmIoTDpsCertificate -ResourceGroupName $ResourceGroupName -Name $IotDpsName -CertificateName $certificateName | Set-AzureRmIotDpsCertificate -Path $verifyCertificatePath
	Assert-True { $verifiedCertificate.Properties.Subject -eq $certificateSubject }
	Assert-True { $verifiedCertificate.Properties.IsVerified }
	Assert-True { $verifiedCertificate.Type -eq $certificateType }
	Assert-True { $verifiedCertificate.CertificateName -eq $certificateName }

	# Remove Certificate from Iot Hub Device Provisioning Service
	$result = Get-AzureRmIoTDpsCertificate -ResourceGroupName $ResourceGroupName -Name $IotDpsName -CertificateName $certificateName | Remove-AzureRmIotDpsCertificate -PassThru
	Assert-True { $result }

	# Remove Resource Group
	Remove-AzureRmResourceGroup -Name $ResourceGroupName -force
}


<#
.SYNOPSIS
Get a certificate from the cert store
#>
function Get-CACertBySubjectName([string]$subjectName)
{
    $certificates = gci -Recurse Cert:\LocalMachine\ |? { $_.gettype().name -eq "X509Certificate2" }
    $cert = $certificates |? { $_.subject -eq $subjectName -and $_.PSParentPath -eq "Microsoft.PowerShell.Security\Certificate::LocalMachine\My" }
    if ($NULL -eq $cert)
    {
        throw ("Unable to find certificate with subjectName {0}" -f $subjectName)
    }

    write $cert[0]
}

<#
.SYNOPSIS
Creates a self signed certificate and stores it in a local computer
#>
function New-CASelfsignedCertificate([string]$subjectName, [object]$signingCert, [bool]$isASigner=$true)
{
	# Build up argument list
	$selfSignedArgs = @{"-DnsName"=$subjectName; 
		                "-CertStoreLocation"="cert:\LocalMachine\My";
	                    "-NotAfter"=(get-date).AddDays(30); 
						}

	if ($isASigner -eq $true)
	{
		$selfSignedArgs += @{"-KeyUsage"="CertSign"; }
		$selfSignedArgs += @{"-TextExtension"= @(("2.5.29.19={text}ca=TRUE&pathlength=12")); }
	}
	else
	{
		$selfSignedArgs += @{"-TextExtension"= @("2.5.29.37={text}1.3.6.1.5.5.7.3.2,1.3.6.1.5.5.7.3.1", "2.5.29.19={text}ca=FALSE&pathlength=0")  }
	}

	if ($signingCert -ne $null)
	{
		$selfSignedArgs += @{"-Signer"=$signingCert }
	}

	if ($useEcc -eq $true)
	{
		$selfSignedArgs += @{"-KeyAlgorithm"="ECDSA_nistP256";
                      "-CurveExport"="CurveName" }
	}

	write (New-SelfSignedCertificate @selfSignedArgs)
}

<#
.SYNOPSIS
Creates a base certificate
#>
function New-CARootCert([string]$subjectName, [string]$requestedFileName)
{
	$certificate = New-CASelfsignedCertificate $subjectName 
	Export-Certificate -cert $certificate -filePath $requestedFileName -Type Cert
	if (-not (Test-Path $requestedFileName))
    {
        throw ("Error: CERT file {0} doesn't exist" -f $requestedFileName)
    }
}

<#
.SYNOPSIS
Creates a child certificate signed by a root certificate
#>
function New-CAVerificationCert([string]$requestedSubjectName, [string]$_rootCertSubject, [string]$verifyRequestedFileName)
{
    $cnRequestedSubjectName = ("CN={0}" -f $requestedSubjectName)
    $rootCACert = Get-CACertBySubjectName $_rootCertSubject
	$verifyCert = New-CASelfsignedCertificate $cnRequestedSubjectName $rootCACert $false
	Export-Certificate -cert $verifyCert -filePath $verifyRequestedFileName -Type Cert
    if (-not (Test-Path $verifyRequestedFileName))
    {
        throw ("Error: CERT file {0} doesn't exist" -f $verifyRequestedFileName)
    }

	# Cleaning Cert Store
	Get-ChildItem ("Cert:\LocalMachine\My\{0}" -f $rootCACert.Thumbprint) | Remove-Item
	Get-ChildItem ("Cert:\LocalMachine\My\{0}" -f $verifyCert.Thumbprint) | Remove-Item
}
