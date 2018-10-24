// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagementInteropConstants.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   Native code PInvokes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    public class ManagementInteropConstants
    {
        public static readonly Guid CLSID_CEcsManagement = Guid.Parse("3EC1199D-20EB-40C0-8294-EB684E89AB2B");

        public static readonly Guid IID_IEcsManagement = Guid.Parse("F29EAB44-2C63-4ACE-8C05-67C2203CBED2");

        public static readonly Guid IID_IUnknown = Guid.Parse("00000000-0000-0000-C000-000000000046");

        public static readonly uint CLSCTX_LOCAL_SERVER = 4;

        public static readonly uint RPC_C_AUTHN_LEVEL_PKT = 4;

        public static readonly uint RPC_C_IMP_LEVEL_IMPERSONATE = 3;
        
        public const int MAX_PATH = 260;

        // The Hash Algorithm OID is an OID identifying the hash algorithm used to sign the certificate request
        // sha512RSA according to https://msdn.microsoft.com/en-us/library/ff635603.aspx

        public static readonly string CertificateHashAlgorithm = "1.2.840.113549.1.1.13";

        public static readonly uint CertificateKeyLength = 2048;

        public static readonly string CertificateProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider";

        public const uint hrShareNotFound = 0x80C80037; // (ECS_E_SYNC_SHARE_NOT_FOUND)
        public const uint hrUserNotFound = 0x80C83031; // (ECS_E_USER_ENUMERATION_ERROR)
        public const uint hrReplicaNotReady = 0x80C8300F; // (ECS_E_REPLICA_NOT_READY)
        public const uint hrGhostingFailed = 0x80C80222; // (ECS_E_GHOSTING_FAILED)
        public const uint hrGhostingDisabled = 0x80C80224; // (ECS_E_GHOSTING_DISABLED)
        public const uint hrPathNotValid = 0x80C8022F;  //  (ECS_E_SCRUBBING_PATH_INVALID)
        public const uint hrShareBusy = 0x80C8022E;  //  (ECS_E_SCRUBBING_SHAREBUSY)
        public const uint hrGCShareBusy = 0x80C80242;  //  (ECS_E_GC_SHAREBUSY)
        public const uint hrGCPathNotValid = 0x80C80246;  //  (ECS_E_GC_PATH_INVALID)
        public const uint hrStableVersionDisabled = 0x80C80247; // (ECS_E_STABLEVERSION_DISABLED)
        public const uint hrBackupNowFailed = 0x80C80251; // (ECS_E_BACKUPNOW_FAILED)
        public const uint hrBCDRInProgress = 0x80C80257; // (ECS_E_BCDR_IN_PROGRESS)
        public const uint hrScrubbingAborted = 0x80C80260; // (ECS_E_SCRUBBING_ABORT_TOO_MANY_ERRORS)

        public const uint hrNetworkLimitConfigConflict = 0x80C83059; // ECS_E_NETWORK_LIMIT_CONFIG_CONFLICT
        public const uint hrNetworkLimitConfigStartBeforeEnd = 0x80C8305A; // ECS_E_NETWORK_LIMIT_CONFIG_START_BEFORE_END

        public const uint hrPathNotSupported = 0x80C80226; // (ECS_E_GHOSTING_NOT_SUPPORTED)
        public const uint hrRecallFailed = 0x80C80222; // (ECS_E_recall_FAILED)

        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        public static int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public static int FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;

        public const Int64 INVALID_FILE_ATTRIBUTES = 0xffffffff;

        public const uint RPC_C_AUTHN_DEFAULT = 0xFFFFFFFF;

        public const uint RPC_C_AUTHZ_NONE = 0;

    }

}
