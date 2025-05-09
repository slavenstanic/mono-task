import { useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import VehicleMakeStore from '../stores/vehicleMakeStore';

const store = new VehicleMakeStore();

const VehicleMakeList = () => {
    useEffect(() => {
        store.loadVehicleMakes();
    }, []);

    if (store.loading) return <p>Loading...</p>;

    return (
        <ul>
            {store.vehicleMakes.map(make => (
                <li key={make.id}>
                    {make.name} ({make.abrv})
                </li>
            ))}
        </ul>
    );
};

export default observer(VehicleMakeList);
