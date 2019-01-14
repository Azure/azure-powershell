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
Gets valid resource name for compute test
#>
function GetResourceGroupName
{
  $stack = Get-PSCallStack
  $testName = $null;
  foreach ($frame in $stack)
  {
    if ($frame.Command.StartsWith("Test-", "CurrentCultureIgnoreCase"))
    {
      $testName = $frame.Command;
    }
  }

  $oldErrorActionPreferenceValue = $ErrorActionPreference;
  $ErrorActionPreference = "SilentlyContinue";
    
  try
  {
    $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName($testName, "pstestrg");
  }
  catch
  {
    if (($Error.Count -gt 0) -and ($Error[0].Exception.Message -like '*Unable to find type*'))
    {
      $assetName = Get-RandomItemName;
    }
    else
    {
      throw;
    }
  }
  finally
  {
    $ErrorActionPreference = $oldErrorActionPreferenceValue;
  }
  return $assetName
}

<#
.SYNOPSIS
Create a resource group
#>
function CreateResourceGroup([string]$rgname, [string]$location) 
{
	$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Force
	return $resourceGroup
}

<#
.SYNOPSIS
Remove a resource group
#>
function RemoveResourceGroup([string]$rgname) 
{
	Remove-AzureRmResourceGroup -Name $rgname -Force
}

<#
.SYNOPSIS
Create a storage account
#>
function CreateStorageAccount([string]$rgname, [string]$name, [string]$location)
{
	New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $name -Location $location -Type "Standard_GRS"
	$storageAccount = Get-AzureRmStorageAccount -ResourceGroupName $rgname -Name $name
	return $storageAccount
}

<#
.SYNOPSIS
Remove a storage account
#>
function RemoveStorageAccount([string]$rgname, [string]$name) 
{
	Remove-AzureRmStorageAccount -ResourceGroupName $rgname -Name $name
}

<#
.SYNOPSIS
Get a storage account
#>
function GetStorageAccount
{

  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN { 
    $context = Get-Context
	  $client = Get-StorageClient $context
  }
  PROCESS {
    $getTask = $client.StorageAccounts.GetPropertiesAsync($ResourceGroupName, $Name, [System.Threading.CancellationToken]::None)
    <#$account = New-Object PSObject -Property @{"StorageAccountName" = $Name; "ResourceGroupName" = $ResourceGroupName; }#>
	  Write-Output $getTask.Result.StorageAccount
  }
  END {}
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
Get a location for test.
#>
function Get-AvailableLocation($preferedLocation)
{
  if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
  {
    $namespace = "Microsoft.Media"
    $provider = Get-AzureRmResourceProvider -ProviderNamespace Microsoft.Media | where {$_.Locations.length -ne 0}
    $locations = $provider.Locations
    if($locations -contains $preferedLocation)
    {
      return $preferedLocation
    }
    return $locations[0]
  }

  return $preferedLocation
}
