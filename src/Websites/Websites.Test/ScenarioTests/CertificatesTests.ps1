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
#Global variables
$rgname = "RG-PS-UnitTesting"
$appname = "AppService-PS-UnitTesting"
$certName = "psunittesting"
$prodHostname = "psunittesting.com"	
$slot = "testslot"	
$slotHostname = "testslot.psunittesting.com"
$thumbprint=""
$wname = "PS-AppServices-UnitTesting"
$keyvaultname =	"PS-UnitTesting-Keyvault"
$keyvaultcertname =	"psunittesting9d3d0603-5c4a-4414-a6e6-8ed93f5dde71"
<#
.SYNOPSIS
Tests creating a new managed cert for app.
#>
function Test-NewAzWebAppCertificate
{
	$rgname = "RG-PS-UnitTesting"
	$appname = "AppService-PS-UnitTesting"
	$certName = "psunittesting"
	$prodHostname = "psunittesting.com"	
	$thumbprint=""

	try{		

		$cert=New-AzWebAppCertificate -ResourceGroupName $rgname -Name $certName -WebAppName $appname -HostName $prodHostname
		$thumbprint=$cert.ThumbPrint

		# Assert
		Assert-AreEqual $prodHostname $cert.SubjectName		
	
	}
	finally{
		
		# Cleanup
		Remove-AzWebAppCertificate -ResourceGroupName $rgname -ThumbPrint $thumbprint
	}
}

<#
.SYNOPSIS
Tests creating a new managed cert for app with SSL binding.
#>
function Test-NewAzWebAppCertificateWithSSLBinding
{
	try{		

		$cert=New-AzWebAppCertificate -ResourceGroupName $rgname -Name $certName -WebAppName $appname -HostName $prodHostname -AddBinding
		$thumbprint=$cert.ThumbPrint

		# Assert
		Assert-AreEqual $prodHostname $cert.SubjectName		

		#Assert
		$getResult = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname
		Assert-AreEqual 1 $getResult.Count
		$currentHostNames = $getResult | Select -expand Name
		Assert-True { $currentHostNames -contains $prodHostname }
		$getResult = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname
		Assert-AreEqual $getResult.Name $prodHostname
	
	}
	finally{
		
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzWebAppCertificate -ResourceGroupName $rgname -ThumbPrint $thumbprint
	}
}

<#
.SYNOPSIS
Tests creating a new managed certfor slot.
#>
function Test-NewAzWebAppCertificateForSlot
{

	try{
		
		$cert=New-AzWebAppCertificate -ResourceGroupName $rgname -Name $certName -WebAppName $appname -HostName $slotHostname -Slot $slot
		$thumbprint=$cert.ThumbPrint
		
		# Assert
		Assert-AreEqual $slotHostname $cert.SubjectName
	
	}
	finally{
	
		# Cleanup
		Remove-AzWebAppCertificate -ResourceGroupName $rgname -ThumbPrint $thumbprint
	}
}

<#
.SYNOPSIS
Tests removing a managed cert.
#>
function Test-RemoveAzWebAppCertificate
{
	try{		

		$cert=New-AzWebAppCertificate -ResourceGroupName $rgname -Name $certName -WebAppName $appname -HostName $prodHostname
		$thumbprint=$cert.ThumbPrint

		# Assert
		Assert-AreEqual $prodHostname $cert.SubjectName	
		
		Remove-AzWebAppCertificate -ResourceGroupName $rgname -ThumbPrint $thumbprint

		$certificate = Get-AzWebAppCertificate -ResourceGroupName $rgname -Thumbprint $thumbprint
		
		#Assert
		$certificate.count -eq 0
	
	}
	finally{
	
	}
}

<#
.SYNOPSIS
Tests for importing a keyvaultcertificate to appservice
#>
function Test-ImportAzWebAppKeyVaultCertificate
{
	try
	{		
		#Setup
		$kvcert = Import-AzWebAppKeyVaultCertificate -ResourceGroupName $rgname -WebAppName $wname -KeyVaultName $keyvaultname -CertName $keyvaultcertname
		$default_webapp_certname= $keyvaultname+'-'+$keyvaultcertname
		# Assert
		Assert-AreEqual $kvcert.Name $default_webapp_certname	
	
	}
	finally{

	}
}