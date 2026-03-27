---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/invoke-azdevcenteruseralignpool
schema: 2.0.0
---

# Invoke-AzDevCenterUserAlignPool

## SYNOPSIS
Aligns all Dev Boxes in the pool with the current configuration.

## SYNTAX

### AlignExpanded (Default)
```
Invoke-AzDevCenterUserAlignPool -Endpoint <String> -PoolName <String> -ProjectName <String>
 -Target <PoolAlignTarget[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Align
```
Invoke-AzDevCenterUserAlignPool -Endpoint <String> -PoolName <String> -ProjectName <String>
 -Body <IPoolAlignBody> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AlignViaIdentity
```
Invoke-AzDevCenterUserAlignPool -Endpoint <String> -InputObject <IDevCenterdataIdentity> -Body <IPoolAlignBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AlignViaIdentityExpanded
```
Invoke-AzDevCenterUserAlignPool -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 -Target <PoolAlignTarget[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AlignByDevCenter
```
Invoke-AzDevCenterUserAlignPool -DevCenterName <String> -PoolName <String> -ProjectName <String>
 -Body <IPoolAlignBody> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AlignViaIdentityByDevCenter
```
Invoke-AzDevCenterUserAlignPool -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 -Body <IPoolAlignBody> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AlignExpandedByDevCenter
```
Invoke-AzDevCenterUserAlignPool -DevCenterName <String> -PoolName <String> -ProjectName <String>
 -Target <PoolAlignTarget[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AlignViaIdentityExpandedByDevCenter
```
Invoke-AzDevCenterUserAlignPool -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 -Target <PoolAlignTarget[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Aligns all Dev Boxes in the pool with the current configuration.

## EXAMPLES

### Example 1: Align all Dev Boxes in a pool by endpoint and target
```powershell
Invoke-AzDevCenterUserAlignPool `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -PoolName "DevPool01" `
  -Target "NetworkProperties"
```

This command aligns all Dev Boxes in the pool "DevPool01" in project "DevProject" on the "NetworkProperties" target using the endpoint.

### Example 2: Align all Dev Boxes in a pool by dev center name and multiple targets
```powershell
Invoke-AzDevCenterUserAlignPool `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -PoolName "DevPool01" `
  -Target "NetworkProperties"
```

This command aligns all Dev Boxes in the pool "DevPool01" on both "NetworkProperties" and "DevBoxDefinition" using the dev center name.

### Example 3: Align all Dev Boxes in a pool using InputObject and endpoint
```powershell
$poolInput = @{
    ProjectName = "DevProject"
    PoolName = "DevPool01"
}
Invoke-AzDevCenterUserAlignPool `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $poolInput `
  -Target "NetworkProperties"
```

This command aligns all Dev Boxes in the pool "DevPool01" using the endpoint and an identity object.

### Example 4: Align all Dev Boxes in a pool using Body parameter
```powershell
$body = @{
    Target = @("NetworkProperties")
}
Invoke-AzDevCenterUserAlignPool `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -PoolName "DevPool01" `
  -Body $body
```

This command aligns all Dev Boxes in the pool "DevPool01" using the dev center name and a body object specifying the target.

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

### -Body
Indicates which pool properties to align on.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IPoolAlignBody
Parameter Sets: Align, AlignViaIdentity, AlignByDevCenter, AlignViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: AlignByDevCenter, AlignViaIdentityByDevCenter, AlignExpandedByDevCenter, AlignViaIdentityExpandedByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: AlignExpanded, Align, AlignViaIdentity, AlignViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: AlignViaIdentity, AlignViaIdentityExpanded, AlignViaIdentityByDevCenter, AlignViaIdentityExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -PoolName
Pool name.

```yaml
Type: System.String
Parameter Sets: AlignExpanded, Align, AlignByDevCenter, AlignExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: AlignExpanded, Align, AlignByDevCenter, AlignExpandedByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
The targets to align on.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Support.PoolAlignTarget[]
Parameter Sets: AlignExpanded, AlignViaIdentityExpanded, AlignExpandedByDevCenter, AlignViaIdentityExpandedByDevCenter
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IPoolAlignBody

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
