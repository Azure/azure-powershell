### Example 1: Create a new application insights resource
```powershell
PS C:\> New-AzApplicationInsights -Kind java -ResourceGroupName testgroup -Name test1027 -location eastus
```

Add a new application insights resource named as "test" in resource group "testgroup" with kind "java"