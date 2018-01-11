<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes

### Release 4.0.0 - November 2017

The following cmdlets were affected this release:

**Add-AzureRMLogAlertRule**
- The **Add-AzureRMLogAlertRule** cmdlet has been deprecated
- After October 1st using this cmdlet will no longer have any effect as this functionality is being transitioned to Activity Log Alerts. Please see https://aka.ms/migratemealerts for more information.

**Get-AzureRMUsage**
- The **Get-AzureRMUsage** cmdlet has been deprecated

**Get-AzureRmAlertHistory** / **Get-AzureRmAutoscaleHistory** / **Get-AzureRmLogs**
- Output change: The field EventChannels from the EventData object (returned by these cmdlets) is being deprecated since it now returns a constant value (Admin,Operation.)

**Get-AzureRmAlertRule**
- Output change: The output of this cmdlet will be flattened, i.e. elimination of the properties field, to improve the user experience.

```powershell
# Old
$rules = Get-AzureRmAlertRule -ResourceGroup $resourceGroup
if ($rules -and $rules.count -ge 1)
{
	Write-Host -Foreground Red "Error updating alert rule"
	Write-Host $rules[0].Id
	Write-Host $rules[0].Properties.IsEnabled
	Write-Host $rules[0].Properties.Condition
}

# New
$rules = Get-AzureRmAlertRule -ResourceGroup $resourceGroup
if ($rules -and $rules.count -ge 1)
{
	Write-Host -Foreground red "Error updating alert rule"
	Write-Host $rules[0].Id

	# Properties will remain for a while
	Write-Host $rules[0].Properties.IsEnabled
      
	# But the properties will be at the top level too. Later Properties will be removed
	Write-Host $rules[0].IsEnabled
	Write-Host $rules[0].Condition
}
```

**Get-AzureRmAutoscaleSetting**
- Output change: The AutoscaleSettingResourceName field will be deprecated since it always equals the Name field.

```powershell
# Old
$s1 = Get-AzureRmAutoscaleSetting -ResourceGroup $resourceGroup -Name MySetting
if ($s1.AutoscaleSettingResourceName -ne $s1.Name)
{
	Write-Host "There is something wrong with the name"
}

# New
$s1 = Get-AzureRmAutoscaleSetting -ResourceGroup $resourceGroup -Name MySetting
    
# there won't be a AutoscaleSettingResourceName
Write-Host $s1.Name    
```

**Remove-AzureRmAlertRule** / **Remove-AzureRmLogProfile**
- Output change: The type of the output will change to return a single object containing the request Id and the status code.

```powershell
# Old
$s1 = Remove-AzureRmAlertRule -ResourceGroup $resourceGroup -name $ruleName
if ($s1 -ne $null)
{
	$r = $s1[0].RequestId
	$s = $s1[0].StatusCode
}

# New
$s1 = Remove-AzureRmAlertRule -ResourceGroup $resourceGroup -name $ruleName
$r = $s1.RequestId
$s = $s1.StatusCode
```