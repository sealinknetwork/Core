using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Blockcore.Utilities.Extensions;
using Newtonsoft.Json;
using SealinkNetwork;

namespace Blockcore.Node
{
    public class peer
    {
        public string addr { get; set; }
        public string subVer { get; set; }
        public string startingHeight { get; set; }
        public string version { get; set; }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                args = new string[] { };

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


                FullNode node = (FullNode)nodeBuilder.Build();


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

                    //check first load , download peers
                    try
                    {
                        var http = new HttpClient();
                        HttpResponseMessage resp = await http.GetAsync("https://explorer.sealink.network/smartnode/peers");
                        if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            var content = await resp.Content.ReadAsStringAsync();
                            List<peer> peers = JsonConvert.DeserializeObject<List<peer>>(content);
                            if (peers.Count > 0)
                            {

                                foreach (peer peer in peers)
                                {
                                    var arrs = peer.addr.Split(':');
                                    //if (strpeers.Find(a => a.Equals(arrs[0])) != null) continue;
                                    node.ConnectionManager.ConnectionSettings.AddAddNode(new IPEndPoint(IPAddress.Parse(arrs[0]), int.Parse(arrs[1])));
                                }
                            }
                        }
                    }
                    catch { }


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
