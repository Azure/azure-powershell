### Example 1: Check if a PostgreSQL Flexible Server name is available
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailability -Location "East US" -Name "myNewPostgreSqlServer"
```

```output
Name      : myNewPostgreSqlServer
Available : True
Reason    : 
Message   : 
```

Checks if the specified server name is available in the East US region.

### Example 2: Check availability for an already used server name
```powershell
Test-AzPostgreSqlFlexibleServerNameAvailability -Location "West Europe" -Name "popular-server-name"
```

```output
Name      : popular-server-name
Available : False
Reason    : AlreadyExists
Message   : The server name 'popular-server-name' is already in use.
```

Checks availability for a server name that is already in use, returning details about why it's not available.

