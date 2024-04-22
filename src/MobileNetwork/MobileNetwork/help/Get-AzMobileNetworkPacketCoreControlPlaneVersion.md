---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/get-azmobilenetworkpacketcorecontrolplaneversion
schema: 2.0.0
---

# Get-AzMobileNetworkPacketCoreControlPlaneVersion

## SYNOPSIS
Gets information about the specified packet core control plane version.

## SYNTAX

### List (Default)
```
Get-AzMobileNetworkPacketCoreControlPlaneVersion [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzMobileNetworkPacketCoreControlPlaneVersion -VersionName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMobileNetworkPacketCoreControlPlaneVersion -InputObject <IMobileNetworkIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified packet core control plane version.

## EXAMPLES

### Example 1: List information about the specified packet core control plane version by sub.
```powershell
Get-AzMobileNetworkPacketCoreControlPlaneVersion
```

```output
Name
----
PMN-4-9-0
pmn-2301-0-1
```

List information about the specified packet core control plane version by sub.

### Example 2: Get information about the specified packet core control plane version by VersionName.
```powershell
Get-AzMobileNetworkPacketCoreControlPlaneVersion -VersionName pmn-2301-0-1
```

```output
Name
----
pmn-2301-0-1
```

Get information about the specified packet core control plane version by VersionName.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -VersionName
The name of the packet core control plane version.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPacketCoreControlPlaneVersion

## NOTES

## RELATED LINKS
