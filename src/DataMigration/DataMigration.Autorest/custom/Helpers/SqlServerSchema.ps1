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


# Function Definitions

function Test-SqlServerSchemaConfigFile{
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $path
    )

    process {
        if (!(Test-Path -Path $path))
        {
            throw "Invalid Config File path: $path"
        } 
    }
}

function  Get-DefaultSqlServerSchemaOutputFolder {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
    )

    process {
        $OSPlatform = Get-OSName

        if($OSPlatform.Contains("Linux"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath ".config\Microsoft\SqlSchemaMigration";

        }
        elseif ($OSPlatform.Contains("Darwin"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath "Library\Application Support\Microsoft\SqlSchemaMigration";
        }
        else
        {
            $DefualtPath = Join-Path -Path $env:LOCALAPPDATA -ChildPath "Microsoft\SqlSchemaMigration";
        }

        return $DefualtPath
    }
}
