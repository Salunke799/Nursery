export class Employee implements IEmployee {

  id: number;
  nurseryId: number;
  firstName: string;
  middleName: string;
  lastName: string;
  dateofBirth: string;
  contactNumber: string;
  email: string;
  villageName: string;
  genderType: number;
  educationType: number;
  stateId: number;
  districtId: number;
  tehsilId: number;

  constructor(data?: IEmployee) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

}

export interface IEmployee {
  id: number;
  nurseryId: number;
  firstName: string;
  middleName: string;
  lastName: string;
  dateofBirth: string;
  contactNumber: string;
  email: string;
  villageName: string;
  genderType: number;
  educationType: number;
  stateId: number;
  districtId: number;
  tehsilId: number;
}
