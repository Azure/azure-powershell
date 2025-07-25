### Example 1: Create an in-memory object for UrlRedirectAction
```powershell
New-AzFrontDoorCdnRuleUrlRedirectActionObject -Name UrlRedirect -ParameterRedirectType Moved -ParameterDestinationProtocol MatchRequest
```

```output
Name
----
UrlRedirect
```

Create an in-memory object for UrlRedirectAction