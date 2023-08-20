using System.Collections;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Web3Unity.Scripts.Library.Ethers.Providers;
using Web3Unity.Scripts.Library.Web3Wallet;

using UnityEngine;

public class MintNFT : MonoBehaviour
{
    public CheckNFTOwnership checkNFTOwnership;

    string[] contractAddresses = 
    {
        "0x9f109bD4cC26357184CF6b1f87cFaadd8233E432",
        "0xD837D98194884Bc4dEF43EEdc0aB4e22fA20F174",
        "0xec7Ba60FDcDA2F327d1Ff4E05029Ae0619b3B295"
    };

    async public void mintItem(int avatarIndex)
    {
        string chainId = "80001";
        var tokenURI = "https://rpc-mumbai.maticvigil.com/";

        string contractAbi = ContractAbi.SingleChainAbi;
        string contractAddress = contractAddresses[avatarIndex];
        string method = "mintItem";
        
        var provider = new JsonRpcProvider("https://bafkreiczapdwomdlotjqt4yaojyizlgarn4kq57smi3ptkwn5lug5yz7yu.ipfs.nftstorage.link/");
        var contract = new Contract(contractAbi, contractAddress, provider);
        Debug.Log("Contract: " + contract);
        
        var calldata = contract.Calldata(method, new object[]
        {
            tokenURI
        });
        
        string response = await Web3Wallet.SendTransaction(chainId, contractAddress, "0", calldata, "", "");

        Debug.LogError(response);
        
        StartCoroutine(WaitAndCheckBalance(avatarIndex));
    }
    
    IEnumerator WaitAndCheckBalance(int avatarIndex)
    {
        // Wait for 15 seconds
        yield return new WaitForSeconds(10);

        // Check the balance again
        checkNFTOwnership.CheckNFTBalance(contractAddresses[avatarIndex], avatarIndex);
    }
}