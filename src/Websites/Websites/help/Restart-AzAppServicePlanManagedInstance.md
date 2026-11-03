---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/restart-azappserviceplanmanagedinstance
schema: 2.0.0
---

# Restart-AzAppServicePlanManagedInstance

## SYNOPSIS
Recycles a worker in a Managed Instance App Service plan.

## SYNTAX

### S1 (Default)
```
Restart-AzAppServicePlanManagedInstance [-ResourceGroupName] <String> [-Name] <String>
 -InstanceName <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### S2
```
Restart-AzAppServicePlanManagedInstance [-AppServicePlan] <PSAppServicePlan>
 -InstanceName <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Restart-AzAppServicePlanManagedInstance** cmdlet requests recycling of one Managed Instance worker.
Use **Get-AzAppServicePlanManagedInstance** to identify the worker name.
The cmdlet returns after the service accepts the request; it does not wait for the worker to become ready.
Recycling a worker can interrupt applications running on that worker.

## EXAMPLES

### Example 1: Recycle one worker
```powershell
Restart-AzAppServicePlanManagedInstance -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" -InstanceName "WORKER1" -PassThru
```

This command requests recycling of WORKER1 and returns true when the request is accepted.

### Example 2: Preview a recycle request
```powershell
Get-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" |
    Restart-AzAppServicePlanManagedInstance -InstanceName "WORKER1" -WhatIf
```

This command describes the recycle operation without submitting it.

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

### -AppServicePlan
The App Service plan object identifying the plan containing the worker.
Use **Get-AzAppServicePlan** to retrieve the object.

```yaml
Type: Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan
Parameter Sets: S2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -Confirm
Prompts for confirmation before requesting that the worker be recycled.

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

### -InstanceName
The name of the Managed Instance worker to recycle.

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

### -Name
The name of the Managed Instance App Service plan.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true after the service accepts the recycle request.
Without this parameter, no object is returned.

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
The resource group containing the Managed Instance App Service plan.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Describes the recycle operation without submitting it to Azure.

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
This cmdlet supports the common parameters. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzAppServicePlan](./Get-AzAppServicePlan.md)

[Get-AzAppServicePlanManagedInstance](./Get-AzAppServicePlanManagedInstance.md)
