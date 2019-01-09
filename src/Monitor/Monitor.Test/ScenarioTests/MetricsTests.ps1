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
Tests getting metrics values for a particular resource.
#>
function Test-GetMetrics
{
    # Setup
	$rscname = 'subscriptions/56bb45c9-5c14-4914-885e-c6fd6f130f7c/resourceGroups/reactdemo/providers/Microsoft.Web/sites/reactdemowebapi'

    try
    {
        # Test
        $actual = Get-AzMetric -ResourceId $rscname -starttime 2018-03-23T22:00:00Z -endtime 2018-03-23T22:30:00Z
 
        # Assert TODO add more asserts
        Assert-AreEqual 1 $actual.Count

        $actual = Get-AzMetric -ResourceId $rscname -MetricNames CpuTime,Requests -timeGrain 00:01:00 -starttime 2018-03-23T22:00:00Z -endtime 2018-03-23T22:30:00Z -AggregationType Count

        # Assert TODO add more asserts
        Assert-AreEqual 2 $actual.Count

        $metricFilter = New-AzMetricFilter -Dimension City -Operator eq -Value "Seattle","New York"

        Assert-AreEqual 1 $metricFilter.Count
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting metrics definitions and creating a new metric dimension filter.
#>
function Test-GetMetricDefinitions
{
    # Setup
    $rscname = 'subscriptions/56bb45c9-5c14-4914-885e-c6fd6f130f7c/resourceGroups/reactdemo/providers/Microsoft.Web/sites/reactdemowebapi'

    try
    {
        $actual = Get-AzMetricDefinition -ResourceId $rscname

        # Assert TODO add more asserts
        Assert-AreEqual 33 $actual.Count

        $actual = Get-AzMetricDefinition -ResourceId $rscname -MetricName CpuTime,Requests -MetricNamespace "Microsoft.Web/sites"

        Assert-AreEqual 2 $actual.Count
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}