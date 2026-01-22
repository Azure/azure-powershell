### Example 1: Check if a PostgreSQL Flexible Server name is globally available
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally -Name "my-unique-postgresql-server"
```

```output
Name      : my-unique-postgresql-server
Available : True
Reason    : 
Message   : Server name is available globally
```

Checks if the specified server name is available globally across all Azure regions and subscriptions.

### Example 2: Check availability for a common server name
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailabilityGlobally -Name "postgresql-server"
```

```output
Name      : postgresql-server
Available : False
Reason    : AlreadyExists
Message   : The server name 'postgresql-server' is already in use globally
```

Checks global availability for a common server name that is already in use, returning details about why it's not available.

