---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/set-azpurviewdefaultaccount
schema: 2.0.0
---

# Set-AzPurviewDefaultAccount

## SYNOPSIS
Sets the default account for the scope.

## SYNTAX

### SetExpanded (Default)
```
Set-AzPurviewDefaultAccount -AccountName <String> -ResourceGroupName <String> -ScopeTenantId <String>
 [-Scope <String>] [-ScopeType <String>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetViaJsonFilePath
```
Set-AzPurviewDefaultAccount -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetViaJsonString
```
Set-AzPurviewDefaultAccount -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Sets the default account for the scope.

## EXAMPLES

### Example 1: Sets the default account for the scope.
```powershell
Set-AzPurviewDefaultAccount -AccountName test-pa -ResourceGroupName test-rg -ScopeTenantId xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
```

```output
AccountName ResourceGroupName Scope                                ScopeTenantId                        ScopeType SubscriptionId
----------- ----------------- -----                                -------------                        --------- --------------
test-pa      test-rg            xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a Tenant    xxxxxxxx-1bf0-4dda-aec3
```

Sets `test-pa` as the default account for the scope.

## PARAMETERS

### -AccountName
The name of the account that is set as the default.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
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

### -JsonFilePath
Path of Json file supplied to the Set operation

```yaml
Type: System.String
Parameter Sets: SetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Set operation

```yaml
Type: System.String
Parameter Sets: SetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name of the account that is set as the default.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope object ID.
For example, sub ID or tenant ID.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeTenantId
The scope tenant in which the default account is set.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeType
The scope where the default account is set.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID of the account that is set as the default.

```yaml
Type: System.String
Parameter Sets: SetExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IDefaultAccountPayload

## NOTES

## RELATED LINKS
