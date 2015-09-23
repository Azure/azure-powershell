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

########################################################################### General Scenario Tests ###########################################################################


# Initilizing variables
$pseudorandomInput = "a","b","c","d","e","f","g","1","2","3","4","5","6","7"
$mediaPrefix = "psmediatest"
$MediaAccountName = $MediaAccountName
$StorageAccountName = $StorageAccountName
$DefaultRegion = "West US"

function GetPseudoRandomName
{  
	$returnValue = $mediaPrefix + (Get-Random -input $pseudorandomInput) + (Get-Random -input $pseudorandomInput) + (Get-Random -input $pseudorandomInput)
	return $returnValue
}

# Generating accounts names if variables are not defined
if([string]::IsNullOrEmpty($StorageAccountName))
{
	$StorageAccountName = GetPseudoRandomName
}

if([string]::IsNullOrEmpty($MediaAccountName))
{
	$MediaAccountName = GetPseudoRandomName
}

function Get-Region
{
    param([string] $defaultRegion)
	$locations = Get-AzureLocation
	$returnedLocation = $null
	Foreach($location in $locations)
	{
	   if ($location.DisplayName -eq $defaultRegion)
	   {
	       return $defaultRegion
	   }

	   if ($location.AvailableServices.Contains('Storage'))
	   {
	       $returnedLocation = $location.DisplayName
	   }
	}

	return $returnedLocation
}


$Region = Get-Region $DefaultRegion




function EnsureStorageAccountExists
{
	

	$accounts = Get-AzureStorageAccount
	
	Foreach($account in $accounts)
	{
		if ($account.StorageAccountName -eq $StorageAccountName) 
		{ 
			return
		}
	}
	
	New-AzureStorageAccount -StorageAccountName $StorageAccountName -Location $Region

}

function EnsureTestAccountExists
{

	$accounts = Get-AzureMediaServicesAccount

	Foreach($account in $accounts)
	{
		if ($account.Name -eq $MediaAccountName) 
		{ 
			return
		}
	}

	EnsureStorageAccountExists
	
	New-AzureMediaServicesAccount -Name $MediaAccountName -Location $Region -StorageAccountName $StorageAccountName
}

<#
.SYNOPSIS
Tests rotate key.
#>
function Test-NewAzureMediaServicesKey
{
	EnsureTestAccountExists

	$key = New-AzureMediaServicesKey -Name $MediaAccountName -KeyType Secondary -Force

	$account = Get-AzureMediaServicesAccount -Name $MediaAccountName

	Assert-AreEqual $key $account.MediaServicesSecondaryAccountKey
}
	

<#
.SYNOPSIS
Tests delete account.
#>
function Test-RemoveAzureMediaServicesAccount
{
	EnsureTestAccountExists

	Remove-AzureMediaServicesAccount -Name $MediaAccountName -Force
}

function Test-GetAzureMediaServicesAccount
{
	$accounts = Get-AzureMediaServicesAccount
}

function Test-GetAzureMediaServicesAccountByName 
{
	EnsureTestAccountExists

	$account = Get-AzureMediaServicesAccount -Name $MediaAccountName
}



function MediaServicesTest-Cleanup
{
	$accounts = Get-AzureMediaServicesAccount

	Foreach($account in $accounts)
	{
		if($account.Name.StartsWith($mediaPrefix)) 
		{

			Remove-AzureMediaServicesAccount -Name $account.Name -Force
		}
	}
	
	
	$accounts = Get-AzureStorageAccount
	
	Foreach($account in $accounts)
	{
		if ($account.StorageAccountName.StartsWith($mediaPrefix)) 
		{ 
			Remove-AzureStorageAccount -StorageAccountName $account.StorageAccountName
		}
	}
}
