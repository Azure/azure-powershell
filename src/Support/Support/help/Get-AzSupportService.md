---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# Get-AzSupportService

## SYNOPSIS
Get services for which support is available. 

## SYNTAX

### ListParameterSet (Default)
```
Get-AzSupportService [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzSupportService -Name <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSupportService -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get services for which support is available. Using the service name, you cam then retrieve list of problem classifications or issue types for that service for which support is available.

## EXAMPLES

### Example 1: Get all services available for support
```powershell
PS C:\> Get-AzSupportService | Select-Object -First 5 | ft Id, DisplayName

Id                                                   DisplayName
--                                                   -----------
/providers/Microsoft.Support/services/{service_guid} Activity Logs
/providers/Microsoft.Support/services/{service_guid} Advanced Threat Protection - Azure
/providers/Microsoft.Support/services/{service_guid} Advanced Threat Protection - Microsoft Defender
/providers/Microsoft.Support/services/{service_guid} Advanced Threat Protection - O365
/providers/Microsoft.Support/services/{service_guid} Advisor
```

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

### -Name
Name of Service resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of Service resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Support.Models.PSSupportService

## NOTES

## RELATED LINKS
