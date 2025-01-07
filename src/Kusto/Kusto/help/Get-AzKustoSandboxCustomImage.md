---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustosandboxcustomimage
schema: 2.0.0
---

# Get-AzKustoSandboxCustomImage

## SYNOPSIS
Returns a sandbox custom image

## SYNTAX

### List (Default)
```
Get-AzKustoSandboxCustomImage -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzKustoSandboxCustomImage -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKustoSandboxCustomImage -InputObject <IKustoIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Returns a sandbox custom image

## EXAMPLES

### Example 1: List all sandbox custom images in a cluster
```powershell
Get-AzKustoSandboxCustomImage -ClusterName "myCluster" -ResourceGroupName "myResourceGroup"
```

```output
Name
----
myCluser/myImage
```

The above command returns all Kusto sandbox custom images in cluster "myCluster" and resource group "myResourceGroup".

### Example 2: Get a sandbox custom image by name in cluster
```powershell
Get-AzKustoSandboxCustomImage -ClusterName "myCluster" -Name "myImage" -ResourceGroupName "myResourceGroup"
```

```output
Name
----
myCluser/myImage
```

The above command returns a Kusto sandbox custom image named "myImage" in cluster "myCluster" and resource group "myResourceGroup".

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the sandbox custom image.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SandboxCustomImageName

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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ISandboxCustomImage

## NOTES

## RELATED LINKS
