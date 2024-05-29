### Example 1: Create an in-memory object for NetCoreZipUploadedUserSourceInfo.
```powershell
New-AzSpringAppDeploymentNetCoreZipUploadedObject -NetCoreMainEntryPath aaa -RuntimeVersion 1.0 -RelativePath abc/anc -Version 1.2
```

```output
NetCoreMainEntryPath : aaa
RelativePath         : abc/anc
RuntimeVersion       : 1.0
Type                 : NetCoreZip
Version              : 1.2
```

Create an in-memory object for NetCoreZipUploadedUserSourceInfo.