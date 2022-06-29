---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.dll-Help.xml
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/get-azsentinelincident
schema: 2.0.0
---

# Get-AzSentinelIncident

## SYNOPSIS
Gets one or more Azure Sentinel Incidents.

## SYNTAX

### WorkspaceScope (Default)
```
Get-AzSentinelIncident -ResourceGroupName <String> -WorkspaceName <String> [-Filter <String>]
 [-OrderBy <String>] [-Max <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IncidentId
```
Get-AzSentinelIncident -ResourceGroupName <String> -WorkspaceName <String> [-IncidentId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Get-AzSentinelIncident -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSentinelIncident** cmdlet gets a specific or multiple Incidents from the specified workspace.
If you specify the *IncidentId* parameter, a single **Incident** object is returned.
If you do not specify the *IncidentId* parameter, an array containing Incidents in the specified workspace is returned.
Default, the module returns 1000 incidents. To fetch more than 1000, use the -Max parameter.
You can use the **Incident** object to update the Incident. For example you can add comments, change the severity, assign an owner, etc. to the **Incident**.

*Note: An IncidentId is in the following format: c464bcd7-daee-47ff-ac58-1fbb73cf1d6b and is not the same as the Incident ID (number) as in the Azure Sentinel Incident view. The IncidentId can be found in the incident details view, in the "Incident link" field, represented in the last part of the https link.*

## EXAMPLES

### Example 1
Get all Azure Sentinel Incidents using a connection object:


```powershell
$SentinelConnection = @{
    ResourceGroupName = "myResourceGroupName"
    WorkspaceName = "myWorkspaceName"
}
Get-AzSentinelIncident @SentinelConnection
```

This example gets all the the Incidents using a connection object

### Example 2
```powershell
$Incidents = Get-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName"
```

This example gets all of the Incidents in the specified workspace, and then stores it in the $Incidents variable.

### Example 3
```powershell
$Incident = Get-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId"
```

This example gets a specific Incident in the specified workspace, and then stores it in the $Incident variable.<br/>
*Please note that IncidentId is in this format: 168d330b-219b-4191-a5b1-742c211adb05*

### Example 4
```powershell
Get-AzSentinelIncident @SentinelConnection | Where-Object {$_.Title -eq "Failed AzureAD logons but success logon to host"}
```

This example uses a connection object and returns incidents with a specific title. <br/>
Using a **Where-Object** condition you can retrieve incidents with a specific title, status, severity, owner, etc.

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

### -Filter
Filters the results, based on a Boolean condition.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncidentId
Incident Id.

```yaml
Type: System.String
Parameter Sets: IncidentId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Max
Maximum number of records to return

```yaml
Type: System.Int32
Parameter Sets: WorkspaceScope
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderBy
Sorts the results

```yaml
Type: System.String
Parameter Sets: WorkspaceScope
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope, IncidentId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
Workspace Name.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope, IncidentId
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

### System.String
## OUTPUTS

### Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncident
## NOTES

## RELATED LINKS
