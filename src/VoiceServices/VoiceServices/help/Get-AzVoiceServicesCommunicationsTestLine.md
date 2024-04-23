---
external help file: Az.VoiceServices-help.xml
Module Name: Az.VoiceServices
online version: https://learn.microsoft.com/powershell/module/az.voiceservices/get-azvoiceservicescommunicationstestline
schema: 2.0.0
---

# Get-AzVoiceServicesCommunicationsTestLine

## SYNOPSIS
Get a TestLine

## SYNTAX

### List (Default)
```
Get-AzVoiceServicesCommunicationsTestLine -CommunicationsGatewayName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzVoiceServicesCommunicationsTestLine -CommunicationsGatewayName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVoiceServicesCommunicationsTestLine -InputObject <IVoiceServicesIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a TestLine

## EXAMPLES

### Example 1: List all testline under the communications gateway
```powershell
Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg
```

List all testline under the communications gateway.

### Example 2: Get a testline
```powershell
Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg
```

Get a testline.

### Example 3: Get a testline by pipeline
```powershell
New-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01 -Location westcentralus -Purpose 'Automated' -PhoneNumber "+1-555-1234" | Get-AzVoiceServicesCommunicationsTestLine
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg
```

Get a testline by pipeline.

## PARAMETERS

### -CommunicationsGatewayName
Unique identifier for this deployment

```yaml
Type: System.String
Parameter Sets: List, Get
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.IVoiceServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Unique identifier for this test line

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TestLineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.IVoiceServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VoiceServices.Models.Api20230131.ITestLine

## NOTES

## RELATED LINKS
