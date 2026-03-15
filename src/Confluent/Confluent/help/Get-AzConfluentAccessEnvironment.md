---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentaccessenvironment
schema: 2.0.0
---

# Get-AzConfluentAccessEnvironment

## SYNOPSIS
Environment list of an organization

## SYNTAX

### ListExpanded (Default)
```
Get-AzConfluentAccessEnvironment -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-SearchFilter <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzConfluentAccessEnvironment -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -Body <IListAccessRequestModel> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzConfluentAccessEnvironment -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzConfluentAccessEnvironment -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Environment list of an organization

## EXAMPLES

### Example 1: List all Confluent Environments under organization and under resource group
```powershell
Get-AzConfluentAccessEnvironment -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv002",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv002",
                        "created_at": "2025-11-03T14:15:40.878158+00:00",
                        "updated_at": "2025-11-03T14:15:40.878158+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv002",
                      "display_name": "default"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv003",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv003",
                        "created_at": "2025-11-17T10:14:45.640567+00:00",
                        "updated_at": "2025-11-17T10:14:45.640567+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv003",
                      "display_name": "test-env-0"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv004",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv004",
                        "created_at": "2025-11-28T09:41:04.588316+00:00",
                        "updated_at": "2025-11-28T09:41:04.588316+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv004",
                      "display_name": "test-env-1"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv005",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv005",
                        "created_at": "2025-11-28T09:44:36.482039+00:00",
                        "updated_at": "2025-11-28T09:44:36.482039+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv005",
                      "display_name": "test-env-2"
                    }…}
Kind              : EnvironmentList
MetadataFirst     :
MetadataLast      :
MetadataNext      :
MetadataPrev      :
MetadataTotalSize : 0
```

This command lists all confluent environments under a organization and resource group

## PARAMETERS

### -Body
List Access Request Model

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IListAccessRequestModel
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchFilter
Search filters for the request

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ListExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IListAccessRequestModel

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IAccessListEnvironmentsSuccessResponse

## NOTES

## RELATED LINKS
