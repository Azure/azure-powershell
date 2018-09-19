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
Tests creating new azure profile with access token
#>
function Test-SelectDefaultProfile
{
    param([string] $token, [string] $user, [string] $sub)
    $profile = $(New-AzureProfile -SubscriptionId $sub -AccessToken $token -AccountId $user)
    Assert-AreEqual "AzureCloud" $Profile.Context.Environment.Name
    Select-AzureProfile $profile
	$profile2 = Select-AzureProfile -Default     
	Assert-NotNull $($profile2.ProfilePath)
}

<#
.SYNOPSIS
Tests using a profile to run an RDFE cmdlet
#>
function Test-NewAzureProfileInRDFEMode
{
    param([string] $token, [string] $user, [string] $sub)
    $profile = $(New-AzureProfile -SubscriptionId $sub -AccessToken $token -AccountId $user)
    Assert-AreEqual "AzureCloud" $Profile.Context.Environment.Name
    Select-AzureProfile $profile
    $locations = Get-AzureLocation
    Assert-NotNull $locations
    Assert-True {$locations.Count -gt 1}
}

<#
.SYNOPSIS
Tests using a profile to run an ARM cmdlet
#>
function Test-NewAzureProfileInARMMode
{
    param([string] $token, [string] $user, [string] $sub)
    $profile = $(New-AzureProfile -SubscriptionId $sub -AccessToken $token -AccountId $user)
	Assert-AreEqual "AzureCloud" $($Profile.Context.Environment.Name) "Expecting the azure cloud environment"
	Select-AzureProfile $profile
	$locations = Get-AzureLocation
	Assert-NotNull $locations
	Assert-True {$locations.Count -gt 1}
}