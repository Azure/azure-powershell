### Example 1: Create a new Api Key for an application insights resource
```powershell
PS C:\> $apiKeyDescription = "testapiKey"
PS C:\> $permissions = @("ReadTelemetry", "WriteAnnotations")
PS C:\> New-AzApplicationInsightsApiKey -ResourceGroupName "testGroup" -Name "test" -Description $apiKeyDescription -Permissions $permissions

```

Create a new Api Key for an application insights resource

