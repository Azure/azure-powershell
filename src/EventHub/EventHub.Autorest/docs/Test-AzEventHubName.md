---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/test-azeventhubname
schema: 2.0.0
---

# Test-AzEventHubName

## SYNOPSIS
Checks availability of a namespace name or disaster recovery alias.

## SYNTAX

### NamespaceAvailability (Default)
```
Test-AzEventHubName -NamespaceName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [<CommonParameters>]
```

### AliasAvailability
```
Test-AzEventHubName -AliasName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
Checks availability of a namespace name or disaster recovery alias.

## EXAMPLES

### Example 1: Check the availability of an EventHub namespace name
```powershell
Test-AzEventHubName -NamespaceName myNamespace
```

```output
Message                                                                                                NameAvailable Reason
-------                                                                                                ------------- ------
The specified name is not available. For more information visit https://aka.ms/eventhubsarmexceptions.         False NameInUse
```

Checks the availability of namespace name `myNamespace`.

### Example 2: Check the availability of an EventHub Geo Disaster Recovery Alias
```powershell
Test-AzEventHubName -NamespaceName myNamespace -ResourceGroupName myResourceGroup -AliasName myAlias
```

```output
Message                                                                                                NameAvailable Reason
-------                                                                                                ------------- ------
The specified name is not available. For more information visit https://aka.ms/eventhubsarmexceptions.         False NameInUse
```

Checks the availability of alias name `myAlias` on namespace `myNamepace`.

## PARAMETERS

### -AliasName
The name of Disaster Recovery Config alias.

```yaml
Type: System.String
Parameter Sets: AliasAvailability
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
The name of the resource

```yaml
Type: System.String
Parameter Sets: AliasAvailability
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
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.ICheckNameAvailabilityResult

## NOTES

ALIASES

## RELATED LINKS

