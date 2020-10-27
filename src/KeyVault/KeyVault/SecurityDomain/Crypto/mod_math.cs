using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Crypto
{
    class mod_math
    {
        public static UInt32 mod_invert(UInt32 x)
        {
            UInt32 ret = x;

            for (UInt32 i = 0; i < 7; ++i)
            {
                ret = mod_multiply(ret, ret);
                ret = mod_multiply(ret, x);
            }

            return ret;
        }

        public static UInt32 mod_reduce(UInt32 x)
        {
            // Function to find x % 257 without side channels
            UInt32 t = (x & 0xff) - (x >> 8);
            t += (UInt32)((Int32)t >> 31) & 257;
            return t;
        }

        // Assumes a, b are within 0-256
        public static UInt32 mod_multiply(UInt32 a, UInt32 b)
        {
            return mod_reduce(a * b);
        }

        public static UInt32 mod_add(UInt32 a, UInt32 b)
        {
            return mod_reduce(a + b);
        }

        public static UInt32 mod_subtract(UInt32 a, UInt32 b)
        {
            // Must ensure that the difference is in the range of 0-256
            return mod_reduce(a - b + 257);
        }
    }

    class random_bits
    {
        public UInt16 get_mod_257()
        {
            UInt16 tmp = 0;
            do
            {
                tmp = get_word();

                if (tmp != 0)
                    return (UInt16)mod_math.mod_reduce(tmp);

            } while (tmp == 0);

            // Not actually reached
            return 0;
        }

        public UInt16 get_word()
        {
            Int32 remaining = random_bytes.Length - (Int32)current;

            if (remaining < 2)
                load();

            UInt16 ret = (UInt16)((random_bytes[current+1] << 8) | random_bytes[current]);
            current += 2;
            return ret;
        }

        void load()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                current = 0;
                rng.GetBytes(random_bytes);
            }
        }

        public random_bits(UInt32 _chunk_size)
        {
            chunk_size = _chunk_size;
            current = 0;
            random_bytes = new byte[chunk_size];
            load();
        }

        UInt32 chunk_size;
        UInt32 current;
        byte[] random_bytes;
    }

    struct share
    {
        public share(UInt16 w)
        {
            x = (UInt16)(w >> 9);
            value = (UInt16)(w & 0x1ff);
        }

        public share(UInt16 _x, UInt16 _value)
        {
            x = _x;
            value = _value;
        }

        public UInt16 to_uint16()
        {
            return (UInt16)(x << 9 | value);
        }

        public UInt16 x;
        public UInt16 value;
    }
    class shared_math
    {
        public static UInt16 get_secret(UInt16[] shares, UInt32 size)
        {
            UInt32 secret = 0;

            // Calculate numerator
            for (UInt32 i = 0; i<size; ++i)
            {
                UInt32 numerator = 1;
                UInt32 denominator = 1;
                share si = new share(shares[i]);

                for (UInt32 j = 0; j<size; ++j)
                {
                    if (i == j)
                        continue;

                    share sj = new share(shares[j]);
                    numerator = mod_math.mod_multiply(numerator, sj.x);
                    UInt32 diff = mod_math.mod_subtract(sj.x, si.x);
                    denominator = mod_math.mod_multiply(diff, denominator);
                }

                UInt32 invert = mod_math.mod_invert(denominator);
                UInt32 ci = mod_math.mod_multiply(numerator, invert);
                UInt32 tmp = mod_math.mod_multiply(ci, si.value);
                secret = mod_math.mod_add(secret, tmp);
            }

            return (UInt16)(secret);
        }

        static public UInt16 make_share(UInt16[] coefficients, UInt16 x)
        {
	        /*
		        When you evaluate
			           a*x^3 + b*x^2 + c*x + d
		        you compute
			           ((a*x + b)*x + c)*x + d
		        Also known as Horner’s rule.
	        */

	        if (coefficients.Length < 2)
	        {
		        throw new Exception("Invalid input");
	        }

            UInt32 tmp = 0;
            tmp = mod_math.mod_multiply(coefficients[0], x );
            tmp = mod_math.mod_add(tmp, coefficients[1] );

	        for (UInt32 i = 2; i < coefficients.Length; ++i)
	        {
		        tmp = mod_math.mod_multiply(tmp, x );
                tmp = mod_math.mod_add(tmp, coefficients[i] );
            }

	        return (UInt16)(tmp );
        }
    }
}
