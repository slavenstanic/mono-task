import { makeAutoObservable } from "mobx";

class VehicleFormStore {
  name = "";
  abrv = "";

  constructor() {
    makeAutoObservable(this);
  }

  setField(field: string, value: string) {
    (this as any)[field] = value;
  }

  reset() {
    this.name = "";
    this.abrv = "";
  }

  get isValid() {
    return this.name.trim() !== "" && this.abrv.trim() !== "";
  }
}

const vehicleFormStore = new VehicleFormStore();
export default vehicleFormStore;
