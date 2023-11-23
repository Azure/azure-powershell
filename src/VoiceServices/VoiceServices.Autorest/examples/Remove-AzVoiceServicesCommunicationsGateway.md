### Example 1: Delete a gateway
```powershell
Remove-AzVoiceServicesCommunicationsGateway -ResourceGroupName vtest-communication-rg -Name vsc-gateway-pwsh01
```

```output
```

Delete a gateway.

### Example 2: Delete a gateway by pipeline
```powershell
Get-AzVoiceServicesCommunicationsGateway -ResourceGroupName vtest-communication-rg -Name vsc-gateway-pwsh01 | Remove-AzVoiceServicesCommunicationsGateway
```

```output
```

Delete a gateway by pipeline.

