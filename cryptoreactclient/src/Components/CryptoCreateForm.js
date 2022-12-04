import React, { useState } from "react";

export default function CryptoCreateForm(props) {
   
    const initialFormData = Object.freeze({
        transferFrom: "Name who will get transfer",
        transferTo: "Name who get transfer",
        cryptoAmount: "Amount of transfer",
        currencyType: "Type of the currency",
        transferType: "Type of the transfer",
        transferDate: Date.now(),
        balance: 0,
        client: "Client"
    }); 

    const {formData, SetFormData} = useState(initialFormData);
    const handleChange = (e) => {
        SetFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });

    };
    const handleSubmit = (e) => {
        e.preventDefault();

        const cryptoToCreate = {
            cryptoId: 0,
            transferFrom: FormData.transferFrom,
            transferTo: FormData.transferTo,
            cryptoAmount: FormData.cryptoAmount,
            currencyType: FormData.currencyType,
            transferType: FormData.transferType,
            transferDate: FormData.Date,
            balance: FormData.balance,
            client: FormData.client
        };
        const url = 'https://localhost:7254/api/Crypto';
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(cryptoToCreate)
          })
            .then(response => response.json())
            .then(responseFromServer => {
              console.log(responseFromServer);
            })
            .catch((error) => {
              console.log(error);
              alert(error);
            });
            props.onCryptoCreated(cryptoToCreate)

    };
    return (
        <div>
            <form className="w-100 px-5">
                <h1 className="mt-5">Create new crypto info</h1>

                <div className="mt-5">
                    <label className="h3 form-label">Crypto transferTo</label>
                    <input value={FormData.transferFrom} name="title" type="text" className="form-control" onChange={handleChange} />
                </div>
                
                <div className="mt-4">
                    <label className="h3 form-label">Crypto transferFrom</label>
                    <input value={FormData.transferTo} name="title" type="text" className="form-control" onChange={handleChange} />
                </div>
                <div className="mt-4">
                    <label className="h3 form-label">Crypto amount</label>
                    <input value={FormData.cryptoAmount} name="title" type="number" className="form-control" onChange={handleChange} />
                </div>
                <div className="mt-4">
                    <label className="h3 form-label">Crypto currencyType</label>
                    <input value={FormData.currencyType} name="title" type="text" className="form-control" onChange={handleChange} />
                </div>
                <div className="mt-4">
                    <label className="h3 form-label">Crypto transferType</label>
                    <input value={FormData.transferType} name="title" type="text" className="form-control" onChange={handleChange} />
                </div>
                <div className="mt-4">
                    <label className="h3 form-label">Crypto transferDate</label>
                    <input value={FormData.transferDate} name="title" type="date" className="form-control" onChange={handleChange} />
                </div>
                <div className="mt-4">
                    <label className="h3 form-label">Crypto balance</label>
                    <input value={FormData.balance} name="title" type="number" className="form-control" onChange={handleChange} />
                </div>
                <div className="mt-4">
                    <label className="h3 form-label">Crypto Client</label>
                    <input value={FormData.client} name="title" type="text" className="form-control" onChange={handleChange} />
                </div>

                <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
                <button onClick={()=>props.onCryptoCreated(null)}className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>

            </form>
        </div>
    )

}
