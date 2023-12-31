
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

### Windows ###

- Install .NET 6 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- Dwonload last Sealink Node. 
- UnZip file, find the Blockcore.Node.exe, click to runing node.
- Open Browser, input http://localhost:15003



### Linux ###
- Install .NET 6 https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#set-environment-variables-system-wide
- Set environment variables system-wide
- export DOTNET_ROOT=$HOME/.dotnet
- export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools

### Install Rocksdb dependencies ###
- apt-get update 
- apt-get install -y curl libsnappy-dev libc-dev libc6-dev libc6 unzip 
- apt-get clean
- rm -rf /var/lib/apt/lists/*

### Run Node ###
- Dwonload Sealink Node.https://github.com/sealinknetwork/Core/releases
- Unzip file,Run dotnet Blockcore.Node.dll
- Open Browser, input http://localhost:15003



### Mining&Staking ####
- Setting, Enable Mining, Enable SmartNode
![image](https://github.com/sealinknetwork/Core/assets/153339478/045d8a50-96ac-4e56-b217-ea11660e95c3)

- Staking(need slk)
![image](https://github.com/sealinknetwork/Core/assets/153339478/d2fbcd54-f2df-4b12-8eee-c0dfda71b312)



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

- Add Node
curl -X 'GET' 'http://localhost:15003/api/ConnectionManager/addnode?endpoint=72.167.148.221&command=add' -H 'accept: */*'
curl -X 'GET' 'http://localhost:15003/api/ConnectionManager/getpeerinfo' -H 'accept: */*'

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
