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
* Preview release of API version 2026-03-01-preview for Az.DeviceRegistry. New cmdlets include:
    - `Get-AzDeviceRegistryCredentials`: Get a Credential for a namespace
    - `New-AzDeviceRegistryCredentials`: Create a Credential for a namespace
    - `Update-AzDeviceRegistryCredentials`: Update a Credential for a namespace
    - `Remove-AzDeviceRegistryCredentials`: Delete a Credential for a namespace
    - `Sync-AzDeviceRegistryCredentials`: Synchronize credentials for a namespace
    - `Get-AzDeviceRegistryPolicy`: Get a Policy for a namespace
    - `New-AzDeviceRegistryPolicy`: Create a Policy for a namespace
    - `Update-AzDeviceRegistryPolicy`: Update a Policy for a namespace
    - `Remove-AzDeviceRegistryPolicy`: Remove a Policy for a namespace
    - `Initialize-AzDeviceRegistryPolicyBringYourOwnRoot`: Initialize a bring-your-own-root policy
    - `Revoke-AzDeviceRegistryPolicyIssuer`: Revoke a policy issuer
    - `Revoke-AzDeviceRegistryNamespaceDevice`: Revoke a namespace device

## Version 1.0.0
* General availability for module Az.DeviceRegistry

* GA stable release of API version 2025-10-01 for Az.DeviceRegistry. New updates include:
    - Schema and Schema Version asynchronous delete. No longer synchronous.
    - Namespace Asset and Namespace Discovered Asset EventGroups.
    - Namespace Device x509 certificate authentication now supports intermediate certificates and key secret names.

## Version 0.2.0
* Public preview release of API version 2025-07-01-preview for Az.DeviceRegistry. New resources included:
    - Schema Registry
    - Schema 
    - Schema Version
    - Namespaces
    - Namespace Asset
    - Namespace Device
    - Namespace Discovered Asset
    - Namespace Discovered Device
* Support for Move-AzDeviceRegistryNamespace to migrate Asset and AssetEndpointProfile resources under a specified Namespace as Namespace Assets and Namespace Devices.

## Version 0.1.1
* Fixed module name in module metadata

## Version 0.1.0
* Upgraded nuget package to signed package.

## Version 0.1.0
* First preview release for module Az.DeviceRegistry

