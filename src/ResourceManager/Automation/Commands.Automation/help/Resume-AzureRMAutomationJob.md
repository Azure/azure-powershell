---
external help file: Microsoft.Azure.Commands.ResourceManager.Automation.dll-Help.xml
Module Name: AzureRM.Automation
ms.assetid: 9400E9EB-E927-44D5-8722-9706BDD92FD5
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.automation/resume-azurermautomationjob
schema: 2.0.0
---

# Resume-AzureRmAutomationJob

## SYNOPSIS
Resumes a suspended Automation job.

## SYNTAX

```
Resume-AzureRmAutomationJob [-Id] <Guid> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Resume-AzureRmAutomationJob** cmdlet resumes a suspended Azure Automation job.
Specify the suspended job.
To suspend a job, use the Suspend-AzureRmAutomationJob cmdlet.

## EXAMPLES

### Example 1: Resume a suspended job
```
PS C:\>Resume-AzureRmAutomationJob -AutomationAccountName "Contoso17" -Id 2989b069-24fe-40b9-b3bd-cb7e5eac4b64 -ResourceGroupName "ResourceGroup01"
```

This command resumes the job that has the specified ID.

## PARAMETERS

### -AutomationAccountName
Specifies the name of an Automation account in which this cmdlet resume a job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the ID of a job that this cmdlet resumes.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases: JobId

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group for which this cmdlet resumes a job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

### System.String

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Get-AzureRmAutomationJob](./Get-AzureRMAutomationJob.md)

[Get-AzureRmAutomationJobOutput](./Get-AzureRMAutomationJobOutput.md)

[Stop-AzureRmAutomationJob](./Stop-AzureRMAutomationJob.md)

[Suspend-AzureRmAutomationJob](./Suspend-AzureRMAutomationJob.md)


