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

## Release 5.0.0 - November 2017

The following cmdlets were affected this release:

**New-AzureRmBatchCertificate**
- Parameter "Password" being replaced in favor of a Secure string

```powershell

# Old
# New-AzureRmBatchCertificate [other required parameters] -Password "plain-text string"

# New
# New-AzureRmBatchCertificate [other required parameters] -Password $SecureStringVariable
```

**New-AzureRmBatchComputeNodeUser**
- Parameter "Password" being replaced in favor of a Secure string

```powershell

# Old
# New-AzureRmBatchComputeNodeUser [other required parameters] -Password "plain-text string"

# New
# New-AzureRmBatchComputeNodeUser [other required parameters] -Password $SecureStringVariable
```

**Set-AzureRmBatchComputeNodeUser**
- Parameter "Password" being replaced in favor of a Secure string

```powershell

# Old
# Set-AzureRmBatchComputeNodeUser [other required parameters] -Password "plain-text string"

# New
# Set-AzureRmBatchComputeNodeUser [other required parameters] -Password $SecureStringVariable
```