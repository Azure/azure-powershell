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

<# If you want to run these tests live then create a Basic/Standard/Premium web app, 
assign a custom domain to it and update global variable values.
#>

#Global variables
$rgname = "webappsslbindingrb"
$appname = "webappsslbindingtest"
$slot = "testslot"
$prodHostname = "www.webappsslbindingtests.com"
$slotHostname = "testslot.webappsslbindingtests.com"
$thumbprint = "40D6600B0B8740C41BA4B3D13B967DDEF6ED1918"

<#
.SYNOPSIS
Tests creating a new Web App SSL binding.
#>
function Test-CreateNewWebAppSSLBinding
{
	try
	{
		# Test - Create Ssl binding for web app
		$createResult = New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		Assert-AreEqual $prodHostname $createResult.Name

		# Test - Create Ssl binding for web app slot
		$createResult = New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint
		Assert-AreEqual $slotHostname $createResult.Name
	}
    finally
    {
		# Cleanup
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
    }
}

<#
.SYNOPSIS
Tests retrieving Web App SSL binding.
#>
function Test-GetNewWebAppSSLBinding
{
	try
	{
		# Setup - Create Ssl bindings
		$createWebAppResult = New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		$createWebAppSlotResult = New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint

		# Test - Get commands for web app
		$getResult = Get-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname
		Assert-AreEqual 2 $getResult.Count
		$currentHostNames = $getResult | Select -expand Name
		Assert-True { $currentHostNames -contains $createWebAppResult.Name }
		$getResult = Get-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname
		Assert-AreEqual $getResult.Name $createWebAppResult.Name

		# Test - Get commands for web app slot
		$getResult = Get-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot
		Assert-AreEqual 1 $getResult.Count
		$currentHostNames = $getResult | Select -expand Name
		Assert-True { $currentHostNames -contains $createWebAppSlotResult.Name }
		$getResult = Get-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname
		Assert-AreEqual $getResult.Name $createWebAppSlotResult.Name
	}
    finally
    {
		# Cleanup
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
    }
}

<#
.SYNOPSIS
Tests removing Web App SSL binding.
#>
function Test-RemoveNewWebAppSSLBinding
{
	try
	{
		# Setup - Create Ssl bindings
		New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint

		# Tests - Removing binding from web app and web app slot
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 

		# Assert
		$res = Get-AzureRMWebAppSSLBinding  -ResourceGroupName $rgname -WebAppName  $appname
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $prodHostname }

		$res = Get-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $slotHostName }
	}
    finally
    {
		# Cleanup
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
    }
}

<#
.SYNOPSIS
Tests executing Ssl binding cmdlets using pipe
#>
function Test-WebAppSSLBindingPipeSupport
{
	try
	{
		# Setup - Retrieve web app and web app slot objects
		$webapp = Get-AzureRMWebApp  -ResourceGroupName $rgname -Name  $appname
		$webappslot = Get-AzureRMWebAppSlot  -ResourceGroupName $rgname -Name  $appname -Slot $slot

		# Test - Create Ssl bindings using web app and web app slot objects
		$createResult = $webapp | New-AzureRMWebAppSSLBinding -Name $prodHostName -Thumbprint $thumbprint
		Assert-AreEqual $prodHostName $createResult.Name

		$createResult = $webappslot | New-AzureRMWebAppSSLBinding -Name $slotHostName -Thumbprint $thumbprint
		Assert-AreEqual $slotHostName $createResult.Name

		# Test - Retrieve Ssl bindings using web app and web app slot objects
		$getResult = $webapp |  Get-AzureRMWebAppSSLBinding
		Assert-AreEqual 2 $getResult.Count

		$getResult = $webappslot | Get-AzureRMWebAppSSLBinding
		Assert-AreEqual 1 $getResult.Count

		# Test - Delete Ssl bindings using web app and web app slot objects
		$webapp | Remove-AzureRMWebAppSSLBinding -Name $prodHostName -Force 
		$res = $webapp | Get-AzureRMWebAppSSLBinding
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $prodHostName }

		$webappslot | Remove-AzureRMWebAppSSLBinding -Name $slotHostName -Force 
		$res = $webappslot | Get-AzureRMWebAppSSLBinding
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $slotHostName }
	}
    finally
    {
		# Cleanup
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostName -Force 
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostName -Force 
    }
}

<#
.SYNOPSIS
Tests retrieving web app certificates
#>
function Test-GetWebAppCertificate
{
	try
	{
		# Setup - Create Ssl bindings
		New-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint

		# Tests - Retrieve web app certificate objects
		$certificates = Get-AzureRMWebAppCertificate
		$thumbprints = $certificates | Select -expand Thumbprint
		Assert-True { $thumbprints -contains $thumbprint }

		$certificate = Get-AzureRMWebAppCertificate -Thumbprint $thumbprint
		Assert-AreEqual $thumbprint $certificate.Thumbprint
	}
    finally
    {
		# Cleanup
		Remove-AzureRMWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostName -Force 
    }
}