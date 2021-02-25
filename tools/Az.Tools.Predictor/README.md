# Az Predictor module

## Overview

**[Az Predictor](https://www.powershellgallery.com/packages/Az.Tools.Predictor/)** is a PowerShell module that helps you navigate the cmdlets and parameters of the [Az module](https://www.powershellgallery.com/packages/Az) by providing context-aware suggestions in the PowerShell command line.

Az Predictor is using the [subsystem plugin model](https://docs.microsoft.com/en-us/powershell/scripting/learn/experimental-features?view=powershell-7.1#pssubsystempluginmodel) available with PowerShell 7.1. This updated version requires [PS Readline 2.2.0-beta2](https://www.powershellgallery.com/packages/PSReadLine/2.2.0-beta2) to display the suggestions.

Required configuration for Az Predictor:

- [PowerShell 7.2 preview 3](https://github.com/PowerShell/PowerShell/releases/tag/v7.2.0-preview.3)
- [PSReadline 2.2.0-beta2](https://github.com/PowerShell/PSReadLine/releases/tag/v2.2.0-beta2)

## Getting started

### Installing the module

1. Install [PowerShell 7.2 preview 3](https://github.com/PowerShell/PowerShell/releases/tag/v7.2.0-preview.3)
2. Install [PSReadline 2.2.0-beta2](https://www.powershellgallery.com/packages/PSReadLine/2.2.0-beta2)

    `Install-Module -Name PSReadline -AllowPrerelease`

3. Install the Az.Tools.Predictor module

    `Install-Module -Name Az.Tools.Predictor -AllowPrerelease`

### Enabling Az Predictor


4. Enable the suggestions

    `Enable-AzPredictor -AllSession`

5. Set your preferred view for get the suggestions

    - Enable the list view: `Set-PSReadLineOption -PredictionViewStyle ListView`
    - Enable the inline view: `Set-PSReadLineOption -PredictionViewStyle InlineView`

> Note: You can switch between the modes with the "F2" key/

## Privacy and data collection

### Privacy

Az predictor takes the last two Az cmdlets to make the suggestions and ignores any cmdlet that is not part of the [Az PowerShell](https://www.powershellgallery.com/packages/Az) module.
Only names of cmdlets and parameters are sent to our API to obtain the suggestion; all the parameters' values are discarded. The resource group name and location used are kept locally and reused in subsequent cmdlets for convenience but never sent to the API.
In the preview version, the module generates and sends anonymized information about the current session to the API used for predictions that are used to assess the quality of the suggestions made.

### Data collection

The current version of Az Predictor collects anonymized information about its usage to identify common issues and improve experience with the future releases.
Az Predictor does not collect any private or personal data.

For example, the usage data helps identify inaccurate suggestions and issues like interferences with PSReadline.
While we appreciate the insights this data provides, we also understand that not everyone wants to send usage data, and you can disable data collection with the [`Disable-AzDataCollection`](https://docs.microsoft.com/en-us/powershell/module/az.accounts/disable-azdatacollection) cmdlet. You can also read our [privacy statement](https://go.microsoft.com/fwlink/?LinkID=528096&clcid=0x409) to learn more.
