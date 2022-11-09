### Example 1: Remove a custom domain by its name
```powershell
Remove-AzWebPubSubCustomDomain -Name mydomain -ResourceGroupName -rg -ResourceName -wps
```

```output
```



### Example 2: Remove a custom domain by its identity
```powershell
$customDomain = Get-AzWebPubSubCustomDomain -Name mydomain -ResourceGroupName -rg -ResourceName -wps
$customDomain | Remove-AzWebPubSubCustomDomain
```

```output
```

