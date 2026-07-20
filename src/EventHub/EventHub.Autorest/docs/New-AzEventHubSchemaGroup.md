---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhubschemagroup
schema: 2.0.0
---

# New-AzEventHubSchemaGroup

## SYNOPSIS
Create an EventHub schema group.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventHubSchemaGroup -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-GroupProperty <Hashtable>] [-SchemaCompatibility <String>]
 [-SchemaType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityNamespace
```
New-AzEventHubSchemaGroup -Name <String> -NamespaceInputObject <IEventHubIdentity> -Parameter <ISchemaGroup>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityNamespaceExpanded
```
New-AzEventHubSchemaGroup -Name <String> -NamespaceInputObject <IEventHubIdentity>
 [-GroupProperty <Hashtable>] [-SchemaCompatibility <String>] [-SchemaType <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an EventHub schema group.

## EXAMPLES

### Example 1: Create EventHub schema group
```powershell
$schemaGroup = New-AzEventHubSchemaGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name mySchemaGroup -SchemaCompatibility Backward -SchemaType Avro
```

```output
CreatedAtUtc                 : 9/14/2022 6:05:47 AM
ETag                         : {etag}
GroupProperty                : {
                               }
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/schemagroups/mySchemaGroup
Location                     : Central US
Name                         : mySchemaGroup
ResourceGroupName            : myResourceGroup
SchemaCompatibility          : Backward
SchemaType                   : Avro
```

Create a new schema group `mySchemaGroup` for namespace `myNamespace`.

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

### -GroupProperty
dictionary object for SchemaGroup group properties

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Schema Group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SchemaGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: CreateViaIdentityNamespace, CreateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The Namespace name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Single item in List or Get Schema Group operation

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.ISchemaGroup
Parameter Sets: CreateViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaCompatibility
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaType
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.ISchemaGroup

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.ISchemaGroup

## NOTES

## RELATED LINKS

