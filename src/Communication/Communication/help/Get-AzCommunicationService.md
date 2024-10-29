---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/get-azcommunicationservice
schema: 2.0.0
---

# Get-AzCommunicationService

## SYNOPSIS
Get the CommunicationService and its properties.

## SYNTAX

### List (Default)
```
Get-AzCommunicationService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCommunicationService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzCommunicationService -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCommunicationService -InputObject <ICommunicationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the CommunicationService and its properties.

## EXAMPLES

### Example 1: List existing CommunicationServices for a Subscription
```powershell
Get-AzCommunicationService -SubscriptionId 632ec9eb-fad7-4cbd-993a-e72973ba2acc
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy         SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType
-------- ----                -------------------  -------------------         ----------------------- ------------------------ ------------------------   ----------------------------
Global   ContosoAcsResource1 7/09/2024 4:41:40 AM contosouser@microsoft.com   User                    7/09/2024 4:41:40 AM     contosouser@microsoft.com  User
Global   ContosoAcsResource2 4/10/2024 2:41:40 AM contosouser2@microsoft.com  User                    4/10/2024 2:41:40 AM     contosouser2@microsoft.com User
Global   ContosoAcsResource3 5/01/2024 1:41:40 AM contosouser3@microsoft.com  User                    5/01/2024 1:41:40 AM     contosouser3@microsoft.com User
Global   ContosoAcsResource4 6/08/2024 5:41:40 AM contosouser4@microsoft.com  User                    6/08/2024 5:41:40 AM     contosouser4@microsoft.com User
Global   ContosoAcsResource5 6/09/2024 4:41:40 AM contosouser5@microsoft.com  User                    6/09/2024 4:41:40 AM     contosouser5@microsoft.com User
```

Returns a list of all ACS resources under that subscription.

### Example 2: Get infomation on specified Azure Communication resource
```powershell
Get-AzCommunicationService -Name ContosoAcsResource34 -ResourceGroupName ContosoResourceProvider1
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType
-------- ----                -------------------  -------------------        ----------------------- ------------------------ ------------------------  ----------------------------
Global   ContosoAcsResource1 7/10/2024 4:41:40 AM contosouser@microsoft.com  User                    7/10/2024 9:02:15 AM     contosouser@microsoft.com User
```

Returns the information on an ACS resource, if one matching provided parameters is found.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.ICommunicationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the CommunicationService resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CommunicationServiceName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.ICommunicationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20230601Preview.ICommunicationServiceResource

## NOTES

## RELATED LINKS
