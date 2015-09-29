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

$createdCloudServices = @()

<#
.SYNOPSIS
Gets valid and available cloud service name.
#>
function Get-CloudServiceName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets the default location
#>
function Get-DefaultLocation
{
	return (Get-AzureLocation)[0].Name
}

<#
.SYNOPSIS
Creates cloud services with the count specified

.PARAMETER count
The number of cloud services to create.
#>
function New-CloudService
{
	param([int] $count, [ScriptBlock] $cloudServiceProject, [string] $slot)
	
	if ($cloudServiceProject -eq $null) { $cloudServiceProject = { New-TinyCloudServiceProject $args[0] } }
	if ($slot -eq $null) { $slot = "Production" }

	1..$count | % { 
		$name = Get-CloudServiceName;
		Invoke-Command -ScriptBlock $cloudServiceProject -ArgumentList $name;
		Publish-AzureServiceProject -Slot $slot
		$global:createdCloudServices += $name;
	}
}

<#
.SYNOPSIS
Creates cloud services and runs validation the count specified

.PARAMETER count
The number of cloud services to create.
.PARAMETER cloudServiceProject
Code block to create a cloud service project
.PARAMETER verifier
Code block to verify successful publishing of service
.PARAMETER updater
Code block to update the service and verify the correct update
#>
function PublishAndUpdate-CloudService
{
	param([int] $count, [ScriptBlock] $cloudServiceProject, [ScriptBlock] $verifier, [ScriptBlock] $updater)
	if ($cloudServiceProject -eq $null) { $cloudServiceProject = { New-TinyCloudServiceProject $args[0] } }
	if ($verifier -eq $null) {$verifier = {return $true}}
	1..$count | % { 
		$name = Get-CloudServiceName;
		Invoke-Command -ScriptBlock $cloudServiceProject -ArgumentList $name;
		$service = Publish-AzureServiceProject;
		$global:createdCloudServices += $name;
		$worked = Retry-Function $verifier $service 3 30
		Assert-True {$worked -eq $true} "Error verifying first application deployment"
		if ($updater -ne $null)
		{
			Invoke-Command -ScriptBlock $updater
			$service = Publish-AzureServiceProject;
			$worked = Retry-Function $verifier $service 3 30
			Assert-True {$worked -eq $true} "Error verifying application update"
		}
	}
}

<#
.SYNOPSIS
Removes all cloud services/storage accounts in the current subscription.
#>
function Initialize-CloudServiceTest
{
	try { Get-AzureStorageAccount | Remove-AzureStorageAccount }
	catch { <# Proceed #> }
	
	try { Get-AzureService | Remove-AzureService -Force }
	catch { <# Proceed #> }
}

<#
.SYNOPSIS
Creates new cloud service project with one node web role.
#>
function New-TinyCloudServiceProject
{
	param([string] $name)

	New-AzureServiceProject $name
	Add-AzureNodeWebRole
}

<#
.SYNOPSIS
Creates new cloud service project with a web role connected to a cache.
#>
function New-CacheCloudServiceProject
{
	param([string] $name)

	New-AzureServiceProject $name
	Add-AzureNodeWebRole ClientRole
	copy ..\CloudService\Cache\*.js .\ClientRole\
	cd .\ClientRole
	Npm-Install "install ..\..\CloudService\Cache\mc.tgz ..\..\CloudService\Cache\connman.tgz";
	cd ..
	Add-AzureCacheWorkerRole CacheRole
	Enable-AzureMemcacheRole ClientRole CacheRole
	$password = ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force
	Enable-AzureServiceProjectRemoteDesktop "gooduser" -Password $password
}

<#
.SYNOPSIS
Runs npm and verifies the results.

.PARAMETER command
The npm command to run
#>

function Npm-Install
{
	param([string] $command)

	$scriptBlock = {
		$toss = Start-Process npm $command -WAIT; 
		$modules = Get-Item * | Where-Object Name node_modules -EQ;
		return $modules -ne $null;
	}
	
	Retry-Function $scriptBlock $null 3 30
}

<#
.SYNOPSIS
Places and retrieves a key value pair from a cache app
#>
function Verify-CacheApp
{
	param([string]$uri)
	$client = New-Object System.Net.WebClient
	$client.BaseAddress = $uri
	$toss = $client.UploadString("/add", "key=key1&value=value1")
	$check = $client.UploadString("/get", "key=key1")
	return $check.Contains("key1") -and $check.Contains("value1")
}

<#
.SYNOPSIS
Updates a service definition by adding remote desktop
#>

function Test-RemoteDesktop
{
	$password = New-Object System.Security.SecureString
	foreach ($c in "P@ssw0rd!".ToCharArray()) {$password.AppendChar($c)}
	Enable-AzureServiceProjectRemoteDesktop -Username user1 -Password $password
}