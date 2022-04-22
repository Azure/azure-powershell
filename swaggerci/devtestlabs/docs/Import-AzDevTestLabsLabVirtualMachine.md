---
external help file:
Module Name: Az.DevTestLabs
online version: https://docs.microsoft.com/en-us/powershell/module/az.devtestlabs/import-azdevtestlabslabvirtualmachine
schema: 2.0.0
---

# Import-AzDevTestLabsLabVirtualMachine

## SYNOPSIS
Import a virtual machine into a different lab.
This operation can take a while to complete.

## SYNTAX

### ImportExpanded (Default)
```
Import-AzDevTestLabsLabVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DestinationVirtualMachineName <String>] [-SourceVirtualMachineResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Import
```
Import-AzDevTestLabsLabVirtualMachine -Name <String> -ResourceGroupName <String>
 -ImportLabVirtualMachineRequest <IImportLabVirtualMachineRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzDevTestLabsLabVirtualMachine -InputObject <IDevTestLabsIdentity>
 -ImportLabVirtualMachineRequest <IImportLabVirtualMachineRequest> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzDevTestLabsLabVirtualMachine -InputObject <IDevTestLabsIdentity>
 [-DestinationVirtualMachineName <String>] [-SourceVirtualMachineResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Import a virtual machine into a different lab.
This operation can take a while to complete.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DestinationVirtualMachineName
The name of the virtual machine in the destination lab

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportLabVirtualMachineRequest
This represents the payload required to import a virtual machine from a different lab into the current one
To construct, see NOTES section for IMPORTLABVIRTUALMACHINEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IImportLabVirtualMachineRequest
Parameter Sets: Import, ImportViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity
Parameter Sets: ImportViaIdentity, ImportViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the lab.

```yaml
Type: System.String
Parameter Sets: Import, ImportExpanded
Aliases:

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

### -PassThru
Returns true when the command succeeds

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

```yaml
Type: System.String
Parameter Sets: Import, ImportExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceVirtualMachineResourceId
The full resource ID of the virtual machine to be imported.

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: Import, ImportExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IImportLabVirtualMachineRequest

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


IMPORTLABVIRTUALMACHINEREQUEST <IImportLabVirtualMachineRequest>: This represents the payload required to import a virtual machine from a different lab into the current one
  - `[DestinationVirtualMachineName <String>]`: The name of the virtual machine in the destination lab
  - `[SourceVirtualMachineResourceId <String>]`: The full resource ID of the virtual machine to be imported.

INPUTOBJECT <IDevTestLabsIdentity>: Identity Parameter
  - `[ArtifactSourceName <String>]`: The name of the artifact source.
  - `[Id <String>]`: Resource identity path
  - `[LabName <String>]`: The name of the lab.
  - `[LocationName <String>]`: The name of the location.
  - `[Name <String>]`: The name of the lab.
  - `[PolicySetName <String>]`: The name of the policy set.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ServiceFabricName <String>]`: The name of the service fabric.
  - `[SubscriptionId <String>]`: The subscription ID.
  - `[UserName <String>]`: The name of the user profile.
  - `[VirtualMachineName <String>]`: The name of the virtual machine.

## RELATED LINKS

