---
external help file: Az.Aks-help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azaksmanagedclustermeshrevisionprofile
schema: 2.0.0
---

# Get-AzAksManagedClusterMeshRevisionProfile

## SYNOPSIS
Contains extra metadata on the revision, including supported revisions, cluster compatibility and available upgrades

## SYNTAX

### List (Default)
```
Get-AzAksManagedClusterMeshRevisionProfile -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAksManagedClusterMeshRevisionProfile -Location <String> -Mode <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzAksManagedClusterMeshRevisionProfile -Mode <String> -LocationInputObject <IAksIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksManagedClusterMeshRevisionProfile -InputObject <IAksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Contains extra metadata on the revision, including supported revisions, cluster compatibility and available upgrades

## EXAMPLES

### Example 1: Get AKS Mesh Revision Profile
```powershell
Get-AzAksManagedClusterMeshRevisionProfile -Location eastus
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/providers/Microsoft.ContainerService/locations/eastus/meshRevisionProfiles/istio
MeshRevision                 : {{
                                 "revision": "asm-1-25",
                                 "upgrades": [ "asm-1-26", "asm-1-27" ],
                                 "compatibleWith": [
                                   {
                                     "name": "KubernetesOfficial",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33" ]
                                   },
                                   {
                                     "name": "AKSLongTermSupport",
                                     "versions": [ "1.28", "1.29", "1.30", "1.31", "1.32", "1.33" ]
                                   }
                                 ]
                               }, {
                                 "revision": "asm-1-26",
                                 "upgrades": [ "asm-1-27" ],
                                 "compatibleWith": [
                                   {
                                     "name": "KubernetesOfficial",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   },
                                   {
                                     "name": "AKSLongTermSupport",
                                     "versions": [ "1.28", "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   }
                                 ]
                               }, {
                                 "revision": "asm-1-27",
                                 "compatibleWith": [
                                   {
                                     "name": "KubernetesOfficial",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   },
                                   {
                                     "name": "AKSLongTermSupport",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   }
                                 ]
                               }}
Name                         : istio
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/locations/meshRevisionProfiles
```

Get extra metadata on the revision, including supported revisions, cluster compatibility and available upgrades.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
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
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Mode
The mode of the mesh.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMeshRevisionProfile

## NOTES

## RELATED LINKS
