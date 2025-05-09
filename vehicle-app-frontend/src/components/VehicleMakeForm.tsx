import { useState } from 'react';
import { observer } from 'mobx-react-lite';
import vehicleMakeStore from '../stores/vehicleMakeStore';

const VehicleMakeForm = () => {
    const [form, setForm] = useState({ name: '', abrv: '' });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (form.name && form.abrv) {
            vehicleMakeStore.createVehicleMake(form);
            setForm({ name: '', abrv: '' }); // reset form
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                name="name"
                value={form.name}
                onChange={handleChange}
                placeholder="Name"
            />
            <input
                name="abrv"
                value={form.abrv}
                onChange={handleChange}
                placeholder="Abbreviation"
            />
            <button type="submit">Add Vehicle Make</button>
        </form>
    );
};

export default observer(VehicleMakeForm);
