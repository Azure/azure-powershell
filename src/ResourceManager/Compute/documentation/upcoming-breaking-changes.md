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

## Release X.0.0 - May 2018

The following cmdlets were affected this release:

**New-AzureRmVMConfig**
**Update-AzureRmVM**
**New-AzureRmVmssConfig**
- Switch parameter, AssignIdentity, will be replaced with IdentityType parameter which takes a value from 'SystemAssigned', 'UserAssigned', 'SystemAssignedUserAssinged', and 'None'.
Previously, only 'SystemAssigned' identity type was available, and AssignIdentity parameter sets 'SystemAssigned' identity.  
Now, more types of identities are available, so new parameter 'IdentityType' is introduced and will replace 'AssignIdentity' parameter.

```powershell
# Old
# New-AzureRmVMConfig -AssignIdentity
# New-AzureRmVmssConfig -AssignIdentity


# New
# New-AzureRmVMConfig -IdentityType 'SystemAssigned'
# New-AzureRmVmssConfig -IdentityType 'SystemAssigned'
```

**New-AzureRmAvailabilitySet**
- Switch parameter, Managed, will be replaced with Sku parameter.
In order to set a managed availability set, a user should give Sku parameter with 'Aligned' value.

```powershell
# Old
# New-AzureRmAvailabilitySet -Managed


# New
# New-AzureRmAvailabilitySet -Sku 'Aligned'