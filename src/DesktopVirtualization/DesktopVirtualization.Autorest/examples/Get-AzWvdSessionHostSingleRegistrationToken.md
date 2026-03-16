### Example 1: Get a scoped registration token for a SessionHost
```powershell
Get-AzWvdSessionHostSingleRegistrationToken -ResourceGroupName resourceGroup1 `
                                             -HostPoolName hostPool1 `
                                             -SessionHostName sessionHost1.microsoft.com `
                                             -ExpirationTimeInUtc (Get-Date).ToUniversalTime().AddHours(2)
```

```output
ExpirationTime              Token
--------------              -----
9/22/2008 2:01:54 PM        <registration token>
```

This command lists the scoped registration tokens associated with an Azure Virtual Desktop SessionHost, with a specified expiration time.
