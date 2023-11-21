### Example 1: Create an in-memory object for NfsAccessPolicy.
```powershell
$objcet = New-AzStorageCacheNfsAccessRuleObject -Access 'rw' -Scope 'network' -AnonymousUid "65534" -AnonymousGid "65534" -SubmountAccess:$True -RootSquash:$True -Suid:$False -Filter "10.99.1.0/24"
New-AzStorageCacheNfsAccessPolicyObject -AccessRule $object -Name azps-nfsaccesspolicy
```

```output
Name
----
azps-nfsaccesspolicy
```

Create an in-memory object for NfsAccessPolicy.