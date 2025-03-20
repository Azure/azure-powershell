### Example 1: Create an in-memory object for GatewayApiRoute.
```powershell
New-AzSpringCloudGatewayApiRouteObject -Title "myApp route config" -SsoEnabled $true -Filter "StripPrefix=2","RateLimit=1,1s" -Predicate "Path=/api5/customer/**"
```

```output
Description :
Filter      : {StripPrefix=2, RateLimit=1,1s}
Order       :
Predicate   : {Path=/api5/customer/**}
SsoEnabled  : True
Tag         :
Title       : myApp route config
TokenRelay  :
Uri         :
```

Create an in-memory object for GatewayApiRoute.