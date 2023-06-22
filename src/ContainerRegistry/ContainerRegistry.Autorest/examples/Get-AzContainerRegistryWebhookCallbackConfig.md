### Example 1: Gets the configuration of service URI and custom headers for the webhook.
```powershell
Get-AzContainerRegistryWebhookCallbackConfig -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -WebhookName "webhook001"
```

```output
ServiceUri
----------
http://www.bing.com
```

Gets the configuration of service URI and custom headers for the webhook.

