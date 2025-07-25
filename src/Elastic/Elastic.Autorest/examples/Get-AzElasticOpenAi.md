### Example 1: Get OpenAI integration rule for a given monitor resource.
```powershell
Get-AzElasticOpenAi -IntegrationName default -ResourceGroupName azure-elastic-test -MonitorName elastic-pwsh02
```

```output:
IntegrationName          : default
openAIResourceId         : /subscriptions/cff37b56-870a-448f-a2fb-1a89235d4d32/resourceGroups/utkarshjain-rg/providers/Microsoft.CognitiveServices/accounts/utkarshTestResource1
openAIResourceEndpoint   : https://utkarshtestresource1.openai.azure.com/openai/deployments/test1/chat/completions?api-version=2024-06-15-preview
CreatedAt                : 2024-02-10T09:25:43Z
Status                   : Active
```

This command gets OpenAI integration rule for a given monitor resource.