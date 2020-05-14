<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

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

The following cmdlets were affected this release:

**Get-AzBatchApplication**
 - Removed `ApplicationPackages` property from `PSApplication` returned by the **Get-AzBatchApplication** cmdlet. This property was previously always `$null`.
 - The specific packages inside of an application now can be retrieved using **Get-AzBatchApplicationPackage**. For example: `Get-AzBatchApplication -AccountName myaccount -ResourceGroupName myresourcegroup -ApplicationId myapplication`.

**New-AzBatchPool**
- When creating a pool using **New-AzBatchPool**, the `VirtualMachineImageId` property of `PSImageReference` can now only refer to a Shared Image Gallery image.
- When creating a pool using **New-AzBatchPool**, the pool can be provisioned without a public IP using the new `PublicIPAddressConfiguration` property of `PSNetworkConfiguration`.
  - The `PublicIPs` property of `PSNetworkConfiguration` has moved in to `PSPublicIPAddressConfiguration` as well. This property can only be specified if `IPAddressProvisioningType` is `UserManaged`.