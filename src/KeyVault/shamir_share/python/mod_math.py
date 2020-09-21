import secrets
import array

class mod_math:

    def mod_reduce(self, x):
        t = (x & 0xff) - (x >> 8)
        t += (t >> 31) & 257
        return t

    def mod_multiply(self, x, y):
        return self.mod_reduce( x * y )

    def mod_invert(self, x):
        ret = x
        for i in range(7):
            ret = self.mod_multiply(ret, ret)
            ret = self.mod_multiply(ret, x)

        return ret

    def mod_add(self, x, y):
        return self.mod_reduce( x + y)

    def mod_subtract(self, x, y):
        return self.mod_reduce( x - y + 257 )

    def get_random(self):
        r = secrets.randbits(16)
        return self.mod_reduce(r)

class share:
    def __init__(self, x, v):
        self.x = x
        self.v = v

    def from_uint16(self, w):
        self.x = w >> 9
        self.v = w & 0x1ff
        return self

    def to_uint16(self):
        return ((self.x << 9) | self.v)

class mod_math_internal:
    def share_from_uint16(self, w):
        x = w >> 9
        v = w & 0x1ff
        return share(x, v)

class make_byte_shares:
    def __init__(self, required, secret_byte):
        self.mm = mod_math()
        self.coefficients = self.init_coefficients(required, secret_byte)

    def init_coefficients(self, required, secret_byte):
        coefficients = array.array('H')

        for i in range(required - 1):
            coefficients.append(self.mm.get_random())

        coefficients.append( secret_byte )
        return coefficients

    def set_secret_byte(self, secret_byte):
        self.coefficients[ len(self.coefficients) - 1] = secret_byte

    def make_share(self, x):
        tmp = 0
        tmp = self.mm.mod_multiply(self.coefficients[0], x )
        tmp = self.mm.mod_add(tmp, self.coefficients[1] )

        for i in range( 2, len(self.coefficients) ):
            tmp = self.mm.mod_multiply(tmp, x)
            tmp = self.mm.mod_add(tmp, self.coefficients[i])
            i += 1

        s = share(x, tmp)
        return s

class get_byte_secret:
    def __init__(self):
        self.mm = mod_math()
        self.mmi = mod_math_internal()


    def get_secret( self, shares, required ):
        
        secret = 0
        
        for i in range( required ):
            numerator = 1
            denominator = 1
            si = self.mmi.share_from_uint16(shares[i])

            for j in range(required):
                if i == j: 
                    continue

                sj = self.mmi.share_from_uint16(shares[j])
                numerator = self.mm.mod_multiply(numerator, sj.x)
                diff = self.mm.mod_subtract(sj.x, si.x)
                denominator = self.mm.mod_multiply(diff, denominator)

            invert = self.mm.mod_invert(denominator)
            ci = self.mm.mod_multiply(numerator, invert)
            tmp = self.mm.mod_multiply(ci, si.v)
            secret = self.mm.mod_add(secret, tmp)

        return secret

