
<p align="center">
  <p align="center">
    <img src="https://sealink.network/img/logo.png" height="50" alt="Sealink" />
  </p>
  <h3 align="center">
    About Sealink Network
  </h3>
  <p align="center">
    Open source .NET Bitcoin based blockchain node in C# 
  </p>
</p>


Introduction
----------------------------

### Bitcoin Implementation in C# and .NET 6

**What is Sealink?**

- Sealink is a platform to build Layer 1 consensus networks based on the Bitcoin protocol [ blockcore.net ], built on the [.NET Core](https://dotnet.github.io/) framework and written entirely in C#. 
- Sealink aims to maintain an alternative C# Bitcoin implementation, based on the [NBitcoin](https://github.com/MetacoSA/NBitcoin) & [Stratis](https://github.com/stratisproject/StratisBitcoinFullNode) projects.
- Sealink is neither a coin or a for profit business.

Getting Started Guide
-----------
### Add Node ###
- 97.74.83.32

### Windows ###

- Install .NET 6 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Dwonload last Sealink Node. 
- UnZip file, find the Blockcore.Node.exe, click to runing node.
- Open Browser, input http://localhost:15003



### Linux ###
- Install .NET 6 https://learn.microsoft.com/zh-cn/dotnet/core/install/linux-scripted-manual#set-environment-variables-system-wide
  
- Intstall Rocksdb dependencies
- apt-get update 
- apt-get install -y curl libsnappy-dev libc-dev libc6-dev libc6 unzip 
- apt-get clean
- rm -rf /var/lib/apt/lists/*
  
- Dwonload Sealink Node.
- Unzip file,run dotnet Blockcore.Node.dll
- Open Browser, input http://localhost:15003

### API ###
- DocUrl http://localhost:15003/docs/index.html

- Get Mnemonic
  curl -X 'GET' 'http://localhost:15003/api/Wallet/mnemonic?language=English&wordCount=12' -H 'accept: */*'
  
- Create Wallet
  curl -X 'POST' \
  'http://localhost:15003/api/Wallet/create' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d '{
  "mnemonic": "string",
  "password": "string",
  "passphrase": "string",
  "name": "string",
  "purpose": 0
}'

- Get wallet balance
curl -X 'GET' \
  'http://localhost:15003/api/Wallet/balance?WalletName=1&AccountName=account%200' \
  -H 'accept: */*'

- Start mining
  curl -X 'POST' \
  'http://localhost:15003/api/Mining/generate' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d '{
  "blockCount": 1
}'

- Stop mining
  curl -X 'POST' \
  'http://localhost:15003/api/Mining/stopmining' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d 'true'

- Start staking
  curl -X 'POST' \
  'http://localhost:15003/api/Staking/startstaking' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d '{
  "password": "1",
  "name": "1" --wallet name

}'

- Stop staking
  curl -X 'POST' \
  'http://localhost:15003/api/Staking/stopstaking' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d 'true'

- Get chain status
  curl -X 'GET' 'http://localhost:15003/api/Node/status' -H 'accept: */*'
