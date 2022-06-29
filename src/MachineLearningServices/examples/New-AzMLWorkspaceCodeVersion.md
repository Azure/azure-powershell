### Example 1: Create or update code version
```powershell
New-AzMLWorkspaceCodeVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name 'cli-hello-example' -Version 1 -CodeUri "https://mlworkspacepor8056718628.blob.core.windows.net/azureml-blobstore-dc0f7f2b-686d-417b-a456-6c09def791f5/LocalUpload/a8da6e3978c9f8b1cb03501595a9142f/src"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    5/24/2022 7:14:05 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 7:14:05 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Create or update code version
