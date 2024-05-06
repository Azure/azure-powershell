### Example 1: List properties of verified partner.
```powershell
Get-AzEventGridVerifiedPartner
```

```output
Name              ResourceGroupName
----              -----------------
Auth0
MicrosoftGraphAPI
SAP
TribalGroup
```

List properties of verified partner.

### Example 2: Get properties of a verified partner.
```powershell
Get-AzEventGridVerifiedPartner -Name MicrosoftGraphAPI
```

```output
Name              ResourceGroupName
----              -----------------
MicrosoftGraphAPI
```

Get properties of a verified partner.