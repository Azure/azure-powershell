### Example 1: List default parameter groups in a region
```powershell
Get-AzHorizonDbDefaultParameterGroup -Location 'eastus2' | Format-List -Property Name, PostgreSqlVersion, Description, ProvisioningState, Parameter
```

```output
Name              : default-postgresql-17-provisioned
PostgreSqlVersion : 17
Description       : Default parameters for PostgreSQL 17 provisioned pools
ProvisioningState : Succeeded
Parameter         : {{
                      "name": "allow_alter_system",
                      "description": "Allows running the ALTER SYSTEM command. Can be set to off for environments where global configuration changes should be m
                    ade using a different method.",
                      "value": "on",
                      "defaultValue": "on",
                      "valueSource": "SystemDefault",
                      "dataType": "Boolean",
                      "allowedValues": "on,off",
                      "isDynamic": true,
                      "isReadOnly": true,
                      "documentationLink": "https://www.postgresql.org/docs/17/runtime-config-compatible.html#GUC-ALLOW-ALTER-SYSTEM"
                    }, {
                      "name": "allow_in_place_tablespaces",
                      "description": "Allows tablespaces directly inside pg_tblspc, for testing. NOT IMPLEMENTED",
                      "value": "off",
                      "defaultValue": "off",
                      "valueSource": "SystemDefault",
                      "dataType": "Boolean",
                      "allowedValues": "on,off",
                      "isDynamic": true,
                      "isReadOnly": true,
                      "documentationLink": "https://www.postgresql.org/docs/17/runtime-config-developer.html#GUC-ALLOW-IN-PLACE-TABLESPACES"
                    }, {
                      "name": "allow_system_table_mods",
                      "description": "Allows modifications of the structure of system tables.",
                      "value": "off",
                      "defaultValue": "off",
                      "valueSource": "SystemDefault",
                      "dataType": "Boolean",
                      "allowedValues": "on,off",
                      "isDynamic": true,
                      "isReadOnly": true,
                      "documentationLink": "https://www.postgresql.org/docs/17/runtime-config-developer.html#GUC-ALLOW-SYSTEM-TABLE-MODS"
                    }, {
                      "name": "application_name",
                      "description": "Sets the application name to be reported in statistics and logs.",
                      "value": "",
                      "defaultValue": "",
                      "valueSource": "SystemDefault",
                      "dataType": "String",
                      "allowedValues": "[A-Za-z0-9._-]*",
                      "isDynamic": true,
                      "isReadOnly": false,
                      "documentationLink": "https://www.postgresql.org/docs/17/libpq-connect.html#LIBPQ-CONNECT-APPLICATION-NAME"
                    }…}
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get the default PostgreSQL 17 parameter group
```powershell
Get-AzHorizonDbDefaultParameterGroup -Location 'eastus2' -Name 'default-postgresql-17-provisioned' | Format-List -Property Name, PostgreSqlVersion, Description, ProvisioningState, Parameter
```

```output
Name              : default-postgresql-17-provisioned
PostgreSqlVersion : 17
Description       : Default parameters for PostgreSQL 17 provisioned pools
ProvisioningState : Succeeded
Parameter         : {{
                      "name": "allow_alter_system",
                      "description": "Allows running the ALTER SYSTEM command. Can be set to off for environments where global configuration changes should be m
                    ade using a different method.",
                      "value": "on",
                      "defaultValue": "on",
                      "valueSource": "SystemDefault",
                      "dataType": "Boolean",
                      "allowedValues": "on,off",
                      "isDynamic": true,
                      "isReadOnly": true,
                      "documentationLink": "https://www.postgresql.org/docs/17/runtime-config-compatible.html#GUC-ALLOW-ALTER-SYSTEM"
                    }, {
                      "name": "allow_in_place_tablespaces",
                      "description": "Allows tablespaces directly inside pg_tblspc, for testing. NOT IMPLEMENTED",
                      "value": "off",
                      "defaultValue": "off",
                      "valueSource": "SystemDefault",
                      "dataType": "Boolean",
                      "allowedValues": "on,off",
                      "isDynamic": true,
                      "isReadOnly": true,
                      "documentationLink": "https://www.postgresql.org/docs/17/runtime-config-developer.html#GUC-ALLOW-IN-PLACE-TABLESPACES"
                    }, {
                      "name": "allow_system_table_mods",
                      "description": "Allows modifications of the structure of system tables.",
                      "value": "off",
                      "defaultValue": "off",
                      "valueSource": "SystemDefault",
                      "dataType": "Boolean",
                      "allowedValues": "on,off",
                      "isDynamic": true,
                      "isReadOnly": true,
                      "documentationLink": "https://www.postgresql.org/docs/17/runtime-config-developer.html#GUC-ALLOW-SYSTEM-TABLE-MODS"
                    }, {
                      "name": "application_name",
                      "description": "Sets the application name to be reported in statistics and logs.",
                      "value": "",
                      "defaultValue": "",
                      "valueSource": "SystemDefault",
                      "dataType": "String",
                      "allowedValues": "[A-Za-z0-9._-]*",
                      "isDynamic": true,
                      "isReadOnly": false,
                      "documentationLink": "https://www.postgresql.org/docs/17/libpq-connect.html#LIBPQ-CONNECT-APPLICATION-NAME"
                    }…}
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
