---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceSharedPrivateLinkResourceObject
schema: 2.0.0
---

# New-AzMLWorkspaceSharedPrivateLinkResourceObject

## SYNOPSIS
Create an in-memory object for SharedPrivateLinkResource.

## SYNTAX

```
New-AzMLWorkspaceSharedPrivateLinkResourceObject [-GroupId <String>] [-Name <String>]
 [-PrivateLinkResourceId <String>] [-RequestMessage <String>]
 [-Status <PrivateEndpointServiceConnectionStatus>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SharedPrivateLinkResource.

## EXAMPLES

### Example 1: Create an in-memory object for SharedPrivateLinkResource, pass it to as value of Value SharedPrivateLinkResource of  New-AzMLWorkspace
```powershell
New-AzMLWorkspaceSharedPrivateLinkResourceObject
```

Create an in-memory object for SharedPrivateLinkResource

## PARAMETERS

### -GroupId
The private link resource group id.

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

### -Name
Unique name of the private link.

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

### -PrivateLinkResourceId
The resource id that private link links to.

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

### -RequestMessage
Request message.

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

### -Status
Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.PrivateEndpointServiceConnectionStatus
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.SharedPrivateLinkResource

## NOTES

ALIASES

## RELATED LINKS

