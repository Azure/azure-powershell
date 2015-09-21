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

$createdNamespaces = @()

<#
.SYNOPSIS
Gets default location from the available list of service bus locations.
#>
function Get-DefaultServiceBusLocation
{
    $locations = Get-AzureSBLocation

    return $locations[0].Code
}

<#
.SYNOPSIS
Gets valid and available service bus namespace name.
#>
function Get-NamespaceName
{
    return getAssetName
}

<#
.SYNOPSIS
Removes given namespace when it's status is 'Active'

.PARAMETER name
The namespace name.
#>
function Remove-Namespace
{
    param([string]$name)
    Wait-NamespaceStatus $name "Active"
    Remove-AzureSBNamespace $name -Force
    Wait-NamespaceRemoved $name
}

<#
.SYNOPSIS
Waits until the namespace is removed.

.PARAMETER name
The namespace name.
#>
function Wait-NamespaceRemoved
{
    param([string]$name)
    
    $waitScriptBlock = {
        $removed = $false
        try
        {
            $namespace = Get-AzureSBNamespace $name
            Wait-Seconds 5
        }
        catch
        {
            $removed = $true
        }

        return $removed;
    }

    Wait-Function $waitScriptBlock $true
}

<#
.SYNOPSIS
Waits on the namespace until its status reaches provided state.

.PARAMETER name
The namespace name.

.PARAMETER status
The status to wait on.
#>
function Wait-NamespaceStatus
{
    param([string] $name, [string] $status)

    $waitScriptBlock = { (Get-AzureSBNamespace $name).Status }
    Wait-Function $waitScriptBlock $status
}

<#
.SYNOPSIS
Clears the all created resources while doing the test.
#>
function Test-CleanupServiceBus
{
    try { foreach ($name in $global:createdNamespaces) { Remove-Namespace $name -Force } }
    catch { <# Succeed #> }
    $global:createdNamespaces = @()
}

<#
.SYNOPSIS
Creates service bus namespaces with the count specified and wait until the namespace status is Active.

.PARAMETER count
The number of namespaces to create.
#>
function New-Namespace
{
    param([int]$count)
    1..$count | % { 
        $name = Get-NamespaceName;
        New-AzureSBNamespace $name $(Get-DefaultServiceBusLocation);
        $global:createdNamespaces += $name;
    }

    $global:createdNamespaces | % { Wait-NamespaceStatus $_ "Active" };
}

<#
.SYNOPSIS
Removes all the active namespaces in the current subscription.
#>
function Initialize-NamespaceTest
{
    try { Get-AzureSBNamespace | Where {$_.Status -eq "Active"} | Remove-AzureSBNamespace -Force }
    catch { <# Succeed #> }
}

<#
.SYNOPSIS
Creates a ServiceBusExtensionClient instance.
#>
function New-ServiceBusClientExtensions
{
    $client = New-Object Microsoft.WindowsAzure.Commands.Utilities.ServiceBus.ServiceBusClientExtensions `
        -ArgumentList $(Get-AzureSubscription -Default)

    return $client
}