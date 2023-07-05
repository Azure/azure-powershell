### Example 1: Create an in-memory object for NamespaceJunction.
```powershell
New-AzStorageCacheNamespaceJunctionObject -NamespacePath "/path/on/cache" -NfsAccessPolicy "default" -NfsExport "exp2" -TargetPath "/path/on/exp1"
```

```output
NamespacePath  NfsAccessPolicy NfsExport TargetPath
-------------  --------------- --------- ----------
/path/on/cache default         exp2      /path/on/exp1
```

Create an in-memory object for NamespaceJunction.