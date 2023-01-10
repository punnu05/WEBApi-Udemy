import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import{MatInputModule} from '@angular/material/input';
import { EmployeeComponent } from './employee/employee.component';
import { DepartmentComponent } from './department/department.component';
import { ShowDeptComponent } from './department/show-dept/show-dept.component';
import { EditDeptComponent } from './department/edit-dept/edit-dept.component';
import { AddDeptComponent } from './department/add-dept/add-dept.component';
import { AddEmpComponent } from './employee/add-emp/add-emp.component';
import { EditEmpComponent } from './employee/edit-emp/edit-emp.component';
import { ShowEmpComponent } from './employee/show-emp/show-emp.component'
import { EmployeeService } from './servises/employee.service';
import { DepartmentService } from './servises/department.service';


// import { MdButtonModule, MdCardModule, MdMenuModule, MdToolbarModule
//    MdIconModule, MatAutocompleteModule,
//    ,MatFormFieldModule } from '@angular/material';


@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    DepartmentComponent,
    ShowDeptComponent,
    EditDeptComponent,
    AddDeptComponent,
    AddEmpComponent,
    EditEmpComponent,
    ShowEmpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule
  ],
  providers: [EmployeeService,DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
