import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/Models/ui-models/Employee.models';
import { EmployeeDetailsService } from '../employee-details.service';

@Component({
  selector: 'app-view-employee',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.css']
})
export class ViewEmployeeComponent implements OnInit {
  employeeId:string|null|undefined;
  employee:Employee={
    globalGroupID:0 ,
    employeeNo: 0,
    name: '',
    localGrade: '',
    mainClient: '',
    email: '',
    joiningDate:new Date,
    projectCode:0 ,
    projectName: '',
    projectStartDate:new Date,
    projectEndDate: new Date,
    peopleManager: '',
    practice: '',
    pspName: '',
    newGlobalPractice: '',
    officeCity: '',
    country: ''
  }
  constructor(private readonly employeeservice:EmployeeDetailsService,private readonly route:ActivatedRoute,
    private readonly router:Router){}
  

  
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params)=>{
        this.employeeId=params.get('id');
        if(this.employeeId){
          this.employeeservice.getEmployeebyid(this.employeeId)
          .subscribe(
            (successResponse)=>{
              this.employee=successResponse;
              
            }

          );
        }
      }
    );

    
  }
}
