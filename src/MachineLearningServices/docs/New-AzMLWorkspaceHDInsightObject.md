---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceHDInsightObject
schema: 2.0.0
---

# New-AzMLWorkspaceHDInsightObject

## SYNOPSIS
Create an in-memory object for HDInsight.

## SYNTAX

```
New-AzMLWorkspaceHDInsightObject [-Address <String>] [-AdministratorAccountPassword <String>]
 [-AdministratorAccountPrivateKeyData <String>] [-AdministratorAccountPublicKeyData <String>]
 [-AdministratorAccountUsername <String>] [-Description <String>] [-DisableLocalAuth <Boolean>]
 [-ResourceId <String>] [-SshPort <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HDInsight.

## EXAMPLES

### Example 1: Create an in-memory object for HDInsight
```powershell
New-AzMLWorkspaceHDInsightObject
```

Create an in-memory object for HDInsight

## PARAMETERS

### -Address
Public IP address of the master node of the cluster.

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

### -AdministratorAccountPassword
Password of admin account.

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

### -AdministratorAccountPrivateKeyData
Private key data.

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

### -AdministratorAccountPublicKeyData
Public key data.

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

### -AdministratorAccountUsername
Username of admin account.

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

### -SshPort
Port open for ssh connections on the master node of the cluster.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.HdInsight

## NOTES

ALIASES

## RELATED LINKS

