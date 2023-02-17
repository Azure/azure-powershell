### Example 1: List the details of Content Key Policy in the Media Services account by Media Name.
```powershell
Get-AzMediaContentKeyPolicy -AccountName azpsms -ResourceGroupName azps_test_group
```

```output
Name                    ResourceGroupName
----                    -----------------
azpsms-contentkeypolicy azps_test_group
```

List the details of Content Key Policy in the Media Services account by Media Name.

### Example 2: Get the details of a Content Key Policy in the Media Services account by ConteneKey Name.
```powershell
Get-AzMediaContentKeyPolicy -AccountName azpsms -ResourceGroupName azps_test_group -Name azpsms-contentkeypolicy
```

```output
Name                    ResourceGroupName
----                    -----------------
azpsms-contentkeypolicy azps_test_group
```

Get the details of a Content Key Policy in the Media Services account by ConteneKey Name.