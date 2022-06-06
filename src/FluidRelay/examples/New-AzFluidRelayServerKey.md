### Example 1: Regenerate the primary or secondary key for this server.
```powershell
New-AzFluidRelayServerKey -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp -KeyName 'key2'
```

```output
                        Key1                         Key2
                        ----                         ----
System.Security.SecureString System.Security.SecureString
```

Regenerate the primary or secondary key for this server.

### Example 2: Regenerate the primary or secondary key for this server.
```powershell
$keyName = New-AzFluidRelayRegenerateKeyRequestObject -KeyName 'key1'
New-AzFluidRelayServerKey -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp -Parameter $keyName
```

```output
                        Key1                         Key2
                        ----                         ----
System.Security.SecureString System.Security.SecureString
```

Regenerate the primary or secondary key for this server.