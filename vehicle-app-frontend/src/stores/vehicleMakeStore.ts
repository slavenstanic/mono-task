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
}

const vehicleMakeStore = new VehicleMakeStore();
export default vehicleMakeStore;
