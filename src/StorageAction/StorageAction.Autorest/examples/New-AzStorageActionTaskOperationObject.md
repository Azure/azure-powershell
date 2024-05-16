### Example 1: Create a operation object
```powershell
New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue | Format-List
```

```output
Name      : SetBlobTier
OnFailure : break
OnSuccess : continue
Parameter : {
              "tier": "Hot"
            }
```

This command creates a operation object.