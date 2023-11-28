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

## Version 1.7.1
* Fixed an issue regarding Custom Managed Key.[#22463] [#22898]

## Version 1.7.0
* Added some parameters in `Update-AzDatabricksWorkspace`:
    - `EnableNoPublicIP`
    - `PublicNetworkAccess`

## Version 1.6.0
* Added some parameters in the `New-AzDatabricksWorkspace` and `Update-AzDatabricksWorkspace`.
    - `ManagedDiskKeyVaultPropertiesKeyName`
    - `ManagedDiskKeyVaultPropertiesKeyVaultUri`
    - `ManagedDiskKeyVaultPropertiesKeyVersion`
    - `ManagedDiskRotationToLatestKeyVersionEnabled`
    - `ManagedServicesKeyVaultPropertiesKeyName`
    - `ManagedServicesKeyVaultPropertiesKeyVaultUri`
    - `ManagedServicesKeyVaultPropertiesKeyVersion`
    - `Authorization`
    - `UiDefinitionUri`
* Added some parameters in the `Update-AzDatabricksVNetPeering`.
    - `DatabricksAddressSpacePrefix`
    - `DatabricksVirtualNetworkId`
    - `RemoteAddressSpacePrefix`
    - `RemoteVirtualNetworkId` 

## Version 1.5.1
* Fixed an issue that `Update-AzDatabricksWorkspace` doesn't work as expected while enabling encryption. [#21324]

## Version 1.5.0
* Upgraded API version to 2023-02-01

## Version 1.4.0
* Added `RequiredNsgRule` parameter in the `Update-AzDatabricksWorkspace`.

## Version 1.3.0
* Upgraded API version to 2022-04-01-preview
* Modified description of `EnableNoPublicIP` parameter in the `New-AzDatabricksWorkspace`. [#14381]

## Version 1.2.0
* Upgraded API version to 2021-04-01-preview

## Version 1.1.0
* Supported -EnableNoPublicIP when creating a Databricks workspace

## Version 1.0.2
* Fixed an issue that may cause `New-AzDatabricksVNetPeering` to return before it is fully provisioned (https://github.com/Azure/autorest.powershell/issues/610)

## Version 1.0.1
* Fixed a bug that may cause updating databricks workspace without `-EncryptionKeyVersion` to fail.

## Version 1.0.0
* General availability of 'Az.Databricks' module
* Added support for virtual network peering

## Version 0.2.0
* Added support for DBFS Double Encryption Support

## Version 0.1.1
* Added support for customer-managed keys

## Version 0.1.0
* the first preview release

