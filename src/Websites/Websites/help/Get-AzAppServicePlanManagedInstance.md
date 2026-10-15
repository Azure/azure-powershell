---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azappserviceplanmanagedinstance
schema: 2.0.0
---

# Get-AzAppServicePlanManagedInstance

## SYNOPSIS
Gets worker instances in a Managed Instance App Service plan.

## SYNTAX

### S1 (Default)
```
Get-AzAppServicePlanManagedInstance [-ResourceGroupName] <String> [-Name] <String>
 [-InstanceName <String>] [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### S2
```
Get-AzAppServicePlanManagedInstance [-AppServicePlan] <PSAppServicePlan> [-InstanceName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAppServicePlanManagedInstance** cmdlet retrieves the worker names, IP addresses, and statuses for a Managed Instance App Service plan.
Specify **-InstanceName** to retrieve one worker by its case-insensitive name.
An error is returned if the specified worker is not present.

## EXAMPLES

### Example 1: List the instances in a Managed Instance plan
```powershell
Get-AzAppServicePlanManagedInstance -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan"
```

This command returns the worker instances and their private IP addresses.

### Example 2: Retrieve one instance using a plan from the pipeline
```powershell
Get-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" |
    Get-AzAppServicePlanManagedInstance -InstanceName "WORKER1"
```

This command retrieves WORKER1 from the plan.
Use its IPAddress property with a configured Azure Bastion or RDP client.

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
The App Service plan object identifying the plan whose workers are retrieved.
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
The name of the worker to retrieve.
Omit this parameter to list all workers in the plan.

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

### CommonParameters
This cmdlet supports the common parameters. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan

## OUTPUTS

### Microsoft.Azure.Management.WebSites.Models.ServerFarmInstance

## NOTES

## RELATED LINKS

[Get-AzAppServicePlan](./Get-AzAppServicePlan.md)
