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
