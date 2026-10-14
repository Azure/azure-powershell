---
external help file: Az.Discovery-help.xml
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/new-azdiscoverynodepool
schema: 2.0.0
---

# New-AzDiscoveryNodePool

## SYNOPSIS
Create a NodePool

## SYNTAX

### CreateExpanded (Default)
```
New-AzDiscoveryNodePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -SupercomputerName <String> -Location <String> [-ImageCacheLowerThreshold <Int32>]
 [-ImageCacheUpperThreshold <Int32>] [-MaxNodeCount <Int32>] [-MinNodeCount <Int32>] [-OSDiskSizeGb <Int32>]
 [-ScaleSetPriority <String>] [-SubnetId <String>] [-Tag <Hashtable>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDiscoveryNodePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -SupercomputerName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDiscoveryNodePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -SupercomputerName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentitySupercomputerExpanded
```
New-AzDiscoveryNodePool -Name <String> -SupercomputerInputObject <IDiscoveryIdentity> -Location <String>
 [-ImageCacheLowerThreshold <Int32>] [-ImageCacheUpperThreshold <Int32>] [-MaxNodeCount <Int32>]
 [-MinNodeCount <Int32>] [-OSDiskSizeGb <Int32>] [-ScaleSetPriority <String>] [-SubnetId <String>]
 [-Tag <Hashtable>] [-VMSize <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a NodePool

## EXAMPLES

### Example 1: Create a new node pool
```powershell
New-AzDiscoveryNodePool -ResourceGroupName "my-rg" -SupercomputerName "my-supercomputer" -Name "my-pool" -Location "eastus" -VMSize "Standard_D4s_v3" -MinNodeCount 1 -MaxNodeCount 10
```

```output
Location    Name        ResourceGroupName    ProvisioningState
--------    ----        -----------------    -----------------
eastus      my-pool     my-rg                Succeeded
```

Creates a new node pool under the specified supercomputer.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -ImageCacheLowerThreshold
The percent of disk usage before which image garbage collection is never run.
This cannot be set higher than imageCacheUpperThreshold.
The default is 40%

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageCacheUpperThreshold
The percent of disk usage after which image garbage collection is guaranteed to run.
The default is 60%

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxNodeCount
The maximum number of nodes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinNodeCount
The minimum number of nodes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NodePool

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NodePoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -OSDiskSizeGb
The size of the OS disk in GB.
If not specified, the default is 120 GB.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleSetPriority
The Virtual Machine Scale Set priority.
If not specified, the default is 'Regular'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
The node pool subnet.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupercomputerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: CreateViaIdentitySupercomputerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SupercomputerName
The name of the Supercomputer

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize
The size of the underlying Azure VM.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySupercomputerExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePool

## NOTES

## RELATED LINKS
