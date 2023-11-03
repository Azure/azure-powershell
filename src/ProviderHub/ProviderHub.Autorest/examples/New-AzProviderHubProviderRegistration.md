### Example 1: Create/Update a provider registration.
```powershell
New-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso" -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization @{ApplicationId = "00000000-0000-0000-0000-000000000000"; RoleDefinitionId = "00000000-0000-0000-0000-000000000000"} -Namespace "Microsoft.Contoso" -ProviderVersion "2.0" -ProviderType "Internal" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "help@microsoft.com" -ManagementIncidentRoutingService "Contoso Service" -ManagementIncidentRoutingTeam "Contoso Team" -ManagementServiceTreeInfo @{ComponentId = "00000000-0000-0000-0000-000000000000"; ServiceId = "00000000-0000-0000-0000-000000000000"} -Capability @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}, @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}
```

```output
Name                Type
----                ----
Microsoft.Contoso   Microsoft.ProviderHub/providerRegistrations
```

Create/Update a provider registration.

### Example 2: Create/Update a provider registration.
```powershell
New-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso" -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization @{ApplicationId = "00000000-0000-0000-0000-000000000000"; RoleDefinitionId = "00000000-0000-0000-0000-000000000000"} -Namespace "Microsoft.Contoso" -ProviderVersion "2.0" -ProviderType "Hidden" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "help@microsoft.com" -ManagementIncidentRoutingService "Contoso Service" -ManagementIncidentRoutingTeam "Contoso Team" -ManagementServiceTreeInfo @{ComponentId = "00000000-0000-0000-0000-000000000000"; ServiceId = "00000000-0000-0000-0000-000000000000"} -Capability @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}, @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}
```

```output
Name                Type
----                ----
Microsoft.Contoso   Microsoft.ProviderHub/providerRegistrations
```

Create/Update a provider registration.
