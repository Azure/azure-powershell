---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/new-azsupportfileworkspacesnosubscription
schema: 2.0.0
---

# New-AzSupportFileWorkspacesNoSubscription

## SYNOPSIS
Create a new file workspace.

## SYNTAX

```
New-AzSupportFileWorkspacesNoSubscription -FileWorkspaceName <String> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new file workspace.

## EXAMPLES

### Example 1: Create a new file workspace
```powershell
New-AzSupportFileWorkspacesNoSubscription -Name "testworkspace"
```

```output
CreatedOn                    : 2/8/2024 4:25:38 PM
ExpirationTime               : 2/9/2024 4:25:38 PM
Id                           : /providers/Microsoft.Support/fileWorkspaces/testworkspace
Name                         : testworkspace
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/fileWorkspaces
```

Creates a new file workspace.

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

### -FileWorkspaceName
File workspace name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IFileWorkspaceDetails

## NOTES

## RELATED LINKS

