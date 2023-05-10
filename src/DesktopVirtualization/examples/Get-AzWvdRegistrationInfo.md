### Example 1: Get Existing Registration Info from Hostpool
```powershell
Get-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolName hpName
```

```output
ExpirationTime        RegistrationTokenOperation Token
--------------        -------------------------- -----
5/10/2023 12:00:00 PM None                       <base64 encoded string>

```

Retrieves Registration Info for the chosen hostpool.

### Example 2: Get Empty Registration Info from HostPool 
```powershell
Get-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolname hpName
```

```output
ExpirationTime RegistrationTokenOperation Token
-------------- -------------------------- -----
               None
```

Returns an empty Registration Info for the chosen Hostpool if the Hostpool doesn't have any Registration Info.
