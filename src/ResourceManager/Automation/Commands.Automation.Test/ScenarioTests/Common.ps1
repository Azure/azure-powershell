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
Gets resource group name
#>
function Get-RandomResourceGroupName
{
    return 'rg-' + (getAssetName)
}

<#
.SYNOPSIS
Gets account name
#>
function Get-RandomAutomationAccountName
{
	return 'automationAccount-' + (getAssetName)
}

<#
.SYNOPSIS
Gets autoamtion account test location
#>
function Get-AutomationAccountTestLocation
{
	return Get-Location -providerNamespace "Microsoft.Automation" -resourceType "automationAccounts" -preferredLocation "Japan East"
}

<#
.SYNOPSIS
Checks whether the first string contains the second one
#>
function AssertContains
{
    param([string] $str, [string] $substr, [string] $message)

    if (!$message)
    {
        $message = "Assertion failed because '$str' does not contain '$substr'"
    }
  
    if (!$str.Contains($substr)) 
    {
        throw $message
    }
  
    return $true
}  

