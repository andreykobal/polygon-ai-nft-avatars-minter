using Web3Unity.Scripts.Library.Ethers.Contracts;
using Newtonsoft.Json;
using Web3Unity.Scripts.Library.Ethers.Providers;
using UnityEngine;
using UnityEngine.UIElements;

public class Check1155Balance : MonoBehaviour
{
    public UIDocument uiDocument;
    private Label diamondsTotalLabel;
    async public void Check1155TotalBalance()
    {
        string contractAbi = ContractAbi.Abi1155;
        string contractAddress = "0xCA45E197E11804a2643dB50D87f03378c56e466d";
        string method = "getTotalBalance";
        
        var walletAddress = PlayerPrefs.GetString("Account");
        var provider = new JsonRpcProvider("https://rpc-mumbai.maticvigil.com/");
        var contract = new Contract(contractAbi, contractAddress, provider);
        var calldata = await contract.Call(method, new object[]
        {
            // Pass the account address as the parameter
            walletAddress
        });
        var totalDiamonds = calldata[0];
        
        print("Contract 1155 Balance (Diamonds) Total: " + totalDiamonds);
        
        diamondsTotalLabel = uiDocument.rootVisualElement.Q<Label>("DiamondsTotal");
        diamondsTotalLabel.text = totalDiamonds.ToString();
    }

    void Start()
    {
        Check1155TotalBalance();
    }
}
