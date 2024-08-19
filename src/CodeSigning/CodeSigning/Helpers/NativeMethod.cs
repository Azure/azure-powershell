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

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    [SuppressUnmanagedCodeSecurity]
    internal unsafe static class NativeMethod
    {
        private const string CRYPT32_LIB = "crypt32.dll";
        /*
         * CRYPT32.DLL
         */
        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380228(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern SafeCryptMessageHandle CryptMsgOpenToDecode(
            [In] MessageEncodingType dwMsgEncodingType,
            [In] uint dwFlags,
            [In] MessageType dwMsgType,
            [In] IntPtr hCryptProv,
            [In] IntPtr pRecipientInfo,
            [In] IntPtr pStreamInfo);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380229(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern SafeCryptMessageHandle CryptMsgOpenToEncode(
            [In] MessageEncodingType dwMsgEncodingType,
            [In] uint dwFlags,
            [In] MessageType dwMsgType,
            [In] IntPtr pvMsgEncodeInfo,
            [In, MarshalAs(UnmanagedType.LPStr)] string pszInnerContentObjID,
            [In] IntPtr pStreamInfo);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380231(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern bool CryptMsgUpdate(
            [In] SafeCryptMessageHandle hCryptMsg,
            [In] IntPtr pbData,
            [In] uint cbData,
            [In] bool fFinal);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380216(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern void CryptMemFree(
            [In] IntPtr pv);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/dd433803(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern bool CryptRetrieveTimeStamp(
            [In, MarshalAs(UnmanagedType.LPWStr)] string wszUrl,
            [In] uint dwRetrievalFlags,
            [In] uint dwTimeout,
            [In, MarshalAs(UnmanagedType.LPStr)] string pszHashId,
            [In] IntPtr pPara,
            [In] byte* pbData,
            [In] uint cbData,
            [Out] out SafeCryptMemHandle ppTsContext,
            [In] IntPtr ppTsSigner,
            [In] IntPtr phStore);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380220(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern bool CryptMsgControl(
            [In] SafeCryptMessageHandle hCryptMsg,
            [In] uint dwFlags,
            [In] uint dwCtrlType,
            [In] void* pvCtrlPara);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380227(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern bool CryptMsgGetParam(
            [In] SafeCryptMessageHandle hCryptMsg,
            [In] uint dwParamType,
            [In] uint dwIndex,
            [In] IntPtr pvData,
            [In, Out] ref uint pcbData);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa379922(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern bool CryptEncodeObjectEx(
            [In] MessageEncodingType dwCertEncodingType,
            [In] IntPtr lpszStructType,
            [In] IntPtr pvStructInfo,
            [In] uint dwFlags,
            [In] IntPtr pEncodePara,
            [Out] out SafeLocalAllocHandle pvEncoded,
            [Out] out uint pcbEncoded);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380219(v=vs.85).aspx
        [DllImport(CRYPT32_LIB, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern bool CryptMsgClose(
            [In] IntPtr hCryptMsg);
    }

    internal sealed class SafeCryptMemHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // Called by P/Invoke when returning SafeHandles
        private SafeCryptMemHandle()
              : base(ownsHandle: true)
        { }

        // Do not provide a finalizer - SafeHandle's critical finalizer will
        // call ReleaseHandle for you.

        protected override bool ReleaseHandle()
        {
            NativeMethod.CryptMemFree(handle);
            return true;
        }
    }

    internal sealed class SafeLocalAllocHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // Called by P/Invoke when returning SafeHandles
        private SafeLocalAllocHandle()
              : base(ownsHandle: true)
        { }

        public static SafeLocalAllocHandle Allocate(uint cb)
        {
            var newHandle = new SafeLocalAllocHandle();
            newHandle.AllocateCore(cb);
            return newHandle;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        private void AllocateCore(uint cb)
        {
            SetHandle(Marshal.AllocHGlobal((IntPtr)cb));
        }

        // Do not provide a finalizer - SafeHandle's critical finalizer will
        // call ReleaseHandle for you.

        protected override bool ReleaseHandle()
        {
            // misnomer - actually calls LocalFree
            Marshal.FreeHGlobal(handle);
            return true;
        }

        public byte[] ToByteArray(uint byteCount)
        {
            byte[] buffer = new byte[byteCount];
            if (byteCount != 0)
            {
                bool refAdded = false;

                RuntimeHelpers.PrepareConstrainedRegions();
                try
                {
                    DangerousAddRef(ref refAdded);
                    Marshal.Copy(DangerousGetHandle(), buffer, 0, buffer.Length);
                }
                finally
                {
                    if (refAdded)
                    {
                        DangerousRelease();
                    }
                }
            }

            return buffer;
        }
    }

    internal unsafe static class CapiUtil
    {
        /// <summary>
        /// Asserts that <paramref name="condition"/> has been satisfied.
        /// </summary>
        /// <exception cref="CryptographicException">Thrown if <paramref name="condition"/> is not satisfied.</exception>
        /// <remarks>
        /// This isn't a typical Debug.Assert; the check is always performed, even in retail builds.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AssertCondition(bool condition, string message)
        {
            if (!condition)
            {
                Fail(message);
            }
        }

        /// <summary>
        /// Asserts that the operation returned successfully.
        /// </summary>
        /// <exception cref="CryptographicException">Thrown if <paramref name="success"/> is false.</exception>
        /// <remarks>
        /// This isn't a typical Debug.Assert; the check is always performed, even in retail builds.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AssertSuccess(bool success, string apiName)
        {
            if (!success)
            {
                int errorCode = Marshal.GetLastWin32Error();
                if (errorCode != 0)
                {
                    throw new CryptographicException(errorCode);
                }
                else
                {
                    throw new CryptographicException($"Function {apiName} returned failure. No error code provided.");
                }
            }
        }

        /// <summary>
        /// Asserts that the provided <see cref="SafeHandle"/> is valid.
        /// </summary>
        /// <exception cref="CryptographicException">Thrown if <paramref name="safeHandle"/> is invalid.</exception>
        /// <remarks>
        /// This isn't a typical Debug.Assert; the check is always performed, even in retail builds.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AssertSafeHandleIsValid<T>(T safeHandle) where T : SafeHandle
        {
            if (safeHandle == null || safeHandle.IsInvalid)
            {
                int errorCode = Marshal.GetLastWin32Error();
                if (errorCode != 0)
                {
                    throw new CryptographicException(errorCode);
                }
                else
                {
                    throw new CryptographicException($"Function did not return a valid {typeof(T).Name}. No error code provided.");
                }
            }
        }

        /// <summary>
        /// Throws a <see cref="CryptographicException"/> with the provided fail message.
        /// </summary>
        /// <remarks>
        /// This isn't a typical Debug.Fail; the check is always performed, even in retail builds.
        /// This method doesn't actually return (return type O), but it's typed to return Exception
        /// so that callers can write 'throw Fail' in order to pass verification.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Exception Fail(string message)
        {
            throw new CryptographicException($"Assertion failed: {message}");
        }
    }

    [Flags]
    internal enum MessageEncodingType : uint
    {
        X509_ASN_ENCODING = 0x00000001,
        PKCS_7_ASN_ENCODING = 0x00010000,
    }

    // from wincrypt.h
    internal enum MessageType : uint
    {
        CMSG_DATA = 1,
        CMSG_SIGNED = 2,
        CMSG_ENVELOPED = 3,
        CMSG_SIGNED_AND_ENVELOPED = 4,
        CMSG_HASHED = 5,
        CMSG_ENCRYPTED = 6,
    }

    // from wincrypt.h
    // https://msdn.microsoft.com/en-us/library/windows/desktop/aa377807(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    internal struct CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA
    {
        internal uint cbSize;
        internal uint dwSignerIndex;
        internal DATA_BLOB BLOB;
    }

    // from wincrypt.h
    // https://msdn.microsoft.com/en-us/library/windows/desktop/dd433837(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    internal struct CRYPT_TIMESTAMP_CONTEXT
    {
        internal uint cbEncoded;
        internal IntPtr pbEncoded;
        internal IntPtr pTimeStamp;
    }

    // from wincrypt.h
    // https://msdn.microsoft.com/en-us/library/windows/desktop/aa381414(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    internal struct DATA_BLOB
    {
        internal uint cbData;
        internal IntPtr pbData;
    }

    // from wincrypt.h
    // https://msdn.microsoft.com/en-us/library/windows/desktop/aa381146(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct CRYPT_ATTRIBUTES
    {
        internal uint cAttr;
        internal CRYPT_ATTRIBUTE* rgAttr;
    }

    // from wincrypt.h
    // https://msdn.microsoft.com/en-us/library/windows/desktop/aa381139(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct CRYPT_ATTRIBUTE
    {
        internal IntPtr pszObjId;
        internal uint cValue;
        internal DATA_BLOB* rgValue;
    }

    // from wincrypt.h
    // https://msdn.microsoft.com/en-us/library/windows/desktop/aa377812(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    internal struct CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA
    {
        internal uint cbSize;
        internal uint dwSignerIndex;
        internal uint dwUnauthAttrIndex;
    }
}

