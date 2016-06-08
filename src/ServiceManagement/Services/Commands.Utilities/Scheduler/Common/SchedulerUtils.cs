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
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Common
{
    public static class SchedulerUtils
    {
        public static string GetCertData(string pfxPath, string password)
        {
            if (!string.IsNullOrEmpty(pfxPath))
            {                
                var cert = new X509Certificate2();
                cert.Import(pfxPath, password, X509KeyStorageFlags.Exportable);
                return cert.HasPrivateKey
                    ? Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password))
                    : Convert.ToBase64String(cert.Export(X509ContentType.Pkcs12));
            }
            return null;
        }
    }
}
