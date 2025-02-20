import logo from './logo.svg';
import './App.css';
import AddNewCar from './components/AddNewCar';
import GetAllCars from './components/cards/GetAllCars';

function App() {
  return (
    <div className="container">
      <AddNewCar />
      <GetAllCars />
    </div>
  );
}

export default App;
