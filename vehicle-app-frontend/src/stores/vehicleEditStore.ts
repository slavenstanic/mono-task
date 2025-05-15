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

  setForm = (field: string, value: string) => {
    this.form = { ...this.form, [field]: value };
  };

  setFormValues = (values: { name: string; abrv: string }) => {
    this.form = values;
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
