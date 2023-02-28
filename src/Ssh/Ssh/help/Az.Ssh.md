---
Module Name: Az.Ssh
Module Guid: 91832aaa-dc11-4583-8239-bce5fd531604
Download Help Link: {{ Update Download Link }}
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Ssh Module
## Description
This module allows you to create an interactive shell connection to Azure Resources, such as Azure VMs or Arc Servers, using SSH (Secure Shell). The connection can be established using AAD (Azure Active Directory) accounts, or local machine accounts. Note that this module requires that OpenSSH be installed and discoverable on the client machine.

## Az.Ssh Cmdlets
### [Enter-AzVM](Enter-AzVM.md)
Starts an interactive SSH session to an Azure Resource (such as Azure VMs or Arc Servers).
Users can login using AAD accounts, or local user accounts via standard SSH authentication. Use AAD account login for the best security and convenience.

### [Export-AzSshConfig](Export-AzSshConfig.md)
This cmdlet exports an SSH configuration file that can be used to connect to Azure Resources through client applications that support OpenSSH config and certificates. SSH config files can be created that use AAD issued certificates or local user credentials.

