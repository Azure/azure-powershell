## Storage.Management

### StorageAccount

* `Get-AzStorageAccount`
    - [ ] Hide `Get-AzStorageAccountProperty`
    - [ ] Add `-Name` and use `Get-AzStorageAccountProperty`
* `Set-AzStorageAccount`
    - [x] Change name to `Invoke-AzStorageAccountFailover` or something else
* `Update-AzStorageAccount`
    - [x] Rename to `Set-AzStorageAccount`
    - [ ] Return results after calling `GetProperties`
    - [ ] Implemente as a PUT
    - [ ] Add two new parameter sets: Make `-KeyvaultEncryption` become two boolean parameters -- `-StorageEncryption` and `-KeyvaultEncryption` ?
    - [ ] Add `-AssignIdentity` that resets `Identity`
    - [ ] Rename the parameter prefix `NetworkAcls` to `NetworkRuleSet`?
    - [ ] Add `-UpgradeToStorageV2` and hide `-Kind` ?
    - [ ] Implement `-Force` and `-AsJob`
* `New-AzStorageAccount`
    - [ ] Uses `NameAvailability` before creating
    - [ ] Return results after calling `GetProperties`
    - [ ] Add `-AssignIdentity` that resets `Identity`
    - [ ] Rename the parameter prefix `NetworkAcls` to `NetworkRuleSet`?
    - [ ] `-IsHnsEnabled` -> `-EnableHierarchicalNamespace`?
* `Remove-AzStorageAccount`
    - [ ] Implement `-Force` and `-AsJob`
* `Set-AzStorageAccountManagementPolicy`
    - [ ] Parameter of type `IManagementPolicy` not being correclty expanded
- [ ] Determine if the lack of in-memory creation cmdlets for `NetworkRuleSet` and `ManagementPolicy*` is not a problem
    - Check the file `resources/comparing_modules_notes.md` for more info.

### Blobs or Storage Container

* `Set-AzStorageBlobServiceProperty`
    - [ ] Rename it to `Update` and mimic a PATCH call.
* `Set-AzRmStorageContainerImmutabilityPolicy`
    - [ ] Add `-ExtendedPolicy` switch parameter that invokes `Invoke-AzExtendBlobContainerImmutabilityPolicy`

### Optional

- [ ] Create `Set-AzCurrentStorageAccount`
