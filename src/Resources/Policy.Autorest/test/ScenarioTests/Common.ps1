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

$TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;
$ResourcesPath = Join-Path $TestOutputRoot "ScenarioTests"

<#
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid password string for a VM
#>
function Get-PasswordForVM
{
    return (getAssetName) + '_196Ab!@'
}

<#
.SYNOPSIS
Gets valid application display name
#>
function Get-ApplicatonDisplayName
{
    return getAssetName
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

<#
.SYNOPSIS
Cleans the deployment
#>
function Clean-DeploymentAtSubscription($deploymentName)
{
    $assemblies = [AppDomain]::Currentdomain.GetAssemblies() | Select-Object FullName | ForEach-Object { $_.FullName.Substring(0, $_.FullName.IndexOf(',')) }
    if ($assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpMockServer' `
        -or $assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode' `
        -or [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        try {
            Remove-AzDeployment -ScopeType Subscription -Name $deploymentName
        } 
        catch {
        }
    }
}

<#
.SYNOPSIS
Cleans the deployment
#>
function Clean-DeploymentAtTenant($deploymentName)
{
    $assemblies = [AppDomain]::Currentdomain.GetAssemblies() | Select-Object FullName | ForEach-Object { $_.FullName.Substring(0, $_.FullName.IndexOf(',')) }
    if ($assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpMockServer' `
        -or $assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode' `
        -or [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        try {
            Remove-AzDeployment -ScopeType Tenant -Name $deploymentName
        } 
        catch {
        }
    }
}

function New-AzResourceGroup
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $Name,
        [string] [Parameter()] $Location
    )

    Invoke-AzRest -SubscriptionId (Get-AzContext).Subscription.Id -ResourceGroupName $Name -ApiVersion 2021-04-01 -Payload "{ `"location`": `"$($Location)`" }" -Method PUT
}

<#
.SYNOPSIS
Simple utility function to see if two simple hashtables equal (key is case insensitive; value is case sensitive)
#>
function AreHashtableEqual($hash1, $hash2)
{
    if($hash1 -eq $null -and $hash2 -eq $null)
    {
        return $true; 
    }
    if($hash1 -eq $null -or $hash2 -eq $null -or $hash1.Count -ne $hash2.Count)
    {
        return $false;
    }
    foreach($key in $hash1.Keys) 
    {
        if(!$hash2.ContainsKey($key))  # case insensitive
        {
            return $false;
        }
        if($hash1.$key -cne $hash2.$key)  # case sensitive
        {
            return $false;
        }
    }
    return $true;
}
