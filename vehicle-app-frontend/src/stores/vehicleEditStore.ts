import { makeObservable, observable, action } from "mobx";

class VehicleEditStore {
  form = { name: "", abrv: "" };
  editId: number | null = null;

  constructor() {
    makeObservable(this, {
      form: observable,
      editId: observable,
      setForm: action,
      setEditId: action,
      resetForm: action,
    });
  }

  setForm = (name: string, abrv: string) => {
    this.form = { name, abrv };
  };

  resetForm = () => {
    this.form = { name: "", abrv: "" };
    this.editId = null;
  };

  setEditId = (id: number) => {
    this.editId = id;
  };
}

const vehicleEditStore = new VehicleEditStore();
export default vehicleEditStore;
