using System;

namespace Blockcore.NBitcoin.BouncyCastle.asn1
{
    /**
     * A Null object.
     */
    internal class DerNull
        : Asn1Null
    {
        public static readonly DerNull Instance = new DerNull(0);

        private byte[] zeroBytes = new byte[0];

        [Obsolete("Use static Instance object")]
        public DerNull()
        {
        }

        protected internal DerNull(int dummy)
        {
        }

        internal override void Encode(
            DerOutputStream derOut)
        {
            derOut.WriteEncoded(Asn1Tags.Null, this.zeroBytes);
        }

        protected override bool Asn1Equals(
            Asn1Object asn1Object)
        {
            return asn1Object is DerNull;
        }

        protected override int Asn1GetHashCode()
        {
            return -1;
        }
    }
}
