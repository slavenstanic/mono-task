import { useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import vehicleMakeStore from '../stores/vehicleMakeStore';

const VehicleMakeList = () => {
    useEffect(() => {
        vehicleMakeStore.loadVehicleMakes();
    }, []);

    if (vehicleMakeStore.loading) return <p>Loading...</p>;

    return (
        <ul>
            {vehicleMakeStore.vehicleMakes.map(make => (
                <li key={make.id}>
                    {make.name} ({make.abrv})
                    <button onClick={() => vehicleMakeStore.deleteVehicleMake(make.id)}>
                        Delete
                    </button>
                </li>
            ))}
        </ul>
    );
};

export default observer(VehicleMakeList);
