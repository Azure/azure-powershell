### Example 1: Check if a name is available or already used in a location for a flexible server
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailability -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -LocationName example-location -Name server-name
```

```output
When name is available:

Message       : 
Name          : example-server
NameAvailable : True
Reason        : 
Type          : Microsoft.DBforPostgreSQL/flexibleServers


When name is already used:

Message       : Specified server name is already used.
Name          : example-server
NameAvailable : False
Reason        : AlreadyExists
Type          : Microsoft.DBforPostgreSQL/flexibleServers


When name is invalid:

Message       : Specified server name contains unsupported characters or is too long. Server name must be no longer than 63 characters long, contain only lower-case characters or digits, cannot contain '.' or '_' characters and can't start or end with '-' character.
Name          : example~server
NameAvailable : False
Reason        : Invalid
Type          : Microsoft.DBforPostgreSQL/flexibleServers
```

Checks if a name is available or already used for an Azure Database for PostgreSQL flexible server with server name, location, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
