---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsAlert

## SYNOPSIS
Returns alerts at a given location.

## SYNTAX

### Alerts_List (Default)
```
Get-AzsAlert [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### Alerts_Get
```
Get-AzsAlert -Location <String> -AlertName <String> [<CommonParameters>]
```

## DESCRIPTION
Returns alerts at a given location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsAlert -Location local

FaultTypeId                       ClosedTimestamp     ClosedByUserAlias                           Name                                 ResourceRegistrationId
-----------                       ---------------     -----------------                           ----                                 ----------------------
ServiceFabricClusterUnhealthy     08/25/2017 04:52:27                                             148820f7-807a-4edd-857b-a23c3dcb6acf ca96c335-e545-4563-9d65-058db3a8ef15
ServiceFabricApplicationUnhealthy 08/25/2017 18:48:31                                             17d030ef-7be7-4e12-a653-6158a3bc7643
AzureStackNotActivated            08/25/2017 18:21:34 example@microsoft.com 356fd53c-b355-4522-ab5b-1a0f385381fa
ServiceFabricApplicationUnhealthy 08/25/2017 04:33:12                                             37fab95e-8981-4657-872a-d0a904308d26
ServiceFabricApplicationUnhealthy 08/25/2017 04:52:27                                             7ff5f418-75e1-41e3-85c3-229e369313a3
ServiceFabricClusterUnhealthy     08/25/2017 04:33:12                                             b8f81ea8-cf7d-4909-a9f4-0779909e15eb ca96c335-e545-4563-9d65-058db3a8ef15
AzureStackNotActivated            08/25/2017 18:16:49 example@microsoft.com c0328148-006b-482b-9c75-ad58c454225b
AzureStackNotActivated            08/25/2017 18:29:55 example@microsoft.com cf278262-78cd-43eb-8cd8-9c4cac5e75f7
AzureStackNotActivated
```

Get all alerts at a location.

### Example 1
```
PS C:\> Get-AzsAlert -Location local -Alert 148820f7-807a-4edd-857b-a23c3dcb6acf

FaultTypeId                   ClosedTimestamp     ClosedByUserAlias Name                                 ResourceRegistrationId
-----------                   ---------------     ----------------- ----                                 ----------------------
ServiceFabricClusterUnhealthy 08/25/2017 04:52:27                   148820f7-807a-4edd-857b-a23c3dcb6acf ca96c335-e545-4563-9d65-058db3a8ef15
```

Get an alert by name at a location.

## PARAMETERS

### -AlertName
Name of the alert.

```yaml
Type: String
Parameter Sets: Alerts_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: Alerts_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: Alerts_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: Alerts_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert

## NOTES

## RELATED LINKS

