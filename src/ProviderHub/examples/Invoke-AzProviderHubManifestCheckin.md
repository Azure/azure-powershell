### Example 1: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"
```

CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged. Use the Default/Custom rollout (http://aka.ms/rpaasrollout) to roll out the manifest.

Checkin the resource provider manifest.

### Example 2: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"
```

CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged. Use the Default/Custom rollout (http://aka.ms/rpaasrollout) to roll out the manifest.

Checkin the resource provider manifest.
