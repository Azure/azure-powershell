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

$containerName = "testcredentials-storage";
$containerPrefix = "testcredentials-";

<#
.SYNOPSIS
Tests using Get-AzureStorageContainer without container name.
#>
function Test-GetAzureStorageContainerWithoutContainerName
{
    $containers = Get-AzureStorageContainer; 
    Assert-True {$containers.Count -ge 1};
    $container =  $containers | ? {$_.Name -eq $containerName}
    Assert-NotNull $container;
}

<#
.SYNOPSIS
Tests using Get-AzureStorageContainer with container name.
#>
function Test-GetAzureStorageContainerWithContainerName
{
    $containers = Get-AzureStorageContainer $containerName; 
    Assert-True {$containers.Count -eq 1};
    Assert-AreEqual $containers[0].Name $containerName;
}

<#
.SYNOPSIS
Tests using Get-AzureStorageContainer with container prefix.
#>
function Test-GetAzureStorageContainerWithPrefix
{
    $containers = Get-AzureStorageContainer -Prefix $containerPrefix; 
    Assert-True {$containers.Count -ge 1};
    $containers | % {Assert-True {$_.Name.StartsWith($containerPrefix)}}
}

<#
.SYNOPSIS
Tests using New-AzureStorageContainer.
#>
function Test-NewAzureStorageContainer
{
    $randomName = [System.Guid]::NewGuid().ToString();
    $container = New-AzureStorageContainer $randomName;
    Assert-True {$container.Count -eq 1};
    Assert-True {$container[0].Name -eq $randomName}
    Assert-True {$container[0].PublicAccess.ToString() -eq "Off"}
	
    try
    {
        $container[0].CloudBlobContainer.DeleteIfExists();
    }
    catch
    {}
}

<#
.SYNOPSIS
Tests using New-AzureStorageContainer with specified acl level
#>
function Test-NewAzureStorageContainerWithPermission
{
    $randomName = [System.Guid]::NewGuid().ToString();
    $container = New-AzureStorageContainer $randomName -Permission Container;
    Assert-True {$container[0].Name -eq $randomName}
    Assert-True {$container[0].PublicAccess.ToString() -eq "Container"}
	
    try
    {
        $container[0].CloudBlobContainer.DeleteIfExists();
    }
    catch
    {}
}

<#
.SYNOPSIS
Tests using New-AzureStorageContainer to create a container which already exists
#>
function Test-NewExistsAzureStorageContainer
{
    # Setup
    try
    {
        New-AzureStorageContainer $containerName
    }
    catch {}
    Assert-Throws {New-AzureStorageContainer $containerName} "Container '$containerName' already exists."
}

<#
.SYNOPSIS
Tests using New-AzureStorageContainer with invalid container name
#>
function Test-NewExistsAzureStorageContainerWithInvalidContainerName
{
    $invalidName = "a";
    Assert-Throws {New-AzureStorageContainer $invalidName}
}

<#
.SYNOPSIS
Tests using Remove-AzureStorageContainer
#>
function Test-RemoveAzureStorageContainer
{
    $randomName = [System.Guid]::NewGuid().ToString();
    New-AzureStorageContainer $randomName
    Remove-AzureStorageContainer $randomName -Force
}

<#
.SYNOPSIS
Tests using Remove-AzureStorageContainer by container pipeline
#>
function Test-RemoveAzureStorageContainerByContainerPipeline
{
    $randomName = [System.Guid]::NewGuid().ToString();
    New-AzureStorageContainer $randomName | Get-AzureStorageContainer | Remove-AzureStorageContainer -Force
}