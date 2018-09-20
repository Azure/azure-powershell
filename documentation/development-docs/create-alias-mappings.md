In the new Az Netstandard module, the default prefix for all cmdlets is "Az".  However, in order to prevent massive breaking changes that require scripts to be immediately rewritten, we have created a new cmdlet "Enable-AzureRmAlias" that will enable aliases to the old "AzureRm" prefix.  This is a guide on how to add aliases for new cmdlets added to any module.

1.) Ensure your cmdlet attribute is formatted correctly to include the AzureRMPrefix.  This will make the cmdlet prefix "Az" for Netstandard and "AzureRM" for the legacy desktop module (while the desktop module continues to be maintained). Example can be found [here](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Profile/Commands.Profile/Default/GetAzureRmDefault.cs#L29).

2.) Ensure both AzureRm.\<moduleName>.psd1 and Az.\<moduleName>.psd1 are updated with all new cmdlets.  The prefix for cmdlets in AzureRM.\<moduleName>.psd1 should be AzureRm, and the prefix for cmdlets in Az.\<moduleName>.psd1 should be Az.

3.) Run the script to create alias mapping.  This can be found in [tools/CreateAliasMappings.ps1](https://github.com/Azure/azure-powershell/blob/preview/tools/CreateAliasMapping.ps1).

4.) Copy the output contents from [tools/AliasMappings.json](https://github.com/Azure/azure-powershell/blob/preview/tools/AliasMapping.json) into the mapping variable in [src/ResourceManager/Profile/Commands.Profile/AzureRmAlias/Mappings.cs](https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/Profile/Commands.Profile/AzureRmAlias/Mappings.cs#L36).
