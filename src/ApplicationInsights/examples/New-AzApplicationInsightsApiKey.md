### Example 1: Create a new Api Key for an application insights resource
```powershell
$apiKeyDescription = "testapiKey"
$permissions = @("ReadTelemetry", "WriteAnnotations")
New-AzApplicationInsightsApiKey -ResourceGroupName "testGroup" -Name "test" -Description $apiKeyDescription -Permissions $permissions

```

Create a new Api Key for an application insights resource

