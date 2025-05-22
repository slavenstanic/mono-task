import { makeObservable, observable, action, runInAction } from "mobx";
import { getVehicleMakes } from "../services/vehicleMakeService";
import type { VehicleMake } from "../models/vehicleMake";

class VehicleListStore {
  vehicleMakes: VehicleMake[] = [];
  page = 1;
  pageSize = 5;
  totalPages = 1;
  loading = false;

  constructor() {
    makeObservable(this, {
      vehicleMakes: observable,
      page: observable,
      pageSize: observable,
      totalPages: observable,
      loading: observable,
      loadVehicleMakes: action,
      setPage: action,
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
}

const vehicleListStore = new VehicleListStore();
export default vehicleListStore;
