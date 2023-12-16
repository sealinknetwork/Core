using System;
using System.Linq;
using System.Threading.Tasks;
using Blockcore.Builder;
using Blockcore.Configuration;
using Blockcore.Features.BlockStore;
using Blockcore.Features.ColdStaking;
using Blockcore.Features.Consensus;
using Blockcore.Features.Diagnostic;
using Blockcore.Features.MemoryPool;
using Blockcore.Features.Miner;
using Blockcore.Features.NodeHost;
using Blockcore.Features.RPC;
using Blockcore.Utilities;

namespace Blockcore.Node
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                args = new string[] {
                "-server",
                "-rpcallowip=127.0.0.1",
                "-rpcbind=127.0.0.1",
                "-rpcpassword=123456",
                "-rpcuser=sealink",
                "-enableWS=true"
                };

                var nodeSettings = new NodeSettings(networksSelector: SealinkNetwork.Networks.Networks.SealinkNetwork, args: args);

                IFullNodeBuilder nodeBuilder = new FullNodeBuilder()
                    .UseNodeSettings(nodeSettings)
                    .UseBlockStore()
                    .UsePosConsensus()
                    .UseMempool()
                    .UseColdStakingWallet()
                    .AddPowPosMining()
                    .UseNodeHost()
                    .AddRPC()
                    .UseDiagnosticFeature();

                IFullNode node = nodeBuilder.Build();


                if (node != null)
                {
                    node.Ntype = NodeType.Wallet;
                    var path = AppDomain.CurrentDomain.BaseDirectory + "cfg.ini";
                    if (System.IO.File.Exists(path))
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
                        {
                            var cfg = sr.ReadToEnd();
                            if (cfg == "Mining")
                            {
                                node.Ntype = NodeType.Mining;
                            }
                            else if (cfg == "Smart")
                            {
                                node.Ntype = NodeType.Smart;
                            }
                            else if (cfg == "Full")
                            {
                                node.Ntype = NodeType.Full;
                            }
                        }
                    }
                    await node.RunAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem initializing the node. Details: '{0}'", ex);
            }
        }
    }
}
