import { Vehicle } from './vehicle.model'
export interface Checklist {
  checklistID: number;
  tires: boolean;
  lights: boolean;
  breaks: boolean;
  engine: boolean;
  electric: boolean;
  observation: string;
  vehicleID: number;
  vehicle: Vehicle;
}
