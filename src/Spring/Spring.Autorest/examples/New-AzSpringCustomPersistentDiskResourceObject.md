### Example 1: Create an in-memory object for CustomPersistentDiskResource.
```powershell
New-AzSpringCustomPersistentDiskResourceObject -StorageId "storageId" -CustomPersistentDiskPropertyEnableSubPath:$true -CustomPersistentDiskPropertyMountOption "string" -CustomPersistentDiskPropertyMountPath "string" -CustomPersistentDiskPropertyReadOnly:$true
```

```output
CustomPersistentDiskProperty              : {
                                              "type": "AzureFileVolume",
                                              "mountPath": "string",
                                              "readOnly": true,
                                              "enableSubPath": true,
                                              "mountOptions": [ "string" ]
                                            }
CustomPersistentDiskPropertyEnableSubPath : True
CustomPersistentDiskPropertyMountOption   : {string}
CustomPersistentDiskPropertyMountPath     : string
CustomPersistentDiskPropertyReadOnly      : True
CustomPersistentDiskPropertyType          : AzureFileVolume
StorageId                                 : storageId
```

Create an in-memory object for CustomPersistentDiskResource.