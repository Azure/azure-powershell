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

* deprecated cmdlets: `Get-AzBatchCertificate` and `New-AzBatchCertificate`
  - The Batch account certificates feature is deprecated. Please transition to using Azure Key Vault to securely access and install certificates on your Batch pools, [learn more](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide)