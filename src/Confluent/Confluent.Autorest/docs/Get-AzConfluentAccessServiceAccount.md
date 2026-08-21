---
external help file:
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentaccessserviceaccount
schema: 2.0.0
---

# Get-AzConfluentAccessServiceAccount

## SYNOPSIS
Organization service accounts details

## SYNTAX

### ListExpanded (Default)
```
Get-AzConfluentAccessServiceAccount -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-SearchFilter <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### List
```
Get-AzConfluentAccessServiceAccount -OrganizationName <String> -ResourceGroupName <String>
 -Body <IListAccessRequestModel> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzConfluentAccessServiceAccount -OrganizationName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzConfluentAccessServiceAccount -OrganizationName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Organization service accounts details

## EXAMPLES

### Example 1: List all Service accounts under an Organization in the resource group
```powershell
Get-AzConfluentAccessServiceAccount -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa02",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa02",
                        "created_at": "2025-11-24T04:19:14.474519+00:00",
                        "updated_at": "2025-11-24T04:19:14.474519+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa02",
                      "display_name": "serAccPGS",
                      "description": "Service account for connector snkConn24110948"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa04",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa04",
                        "created_at": "2025-12-22T13:46:18.382565+00:00",
                        "updated_at": "2025-12-22T13:46:18.382565+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa04",
                      "display_name": "serAccPGS19152212",
                      "description": "Service account for connector srcConnTestSA1915"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa01",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa01",
                        "created_at": "2025-12-22T13:47:06.072554+00:00",
                        "updated_at": "2025-12-22T13:47:06.072554+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa01",
                      "display_name": "serAccPGS19172212",
                      "description": "Service account for connector snkConnTestSA1917"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa03",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa03",
                        "created_at": "2026-01-06T06:46:27.431436+00:00",
                        "updated_at": "2026-01-06T06:46:27.431436+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa03",
                      "display_name": "serAccPGS12160601",
                      "description": "Service account for connector snk1215"
                    }…}
Kind              : ServiceAccountList
MetadataFirst     :
MetadataLast      :
MetadataNext      :
MetadataPrev      :
MetadataTotalSize : 0
```

This command lists all Servie accounts under a organization and resource group

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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IAccessListServiceAccountsSuccessResponse

## NOTES

## RELATED LINKS

