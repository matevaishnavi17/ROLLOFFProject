import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDetailsService } from '../employees/employee-details.service';
import { Employee } from '../Models/ui-models/Employee.models';

@Component({
  selector: 'app-feedback-form',
  templateUrl: './feedback-form.component.html',
  styleUrls: ['./feedback-form.component.css']
})

export class FeedbackFormComponent {
  
  constructor(private employeeService:EmployeeDetailsService,
    private readonly route:ActivatedRoute){}

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

ngOnInit(): void {
  this.route.paramMap.subscribe(
    (params)=>{
      this.employeeId=params.get('id');
      if(this.employeeId){
        this.employeeService.getEmployeebyid(this.employeeId)
        .subscribe(
          (successResponse)=>{
            this.employee=successResponse;
            console.log(this.employee)
            this.addForms.controls.globalGroupId.setValue(this.employee.globalGroupID);
            this.addForms.controls.name.setValue(this.employee.name);
            this.addForms.controls.projectCode.setValue(this.employee.projectCode);
            this.addForms.controls.practice.setValue(this.employee.practice);
            this.addForms.controls.projectName.setValue(this.employee.projectName);
            this.addForms.controls.localGrade.setValue(this.employee.localGrade);
            this.addForms.controls.employeeNo.setValue(this.employee.employeeNo);
            
          }
        );
      }
    }
  );
}

addForms = new FormGroup({
  globalGroupId : new FormControl(0),
  employeeNo: new FormControl(0),
  name : new FormControl(''),
  practice : new FormControl(''),
  performanceIssue : new FormControl(''),
  technicalSkills : new FormControl(''),
  localGrade : new FormControl(''),
  rollOffEndDate : new FormControl(''),
  resigned : new FormControl(''),
  communication : new FormControl(''),
  primarySkill : new FormControl(''),
  reasonForRollOff : new FormControl(''),
  underProbation : new FormControl(''),
  roleCompetencies : new FormControl(''),
  projectCode : new FormControl(0),
  longLeave : new FormControl(''),
  remarks : new FormControl(''),
  projectName : new FormControl(''),
  thisReleaseNeedsBackfillIsBackfilled : new FormControl(''),
  relevantExperienceYears : new FormControl(0),

  //leaveType : new FormControl(''),
  //otherReasons : new FormControl('')
}
);

get GGID(){
  return this.addForms.get('globalGroupId') as FormControl;
}

   

SaveData(){

  console.log(this.addForms.value);
  this.employeeService.saveFormData(this.addForms.value).subscribe((result)=>{
    console.log(result);
    alert("Submitted ");
  });
}


}
