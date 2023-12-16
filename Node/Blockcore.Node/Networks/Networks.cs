using Blockcore.Networks;

namespace SealinkNetwork.Networks
{
   public static class Networks
   {
      public static NetworksSelector SealinkNetwork
      {
         get
         {
            return new NetworksSelector(() => new SealinkNetworkMain(), () => new SealinkNetworkTest(), () => new SealinkNetworkRegTest());
         }
      }
   }
}
