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
using System.Security;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Represents Sql Authentication credentials.
    /// </summary>
    public class SqlAuthenticationCredentials 
    {
        private string userName;
        private SecureString password;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlAuthenticationCredentials" /> class.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The encrypted password.</param>
        public SqlAuthenticationCredentials(string userName, SecureString password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("userName");
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            this.userName = userName;
            this.password = password.Copy();
            this.password.MakeReadOnly();
        }

        /// <summary>
        /// Gets the credential user name.
        /// </summary>
        public virtual string UserName
        {
            get { return this.userName; }
        }

        /// <summary>
        /// Gets the credential password in secure encrypted form.
        /// </summary>
        public virtual SecureString EncryptedPassword
        {
            get { return this.password; }
        }

        /// <summary>
        /// Gets the credential password in plain text.
        /// </summary>
        public virtual string Password
        {
            get
            {
                // This only works from the same logon and process context as when it was made, 
                // since it uses DPAPI to encode.
                return Decrypt(this.password);
            }
        }

        /// <summary>
        /// Convert a <see cref="System.Security.SecureString"/> to a plain-text string representation.
        /// This should only be used in a proetected context, and must be done in the same logon and process context
        /// in which the <see cref="System.Security.SecureString"/> was constructed.
        /// </summary>
        /// <param name="secureString">The encrypted <see cref="System.Security.SecureString"/>.</param>
        /// <returns>The plain-text string representation.</returns>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static string Decrypt(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
