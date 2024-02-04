### Example 1: Get the default definition of a Stream Analytics function
```powershell
Get-AzStreamAnalyticsDefaultFunctionDefinition -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name mlsfunction-01 -BindingType Microsoft.MachineLearningServices -Endpoint "http://875da830-4d5f-44f1-b221-718a5f26a21d.eastus.azurecontainer.io/score"-UdfType Scalar
```
```output
Name           Type ETag
----           ---- ----
mlsfunction-01
```

This command gets the default definition of the function.
