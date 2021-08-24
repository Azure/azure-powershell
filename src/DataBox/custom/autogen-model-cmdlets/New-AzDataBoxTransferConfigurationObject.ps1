
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
    Create a in-memory object for TransferConfiguration
    .Description
    Create a in-memory object for TransferConfiguration

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.TransferConfiguration
    .Link
    https://docs.microsoft.com/powershell/module/az.DataBox/new-AzDataBoxTransferConfigurationObject
    #>
    function New-AzDataBoxTransferConfigurationObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.TransferConfiguration')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="Map of filter type and the details to transfer all data. This field is required only if the TransferConfigurationType is given as TransferAll.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ITransferConfigurationTransferAllDetails]
            $TransferAllDetail,
            [Parameter(HelpMessage="Map of filter type and the details to filter. This field is required only if the TransferConfigurationType is given as TransferUsingFilter.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ITransferConfigurationTransferFilterDetails]
            $TransferFilterDetail,
            [Parameter(Mandatory, HelpMessage="Type of the configuration for transfer.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.TransferConfigurationType]
            $Type
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.TransferConfiguration]::New()
    
            $Object.TransferAllDetail = $TransferAllDetail
            $Object.TransferFilterDetail = $TransferFilterDetail
            $Object.Type = $Type
            return $Object
        }
    }
    
