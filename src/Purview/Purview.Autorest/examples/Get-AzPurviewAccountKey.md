### Example 1: List the authorization keys associated with a specified account.
```powershell
Get-AzPurviewAccountKey -AccountName test-pa -ResourceGroupName test-rg
```

```output
AtlasKafkaPrimaryEndpoint
-------------------------
Endpoint=sb://atlas-xxxxxxxx-5348-4811-a336-759242a25d37.servicebus.windows.net/;SharedAccessKeyName=AlternateSharedAccessKey;SharedAcces… 
```

List the authorization keys associated with account 'test-pa'.

