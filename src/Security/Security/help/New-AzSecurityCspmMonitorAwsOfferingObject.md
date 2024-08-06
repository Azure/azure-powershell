---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritycspmmonitorawsofferingobject
schema: 2.0.0
---

# New-AzSecurityCspmMonitorAwsOfferingObject

## SYNOPSIS
Create an in-memory object for CspmMonitorAwsOffering.

## SYNTAX

```
New-AzSecurityCspmMonitorAwsOfferingObject [-NativeCloudConnectionCloudRoleArn <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CspmMonitorAwsOffering.

## EXAMPLES

### Example 1: Create new CspmMonitorAwsOffering object
```powershell
New-AzSecurityCspmMonitorAwsOfferingObject -NativeCloudConnectionCloudRoleArn "arn:aws:iam::123456789012:role/CspmMonitorAws"
```

```output
Description NativeCloudConnectionCloudRoleArn             OfferingType
----------- ---------------------------------             ------------
            arn:aws:iam::123456789012:role/CspmMonitorAws CspmMonitorAws
```

## PARAMETERS

### -NativeCloudConnectionCloudRoleArn
The cloud role ARN in AWS for this feature.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.CspmMonitorAwsOffering

## NOTES

## RELATED LINKS
