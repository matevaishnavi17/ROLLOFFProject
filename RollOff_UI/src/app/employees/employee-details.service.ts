import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
//import{GetAllEmployeeResponse} from '../Models/api-models/getallstudentresponse.models'
import {Employee} from '../Models/api-models/Employee.models';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  baseApiUrl:string=environment.baseApiUrl;
  constructor(private httpClient:HttpClient) { }

  getEmployee():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.baseApiUrl+'Employees');
  }

  getEmployeebyid(employeeid:string):Observable<Employee>{
    return this.httpClient.get<Employee>(this.baseApiUrl+'Employees/'+employeeid);
  }

  saveFormData(data:any){
    console.log(data);
    return this.httpClient.post(this.baseApiUrl+'api/Form',data);
  }
}
