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
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Sync.Download
{
    public class BlobUri
    {
        public static bool TryParseUri(Uri uri, out BlobUri blobUri)
        {
            blobUri = null;
            string storageAccountName;
            string storageDomainName;
            string blobContainerName;
            string blobName;
            string queryString;
            string secret;

            var result = TryParseUri(uri,
                                     out storageAccountName,
                                     out storageDomainName,
                                     out blobContainerName,
                                     out blobName,
                                     out queryString,
                                     out secret);

            if (!result)
            {
                return false;
            }
            blobUri = new BlobUri(uri, storageAccountName, storageDomainName, blobContainerName, blobName, queryString);
            return true;
        }

        internal static bool TryParseUri(Uri blobUri,
                                         out string storageAccountName,
                                         out string storageDomainName,
                                         out string blobContainerName,
                                         out string blobName,
                                         out string queryString,
                                         out string secret)
        {
            storageAccountName = null;
            storageDomainName = null;
            blobContainerName = null;
            blobName = null;
            secret = null;
            queryString = null;

            string[] hostSegments = blobUri.DnsSafeHost.ToLower().Split('.');

            if (hostSegments.Length < 2)
            {
                return false;
            }

            storageAccountName = hostSegments[0];
            storageDomainName = string.Join(".", hostSegments, 1, hostSegments.Length - 1);

            blobContainerName = null;
            blobName = null;

            string[] segments = blobUri.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length < 2)
            {
                return false; //Must have atleast a containerName and BlobName
            }

            blobName = HttpUtility.UrlDecode(
                string.Join(
                    "/", segments, 1, segments.Length - 1));
            blobContainerName = HttpUtility.UrlDecode(segments[0]);

            NameValueCollection queryValues = HttpUtility.ParseQueryString(blobUri.Query);

            StringBuilder queryBuilder = new StringBuilder();
            bool firstQuery = true;

            foreach (string key in queryValues.AllKeys)
            {
                if (string.Equals(key, "dsas_secret", StringComparison.OrdinalIgnoreCase))
                {
                    secret = queryValues["dsas_secret"];
                }
                else
                {
                    if (firstQuery)
                    {
                        queryBuilder.AppendFormat("?{0}={1}", key.Replace("?", ""), queryValues[key]);
                        firstQuery = false;
                    }
                    else
                    {
                        queryBuilder.AppendFormat("&{0}={1}", key, queryValues[key]);
                    }
                }
            }

            if (!string.IsNullOrEmpty(secret))
            {
                //TODO[JWA], Find out the complete set of decoding;
                secret = secret.Replace(' ', '+');
            }

            queryString = queryBuilder.ToString();
            return true;
        }

        public Uri Uri { get; private set; }
        public string BaseUri { get; private set; }
        public string StorageAccountName { get; private set; }
        public string StorageDomainName { get; private set; }
        public string BlobContainerName { get; private set; }
        public string BlobName { get; private set; }
        public string QueryString { get; set; }
        public string BlobPath { get; private set; }

        public BlobUri(Uri uri, string storageAccountName, string storageDomainName, string blobContainerName, string blobName, string queryString)
        {
            Uri = uri;
            StorageAccountName = storageAccountName;
            StorageDomainName = storageDomainName;
            BlobContainerName = blobContainerName;
            BlobName = blobName;
            QueryString = queryString;
            BaseUri = uri.Scheme + Uri.SchemeDelimiter + uri.DnsSafeHost;
            BlobPath = this.BaseUri + uri.LocalPath;
        }

    }

    #region HttpUtility port from .Net 4.0

    class HttpUtility
    {
        public static string UrlDecode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecode(str, Encoding.UTF8);
        }

        public static string UrlDecode(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecodeStringFromStringInternal(str, e);
        }

        private static string UrlDecodeStringFromStringInternal(string s, Encoding e)
        {
            int length = s.Length;
            UrlDecoder decoder = new UrlDecoder(length, e);
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                if (ch == '+')
                {
                    ch = ' ';
                }
                else if ((ch == '%') && (i < (length - 2)))
                {
                    if ((s[i + 1] == 'u') && (i < (length - 5)))
                    {
                        int num3 = HexToInt(s[i + 2]);
                        int num4 = HexToInt(s[i + 3]);
                        int num5 = HexToInt(s[i + 4]);
                        int num6 = HexToInt(s[i + 5]);
                        if (((num3 < 0) || (num4 < 0)) || ((num5 < 0) || (num6 < 0)))
                        {
                            goto Label_0106;
                        }
                        ch = (char)((((num3 << 12) | (num4 << 8)) | (num5 << 4)) | num6);
                        i += 5;
                        decoder.AddChar(ch);
                        continue;
                    }
                    int num7 = HexToInt(s[i + 1]);
                    int num8 = HexToInt(s[i + 2]);
                    if ((num7 >= 0) && (num8 >= 0))
                    {
                        byte b = (byte)((num7 << 4) | num8);
                        i += 2;
                        decoder.AddByte(b);
                        continue;
                    }
                }
                Label_0106:
                if ((ch & 0xff80) == 0)
                {
                    decoder.AddByte((byte)ch);
                }
                else
                {
                    decoder.AddChar(ch);
                }
            }
            return decoder.GetString();
        }

        private static int HexToInt(char h)
        {
            if ((h >= '0') && (h <= '9'))
            {
                return (h - '0');
            }
            if ((h >= 'a') && (h <= 'f'))
            {
                return ((h - 'a') + 10);
            }
            if ((h >= 'A') && (h <= 'F'))
            {
                return ((h - 'A') + 10);
            }
            return -1;
        }

        public static string UrlEncodeUnicode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlEncodeUnicodeStringToStringInternal(str, false);
        }

        private static string UrlEncodeUnicodeStringToStringInternal(string s, bool ignoreAscii)
        {
            int length = s.Length;
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                if ((ch & 0xff80) == 0)
                {
                    if (ignoreAscii || IsSafe(ch))
                    {
                        builder.Append(ch);
                    }
                    else if (ch == ' ')
                    {
                        builder.Append('+');
                    }
                    else
                    {
                        builder.Append('%');
                        builder.Append(IntToHex((ch >> 4) & '\x000f'));
                        builder.Append(IntToHex(ch & '\x000f'));
                    }
                }
                else
                {
                    builder.Append("%u");
                    builder.Append(IntToHex((ch >> 12) & '\x000f'));
                    builder.Append(IntToHex((ch >> 8) & '\x000f'));
                    builder.Append(IntToHex((ch >> 4) & '\x000f'));
                    builder.Append(IntToHex(ch & '\x000f'));
                }
            }
            return builder.ToString();
        }

        internal static bool IsSafe(char ch)
        {
            if ((((ch >= 'a') && (ch <= 'z')) || ((ch >= 'A') && (ch <= 'Z'))) || ((ch >= '0') && (ch <= '9')))
            {
                return true;
            }
            switch (ch)
            {
                case '\'':
                case '(':
                case ')':
                case '*':
                case '-':
                case '.':
                case '_':
                case '!':
                    return true;
            }
            return false;
        }

        internal static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char)(n + 0x30);
            }
            return (char)((n - 10) + 0x61);
        }

        public static NameValueCollection ParseQueryString(string query)
        {
            return ParseQueryString(query, Encoding.UTF8);
        }

        public static NameValueCollection ParseQueryString(string query, Encoding encoding)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            if ((query.Length > 0) && (query[0] == '?'))
            {
                query = query.Substring(1);
            }
            return new HttpValueCollection(query, false, true, encoding);
        }

        private class UrlDecoder
        {
            // Fields
            private int _bufferSize;
            private byte[] _byteBuffer;
            private char[] _charBuffer;
            private Encoding _encoding;
            private int _numBytes;
            private int _numChars;

            // Methods
            internal UrlDecoder(int bufferSize, Encoding encoding)
            {
                this._bufferSize = bufferSize;
                this._encoding = encoding;
                this._charBuffer = new char[bufferSize];
            }

            internal void AddByte(byte b)
            {
                if (this._byteBuffer == null)
                {
                    this._byteBuffer = new byte[this._bufferSize];
                }
                this._byteBuffer[this._numBytes++] = b;
            }

            internal void AddChar(char ch)
            {
                if (this._numBytes > 0)
                {
                    this.FlushBytes();
                }
                this._charBuffer[this._numChars++] = ch;
            }

            private void FlushBytes()
            {
                if (this._numBytes > 0)
                {
                    this._numChars += this._encoding.GetChars(this._byteBuffer, 0, this._numBytes, this._charBuffer, this._numChars);
                    this._numBytes = 0;
                }
            }

            internal string GetString()
            {
                if (this._numBytes > 0)
                {
                    this.FlushBytes();
                }
                if (this._numChars > 0)
                {
                    return new string(this._charBuffer, 0, this._numChars);
                }
                return string.Empty;
            }
        }

    }

    [Serializable]
    internal class HttpValueCollection : NameValueCollection
    {
        // Methods
        internal HttpValueCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        internal HttpValueCollection(int capacity)
            : base(capacity, (IEqualityComparer)StringComparer.OrdinalIgnoreCase)
        {
        }

        protected HttpValueCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        internal HttpValueCollection(string str, bool readOnly, bool urlencoded, Encoding encoding)
            : base(StringComparer.OrdinalIgnoreCase)
        {
            if (!string.IsNullOrEmpty(str))
            {
                this.FillFromString(str, urlencoded, encoding);
            }
            base.IsReadOnly = readOnly;
        }


        internal void FillFromString(string s)
        {
            this.FillFromString(s, false, null);
        }

        internal void FillFromString(string s, bool urlencoded, Encoding encoding)
        {
            int num = (s != null) ? s.Length : 0;
            for (int i = 0; i < num; i++)
            {
                int startIndex = i;
                int num4 = -1;
                while (i < num)
                {
                    char ch = s[i];
                    if (ch == '=')
                    {
                        if (num4 < 0)
                        {
                            num4 = i;
                        }
                    }
                    else if (ch == '&')
                    {
                        break;
                    }
                    i++;
                }
                string str = null;
                string str2 = null;
                if (num4 >= 0)
                {
                    str = s.Substring(startIndex, num4 - startIndex);
                    str2 = s.Substring(num4 + 1, (i - num4) - 1);
                }
                else
                {
                    str2 = s.Substring(startIndex, i - startIndex);
                }
                if (urlencoded)
                {
                    base.Add(HttpUtility.UrlDecode(str, encoding), HttpUtility.UrlDecode(str2, encoding));
                }
                else
                {
                    base.Add(str, str2);
                }
                if ((i == (num - 1)) && (s[i] == '&'))
                {
                    base.Add(null, string.Empty);
                }
            }
        }

        internal void MakeReadOnly()
        {
            base.IsReadOnly = true;
        }

        internal void MakeReadWrite()
        {
            base.IsReadOnly = false;
        }

        internal void Reset()
        {
            base.Clear();
        }

        public override string ToString()
        {
            return this.ToString(true);
        }

        internal virtual string ToString(bool urlencoded)
        {
            return this.ToString(urlencoded, null);
        }

        internal virtual string ToString(bool urlencoded, IDictionary excludeKeys)
        {
            int count = this.Count;
            if (count == 0)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            bool flag = (excludeKeys != null) && (excludeKeys["__VIEWSTATE"] != null);
            for (int i = 0; i < count; i++)
            {
                string key = this.GetKey(i);
                if (((!flag || (key == null)) || !key.StartsWith("__VIEWSTATE", StringComparison.Ordinal)) && (((excludeKeys == null) || (key == null)) || (excludeKeys[key] == null)))
                {
                    string str3;
                    if (urlencoded)
                    {
                        key = HttpUtility.UrlEncodeUnicode(key);
                    }
                    string str2 = !string.IsNullOrEmpty(key) ? (key + "=") : string.Empty;
                    ArrayList list = (ArrayList)base.BaseGet(i);
                    int num3 = (list != null) ? list.Count : 0;
                    if (builder.Length > 0)
                    {
                        builder.Append('&');
                    }
                    if (num3 == 1)
                    {
                        builder.Append(str2);
                        str3 = (string)list[0];
                        if (urlencoded)
                        {
                            str3 = HttpUtility.UrlEncodeUnicode(str3);
                        }
                        builder.Append(str3);
                    }
                    else if (num3 == 0)
                    {
                        builder.Append(str2);
                    }
                    else
                    {
                        for (int j = 0; j < num3; j++)
                        {
                            if (j > 0)
                            {
                                builder.Append('&');
                            }
                            builder.Append(str2);
                            str3 = (string)list[j];
                            if (urlencoded)
                            {
                                str3 = HttpUtility.UrlEncodeUnicode(str3);
                            }
                            builder.Append(str3);
                        }
                    }
                }
            }
            return builder.ToString();
        }
    }
    #endregion

}