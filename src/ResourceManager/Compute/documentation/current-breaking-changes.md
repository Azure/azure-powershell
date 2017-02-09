<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes
**Set-AzureVMDSCExtension**
    - WmfVersion parameter of this cmdlet no longer supports "5.1PP". 

    ```powershell
    # Old
    # Set-AzureVMDSCExtension -WmfVersion 5.1PP -VM $vm -ConfigurationArchive archive.ps1.zip -ConfigurationName name

    # New
    # Set-AzureVMDSCExtension -WmfVersion 5.1 -VM $vm -ConfigurationArchive archive.ps1.zip -ConfigurationName name
    ```

    **Set-AzureRmVMDSCExtension**
    - WmfVersion parameter of this cmdlet no longer supports "5.1PP". 

    ```powershell
    # Old
    # Set-AzureRmVMDSCExtension -ResourceGroupName "rg1" -VMName "vmname" -ArchiveBlobName "Sample.ps1.zip" -ArchiveStorageAccountName "Stg" -ConfigurationName "ConfigName" -Version "X.Y" -Location "West US" -WmfVersion 5.1PP

    # New
    # Set-AzureRmVMDSCExtension -ResourceGroupName "rg1" -VMName "vmname" -ArchiveBlobName "Sample.ps1.zip" -ArchiveStorageAccountName "Stg" -ConfigurationName "ConfigName" -Version "X.Y" -Location "West US" -WmfVersion 5.1
    ```