### Example 1: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"

CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged.
```

Checkin the resource provider manifest.

### Example 2: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"

CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged.
```

Checkin the resource provider manifest.
