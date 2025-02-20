import React, { useState } from 'react'

export default function AddNewCar() {

  const [carData, setCardata] = useState(
    {
      brand: "",
      type: "",
      color: "",
      myear: ""
    }
  )

  const handleChange = (event) => {
    const { name, value } = event.target
    setCardata({ ...carData, [name]: value })
  }

  const handleSubmit = async (event) => {
    const url = `http://localhost:5000/cars`
    event.preventDefault()
    const request = await fetch(url, {
      method: "POST",
      body: JSON.stringify(carData),
      headers: {
        "Content-Type": "application/json"
        //,
        //"Authorize": jwtDecode(localStorage.getItem("token"))
      }
    })
    if (!request.ok) {
      console.log("error")
      return
    }

    const response = await request.json()

  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label>Márka</label>
        <input
          type="text" 
          id='brand'
          name="brand" 
          value={carData.brand}
          onChange={handleChange}
          className='form-control'
          placeholder='Autó márkája'
        />
        <label>Típus</label>
        <input
          type="text" 
          id='type'
          name="type" 
          value={carData.type}
          onChange={handleChange}
          className='form-control'
          placeholder='Autó típusa'
        />
        <label>Szín</label>
        <input
          type="text" 
          id='color'
          name="color" 
          value={carData.color}
          onChange={handleChange}
          className='form-control'
          placeholder='Autó színe'
        />
        <label>Gyártási év</label>
        <input
          type="date" 
          id='myear'
          name="myear" 
          value={carData.myear}
          onChange={handleChange}
          className='form-control'
          placeholder='Autó gyártási éve-hónap-nap'
        />
      <button type="submit" className='btn btn-primary'>Elküld</button>

      </form>
    </div>
  )
}
