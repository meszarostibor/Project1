import React, {useState,useEffect} from 'react'

export default function GetAllCars() {
  
  const url = `http://localhost:5000/cars`
  const [carsData, setCarsData] = useState([])

  useEffect(() => {
    (async () => {
      const request = await fetch(url, {
        headers: {
          contentType: 'application/json'
        }
      })
      if (!request.ok) {
        console.log("error")
        return
      }
      const response = await request.json();
      setCarsData(response.result)
      console.log(response.message)
    })()
  }, [carsData])

  const carElements = carsData.map((car) => {
    return (
      <div className='card-body' key={car.id} style={{ width: 200 }}>
        <h3>{car.brand}</h3>
        <h3>{car.type}</h3>
        <h3>{car.color}</h3>
        <h3>{car.myear}</h3>
      </div>
    )
  })

  return (
    <div>
      {carElements}
    </div>
  )
}
