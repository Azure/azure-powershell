---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/enable-azspringtestendpoint
schema: 2.0.0
---

# Enable-AzSpringTestEndpoint

## SYNOPSIS
Enable test endpoint functionality for a Service.

## SYNTAX

### Enable (Default)
```
Enable-AzSpringTestEndpoint -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentity
```
Enable-AzSpringTestEndpoint -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Enable test endpoint functionality for a Service.

## EXAMPLES

### Example 1: Enable test endpoint functionality for a Service
```powershell
Enable-AzSpringTestEndpoint -ResourceGroupName Spring-gp-junxi -Name Spring-service -debug
```

```output
Enabled PrimaryKey  PrimaryTestEndpoint
------- ----------  -------------------
True    *******     https://primary:EZ0RH3NEDunYBmnAiK7LebCGpruoO…
```

Enable test endpoint functionality for a Service.

### Example 2: Enable test endpoint functionality for a Service by pipeline
```powershell
Get-AzSpring -ResourceGroupName lucas-rg-test -Name springapp-pwsh01 | Disable-AzSpringTestEndpoint 
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:EZ0RH3NEDunYBmnAiK7LebCGpruoO…
```

Enable test endpoint functionality for a Service by pipeline.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: EnableViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Enable
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: Enable
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Enable
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ITestKeys

## NOTES

## RELATED LINKS

