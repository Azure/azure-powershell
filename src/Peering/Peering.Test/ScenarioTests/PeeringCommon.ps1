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

#cd ..
$dll = dir | Where-Object {$_.Name -match "Peering.Test.dll"} | % {$_.FullName};
[Reflection.Assembly]::LoadFile($dll);
$ipGenerator = New-Object Microsoft.Azure.Commands.Peering.Test.ScenarioTests.IPGenerator;

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = getAssetName "MockRg"
	Write-Debug "ResourceGroupName: $resourceGroupName"
    $rglocation = "Central US"
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $rglocation -Force
	Write-Debug "Created $resourceGroupName"
    return $resourceGroup
}

function getPeeringLocation ($kind, $location)
{
	return Get-AzPeeringLocation -Kind $kind -PeeringLocation $location
}

function isDirect ($t)
{
	if ($t -eq $true){
		return "Direct"
	}
	return "Exchange"
}

function newIpV4Address ($withPrefix, $maxPrefix, $offset, $randomNum)
{
		$ipv4 = $ipGenerator.CreateIpv4Address($randomNum, $maxPrefix);
		return $ipGenerator.OffSet($ipv4, $false, $offset, $withPrefix);
}

function newIpV6Address ($withPrefix, $maxPrefix, $offset, $randomNum)
{
		$ipv6 = $ipGenerator.CreateIpv6Address($randomNum, $maxPrefix);
		return $ipGenerator.OffSet($ipv6, $true, $offset, $withPrefix);
}

function changeIp($address, $isv6, $offset, $withPrefix){
return $ipGenerator.OffSet($address, $isv6, $offset, $withPrefix);
}

function maxAdvertisedIpv4
{
	$maxPrefixV4 = getPeeringVariable "MaxPrefixV4" $ipGenerator.BuildMaxPrefixes($false);
	return $maxPrefixV4
}

function maxAdvertisedIpv6
{
	$maxPrefixV6 = getPeeringVariable "MaxPrefixV6" $ipGenerator.BuildMaxPrefixes($true);
	return $maxPrefixV6
}

function getHash
{
$hash = getPeeringVariable "Hash" $ipGenerator.BuildHash()
return "$hash"
}

function getBandwidth
{
$bandwidth = getPeeringVariable "bandwidth" $ipGenerator.GetBandwidth()
	return $bandwidth
}

function getPeeringVariable
{
   param([string]$variableName, $value)
   $testName = getTestName
   if ($value)
   {
   $result = $value
   }
   else {
   $reult = $null
   }
  if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName))
  {
      $result = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
  }
  if (![Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName)){
   return $result = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable($variableName, $value)
  }

  return $result
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
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
	$assemblies = [AppDomain]::Currentdomain.GetAssemblies() | Select-Object FullName | ForEach-Object { $_.FullName.Substring(0, $_.FullName.IndexOf(',')) }
    if ($assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpMockServer' `
		-or $assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode' `
		-or [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzResourceGroup -Name $rgname -Force
    }
}