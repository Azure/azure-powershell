### Example 1: Get a specific onboarded api collection resource
```powershell
Get-AzSecurityApiCollection -ResourceGroupName apicollectionstests -ServiceName "demoapimservice2" -ApiId "echo-api"
```

```output
BaseUrl                                      : https://demoapimservice2.azure-api.net/echo
DiscoveredVia                                : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapim
                                               service2
DisplayName                                  : Echo API
Id                                           : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapim
                                               service2/providers/Microsoft.Security/apiCollections/echo-api
Name                                         : echo-api
NumberOfApiEndpoint                          : 6
NumberOfApiEndpointsWithSensitiveDataExposed : 0
NumberOfExternalApiEndpoint                  : 0
NumberOfInactiveApiEndpoint                  : 6
NumberOfUnauthenticatedApiEndpoint           : 0
ProvisioningState                            : Succeeded
ResourceGroupName                            : apicollectionstests
SensitivityLabel                             :
Type                                         : microsoft.security/apicollections
```

### Example 2: List onboarded api collections by service name
```powershell
Get-AzSecurityApiCollection -ResourceGroupName "apicollectionstests" -ServiceName "demoapimservice2"
```

```output
Name       ResourceGroupName
----       -----------------
echo-api   apicollectionstests
echo-api-2 apicollectionstests
```

### Example 3: List onboarded api collections by subscription
```powershell
Get-AzSecurityApiCollection
```

```output
Name       ResourceGroupName
----       -----------------
echo-api   apicollectionstests
echo-api-2 apicollectionstests
```

