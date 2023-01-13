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