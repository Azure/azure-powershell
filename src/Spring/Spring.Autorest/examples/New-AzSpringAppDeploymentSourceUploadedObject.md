### Example 1: Create an in-memory object for SourceUploadedUserSourceInfo.
```powershell
New-AzSpringAppDeploymentSourceUploadedObject -ArtifactSelector sub-module-1 -RuntimeVersion 1.0 -RelativePath "resources/a172cedcae47474b615c54d510a5d84a8dea3032e958587430b413538be3f333-2019082605-e3095339-1723-44b7-8b5e-31b1003978bc" -Version 1.0
```

```output
ArtifactSelector : sub-module-1
RelativePath     : resources/a172cedcae47474b615c54d510a5d84a8dea3032e958587430b413538be3f333-2019082605-e3095339-1723-44b7-8b5e-31b1003978bc
RuntimeVersion   : 1.0
Type             : Source
Version          : 1.0
```

Create an in-memory object for SourceUploadedUserSourceInfo.