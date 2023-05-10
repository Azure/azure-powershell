### Example 1: Delete a test line
```powershell
Remove-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01
```

```output
```

Delete a test line.

### Example 2: Delete a test line by pipeline
```powershell
Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01 | Remove-AzVoiceServicesCommunicationsTestLine
```

```output
```

Delete a test line by pipeline.

