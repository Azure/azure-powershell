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

## Release 6.0.0 - Nov 2018
The following properties were affected by this release:

**SnapshotInfo**
- The snapshotInfo property on the Site object is deprecated and will be removed.

**AppServicePlanName**
- The AppServicePlanName property on the AppServicePlan object is deprecated and will be removed.

**GeoRegion**
- The GeoRegion property on the Certificate object is deprecated and wil be removed.

**IgnoreQuotas**
- The IgnoreQuotas property on the CloningInfo object is deprecated and will be removed.

## Release 6.0.0 - May 2018


The following cmdlets were affected by this release:

## Release 6.0.0 - May 2018

**New-AzureRmAppServicePlan**
- Output type changed from ServerFarmWithRichSku to AppServicePlan

**Get-AzureRmWebApp**
- AppServicePlan parameter type changed from ServerFarmWithRichSku to AppServicePlan