---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/new-azkustoscript
schema: 2.0.0
---

# New-AzKustoScript

## SYNOPSIS
Creates a Kusto database script.

## SYNTAX

### CreateExpanded (Default)
```
New-AzKustoScript -ClusterName <String> -DatabaseName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ContinueOnError] [-ForceUpdateTag <String>]
 [-PrincipalPermissionsAction <PrincipalPermissionsAction>] [-ScriptContent <String>]
 [-ScriptLevel <ScriptLevel>] [-ScriptUrl <String>] [-ScriptUrlSasToken <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzKustoScript -ClusterName <String> -DatabaseName <String> -Name <String> -ResourceGroupName <String>
 -Parameter <IScript> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a Kusto database script.

## EXAMPLES

### Example 1: Create a Kusto database script
```powershell
New-AzKustoScript -ClusterName testnewkustocluster -DatabaseName mykustodatabase -Name newkustoscript -ResourceGroupName testrg -ScriptUrl $BlobSASURL -ScriptUrlSasToken $BlobSASToken -PrincipalPermissionsAction "RemovePermissionOnScriptCompletion" -ScriptLevel "Database"
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command creates a Kusto database script named "newkustocript" in the resource group "testrg".

This script contains database scoped commands and the permissions of the script executor will be removed upon completion

## PARAMETERS

### -AsJob
Run the command as a job

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

### -ClusterName
The name of the Kusto cluster.

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

### -ContinueOnError
Flag that indicates whether to continue if one of the command fails.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the database in the Kusto cluster.

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

### -ForceUpdateTag
A unique string.
If changed the script will be applied again.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Kusto database script.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ScriptName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Parameter
Class representing a database script.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IScript
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrincipalPermissionsAction
Indicates if the permissions for the script caller are kept following completion of the script.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalPermissionsAction
Parameter Sets: CreateExpanded
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

### -ScriptContent
The script content.
This property should be used when the script is provide inline and not through file in a SA.
Must not be used together with scriptUrl and scriptUrlSasToken properties.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptLevel
Differentiates between the type of script commands included - Database or Cluster.
The default is Database.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ScriptLevel
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptUrl
The url to the KQL script blob file.
Must not be used together with scriptContent property

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptUrlSasToken
The SaS token that provide read access to the file which contain the script.
Must be provided when using scriptUrl property.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IScript

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IScript

## NOTES

## RELATED LINKS

