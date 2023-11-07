### Example 1: 
```powershell
Enable-AzStackHCIRemoteSupport -AccessLevel Diagnostics -ExpireInMinutes 1440 -SasCredential "Sample SAS"
```

```output
Proceed with enabling remote support?
[Y] Yes  [N] No: Y

Enabling Remote Support for 'Diagnostics' expiring in '1440' minutes.
Using provided SAS credential to make remote support connection.
Remote Support successfully Enabled.


State         : Active
CreatedAt     : 3/29/2022 10:29:19 AM +00:00
UpdatedAt     : 3/29/2022 10:29:19 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:29:18 AM +00:00
SasCredential :
```

Enable Remote Support on machine 

### Example 2:
```powershell
Enable-AzStackHCIRemoteSupport -AccessLevel DiagnosticsRepair -ExpireInMinutes 1440 -SasCredential "Sample SAS" -AgreeToRemoteSupportConsent
```

```output
Enabling Remote Support for 'Diagnostics' expiring in '1440' minutes.
Using provided SAS credential to make remote support connection.
Remote Support successfully Enabled.


State         : Active
CreatedAt     : 3/29/2022 10:29:19 AM +00:00
UpdatedAt     : 3/29/2022 10:29:53 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:29:53 AM +00:00
SasCredential :
```

Enable remort support by providing consent. In this case, user is not prompted for consent


