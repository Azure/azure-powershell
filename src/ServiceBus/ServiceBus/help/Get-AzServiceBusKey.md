---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebuskey
schema: 2.0.0
---

# Get-AzServiceBusKey

## SYNOPSIS
Gets the SASKey of a ServiceBus namespace, queue or topic.

## SYNTAX

### GetExpandedNamespace (Default)
```
Get-AzServiceBusKey -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### GetExpandedAlias
```
Get-AzServiceBusKey -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -AliasName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### GetExpandedTopic
```
Get-AzServiceBusKey -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -TopicName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

### GetExpandedQueue
```
Get-AzServiceBusKey -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -QueueName <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the SASKey of a ServiceBus namespace, queue or topic.

## EXAMPLES

### Example 1: Get keys of a ServiceBus Namespace authorization rule
```powershell
Get-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name RootManageSharedAccessKey
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

Gets keys of authorization rule `RootManageSharedAccessKey` of ServiceBus namespace `myNamespace`.

### Example 2: Get keys of a Queue authorization rule
```powershell
Get-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName queue1 -Name RootManageSharedAccessKey
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

Gets keys of authorization rule `RootManageSharedAccessKey` of ServiceBus queue `queue1` from namespace `myNamespace`.

### Example 3: Get keys of a Topic authorization rule
```powershell
Get-AzServiceBusKey -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName topic1 -Name RootManageSharedAccessKey
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

Gets keys of authorization rule `RootManageSharedAccessKey` of ServiceBus topic `topic1` from namespace `myNamespace`.

## PARAMETERS

### -AliasName
The name of the Service Disaster Recovery Config.

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
The name of ServiceBus namespace

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

### -QueueName
The name of the ServiceBus queue.

```yaml
Type: System.String
Parameter Sets: GetExpandedQueue
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

### -TopicName
The name of the ServiceBus topic.

```yaml
Type: System.String
Parameter Sets: GetExpandedTopic
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IAccessKeys

## NOTES

## RELATED LINKS
