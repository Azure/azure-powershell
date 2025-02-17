### Example 1: Create or update a OpenAI integration rule for a given monitor resource.
```powershell
New-AzElasticOpenAi -IntegrationName default -ResourceGroupName elastic-rg-3eytki -MonitorName elastic-rhqz1v
```

```output
IntegrationName              Status            ResourceGroupName
------------------          ---------          -----------------
default                      Active            elastic-rg-3eytki
```

This command Creates or updates a OpenAI integration rule for a given monitor resource.