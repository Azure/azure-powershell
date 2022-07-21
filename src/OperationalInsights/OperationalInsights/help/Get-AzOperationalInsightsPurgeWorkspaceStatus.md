---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/Get-AzOperationalInsightsPurgeWorkspaceStatus
schema: 2.0.0
---

# Get-AzOperationalInsightsPurgeWorkspaceStatus

## SYNOPSIS
Gets status of an ongoing purge operation.

## SYNTAX

```
Get-AzOperationalInsightsPurgeWorkspaceStatus [-ResourceGroupName] <String> [-WorkspaceName] <String>
 [-PurgeId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets status of an ongoing purge operation.

## EXAMPLES

### Example 1
```powershell
Get-AzOperationalInsightsPurgeWorkspaceStatus -ResourceGroupName "ContosoResourceGroup" -WorkspaceName "MyWorkspace" -PurgeId "cd944bc7-ba11-447e-910c-c6393ac020a9"
```

This command gets the status of an ongoing purge operation by resource group name, workspace name and the purge id returned from New-AzOperationalInsightsPurgeWorkspace command.

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

### -PurgeId
In a purge status request, this is the Id of the operation the status of which is returned.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace that contains the table.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspacePurgeStatusResponse

## NOTES

## RELATED LINKS
