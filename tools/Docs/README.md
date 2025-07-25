This folder puts scripts and files related to the publishing of Azure PowerShell documentation.

# Scripts
- GenerateDotNetCsv.ps1: Generates az-ps-latest.csv as the feed of online csharp reference publishing according to feed psd1. It usually runs after refreshing AzPreview.psd1 after version bumping.
- GenerateAboutTopicTxt.ps1: Converts markdown files under 'About' folder to txt files. To run this script, please pre-install pandoc in advance. Please refer to: https://pandoc.org/installing.html.
- CopyAboutTopics.ps1: Copies *.help.txt files under 'About' folder to current module's culture folder.

# Files
- az-ps-latest.csv: The feed of online csharp reference publishing. It will be submit to online docs team.