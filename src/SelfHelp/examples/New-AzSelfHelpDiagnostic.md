### Example 1: Create Diagnostic for a KeyVault resource.

```powershell
$insightsToInvoke = [ordered]@{
                "solutionId" = "Demo2InsightV2"
            }
New-AzSelfHelpDiagnostic -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/aravind-test-resources/providers/Microsoft.KeyVault/vaults/ab-tests-kv-an" -SResourceName ab-test-983 -Insight $insightsToInvoke -NoWait
```

```output
Target
------
https://management.azure.com/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/providers/Microsoft.Help/Diagnostics/ab-test-984/operationResults/9ef3e257
```

Create Diagnostic for a KeyVault resource.
