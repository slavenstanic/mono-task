import { makeObservable, observable, action, runInAction } from "mobx";
import API from "../api/agent";
import type { VehicleMake } from "../models/vehicleMake";

interface PagedResult<T> {
  items: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}

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
      const response = await API.get<PagedResult<VehicleMake>>(
        `/vehiclemake?page=${this.page}&pageSize=${this.pageSize}`,
      );
      runInAction(() => {
        this.vehicleMakes = response.data.items;
        this.totalPages = response.data.totalPages;
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
      await API.post<VehicleMake>("/vehiclemake", make);
      runInAction(() => {
        this.loadVehicleMakes();
      });
    } catch (error) {
      console.error("Failed to create vehicle make:", error);
    }
  };

  deleteVehicleMake = async (id: number) => {
    try {
      const response = await API.delete(`/vehiclemake/${id}`);
      if (response.status === 200) {
        this.loadVehicleMakes();
      }
    } catch (error) {
      console.error("Failed to delete vehicle make:", error);
    }
  };

  updateVehicleMake = async (make: VehicleMake) => {
    try {
      const response = await API.put(`/vehiclemake/${make.id}`, make);
      if (response.status === 200) {
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
