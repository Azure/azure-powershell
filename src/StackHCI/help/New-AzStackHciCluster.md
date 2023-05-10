---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhcicluster
schema: 2.0.0
---

# New-AzStackHciCluster

## SYNOPSIS
Create an HCI cluster.

## SYNTAX

```
New-AzStackHciCluster -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-AadApplicationObjectId <String>] [-AadClientId <String>] [-AadServicePrincipalObjectId <String>]
 [-AadTenantId <String>] [-CloudManagementEndpoint <String>]
 [-DesiredPropertyDiagnosticLevel <DiagnosticLevel>]
 [-DesiredPropertyWindowsServerSubscription <WindowsServerSubscription>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an HCI cluster.

## EXAMPLES

### Example 1: 
```powershell
New-AzStackHciCluster -Name "myCluster" -ResourceGroupName "test-rg" -AadTenantId "c76bd4d1-bea3-45ea-be1b-4a745a675d07" -AadClientId "24a6e53d-04e5-44d2-b7cc-1b732a847dfc" -Location "eastus"
```

```output
Location Name      ResourceGroupName
-------- ----      -----------------
eastus   myCluster test-rg
```

This command creates a Stack HCI cluster

### Example 2: 
```powershell
New-AzStackHciCluster -Name "myCluster2" -ResourceGroupName "test-rg" -AadTenantId "c76bd4d1-bea3-45ea-be1b-4a745a675d07" -AadClientId "24a6e53d-04e5-44d2-b7cc-1b732a847dfc" -Location "westeurope" -DesiredPropertyDiagnosticLevel "Off" -DesiredPropertyWindowsServerSubscription "Enabled"
```

```output
Location   Name       ResourceGroupName
--------   ----       -----------------
westeurope myCluster2 test-rg
```

This command creates a Stack HCI cluster with DiagnosticLevel = "Off" and WindowsServerSubscription = "Enabled".
By default, these values are set to "Basic" and "Disabled" respectively.

## PARAMETERS

### -AadApplicationObjectId
Object id of cluster AAD identity.

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

### -AadClientId
App id of cluster AAD identity.

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

### -AadServicePrincipalObjectId
Id of cluster identity service principal.

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

### -AadTenantId
Tenant id of cluster AAD identity.

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

### -CloudManagementEndpoint
Endpoint configured for management from the Azure portal.

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

### -DesiredPropertyDiagnosticLevel
Desired level of diagnostic data emitted by the cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.DiagnosticLevel
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DesiredPropertyWindowsServerSubscription
Desired state of Windows Server Subscription.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.WindowsServerSubscription
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20220501.ICluster

## NOTES

ALIASES

## RELATED LINKS

