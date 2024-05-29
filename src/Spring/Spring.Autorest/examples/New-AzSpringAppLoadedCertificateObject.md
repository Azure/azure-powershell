### Example 1: Create an in-memory object for LoadedCertificate.
```powershell
New-AzSpringAppLoadedCertificateObject -ResourceId "resourceId" -LoadTrustStore:$true
```

```output
LoadTrustStore ResourceId
-------------- ----------
          True resourceId
```

Create an in-memory object for LoadedCertificate.