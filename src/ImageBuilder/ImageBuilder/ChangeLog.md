<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release

## Version 0.5.0
* Introduced various new features by upgrading code generator. Please see details [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).
* Set parameter 'JsonFilePath' for cmdlet `New-AzImageBuilderTemplate` alias 'JsonTemplatePath'.
* Removed cmdlet `Update-AzImageBuilderTemplate`. Please see the details [here](https://learn.microsoft.com/en-us/azure/virtual-machines/linux/image-builder-troubleshoot#update-or-upgrade-of-image-templates-is-currently-not-supported).
* Updated `New-AzImageBuilderTemplate` to support for new Managed Identity setting.
  * Keep alias `UserAssignedIdentityId` for parameter `UserAssignedIdentity`. The type of `UserAssignedIdentity` is simplified to an array of strings that is used to specify the user's assigned identity.

## Version 0.4.2
* Upgraded nuget package to signed package.

## Version 0.4.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.4.0
*  Upgraded API version from 2022-02-14 to 2022-07-01.
   - Added a cmdlet named `Get-AzImageBuilderTrigger`.
   - Added a cmdlet named `New-AzImageBuilderTemplateDistributeVersionerLatestObject` to create an in-memory object for DistributeVersionerLatest.
   - Added a cmdlet named `New-AzImageBuilderTemplateDistributeVersionerSourceObject` to create an in-memory object for DistributeVersionerSource.
   - Added a cmdlet named `New-AzImageBuilderTrigger`.
   - Added a cmdlet named `Update-AzImageBuilderTemplate`.
   - Added a cmdlet named `Remove-AzImageBuilderTrigger`.

## Version 0.3.0
*  Upgraded API version from 2020-02-14 to 2022-02-14.
    - Supported parameter `replicationRegions` in JSON file for `New-AzImageBuilderTemplate`. [#18924]
    - Added parameter `VMProfileUserAssignedIdentity` in `New-AzImageBuilderTemplate`. [#17273]
    - Added a cmdlet named `New-AzImageBuilderTemplateValidatorObject` to create an in-memory object for ImageTemplateValidator.
*  Renamed `Get-AzImageBuilderRunOutput` to `Get-AzImageBuilderTemplateRunOutput`.
*  Renamed `New-AzImageBuilderCustomizerObject` to `New-AzImageBuilderTemplateCustomizerObject`.
*  Renamed `New-AzImageBuilderDistributorObject` to `New-AzImageBuilderTemplateDistributorObject`
*  Renamed `New-AzImageBuilderSourceObject` to `New-AzImageBuilderTemplateSourceObject`.

## Version 0.2.0
* Added support for runAsSystem parameter in `New-AzImageBuilderCustomizerObject` [#13163]
* Added support to create template basing on imported json in `New-AzImageBuilderTemplate`. [#12634]

## Version 0.1.2
* Removed `Sha256Checksum` parameter from example of `New-AzImageBuilderCustomizerObject`.

## Version 0.1.1
* Made `Sha256Checksum` optional in `New-AzImageBuilderCustomizerObject`.

## Version 0.1.0
* the first preview release

