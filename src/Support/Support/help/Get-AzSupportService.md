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

## DESCRIPTION
Gets the current list of Azure services for which support is available. Each Azure service has its own set of categories called problem classification. Get the current list of problem classification for a service using Get-AzSupportProblemClassification. You can use the service and problem classification GUID to create a new support ticket using New-AzSupportTicket.

Always use the service and problem classification GUIDs obtained programmatically. This practice ensures that you have the most recent set of service and problem classification GUIDs for support ticket creation. 

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportService

## NOTES

## RELATED LINKS
