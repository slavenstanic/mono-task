import { makeAutoObservable, runInAction } from 'mobx';
import API from '../api/agent';
import type {VehicleMake} from '../models/vehicleMake';

class VehicleMakeStore {
    vehicleMakes: VehicleMake[] = [];
    loading: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadVehicleMakes = async () => {
        this.loading = true;
        try {
            const response = await API.get<VehicleMake[]>('/vehiclemake');
            runInAction(() => {
                this.vehicleMakes = response.data;
            });
        } catch (error) {
            console.error('Failed to load vehicle makes:', error);
        } finally {
            runInAction(() => {
                this.loading = false;
            });
        }
    };

    createVehicleMake = async (make: Omit<VehicleMake, 'id'>) => {
        try {
            const response = await API.post<VehicleMake>('/vehiclemake', make);
            runInAction(() => {
                this.vehicleMakes.push(response.data);
            });
        } catch (error) {
            console.error('Failed to create vehicle make:', error);
        }
    };

    deleteVehicleMake = async (id: number) => {
        try {
            await API.delete(`/vehiclemake/${id}`);
            runInAction(() => {
                this.vehicleMakes = this.vehicleMakes.filter(m => m.id !== id);
            });
        } catch (error) {
            console.error('Failed to delete vehicle make:', error);
        }
    };

    updateVehicleMake = async (make: VehicleMake) => {
        try {
            await API.put(`/vehiclemake/${make.id}`, make);
            runInAction(() => {
                const index = this.vehicleMakes.findIndex(m => m.id === make.id);
                if (index !== -1) this.vehicleMakes[index] = make;
            });
        } catch (error) {
            console.error('Failed to update vehicle make:', error);
        }
    };


}

const vehicleMakeStore = new VehicleMakeStore();
export default vehicleMakeStore;
