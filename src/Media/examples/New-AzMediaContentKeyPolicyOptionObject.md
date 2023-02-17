### Example 1: Create an in-memory object for ContentKeyPolicyOption.
```powershell
New-AzMediaContentKeyPolicyOptionObject -ConfigurationOdataType "#Microsoft.Media.ContentKeyPolicyWidevineConfiguration" -RestrictionOdataType "#Microsoft.Media.ContentKeyPolicyOpenRestriction" -Name "widevineoption"
```

```output
Name           PolicyOptionId
----           --------------
widevineoption
```

Create an in-memory object for ContentKeyPolicyOption.