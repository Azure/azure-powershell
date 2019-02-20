---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://docs.microsoft.com/en-us/powershell/module/az.security/set-azsecuritythreatprotection
schema: 2.0.0
---

# Set-AzSecurityThreatProtection

## SYNOPSIS
Sets the threat protection policy for a storage account.

## SYNTAX

### PolicyOn
```
Set-AzSecurityThreatProtection -ResourceId <String> [-Enable] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PolicyOff
```
Set-AzSecurityThreatProtection -ResourceId <String> [-Disable] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The "Set-AzSecurityThreatProtection" cmdlet sets the threat protetion policy of a storage account.
To use this cmdlet, specify the *ResourceId* and *-Enable* OR *-Disable* parameters to activate or deactivate the policy.


## EXAMPLES

### Example 1:  Enable Advanced Threat Protection policy:
```powershell
PS C:\> Set-AzSecurityThreatProtection -ResourceId "/subscriptions/xxxxxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount/" -Enable

IsEnabled Id
--------- --
    True  "/subscriptions/xxxxxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount/"
```
This command enables the threat protection policy for resource id "/subscriptions/xxxxxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount/".
### Example 2:  Disable Advanced Threat Protection policy:
```powershell
PS C:\> Set-AzSecurityThreatProtection -ResourceId "/subscriptions/xxxxxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount/" -Disable

IsEnabled Id
--------- --
    False  "/subscriptions/xxxxxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount/"
```
This command disables the threat protection policy for resource id "/subscriptions/xxxxxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount/".
## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Disables Threat Protection policy.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PolicyOff
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enable
Enables Threat Protection policy.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PolicyOn
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the security resource that you want to invoke the command on.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.ThreatProtection.PSThreatProtection

## NOTES

## RELATED LINKS
