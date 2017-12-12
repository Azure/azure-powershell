---
external help file: Microsoft.Azure.Commands.ManagementGroups.dll-Help.xml
Module Name: AzureRM.ManagementGroups
online version: 
schema: 2.0.0
---

# Remove-AzureRmManagementGroupSubscription

## SYNOPSIS
Removes a Subscription from a Management Group.

## SYNTAX

```
Remove-AzureRmManagementGroupSubscription [-GroupName] <String> [-SubscriptionId] <Guid>
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Remove-AzureRMManagementGroupSubscription** cmdlet removes a Subscription from a Management Group.

## EXAMPLES

### Example 1 - Remove Subscription from Management Group
```
PS C:\> Remove-AzureRMManagementGroupSubscription -GroupName "TestGroup" -SubscriptionId 2120692d-35c3-44c8-81f5-631fa7351726
OK
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupName
The GroupName of the Management Group to add the Subscription to.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The SubscriptionId to remove from the Management Group.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### System.String


## NOTES

## RELATED LINKS

[Get-AzureRmManagementGroupSubscription](./Get-AzureRmManagementGroupSubscription.md)

