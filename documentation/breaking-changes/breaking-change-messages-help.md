# Breaking Change Messages Help

## What is this warning all about?

Breaking change warnings are a means for the cmdlet authors to communicate with the end users any upcoming breaking changes. Most of these changes will be taking effect in the next breaking change release.

## How do I get rid of the warnings?

As of now the only way a user can supress the warnings is to set an environment variable, [details here](https://github.com/Azure/azure-powershell/blob/preview/documentation/breaking-changes/breaking-changes-attribute-help.md#supress-the-breaking-change-messages-at-runtime).

## More information

### What are the different types of breaking changes possible in the cmdlet?

[Here](https://github.com/Azure/azure-powershell/blob/preview/documentation/breaking-changes/breaking-changes-definition.md
) is a good resource on the various types of breaking changes authors can call out in a cmdlet.

### How are these warnings added to the cmdlets

Cmdlet authors can use the breaking change attributes described [here](https://github.com/Azure/azure-powershell/blob/preview/documentation/breaking-changes/breaking-changes-attribute-help.md) to call out the [various types](https://github.com/Azure/azure-powershell/blob/preview/documentation/breaking-changes/breaking-changes-definition.md) of deprecations/breaking changes that will be coming in the next breaking change release.

### How do i send feedback about this?
* Generic feedback : Use the [`Send-Feedback`](https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/send-feedback?view=azurermps-6.11.0) cmdlet
* A bug : Report it as an issue [here](https://github.com/Azure/azure-powershell/issues) 
