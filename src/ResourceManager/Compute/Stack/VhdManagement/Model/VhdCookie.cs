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
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class VhdCookie
    {
        static readonly byte[] FooterCookie = Encoding.ASCII.GetBytes("conectix");
        static readonly byte[] HeaderCookie = Encoding.ASCII.GetBytes("cxsparse");

        private readonly VhdCookieType cookieType;
        private readonly byte[] expectedData;

        public static VhdCookie CreateFooterCookie()
        {
            return new VhdCookie(VhdCookieType.Footer, FooterCookie);
        }

        public static VhdCookie CreateHeaderCookie()
        {
            return new VhdCookie(VhdCookieType.Header, HeaderCookie);
        }

        public VhdCookie(VhdCookieType cookieType, byte[] data)
        {
            this.cookieType = cookieType;
            this.Data = data;
            this.expectedData = GetExpectedCookie();
        }

        public byte[] Data { get; private set; }

        public string StringData
        {
            get { return Encoding.ASCII.GetString(this.Data); }
        }

        public bool IsValid()
        {
            if (Data.Length != expectedData.Length)
            {
                return false;
            }
            return !expectedData.Where((t, i) => Data[i] != t).Any();
        }

        private byte[] GetExpectedCookie()
        {
            return cookieType == VhdCookieType.Header ? HeaderCookie : FooterCookie;
        }

        public VhdCookie CreateCopy()
        {
            var copy = new byte[Data.Length];
            Array.Copy(Data, copy, Data.Length);
            return new VhdCookie(this.cookieType, copy);
        }

        public override string ToString()
        {
            return StringData;
        }
    }
}