---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az.app/new-azcontainerappmanagedenvdapr
schema: 2.0.0
---

# New-AzContainerAppManagedEnvDapr

## SYNOPSIS
Creates or updates a Dapr Component in a Managed Environment.

## SYNTAX

```
New-AzContainerAppManagedEnvDapr -DaprName <String> -EnvName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ComponentType <String>] [-IgnoreError] [-InitTimeout <String>]
 [-Metadata <IDaprMetadata[]>] [-Scope <String[]>] [-Secret <ISecret[]>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Dapr Component in a Managed Environment.

## EXAMPLES

### Example 1: Creates or updates a Dapr Component in a Managed Environment.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

New-AzContainerAppManagedEnvDapr -DaprName azps-dapr -EnvName azps-env -ResourceGroupName azpstest_gp -componentType state.azure.cosmosdb -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName Version
----      -------------        ----------- ----------- ----------------- -------
azps-dapr state.azure.cosmosdb False       50s         azpstest_gp       v1
```

Creates or updates a Dapr Component in a Managed Environment.

## PARAMETERS

### -ComponentType
Component type

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

### -DaprName
Name of the Dapr Component.

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
```

### -EnvName
Name of the Managed Environment.

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

### -IgnoreError
Boolean describing if the component errors are ignores

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

### -InitTimeout
Initialization timeout

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

### -Metadata
Component metadata
To construct, see NOTES section for METADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IDaprMetadata[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -Scope
Names of container apps that can use this Dapr component

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Secret
Collection of secrets used by a Dapr component
To construct, see NOTES section for SECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ISecret[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Component version

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IDaprComponent

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


METADATA <IDaprMetadata[]>: Component metadata
  - `[Name <String>]`: Metadata property name.
  - `[SecretRef <String>]`: Name of the Dapr Component secret from which to pull the metadata property value.
  - `[Value <String>]`: Metadata property value.

SECRET <ISecret[]>: Collection of secrets used by a Dapr component
  - `[Name <String>]`: Secret Name.
  - `[Value <String>]`: Secret Value.

## RELATED LINKS

