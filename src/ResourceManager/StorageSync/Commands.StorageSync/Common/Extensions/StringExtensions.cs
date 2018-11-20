// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    /// <summary>
    /// String Extensions class
    /// </summary>
    public static class StringExtensions
    {
 
        /// <summary>
        /// This function will transform an string to uri object.
        /// </summary>
        /// <param name="uriString">Uri String</param>
        /// <param name="uriKind">Uri kind</param>
        /// <param name="throwException">Throw Exception</param>
        /// <returns>Uri object</returns>
        public static Uri ToUri(this string uriString, UriKind uriKind = UriKind.RelativeOrAbsolute, bool throwException = true)
        {
            try
            {
                return new Uri(uriString, uriKind);
            }
            catch (Exception)
            {
                if (throwException)
                {
                    throw;
                }
            }
            return default(Uri);
        }

        /// <summary>
        /// This function will convert a string to server certificate.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public static byte[] ToBase64Bytes(this string source, bool throwException = true)
        {
            try
            {
                return Convert.FromBase64String(source);
            }
            catch (FormatException)
            {
                 if (throwException)
                {
                    throw;
                }
            }

            return default(byte[]);
        }

    }
}
