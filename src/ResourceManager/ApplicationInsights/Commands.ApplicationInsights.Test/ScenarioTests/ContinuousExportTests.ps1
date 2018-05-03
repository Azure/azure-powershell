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
Test Get-AzureRmApplicationInsightsContinuousExport
#>
function Test-GetApplicationInsightsContinuousExport
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$dummySubId = "50359d91-7b9d-4823-85af-eb298a61ba97";
		$dummyStorageAccount = "dummysa";
		$dummyContainer = "dummycontianer";

		$destinatinStorageAccountId = "/subscriptions/" + $dummySubId + "/resourceGroups/" + $rgname + "/providers/Microsoft.Storage/storageAccounts/"+ $dummyStorageAccount;
		$destinationStorageAccountSASToken = "https://"+ $dummyStorageAccount + ".blob.core.windows.net/"+$dummyContainer + "?sv=2015-04-05&sr=c&sig=xxxxxxxxx";
		
		$documentTypes = @("Request", "Custom Event");
		$continuousExport = New-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -DocumentType $documentTypes -StorageAccountId $destinatinStorageAccountId -StorageLocation $loc -StorageSASUri $destinationStorageAccountSASToken;

        $continuousExport2 = Get-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -ExportId $continuousExport.ExportId;
        
        Assert-NotNull $continuousExport2        
		Assert-AreEqual "Request, Custom Event" $continuousExport2.DocumentTypes
		Assert-AreEqual $dummySubId $continuousExport2.DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExport2.DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExport2.ContainerName

        $continuousExports = Get-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName;
        
		Assert-AreEqual 1 $continuousExports.count
		Assert-AreEqual "Request, Custom Event" $continuousExports[0].DocumentTypes
		Assert-AreEqual $dummySubId $continuousExports[0].DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExports[0].DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExports[0].ContainerName

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzureRmApplicationInsightsContinuousExport
#>
function Test-NewApplicationInsightsContinuousExport
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$dummySubId = "50359d91-7b9d-4823-85af-eb298a61ba97";
		$dummyStorageAccount = "dummysa";
		$dummyContainer = "dummycontianer";

		$destinatinStorageAccountId = "/subscriptions/" + $dummySubId + "/resourceGroups/" + $rgname + "/providers/Microsoft.Storage/storageAccounts/"+ $dummyStorageAccount;
		$destinationStorageAccountSASToken = "https://"+ $dummyStorageAccount + ".blob.core.windows.net/"+$dummyContainer + "?sv=2015-04-05&sr=c&sig=xxxxxxxxx";
		
		$documentTypes = @("Request", "Custom Event");
		$continuousExport = New-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -DocumentType $documentTypes -StorageAccountId $destinatinStorageAccountId -StorageLocation $loc -StorageSASUri $destinationStorageAccountSASToken;

        Assert-NotNull $continuousExport       
		Assert-AreEqual "Request, Custom Event" $continuousExport.DocumentTypes
		Assert-AreEqual $dummySubId $continuousExport.DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExport.DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExport.ContainerName

        $continuousExport2 = Get-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -ExportId $continuousExport.ExportId;
        
        Assert-NotNull $continuousExport2        
		Assert-AreEqual "Request, Custom Event" $continuousExport2.DocumentTypes
		Assert-AreEqual $dummySubId $continuousExport2.DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExport2.DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExport2.ContainerName

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Remove-AzureRmApplicationInsightsContinuousExport
#>
function Test-RemoveApplicationInsightsContinuousExport
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$dummySubId = "50359d91-7b9d-4823-85af-eb298a61ba97";
		$dummyStorageAccount = "dummysa";
		$dummyContainer = "dummycontianer";

		$destinatinStorageAccountId = "/subscriptions/" + $dummySubId + "/resourceGroups/" + $rgname + "/providers/Microsoft.Storage/storageAccounts/"+ $dummyStorageAccount;
		$destinationStorageAccountSASToken = "https://"+ $dummyStorageAccount + ".blob.core.windows.net/"+$dummyContainer + "?sv=2015-04-05&sr=c&sig=xxxxxxxxx";
		
		$documentTypes = @("Request", "Custom Event");
		$continuousExport = New-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -DocumentType $documentTypes -StorageAccountId $destinatinStorageAccountId -StorageLocation $loc -StorageSASUri $destinationStorageAccountSASToken;

        $continuousExport2 = Get-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -ExportId $continuousExport.ExportId;
        
        Assert-NotNull $continuousExport2        
		Assert-AreEqual "Request, Custom Event" $continuousExport2.DocumentTypes
		Assert-AreEqual $dummySubId $continuousExport2.DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExport2.DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExport2.ContainerName

        Remove-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -ExportId $continuousExport.ExportId;

		$continuousExports = Get-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName;
		Assert-AreEqual 0 $continuousExports.count;

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzureRmApplicationInsightsContinuousExport
#>
function Test-SetApplicationInsightsContinuousExport
{
    # Setup
    $rgname = Get-ApplicationInsightsTestResourceName;

    try
    {
        # Test
		$appName = "app" + $rgname;
        $loc = Get-ProviderLocation ResourceManagement;
		$kind = "web";
        New-AzureRmResourceGroup -Name $rgname -Location $loc;
        New-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName -Location $loc -Kind $kind;
		
		$dummySubId = "50359d91-7b9d-4823-85af-eb298a61ba97";
		$dummyStorageAccount = "dummysa";
		$dummyContainer = "dummycontianer";

		$destinatinStorageAccountId = "/subscriptions/" + $dummySubId + "/resourceGroups/" + $rgname + "/providers/Microsoft.Storage/storageAccounts/"+ $dummyStorageAccount;
		$destinationStorageAccountSASToken = "https://"+ $dummyStorageAccount + ".blob.core.windows.net/"+$dummyContainer + "?sv=2015-04-05&sr=c&sig=xxxxxxxxx";
		
		$documentTypes = @("Request", "Custom Event");
		$continuousExport = New-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -DocumentType $documentTypes -StorageAccountId $destinatinStorageAccountId -StorageLocation $loc -StorageSASUri $destinationStorageAccountSASToken;

        $continuousExport2 = Get-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -ExportId $continuousExport.ExportId;
        
        Assert-NotNull $continuousExport2        
		Assert-AreEqual "Request, Custom Event" $continuousExport2.DocumentTypes
		Assert-AreEqual $dummySubId $continuousExport2.DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExport2.DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExport2.ContainerName

		$documentTypes = @("Request", "Custom Event", "Exception");
		$continuousExport3 = Set-AzureRmApplicationInsightsContinuousExport -ResourceGroupName $rgname -Name $appName -ExportId $continuousExport.ExportId -DocumentType $documentTypes -StorageAccountId $destinatinStorageAccountId -StorageLocation $loc -StorageSASUri $destinationStorageAccountSASToken;
        Assert-NotNull $continuousExport3        
		Assert-AreEqual "Request, Custom Event, Exception" $continuousExport3.DocumentTypes
		Assert-AreEqual $dummySubId $continuousExport3.DestinationStorageSubscriptionId
		Assert-AreEqual $loc $continuousExport3.DestinationStorageLocationId
		Assert-AreEqual $dummyContainer $continuousExport3.ContainerName

        Remove-AzureRmApplicationInsights -ResourceGroupName $rgname -Name $appName;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


