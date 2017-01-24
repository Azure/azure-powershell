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
## 
Default parameter set for Get-AzureRmOperationalInsightsDataSource will be deprecated and change to ByWorkspaceNameByKind.
```powershell
# Old (which does nothing)
Get-AzureRmOperationalInsightsDataSource 

# New
Get-AzureRmOperationalInsightsDataSource -ResourceGroupName "resourceGroupA" -WorkspaceName "LogAnalyticsWorkspace" -Kind AzureActivityLog
```

AzureAuditLog will be removed from parameter Kind for Get-AzureRmOperationalInsightsDataSource, you should switch to AzureActivityLog.
```powershell
# Old
Get-AzureRmOperationalInsightsDataSource -ResourceGroupName "resourceGroupA" -WorkspaceName "LogAnalyticsWorkspace" -Kind AzureAuditLog

# New
Get-AzureRmOperationalInsightsDataSource -ResourceGroupName "resourceGroupA" -WorkspaceName "LogAnalyticsWorkspace" -Kind AzureActivityLog
```