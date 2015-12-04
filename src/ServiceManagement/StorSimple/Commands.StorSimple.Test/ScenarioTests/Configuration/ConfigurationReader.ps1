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

$global:StorSimpleGlobalConfigMap = $null

function Read-XMLConfigFile($configFilePath)
{
	$methodName = "Read-ConfigFile"

	Write-Verbose "$methodName : Reading configuration file '$configFilePath'"
	if([string]::IsNullOrEmpty($configFilePath)) {
		throw "$methodName : Config file path is not specified. Please specify file path OR set the environment variable STORSIMPLE_SDK_TEST_CONFIG_PATH."
	}
	
	[xml] $configContent = Get-Content $configFilePath
	if(!$configContent) {
		throw "$methodName : Config file '$configFilePath' is either not readable or is empty"
	}
	Write-Verbose "$methodName : Configuration file read. Extracting configuration keys."

	$configMap=@{}
	foreach($configEntry in $configContent.configuration.appSettings.add) {
		Write-Verbose ("{0} : {1}" -F $configEntry.key, $configEntry.Value)
		if($configMap.ContainsKey($configEntry.key)) {
			throw "Duplicate configuration entries for key '$($configEntry.key)' - please check the configuration file '$configFilePath' for correctness"
		} else {
			$configMap.Add($configEntry.key, $configEntry.Value)
		}
	}
	$global:StorSimpleGlobalConfigMap = $configMap

	Write-Verbose "$methodName : Completed reading configuration items from file '$configFilePath'. Found $($configMap.Count) keys : "
	$configMap.GetEnumerator() | foreach-object -begin { $i = 1 } -process { Write-Verbose ("$methodName : Config entry #{0}: '{1}' : '{2}'" -F $i, $_.Key, $_.Value); $i++}
	return $configMap
}

function Read-ConfigFile($configFilePath)
{
	$methodName = "Read-ConfigFile"

	Write-Verbose "$methodName : Reading configuration file '$configFilePath'"
	if([string]::IsNullOrEmpty($configFilePath)) {
		throw "$methodName : Config file path is not specified. Please specify file path OR set the environment variable STORSIMPLE_SDK_TEST_CONFIG_PATH."
	}

	$configContent = Get-Content $configFilePath
	if(!$configContent) {
		throw "$methodName : Config file '$configFilePath' is either not readable or is empty"
	}
	Write-Verbose "$methodName : Configuration file read. Extracting configuration keys."

	$configContent | foreach-object -begin {$configMap=@{}} -process { $k = [regex]::split($_,'='); if(($k[0].CompareTo("") -ne 0) -and ($k[0].StartsWith("[") -ne $True) -and ($k[0].StartsWith("#") -ne $True)) { $configMap.Add($k[0], $k[1]) } }
	$global:StorSimpleGlobalConfigMap = $configMap

	Write-Verbose "$methodName : Completed reading configuration items from file '$configFilePath'. Found $($configMap.Count) keys : "
	$configMap.GetEnumerator() | foreach-object -begin { $i = 1 } -process { Write-Verbose ("$methodName : Config entry #{0}: '{1}' : '{2}'" -F $i, $_.Key, $_.Value); $i++}
	return $configMap
}

function Get-ConfigFileMap ()
{
	$methodName = "Get-ConfigFileMap"

	if($global:StorSimpleGlobalConfigMap) {
		Write-Verbose "$methodName : Using cached config map"
		return $global:StorSimpleGlobalConfigMap
	}

	$configFilePath = $env:STORSIMPLE_SDK_TEST_CONFIG_PATH
	$configurationMap = Read-XMLConfigFile $configFilePath

	if(!$configurationMap -or $configurationMap.Count -eq 0) {
		throw "$methodName : The configuration map does not contain any keys - please check the configuration file '$configFilePath' for correctness"
	}

	return $configurationMap
}

<#
.SYNOPSIS
#>
function Get-Configuration ($configPropertyKey)
{
	$methodName = "Get-Configuration"
	Write-Verbose "$methodName : Fetching from configuration map, value of key '$configPropertyKey'"
	
	$configurationMap = Get-ConfigFileMap

	if($configurationMap.ContainsKey($configPropertyKey)) {
		$configurationValue = $configurationMap[$configPropertyKey]
		Write-Verbose "$methodName : Returning configuration property with value '$configurationValue' for key '$configPropertyKey'"

		return $configurationValue;
	}

	Write-Verbose "$methodName : Could not find any property in the configuration map with the key '$configPropertyKey'"
	return $null
}
