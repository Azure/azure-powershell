# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

$aliases = @{
    # Profile aliases
    "Get-WAPackPublishSettingsFile" = "Get-AzurePublishSettingsFile";
    "Get-WAPackSubscription" = "Get-AzureSubscription";
    "Import-WAPackPublishSettingsFile" = "Import-AzurePublishSettingsFile";
    "Remove-WAPackSubscription" = "Remove-AzureSubscription";
    "Select-WAPackSubscription" = "Select-AzureSubscription";
    "Set-WAPackSubscription" = "Set-AzureSubscription";
    "Show-WAPackPortal" = "Show-AzurePortal";
    "Test-WAPackName" = "Test-AzureName";
    "Get-WAPackEnvironment" = "Get-AzureEnvironment";
    "Add-WAPackEnvironment" = "Add-AzureEnvironment";
    "Set-WAPackEnvironment" = "Set-AzureEnvironment";
    "Remove-WAPackEnvironment" = "Remove-AzureEnvironment";

    # Websites aliases
    "New-WAPackWebsite" = "New-AzureWebsite";
    "Get-WAPackWebsite" = "Get-AzureWebsite";
    "Set-WAPackWebsite" = "Set-AzureWebsite";
    "Remove-WAPackWebsite" = "Remove-AzureWebsite";
    "Start-WAPackWebsite" = "Start-AzureWebsite";
    "Stop-WAPackWebsite" = "Stop-AzureWebsite";
    "Restart-WAPackWebsite" = "Restart-AzureWebsite";
    "Show-WAPackWebsite" = "Show-AzureWebsite";
    "Get-WAPackWebsiteLog" = "Get-AzureWebsiteLog";
    "Save-WAPackWebsiteLog" = "Save-AzureWebsiteLog";
    "Get-WAPackWebsiteLocation" = "Get-AzureWebsiteLocation";
    "Get-WAPackWebsiteDeployment" = "Get-AzureWebsiteDeployment";
    "Restore-WAPackWebsiteDeployment" = "Restore-AzureWebsiteDeployment";
    "Enable-WAPackWebsiteApplicationDiagnositc" = "Enable-AzureWebsiteApplicationDiagnostic";
    "Disable-WAPackWebsiteApplicationDiagnostic" = "Disable-AzureWebsiteApplicationDiagnostic";

    # Service Bus aliases
    "Get-WAPackSBLocation" = "Get-AzureSBLocation";
    "Get-WAPackSBNamespace" = "Get-AzureSBNamespace";
    "New-WAPackSBNamespace" = "New-AzureSBNamespace";
    "Remove-WAPackSBNamespace" = "Remove-AzureSBNamespace";

    # Storage aliases
    "Get-AzureStorageContainerAcl" = "Get-AzureStorageContainer";
    "Start-CopyAzureStorageBlob" = "Start-AzureStorageBlobCopy";
    "Stop-CopyAzureStorageBlob" = "Stop-AzureStorageBlobCopy";

    # Compute aliases
    "New-AzureDns" = "New-AzureDnsConfig";
	
    # HDInsight aliases
    "Invoke-Hive" = "Invoke-AzureHDInsightHiveJob";
    "hive" = "Invoke-AzureHDInsightHiveJob"
}

$aliases.GetEnumerator() | Select @{Name='Name'; Expression={$_.Key}}, @{Name='Value'; Expression={$_.Value}} | New-Alias -Description "AzureAlias"