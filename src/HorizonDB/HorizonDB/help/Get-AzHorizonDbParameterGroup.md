---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbparametergroup
schema: 2.0.0
---

# Get-AzHorizonDbParameterGroup

## SYNOPSIS
Gets information about a HorizonDB parameter group.

## SYNTAX

### List (Default)
```
Get-AzHorizonDbParameterGroup [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzHorizonDbParameterGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzHorizonDbParameterGroup -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbParameterGroup -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about a HorizonDB parameter group.

## EXAMPLES

### Example 1: List parameter groups in the current subscription
```powershell
Get-AzHorizonDbParameterGroup | Format-List -Property Name, Location, PostgreSqlVersion, Description, ProvisioningState, Parameter
```

```output
Name              : production-parameters
Location          : eastus2
PostgreSqlVersion : 17
Description       : Parameters for production transactional workloads
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
                      "value": "horizondb-production",
                      "defaultValue": "",
                      "valueSource": "UserOverride",
                      "dataType": "String",
                      "allowedValues": "[A-Za-z0-9._-]*",
                      "isDynamic": true,
                      "isReadOnly": false,
                      "documentationLink": "https://www.postgresql.org/docs/17/libpq-connect.html#LIBPQ-CONNECT-APPLICATION-NAME"
                    }…}
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: List parameter groups in a resource group
```powershell
Get-AzHorizonDbParameterGroup -ResourceGroupName 'example-resource-group' | Format-List -Property Name, Location, PostgreSqlVersion, Description, ProvisioningState, Parameter
```

```output
Name              : production-parameters
Location          : eastus2
PostgreSqlVersion : 17
Description       : Parameters for production transactional workloads
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
                      "value": "horizondb-production",
                      "defaultValue": "",
                      "valueSource": "UserOverride",
                      "dataType": "String",
                      "allowedValues": "[A-Za-z0-9._-]*",
                      "isDynamic": true,
                      "isReadOnly": false,
                      "documentationLink": "https://www.postgresql.org/docs/17/libpq-connect.html#LIBPQ-CONNECT-APPLICATION-NAME"
                    }…}
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Get a parameter group
```powershell
Get-AzHorizonDbParameterGroup -ResourceGroupName 'example-resource-group' -Name 'production-parameters' | Format-List -Property Name, Location, PostgreSqlVersion, Description, ProvisioningState, Parameter
```

```output
Name              : production-parameters
Location          : eastus2
PostgreSqlVersion : 17
Description       : Parameters for production transactional workloads
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
                      "value": "horizondb-production",
                      "defaultValue": "",
                      "valueSource": "UserOverride",
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

### -Name
The name of the HorizonDB parameter group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ParameterGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IParameterGroup

## NOTES

## RELATED LINKS
