import React from 'react';
import './App.css';
import MintNFT from './MintNFT';
import logo from './assets/logo.png';


function App() {
  const isMobile = window.innerWidth <= 768; // You can adjust the breakpoint if needed

  return (
    <div className="App">
      {isMobile && !window.ethereum ? (
        <div className="MobileOverlay">
          <img src={logo} alt="logo" style={{ width: '150px' }} /> 
          <h1 style={{ textAlign: 'center', fontSize: '24px', lineHeight: '28px', margin: '16px 0'}}>Mint Your AI NFT Avatar</h1>

          <h4>Enjoy the app on mobile! For a seamless experience, please install Metamask</h4>
          <a href="https://metamask.app.link/dapp/simple-nft-minter-xt5p.vercel.app/"><button>Open in Metamask</button></a>
        </div>
      ) : null}
      <MintNFT />
    </div>
  );
}

export default App;