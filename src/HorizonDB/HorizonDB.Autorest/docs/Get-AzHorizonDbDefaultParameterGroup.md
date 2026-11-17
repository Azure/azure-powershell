---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbdefaultparametergroup
schema: 2.0.0
---

# Get-AzHorizonDbDefaultParameterGroup

## SYNOPSIS
Gets a default parameter group available for a subscription in a specific region.
Each PostgreSQL version has at most one default parameter group in a location.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbDefaultParameterGroup -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbDefaultParameterGroup -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbDefaultParameterGroup -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzHorizonDbDefaultParameterGroup -LocationInputObject <IHorizonDbIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a default parameter group available for a subscription in a specific region.
Each PostgreSQL version has at most one default parameter group in a location.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the DefaultParameterGroup

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IDefaultParameterGroup

## NOTES

## RELATED LINKS

