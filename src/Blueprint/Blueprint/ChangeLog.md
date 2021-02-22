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
* Added a fix to unregister the API delegating handler from blueprint client

## Version 0.2.13
* Updated Blueprint .NET SDK version

## Version 0.2.12
* Added support for management group level Blueprint assignment

## Version 0.2.11
* Showed DependsOn property value in the table view
* Added support to accept PolicyDefinitionParameter empty 

## Version 0.2.10
* Added support to include subfolders when deploying blueprints with artifacts

## Version 0.2.9
* Update references in .psd1 to use relative path

## Version 0.2.8
* Bug Fix: File/folder names should be platform agnostic for Export/Import cmdlets

## Version 0.2.7
* Bug Fix: Use user assigned identity defined in the assignment file instead of cmdlet parameter during blueprint assignment (Set- cmdlet).
* Update module version information in the .psd1 file

## Version 0.2.6
* Bug Fix: Use user assigned identity defined in the assignment file instead of cmdlet parameter during blueprint assignment.

## Version 0.2.5
* Add functionality to make sure Blueprint RP is registered before any service calls

## Version 0.2.4
* Fixed miscellaneous typos across module
* Bug fix (Get-AzBlueprint should work on national clouds)

## Version 0.2.3
- Bug fixes and help message improvements

## Version 0.2.2
- Add change note support during publishing of a blueprint
- Update Blueprint SDK version
- Bug fixes

## Version 0.2.1
* Bug fixes and improvements

## Version 0.2.0
* Added new cmdlets:
    - New-AzBlueprint
    - Set-AzBlueprint
    - Publish-AzBlueprint
    - New-AzBlueprintArtifact
    - Set-AzBlueprintArtifact
    - Get-AzBlueprintArtifact
    - Export-AzBlueprintWithArtifact
    - Import-AzBlueprintWithArtifact'

## Version 0.1.1
* Update Remove- cmdlet to not require SubscriptionId parameter
* Update cmdlet examples
* Update Blueprint .NET SDK version
* Support secure strings as assignment parameters
* Support WhoIsBlueprint
     - Get AAD ObjectId of the Blueprints service principal in the tenant

## Version 0.1.0
* Preview release of Az.Blueprint module
