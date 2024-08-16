---
external help file:
Module Name: Az.SapVirtualInstance
online version: https://learn.microsoft.com/powershell/module/az.sapvirtualinstance/update-azworkloadssapvirtualinstance
schema: 2.0.0
---

# Update-AzWorkloadsSapVirtualInstance

## SYNOPSIS
Updates a Virtual Instance for SAP solutions resource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWorkloadsSapVirtualInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IdentityType <ManagedServiceIdentityType>]
 [-ManagedResourcesNetworkAccessType <ManagedResourcesNetworkAccessType>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWorkloadsSapVirtualInstance -InputObject <ISapVirtualInstanceIdentity>
 [-IdentityType <ManagedServiceIdentityType>]
 [-ManagedResourcesNetworkAccessType <ManagedResourcesNetworkAccessType>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a Virtual Instance for SAP solutions resource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -IdentityType
Type of manage identity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedResourcesNetworkAccessType
Specifies the network access configuration for the resources that will be deployed in the Managed Resource Group.
The options to choose from are Public and Private.
If 'Private' is chosen, the Storage Account service tag should be enabled on the subnets in which the SAP VMs exist.
This is required for establishing connectivity between VM extensions and the managed resource group storage account.
This setting is currently applicable only to Storage Account.
Learn more here https://go.microsoft.com/fwlink/linkid=2247228

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.ManagedResourcesNetworkAccessType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Virtual Instances for SAP solutions resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: SapVirtualInstanceName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Gets or sets the Resource tags.

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

### -UserAssignedIdentity
User assigned identities dictionary

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.ISapVirtualInstance

## NOTES

## RELATED LINKS


