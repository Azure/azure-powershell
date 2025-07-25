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

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Class ManagementInteropConstants.
    /// </summary>
    public class ManagementInteropConstants
    {
        /// <summary>
        /// The CLSID c ecs management
        /// </summary>
        public static readonly Guid CLSID_CEcsManagement = Guid.Parse("3EC1199D-20EB-40C0-8294-EB684E89AB2B");

        /// <summary>
        /// The iid i ecs management
        /// </summary>
        public static readonly Guid IID_IEcsManagement = Guid.Parse("F29EAB44-2C63-4ACE-8C05-67C2203CBED2");

        /// <summary>
        /// The iid i unknown
        /// </summary>
        public static readonly Guid IID_IUnknown = Guid.Parse("00000000-0000-0000-C000-000000000046");

        /// <summary>
        /// the iid of stable version deep gc progress.
        /// </summary>
        public static readonly Guid IID_IStableVersionDeepGcProgress = Guid.Parse("737EADF1-B170-D548-76F2-80F4638F3787");

        /// <summary>
        /// the iid of scrubbing engine connection point.
        /// </summary>
        public static readonly Guid IID_IScrubbingEngineConnectionPoint = Guid.Parse("03057D98-C8F3-4B70-B1CF-5768DF69EE16");

        /// <summary>
        /// The CLSCTX local server
        /// </summary>
        public static readonly uint CLSCTX_LOCAL_SERVER = 4;

        /// <summary>
        /// The RPC c authn level PKT
        /// </summary>
        public static readonly uint RPC_C_AUTHN_LEVEL_PKT = 4;

        /// <summary>
        /// The RPC c imp level impersonate
        /// </summary>
        public static readonly uint RPC_C_IMP_LEVEL_IMPERSONATE = 3;

        /// <summary>
        /// The maximum path
        /// </summary>
        public const int MAX_PATH = 260;

        // The Hash Algorithm OID is an OID identifying the hash algorithm used to sign the certificate request
        // sha512RSA according to https://msdn.microsoft.com/en-us/library/ff635603.aspx

        /// <summary>
        /// The certificate hash algorithm
        /// </summary>
        public static readonly string CertificateHashAlgorithm = "1.2.840.113549.1.1.13";

        /// <summary>
        /// The certificate key length
        /// </summary>
        public static readonly uint CertificateKeyLength = 2048;

        /// <summary>
        /// The certificate provider name
        /// </summary>
        public static readonly string CertificateProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider";

        /// <summary>
        /// The hr share not found
        /// </summary>
        public const uint hrShareNotFound = 0x80C80037; // (ECS_E_SYNC_SHARE_NOT_FOUND)
        /// <summary>
        /// The hr user not found
        /// </summary>
        public const uint hrUserNotFound = 0x80C83031; // (ECS_E_USER_ENUMERATION_ERROR)
        /// <summary>
        /// The hr replica not ready
        /// </summary>
        public const uint hrReplicaNotReady = 0x80C8300F; // (ECS_E_REPLICA_NOT_READY)
        /// <summary>
        /// The hr ghosting failed
        /// </summary>
        public const uint hrGhostingFailed = 0x80C80222; // (ECS_E_GHOSTING_FAILED)
        /// <summary>
        /// The hr ghosting disabled
        /// </summary>
        public const uint hrGhostingDisabled = 0x80C80224; // (ECS_E_GHOSTING_DISABLED)
        /// <summary>
        /// The hr path not valid
        /// </summary>
        public const uint hrPathNotValid = 0x80C8022F;  //  (ECS_E_SCRUBBING_PATH_INVALID)
        /// <summary>
        /// The hr share busy
        /// </summary>
        public const uint hrShareBusy = 0x80C8022E;  //  (ECS_E_SCRUBBING_SHAREBUSY)
        /// <summary>
        /// The hr gc share busy
        /// </summary>
        public const uint hrGCShareBusy = 0x80C80242;  //  (ECS_E_GC_SHAREBUSY)
        /// <summary>
        /// The hr gc path not valid
        /// </summary>
        public const uint hrGCPathNotValid = 0x80C80246;  //  (ECS_E_GC_PATH_INVALID)
        /// <summary>
        /// The hr stable version disabled
        /// </summary>
        public const uint hrStableVersionDisabled = 0x80C80247; // (ECS_E_STABLEVERSION_DISABLED)
        /// <summary>
        /// The hr backup now failed
        /// </summary>
        public const uint hrBackupNowFailed = 0x80C80251; // (ECS_E_BACKUPNOW_FAILED)
        /// <summary>
        /// The hr BCDR in progress
        /// </summary>
        public const uint hrBCDRInProgress = 0x80C80257; // (ECS_E_BCDR_IN_PROGRESS)
        /// <summary>
        /// The hr scrubbing aborted
        /// </summary>
        public const uint hrScrubbingAborted = 0x80C80260; // (ECS_E_SCRUBBING_ABORT_TOO_MANY_ERRORS)

        /// <summary>
        /// The hr network limit configuration conflict
        /// </summary>
        public const uint hrNetworkLimitConfigConflict = 0x80C83059; // ECS_E_NETWORK_LIMIT_CONFIG_CONFLICT
        /// <summary>
        /// The hr network limit configuration start before end
        /// </summary>
        public const uint hrNetworkLimitConfigStartBeforeEnd = 0x80C8305A; // ECS_E_NETWORK_LIMIT_CONFIG_START_BEFORE_END

        /// <summary>
        /// The hr path not supported
        /// </summary>
        public const uint hrPathNotSupported = 0x80C80226; // (ECS_E_GHOSTING_NOT_SUPPORTED)
        /// <summary>
        /// The hr recall failed
        /// </summary>
        public const uint hrRecallFailed = 0x80C80222; // (ECS_E_recall_FAILED)

        /// <summary>
        /// The invalid handle value
        /// </summary>
        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        /// <summary>
        /// The file attribute directory
        /// </summary>
        public static int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        /// <summary>
        /// The file attribute reparse point
        /// </summary>
        public static int FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;

        /// <summary>
        /// The invalid file attributes
        /// </summary>
        public const Int64 INVALID_FILE_ATTRIBUTES = 0xffffffff;

        /// <summary>
        /// The RPC c authn default
        /// </summary>
        public const uint RPC_C_AUTHN_DEFAULT = 0xFFFFFFFF;

        /// <summary>
        /// The RPC c authz none
        /// </summary>
        public const uint RPC_C_AUTHZ_NONE = 0;

    }

}
