export class Farmer implements IFarmer {

  id: number;
  nurseryId: number;
  firstName: string;
  middleName: string;
  lastName: string;
  dateTime: string;
  contactNumber: number;
  email: string;
  villageName: string;
  genderType: number;
  educationType: number;
  stateId: number;
  districtId: number;
  tehsilId: number;

  constructor(data?: IFarmer) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

}

export interface IFarmer {
  id: number;
  nurseryId: number;
  firstName: string;
  middleName: string;
  lastName: string;
  dateTime: string;
  contactNumber: number;
  email: string;
  villageName: string;
  genderType: number;
  educationType: number;
  stateId: number;
  districtId: number;
  tehsilId: number;
}
