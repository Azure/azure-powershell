<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected by this release:

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
## Release 6.0.0 - May 2018

The following cmdlets were affected by this release:

**Get-AzureRmAppServicePlan**
- Output type changed from ServerFarmWithRichSku to AppServicePlan

**Set-AzureRmAppServicePlan**
- Output type changed from ServerFarmWithRichSku to AppServicePlan

**New-AzureRmAppServicePlan**
- Output type changed from ServerFarmWithRichSku to AppServicePlan

**Get-AzureRmWebApp**
- AppServicePlan parameter type changed from ServerFarmWithRichSku to AppServicePlan