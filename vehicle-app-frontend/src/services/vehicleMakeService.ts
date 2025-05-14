import API from "../api/agent";
import type { VehicleMake, PagedResult } from "../models/vehicleMake";

export const getVehicleMakes = async (page: number, pageSize: number) => {
  const response = await API.get<PagedResult<VehicleMake>>(
    `/vehiclemake?page=${page}&pageSize=${pageSize}`,
  );
  return response.data;
};

export const createVehicleMake = async (make: Omit<VehicleMake, "id">) => {
  const response = await API.post<VehicleMake>("/vehiclemake", make);
  return response.data;
};

export const updateVehicleMake = async (make: VehicleMake) => {
  const response = await API.put(`/vehiclemake/${make.id}`, make);
  return response.status;
};

export const deleteVehicleMake = async (id: number) => {
  const response = await API.delete(`/vehiclemake/${id}`);
  return response.status;
};
