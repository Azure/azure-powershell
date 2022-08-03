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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.TestFx
{
    public class ConnectionString
    {
        private Dictionary<string, string> _keyValuePairs;
        private string _connString;
        private StringBuilder _parseErrorSb;
        private string DEFAULT_TENANTID = "72f988bf-86f1-41af-91ab-2d7cd011db47";

        public Dictionary<string, string> KeyValuePairs
        {
            get
            {
                if (_keyValuePairs == null)
                {
                    _keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }
                return _keyValuePairs;
            }
            private set
            {
                _keyValuePairs = value;
            }
        }

        public string ParseErrors
        {
            get
            {
                return _parseErrorSb.ToString();
            }

            private set
            {
                _parseErrorSb.AppendLine(value);
            }
        }

        void Init()
        {
            List<string> connectionKeyNames = new List<string>();
            connectionKeyNames = (from fi in typeof(ConnectionStringKeys).GetFields(BindingFlags.Public | BindingFlags.Static)
                                  select fi.GetRawConstantValue().ToString()).ToList<string>();
            connectionKeyNames.ForEach((li) => KeyValuePairs.Add(li, string.Empty));
        }

        public ConnectionString()
        {
            Init();
            _parseErrorSb = new StringBuilder();
        }

        public ConnectionString(string connString) : this()
        {
            _connString = connString;
            Parse(_connString); //Keyvalue pairs are normalized and is called from Parse(string) function
            NormalizeKeyValuePairs();
        }

        private void NormalizeKeyValuePairs()
        {
            string clientId, spn, password, spnSecret, userId, aadTenantId;
            KeyValuePairs.TryGetValue(ConnectionStringKeys.AADClientIdKey, out clientId);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalKey, out spn);

            KeyValuePairs.TryGetValue(ConnectionStringKeys.UserIdKey, out userId);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.PasswordKey, out password);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalSecretKey, out spnSecret);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.TenantIdKey, out aadTenantId);

            //ClientId was provided and servicePrincipal was empty, we want ServicePrincipal to be initialized
            //At some point we will deprecate ClientId keyName
            if (!string.IsNullOrEmpty(clientId) && (string.IsNullOrEmpty(spn)))
            {
                KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey] = clientId;
            }

            //Set the value of PasswordKey to ServicePrincipalSecret ONLY if userId is empty
            //If UserId is not empty, we are not sure if it's a password for inter active login or ServicePrincipal SecretKey
            if (!string.IsNullOrEmpty(password) && (string.IsNullOrEmpty(spnSecret)) && (string.IsNullOrEmpty(userId)))
            {
                KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey] = password;
            }

            //Initialize default value for AADTenent
            if (string.IsNullOrEmpty(aadTenantId))
            {
                KeyValuePairs[ConnectionStringKeys.TenantIdKey] = DEFAULT_TENANTID;
            }
        }

        public void Parse(string connString)
        {
            string parseRegEx = @"(?<KeyName>[^=]+)=(?<KeyValue>.+)";

            if (_parseErrorSb != null) _parseErrorSb.Clear();

            if (string.IsNullOrEmpty(connString))
            {
                ParseErrors = "Empty connection string";
            }
            else
            {
                string[] pairs = connString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (pairs == null) ParseErrors = string.Format("'{0}' unable to parse string", connString);

                //TODO: Shall we clear keyValue dictionary?
                //What if parsed gets called on the same instance multiple times
                //the connectionString is either malformed/invalid
                //For now clearing keyValue dictionary, we assume the caller wants to parse new connection string
                //and wants to discard old values (even if they are valid)

                KeyValuePairs.Clear(clearValuesOnly: true);
                foreach (string pair in pairs)
                {
                    Match m = Regex.Match(pair, parseRegEx);

                    if (m.Groups.Count > 2)
                    {
                        string keyName = m.Groups["KeyName"].Value;
                        string newValue = m.Groups["KeyValue"].Value;

                        if (KeyValuePairs.ContainsKey(keyName))
                        {
                            string existingValue = KeyValuePairs[keyName];
                            // Replace if the existing value do not match.
                            // We allow existing key values to be overwritten (this is especially true for endpoints)
                            if (!existingValue.Equals(newValue, StringComparison.OrdinalIgnoreCase))
                            {
                                KeyValuePairs[keyName] = newValue;
                            }
                        }
                        else
                        {
                            KeyValuePairs[keyName] = newValue;
                        }
                    }
                    else
                    {
                        ParseErrors = string.Format("Incorrect '{0}' keyValue pair format", pair);
                    }
                }

                //Adjust key-value pairs and normalize values across multiple keys
                //We need to do this here because Connection string can be parsed multiple time within same instance
                NormalizeKeyValuePairs();
            }
        }

        internal bool HasNonEmptyValue(string connStrKey)
        {
            KeyValuePairs.TryGetValue(connStrKey, out string keyValue);

            if (string.IsNullOrEmpty(keyValue))
                return false;

            return true;
        }

        internal string GetValue(string keyName)
        {
            return KeyValuePairs[keyName];
        }

        public T GetValue<T>(string keyName)
        {
            T returnValue = default;
            try
            {
                string keyValue = GetValue(keyName);
                returnValue = (T)Convert.ChangeType(keyValue, typeof(T));
            }
            catch { }

            return returnValue;
        }

        public override string ToString()
        {
            return _connString;
        }
    }
}
