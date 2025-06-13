### Example 1: Retrieve the connection URI for a specific Neon Postgres database

```powershell
Get-AzNeonPostgresProjectConnectionUri -OrganizationName "NeonDemoOrgPS1" -ProjectName "dawn-breeze-86932057" -ResourceGroupName "neonrg" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BranchId "br-damp-bird-a82olmcu" -DatabaseName "neondb" -EndpointId "ep-spring-cake-a88oisqp" -RoleName "neondb_owner"
```

```output
BranchId            : br-damp-bird-a82olmcu
ConnectionStringUri : System.Security.SecureString
DatabaseName        : neondb
EndpointId          : ep-spring-cake-a88oisqp
IsPooled            : False
ProjectId           : dawn-breeze-86932057
RoleName            : neondb_owner
```

Retrieve the connection URI for a specific Neon Postgres database.
