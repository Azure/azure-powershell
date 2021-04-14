
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for Volume
.Description
Create a in-memory object for Volume

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Volume
.Link
https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerGroupVolumeObject
#>
function New-AzContainerGroupVolumeObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Volume')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The flag indicating whether the Azure File shared mounted as a volume is read-only.")]
        [System.Management.Automation.SwitchParameter]
        $AzureFileReadOnly,
        [Parameter(HelpMessage="The name of the Azure File share to be mounted as a volume.")]
        [string]
        $AzureFileShareName,
        [Parameter(HelpMessage="The storage account access key used to access the Azure File share.")]
        [SecureString]
        $AzureFileStorageAccountKey,
        [Parameter(HelpMessage="The name of the storage account that contains the Azure File share.")]
        [string]
        $AzureFileStorageAccountName,
        # [Parameter(HelpMessage="The empty directory volume.")]
        # [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IAny]
        # $EmptyDir,
        [Parameter(HelpMessage="Target directory name. Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the git repository.  Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.")]
        [string]
        $GitRepoDirectoryName,
        [Parameter(HelpMessage="Repository URL.")]
        [string]
        $GitRepoRepositoryUrl,
        [Parameter(HelpMessage="Commit hash for the specified revision.")]
        [string]
        $GitRepoRevision,
        [Parameter(Mandatory, HelpMessage="The name of the volume.")]
        [string]
        $Name
        # ,
        # [Parameter(HelpMessage="The secret volume.")]
        # [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume]
        # $Secret
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Volume]::New()

        $Object.AzureFileShareName = $AzureFileShareName
        if ($PSBoundParameters.ContainsKey('AzureFileStorageAccountKey')) {
            $psTxt = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $PSBoundParameters['AzureFileStorageAccountKey']
        }
        $Object.AzureFileStorageAccountKey = $psTxt
        Write-host $psTxt
        $Object.AzureFileStorageAccountName = $AzureFileStorageAccountName
        # $Object.EmptyDir = $EmptyDir
        $Object.GitRepoDirectory = $GitRepoDirectoryName
        $Object.GitRepoRepository = $GitRepoRepositoryUrl
        $Object.GitRepoRevision = $GitRepoRevision
        $Object.Name = $Name
        # $Object.Secret = $Secret
        return $Object
    }
}

