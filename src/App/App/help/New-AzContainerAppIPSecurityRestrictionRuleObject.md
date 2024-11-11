---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappipsecurityrestrictionruleobject
schema: 2.0.0
---

# New-AzContainerAppIPSecurityRestrictionRuleObject

## SYNOPSIS
Create an in-memory object for IPSecurityRestrictionRule.

## SYNTAX

```
New-AzContainerAppIPSecurityRestrictionRuleObject -Action <String> -IPAddressRange <String> -Name <String>
 [-Description <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IPSecurityRestrictionRule.

## EXAMPLES

### Example 1: Create an in-memory object for IPSecurityRestrictionRule.
```powershell
New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
```

```output
Action Description IPAddressRange Name
------ ----------- -------------- ----
Allow              192.168.1.1/32 Allow work IP A subnet
```

Create an in-memory object for IPSecurityRestrictionRule.

## PARAMETERS

### -Action
Allow or Deny rules to determine for incoming IP.
Note: Rules can only consist of ALL Allow or ALL Deny.

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

### -Description
Describe the IP restriction rule that is being sent to the container-app.
This is an optional field.

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

### -IPAddressRange
CIDR notation to match incoming IP address.

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
Name for the IP restriction rule.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IPSecurityRestrictionRule

## NOTES

## RELATED LINKS
