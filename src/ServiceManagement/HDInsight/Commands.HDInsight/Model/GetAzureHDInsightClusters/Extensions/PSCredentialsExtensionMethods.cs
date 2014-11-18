// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal static class PsCredentialsExtensionMethods
    {
        internal static string GetCleartextFromSecureString(SecureString secureString)
        {
            secureString.ArgumentNotNull("secureString");
            IntPtr bstr = Marshal.SecureStringToBSTR(secureString);
            string clearTextValue;
            try
            {
                clearTextValue = Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }

            return clearTextValue;
        }

        internal static string GetCleartextPassword(this PSCredential credentials)
        {
            credentials.ArgumentNotNull("credentials");
            return GetCleartextFromSecureString(credentials.Password);
        }
    }
}
