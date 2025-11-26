---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TestModule.dll-Help.xml
Module Name: Az.TestModule
online version: https://learn.microsoft.com/powershell/module/az.testmodule/new-testresource
schema: 2.0.0
---

# New-TestResource

## SYNOPSIS
Creates a new test resource.

## SYNTAX

```
New-TestResource [-ResourceGroupName] <String> [-ResourceName] <String> [-Location] <String>
 [-Sku <String>] [-Capacity <Int32>] [-EnableLogging] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The New-TestResource cmdlet creates a new test resource in Azure.

## EXAMPLES

### Example 1: Create a test resource
```powershell
New-TestResource -ResourceGroupName "myRG" -ResourceName "myResource" -Location "eastus"
```

Creates a test resource.

## PARAMETERS

### -ResourceGroupName
The resource group name.

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

### -ResourceName
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU.

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

### -Capacity
The capacity.

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

### -EnableLogging
Enable logging.

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
