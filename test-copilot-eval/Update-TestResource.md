---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TestModule.dll-Help.xml
Module Name: Az.TestModule
online version: https://learn.microsoft.com/powershell/module/az.testmodule/update-testresource
schema: 2.0.0
---

# Update-TestResource

## SYNOPSIS
Updates.

## SYNTAX

```
Update-TestResource [-ResourceGroupName] <String> [-Name] <String> [-Tag <Hashtable>]
 [-Tier <String>] [-Count <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Updates resource.

## EXAMPLES

### Example 1
```powershell
Update-TestResource -ResourceGroupName "rg" -Name "res"
```

Updates.

## PARAMETERS

### -ResourceGroupName
RG.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tag.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tier
Tier.

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

### -Count
Count.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.TestModule.Models.PSTestResource

## NOTES

## RELATED LINKS
