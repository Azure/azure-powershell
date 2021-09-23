
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


function New-AzMgAppCredential {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential], [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential])]
    [CmdletBinding(DefaultParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet ', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet', Mandatory)]
        [Alias('Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${ObjectId},

        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${ApplicationId},

        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${DisplayName},

        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication]
        ${ApplicationObject},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${CertValue},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.Security.SecureString]
        ${Password},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithKeyCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithKeyCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential]
        ${KeyCredential},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordCredentialParameterSet', Mandatory)]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordCredentialParameterSet', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential]
        ${PasswordCredential},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${StartDate},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.DateTime]
        ${EndDate},

        [Parameter(ParameterSetName = 'ApplicationObjectIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithCertValueParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationIdWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'DisplayNameWithPasswordParameterSet')]
        [Parameter(ParameterSetName = 'ApplicationObjectWithPasswordParameterSet')]
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
        [System.String]
        ${CustomKeyIdentifier},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if ($PSBoundParameters.ContainsKey('KeyCredential')) {
            $credential = $PSBoundParameters['KeyCredential']
        }
        elseif ($PSBoundParameters.ContainsKey('PasswordCredential')) {
            $credential = $PSBoundParameters['PasswordCredential']
        }
        else {
            if ($PSBoundParameters.ContainsKey('Password')) {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential" 
                -Property @{'SecretText' = (Unprotect-SecureString -SecureString $PSBoundParameters['Password']) }
            }
            if ($PSBoundParameters.ContainsKey('CertValue')) {
                $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" 
                -Property @{'Key' = ([System.Convert]::FromBase64String($PSBoundParameters['CertValue']));
                    'Usage'       = 'Verify'; 
                    'Type'        = 'AsymmetricX509Cert'
                }
            }
            if ($PSBoundParameters.ContainsKey('CustomKeyIdentifier')) {
                $credential.CustomKeyIdentifier = [System.Convert]::FromBase64String($PSBoundParameters['CustomKeyIdentifier'])
            }
            if ($PSBoundParameters.ContainsKey('StartDate')) {
                $credential.StartDateTime = $PSBoundParameters['StartDate']
            }
            if ($PSBoundParameters.ContainsKey('EndDate')) {
                $credential.EndDateTime = $PSBoundParameters['EndDate']
            }
            $credential.KeyId = (New-Guid).ToString()
        }

        switch ($PSCmdlet.ParameterSetName) {
            { 'ApplicationObjectIdWithPasswordParameterSet' -or 'ApplicationObjectIdWithPasswordCredentialParameterSet' } {
                MSGraph.internal\Add-AzMgApplicationPassword -ApplicationId $PSBoundParameters['ObjectId'] -PasswordCredential $credential
                break
            }
            { 'ApplicationObjectIdWithCertValueParameterSet' -or 'ApplicationObjectIdWithKeyCredentialParameterSet' } {
                MSGraph.internal\Add-AzMgApplicationKey -ApplicationId $PSBoundParameters['ObjectId'] -KeyCredential $credential
                break
            }
            { 'ApplicationIdWithPasswordParameterSet' -or 'ApplicationIdWithPasswordCredentialParameterSet' } {
                $app = Get-AzMgApplication -ApplicationId $PSBoundParameters['ApplicationId'] -Select Id
                if ($app) {
                    MSGraph.internal\Add-AzMgApplicationPassword -ApplicationId $app.Id -PasswordCredential $credential    
                }
                else {
                    Write-Error "application with application id '$($PSBoundParameters['ApplicationId'])' does not exist."
                    return
                }
                break
            }
            { 'ApplicationIdWithCertValueParameterSet' -or 'ApplicationIdWithKeyCredentialParameterSet' } {
                $app = Get-AzMgApplication -ApplicationId $PSBoundParameters['ApplicationId'] -Select Id
                if ($app) {
                    MSGraph.internal\Add-AzMgApplicationKey -ApplicationId $app.Id -KeyCredential $credential 
                }
                else {
                    Write-Error "application with application id '$($PSBoundParameters['ApplicationId'])' does not exist."
                    return
                }
                break
            }
            { 'DisplayNameWithPasswordParameterSet' -or 'DisplayNameWithPasswordCredentialParameterSet' } {
                $app = Get-AzMgApplication DisplayName $PSBoundParameters['DisplayName'] -Select Id
                if (0 -eq $app.Count) {
                    Write-Error "application with display name '$($PSBoundParameters['DisPlayName'])' does not exist."
                    return
                }
                elseif (1 -eq $app.Count) {
                    MSGraph.internal\Add-AzMgApplicationPassword -ApplicationId $app[0].Id -PasswordCredential $credential
                }
                else {
                    Write-Error "More than one application found with display name '$($PSBoundParameters['DisplayName'])'. Please use the Get-AzMgApplication cmdlet to get the object id of the desired application."
                    return
                }
                break
            }
            { 'DisplayNameWithCertValueParameterSet' -or 'DisplayNameWithKeyCredentialParameterSet' } {
                $app = Get-AzMgApplication DisplayName $PSBoundParameters['DisplayName'] -Select Id
                if (0 -eq $app.Count) {
                    Write-Error "application with display name '$($PSBoundParameters['DisPlayName'])' does not exist."
                    return
                }
                elseif (1 -eq $app.Count) {
                    MSGraph.internal\Add-AzMgApplicationkey -ApplicationId $app[0].Id -KeyCredential $credential
                }
                else {
                    Write-Error "More than one application found with display name '$($PSBoundParameters['DisplayName'])'. Please use the Get-AzMgApplication cmdlet to get the object id of the desired application."
                    return
                }
                break
            }
            { 'ApplicationObjectWithPasswordParameterSet' -or 'ApplicationObjectWithPasswordParameterSet' } {
                MSGraph.internal\Add-AzMgApplicationPassword -ApplicationId $PSBoundParameters['ApplicationObject'].Id -PasswordCredential $credential
                break
            }
            { 'ApplicationObjectWithCertValueParameterSet' -or 'ApplicationObjectWithCertValueParameterSet' } {
                MSGraph.internal\Add-AzMgApplicationKey -ApplicationId $PSBoundParameters['ApplicationObject'].Id -KeyCredential $credential
                break
            }
            default {
                break
            }
        }    
    }
}