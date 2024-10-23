### Example 1: Get OpenAI integration status for a given integration.
```powershell
Get-AzElasticOpenAiStatus -IntegrationName default -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02
```

```output:
IntegrationName: default
Status: Active
```

This command gets OpenAI integration status for a given integration.