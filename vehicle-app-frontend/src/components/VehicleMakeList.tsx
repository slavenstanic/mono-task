import { useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import vehicleMakeStore from '../stores/vehicleMakeStore';
import type {VehicleMake} from '../models/vehicleMake';

const VehicleMakeList = () => {
    const [editId, setEditId] = useState<number | null>(null);
    const [form, setForm] = useState({ name: '', abrv: '' });

    useEffect(() => {
        vehicleMakeStore.loadVehicleMakes();
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const startEdit = (make: VehicleMake) => {
        setEditId(make.id);
        setForm({ name: make.name, abrv: make.abrv });
    };

    const cancelEdit = () => {
        setEditId(null);
        setForm({ name: '', abrv: '' });
    };

    const saveEdit = () => {
        if (editId !== null) {
            vehicleMakeStore.updateVehicleMake({ id: editId, ...form });
            cancelEdit();
        }
    };

    if (vehicleMakeStore.loading) return <p>Loading...</p>;

    return (
        <ul>
            {vehicleMakeStore.vehicleMakes.map(make => (
                <li key={make.id}>
                    {editId === make.id ? (
                        <>
                            <input
                                name="name"
                                value={form.name}
                                onChange={handleChange}
                            />
                            <input
                                name="abrv"
                                value={form.abrv}
                                onChange={handleChange}
                            />
                            <button onClick={saveEdit}>Save</button>
                            <button onClick={cancelEdit}>Cancel</button>
                        </>
                    ) : (
                        <>
                            {make.name} ({make.abrv})
                            <button onClick={() => startEdit(make)}>Edit</button>
                            <button onClick={() => vehicleMakeStore.deleteVehicleMake(make.id)}>Delete</button>
                        </>
                    )}
                </li>
            ))}
        </ul>
    );
};

export default observer(VehicleMakeList);
