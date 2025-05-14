export interface VehicleMake {
  id: number;
  name: string;
  abrv: string;
}

export interface PagedResult<T> {
  items: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}
