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
Test Export Log Analytic Throttled Requests
#>
function Test-ExportLogAnalyticThrottledRequestsNegative
{
    $loc = Get-ComputeOperationLocation;
    $from = Get-Date -Year 2018 -Month 2 -Day 27 -Hour 9;
    $to = Get-Date -Year 2018 -Month 2 -Day 28 -Hour 9;
    $sasuri = 'https://fakestore.blob.core.windows.net/mylogs/fakesas';
    Assert-ThrowsContains { `
        $result = Export-AzLogAnalyticThrottledRequest -Location $loc -FromTime $from -ToTime $to -BlobContainerSasUri $sasuri -GroupByThrottlePolicy -GroupByResourceName;} `
        "the given SAS URI";
}

<#
.SYNOPSIS
Test Export Log Analytic Request Rate By Interval
#>
function Test-ExportLogAnalyticRequestRateByIntervalNegative
{
    $loc = Get-ComputeOperationLocation;
    $from = Get-Date -Year 2018 -Month 2 -Day 27 -Hour 9;
    $to = Get-Date -Year 2018 -Month 2 -Day 28 -Hour 9;
    $sasuri = 'https://fakestore.blob.core.windows.net/mylogs/fakesas';
    $interval = "FiveMins";
    Assert-ThrowsContains { `
        $result = Export-AzLogAnalyticRequestRateByInterval -Location $loc -FromTime $from -ToTime $to -BlobContainerSasUri $sasuri -IntervalLength $interval -GroupByThrottlePolicy -GroupByOperationName;} `
        "the given SAS URI";
}

<#
.SYNOPSIS
Test Export Log Analytics group by parameters
#>
function Test-ExportLogAnalyticGroupByParameters
{

    # Setup
    $rgname = Get-ComputeTestResourceName;
    $loc = "westus2";

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $container = "contain";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
        Assert-NotNull $key;

        $from = Get-Date -Year 2021 -Month 1 -Day 4 -Hour 9;
        $to = Get-Date -Year 2021 -Month 1 -Day 5 -Hour 9;

        $context = New-AzStorageContext -StorageAccountName $stoname -StorageAccountKey $key.Value[0];

        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
        {
            New-AzStorageContainer -Name $container -Context $context;
            $sastoken = Get-AzStorageContainer -Name $container -Context $context | New-AzStorageContainerSASToken -Permission rwdl -Context $context;
        }

        $sasuri = "https://$stoname.blob.core.windows.net/$container$sastoken";

        $result = Export-AzLogAnalyticThrottledRequest -Location $loc -FromTime $from -ToTime $to -BlobContainerSasUri $sasuri -GroupByUserAgent;
        Assert-AreEqual "Succeeded" $result.Status;

        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
        {
            $blobs = Get-AzStorageBlob -Container $container -Context $context;
            $throttle_blob = $blobs | where {$_.name.contains("ThrottledRequests")};
            Assert-NotNull $throttle_blob;
        }

        $result = Export-AzLogAnalyticThrottledRequest -Location $loc -FromTime $from -ToTime $to -BlobContainerSasUri $sasuri -GroupByApplicationId;
        Assert-AreEqual "Succeeded" $result.Status;

        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
        {
            $blobs = Get-AzStorageBlob -Container $container -Context $context;
            $throttle_blob = $blobs | where {$_.name.contains("ThrottledRequests")};
            Assert-NotNull $throttle_blob;
        }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Export Log Analytics positive scenario
#>
function Test-ExportLogAnalytics
{
    $rgname = Get-ComputeTestResourceName;
    $loc = Get-ComputeOperationLocation;
    $stoname = 'sto' + $rgname;
    $stotype = 'Standard_GRS';
    $container = "test";
    $sastoken = '?fakesas'

    New-AzResourceGroup -Name $rgname -Location $loc -Force;
    New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    $key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname;
    $context = New-AzStorageContext -StorageAccountName $stoname -StorageAccountKey $key.Key1;

    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        New-AzStorageContainer -Name $container -Context $context;
        $sastoken = Get-AzStorageContainer -Name $container -Context $context | New-AzStorageContainerSASToken -Permission rwdl -Context $context;
    }

    try
    {
        $from = Get-Date -Year 2018 -Month 5 -Day 27 -Hour 9;
        $to = Get-Date -Year 2018 -Month 5 -Day 28 -Hour 9;
        $sasuri = "https://$stoname.blob.core.windows.net/$container$sastoken";
        $interval = "FiveMins";
        $result = Export-AzLogAnalyticRequestRateByInterval -Location $loc -FromTime $from -ToTime $to -BlobContainerSasUri $sasuri -IntervalLength $interval -GroupByThrottlePolicy -GroupByOperationName -GroupByResourceName;
        Assert-AreEqual "Succeeded" $result.Status;
        $output = $result | Out-String;
        Assert-True { $output.Contains(".csv"); }
        Assert-True { $output.Contains("RequestRateByInterval"); }

        $result = Export-AzLogAnalyticThrottledRequest -Location $loc -FromTime $from -ToTime $to -BlobContainerSasUri $sasuri -GroupByThrottlePolicy -GroupByOperationName -GroupByResourceName;
        Assert-AreEqual "Succeeded" $result.Status;
        $output = $result | Out-String;
        Assert-True { $output.Contains(".csv"); }
        Assert-True { $output.Contains("ThrottledRequests"); }

        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
        {
            $blobs = Get-AzStorageBlob -Container test -Context $context;
            $request_blob = $blobs | where {$_.name.contains("RequestRateByInterval")};
            $throttle_blob = $blobs | where {$_.name.contains("ThrottledRequests")};
            Assert-NotNull $request_blob;
            Assert-NotNull $throttle_blob;
        }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
