---
external help file:
Module Name: Az.ContainerAppsApi
online version: https://learn.microsoft.com/powershell/module/az.containerappsapi/get-azcontainerappsapiavailableworkloadprofile
schema: 2.0.0
---

# Get-AzContainerAppsApiAvailableWorkloadProfile

## SYNOPSIS
Get all available workload profiles for a location.

## SYNTAX

### Get (Default)
```
Get-AzContainerAppsApiAvailableWorkloadProfile -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppsApiAvailableWorkloadProfile -InputObject <IContainerAppsApiIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get all available workload profiles for a location.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of Azure region.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IAvailableWorkloadProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerAppsApiIdentity>`: Identity Parameter
  - `[AuthConfigName <String>]`: Name of the Container App AuthConfig.
  - `[CertificateName <String>]`: Name of the Certificate.
  - `[ComponentName <String>]`: Name of the Dapr Component.
  - `[ConnectedEnvironmentName <String>]`: Name of the connectedEnvironment.
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[DetectorName <String>]`: Name of the Container App Detector.
  - `[EnvironmentName <String>]`: Name of the Environment.
  - `[Id <String>]`: Resource identity path
  - `[JobExecutionName <String>]`: Job execution name.
  - `[JobName <String>]`: Name of the Container Apps Job.
  - `[Location <String>]`: The name of Azure region.
  - `[ManagedCertificateName <String>]`: Name of the Managed Certificate.
  - `[ReplicaName <String>]`: Name of the Container App Revision Replica.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SourceControlName <String>]`: Name of the Container App SourceControl.
  - `[StorageName <String>]`: Name of the storage.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

