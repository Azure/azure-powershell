# Upcoming Breaking Changes

## Release X.0.0 - May 2018

The following cmdlets were affected this release:

**Update-AzAvailabilitySet**
- Switch parameter, Managed, will be replaced with Sku parameter.
In order to set a managed availability set, a user should give Sku parameter with 'Aligned' value.

```powershell
# Old
Update-AzAvailabilitySet -Managed

# New
Update-AzAvailabilitySet -Sku 'Aligned'
```

**Update-AzImage**
- Image parameter will be removed for the parameter set when ResourceGroupName and ImageName are given.

**Save-AzImage**
- Name will be removed from the Id parameter set.

**Restart-AzVM**
- Name will be removed from the Id parameter set.

**Set-AzVM**
- Name will be removed from the Id parameter set.

**Start-AzVM**
- Name will be removed from the Id parameter set.

**Remove-AzVM**
- Name will be removed from the Id parameter set.

**Stop-AzVM**
- Name will be removed from the Id parameter set.

**New-AzDiskConfig**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
- HyperVGeneration property will be added.
- DiskState property will be added.

**Set-AzDiskDiskEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
- HyperVGeneration property will be added.
- DiskState property will be added.

**Set-AzDiskKeyEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
- HyperVGeneration property will be added.
- DiskState property will be added.

**New-AzDiskUpdateConfig**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.

**Set-AzDiskUpdateDiskEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.

**Set-AzDiskUpdateKeyEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.

**New-AzSnapshotConfig**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
- HyperVGeneration property will be added.

**Set-AzSnapshotDiskEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
- HyperVGeneration property will be added.

**Set-AzSnapshotKeyEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
- HyperVGeneration property will be added.

**New-AzSnapshotUpdateConfig**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.

**Set-AzSnapshotUpdateDiskEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.

**Set-AzSnapshotUpdateKeyEncryptionKey**
- EncryptionSettings property in the cmdlet output will be deprecated.  It will be replaced with EncryptionSettingsCollection.
- EncryptionSettings.Enabled will be replaced with EncryptionSettingsCollection.Enabled.
- EncryptionSettings.DiskEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].DiskEncryptionKey.
- EncryptionSettings.KeyEncryptionKey will be replaced with EncryptionSettingsCollection.EncryptionSettings[0].KeyEncryptionKey.
- EncryptionSettingsCollection supports a list of EncryptionSettings.
