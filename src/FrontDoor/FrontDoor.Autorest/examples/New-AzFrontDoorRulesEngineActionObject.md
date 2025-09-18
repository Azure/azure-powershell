### Example 1: Create a rules engine action that append response header value and show how to view the properties of the rules engine action created.
<!-- Skip: Output cannot be splitted from code -->
```powershell
$headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
$headerActions

HeaderName             HeaderActionType Value
----------             ---------------- -----
X-Content-Type-Options           Append nosniff

$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions
$rulesEngineAction

RequestHeaderActions ResponseHeaderActions    RouteConfigurationOverride
-------------------- ---------------------    --------------------------
{}                   {X-Content-Type-Options}

```

Create a rules engine action that append response header value and show how to view the properties of the rules engine action created.

### Example 2: Create a rules engine action that forwards the requests to a specific backend pool and show how to view the properties of the rules engine action created.
<!-- Skip: Output cannot be splitted from code -->
```powershell
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -RequestHeaderAction $headerActions -ForwardingProtocol HttpsOnly -BackendPoolName mybackendpool -ResourceGroupName Jessicl-Test-RG -FrontDoorName jessicl-test-myappfrontend -QueryParameterStripDirective StripNone -DynamicCompression Disabled -EnableCaching $true
$rulesEngineAction

RequestHeaderAction            ResponseHeaderAction RouteConfigurationOverride
-------------------            -------------------- --------------------------
{headeraction1, headeraction2} {}                   Microsoft.Azure.Commands.FrontDoor.Models.PSForwardingConfiguration

$rulesEngineAction.RequestHeaderAction

HeaderName    HeaderActionType Value
----------    ---------------- -----
headeraction1        Overwrite
headeraction2           Append

$rulesEngineAction.ResponseHeaderAction
$rulesEngineAction.RouteConfigurationOverride

CustomForwardingPath         :
ForwardingProtocol           : HttpsOnly
BackendPoolId                : /subscriptions/47f4bc68-6fe4-43a2-be8b-dfd0e290efa2/resourceGroups/myresourcegroup/provi
                               ders/Microsoft.Network/frontDoors/myfrontdoor/BackendPools/mybackendpool
QueryParameterStripDirective : StripNone
DynamicCompression           : Disabled
EnableCaching                : True
```

Create a rules engine action that forwards the requests to a specific backend pool and show how to view the properties of the rules engine action created.

### Example 3: Create a rules engine action that redirects the requests to another host and show how to view the properties of the rules engine action created.
<!-- Skip: Output cannot be splitted from code -->
```powershell
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -RedirectType Moved -RedirectProtocol MatchRequest -CustomHost www.contoso.com
$rulesEngineAction

RequestHeaderActions ResponseHeaderActions RouteConfigurationOverride
-------------------- --------------------- --------------------------
{}                   {}                    Microsoft.Azure.Commands.FrontDoor.Models.PSRedirectConfiguration

$rulesEngineAction.RouteConfigurationOverride

RedirectType      : Moved
RedirectProtocol  : MatchRequest
CustomHost        : www.contoso.com
CustomPath        :
CustomFragment    :
CustomQueryString :

```

Create a rules engine action that redirects the requests to another host and show how to view the properties of the rules engine action created.
