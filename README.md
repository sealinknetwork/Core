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
- 72.167.148.221
- 92.205.231.104
- 97.74.86.57

### Windows ###

- Install .NET 6 [Link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Dwonload last Sealink Node. 
- UnZip file, find the Blockcore.Node.exe, click to runing node.
- Open Browser, input http://localhost:15003

### Liunx ###
- Install .NET 6 [Link](https://learn.microsoft.com/zh-cn/dotnet/core/install/linux-scripted-manual#set-environment-variables-system-wide)

- Install libs

  ```shell
  sudo apt-get install build-essential
  sudo apt-get install libgflags-dev
  sudo apt-get install libsnappy-dev
  sudo apt-get install zlib1g-dev
  sudo apt-get install libbz2-dev
  sudo apt-get install liblz4-dev
  sudo apt-get install libzstd-dev
  ```

- Dwonload Sealink Node.

- Unzip file,run dotnet Blockcore.Node.dll

- Open Browser, input http://localhost:15003

### API ###
- DocUrl [http://localhost:15003/docs/index.html](http://localhost:15003/docs/index.html)

- Get Mnemonic

  ```shell
  curl -X 'GET' 'http://localhost:15003/api/Wallet/mnemonic?language=English&wordCount=12' -H 'accept: */*'
  ```

- Create Wallet

  ```shell
  curl -X 'POST' 'http://localhost:15003/api/Wallet/create' \
    -H 'accept: */*' \
    -H 'Content-Type: application/json-patch+json' \
    -d '{
    "mnemonic": "string",
    "password": "string",
    "passphrase": "string",
    "name": "string",
    "purpose": 0
  }'
  ```

- Get wallet balance

  ```shell
  curl -X 'GET' 'http://localhost:15003/api/Wallet/balance?WalletName=1&AccountName=account%200'
    -H 'accept: */*' 
  ```

- Start mining

  ```shell
  curl -X 'POST'   'http://localhost:15003/api/Mining/generate' \
    -H 'accept: */*' \
    -H 'Content-Type: application/json-patch+json' \
    -d '{
    "blockCount": 1
  }'
  ```

- Stop mining

  ```shell
  curl -X 'POST' 'http://localhost:15003/api/Mining/stopmining' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d 'true'
  ```

- Start staking

  ```shell
  - curl -X 'POST' 'http://localhost:15003/api/Staking/startstaking' \
    -H 'accept: */*' \
    -H 'Content-Type: application/json-patch+json' \
    -d '{
    "password": "1",
    "name": "1" --wallet name
  }'
  ```

- Stop staking
  
  ```shell
  curl -X 'POST' 'http://localhost:15003/api/Staking/stopstaking' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json-patch+json' \
  -d 'true'
  ```
  
- Get chain status
  
  ```shell
  curl -X 'GET' 'http://localhost:15003/api/Node/status' -H 'accept: */*'
  ```
  
  
