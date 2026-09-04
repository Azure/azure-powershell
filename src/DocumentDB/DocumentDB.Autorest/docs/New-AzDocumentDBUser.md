---
external help file:
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/new-azdocumentdbuser
schema: 2.0.0
---

# New-AzDocumentDBUser

## SYNOPSIS
Create a Microsoft Entra ID user on a mongo cluster.

## SYNTAX

```
New-AzDocumentDBUser -MongoClusterName <String> -Name <String> -ResourceGroupName <String> -Type <String>
 [-SubscriptionId <String>] [-Role <Hashtable[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create (grant) a Microsoft Entra ID principal access to a mongo cluster by assigning it
database roles.
The '-Type' parameter surfaces the Entra principal type; the service models
the identity provider as a discriminated union (identityProvider -\> microsoftEntraID -\>
principalType) that the generated cmdlet does not flatten, so this wrapper exposes a simple
'-Type' flag and builds the nested request body.

## EXAMPLES

### Example 1: Assign a Microsoft Entra ID user to a mongo cluster
```powershell
New-AzDocumentDBUser -Name 71581c6f-df31-4790-bc49-26c6b38df8bd -MongoClusterName myCluster -ResourceGroupName myResourceGroup `
    -Type User -Role @(@{ Db = 'admin'; Role = 'root' })
```

```output
Name                                  ProvisioningState
----                                  -----------------
71581c6f-df31-4790-bc49-26c6b38df8bd  Succeeded
```

Grant a Microsoft Entra ID principal data-plane access to a mongo cluster.
`-Name` is
the object id of the Entra principal, `-Type` is the principal type (`User` or
`ServicePrincipal`), and `-Role` assigns one or more database roles.
Microsoft Entra
authentication must be enabled on the cluster (see `-AuthConfigAllowedMode` on
`New-AzDocumentDBMongoCluster`).

## PARAMETERS

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

### -MongoClusterName
The name of the mongo cluster.

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
The Microsoft Entra object (client) ID of the user or service principal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: UserName

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

### -Role
The database roles to assign, each as a hashtable with 'Db' and 'Role' keys.
Example: -Role @(@{ Db = 'admin'; Role = 'root' })

```yaml
Type: System.Collections.Hashtable[]
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

### -Type
The Microsoft Entra principal type of the user.

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

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUser

## NOTES

## RELATED LINKS
