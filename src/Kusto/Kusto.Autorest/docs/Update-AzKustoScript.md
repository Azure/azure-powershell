---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/update-azkustoscript
schema: 2.0.0
---

# Update-AzKustoScript

## SYNOPSIS
Update a database script.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzKustoScript -ClusterName <String> -DatabaseName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ContinueOnError] [-ForceUpdateTag <String>]
 [-PrincipalPermissionsAction <String>] [-ScriptLevel <String>] [-ScriptUrl <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzKustoScript -ClusterName <String> -DatabaseName <String> -Name <String> -ResourceGroupName <String>
 -Parameter <IScript> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzKustoScript -InputObject <IKustoIdentity> -Parameter <IScript> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityCluster
```
Update-AzKustoScript -ClusterInputObject <IKustoIdentity> -DatabaseName <String> -Name <String>
 -Parameter <IScript> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzKustoScript -ClusterInputObject <IKustoIdentity> -DatabaseName <String> -Name <String>
 [-ContinueOnError] [-ForceUpdateTag <String>] [-PrincipalPermissionsAction <String>] [-ScriptLevel <String>]
 [-ScriptUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityDatabase
```
Update-AzKustoScript -DatabaseInputObject <IKustoIdentity> -Name <String> -Parameter <IScript>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityDatabaseExpanded
```
Update-AzKustoScript -DatabaseInputObject <IKustoIdentity> -Name <String> [-ContinueOnError]
 [-ForceUpdateTag <String>] [-PrincipalPermissionsAction <String>] [-ScriptLevel <String>]
 [-ScriptUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzKustoScript -InputObject <IKustoIdentity> [-ContinueOnError] [-ForceUpdateTag <String>]
 [-PrincipalPermissionsAction <String>] [-ScriptLevel <String>] [-ScriptUrl <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzKustoScript -ClusterName <String> -DatabaseName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzKustoScript -ClusterName <String> -DatabaseName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a database script.

## EXAMPLES

### Example 1: Update an existing kusto script by name
```powershell
Update-AzKustoScript -DatabaseName mykustodatabase -Name newkustoscript -ClusterName testnewkustocluster -ResourceGroupName testrg -ScriptUrl $BlobSASURL -ScriptUrlSasToken $BlobSASToken -PrincipalPermissionsAction RemovePermissionOnScriptCompletion -ScriptLevel Database
```

```output
Name                                               Type
----                                               ----
testnewkustocluster/mykustodatabase/newkustoscript Microsoft.Kusto/Clusters/Databases/Scripts
```

The above command updates the Kusto script "newkustoscript" found in the resource group "testrg".

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

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentityCluster, UpdateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityDatabaseExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentityDatabase, UpdateViaIdentityDatabaseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatabaseName
The name of the database in the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityCluster, UpdateViaIdentityClusterExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityDatabaseExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Kusto database script.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityCluster, UpdateViaIdentityClusterExpanded, UpdateViaIdentityDatabase, UpdateViaIdentityDatabaseExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IScript
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityCluster, UpdateViaIdentityDatabase
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityDatabaseExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptLevel
Differentiates between the type of script commands included - Database or Cluster.
The default is Database.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityDatabaseExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityDatabaseExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IScript

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IScript

## NOTES

## RELATED LINKS

