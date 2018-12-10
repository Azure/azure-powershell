---
external help file: Microsoft.Azure.Commands.LogicApp.dll-Help.xml
Module Name: Az.LogicApp
online version:
schema: 2.0.0
---

# Remove-AzIntegrationAccountBatchConfiguration

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIntegrationAccount (Default)
```
Remove-AzIntegrationAccountBatchConfiguration [-ResourceGroupName <String>] [-ParentName <String>]
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzIntegrationAccountBatchConfiguration [-ResourceGroupName <String>] [-ParentName <String>]
 [-Name <String>] -InputObject <BatchConfiguration> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceId
```
Remove-AzIntegrationAccountBatchConfiguration [-ResourceGroupName <String>] [-ParentName <String>]
 [-Name <String>] -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
An integration account batch configuration.

```yaml
Type: Microsoft.Azure.Management.Logic.Models.BatchConfiguration
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The integration account batch configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BatchConfigurationName, ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentName
The integration account name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: IntegrationAccountName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The integration account resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The integration account batch configuration resource id.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Management.Logic.Models.BatchConfiguration

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
