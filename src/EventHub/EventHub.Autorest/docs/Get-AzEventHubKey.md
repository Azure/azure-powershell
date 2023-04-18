---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubkey
schema: 2.0.0
---

# Get-AzEventHubKey

## SYNOPSIS
Gets an EventHub SAS key

## SYNTAX

### GetExpandedNamespace (Default)
```
Get-AzEventHubKey -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

### GetExpandedAlias
```
Get-AzEventHubKey -AliasName <String> -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

### GetExpandedEntity
```
Get-AzEventHubKey -EventHubName <String> -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
Gets an EventHub SAS key

## EXAMPLES

### Example 1: Get keys of an EventHub Namespace authorization rule
```powershell
Get-AzEventHubKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name RootManageSharedAccessKey
```

```output
AliasPrimaryConnectionString   :
AliasSecondaryConnectionString :
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : 000000000000
PrimaryKey                     : 000000000000
SecondaryConnectionString      : {ConnectionString}
SecondaryKey                   : {ConnectionString}
```

Gets keys of authorization rule `RootManageSharedAccessKey` of EventHub namespace `myNamespace`.

### Example 2: Get keys of an EventHub Entity authorization rule
```powershell
Get-AzEventHubKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name RootManageSharedAccessKey
```

```output
AliasPrimaryConnectionString   :
AliasSecondaryConnectionString :
KeyName                        : RootManageSharedAccessKey
PrimaryConnectionString        : 000000000000
PrimaryKey                     : 000000000000
SecondaryConnectionString      : {ConnectionString}
SecondaryKey                   : {ConnectionString}
```

Gets keys of authorization rule `RootManageSharedAccessKey` of EventHub entity `myEventHub` from namespace `myNamespace`.

## PARAMETERS

### -AliasName
The name of the Disaster Recovery alias

```yaml
Type: System.String
Parameter Sets: GetExpandedAlias
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -EventHubName
The name of the EventHub entity.

```yaml
Type: System.String
Parameter Sets: GetExpandedEntity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Authorization Rule

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AuthorizationRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of EventHub namespace

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

### -SubscriptionId
The ID of the target subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IAccessKeys

## NOTES

ALIASES

## RELATED LINKS

