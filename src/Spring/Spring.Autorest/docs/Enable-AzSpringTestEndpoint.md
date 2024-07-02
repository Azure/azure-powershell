---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/enable-azspringtestendpoint
schema: 2.0.0
---

# Enable-AzSpringTestEndpoint

## SYNOPSIS
Enable test endpoint functionality for a Service.

## SYNTAX

### Enable (Default)
```
Enable-AzSpringTestEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentity
```
Enable-AzSpringTestEndpoint -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enable test endpoint functionality for a Service.

## EXAMPLES

### Example 1: Enable test endpoint functionality for a Service.
```powershell
Enable-AzSpringTestEndpoint -ResourceGroupName azps_test_group_spring -Name azps-spring-01
```

```output
Enabled               : True
PrimaryKey            : uuCEzTaXQ15sxbe2fMmmDC4uBsXxSt91fM1AHpZR1eCOM7tlmmmdLD2Esf6t5nej
PrimaryTestEndpoint   : https://primary:uuCEzTaXQ15sxbe2fMmmDC4uBsXxSt91fM1AHpZR1eCOM7tlmmmdLD2Esf6t5nej@azps-spring-01.test.azuremicroservices.io
SecondaryKey          : HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT
SecondaryTestEndpoint : https://secondary:HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT@azps-spring-01.test.azuremicroservices.io
```

Enable test endpoint functionality for a Service.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: EnableViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ITestKeys

## NOTES

## RELATED LINKS

