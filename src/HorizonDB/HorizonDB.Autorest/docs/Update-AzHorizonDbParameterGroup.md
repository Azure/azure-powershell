---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/update-azhorizondbparametergroup
schema: 2.0.0
---

# Update-AzHorizonDbParameterGroup

## SYNOPSIS
Update an existing HorizonDB parameter group.
Each connected pool's applyMethod setting controls whether dynamic parameter changes become effective immediately or remain pending until a customer-initiated pool Restart.
Static parameter changes always remain pending until a customer-initiated pool Restart.
Stop followed by Start and scheduled maintenance do not apply pending changes.
The operation fails with a conflict while a previous update to this parameter group is still being processed.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHorizonDbParameterGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-Parameter <IParameterProperties[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHorizonDbParameterGroup -InputObject <IHorizonDbIdentity> [-Description <String>]
 [-Parameter <IParameterProperties[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzHorizonDbParameterGroup -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzHorizonDbParameterGroup -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an existing HorizonDB parameter group.
Each connected pool's applyMethod setting controls whether dynamic parameter changes become effective immediately or remain pending until a customer-initiated pool Restart.
Static parameter changes always remain pending until a customer-initiated pool Restart.
Stop followed by Start and scheduled maintenance do not apply pending changes.
The operation fails with a conflict while a previous update to this parameter group is still being processed.

## EXAMPLES

### Example 1: Update a PostgreSQL parameter group
```powershell
$parameters = @(
    @{ Name = 'application_name'; Value = 'horizondb-production' }
    @{ Name = 'autovacuum'; Value = 'off' }
    @{ Name = 'wal_receiver_timeout'; Value = '45000' }
    @{ Name = 'work_mem'; Value = '8192' }
    @{ Name = 'xmlbinary'; Value = 'base64' }
)
$tags = @{
    environment = 'production'
    team = 'data-platform'
}
Update-AzHorizonDbParameterGroup -ResourceGroupName 'example-resource-group' -Name 'production-parameters' -Parameter $parameters -Description 'Updated parameters for production transactional workloads' -Tag $tags | Format-List -Property Name, Location, PostgreSqlVersion, Description, ProvisioningState, Parameter
```

```output
Name              : production-parameters
Location          : eastus2
PostgreSqlVersion : 17
Description       : Updated parameters for production transactional workloads
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

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Description
Description of the parameter group.
The maximum length is 1024 characters.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HorizonDB parameter group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: ParameterGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters in the parameter group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IParameterProperties[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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

