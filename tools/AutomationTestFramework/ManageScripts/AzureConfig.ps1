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

$azureConfig = @{

# automation account section

	  "aaSubscriptionName" = "Azure SDK Infrastructure";

	  "aaResourceGroupName" =  "azposjhautomation"

	  "aaName" = "azposhautomation";

# storage account section

	  "saSubscriptionName" = "Azure SDK Infrastructure";

	  "saResourceGroupName" =  "transit2automation";

	  "saName" = "transit2automation";

	  'saContainerName' = "testsmodule";
}

function DefaultIfNotSpecifiedAA (
     [string] $subscriptionName
    ,[string] $automaitionAccountName
    ,[string] $resourceGroupName) {

    if ([string]::IsNullOrEmpty($subscriptionName)) {
        $subscriptionName = $azureConfig.Get_Item("aaSubscriptionName")
    }

    if ([string]::IsNullOrEmpty($automaitionAccountName)) {
        $automaitionAccountName = $azureConfig.Get_Item("aaName")
    }

    if ([string]::IsNullOrEmpty($resourceGroupName)) {
        $resourceGroupName = $azureConfig.Get_Item("aaResourceGroupName")
    }

    $cntx = Get-AzureRmContext
    if ($cntx.Subscription.Name -ne $subscriptionName) {
        Write-Verbose "Switching subscription to '$subscriptionName'"
        $null = Get-AzureRmSubscription -SubscriptionName $subscriptionName -ErrorAction "Stop" | Select-AzureRmSubscription
    }  

    @($subscriptionName, $automaitionAccountName, $resourceGroupName)
}

function DefaultIfNotSpecifiedSA (
	   [string] $subscriptionName
    ,[string] $resourceGroupName
    ,[string] $storageAccountName
	  ,[string] $containerName) {

    if ([string]::IsNullOrEmpty($subscriptionName)) {
	      $subscriptionName = $azureConfig.Get_Item("saSubscriptionName")
    }
  
    if ([string]::IsNullOrEmpty($storageAccountName)) {
        $storageAccountName = $azureConfig.Get_Item("saName")
    }
  
    if ([string]::IsNullOrEmpty($resourceGroupName)) {
        $resourceGroupName = $azureConfig.Get_Item("saResourceGroupName")
    }

    if ([string]::IsNullOrEmpty($containerName)) {
        $containerName = $azureConfig.Get_Item("saContainerName")
    }
    
    $cntx = Get-AzureRmContext
    if ($cntx.Subscription.Name -ne $subscriptionName) {
        Write-Verbose "Switching subscription to '$subscriptionName'"
        $null = Get-AzureRmSubscription -SubscriptionName $subscriptionName -ErrorAction "Stop" | Select-AzureRmSubscription
    }  
    
    @($subscriptionName, $resourceGroupName, $storageAccountName,  $containerName)
}