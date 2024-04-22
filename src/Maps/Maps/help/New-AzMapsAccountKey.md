---
external help file: Az.Maps-help.xml
Module Name: Az.Maps
online version: https://learn.microsoft.com/powershell/module/az.maps/new-azmapsaccountkey
schema: 2.0.0
---

# New-AzMapsAccountKey

## SYNOPSIS
Regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzMapsAccountKey -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -KeyType <KeyType>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzMapsAccountKey -InputObject <IMapsIdentity> -KeyType <KeyType> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.

## EXAMPLES

### Example 1: Regenerate either the primary or secondary key for use with the Maps APIs
```powershell
New-AzMapsAccountKey -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -KeyType primary
```

```output
PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
W5VYcbrpyt4urV2-4C-lXepnHoy6EIOHnoLL_wjEtaw 2021-05-20T05:50:27.1509422Z zi6W1bw4zIYLjDj_DRRrC3jBkX-APgBebwx4cZBKJOU 2021-05-20T05:41:03.452571Z
```

This command regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.

### Example 2: Regenerate either the primary or secondary key for use with the Maps APIs by pipeline
```powershell
Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 | New-AzMapsAccountKey -KeyType primary
```

```output
PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
xoGsuTFWuG6xq0re7EdA7nCbDhvRoisZfLHvKfdzIhQ 2021-05-20T05:55:21.7797268Z zi6W1bw4zIYLjDj_DRRrC3jBkX-APgBebwx4cZBKJOU 2021-05-20T05:41:03.452571Z
```

This command regenerate either the primary or secondary key for use with the Maps APIs by pipeline.
The old key will stop working immediately.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity
Parameter Sets: RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyType
Whether the operation refers to the primary or secondary key.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Maps Account.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: RegenerateExpanded
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
Parameter Sets: RegenerateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys

## NOTES

## RELATED LINKS
