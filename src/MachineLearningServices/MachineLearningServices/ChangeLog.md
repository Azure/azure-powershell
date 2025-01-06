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
* upgraded nuget package to signed package.

## Version 1.1.0
* Updated API version to 2024-04-01
* Added Kind and HubResourceId parameters for Workspace cmdlets
* Fixed batch deployment creation issue
* Fixed Connection creation issue
* Added Connection Properties object cmdlets for connection creation
    - `New-AzMLWorkspaceAadAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceAccessKeyAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceAccountKeyAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceApiKeyAuthWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceCustomKeysWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceNoneAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceOAuth2AuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspacePatAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceSasAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceServicePrincipalAuthTypeWorkspaceConnectionPropertiesObject`
    - `New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject`
* Added Model reference object cmdlets for batch deployment creation
    - `New-AzMLWorkspaceIdAssetReferenceObject`
    - `New-AzMLWorkspaceDataPathAssetReferenceObject`
    - `New-AzMLWorkspaceOutputPathAssetReferenceObject`

## Version 1.0.1
* Removed the outdated deps.json file.

## Version 1.0.0
* General availability for module Az.MachineLearningServices

## Version 0.1.0
* First preview release for module Az.MachineLearningServices

