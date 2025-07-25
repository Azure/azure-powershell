using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Crypto
{
    public class shared_secret
	{
		public shared_secret(UInt16 shares, UInt16 required)
        {
			if (shares > max_shares || required > shares || required < 2)
				throw new Exception("Incorrect share or required count");

			_shares = shares;
			_required = required;
			_coefficients = new UInt16[required];
			_rand_bits = new random_bits(64);

		}

		public shared_secret(UInt16 required)
		{
			if (required < 2)
				throw new Exception("Incorrect share or required count");

			_shares = 0;
			_required = required;
			_rand_bits = new random_bits(64);
		}

		public List<UInt16[]> make_shares(byte[] plaintext)
		{
			// Output will have size of share count, each share vector will have an entry for every input byte
			List<UInt16[]> share_arrays = new List<UInt16[]>();

			for( UInt32 i = 0; i < plaintext.Length; ++i)
			{
				byte p = plaintext[i];
				UInt16[] share_array = make_shares(p);

				/*
				We now have a share created for the total number of shares needed
				Each share then needs to be distributed such that there's a share 
				for each byte of plaintext, effectively transposing the 2-dimensional 
				array.
				*/
				Int32 share_count = share_array.Length;

				for (Int32 j = 0; j < share_count; ++j)
				{
					if (i == 0)
						share_arrays.Add(new UInt16[plaintext.Length]);

					UInt16[] current_share_array = share_arrays[j];
					current_share_array[i] = share_array[j];
				}
			}

			return share_arrays;
		}

		public UInt16[] make_shares(byte secret_byte)
		{
			UInt16[] share_array = new UInt16[_shares];

			init_coefficients();
			_coefficients[(UInt32)(_required) - 1] = secret_byte;

			UInt16 x = 1;
			for (UInt32 i = 0; i < _shares; ++i, ++x)
			{
				share s = new share(x, shared_math.make_share(_coefficients, x));
				share_array[i] = s.to_uint16();
			}

			return share_array;
		}

		public byte[] get_secret(List<UInt16[]> share_arrays)
		{
			byte[] plaintext = new byte[share_arrays[0].Length];

			if (share_arrays.Count < _required)
			{
				throw new Exception("Insufficient shares");
			}

			UInt16[] sv = new UInt16[_required];
	
			// TODO - all the constants calculated in get_secret
			// can be pulled out once and re-used, which will help perf
			for (UInt32 j = 0; j < plaintext.Length; ++j)
			{
				for (Int32 i = 0; i< _required; ++i)
				{
					UInt16[] sa = share_arrays[i];
					sv[i] =  sa[j];
				}

				UInt16 text = get_secret(sv);
				plaintext[j] = (byte)(text);
			}

			return plaintext;
		}

		public UInt16 get_secret(UInt16[] share_array)
        {
			if (share_array.Length < _required)
				throw new Exception("Insufficient shares");

			return shared_math.get_secret(share_array, _required);
		}

		void init_coefficients()
		{
			for (UInt32 i = 0; i < (UInt32)(_required) - 1; ++i)
			{
				_coefficients[i] = _rand_bits.get_mod_257();
			}
		}

		UInt16 _shares;
		UInt16 _required;
		UInt16[] _coefficients;
		random_bits _rand_bits;

		const UInt32 max_shares = 126;
	}
}
