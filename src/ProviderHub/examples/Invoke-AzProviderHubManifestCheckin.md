### Example 1: Checkin the resource provider manifest.
```powershell
<<<<<<< HEAD
Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"
```

```output
=======
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged.
```

Checkin the resource provider manifest.

### Example 2: Checkin the resource provider manifest.
```powershell
<<<<<<< HEAD
Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"
```

```output
=======
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged.
```

Checkin the resource provider manifest.
