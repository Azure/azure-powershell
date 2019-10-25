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



function Get-DeviceConnectionString 
{
	return "";
}


function Get-IotDeviceConnectionString 
{
	return "";
}

<#
.SYNOPSIS
Returns EncryptionKey
#>
function Get-EncryptionKey
{
	return "";
}

<#
.SYNOPSIS
Returns Userpassword used for password
#>
function Get-Userpassword
{
	return "";
}




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
	return "psdataboxedgedevice"
}


function Get-StringHash([String] $String,$HashName = "MD5")
{
	$StringBuilder = New-Object System.Text.StringBuilder
	[System.Security.Cryptography.HashAlgorithm]::Create($HashName).ComputeHash([System.Text.Encoding]::UTF8.GetBytes($String))|%{[Void]$StringBuilder.Append($_.ToString("x2"))}
	$StringBuilder.ToString()
}


<#
.SYNOPSIS
Helper script to generate EncryptionKey
#>
function Get-EncryptionKeyForDevice($resourceGroupName, $deviceName)
{

	$sp = Get-AzADServicePrincipal -ApplicationId "2368d027-f996-4edb-bf48-928f98f2ab8c"
	$e = Get-AzDataBoxEdgeDevice -ResourceGroupName $resourceGroupName -DeviceName $deviceName -ExtendedInfo
	$k = $sp.Id+$e.ResourceKey
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

