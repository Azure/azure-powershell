---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/get-azdocumentdbuser
schema: 2.0.0
---

# Get-AzDocumentDBUser

## SYNOPSIS
Gets the defintion of a Mongo cluster user.

## SYNTAX

### List (Default)
```
Get-AzDocumentDBUser -MongoClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDocumentDBUser -MongoClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityMongoCluster
```
Get-AzDocumentDBUser -Name <String> -MongoClusterInputObject <IDocumentDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDocumentDBUser -InputObject <IDocumentDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the defintion of a Mongo cluster user.

## EXAMPLES

### Example 1: Get a Microsoft Entra ID user of a mongo cluster
```powershell
Get-AzDocumentDBUser -Name 71581c6f-df31-4790-bc49-26c6b38df8bd -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                                  ProvisioningState
----                                  -----------------
71581c6f-df31-4790-bc49-26c6b38df8bd  Succeeded
```

Get a single Microsoft Entra ID user of a mongo cluster by object id.

### Example 2: List the Microsoft Entra ID users of a mongo cluster
```powershell
Get-AzDocumentDBUser -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name                                  ProvisioningState
----                                  -----------------
71581c6f-df31-4790-bc49-26c6b38df8bd  Succeeded
```

List all Microsoft Entra ID users of a mongo cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MongoClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity
Parameter Sets: GetViaIdentityMongoCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MongoClusterName
The name of the mongo cluster.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the mongo cluster user.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityMongoCluster
Aliases: UserName

Required: True
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUser

## NOTES

## RELATED LINKS
