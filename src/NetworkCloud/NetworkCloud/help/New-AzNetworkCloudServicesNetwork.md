---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudservicesnetwork
schema: 2.0.0
---

# New-AzNetworkCloudServicesNetwork

## SYNOPSIS
Create a new cloud services network or create the properties of the existing cloud services network.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -ExtendedLocationName <String> -ExtendedLocationType <String>
 -Location <String> [-AdditionalEgressEndpoint <IEgressEndpoint[]>] [-EnableDefaultEgressEndpoint <String>]
 [-StorageOptionMode <String>] [-StorageOptionSizeMiB <Int64>] [-StorageOptionStorageApplianceId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString1
```
New-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath1
```
New-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -ExtendedLocationName <String> -ExtendedLocationType <String>
 -Location <String> [-AdditionalEgressEndpoint <IEgressEndpoint[]>] [-EnableDefaultEgressEndpoint <String>]
 [-StorageOptionMode <String>] [-StorageOptionSizeMiB <Int64>] [-StorageOptionStorageApplianceId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzNetworkCloudServicesNetwork -InputObject <INetworkCloudIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -ExtendedLocationName <String> -ExtendedLocationType <String> -Location <String>
 [-AdditionalEgressEndpoint <IEgressEndpoint[]>] [-EnableDefaultEgressEndpoint <String>]
 [-StorageOptionMode <String>] [-StorageOptionSizeMiB <Int64>] [-StorageOptionStorageApplianceId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new cloud services network or create the properties of the existing cloud services network.

## EXAMPLES

### Example 1: Create cloud services network
```powershell
$tags = @{
    Tag1 = 'tag1'
}
$endpointEgressList = @{}

New-AzNetworkCloudServicesNetwork -CloudServicesNetworkName cloudNetworkServicesName -ResourceGroupName resourceGroupName -ExtendedLocationName "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/customLocationName" -ExtendedLocationType "CustomLocation" -Location eastus -AdditionalEgressEndpoint $endpointEgressList -EnableDefaultEgressEndpoint false -Tag $tags -SubscriptionId subscriptionId
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command creates a cloud services network.

## PARAMETERS

### -AdditionalEgressEndpoint
The list of egress endpoints.
This allows for connection from a Hybrid AKS cluster to the specified endpoint.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IEgressEndpoint[]
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
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

### -EnableDefaultEgressEndpoint
The indicator of whether the platform default endpoints are allowed for the egress traffic.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The ETag of the transformation.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

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

### -IfNoneMatch
Set to '*' to allow a new record set to be created, but to prevent updating an existing resource.
Other values will result in error from server as they are not supported.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath1, CreateViaJsonFilePath
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
Parameter Sets: CreateViaJsonString1, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the cloud services network.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString1, CreateViaJsonString, CreateViaJsonFilePath1, CreateViaJsonFilePath, CreateExpanded1
Aliases: CloudServicesNetworkName

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
Parameter Sets: CreateExpanded, CreateViaJsonString1, CreateViaJsonString, CreateViaJsonFilePath1, CreateViaJsonFilePath, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageOptionMode
The indicator to enable shared storage on the cloud services network.
If not specified, the allocation will align with the standard storage enablement.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageOptionSizeMiB
The requested storage allocation for the volume in Mebibytes.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageOptionStorageApplianceId
The resource ID of the storage appliance that hosts the storage.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateExpanded, CreateViaJsonString1, CreateViaJsonString, CreateViaJsonFilePath1, CreateViaJsonFilePath, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ICloudServicesNetwork

## NOTES

## RELATED LINKS
