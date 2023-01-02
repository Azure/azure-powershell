### Example 1: List all Automanage best practices under a subscription
```powershell
Get-AzAutomanageBestPractice
```

```output
Name
----
AzureBestPracticesProduction
AzureBestPracticesDevTest
```

This commmand lists all Automanage best practices under a subscription.

### Example 2: Get information about a Automanage best practice by name
```powershell
Get-AzAutomanageBestPractice -Name AzureBestPracticesProduction
```

```output
Name
----
AzureBestPracticesProduction
```

This command gets information about a Automanage best practice by name.

