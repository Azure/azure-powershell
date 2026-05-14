---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/invoke-azdatatransferlinkpendingconnection
schema: 2.0.0
---

# Invoke-AzDataTransferLinkPendingConnection

## SYNOPSIS
Links the connection to its pending connection.

## SYNTAX

### LinkExpanded (Default)
```
Invoke-AzDataTransferLinkPendingConnection -ConnectionName <String> -ResourceGroupName <String>
 -PendingConnectionId <String> [-SubscriptionId <String>] [-StatusReason <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Link
```
Invoke-AzDataTransferLinkPendingConnection -ConnectionName <String> -ResourceGroupName <String>
 -Connection <IResourceBody> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentity
```
Invoke-AzDataTransferLinkPendingConnection -InputObject <IDataTransferIdentity> -Connection <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Invoke-AzDataTransferLinkPendingConnection -InputObject <IDataTransferIdentity> -PendingConnectionId <String>
 [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Invoke-AzDataTransferLinkPendingConnection -ConnectionName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonString
```
Invoke-AzDataTransferLinkPendingConnection -ConnectionName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Links the connection to its pending connection.

## EXAMPLES

### Example 1: Link a pending connection by ID
```powershell
$sendSideConnection = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -ConnectionName SendConnection01
Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName ResourceGroup02 -ConnectionName ReceiveConnection01 -PendingConnectionId $sendSideConnection.Id -StatusReason "Linking approved" -Confirm:$false
```

```output
Approver                     : 
DateSubmitted                : 
Direction                    : Receive
FlowType                     : {Mission}
ForceDisabledStatus          : 
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup02/providers/Microsoft.AzureDataTransfer/connections/ReceiveConnection01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {}
Justification                : Linking approved
LinkStatus                   : Linked
LinkedConnectionId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/connections/SendConnection01
Location                     : eastus
Name                         : ReceiveConnection01
Pin                          : abcdefg
Pipeline                     : Pipeline01
Policy                       : 
PrimaryContact               : test@microsoft.com
ProvisioningState            : Succeeded
RemoteSubscriptionId         : 00000000-0000-0000-0000-000000000000
RequirementId                : 0
ResourceGroupName            : ResourceGroup02
Schema                       : 
SchemaUri                    : 
SecondaryContact             : 
Status                       : Approved
StatusReason                 : Approving for PS testing
SystemDataCreatedAt          : 5/30/2099 10:03:41 AM
SystemDataCreatedBy          : test@test.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/30/2099 10:04:57 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "creationTime": "2099-05-30T10:03:39.0878436Z",
                                 "vteam": "Experience"
                               }
Type                         : microsoft.azuredatatransfer/connections
```

This example links a pending send side connection with the name `SendConnection01` to the receive side connection `ReceiveConnection01` within the resource group `ResourceGroup02` and provides a status reason.

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

### -Connection
The resource to reference.

```yaml
Type: ADT.Models.IResourceBody
Parameter Sets: Link, LinkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectionName
The name for the connection to perform the operation on.

```yaml
Type: System.String
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
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
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: LinkViaIdentity, LinkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonString
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

### -PendingConnectionId
ID of the resource.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusReason
Reason for resource operation.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityExpanded
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
Parameter Sets: Link, LinkExpanded, LinkViaJsonFilePath, LinkViaJsonString
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

### ADT.Models.IDataTransferIdentity

### ADT.Models.IResourceBody

## OUTPUTS

### ADT.Models.IConnection

## NOTES

## RELATED LINKS

