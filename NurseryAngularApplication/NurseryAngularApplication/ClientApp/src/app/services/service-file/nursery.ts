export class NurseryDto {

  Id: number;
  NurseryName: string;
  FirstName: string;
  MiddleName: string;
  LastName: string;
  StateId: number;
  DistrictId: number;
  EmailId: string;
  ContactNumber: number;
  CreationDate: string;
  TehsilId: number;
  VillageName: string;

  //constructor(data?: INurseryDto) {
  //  if (data) {
  //    for (var property in data) {
  //      if (data.hasOwnProperty(property))
  //        (<any>this)[property] = (<any>data)[property];
  //    }
  //  }
  //}

}

//export interface INurseryDto {
//  Id: number;
//  NurseryName: string;
//  FirstName: string;
//  MiddleName: string;
//  LastName: string;
//  StateId: number;
//  DistrictId: number;
//  EmailId: string;
//  ContactNumber: number;
//  CreationDate: string;
//  TehsilId: number;
//  VillageName: string;
//}
