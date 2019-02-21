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

namespace Microsoft.Azure.Commands.Sql.Common
{
    public class Constants
    {
        // request headers names
        public const string ClientSessionIdHeaderName = "x-ms-client-session-id";

        // Managed instance constants
        public const string LicenseTypeBasePrice = "BasePrice";
        public const string LicenseTypeLicenseIncluded = "LicenseIncluded";
        public const string GeneralPurposeGen4 = "GP_Gen4";
        public const string GeneralPurposeGen5 = "GP_Gen5";
        public const string BusinessCriticalGen4 = "BC_Gen4";
        public const string BusinessCriticalGen5 = "BC_Gen5";
        public const string BusinessCriticalEdition = "BusinessCritical";
        public const string GeneralPurposeEdition = "GeneralPurpose";
        public const string ComputeGenerationGen4 = "Gen4";
        public const string ComputeGenerationGen5 = "Gen5";
        public const string CollationSqlLatin1 = "SQL_Latin1_General_CP1_CI_AS";
        public const string CollationLatin1 = "Latin1_General_100_CS_AS_SC";
    }
}
