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

  ## Release 5.0.0 - November 2017

    The following cmdlets were affected this release:

    **Add-AzureRMLogAlertRule**
    - Deprecated as announced since April 2017
    - After October 1st using this cmdlet no longer had any effect as this functionality was transitioned to Activity Log Alerts. Please see https://aka.ms/migratemealerts for more information.

    **Get-AzureRMUsage**
    - Deprecated as announced since April 2017

    **Get-AzureRmAlertRule**
    - Output changed as announced since April 2017. The output is now a list of PSAlertRule (descendant of AzureAlertRule) objects. The objects are flatten, i.e.: all attributes are in the root of the object, no Properties attribute in them.

    **Remove-AzureRmAlertRule**
    **Remove-AzureRmLogProfile**
    - Output changed as announced since April 2017. The output is now an AzureOperationResponse object including status code and request Id.

    **Get-AzureRmAutoscaleSetting**
    - Output changed as announced since April 2017. The output is now a list of PSAutoscaleSetting (descendant of AutoscaleSettingResource.) The breaking change is the elimination of the AutoscaleSettingResourceName attribute from the output, since it is always the same as the Name property.

    **Get-AzureRmLog**
    **Get-AzureRmAlertHistory**
    **GetAzureRmAutoscaleHistory**
    - Output changed as announced since April 2017. The output is now a list of PSEventData (a descendant of EventData) objects. The breaking change is the elimination of the EventChannels attribute from the PSEventData, in the previous version it was returning a fixed value.
