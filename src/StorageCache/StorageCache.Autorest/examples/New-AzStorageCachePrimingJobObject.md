### Example 1: Create an in-memory object for PrimingJob.
```powershell
New-AzStorageCachePrimingJobObject -Name azps-primingjob -PrimingManifestUrl "https://contosostorage.blob.core.windows.net/contosoblob/00000000_00000000000000000000000000000000.00000000000.FFFFFFFF.00000000?sp=r&st=2021-08-11T19:33:35Z&se=2021-08-12T03:33:35Z&spr=https&sv=2020-08-04&sr=b&sig=<secret-value-from-key>"
```

```output
Detail Name            PercentComplete PrimingManifestUrl
------ ----            --------------- ------------------
       azps-primingjob                 https://contosostorage.blo...
```

Create an in-memory object for PrimingJob.