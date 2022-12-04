import React, { useState } from "react";
import Constants from "./utilities/Constant";
import CryptoCreateForm from "./Components/CryptoCreateForm";
import CryptoUpdateForm from "./Components/CryptoUpdateForm";

export default function App() {
  const [cryptos, setCryptos] = useState([]);
  const [showingCreateNewCryptoForm, setShowingCreateNewCryptoForm] = useState(false);
  const [cryptoCurrentlyBeingUpdated, setCryptoCurrentlyBeingUpdated] = useState(null);


  function getCryptos() {
    const url = 'https://localhost:7254/api/Crypto';
    //const url = Constants.API_URL_GET_ALL_CRYPTOS
    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(cryptosFromServer => {
        console.log(cryptosFromServer);
        setCryptos(cryptosFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      })
  }
  return (
    <div className="container">
      <div className="row-min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewCryptoForm === false && cryptoCurrentlyBeingUpdated === null) &&  ( 
         
          <div className="mt-5">
            <button onClick={getCryptos} className="btn btn-dark btn-lg w-100">Get Crypto from Server</button>
            <button onClick={() => setShowingCreateNewCryptoForm(true)} className="btn btn-secondary btn-lg w-100 mg-4">Enter new record</button>
          </div>
          )}
          {(cryptos.length > 0 && showingCreateNewCryptoForm === false && cryptoCurrentlyBeingUpdated === null) && renderCryptosTable()}

          {showingCreateNewCryptoForm && <CryptoCreateForm onCryptoCreated={onCryptoCreated} />}
          {cryptoCurrentlyBeingUpdated && <CryptoUpdateForm onCryptoUpdated={onCryptoUpdated}/>}

        </div>
      </div>
    </div>

  );

  function renderCryptosTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">CryptoId(PK)</th>
              <th scope="col">TransferFrom</th>
              <th scope="col">TransferTo</th>
              <th scope="col">CryptoAmout</th>
              <th scope="col">currencyType</th>
              <th scope="col">transferType</th>
              <th scope="col">transferDate</th>
              <th scope="col">balance</th>
              <th scope="col">client</th>
            </tr>
          </thead>
          <tbody>
            {cryptos.map((crypto) => (
              <tr key={crypto.Id}>
                <th scope="row">{crypto.Id}</th>
                <td>{crypto.transferFrom}</td>
                <td>{crypto.transferTo}</td>
                <td>{crypto.cryptoAmount}</td>
                <td>{crypto.currencyType}</td>
                <td>{crypto.transferType}</td>
                <td>{crypto.transferDate}</td>
                <td>{crypto.balance}</td>
                <td>{crypto.client}</td>
                <td>
                  <button onClick={()=>setCryptoCurrentlyBeingUpdated(crypto)} className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button onClick={()=>setCryptoCurrentlyBeingUpdated(crypto)} className="btn btn-secondary btn-lg ">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={() => setCryptos([])} className="btn btn-dark btn-lg w-100">Empty React cryptos array</button>
      </div>
    )
  }
  function onCryptoCreated(createdCrypto) {
    setShowingCreateNewCryptoForm(false);
    if (createdCrypto === null) {
      return;

    }
    alert(`crypto info Successfully created. Click ok to continue `);
    getCryptos();

  }
  function onCryptoUpdated(updatedCrypto) {
    
    setCryptoCurrentlyBeingUpdated(null);
    if(updatedCrypto === null) {
      return;

    }
    let cryptosCopy = [...cryptos];
    const index = cryptosCopy.findIndex((cryptoCopyCrypto,currentIndex)=>{
      if (cryptoCopyCrypto.Id === updatedCrypto.Id) {
        return true;

        
      }
    });
  }
}
