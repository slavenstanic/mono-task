import { makeObservable, observable, action, runInAction } from "mobx";
import type { VehicleMake } from "../models/vehicleMake";

import {
  getVehicleMakes,
  createVehicleMake,
  updateVehicleMake,
  deleteVehicleMake,
} from "../services/vehicleMakeService";

class VehicleMakeStore {
  vehicleMakes: VehicleMake[] = [];
  loading: boolean = false;
  page = 1;
  pageSize = 5;
  totalPages = 1;

  constructor() {
    makeObservable(this, {
      vehicleMakes: observable,
      loading: observable,
      page: observable,
      pageSize: observable,
      totalPages: observable,
      loadVehicleMakes: action,
      setPage: action,
      createVehicleMake: action,
      deleteVehicleMake: action,
      updateVehicleMake: action,
    });
  }

  loadVehicleMakes = async () => {
    this.loading = true;
    try {
      const data = await getVehicleMakes(this.page, this.pageSize);
      runInAction(() => {
        this.vehicleMakes = data.items;
        this.totalPages = data.totalPages;
      });
    } catch (error) {
      console.error("Failed to load vehicle makes:", error);
    } finally {
      runInAction(() => {
        this.loading = false;
      });
    }
  };

  setPage = (newPage: number) => {
    if (newPage >= 1 && newPage <= this.totalPages) {
      this.page = newPage;
      this.loadVehicleMakes();
    }
  };

  createVehicleMake = async (make: Omit<VehicleMake, "id">) => {
    try {
      await createVehicleMake(make);
      runInAction(() => {
        this.loadVehicleMakes();
      });
    } catch (error) {
      console.error("Failed to create vehicle make:", error);
    }
  };

  deleteVehicleMake = async (id: number) => {
    try {
      const status = await deleteVehicleMake(id);
      if (status === 200) {
        this.loadVehicleMakes();
      }
    } catch (error) {
      console.error("Failed to delete vehicle make:", error);
    }
  };

  updateVehicleMake = async (make: VehicleMake) => {
    try {
      const status = await updateVehicleMake(make);
      if (status === 200) {
        runInAction(() => {
          const index = this.vehicleMakes.findIndex((m) => m.id === make.id);
          if (index !== -1) this.vehicleMakes[index] = make;
        });
      }
    } catch (error) {
      console.error("Failed to update vehicle make:", error);
    }
  };
}

const vehicleMakeStore = new VehicleMakeStore();
export default vehicleMakeStore;
