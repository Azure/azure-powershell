---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/invoke-azstackhciconsentandinstalldefaultextension
schema: 2.0.0
---

# Invoke-AzStackHciConsentAndInstallDefaultExtension

## SYNOPSIS
Add consent time for default extensions and initiate extensions installation

## SYNTAX

### And (Default)
```
Invoke-AzStackHciConsentAndInstallDefaultExtension -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AndViaIdentity
```
Invoke-AzStackHciConsentAndInstallDefaultExtension -InputObject <IStackHciIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Add consent time for default extensions and initiate extensions installation

## EXAMPLES

### Example 1:
```powershell
Invoke-AzStackHciConsentAndInstallDefaultExtension -ResourceGroupName "test-rg" -ClusterName "test-clus"
```

```output
Resource Group AggregateState
-------------- --------------
test-rg  Connected
```

Consent for installation of default extensions.
ArcSettings resource is returned.

## PARAMETERS

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: And
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity
Parameter Sets: AndViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: And
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: And
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IArcSetting

## NOTES

## RELATED LINKS
