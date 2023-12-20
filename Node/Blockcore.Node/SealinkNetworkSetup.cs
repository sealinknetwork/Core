using System;
using System.Collections.Generic;
using Blockcore.Consensus.Checkpoints;
using SealinkNetwork.Networks;
using SealinkNetwork.Networks.Setup;
using Blockcore.NBitcoin;

namespace SealinkNetwork
{
   internal class SealinkNetworkSetup
   {
      internal static SealinkNetworkSetup Instance = new SealinkNetworkSetup();

      internal CoinSetup Setup = new CoinSetup
      {
         FileNamePrefix = "sealinknetwork",
         ConfigFileName = "sealinknetwork.conf",
         Magic = "01-4D-59-43",
         CoinType = 51997, // SLIP-0044: https://github.com/satoshilabs/slips/blob/master/slip-0044.md,
         PremineReward = 0x989680,//
         PoWBlockReward = 10,
         PoSBlockReward = 500,
         LastPowBlock = 3500000,
         GenesisText = "There's a difference between knowing the path and walking the path.", // The New York Times, 2020-04-16
         TargetSpacing = TimeSpan.FromSeconds(64),
         ProofOfStakeTimestampMask = 0x0000000F, // 0x0000003F // 64 sec
         PoSVersion = 4
      };

      internal NetworkSetup Main = new NetworkSetup
      {
         Name = "SealinkNetworkMain",
         RootFolderName = "sealinknetwork",
         CoinTicker = "SLK",
         DefaultPort = 15001,
         DefaultRPCPort = 15002,
         DefaultAPIPort = 15003,
         PubKeyAddress = 50, // B https://en.bitcoin.it/wiki/List_of_address_prefixes
         ScriptAddress = 110, // b
         SecretAddress = 160,
         GenesisTime = 1701937369,
         GenesisNonce = 780834,
         GenesisBits = 0x1E0FFFFF,
         GenesisVersion = 1,
         GenesisReward = Money.Zero,
         HashGenesisBlock = "00000d1869963a0fea271c544af7cec203cbf287cf1168a0d529936f0b69bc7a",
         HashMerkleRoot = "8e3770235cdab1c484ef2e928a51c471030220b1f69142c7487f85ed001cf810",
         DNS = new[] { "seed.sealink.network" },
         Nodes = new[] { "97.74.83.32", "97.74.86.57", "72.167.150.174", "92.205.231.104" },
         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         }
      };

      internal NetworkSetup RegTest = new NetworkSetup
      {
         Name = "SealinkNetworkRegTest",
         RootFolderName = "sealinknetworkregtest",
         CoinTicker = "TSLK",
         DefaultPort = 25001,
         DefaultRPCPort = 25002,
         DefaultAPIPort = 25003,
         PubKeyAddress = 111,
         ScriptAddress = 196,
         SecretAddress = 239,
         GenesisTime = 1701937433,
         GenesisNonce = 36602,
         GenesisBits = 0x1F00FFFF,
         GenesisVersion = 1,
         GenesisReward = Money.Zero,
         HashGenesisBlock = "00005fa2cbd7e87d85d9216b0601d7d28dd8390b0244dec0a4fdd5e0e828b3c3",
         HashMerkleRoot = "2e28235fe524bca841ab6e688ae6a46115c7d2418328ec2f2de67d910b7aa3a9",
         DNS = new[] { "seed.sealink.network" },
         Nodes = new[] { "97.74.86.57", "72.167.150.174" },
         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         }
      };

      internal NetworkSetup Test = new NetworkSetup
      {
         Name = "SealinkNetworkTest",
         RootFolderName = "sealinknetworktest",
         CoinTicker = "TSLK",
         DefaultPort = 35001,
         DefaultRPCPort = 35002,
         DefaultAPIPort = 35003,
         PubKeyAddress = 111,
         ScriptAddress = 196,
         SecretAddress = 239,
         GenesisTime = 1701937436,
         GenesisNonce = 5772,
         GenesisBits = 0x1F0FFFFF,
         GenesisVersion = 1,
         GenesisReward = Money.Zero,
         HashGenesisBlock = "000fae014dee6850319fe89e07d2aaac0ee3274c5582fd1686e424dc79c90b5c",
         HashMerkleRoot = "262f2783d752c3b7a48da57567feeab257d77409268a28aeb2c767b7da30881c",
         DNS = new[] { "seed.sealink.network" },
         Nodes = new[] { "97.74.86.57" },
         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         }
      };

      public bool IsPoSv3()
      {
         return this.Setup.PoSVersion == 3;
      }

      public bool IsPoSv4()
      {
         return this.Setup.PoSVersion == 4;
      }
   }
}
