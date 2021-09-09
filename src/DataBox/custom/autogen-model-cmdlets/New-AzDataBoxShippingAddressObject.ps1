
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
    Create a in-memory object for ShippingAddress
    .Description
    Create a in-memory object for ShippingAddress

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ShippingAddress
    .Link
    https://docs.microsoft.com/powershell/module/az.DataBox/new-AzDataBoxShippingAddressObject
    #>
    function New-AzDataBoxShippingAddressObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ShippingAddress')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="Type of address.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.AddressType]
            $AddressType,
            [Parameter(HelpMessage="Name of the City.")]
            [string]
            $City,
            [Parameter(HelpMessage="Name of the company.")]
            [string]
            $CompanyName,
            [Parameter(Mandatory, HelpMessage="Name of the Country.")]
            [string]
            $Country,
            [Parameter(HelpMessage="Postal code.")]
            [string]
            $PostalCode,
            [Parameter(HelpMessage="Name of the State or Province.")]
            [string]
            $StateOrProvince,
            [Parameter(Mandatory, HelpMessage="Street Address line 1.")]
            [string]
            $StreetAddress1,
            [Parameter(HelpMessage="Street Address line 2.")]
            [string]
            $StreetAddress2,
            [Parameter(HelpMessage="Street Address line 3.")]
            [string]
            $StreetAddress3,
            [Parameter(HelpMessage="Extended Zip Code.")]
            [string]
            $ZipExtendedCode
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.ShippingAddress]::New()
    
            $Object.AddressType = $AddressType
            $Object.City = $City
            $Object.CompanyName = $CompanyName
            $Object.Country = $Country
            $Object.PostalCode = $PostalCode
            $Object.StateOrProvince = $StateOrProvince
            $Object.StreetAddress1 = $StreetAddress1
            $Object.StreetAddress2 = $StreetAddress2
            $Object.StreetAddress3 = $StreetAddress3
            $Object.ZipExtendedCode = $ZipExtendedCode
            return $Object
        }
    }
    
