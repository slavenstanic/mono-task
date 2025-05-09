import { makeAutoObservable, runInAction } from 'mobx';
import API from '../api/agent';
import type {VehicleMake} from '../models/vehicleMake';

export default class VehicleMakeStore {
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
}
