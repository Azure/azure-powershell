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
**Export-AzureRmDataLakeStoreItem**
- Parameters Resume, PerFileThreadCount are deprecated. Will be removed in future releases.
```powershell
# Old
# Export-AzureRmDataLakeStoreItem -Account contoso -Path /test -Destination C:\test -Recurse -Resume -PerFileThreadCount 2 -ConcurrentFileCount 80
# New
# Export-AzureRmDataLakeStoreItem -Account contoso -Path /test -Destination C:\test -Recurse -ConcurrentFileCount 160
```
**Import-AzureRmDataLakeStoreItem**
- Parameters Resume, PerFileThreadCount, ForceBinary are deprecated. Will be removed in future releases.
```powershell
# Old
# Import-AzureRmDataLakeStoreItem -Account contoso -Path C:\test -Destination /test -Recurse -Resume -ForceBinary -PerFileThreadCount 2 -ConcurrentFileCount 80
# New
# Import-AzureRmDataLakeStoreItem -Account contoso -Path C:\test -Destination /test -Recurse -ConcurrentFileCount 160
```