<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

## Release 3.0.0

    The following cmdlets were affected this release:

    **Get-AzureRmLogs**
    **Get-AzureRmAlertHistory**
    **Get-AzureRmAutoscaleHistory**
    - The field EventChannels from the EventData object is being deprecated since it is meaningless now. The value currently returned is constant.
    
    **Get-AzureRmUsage**
    - This cmdlet will be deprecated.
    
    **Add-AzureRmMetricAlert**
    **Add-AzureRmWebtestAlert**
    - The output of these cmdlets will change from List<PObject> to a single object, not a list, that includes the requestId, status code, and the updated or newly created resource.
    
    ```powershell
    # Old
  
    $s1 = Add-AzureRmMetricAlertRule -Name chiricutin -Location "West US" -ResourceGroup $resourceGroup -TargetResourceId $resourceId -Operator GreaterThan -Threshold 2 -WindowSize 00:05:00 -MetricName Requests -Description "Pura Vida" -TimeAggre Total -Actions $eMailAction -disab
    if ($s1 -ne $null)
    {
      $r = $s1(0).RequestId
      $s = $s1(0).StatusCode
    }

    # New
    $s1 = Add-AzureRmMetricAlertRule -Name chiricutin -Location "West US" -ResourceGroup $resourceGroup -TargetResourceId $resourceId -Operator GreaterThan -Threshold 2 -WindowSize 00:05:00 -MetricName Requests -Description "Pura Vida" -TimeAggre Total -Actions $eMailAction -disab
    $r = $s1.RequestId
    $s = $s1.StatusCode
    $a = $s1.NewResource
    
    ```

    **Remove-AzureRmAlertRule**
    - The output of these cmdlets will change from list with a single object to a single object, not a list, that includes the requestId, and status code.
    
    ```powershell
    # Old
  
    $s1 = Remove-AzureRmAlertRule -res $resourceGroup -name chiricutin
    if ($s1 -ne $null)
    {
      $r = $s1(0).RequestId
      $s = $s1(0).StatusCode
    }

    # New
    $s1 = Remove-AzureRmAlertRule -res $resourceGroup -name chiricutin
    $r = $s1.RequestId
    $s = $s1.StatusCode
    
    ```
    
    **Add-AzureRmLogAlertRule**
    - This cmdlet will be deprecated.
    
    **Get-AzureRmAlertRule**
    - Each element of the the output (a list of objects) of this cmdlet will be flattened, i.e. instead of returning objects with the following structure { Id, Location, Name, Tags, Properties } it will return objects with the structure { Id, Location, Name, Tags, Type, Description, IsEnabled, Condition, Actions, LastUpdatedTime, ...} so all the attributes of an Azure Resource plus all the attributes of an AlertRuleResource at the top level.
    
    ```powershell
    # Old
  
    $rules = Get-AzureRmAlertRule -Res $resourceGroup
	  if ($rules -and $rules.count -ge 1) {
		  write-host -fore red "Error updating alert rule"
      
      Write-host $rules(0).Id
      Write-host $rules(0).Properties.IsEnabled
      Write-host $rules(0).Properties.Condition
	  }

    # New
    $rules = Get-AzureRmAlertRule -Res $resourceGroup
	  if ($rules -and $rules.count -ge 1) {
		  write-host -fore red "Error updating alert rule"
      
      Write-host $rules(0).Id
      
      # Properties will remain for a while
      Write-host $rules(0).Properties.IsEnabled
      
      # But the properties will be at the top level too. Later Properties will be removed
      Write-host $rules(0).IsEnabled
      Write-host $rules(0).Condition
	  }
    
    ```
    
    **Get-AzureRMAutoscaleSetting**
    - The AutoscaleSettingResourceName field will be deprecated in future versions since it always equals the Name field. In this version is optional.

    ```powershell
    # Old
  
    $s1 = Get-AzureRmAutoscaleSetting -ResourceGroup $resourceGroup -Name MySetting
    if ($s1.AutoscaleSettingResourceName -ne $s1.Name)
    {
      write-host "There is something wrong with the name"
    }

    # New
    $s1 = Get-AzureRmAutoscaleSetting -ResourceGroup $resourceGroup -Name MySetting
    
    # there won't be a AutoscaleSettingResourceName
    write-host $s1.Name
    
    ```
    
    **Remove-AzureRMLogProfile**
    - The output of this cmdlet will change from Boolean to and object containing RequestId and StatusCode.

    ```powershell
    # Old
  
    $s1 = Remove-AzureRMLogProfile --Name myLogProfile
    if ($s1 eq $true)
    {
      write-host "Removed"
    }
    else
    {
      write-host "Failed"
    }

    # New
    $s1 = Remove-AzureRMLogProfile --Name myLogProfile
    $r = $s1.RequestId
    $s = $s1.StatusCode
    
    ```
    
    **Add-LogProfile**
    - The output of this cmdlet will change from an object that includes the requestId, status code, and the updated or newly created resource.
    
    ```powershell
    # Old
  
    $s1 = Add-AzureRmLogProfile -Name default -StorageAccountId /subscriptions/df602c9c-7aa0-407d-a6fb-eb20c8bd1192/resourceGroups/JohnKemTest/providers/Microsoft.Storage/storageAccounts/johnkemtest8162 -Locations Global -categ Delete, Write, Action -retention 3
    $r = $s1.ServiceBusRuleId

    # New
    $s1 = Add-AzureRmLogProfile -Name default -StorageAccountId /subscriptions/df602c9c-7aa0-407d-a6fb-eb20c8bd1192/resourceGroups/JohnKemTest/providers/Microsoft.Storage/storageAccounts/johnkemtest8162 -Locations Global -categ Delete, Write, Action -retention 3
    $r = $s1.RequestId
    $s = $s1.StatusCode
    $a = $s1.NewResource.ServiceBusRuleId
    
    ```
    
    **Set-AzureRmDiagnosticSettings**
    - The command is going to be renamed to Update-AzureRmDiagnsoticSettings

    ```powershell
    # Old
    # Set-AzureRmDiagnosticSettings

    # New
    # Update-AzureRmDiagnosticSettings
    ```