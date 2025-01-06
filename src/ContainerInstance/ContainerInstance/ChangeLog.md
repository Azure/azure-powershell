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
* Added breaking change warning for removing default value for OsType `New-AzContainerGroup`

## Version 4.1.0
* Added ContainerGroupProfileId ContainerGroupProfileRevision StandbyPoolProfileFailContainerGroupCreateOnReuseFailure StandbyPoolProfileId to Container Group properties.
* Added ConfigMapKeyValuePair to Container object properties.
* Added new cmdlet to define container without using the preset default properties New-AzContainerInstanceNoDefaultObject
* Added new cmdlets for Container Group Profile - Get-AzContainerInstanceContainerGroupProfile, New-AzContainerInstanceContainerGroupProfile, Remove-AzContainerInstanceContainerGroupProfile, Update-AzContainerInstanceContainerGroupProfile, Get-AzContainerInstanceContainerGroupProfileRevision

## Version 4.0.2
* Fixed secrets exposure in example documentation.

## Version 4.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 4.0.0
* [Breaking Change] Fixed the typo that output property starting with PreviousState was misspelled as PreviouState. [#22268]

## Version 3.2.2
* Added breaking change warning message for `Get/New/Remove-ContainerGroup`, `New-ContainerInstanceInitDefinitionObject`, `New-ContainerInstanceObject` [#22268]
    - Output properties starting with `PreviouState` will be corrected to `PreviousState`

## Version 3.2.1
* Fixed a bug in `Invoke-AzContainerInstanceCommand` when no result was returned under some conditions [#22453]

## Version 3.2.0
* Added `priority` property to Container Group properties
* Added `Confidential` sku type to Container Group Skus

## Version 3.1.0
* Supported empty directory volume and secret volume for creating container group [#17410]

## Version 3.0.1
* Fixed Identity Bug in ImageRegistryCredential

## Version 3.0.0
* Upgraded API version to 2021-09-01
  - [Breaking Change] Changed the type of parameter `LogAnalyticWorkspaceResourceId` in `New-AzContainerGroup` from Hashtable to String
  - [Breaking Change] Removed parameter `NetworkProfileId` in `New-AzContainerGroup`, added `SubnetId` as its alternative
  - [Breaking Change] Removed parameter `ReadinessProbeHttpGetHttpHeadersName` and `ReadinessProbeHttpGetHttpHeadersValue` in `New-AzContainerInstanceObject`, added `ReadinessProbeHttpGetHttpHeader` as their alternative
  - [Breaking Change] Removed parameter `LivenessProbeHttpGetHttpHeadersName` and `LivenessProbeHttpGetHttpHeadersValue` in `New-AzContainerInstanceObject`, added `LivenessProbeHttpGetHttpHeader` as their alternative
  - Added `Zone` in `New-AzContainerGroup`, `AcrIdentity` in `New-AzContainerGroupImageRegistryCredentialObject`
  - Changed `Username` in `New-AzContainerGroupImageRegistryCredentialObject` from mandatory to optional
* For `Invoke-AzContainerInstanceCommand`
    - [Breaking Change] Displayed command execution result as the cmdlet output by connecting websocket in backend [#15754]
    - Added `-PassThru` to get last execution result when the command succeeds
    - Changed `TerminalSizeCol` and `TerminalSizeRow` from mandatory to optional, set their default values by current PowerShell window size
* Added `Restart-AzContainerGroup`, `Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint` and `New-AzContainerInstanceHttpHeaderObject`

## Version 2.1.0
* Removed the display of file share credential [#15224]

## Version 2.0.0
* Added new cmdlets: `Start-AzContainerGroup`, `Stop-AzContainerGroup` [#10773], `Invoke-AzContainerInstanceCommand` [#7648], `Update-AzContainerGroup`, `Add-AzContainerInstanceOutput`, `Get-AzContainerInstanceCachedImage`, `Get-AzContainerInstanceCapability`, `Get-AzContainerInstanceUsage`, `New-AzContainerGroupImageRegistryCredentialObject`, `New-AzContainerGroupPortObject`, `New-AzContainerGroupVolumeObject`, `New-AzContainerInstanceEnvironmentVariableObject`, `New-AzContainerInstanceInitDefinitionObject`, `New-AzContainerInstanceObject`, `New-AzContainerInstancePortObject` and `New-AzContainerInstanceVolumeMountObject`
* Supported Log Analytics parameters in `New-AzContainerGroup` [#11117]
* Added support to specify network profile and the name of Azure File Share in `New-AzContainerGroup` [#9993] [#12218]
* Added support to specify environment variables as SecureValue [#10110] [#10640]

## Version 1.0.3
* Fixed parameter names used by example of New-AzContainerGroup

## Version 1.0.2
* Update references in .psd1 to use relative path

## Version 1.0.1
* Fixed issue in the -Command parameter of New-AzContainerGroup which added a trailing empty argument

## Version 1.0.0
* General availability of `Az.ContainerInstance` module
* Added managed identity support
