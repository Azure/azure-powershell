This project contains SQL cmdlets that use the Hyak-based SDK
(Microsoft.Azure.Management.Sql < 1.0.0). New cmdlets should not be added to
this project. Instead, new cmdlets should have Swagger specs written (see
https://www.github.com/Azure/azure-rest-api-specs) which can be used to
generate an SDK with AutoRest (Microsoft.Azure.Management.Sql >= 1.0.0).
New cmdlets should then be added to the AutoRest-based project (Commands.Sql).
Existing cmdlets should be migrated over to the AutoRest-based project when
their Swagger specs are implemented.
