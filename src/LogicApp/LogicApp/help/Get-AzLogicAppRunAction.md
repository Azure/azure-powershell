<<<<<<< HEAD
﻿---
external help file: Microsoft.Azure.PowerShell.Cmdlets.LogicApp.dll-Help.xml
Module Name: Az.LogicApp
ms.assetid: 2EA28B90-4BAE-45DF-BD2E-60C74F53FB7B
online version: https://docs.microsoft.com/en-us/powershell/module/az.logicapp/get-azlogicapprunaction
=======
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.LogicApp.dll-Help.xml
Module Name: Az.LogicApp
ms.assetid: 2EA28B90-4BAE-45DF-BD2E-60C74F53FB7B
online version: https://docs.microsoft.com/powershell/module/az.logicapp/get-azlogicapprunaction
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzLogicAppRunAction

## SYNOPSIS
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Gets an action from a logic app run.

## SYNTAX

<<<<<<< HEAD
```
Get-AzLogicAppRunAction -ResourceGroupName <String> -Name <String> -RunName <String> [-ActionName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
=======
```powershell
Get-AzLogicAppRunAction -ResourceGroupName <String> -Name <String> -RunName <String> [-ActionName <String>]
 [-FollowNextPageLink] [-MaximumFollowNextPageLink <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
The **Get-AzLogicAppRunAction** cmdlet gets an action from a logic app run.
This cmdlet returns a **WorkflowRunAction** objects.
Specify the logic app, resource group, and run.
This module supports dynamic parameters.
To use a dynamic parameter, type it in the command.
To discover the names of dynamic parameters, type a hyphen (-) after the cmdlet name, and then press the Tab key repeatedly to cycle through the available parameters.
If you omit a required template parameter, the cmdlet prompts you for the value.

## EXAMPLES

### Example 1: Get an action from a Logic App run
<<<<<<< HEAD
```
PS C:\>Get-AzLogicAppActionRun -ResourceGroupName "ResourceGroup11" -Name "LogicApp05" -RunName "LogicAppRun56" -ActionName "LogicAppAction01"
=======

```powershell
PS C:\>Get-AzLogicAppRunAction -ResourceGroupName "ResourceGroup11" -Name "LogicApp05" -RunName "08585925184423369718380498702CU26" -ActionName "LogicAppAction01"
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Code        : NotFound
EndTime     : 1/13/2016 2:42:56 PM
Error       : 
InputsLink  : Microsoft.Azure.Management.Logic.Models.ContentLink
Name        : LogicAppAction01
OutputsLink : Microsoft.Azure.Management.Logic.Models.ContentLink
StartTime   : 1/13/2016 2:42:55 PM
Status      : Failed
TrackingId  : 
Type        :
```

<<<<<<< HEAD
This command gets a specific Logic App action from the logic app named LogicApp05 for the run named LogicAppRun56.

### Example 2: Get all the actions from a Logic App run
```
PS C:\>Get-AzLogicAppActionRun -ResourceGroupName "ResourceGroup11" -Name "LogicApp05" -RunName "LogicAppRun56"
Code        : NotFound
EndTime     : 1/13/2016 2:42:56 PM
Error       : 
InputsLink  : Microsoft.Azure.Management.Logic.Models.ContentLink
Name        : LogicAppAction1
OutputsLink : Microsoft.Azure.Management.Logic.Models.ContentLink
StartTime   : 1/13/2016 2:42:55 PM
Status      : Failed
TrackingId  : 
Type        :
```

This command gets all Logic App actions from a run named LogicAppRun56 of a logic app named LogicApp05.
=======
This command gets a specific Logic App action from the logic app named LogicApp05 for the run with identifier 08585925184423369718380498702CU26.

### Example 2: Get all the actions from a Logic App run

```powershell
PS C:\>Get-AzLogicAppRunAction -ResourceGroupName "ResourceGroup11" -Name "LogicApp05" -RunName "08585925184423369718380498702CU26" -FollowNextPageLink
```

This command gets all Logic App actions from a run with identifier 08585925184423369718380498702CU26 of a logic app named LogicApp05.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## PARAMETERS

### -ActionName
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Specifies the name of an action in a logic app run.
This cmdlet gets the action that this parameter specifies.

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

### -DefaultProfile
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -Name
=======
### -FollowNextPageLink

Indicates the cmdlet should follow next page links.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: FL

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaximumFollowNextPageLink

Specifies how many times to follow next page links if FollowNextPageLink is used.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: ML

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Specifies the name of a logic app for which this cmdlet gets an action.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Specifies the name of a resource group in which this cmdlet gets an action.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RunName
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Specifies the name of a run of a logic app.
This cmdlet gets an action for the run that this parameter specifies.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Logic.Models.WorkflowRunAction

## NOTES

## RELATED LINKS

[Get-AzLogicAppRunHistory](./Get-AzLogicAppRunHistory.md)

[Stop-AzLogicAppRun](./Stop-AzLogicAppRun.md)
<<<<<<< HEAD


=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
