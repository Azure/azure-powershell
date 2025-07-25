### Example 1: create action group azure function receiver
```powershell
New-AzActionGroupAzureFunctionReceiverObject -FunctionAppResourceId "/subscriptions/5def922a-3ed4-49c1-b9fd-05ec533819a3/resourceGroups/aznsTest/providers/Microsoft.Web/sites/testFunctionApp" -FunctionName HttpTriggerCSharp1 -HttpTriggerUrl "http://test.me" -Name "sample azure function" -UseCommonAlertSchema $true
```

```output
FunctionAppResourceId : /subscriptions/5def922a-3ed4-49c1-b9fd-05ec533819a3/resourceGroups/aznsTest/providers/Microsoft.Web/sites/testFunctionApp
FunctionName          : HttpTriggerCSharp1
HttpTriggerUrl        : http://test.me
Name                  : sample azure function
UseCommonAlertSchema  : True
```

This command creates action group azure function receiver object.

