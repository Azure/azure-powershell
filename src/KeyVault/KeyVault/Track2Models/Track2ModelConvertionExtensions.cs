using System;
using System.Collections.Generic;
using System.Text;
using Track2Sdk = Azure.Security.KeyVault.Keys;
using Track1Sdk = Microsoft.Azure.KeyVault.WebKey;
using System.Security.Cryptography;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal static class Track2ModelConvertionExtensions
    {
        /// <summary>
        /// Converts a track 2 JsonWebKey object to track 1 type
        /// </summary>
        /// <param name="track2Key">track 2 key</param>
        /// <returns>equivalent track 1 key</returns>
        public static Track1Sdk.JsonWebKey ToTrack1JsonWebKey(this Track2Sdk.JsonWebKey track2Key)
        {
            Track1Sdk.JsonWebKey track1Key;

            // convert key specific properties
            if (track2Key.KeyType == Track2Sdk.KeyType.Ec || track2Key.KeyType == Track2Sdk.KeyType.EcHsm)
            {
                track1Key = new Track1Sdk.JsonWebKey(new Track1Sdk.ECParameters()
                {
                    Curve = track2Key.CurveName.ToString(),
                    X = track2Key.X,
                    Y = track2Key.Y,
                    D = track2Key.D
                });
            }
            else if (track2Key.KeyType == Track2Sdk.KeyType.Rsa || track2Key.KeyType == Track2Sdk.KeyType.RsaHsm)
            {
                track1Key = new Track1Sdk.JsonWebKey(track2Key.ToRSA());
            }
            // SDK doesn't have a definition of OctHSM, so I need to use string comparison
            else if (track2Key.KeyType == Track2Sdk.KeyType.Oct || track2Key.KeyType.ToString() == @"oct-HSM")
            {
                track1Key = new Track1Sdk.JsonWebKey();
                track1Key.Kty = track2Key.KeyType.ToString();
            }
            else
            {
                throw new Exception("Not supported");
            }

            // metadata
            track1Key.KeyOps = new List<string>();
            foreach (var op in track2Key.KeyOps)
            {
                track1Key.KeyOps.Add(op.ToString());
            }
            track1Key.Kid = track2Key.Id;

            return track1Key;
        }
    }
}
