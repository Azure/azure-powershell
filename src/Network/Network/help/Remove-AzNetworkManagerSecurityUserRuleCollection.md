---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-aznetworkmanagersecurityuserrulecollection
schema: 2.0.0
---

# Remove-AzNetworkManagerSecurityUserRuleCollection

## SYNOPSIS
Removes a security user rule collection.

## SYNTAX

### ByName (Default)
```
Remove-AzNetworkManagerSecurityUserRuleCollection -Name <String> -SecurityUserConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-ForceDelete] [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzNetworkManagerSecurityUserRuleCollection -InputObject <PSNetworkManagerSecurityUserRuleCollection>
 [-ForceDelete] [-Force] [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceId
```
Remove-AzNetworkManagerSecurityUserRuleCollection -ResourceId <String> [-ForceDelete] [-Force] [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzNetworkManagerSecurityUserRuleCollection** cmdlet removes a security user rule collection.

## EXAMPLES

### Example 1
```powershell
Remove-AzNetworkManagerSecurityUserRuleCollection -Name TestRuleCollectionName -SecurityUserConfigurationName TestUserConfigName -NetworkManagerName TestNMName -ResourceGroupName TestRGName
```

Removes a security user rule collection.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

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

### -ForceDelete
Deletes the resource even if it is part of a deployed configuration.
If the configuration has been deployed, the service will do a cleanup deployment in the background, prior to the delete.

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

### -InputObject
The SecurityUser rule collection resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserRuleCollection
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -PassThru
{{ Fill PassThru Description }}

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
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
The resource id.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityUserConfigurationName
The network manager security user configuration name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityUserRuleCollection](./Get-AzNetworkManagerSecurityUserRuleCollection.md)

[New-AzNetworkManagerSecurityUserRuleCollection](./New-AzNetworkManagerSecurityUserRuleCollection.md)

[Set-AzNetworkManagerSecurityUserRuleCollection](./Set-AzNetworkManagerSecurityUserRuleCollection.md)