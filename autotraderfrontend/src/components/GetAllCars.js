import React, {useState,useEffect} from 'react'
import DeleteCar from './DeleteCar'

export default function GetAllCars(props) {
  
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
  }, [props.count])

  const carElements = carsData.map(
    car => {
    return (
      <div className='card m3 pt-2' key={car.id} style={{ 'width': 200, 'float': 'left' }}>
        <h3>{car.brand}</h3>
        <h3>{car.type}</h3>
        <h3>{car.color}</h3>
        <h3>{car.myear}</h3>
        <div><DeleteCar carId={car.id} handleCount={props.handleCount}/></div>
      </div>
    )
  })

  return (
    <div>
      {carElements}
    </div>
  )
}
