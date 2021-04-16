
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

<#
.Synopsis
Returns a BotService specified by the parameters.
.Description
Returns a BotService specified by the parameters.
.Link
https://docs.microsoft.com/powershell/module/az.botservice/publish-azbotserviceapp
#>
function Publish-AzBotServiceApp {
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [System.String]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [System.String]
        # This parameter defines the name of the bot.
        ${Name},

        [Parameter(Mandatory)]
        [ValidateNotNull()]
        [System.String]
        #This parameter defines the Path of the ZIP
        ${CodeDir}
    )
    
    process {
        try {
            $ZipName = 'Template.Zip'
            Compress-Archive $CodeDir $ZipName
            Write-Host 'Completed ZIP'
            Import-Module Az.WebSites
            Publish-AzWebApp -ArchivePath $ZipName -ResourceGroupName $ResourceGroupName -Name $Name -Force
            Remove-Item $ZipName
        } catch {
            throw
        }
    }
}

