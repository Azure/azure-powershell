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
Tests List AzureFirewallFqdnTag.
#>
function Test-ListAzureFirewallFqdnTag
{
    # One tag we always expect in the list
    $alwaysPresentTag = "WindowsUpdate"

    # Get AzureFirewallFqdnTag
    $availableFqdnTags = Get-AzFirewallFqdnTag

    # Verification
    # Default FQDN Tags will always keep changing, but there should always be at least one item in the list
    Assert-True { $availableFqdnTags.Count -gt 0 }

    #Also, check for one item we always expect in the result
    Assert-AreEqual 1 $availableFqdnTags.Where({$_.FqdnTagName -eq $alwaysPresentTag}).Count
}
