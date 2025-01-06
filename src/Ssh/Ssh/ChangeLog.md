<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->

## Upcoming Release
* upgraded nuget package to signed package.

## Version 0.2.1
* Removed the outdated deps.json file.

## Version 0.2.0
* Supported updating Service Configuration for Arc resources at runtime.
    - Owners/Contributors can change what port is allowed for SSH connection at runtime by providing the -Port parameter and confirming the operation when prompted.
* Fixed bug in the RDP feature in the Enter-AzVM cmdlet.

## Version 0.1.2
* The SSH Proxy required for connection to Arc resources must be installed by the user as part of the Az.Ssh.ArcProxy PowerShell module
    - The Az.Ssh.ArcProxy module can be found in the PowerShell Gallery (https://aka.ms/PowerShellGallery-Az.Ssh.ArcProxy)
    - The proxy files were previously downloaded by the cmdlet at runtime.

## Version 0.1.1
* Added support for the following Resource Types:
    - Microsoft.ConnectedVMwarevSphere/virtualMachines
    - Microsoft.ScVmm/virtualMachines
    - Microsoft.AzureStackHCI/virtualMachines
* Added parameter -Rdp to Enter-AzVM
* Added Scenario tests for Export-AzSshConfig

## Version 0.1.0
* First preview release for module Az.Ssh
