---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/reset-azdocumentdbmongoclusterpassword
schema: 2.0.0
---

# Reset-AzDocumentDBMongoClusterPassword

## SYNOPSIS
Reset the administrator password of a mongo cluster.

## SYNTAX

```
Reset-AzDocumentDBMongoClusterPassword -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -AdministratorPassword <SecureString> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Reset the administrator password of a mongo cluster.
The update runs as an HTTP PATCH that
only sends the properties provided.
The service requires the administrator login to be
included whenever the password is updated, so the cluster's existing administrator user name
is resolved and included in the request automatically.

## EXAMPLES

### Example 1: Reset the administrator password of a mongo cluster
```powershell
$password = ConvertTo-SecureString 'CliReset2026!Pw' -AsPlainText -Force
Reset-AzDocumentDBMongoClusterPassword -Name myCluster -ResourceGroupName myResourceGroup -AdministratorPassword $password
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Reset the administrator password of a mongo cluster.
The administrator user name is
read from the existing cluster, so only the new password is supplied.
The `-Password`
alias can be used in place of `-AdministratorPassword`.

## PARAMETERS

### -AdministratorPassword
The new administrator password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases: Password

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job.

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

### -Name
The name of the mongo cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MongoClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster

## NOTES

## RELATED LINKS
