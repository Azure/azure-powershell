---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azexpressroutelagauthorization
schema: 2.0.0
---

# Remove-AzExpressRouteLagAuthorization

## SYNOPSIS
Removes an authorization from an ExpressRoute link aggregation group.

## SYNTAX

```
Remove-AzExpressRouteLagAuthorization -Name <String> -ExpressRouteLagObject <PSExpressRouteLag> [-Force]
 [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzExpressRouteLagAuthorization** cmdlet removes an authorization from an ExpressRoute link aggregation group (LAG).
Pass an ExpressRoute LAG object to the cmdlet.

## EXAMPLES

### Example 1
```powershell
$lag = Get-AzExpressRouteLag -ResourceGroupName "TestResourceGroup" -Name "TestLag"
$lag | Remove-AzExpressRouteLagAuthorization -Name "TestAuthorization" -Force
```

This example removes the authorization named `TestAuthorization` from the ExpressRoute LAG named `TestLag` without prompting for confirmation.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AsJob
Run the cmdlet in the background.

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

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteLagObject
The ExpressRoute LAG object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation when deleting the authorization.

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

### -Name
The name of the authorization.

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

### -PassThru
Returns `True` when the command succeeds.

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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
