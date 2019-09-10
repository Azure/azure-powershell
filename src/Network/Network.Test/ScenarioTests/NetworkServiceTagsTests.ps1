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
Tests checking API to list service tags.
#>
function Test-NetworkServiceTagsList
{
    $location = Get-ProviderLocation ResourceManagement;

    try
    {
        $results = Get-AzNetworkServiceTag -Location $location;
        Assert-NotNull $results;

        Assert-AreEqual $results.Type "Microsoft.Network/serviceTags";
        Assert-NotNull $results.Name;
        Assert-NotNull $results.Id;
        Assert-NotNull $results.ChangeNumber;
        Assert-NotNull $results.Cloud;
        Assert-NotNull $results.Values;
        Assert-True { $results.Values.Count -gt 1 };

        $serviceTagInformation = $results.Values[0];

        Assert-NotNull $serviceTagInformation.Name;
        Assert-NotNull $serviceTagInformation.Id;
        Assert-NotNull $serviceTagInformation.Properties.ChangeNumber;
        Assert-NotNull $serviceTagInformation.Properties.Region;
        Assert-NotNull $serviceTagInformation.Properties.SystemService;
        Assert-True { $serviceTagInformation.Properties.AddressPrefixes.Count -gt 1 };
    }
    finally {}
}
