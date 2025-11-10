### Example 1: Create a rules engine action that append response header value and show how to view the properties of the rules engine action created.
```powershell
$headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
```

Create a rules engine action that append response header value and show how to view the properties of the rules engine action created.

### Example 2: Create a rules engine action that forwards the requests to a specific backend pool and show how to view the properties of the rules engine action created.
```powershell
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -RequestHeaderAction $headerActions -ForwardingProtocol HttpsOnly -BackendPoolName mybackendpool -ResourceGroupName Jessicl-Test-RG -FrontDoorName jessicl-test-myappfrontend -QueryParameterStripDirective StripNone -DynamicCompression Disabled -EnableCaching $true
```

Create a rules engine action that forwards the requests to a specific backend pool and show how to view the properties of the rules engine action created.

### Example 3: Create a rules engine action that redirects the requests to another host and show how to view the properties of the rules engine action created.
```powershell
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -RedirectType Moved -RedirectProtocol MatchRequest -CustomHost www.contoso.com
```
Create a rules engine action that redirects the requests to another host and show how to view the properties of the rules engine action created.
