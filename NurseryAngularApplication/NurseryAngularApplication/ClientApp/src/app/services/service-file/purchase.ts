export class Nursery implements INursery {

  id: number;
  nurseryName: string;
  firstName: string;
  middleName: string;
  lastName: string;
  stateId: number;
  districtId: number;
  emailId: string;
  contactNumber: number;
  creationDate: string;
  tehsilId: number;
  villageName: string;

  constructor(data?: INursery) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }

}

export interface INursery {
  id: number;
  nurseryName: string;
  firstName: string;
  middleName: string;
  lastName: string;
  stateId: number;
  districtId: number;
  emailId: string;
  contactNumber: number;
  creationDate: string;
  tehsilId: number;
  villageName: string;
}
