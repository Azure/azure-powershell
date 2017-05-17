---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Resolve-AzureRmError

## SYNOPSIS

Display detailed information about PowerShell errors, with extended details for Azure PowerShell errors.

## SYNTAX

### AnyErrorParameterSet (Default)

```powershell
Resolve-AzureRmError [[-Error] <ErrorRecord[]>] [<CommonParameters>]
```

### LastErrorParameterSet

```powershell
Resolve-AzureRmError [-Last] [<CommonParameters>]
```

## DESCRIPTION

Resolves and displays detailed information about errors in the current PowerShell session, including where the error 
occurred in script, stack trace, and all inner and aggregate exceptions. For Azure PowerShell errors provides 
additional detail in debugging service issues, including complete detail about the request and server response 
that caused the error.

## EXAMPLES

### Example 1: Resolve the Last Error

```powershell
PS C:\> Resolve-AzureRmError -Last

   HistoryId: 3


Message        : Run Login-AzureRmAccount to login.
StackTrace     :    at Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet.get_DefaultContext() in AzureRmCmdlet.cs:line 85
                    at Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet.LogCmdletStartInvocationInfo() in AzureRmCmdlet.cs:line 269
                    at Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet.BeginProcessing() inAzurePSCmdlet.cs:line 299
                    at Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet.BeginProcessing() in AzureRmCmdlet.cs:line 320
                    at Microsoft.Azure.Commands.Profile.GetAzureRMSubscriptionCommand.BeginProcessing() in GetAzureRMSubscription.cs:line 49
                    at System.Management.Automation.Cmdlet.DoBeginProcessing()
                    at System.Management.Automation.CommandProcessorBase.DoBegin()
Exception      : System.Management.Automation.PSInvalidOperationException
InvocationInfo : {Get-AzureRmSubscription}
Line           : Get-AzureRmSubscription
Position       : At line:1 char:1
                 + Get-AzureRmSubscription
                 + ~~~~~~~~~~~~~~~~~~~~~~~
HistoryId      : 3
```

Get details of the last error.

## PARAMETERS

### -Error

One or more error records to resolve.  If no parameters are specified, all errors in the session are resolved.

```yaml
Type: ErrorRecord[]
Parameter Sets: AnyErrorParameterSet
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Last
Resolve only the last error that occurred in the session.

```yaml
Type: SwitchParameter
Parameter Sets: LastErrorParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.ErrorRecord[]

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Errors.AzureErrorRecord

### Microsoft.Azure.Commands.Profile.Errors.AzureExceptionRecord

### Microsoft.Azure.Commands.Profile.Errors.AzureRestExceptionRecord

## NOTES

## RELATED LINKS

