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
$rgname = "lketmtestantps10"
$appname = "lketmtestantps10"
$slot = "testslot"
$prodHostname = "www.adorenow.net"
$slotHostname = "testslot.adorenow.net"
$thumbprint = "F75A7A8C033FBEA02A1578812DB289277E23EAB1"

<#
.SYNOPSIS
Tests creating a new Web App SSL binding.
#>
function Test-CreateNewWebAppSSLBinding
{
	try
	{
		
		# Test - Create Ssl binding for web app
		$createResult = New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		Assert-AreEqual $prodHostname $createResult.Name

		# Test - Create Ssl binding for web app slot
		$createResult = New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint
		Assert-AreEqual $slotHostname $createResult.Name
	}
    finally
    {
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
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
		$createWebAppResult = New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		$createWebAppSlotResult = New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint

		# Test - Get commands for web app
		$getResult = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname
    Assert-AreEqual 1 $getResult.Count
		$currentHostNames = $getResult | Select -expand Name
		Assert-True { $currentHostNames -contains $createWebAppResult.Name }
		$getResult = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname
		Assert-AreEqual $getResult.Name $createWebAppResult.Name

		# Test - Get commands for web app slot
		$getResult = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot
    Assert-AreEqual 1 $getResult.Count
		$currentHostNames = $getResult | Select -expand Name
		Assert-True { $currentHostNames -contains $createWebAppSlotResult.Name }
		$getResult = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname
		Assert-AreEqual $getResult.Name $createWebAppSlotResult.Name
	}
    finally
    {
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
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
		New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint

		# Tests - Removing binding from web app and web app slot
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 

		# Assert
		$res = Get-AzWebAppSSLBinding  -ResourceGroupName $rgname -WebAppName  $appname
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $prodHostname }

		$res = Get-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $slotHostName }
	}
    finally
    {
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
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
		$webapp = Get-AzWebApp  -ResourceGroupName $rgname -Name  $appname
		$webappslot = Get-AzWebAppSlot  -ResourceGroupName $rgname -Name  $appname -Slot $slot

		# Test - Create Ssl bindings using web app and web app slot objects
		$createResult = $webapp | New-AzWebAppSSLBinding -Name $prodHostName -Thumbprint $thumbprint
		Assert-AreEqual $prodHostName $createResult.Name

		$createResult = $webappslot | New-AzWebAppSSLBinding -Name $slotHostName -Thumbprint $thumbprint
		Assert-AreEqual $slotHostName $createResult.Name

		# Test - Retrieve Ssl bindings using web app and web app slot objects
		$getResult = $webapp |  Get-AzWebAppSSLBinding
		Assert-AreEqual 1 $getResult.Count

		$getResult = $webappslot | Get-AzWebAppSSLBinding
		Assert-AreEqual 1 $getResult.Count

		# Test - Delete Ssl bindings using web app and web app slot objects
		$webapp | Remove-AzWebAppSSLBinding -Name $prodHostName -Force 
		$res = $webapp | Get-AzWebAppSSLBinding
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $prodHostName }

		$webappslot | Remove-AzWebAppSSLBinding -Name $slotHostName -Force 
		$res = $webappslot | Get-AzWebAppSSLBinding
		$currentHostNames = $res | Select -expand Name
		Assert-False { $currentHostNames -contains $slotHostName }
	}
    finally
    {
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostName -Force 
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostName -Force 
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
		New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint

		# Tests - Retrieve web app certificate objects
		$certificates = Get-AzWebAppCertificate
		$thumbprints = $certificates | Select -expand Thumbprint
		Assert-True { $thumbprints -contains $thumbprint }

		$certificate = Get-AzWebAppCertificate -Thumbprint $thumbprint
		Assert-AreEqual $thumbprint $certificate.Thumbprint
	}
    finally
    {
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostName -Force 
    }
}

<#
.SYNOPSIS
Tests creating a new Web App SSL binding does not override tags
#>
function Test-TagsNotRemovedByCreateNewWebAppSSLBinding
{
	try
	{
		# check the app has tags by default
		$getWebAppResult = Get-AzWebApp -ResourceGroupName $rgname -Name $appname
		Assert-notNull $getWebAppResult.Tags
		$tagsApp = $getWebAppResult.Tags

		# Create Ssl binding for web app
		$createBindingResult = New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Thumbprint $thumbprint
		Assert-AreEqual $prodHostname $createBindingResult.Name
		
		# Test - tags are not removed (the app 'lketmtestantps10' has a tag set)
		$getResult = Get-AzWebApp -ResourceGroupName $rgname -Name $appname
		Assert-notNull $getResult.Tags
		foreach($key in $tagsApp.Keys)
		{
			Assert-AreEqual $tagsApp[$key] $getResult.Tags[$key]
		}

		# check the slot has tags by default
		$getSlotResult = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot
		Assert-notNull $getSlotResult.Tags
		$tagsSlot = $getSlotResult.Tags

		# Create Ssl binding for web app slot
		$createSlotBindingResult = New-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Thumbprint $thumbprint
		Assert-AreEqual $slotHostname $createSlotBindingResult.Name

		# Test - tags are not removed from slot (the app 'lketmtestantps10/testslot' has a tag set)
		$getSlotResult2 = Get-AzWebAppSlot -ResourceGroupName $rgname -Name $appname -Slot $slot
		Assert-notNull $getSlotResult2.Tags
		foreach($key in $tagsSlot.Keys)
		{
			Assert-AreEqual $tagsSlot[$key] $getSlotResult2.Tags[$key]
		}

	}
    finally
    {
		# Cleanup
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Name $prodHostname -Force
		Remove-AzWebAppSSLBinding -ResourceGroupName $rgname -WebAppName  $appname -Slot $slot -Name $slotHostname -Force 
    }
}