### Example 1: Create an in-memory object for UrlRewriteAction
```powershell
New-AzFrontDoorCdnRuleUrlRewriteActionObject -Name UrlRewrite -ParameterDestination /b -ParameterSourcePattern /a -ParameterPreserveUnmatchedPath $False
```

```output
Name
----
UrlRewrite
```

Create an in-memory object for UrlRewriteAction