---
external help file: Az.RedHatOpenShiftHcp-help.xml
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/get-azredhatopenshifthcpversion
schema: 2.0.0
---

# Get-AzRedHatOpenShiftHcpVersion

## SYNOPSIS
List installable HCP OpenShift versions, with optional control-plane / node-pool views.

## SYNTAX

### List (Default)
```
Get-AzRedHatOpenShiftHcpVersion -Location <String> [-SubscriptionId <String[]>] [-ControlPlane] [-NodePool]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRedHatOpenShiftHcpVersion -Location <String> [-SubscriptionId <String[]>] -Name <String> [-ControlPlane]
 [-NodePool] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzRedHatOpenShiftHcpVersion -Name <String> -LocationInputObject <IRedHatOpenShiftHcpIdentity>
 [-ControlPlane] [-NodePool] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRedHatOpenShiftHcpVersion -InputObject <IRedHatOpenShiftHcpIdentity> [-ControlPlane] [-NodePool]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Wraps the generated version-list cmdlet (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Get-AzRedHatOpenShiftHcpVersion).
For CLI parity (az aro hcp
get-versions), the list output is filtered to **enabled** versions and sorted ascending by semver -
disabled versions are hidden.
`-ControlPlane` returns the distinct **MAJOR.MINOR** versions a CLUSTER
accepts; `-NodePool` (and the default list) returns the full **X.Y.Z** patch versions a NODE POOL
requires.
The two switches are mutually exclusive.
A single lookup by `-Name` is returned as-is
(explicit requests are not filtered).

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ControlPlane
Return the distinct MAJOR.MINOR versions a cluster accepts (enabled only, sorted).
For -VersionId on New/Update-Cluster.

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
Use SubscriptionId instead.

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
Identity Parameter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the HcpOpenShiftVersion.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: HcpOpenShiftVersionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodePool
Return the full X.Y.Z patch versions a node pool requires (enabled only, sorted).
For -VersionId on New-NodePool.

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

### -SubscriptionId
The ID of the target subscription.
Defaults to the current Az context subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftVersion

## NOTES

## RELATED LINKS
