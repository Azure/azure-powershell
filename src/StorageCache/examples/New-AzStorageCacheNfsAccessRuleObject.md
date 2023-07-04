### Example 1: Create an in-memory object for NfsAccessRule.
```powershell
New-AzStorageCacheNfsAccessRuleObject -Access 'rw' -Scope 'network' -AnonymousUid "65534" -AnonymousGid "65534" -SubmountAccess:$True -RootSquash:$True -Suid:$False -Filter "10.99.1.0/24"
```

```output
Access AnonymousGid AnonymousUid Filter       RootSquash Scope   SubmountAccess Suid
------ ------------ ------------ ------       ---------- -----   -------------- ----
rw     65534        65534        10.99.1.0/24 True       network True           False
```

Create an in-memory object for NfsAccessRule.