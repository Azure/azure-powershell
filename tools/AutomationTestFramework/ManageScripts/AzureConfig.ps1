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
        Write-Host "Switching subscription to '$subscriptionName'"
        $null = Get-AzureRmSubscription -SubscriptionName $subscriptionName | Select-AzureRmSubscription
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
        Write-Host "Switching subscription to '$subscriptionName'"
        $null = Get-AzureRmSubscription -SubscriptionName $subscriptionName | Select-AzureRmSubscription
    }  
    
    @($subscriptionName, $resourceGroupName, $storageAccountName,  $containerName)
}