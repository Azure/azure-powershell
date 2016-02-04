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
Tests getting the logs associated to a correlation Id.
#>
function Test-GetAzureCorrelationIdLog
{
    # Setup
    $correlation = '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/alertrules/checkrule3-4b135401-a30c-4224-ae21-fa53a5bd253d/incidents/L3N1YnNjcmlwdGlvbnMvYTkzZmIwN2MtNmM5My00MGJlLWJmM2ItNGYwZGViYTEwZjRiL3Jlc291cmNlR3JvdXBzL0RlZmF1bHQtV2ViLUVhc3RVUy9wcm92aWRlcnMvbWljcm9zb2Z0Lmluc2lnaHRzL2FsZXJ0cnVsZXMvY2hlY2tydWxlMy00YjEzNTQwMS1hMzBjLTQyMjQtYWUyMS1mYTUzYTViZDI1M2QwNjM1NjA5MjE5ODU0NzQ1NDI0'

    try 
    {
        # Test
        $actual = Get-AzureCorrelationIdLog -CorrelationId $correlation -starttime 2015-03-02T10:00:00 -endtime 2015-03-02T12:00:00 -detailedOutput

        # Assert TODO add more asserts
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs associated to a resource group.
#>
function Test-GetAzureResourceGroupLog
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
	    $actual = Get-AzureResourceGroupLog -ResourceGroup $rgname -starttime 2015-01-15T04:30:00 -endtime 2015-01-15T12:30:00

        # Assert TODO add more asserts
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs associated to a resource Id.
#>
function Test-GetAzureResourceLog
{
    # Setup
    $rname = '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/alertrules/checkrule3-4b135401-a30c-4224-ae21-fa53a5bd253d'

    try 
    {
		$actual = Get-AzureResourceLog -ResourceId $rname -startTime 2015-03-03T15:42:50Z -endTime 2015-03-03T16:42:50Z

        # Assert TODO add more asserts
		# Assert-Throws { Set-AzureResourceGroup -Name $rgname -Tags @{"testtag" = "testval"} } "Invalid tag format. Expect @{Name = `"tagName`"} or @{Name = `"tagName`"; Value = `"tagValue`"}"
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs associated to a resource provider.
#>
function Test-GetAzureResourceProviderLog
{
    # Setup
    $rpname = 'microsoft.insights'

    try 
    {
		$actual = Get-AzureResourceProviderLog -ResourceProvider $rpname -startTime 2015-03-03T15:42:50Z -endTime 2015-03-03T16:42:50Z

        # Assert
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs for a subscription Id.
#>
function Test-GetAzureSubscriptionIdLog
{
    # No Setup needed

    try 
    {
        # Test
        $actual = Get-AzureSubscriptionIdLog -starttime 2015-01-15T04:30:00 -endtime 2015-01-15T12:30:00 

        # Assert
        Assert-AreEqual $actual.Count 1
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
