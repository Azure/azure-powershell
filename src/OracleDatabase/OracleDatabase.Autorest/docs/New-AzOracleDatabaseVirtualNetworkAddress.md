---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/new-azoracledatabasevirtualnetworkaddress
schema: 2.0.0
---

# New-AzOracleDatabaseVirtualNetworkAddress

## SYNOPSIS
Create a VirtualNetworkAddress

## SYNTAX

### CreateExpanded (Default)
```
New-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IPAddress <String>] [-VMOcid <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername <String> -Name <String>
 -ResourceGroupName <String> -Resource <IVirtualNetworkAddress> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzOracleDatabaseVirtualNetworkAddress -InputObject <IOracleDatabaseIdentity>
 -Resource <IVirtualNetworkAddress> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityCloudVMCluster
```
New-AzOracleDatabaseVirtualNetworkAddress -CloudVMClusterInputObject <IOracleDatabaseIdentity> -Name <String>
 -Resource <IVirtualNetworkAddress> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityCloudVMClusterExpanded
```
New-AzOracleDatabaseVirtualNetworkAddress -CloudVMClusterInputObject <IOracleDatabaseIdentity> -Name <String>
 [-IPAddress <String>] [-VMOcid <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzOracleDatabaseVirtualNetworkAddress -InputObject <IOracleDatabaseIdentity> [-IPAddress <String>]
 [-VMOcid <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername <String> -Name <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername <String> -Name <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a VirtualNetworkAddress

## EXAMPLES

### Example 1: Create a Virtual Network Address on a Cloud VM Cluster resource
```powershell
New-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername "OFake_PowerShellTestVmCluster" -Name "virtualNetworkAddressName" -ResourceGroupName "PowerShellTestRg"
```

Create a Virtual Network Address on a Cloud VM Cluster resource.
For more information, execute `Get-Help New-AzOracleDatabaseVirtualNetworkAddress`.

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

### -CloudVMClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: CreateViaIdentityCloudVMCluster, CreateViaIdentityCloudVMClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Cloudvmclustername
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IPAddress
Virtual network Address address.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityCloudVMClusterExpanded, CreateViaIdentityExpanded
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

### -Name
Virtual IP address hostname.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityCloudVMCluster, CreateViaIdentityCloudVMClusterExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: Virtualnetworkaddressname

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

### -Resource
Virtual IP resource belonging to a vm cluster resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IVirtualNetworkAddress
Parameter Sets: Create, CreateViaIdentity, CreateViaIdentityCloudVMCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMOcid
Virtual Machine OCID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityCloudVMClusterExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IVirtualNetworkAddress

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IVirtualNetworkAddress

## NOTES

## RELATED LINKS

