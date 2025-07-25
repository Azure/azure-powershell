### Example 1: Gets events of a container registry webhook.
```powershell
Get-AzContainerRegistryWebhookEvent  -ResourceGroupName lnxtest -RegistryName lnxcr -WebhookName webhook001
```

```output
ContentAction ContentTimestamp     ResponseMessageStatusCode
------------- ----------------     -------------------------
ping          1/19/2023 6:57:21 AM 200
ping          1/16/2023 9:30:18 PM 200
ping          1/16/2023 9:27:30 PM 200
ping          1/16/2023 9:23:50 PM 200
ping          1/16/2023 9:13:47 PM 200
ping          1/16/2023 9:04:55 PM 200

```

Gets events of a container registry webhook.
