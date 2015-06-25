﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Security.Model;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// All the constants used by sql cmdlets
    /// </summary>
    public class SecurityConstants
    {
        // Audit Events:
        public class DeprecatedAuditEvents
        {
            // DeprecatedAuditEvents from 04/2015
            public const string DataAccess = "DataAccess";
            public const string SchemaChanges = "SchemaChanges";
            public const string DataChanges = "DataChanges";
            public const string SecurityExceptions = "SecurityExceptions";
            public const string RevokePermissions = "RevokePermissions";
        }

        public const string PlainSQL_Success = "PlainSQL_Success";
        public const string PlainSQL_Failure = "PlainSQL_Failure";
        public const string ParameterizedSQL_Success = "ParameterizedSQL_Success";
        public const string ParameterizedSQL_Failure = "ParameterizedSQL_Failure";
        public const string StoredProcedure_Success = "StoredProcedure_Success";
        public const string StoredProcedure_Failure = "StoredProcedure_Failure";
        public const string Login_Success = "Login_Success";
        public const string Login_Failure = "Login_Failure";
        public const string TransactionManagement_Success = "TransactionManagement_Success";
        public const string TransactionManagement_Failure = "TransactionManagement_Failure";

        public const string All = "All";
        public const string None = "None";

        public static readonly Dictionary<string, AuditEventType> AuditEventsToAuditEventType = new Dictionary
            <string, AuditEventType>
        {
            {DeprecatedAuditEvents.DataAccess, AuditEventType.DataAccess},
            {DeprecatedAuditEvents.DataChanges, AuditEventType.DataChanges},
            {DeprecatedAuditEvents.SecurityExceptions, AuditEventType.SecurityExceptions},
            {DeprecatedAuditEvents.RevokePermissions, AuditEventType.RevokePermissions},
            {DeprecatedAuditEvents.SchemaChanges, AuditEventType.SchemaChanges},
            {PlainSQL_Success, AuditEventType.PlainSQL_Success},
            {PlainSQL_Failure, AuditEventType.PlainSQL_Failure},
            {ParameterizedSQL_Success, AuditEventType.ParameterizedSQL_Success},
            {ParameterizedSQL_Failure, AuditEventType.ParameterizedSQL_Failure},
            {StoredProcedure_Success, AuditEventType.StoredProcedure_Success},
            {StoredProcedure_Failure, AuditEventType.StoredProcedure_Failure},
            {Login_Success, AuditEventType.Login_Success},
            {Login_Failure, AuditEventType.Login_Failure},
            {TransactionManagement_Success, AuditEventType.TransactionManagement_Success},
            {TransactionManagement_Failure, AuditEventType.TransactionManagement_Failure}
        };
        
        //id to locate a server's security policy
        public const string ServerPolicyId = "c3d905bb-e460-48bb-884d-75fac8f63e11";

        public const string Primary = "Primary";
        public const string Secondary = "Secondary";

        public const string Enabled = "Enabled";
        public const string Disabled = "Disabled";

        public const string Standard = "Standard";
        public const string Extended = "Extended";

        // Masking functions
        public const string NoMasking = "NoMasking";
        public const string Default = "Default";
        public const string Text = "Text";
        public const string Number = "Number";
        public const string SSN = "SocialSecurityNumber";
        public const string CCN = "CreditCardNumber";
        public const string Email = "Email";

        public const double NumberFromDefaultValue = 0;
        public const double NumberToDefaultValue = 0;
        public static uint PrefixSizeDefaultValue = 0;
        public static string ReplacementStringDefaultValue = string.Empty;
        public static uint SuffixSizeDefaultValue = 0;


        /// <summary>
        /// The values that are sent and received by the auditing endpoint
        /// </summary>
        public class AuditingEndpoint
        {
            public const string New = "New";
            public const string Enabled = "Enabled";
            public const string Disabled = "Disabled";

            // Event types
            public const string DataAccess = "DataAccess";
            public const string SchemaChanges = "SchemaChanges";
            public const string DataChanges = "DataChanges";
            public const string SecurityExceptions = "SecurityExceptions";
            public const string RevokePermissions = "RevokePermissions";
            public const string PlainSQL_Success = "PlainSQL_Success";
            public const string PlainSQL_Failure = "PlainSQL_Failure";
            public const string ParameterizedSQL_Success = "ParameterizedSQL_Success";
            public const string ParameterizedSQL_Failure = "ParameterizedSQL_Failure";
            public const string StoredProcedure_Success = "StoredProcedure_Success";
            public const string StoredProcedure_Failure = "StoredProcedure_Failure";
            public const string Login_Success = "Login_Success";
            public const string Login_Failure = "Login_Failure";
            public const string TransactionManagement_Success = "TransactionManagement_Success";
            public const string TransactionManagement_Failure = "TransactionManagement_Failure";
        }

        /// <summary>
        /// The values that are sent and received by the data masking endpoint
        /// </summary>
        public class DataMaskingEndpoint
        {
            public const string Standard = "Relaxed";
            public const string Extended = "Restricted";
            public const string Enabled = "Enabled";
            public const string Disabled = "Disabled";

            public const string NoMasking = "NoMasking";
            public const string Default = "Default";
            public const string Text = "Text";
            public const string Number = "Number";
            public const string SSN = "SSN";
            public const string CCN = "CCN";
            public const string Email = "Email";
        }

        /// <summary>
        /// The values that are sent and received by the secure connection policy endpoint
        /// </summary>
        public class SecureConnectionEndpoint
        {
            public const string Required = "Required";
            public const string Optional = "Optional";
        }
    }
}