---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilesquotalimit
schema: 2.0.0
---

# Get-AzNetAppFilesQuotaLimit

## SYNOPSIS
Get quota limits

## SYNTAX

```
Get-AzNetAppFilesQuotaLimit -Location <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the default and current limits for Azure NetApp Files (ANF) quotas

## EXAMPLES

### Example 1
```powershell
Get-AzNetAppFilesQuotaLimit -Location "westus2"  -Name totalTiBsPerSubscription
```

```output
Name                             Current Default
----                             ------- -------
westus2/totalTiBsPerSubscription      25      25
```

This command gets the Quota Limits named totalTiBsPerSubscription

## PARAMETERS

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

### -Location
The location of the resource

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
The name of the Quota Limit

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: QuotaLimitName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesSubscriptionQuotaLimit

## NOTES

## RELATED LINKS
