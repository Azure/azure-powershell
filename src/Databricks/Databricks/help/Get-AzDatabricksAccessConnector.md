---
external help file: Az.Databricks-help.xml
Module Name: Az.Databricks
online version: https://learn.microsoft.com/powershell/module/az.databricks/get-azdatabricksaccessconnector
schema: 2.0.0
---

# Get-AzDatabricksAccessConnector

## SYNOPSIS
Gets an Azure Databricks Access Connector.

## SYNTAX

### List1 (Default)
```
Get-AzDatabricksAccessConnector [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDatabricksAccessConnector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzDatabricksAccessConnector -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDatabricksAccessConnector -InputObject <IDatabricksIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Azure Databricks Access Connector.

## EXAMPLES

### Example 1: List all access connectors under a subscription.
```powershell
Get-AzDatabricksAccessConnector
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command lists all access connectors under a subscription.

### Example 2: List all access connectors under a resource group.
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command lists all access connectors under a resource group.

### Example 3: Get a access connectors by name.
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName azps_test_gp_db -Name azps-databricks-accessconnector
```

```output
Location Name                            ResourceGroupName
-------- ----                            -----------------
eastus   azps-databricks-accessconnector azps_test_gp_db
```

This command gets a access connectors by name.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Azure Databricks Access Connector.

```yaml
Type: System.String
Parameter Sets: Get
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IAccessConnector

## NOTES

## RELATED LINKS
