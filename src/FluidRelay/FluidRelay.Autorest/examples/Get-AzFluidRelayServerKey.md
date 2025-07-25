### Example 1: Get primary and secondary key for this server.
```powershell
Get-AzFluidRelayServerKey -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp
```

```output
                        Key1                         Key2
                        ----                         ----
System.Security.SecureString System.Security.SecureString
```

Get primary and secondary key for this server.