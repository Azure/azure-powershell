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
Gets valid resource group name
#>
function Get-DeviceResourceGroupName
{
	return "psrgpfortest"
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-DeviceName
{
	return "psddataboxedgecan"
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-VaultName
{
	return "azpsdbe"
}


<#
.SYNOPSIS
Gets valid Device Connection String
#>

function Get-DeviceConnectionString 
{
	$vaultName = Get-VaultName
	$val = Get-AzKeyVaultSecret -VaultName $vaultName -Name "DeviceConnectionString"
	return $val.SecretValue
}

<#
.SYNOPSIS
Gets valid IOT Device Connection String
#>
function Get-IotDeviceConnectionString 
{
	$vaultName = Get-VaultName
	$val = Get-AzKeyVaultSecret -VaultName $vaultName -Name "IotDeviceConnectionString"
	return $val.SecretValue
}

<#
.SYNOPSIS
Returns Userpassword used for password
Gets valid resource group name
 #>
function Get-Userpassword
{
	$vaultName = Get-VaultName
	$val = Get-AzKeyVaultSecret -VaultName $vaultName -Name "UserPassword"
	return $val.SecretValue
}

<#
.SYNOPSIS
Returns standard EncryptionKey
#>
function Get-EncryptionKey
{
	$val = "faked"
	return ConvertTo-SecureString $val -AsPlainText -Force
}



function Get-StringHash([String] $String,$HashName = "MD5")
{
	$StringBuilder = New-Object System.Text.StringBuilder
	[System.Security.Cryptography.HashAlgorithm]::Create($HashName).ComputeHash([System.Text.Encoding]::UTF8.GetBytes($String))|%{[Void]$StringBuilder.Append($_.ToString("x2"))}
	$StringBuilder.ToString()
}


<#
.SYNOPSIS
Returns EncryptionKey
#>
function Get-EncryptionKeyForDevice($resourceGroupName, $deviceName)
{

	$sp = Get-AzADServicePrincipal -ApplicationId "2368d027-f996-4edb-bf48-928f98f2ab8c"
	$e = Get-AzDataBoxEdgeDevice -ResourceGroupName $resourceGroupName -Name $deviceName -ExtendedInfo
	$k = $sp.Id+$e.ResourceKey
	echo $k
	return Get-StringHash $k "SHA512"
}

<#
.SYNOPSIS
Gets valid storage account name
#>
function Get-StorageAccountName
{
	return getAssetName
}

<#
.SYNOPSIS
Asserts if two tags are equal
#>
function Assert-Tags($tags1, $tags2)
{
	if($tags1.count -ne $tags2.count)
	{
		throw "Tag size not equal. Tag1: $tags1.count Tag2: $tags2.count"
	}

	foreach($key in $tags1.Keys)
	{
		if($tags1[$key] -ne $tags2[$key])
		{
			throw "Tag content not equal. Key:$key Tags1:" +  $tags1[$key] + "Tags2:" + $tags2[$key]
		}
	}
}


<#
.SYNOPSIS
Sleep in record mode only
#>
function SleepInRecordMode ([int]$SleepIntervalInSec)
{
	$mode = $env:AZURE_TEST_MODE
	if ( $mode -ne $null -and $mode.ToUpperInvariant() -eq "RECORD")
	{
		Wait-Seconds $SleepIntervalInSec 
	}
}


