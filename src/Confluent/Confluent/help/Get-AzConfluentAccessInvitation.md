---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/get-azconfluentaccessinvitation
schema: 2.0.0
---

# Get-AzConfluentAccessInvitation

## SYNOPSIS
Organization accounts invitation details

## SYNTAX

### ListExpanded (Default)
```
Get-AzConfluentAccessInvitation -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-SearchFilter <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzConfluentAccessInvitation -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -Body <IListAccessRequestModel> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzConfluentAccessInvitation -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzConfluentAccessInvitation -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Organization accounts invitation details

## EXAMPLES

### Example 1: List all Invitation under organization in the resource group
```powershell
Get-AzConfluentAccessInvitation -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv04",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv04",
                        "created_at": "2025-11-13T10:57:08.617671+00:00",
                        "updated_at": "2025-11-13T10:57:08.625073+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv04",
                      "email": "user5@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_ACCEPTED",
                      "accepted_at": "2025-11-13T13:28:01.219263+00:00",
                      "expires_at": "2025-11-16T10:57:08.625073+00:00"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv02",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv02",
                        "created_at": "2025-11-13T10:59:01.206099+00:00",
                        "updated_at": "2025-11-13T10:59:01.214239+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv02",
                      "email": "user6@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_EXPIRED",
                      "accepted_at": "0001-01-01T00:00:00+00:00",
                      "expires_at": "2025-11-16T10:59:01.214239+00:00"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv03",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv03",
                        "created_at": "2025-11-17T07:09:55.01892+00:00",
                        "updated_at": "2025-11-17T07:09:55.028684+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv03",
                      "email": "user7@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_ACCEPTED",
                      "accepted_at": "2025-11-17T07:13:01.863287+00:00",
                      "expires_at": "2025-11-20T07:09:55.028684+00:00"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv01",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv01",
                        "created_at": "2025-11-17T07:14:32.58968+00:00",
                        "updated_at": "2025-11-17T07:14:32.599239+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv01",
                      "email": "user1@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_ACCEPTED",
                      "accepted_at": "2025-11-17T07:14:56.660743+00:00",
                      "expires_at": "2025-11-20T07:14:32.599239+00:00"
                    }…}
Kind              : InvitationList
MetadataFirst     :
MetadataLast      :
MetadataNext      : https://api.example.confluent.io/iam/v2/invitations?page_token=<TOKEN>
MetadataPrev      :
MetadataTotalSize : 0
```

This command lists all Invitations under a organization and resource group

## PARAMETERS

### -Body
List Access Request Model

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IListAccessRequestModel
Parameter Sets: List
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

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SearchFilter
Search filters for the request

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ListExpanded
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
Type: System.String[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IListAccessRequestModel

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IAccessListInvitationsSuccessResponse

## NOTES

## RELATED LINKS
