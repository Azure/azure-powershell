---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceKubernetesObject
schema: 2.0.0
---

# New-AzMLWorkspaceKubernetesObject

## SYNOPSIS
Create an in-memory object for Kubernetes.

## SYNTAX

```
New-AzMLWorkspaceKubernetesObject [-DefaultInstanceType <String>] [-Description <String>]
 [-DisableLocalAuth <Boolean>] [-ExtensionInstanceReleaseTrain <String>] [-ExtensionPrincipalId <String>]
 [-InstanceLimit <Hashtable>] [-InstanceNodeSelector <Hashtable>] [-InstanceRequest <Hashtable>]
 [-Namespace <String>] [-RelayConnectionString <String>] [-ResourceId <String>]
 [-ServiceBusConnectionString <String>] [-VcName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Kubernetes.

## EXAMPLES

### Example 1: Create an in-memory object for Kubernetes
```powershell
New-AzMLWorkspaceKubernetesObject
```

```output
{{ Add output here }}
```

Create an in-memory object for Kubernetes

## PARAMETERS

### -DefaultInstanceType
Default instance type.

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

### -Description
The description of the Machine Learning compute.

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

### -DisableLocalAuth
Opt-out of local authentication and ensure customers can use only MSI and AAD exclusively for authentication.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionInstanceReleaseTrain
Extension instance release train.

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

### -ExtensionPrincipalId
Extension principal-id.

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

### -InstanceLimit
Resource limits for this instance type.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceNodeSelector
Node Selector.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceRequest
Resource requests for this instance type.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Compute namespace.

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

### -RelayConnectionString
Relay connection string.

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

### -ResourceId
ARM resource id of the underlying compute.

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

### -ServiceBusConnectionString
ServiceBus connection string.

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

### -VcName
VC name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.Kubernetes

## NOTES

ALIASES

## RELATED LINKS

