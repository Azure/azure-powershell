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
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;
using static Microsoft.Azure.Commands.CodeSigning.Helpers.NativeMethod;
using static Microsoft.Azure.Commands.CodeSigning.Helpers.CapiUtil;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    public unsafe static class TimeStampingHelper
    {
        private static readonly Oid _rfc3161CountersignOid = new Oid("1.3.6.1.4.1.311.3.3.1");
        internal static readonly Oid Sha384RsaOid = new Oid("1.2.840.113549.1.1.12");

        private static readonly Oid _rsaCountersignOid = new Oid("1.2.840.113549.1.9.6");
        private static readonly Oid _sha256Oid = new Oid("2.16.840.1.101.3.4.2.1");

        // constants from wincrypt.h
        private static readonly IntPtr PKCS_ATTRIBUTE = (IntPtr)22;
        private static readonly IntPtr X509_OCTET_STRING = (IntPtr)25;
        private const uint CRYPT_ENCODE_ALLOC_FLAG = 0x8000;
        private const uint CMSG_CONTENT_PARAM = 2;
        private const uint CMSG_SIGNER_INFO_PARAM = 6;
        private const uint CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR = 8;
        private const uint CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR = 9;
        private const uint CMSG_SIGNER_UNAUTH_ATTR_PARAM = 10;
        private const uint CMSG_COMPUTED_HASH_PARAM = 22;
        private const uint CMSG_ENCRYPTED_DIGEST = 27;
        private const uint CMSG_ENCODED_MESSAGE = 29;
        private const uint CMSG_SIGNED_DATA_NO_SIGN_FLAG = 0x00000080;
        private const uint CMSG_CTRL_DEL_SIGNER = 7;
        private const uint CMSG_CTRL_ADD_CMS_SIGNER_INFO = 20;

        /// <summary>
        /// Timestamps an input file.
        /// </summary>
        public static byte[] Rfc3161Timestamp(byte[] input, string timestampServerUrl)
        {
            // precondition checking
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (timestampServerUrl == null)
            {
                throw new ArgumentNullException(nameof(timestampServerUrl));
            }

            fixed (byte* pbInput = input)
            {
                byte dummy; // since the CLR doesn't like pinning empty arrays
                return Rfc3161TimestampCore(
                    pbInput: (pbInput != null) ? pbInput : &dummy,
                    cbInput: (uint)input.Length,
                    timestampServerUrl: timestampServerUrl);
            }
        }

        private static byte[] Rfc3161TimestampCore(byte* pbInput, uint cbInput, string timestampServerUrl)
        {
            // This logic closely matches that of Rfc3161Timestamper::TimestampPkcs7
            // See //depot/fbl_sec/ds/security/cryptoapi/pkisign/tools/capilib/SignedCode.cpp

            // parse the incoming CMS payload

            SafeCryptMessageHandle messageHandle = CryptMsgOpenToDecode(
                dwMsgEncodingType: MessageEncodingType.X509_ASN_ENCODING | MessageEncodingType.PKCS_7_ASN_ENCODING,
                dwFlags: 0,
                dwMsgType: 0,
                hCryptProv: IntPtr.Zero,
                pRecipientInfo: IntPtr.Zero,
                pStreamInfo: IntPtr.Zero);
            AssertSafeHandleIsValid(messageHandle);

            using (messageHandle)
            {
                bool success = CryptMsgUpdate(
                    hCryptMsg: messageHandle,
                    pbData: (IntPtr)pbInput,
                    cbData: cbInput,
                    fFinal: true);
                AssertSuccess(success, nameof(CryptMsgUpdate));

                // get the existing signed digest from the message and send it up to the timestamper

                byte[] digest = GetMessageEncryptedDigest(messageHandle);
                SafeCryptMemHandle timestampStructHandle;
                fixed (byte* pbDigest = digest)
                {
                    success = CryptRetrieveTimeStamp(
                        wszUrl: timestampServerUrl,
                        dwRetrievalFlags: 0,
                        dwTimeout: 1000 * 60 * 5, // 5 minutes
                        pszHashId: _sha256Oid.Value,
                        pPara: IntPtr.Zero,
                        pbData: pbDigest,
                        cbData: (uint)digest.Length,
                        ppTsContext: out timestampStructHandle,
                        ppTsSigner: IntPtr.Zero,
                        phStore: IntPtr.Zero);
                }
                AssertSuccess(success, nameof(CryptRetrieveTimeStamp));
                AssertSafeHandleIsValid(timestampStructHandle);

                // turn the timestamped payload into a PKCS attribute

                SafeLocalAllocHandle timestampAttributeHandle;
                uint cbTimestampAttribute;
                using (timestampStructHandle)
                {
                    CRYPT_TIMESTAMP_CONTEXT* pTimestampContext = (CRYPT_TIMESTAMP_CONTEXT*)timestampStructHandle.DangerousGetHandle();
                    timestampAttributeHandle = EncodePkcsAttribute(
                        oid: _rfc3161CountersignOid,
                        pbData: pTimestampContext->pbEncoded,
                        cbData: pTimestampContext->cbEncoded,
                        cbEncoded: out cbTimestampAttribute);
                }

                using (timestampAttributeHandle)
                {
                    // set our timestamp as the sole countersignature

                    DeleteAllCountersignatures(messageHandle);

                    CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA attrToAdd = default(CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA);
                    attrToAdd.cbSize = (uint)sizeof(CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA);
                    attrToAdd.dwSignerIndex = 0; // always assume only one signer
                    attrToAdd.BLOB.pbData = timestampAttributeHandle.DangerousGetHandle();
                    attrToAdd.BLOB.cbData = cbTimestampAttribute;

                    success = CryptMsgControl(
                        hCryptMsg: messageHandle,
                        dwFlags: 0,
                        dwCtrlType: CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR,
                        pvCtrlPara: &attrToAdd);
                    AssertSuccess(success, nameof(CryptMsgControl));

                    // that's it!

                    return GetMessageEncodedMessage(messageHandle);
                }
            }
        }

        internal static byte[] GetMessageEncodedMessage(SafeCryptMessageHandle message)
        {
            return GetMessageParameterAsByteArray(
                message: message,
                dwParamType: CMSG_ENCODED_MESSAGE,
                dwIndex: 0);
        }

        private static SafeLocalAllocHandle EncodePkcsAttribute(Oid oid, IntPtr pbData, uint cbData, out uint cbEncoded)
        {
            IntPtr pszOid = Marshal.StringToHGlobalAnsi(oid.Value);
            try
            {
                DATA_BLOB blob = default(DATA_BLOB);
                blob.pbData = pbData;
                blob.cbData = cbData;

                CRYPT_ATTRIBUTE attribute = default(CRYPT_ATTRIBUTE);
                attribute.pszObjId = pszOid;
                attribute.cValue = 1;
                attribute.rgValue = &blob;

                SafeLocalAllocHandle retVal;
                bool success = CryptEncodeObjectEx(
                    dwCertEncodingType: MessageEncodingType.X509_ASN_ENCODING | MessageEncodingType.PKCS_7_ASN_ENCODING,
                    lpszStructType: PKCS_ATTRIBUTE,
                    pvStructInfo: (IntPtr)(&attribute),
                    dwFlags: CRYPT_ENCODE_ALLOC_FLAG,
                    pEncodePara: IntPtr.Zero,
                    pvEncoded: out retVal,
                    pcbEncoded: out cbEncoded);
                AssertSuccess(success, nameof(CryptEncodeObjectEx));
                AssertSafeHandleIsValid(retVal);

                return retVal;
            }
            finally
            {
                Marshal.FreeHGlobal(pszOid);
            }
        }

        internal static SafeLocalAllocHandle GetMessageSignerUnauthenticatedAttributes(SafeCryptMessageHandle message)
        {
            uint unused;
            return GetMessageParameterAsHandle(
                message: message,
                dwParamType: CMSG_SIGNER_UNAUTH_ATTR_PARAM,
                dwIndex: 0,
                cbData: out unused,
                allowFailure: true);
        }

        private static void DeleteAllCountersignatures(SafeCryptMessageHandle message)
        {
            SafeLocalAllocHandle attributesHandle = GetMessageSignerUnauthenticatedAttributes(message);

            // if there are no existing unauth attributes, short-circuit the method now
            if (attributesHandle == null)
            {
                return;
            }

            using (attributesHandle)
            {
                CRYPT_ATTRIBUTES* pCryptAttributes = (CRYPT_ATTRIBUTES*)attributesHandle.DangerousGetHandle();

                // iterate through the array backward since data after the deleted index shifts forward
                for (uint i = pCryptAttributes->cAttr; i-- != 0;)
                {
                    string thisAttrOid = Marshal.PtrToStringAnsi(pCryptAttributes->rgAttr[i].pszObjId);
                    if (thisAttrOid == _rsaCountersignOid.Value || thisAttrOid == _rfc3161CountersignOid.Value)
                    {
                        // delete the attribute at 'i' index if the OID matches a countersignature we want to remove
                        CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA attrToDelete = default(CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA);
                        attrToDelete.cbSize = (uint)sizeof(CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA);
                        attrToDelete.dwSignerIndex = 0; // always assume only one signer
                        attrToDelete.dwUnauthAttrIndex = i;

                        bool success = CryptMsgControl(
                            hCryptMsg: message,
                            dwFlags: 0,
                            dwCtrlType: CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR,
                            pvCtrlPara: &attrToDelete);
                        AssertSuccess(success, nameof(CryptMsgControl));
                    }
                }
            }
        }

        internal static byte[] GetMessageEncryptedDigest(SafeCryptMessageHandle message)
        {
            return GetMessageParameterAsByteArray(
                message: message,
                dwParamType: CMSG_ENCRYPTED_DIGEST,
                dwIndex: 0);
        }

        private static byte[] GetMessageParameterAsByteArray(SafeCryptMessageHandle message, uint dwParamType, uint dwIndex)
        {
            uint cbData;
            using (var buffer = GetMessageParameterAsHandle(message, dwParamType, dwIndex, out cbData))
            {
                // trim and return
                return buffer.ToByteArray(cbData);
            }
        }

        private static SafeLocalAllocHandle GetMessageParameterAsHandle(SafeCryptMessageHandle message, uint dwParamType, uint dwIndex, out uint cbData, bool allowFailure = false)
        {
            // first, determine the number of bytes needed to allocate
            uint cbDataTemp = 0;
            bool success = CryptMsgGetParam(
                hCryptMsg: message,
                dwParamType: dwParamType,
                dwIndex: dwIndex,
                pvData: IntPtr.Zero,
                pcbData: ref cbDataTemp);

            // it's ok if we can't get certain parameters - don't throw
            if (!success && allowFailure)
            {
                cbData = 0;
                return null;
            }
            AssertSuccess(success, nameof(CryptMsgGetParam));

            // allocate necessary amount of memory (this might be overestimated)
            // and rerun the operation
            var buffer = SafeLocalAllocHandle.Allocate(cbDataTemp);
            success = CryptMsgGetParam(
                hCryptMsg: message,
                dwParamType: dwParamType,
                dwIndex: dwIndex,
                pvData: (IntPtr)buffer.DangerousGetHandle(),
                pcbData: ref cbDataTemp);
            AssertSuccess(success, nameof(CryptMsgGetParam));

            cbData = cbDataTemp;
            return buffer;
        }
    }

    internal sealed class SafeCryptMessageHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // Called by P/Invoke when returning SafeHandles
        private SafeCryptMessageHandle()
              : base(ownsHandle: true)
        { }

        // Do not provide a finalizer - SafeHandle's critical finalizer will
        // call ReleaseHandle for you.

        protected override bool ReleaseHandle()
        {
            return NativeMethod.CryptMsgClose(handle);
        }
    }
}
