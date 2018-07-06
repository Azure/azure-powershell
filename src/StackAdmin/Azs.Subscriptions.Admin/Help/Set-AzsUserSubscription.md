---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version:
schema: 2.0.0
---

# Set-AzsUserSubscription

## SYNOPSIS
Updates the specified user subscription

## SYNTAX

### Set (Default)
```
Set-AzsUserSubscription -SubscriptionId <Guid> [-DisplayName <String>]
 [-DelegatedProviderSubscriptionId <String>] [-Owner <String>] [-TenantId <String>]
 [-RoutingResourceManagerType <String>] [-ExternalReferenceId <String>] [-State <String>] [-Location <String>]
 [-OfferId <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceId
```
Set-AzsUserSubscription -ResourceId <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObject
```
Set-AzsUserSubscription -InputObject <Subscription> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified user subscription

## EXAMPLES

### EXAMPLE 1
```
Set-AzsUserSubscription -SubscriptionId 8e425478-c7f0-49ca-bb92-b42889ec3642 -DisplayName "NewName"
```

Updates a subscription

## PARAMETERS

### -DelegatedProviderSubscriptionId
Parent DelegatedProvider subscription identifier.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
Subscription name.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalReferenceId
External reference identifier.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.Network.Admin.Models.Quota.

```yaml
Type: Subscription
Parameter Sets: InputObject
Aliases: Subscription

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: Set
Aliases: ArmLocation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferId
Identifier of the offer under the scope of a delegated provider.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
Subscription owner.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoutingResourceManagerType
Routing resource manager type.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Subscription state.

```yaml
Type: String
Parameter Sets: Set
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription identifier.

```yaml
Type: Guid
Parameter Sets: Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Directory tenant identifier.

```yaml
Type: String
Parameter Sets: Set
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription

## NOTES

## RELATED LINKS
