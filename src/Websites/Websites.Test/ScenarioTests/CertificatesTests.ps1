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
Tests creating a new managed cert for app.
#>
function Test-NewAzWebAppManagedCertificate
{
	$rgname = "RG-W-CUS"
	$appname = "managedcerts"
	$slot = "testslot"
	$prodHostname = "www.managedcerts.net"
	$slotHostname = "testslot.adorenow.net"
	$thumbprint=""

	try{		

		$cert=New-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $prodHostname
		$thumbprint=$cert.ThumbPrint

		# Assert
		Assert-AreEqual $prodHostname $cert.SubjectName		
	
	}
	finally{
		
		# Cleanup
		Remove-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $prodHostname -ThumbPrint $thumbprint
	}
}

<#
.SYNOPSIS
Tests creating a new managed cert for app with SSL binding.
#>
function Test-NewAzWebAppManagedCertificateWithSSLBinding
{
	$rgname = "RG-W-CUS"
	$appname = "managedcerts"
	$slot = "testslot"
	$prodHostname = "www.managedcerts.net"
	$slotHostname = "testslot.adorenow.net"
	$thumbprint=""

	try{		

		$cert=New-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $prodHostname -AddCertBinding
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
		Remove-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $prodHostname -ThumbPrint $thumbprint
	}
}

<#
.SYNOPSIS
Tests creating a new managed certfor slot.
#>
function Test-NewAzWebAppManagedCertificateForSlot
{

	$rgname = "RG-W-CUS"
	$appname = "managedcerts"
	$slot = "sit"	
	$slotHostname = "www.managedcerts1.org"
	$thumbprint=""

	try{
		
		$cert=New-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $slotHostname -Slot $slot
		$thumbprint=$cert.ThumbPrint
		
		# Assert
		Assert-AreEqual $slotHostname $cert.SubjectName
	
	}
	finally{
	
		# Cleanup
		Remove-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $slotHostname -Slot $slot -ThumbPrint $thumbprint
	}
}

<#
.SYNOPSIS
Tests removing a managed cert.
#>
function Test-RemoveAzWebAppManagedCertificate
{

	$rgname = "RG-W-CUS"
	$appname = "managedcerts"	
	$prodHostname = "www.managedcerts.net"	
	$thumbprint=""

	try{		

		$cert=New-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $prodHostname
		$thumbprint=$cert.ThumbPrint

		# Assert
		Assert-AreEqual $prodHostname $cert.SubjectName	
		
		Remove-AzWebAppManagedCertificate -ResourceGroupName $rgname -WebAppName $appname -HostName $prodHostname -ThumbPrint $thumbprint

		$certificate = Get-AzWebAppCertificate -Thumbprint $thumbprint
		
		#Assert
		$certificate.count -eq 0
	
	}
	finally{
	
	}
}