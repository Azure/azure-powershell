---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeploymentexistence
schema: 2.0.0
---

# Test-AzDeploymentExistence

## SYNOPSIS
Checks whether the deployment exists.

## SYNTAX

### Check (Default)
```
Test-AzDeploymentExistence -DeploymentName <String> -SubscriptionId <String> [-PassThru]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Check1
```
Test-AzDeploymentExistence -DeploymentName <String> -SubscriptionId <String> -ResourceGroupName <String>
 [-PassThru] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CheckViaIdentity1
```
Test-AzDeploymentExistence -InputObject <IResourcesIdentity> [-PassThru] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzDeploymentExistence -InputObject <IResourcesIdentity> [-PassThru] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Checks whether the deployment exists.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DeploymentName
The name of the deployment to check.

```yaml
Type: System.String
Parameter Sets: Check, Check1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: CheckViaIdentity1, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group with the deployment to check.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Check1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Check, Check1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### System.Boolean

## ALIASES

### Test-AzResourceGroupDeploymentExistence

## RELATED LINKS

