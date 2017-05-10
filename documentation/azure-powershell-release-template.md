# Azure PowerShell Release Notes

The following list outlines the steps necessary for a successful release of Azure PowerShell. Please check off the boxes as you complete the steps.

- [ ] For all existing PRs, run the **powershell-demand** Jenkins job on each one, and merge if the build is successful and has been signed off by a member of the team
- [ ] Run the **powershell-demand** Jenkins job against the **dev** branch and fix any issues
- [ ] In the Azure PowerShell repo, create a branch for the release and name it **release-X.X.X**
- [ ] Restrict access to the release branch through the GitHub settings so partners cannot merge their PRs themselves
    - In the settings window, find the *Protected branches* section, and select the release branch from the drop-down menu
    - Make sure the following are the only things checked off:
        + *Protect this branch*
        + *Require status checks to pass before merging*
        + *default*
        + *Restrict who can push to this branch*
            * Make sure to add *Azure/adx-sdk-manage* to this list of people with push access
    - You can check the settings for the **dev** branch if you have any questions
- [ ] Clone the Azure PowerShell repo to your computer, and switch to the release branch
- [ ] Open a PowerShell window, and run the script **tools\PreparePSRelease.ps1**
    - Check the script header for a sample of how the parameters should look
    - For example, for the August 2016 release of Azure PowerShell 2.0.0, the command would look like the following:
    > `.\PreparePSRelease.ps1 2.0.0 "August 2016" -Major`
- [ ] Create a signed build from the release branch using the **powershell-sign** Jenkins job
- [ ] Once the build is successful, click on *Build Artifacts* and download the zip
    - This zip file will contain the .msi for Azure PowerShell, and all of its packages
