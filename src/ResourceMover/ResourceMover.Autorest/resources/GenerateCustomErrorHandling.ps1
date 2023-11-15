# We need to print the complete JSON response from resoure provider as error handling. Only the message field is not enough.
$cmdletFiles = Get-ChildItem -Path ../generated/cmdlets
foreach ($cmdletFile in $cmdletFiles)
{
    $fileName = $cmdletFile.Name
    $outputPath = "../custom/csharp/$fileName"
    $className = $cmdletFile.Name.Substring(0, $fileName.Length-3)
    $csFileContent ="// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801;

namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Cmdlets
{
    public partial class ${className}
    {
        partial void overrideOnDefault(HttpResponseMessage responseMessage, Task<ICloudError> errorResponseTask, ref Task<bool> returnNow)
        {
            this.WriteError(responseMessage, errorResponseTask, ref returnNow);
        }
    }
}"
    Write-Output $csFileContent > $outputPath
}