---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridtopictype
schema: 2.0.0
---

# Get-AzEventGridTopicType

## SYNOPSIS
Get information about a topic type.

## SYNTAX

### List (Default)
```
Get-AzEventGridTopicType [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### Get
```
Get-AzEventGridTopicType -Name <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventGridTopicType -InputObject <IEventGridIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Get information about a topic type.

## EXAMPLES

### Example 1: List information about topic type.
```powershell
Get-AzEventGridTopicType
```

```output
Name                                            ResourceGroupName
----                                            -----------------
Microsoft.Eventhub.Namespaces
......
Microsoft.EventGrid.Namespaces
```

List information about topic type.

### Example 2: Get information about a topic type.
```powershell
Get-AzEventGridTopicType -Name Microsoft.EventGrid.Namespaces
```

```output
Name                           ResourceGroupName
----                           -----------------
Microsoft.EventGrid.Namespaces
```

Get information about a topic type.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the topic type.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TopicTypeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicTypeInfo

## NOTES

## RELATED LINKS
