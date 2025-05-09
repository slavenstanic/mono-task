import VehicleMakeList from './components/VehicleMakeList';
import VehicleMakeForm from "./components/VehicleMakeForm.tsx";

function App() {
    return (
        <div className="App">
            <h1>Vehicle Makes</h1>
            <VehicleMakeForm />
            <VehicleMakeList />
        </div>
    );
}

export default App;
