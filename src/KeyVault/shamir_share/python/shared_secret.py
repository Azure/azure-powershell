import array
from mod_math import *

max_shares = 126

class make_shared_secret:
    def __init__(self, shares, required):
        if shares > max_shares or required > shares or required < 2:
            raise Exception("Incorrect share or required count")

        self.shares = shares
        self.required = required
        self.byte_shares = make_byte_shares( required, 0)

    def make_byte_shares(self, b):
        share_array = []
        self.byte_shares.set_secret_byte(b)

        x = 1
        for i in range(self.shares):
            s = self.byte_shares.make_share(x)
            share_array.append(s.to_uint16())
            x = x + 1

        return share_array

    def make_shares(self, plaintext):
        share_arrays = []

        for i in range( len(plaintext) ):
            p = plaintext[i]
            share_array = self.make_byte_shares(p)

            share_count = len(share_array)

            for j in range(share_count):
                if i == 0:
                    tmp = array.array('H')
                    share_arrays.append(tmp)

                current_share_array = share_arrays[j]
                current_share_array.append(share_array[j])

        return share_arrays

class get_secret:
    def __init__(self, required):
        self.required = required
        self.gbs = get_byte_secret()

    def get_secret_byte(self, share_array):
        if len(share_array) < self.required:
            raise Exception("Insufficient shares")

        return self.gbs.get_secret(share_array, self.required)

    def get_plaintext(self, share_arrays):
        plaintext = bytearray()
        plaintext_len = len(share_arrays[0])

        if len(share_arrays) < self.required:
            raise Exception("Insufficient shares")

        for j in range(plaintext_len):
            sv = array.array('H')

            for i in range(self.required):
                sa = share_arrays[i]
                sv.append(sa[j])

            text = self.get_secret_byte(sv)
            plaintext.append(text)

        return plaintext



    