- [ ] Install Orca from the .msi in the following folder: **\\\\aaptfile01\adxsdk\PowerShell**
- [ ] In the zip file, rename the .msi to **azure-powershell.X.X.X.msi**
- [ ] Open this .msi in Orca, select the *Property* page in the left panel, and save the *ProductCode* somewhere you can easily access it
- [ ]  Create an account on [CodePlex](codeplex.com) if you don't already have one, and link it with your Microsoft corporate account
- [ ]  To access the [Web Platform Install Feeds](https://webpi.codeplex.com/) repository,  contact [Chris Sfanos](mailto:chris.sfanos@microsoft.com) with your CodePlex username and request to join the Web Platform Installer project
- [ ]  Once granted access, we can create the test WebPI feed by cloning the WebPI repo to your computer and navigating to the following folder: **\\\\Src\azuresdk\AzurePS**
- [ ]  Open the file **DH_AzurePS.xml**, and using the *ProductCode* we saved from before, update the product code for *DH_WindowsAzurePowerShellGet*, as well as add a new discovery hint for the product code in the **or** in the entry for *DH_WindowsAzurePowerShellCSFeed*
- [ ]  Open the file **WebProductList_AzurePS.xml**, find the *WindowsAzurePowerShellGet* entry, and update the *version*, *published*, and *updated* entries with the appropriate information. Staying in the *WindowAzurePowerShellGet* entry, find the two *trackingURL* entries, and update the Azure PowerShell version in their URL
- [ ]  To create a registry entry, go to the following folder: **\\\\aaptfile01\ADXSDK\PowerShell**, copy the folder of the last release (*e.g.,* for the August 2016 release, you would copy the folder *2016_07_11_PowerShell*), change the name of the folder to match the current release, and delete everything but the following items:
    - *pkgs* (however, you can delete everything in this folder)
    - *scripts*
    - *removewebpiReg.reg*
    - *webpiReg.reg*
    - *wpilauncher.exe*
- [ ] Copy the .msi from the zip file to this folder
- [ ] Update the *webpiReg.reg* file with the location of the folder you just created
- [ ] Publish the packages to the *pkgs* folder with all of the .nukpg files in the *Package* folder of the zip file we downloaded earlier
- [ ] Run the **webpiReg.reg** file to point the Web Platform Installer at the newest version of Azure PowerShell
- [ ] Setup test [signoff](https://microsoft.sharepoint.com/teams/azuresdk/powershell/_layouts/15/WopiFrame.aspx?sourcedoc=%7b96366200-2BA8-4980-9931-10AEBDAB7E08%7d&file=PowerShell%20End%20Of%20Release%20Testing.docx&action=default) on .msi
    - Go to *Control Panel > Programs > Uninstall a program* and see if you already have Azure PowerShell installed already; if so, uninstall it
    - Run the **wpilauncher.exe** file in your registry entry folder; double-click the Azure PowerShell option, check to see that the version and release date correspond to the new release, and install it
    - Once installed, follow the test instructions in the test signoff document for *Script cmdlets tests*
- [ ] Open the **StaticAnalysis** solution located in **azure-powershell/tools/StaticAnalysis**; in the *Solution Explorer* panel, open up the *StaticAnalysis* project, and double-click the *Properties* tab. In this window, click on the *Debug* tab on the left side, and in the text box labeled *Command line arguments*, enter the following: **"C:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell"**, and run the program
    - Go to **azure-powershell/src/Package** and open all of the .csv files
    - In each one, look at the *Severity* column, and make sure that none of the issues are 0 or 1
    - If the .csv file contains a lot of rows, at the top, click *Data > Filter*, click on the drop-down for the *Severity* column, and you will quickly be able to see all of the values found in that column
- [ ] After all tests are successful, uninstall Azure PowerShell from the *Control Panel*, and run the **removewebpiReg.reg** file so that the Web Platform Installer no longer points at the newest version of Azure PowerShell. Run the Web Platform Installer and install the previous version of Azure PowerShell. Run the **webpiReg.reg** file again, open the Web Platform Installer, and install the newest version of Azure PowerShell.
    - Once installed, follow the same test procedures mentioned above
- [ ] Once all of the tests have passed and there are no major issues from the StaticAnalysis tool, send an email to [all partners](mailto:adxsdkpartners@microsoft.com) with the path to the folder containing the **azure-powershell.X.X.X.msi** and a link to the [change log](https://github.com/Azure/azure-powershell/blob/dev/ChangeLog.md)
    - Make sure to tell the partners to update the change log with any changes that they made that aren't currently found in it for the release
    - Copy the e-mail contents and post it on the slack channels (specifically [#powershell](https://azuresdk.slack.com/messages/powershell/) and [#powershell-announce](https://azuresdk.slack.com/messages/powershell-announce/))
- [ ] Give anyone with an open PR, or those that are making quick additions, a chance to create a new PR that targets the release branch, get their code reviewed, and run a successful **powershell-demand** job
- [ ] Run the **powershell-sign** job on the release branch and notify partner teams of this release candidate
    - **Note:** For additional release candidates created, make sure to update the **DH_AzurePS.xml** file with the new product code of the .msi (obtained from Orca)
- [ ] Wait for partner teams to sign off by MM/DD/YYYY (a few days after the initial release candidate was sent out)
- [ ] Make sure that you have registered a PSRepository for the publish location
    - To see if you have a PSRepository for this location, run the following command: `Get-PSRepository`; if any object with the `SourceLocation` of http://dtlgalleryint.cloudapp.net/api/v2 is listed, you already have the correct PSRepository
    - If this PSRepository does not show up, run the following command to register it: `Register-PSRepository -Name dtgallery -SourceLocation http://dtlgalleryint.cloudapp.net/api/v2 -PublishLocation http://dtlgalleryint.cloudapp.net/api/v2 -InstallationPolicy Trusted`
- [ ] On the evening of MM/DD/YYYY, publish the latest RC of Azure PowerShell to internal through the **ps-pub-test** Jenkins job and smoke test from [here](dtlgalleryint.cloudapp.net/api/v2)
    - Install the modules for testing by running the following commands: `Install-Module -Repository dtlgallery -Name AzureRM` and `Install-Module -Repository dtlgallery -Name Azure -AllowClobber`
    - Run the **RunInstallationTests.ps1** script again (same one from the test signoff document) and ensure that all tests passed
- [ ] Install [Azure Storage Explorer](https://azurestorageexplorer.codeplex.com/) and upload the .msi file to the download blob container
    - The storage account name and storage account key can be retrieved from the OneNote page
    - Upload the **azure-powershell.X.X.X.msi** file from the shared folder to the latest downloads folder
- [ ] Submit a pull request to the WebPI feed and send an email to Chris Sfanos asking to merge the PR
    - The pull request should just include changes to the **WebProductList_AzurePS.xml** and **DH_AzurePS.xml** files
- [ ] Update aka.ms link to point at the newest .msi file for Azure PowerShell
    - Request access if you don't have access to **azure-powershellget**
- [ ] Enable the live publishing job, **ps-publish**
- [ ] Run the job against the release branch, which will publish to the PowerShell Gallery
- [ ] Once the job is complete, disable the **ps-publish** job
- [ ] Follow the same steps for smoke testing that we followed above for **ps-pub-test**
- [ ] Update the README and change log in the release branch if necessary
- [ ] Create a public GitHub [Release](https://github.com/Azure/azure-powershell/releases) with appropriate tag
    - Use the change log from this release as the content of the document
    - Include the .msi file and include a link to it at the top of the document with "Installer: Windows Standalone"
    - Include the changes since the last release at the end of the document
- [ ] Merge the release branch to master
- [ ] Delete the release branch
- [ ] Merge the master branch to dev
- [ ] Smoke test the live WebPI feed
- [ ] Send an email to [all partners](mailto:adxsdkpartners@microsoft.com) with the locations of where the release can be accessed: the PowerShell Gallery modules (both Azure and AzureRM), the WebPI feed, and the GitHub release
    - Copy the e-mail contents and post it on the slack channels (specifically [#powershell](https://azuresdk.slack.com/messages/powershell/) and [#powershell-announce](https://azuresdk.slack.com/messages/powershell-announce/))
- [ ] Resolve any issues, close the release milestone, and create a new milestone for +3 months