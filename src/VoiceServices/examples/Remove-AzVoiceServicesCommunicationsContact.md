### Example 1: Delete a contact
```powershell
Remove-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01
```

```output
```

Delete a contact.

### Example 2: Delete a contact by pipeline
```powershell
Get-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01 | Remove-AzVoiceServicesCommunicationsContact
```

```output
```

Delete a contact by pipeline.

