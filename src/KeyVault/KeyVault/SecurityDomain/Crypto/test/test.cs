using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Crypto.Test
{
    class test
    {
		static void single_byte_test(byte shares, UInt16 required)
		{
			for (UInt16 i = 0; i < (UInt16)0x100; ++i)
			{
				shared_secret secret = new shared_secret(shares, required);

				UInt16[] share_array = secret.make_shares((byte)i);
				UInt16 result = secret.get_secret(share_array);

				if (i != result)
				{
					throw new Exception("single_byte_test failed");
				}
			}
		}

		static void random_single_byte_test()
		{
			byte shares = 126;
			UInt16 required = 16;

			for (UInt32 i = 0; i < 100000; ++i)
			{
				// just use i % 256 as the secret
				byte secret_value = (byte)(i % 256);
				shared_secret secret = new shared_secret(shares, required);
				UInt16[] share_array = secret.make_shares(secret_value);

				// Put them into a List so that we can pick them out
				List<UInt16> tmp_array = new List<UInt16>();

				foreach(UInt16 u in share_array)
                {
					tmp_array.Add(u);
                }

				// Now need to randomly pick values
				UInt16[] random_shares = new UInt16[required];

				random_bits bits = new random_bits(required);

				for (UInt32 j = 0; j < required; ++j)
				{
					// Yes, I really only need a byte, but this is test code
					UInt16 r = bits.get_word();
					Int32 pos = (Int32)(r % tmp_array.Count);

					random_shares[j] = tmp_array[pos];
					tmp_array.RemoveAt(pos);
				}

				UInt16 result = secret.get_secret(random_shares);

				if (result != secret_value)
				{
					throw new Exception("random_single_byte_test failed");
				}
			}

			Console.WriteLine("random_single_byte_test - success");
		}

		static void test_all_shares()
		{
			for (UInt16 i = 2; i < 127; ++i)
			{
				// It will work for larger numbers of required, but
				// it takes a while. Can do some targeted tests for large
				// share count
				UInt16 max_required = 16;
				for (UInt16 j = i > max_required ? max_required : i; j > 1; --j)
				{
					byte shares = (byte)(i);
					byte required = (byte)(j);

					single_byte_test(shares, required);
				}
			}

			Console.WriteLine("test_all_shares - success");
		}

		static void test_126_shares()
		{
			UInt16 i = 126;

			Console.WriteLine("Running 126 share test");

			for (UInt16 j = i; j > 1; --j)
			{
				byte shares = (byte)(i);
				byte required = (byte)(j);

				single_byte_test(shares, required);
			}

			Console.WriteLine("test_126_shares - success");
		}

		static bool check_result(byte[] a, byte[] b)
        {
			// Not for cryptographic purposes
			// assumes equal lengths
			for(Int32 i = 0; i < a.Length; ++i)
            {
				if (a[i] != b[i])
					return false;
            }
			return true;
        }

		static void test_large_secret()
		{
			for (UInt32 i = 0; i < 1000000; ++i)
			{
				shared_secret ss = new shared_secret(11, 5);

				byte[] secret = new byte[32];

				using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
				{
					rng.GetBytes(secret);
				}

				List<UInt16[]> share_arrays = ss.make_shares(secret);
				byte[] plaintext = ss.get_secret(share_arrays);

				if ( !check_result(plaintext, secret) )
				{
					throw new Exception("test_large_secret failed");
				}

				if ((i + 1) % 100000 == 0)
				{
					Console.WriteLine("{0} iterations", i + 1);
				}
			}

			Console.WriteLine("test_large_secret - success");
		}

		static public void run_all_tests()
		{
			Console.WriteLine("Running single-byte tests");
			Console.WriteLine("Testing 2-126 shares, 2-16 required");
			test_126_shares();

			Console.WriteLine("\nTesting 126 shares, 2-126 required");
			test_all_shares();

			Console.WriteLine("\nTesting random shares");
			random_single_byte_test();

			Console.WriteLine("\nRunning 32 byte secret tests");
			test_large_secret();
		}
	}
}
