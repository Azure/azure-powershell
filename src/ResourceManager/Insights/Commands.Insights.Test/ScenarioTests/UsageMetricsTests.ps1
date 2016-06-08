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
Tests getting usage metrics values for a particular resource.
#>
function Test-GetUsageMetrics
{
    # Setup
	$rscname = '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/garyyang1'

    try 
    {
        # Test
		# -timeGrain 00:01:00 -starttime 2015-03-23T15:00:00 -endtime 2015-03-23T15:30:00
        $actual = Get-AzureRmUsage -ResourceId $rscname -star 2015-04-07T15:31:28.4590754-07:00 -end 2015-04-07T16:31:28.4590754-07:00

        # Assert TODO add more asserts
		Assert-AreEqual 0 $actual.Count
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
