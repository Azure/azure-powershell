---
external help file: Az.DisconnectedOperations-help.xml
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/new-azdisconnectedoperationsdisconnectedoperation
schema: 2.0.0
---

# New-AzDisconnectedOperationsDisconnectedOperation

## SYNOPSIS
Create a DisconnectedOperation

## SYNTAX

### CreateExpanded (Default)
```
New-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-ConnectionIntent <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDisconnectedOperationsDisconnectedOperation -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a DisconnectedOperation

## EXAMPLES

### Example 1: Create a new DisconnectedOperation with expanded parameters
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -Location "westus3" -ConnectionIntent "Disconnected" -Tag @{}
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : WestUS3
Name                         : Resource-1
ProvisioningState            : Succeeded
RegistrationStatus           : Unregistered
ResourceGroupName            : ResourceGroup-1
StampId                      : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt          : 05/19/2025 21:23:25
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 05/20/2025 06:09:56
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.edge/disconnectedoperations
```

This command creates a new DisconnectedOperation resource named "Resource-1" in the resource group "ResourceGroup-1" located in "westus3" with the connection intent set to "Disconnected" and no tags.

### Example 2: Create a DisconnectedOperation using a JSON file path
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -JsonFilePath "path/to/jsonFiles/CreateDisconnectedOperations.json"
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : WestUS3
Name                         : Resource-1
ProvisioningState            : Succeeded
RegistrationStatus           : Unregistered
ResourceGroupName            : ResourceGroup-1
StampId                      : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt          : 05/19/2025 21:23:25
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 05/20/2025 06:09:56
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.edge/disconnectedoperations
```

This command creates a DisconnectedOperation resource using the configuration specified in the JSON file located at "path/to/jsonFiles/CreateDisconnectedOperations.json".

### Example 3: Create a DisconnectedOperation using a JSON string
```powershell
New-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1" -JsonString '{"properties":{"connectionIntent":"Disconnected","billingModel":"Capacity"},"tags":{},"location":"westus3"}'
```

```output
BillingModel                 : Capacity
ConnectionIntent             : Disconnected
ConnectionStatus             : Disconnected
DeviceVersion                :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
Location                     : WestUS3
Name                         : Resource-1
ProvisioningState            : Succeeded
RegistrationStatus           : Unregistered
ResourceGroupName            : ResourceGroup-1
StampId                      : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
SystemDataCreatedAt          : 05/19/2025 21:23:25
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 05/20/2025 06:09:56
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.edge/disconnectedoperations
```

This command creates a DisconnectedOperation resource using the configuration specified in the provided JSON string.

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

### -ConnectionIntent
The connection intent

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
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
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation

## NOTES

## RELATED LINKS
