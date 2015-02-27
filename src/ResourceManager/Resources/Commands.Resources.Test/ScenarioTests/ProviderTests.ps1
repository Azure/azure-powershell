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
    Tests registering and un-registering resource providers.
#>
function Test-AzureProvider
{
    $defaultProviders = Get-AzureProvider

    Assert-True { $defaultProviders.Length -gt 0 }

    $allProviders = Get-AzureProvider -ListAvailable

    Assert-True { $allProviders.Length -gt $defaultProviders.Length }

    Register-AzureProvider -ProviderName "Microsoft.ApiManagement"

    $endTime = [DateTime]::UtcNow.AddMinutes(5)

    while ([DateTime]::UtcNow -lt $endTime -and @(Get-AzureProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -ne "Registered")
    {
        sleep 1
    }

    Assert-True { @(Get-AzureProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -eq "Registered" }

    Unregister-AzureProvider -ProviderName "Microsoft.ApiManagement"

    while ([DateTime]::UtcNow -lt $endTime -and @(Get-AzureProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -ne "NotRegistered")
    {
        sleep 1
    }

    Assert-True { @(Get-AzureProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -eq "NotRegistered" }
 }
