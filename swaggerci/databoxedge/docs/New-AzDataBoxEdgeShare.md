---
external help file:
Module Name: Az.DataBoxEdge
online version: https://docs.microsoft.com/en-us/powershell/module/az.databoxedge/new-azdataboxedgeshare
schema: 2.0.0
---

# New-AzDataBoxEdgeShare

## SYNOPSIS
Creates a new share or updates an existing share on the device.

## SYNTAX

```
New-AzDataBoxEdgeShare -DeviceName <String> -Name <String> -ResourceGroupName <String>
 -AccessProtocol <ShareAccessProtocol> -MonitoringStatus <MonitoringStatus> -ShareStatus <ShareStatus>
 [-SubscriptionId <String>] [-AzureContainerInfoContainerName <String>]
 [-AzureContainerInfoDataFormat <AzureContainerDataFormat>]
 [-AzureContainerInfoStorageAccountCredentialId <String>] [-ClientAccessRights <IClientAccessRight[]>]
 [-DataPolicy <DataPolicy>] [-Description <String>] [-RefreshDetailErrorManifestFile <String>]
 [-RefreshDetailInProgressRefreshJobId <String>] [-RefreshDetailLastCompletedRefreshJobTimeInUtc <DateTime>]
 [-RefreshDetailLastJob <String>] [-UserAccessRights <IUserAccessRight[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new share or updates an existing share on the device.

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

### -AccessProtocol
Access protocol to be used by the share.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.ShareAccessProtocol
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AzureContainerInfoContainerName
Container name (Based on the data format specified, this represents the name of Azure Files/Page blob/Block blob).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureContainerInfoDataFormat
Storage format used for the file represented by the share.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.AzureContainerDataFormat
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureContainerInfoStorageAccountCredentialId
ID of the storage account credential used to access storage.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientAccessRights
List of IP addresses and corresponding access rights on the share(required for NFS protocol).
To construct, see NOTES section for CLIENTACCESSRIGHTS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IClientAccessRight[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPolicy
Data policy of the share.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.DataPolicy
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

### -Description
Description for the share.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringStatus
Current monitoring status of the share.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.MonitoringStatus
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The share name.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -RefreshDetailErrorManifestFile
Indicates the relative path of the error xml for the last refresh job on this particular share or container, if any.
This could be a failed job or a successful job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RefreshDetailInProgressRefreshJobId
If a refresh job is currently in progress on this share or container, this field indicates the ARM resource ID of that job.
The field is empty if no job is in progress.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RefreshDetailLastCompletedRefreshJobTimeInUtc
Indicates the completed time for the last refresh job on this particular share or container, if any.This could be a failed job or a successful job.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RefreshDetailLastJob
Indicates the id of the last refresh job on this particular share or container,if any.
This could be a failed job or a successful job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShareStatus
Current status of the share.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.ShareStatus
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAccessRights
Mapping of users and corresponding access rights on the share (required for SMB protocol).
To construct, see NOTES section for USERACCESSRIGHTS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IUserAccessRight[]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IShare

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CLIENTACCESSRIGHTS <IClientAccessRight[]>: List of IP addresses and corresponding access rights on the share(required for NFS protocol).
  - `AccessPermission <ClientPermissionType>`: Type of access to be allowed for the client.
  - `Client <String>`: IP of the client.

USERACCESSRIGHTS <IUserAccessRight[]>: Mapping of users and corresponding access rights on the share (required for SMB protocol).
  - `AccessType <ShareAccessType>`: Type of access to be allowed for the user.
  - `UserId <String>`: User ID (already existing in the device).

## RELATED LINKS

