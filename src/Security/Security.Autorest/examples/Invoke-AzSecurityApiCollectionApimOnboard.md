### Example 1: Onboard an Azure API Management API to Microsoft Defender for APIs.
```powershell
Invoke-AzSecurityApiCollectionApimOnboard -ResourceGroupName "apicollectionstests" -ServiceName "demoapimservice2" -ApiId "echo-api-2"
```

```output
BaseUrl                                      : https://demoapimservice2.azure-api.net
DiscoveredVia                                : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapimservice2
DisplayName                                  : Echo API 2
Id                                           : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/apicollectionstests/providers/Microsoft.ApiManagement/service/demoapimservice2/providers/Microsoft.Security/apiCollections/ech 
                                               o-api-2
Name                                         : echo-api-2
NumberOfApiEndpoint                          : 0
NumberOfApiEndpointsWithSensitiveDataExposed : 0
NumberOfExternalApiEndpoint                  : 0
NumberOfInactiveApiEndpoint                  : 0
NumberOfUnauthenticatedApiEndpoint           : 0
ProvisioningState                            : Succeeded
ResourceGroupName                            : apicollectionstests
SensitivityLabel                             : 
Type                                         : microsoft.security/apicollections
```

