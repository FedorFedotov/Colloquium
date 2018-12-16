
import { AppComponent } from './app.component';
import { MainComponent } from './components/main/main.component';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { HttpModule, JsonpModule, XHRBackend } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes, RouterLinkActive } from '@angular/router';

import { HttpClientModule } from '@angular/common/http';

//import { MatButtonModule, MatCheckboxModule, MatToolbarModule, MatSidenavModule, MatIconModule, MatListModule, MatGridListModule, MatCardModule, MatMenuModule, MatTableModule, MatPaginatorModule, MatSortModule } from '@angular/material';
//import { NavComponent } from './components/nav/nav.component';
//import { LayoutModule } from '@angular/cdk/layout';
//import { DashboardComponent } from './components/dashboard/dashboard.component';
//import { TableComponent } from './components/table/table.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FacultiesComponent } from './components/faculties/faculties.component';
import { GroupsComponent } from './components/groups/groups.component';
import { TimetablesComponent } from './components/timetables/timetables.component';
import { ChatsComponent } from './components/chats/chats.component';
import { FacultyComponent } from './components/faculty/faculty.component';
import { GroupComponent } from './components/group/group.component';
import { TimetableComponent } from './components/timetable/timetable.component';
import { ChatComponent } from './components/chat/chat.component';
import { TeachersComponent } from './components/teachers/teachers.component';
import { TeacherComponent } from './components/teacher/teacher.component';
import { LoginComponent } from './components/login/login.component';


const appRoutes: Routes = [
  {
    path: '', component: MainComponent ,
    children: [
      { path: '', redirectTo: 'companies', pathMatch: 'full' },
      { path: 'companies', component: GroupsComponent },
      { path: 'faculties', component: FacultiesComponent },
      { path: 'jobs', component: TimetablesComponent },
      { path: 'tasks', component: ChatsComponent } ,
      { path: 'profile', component: LoginComponent }   
    ]   
  }
];



@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    FacultiesComponent,
    GroupsComponent,
    TimetablesComponent,
    ChatsComponent,
    FacultyComponent,
    GroupComponent,
    TimetableComponent,
    ChatComponent,
    TeachersComponent,
    TeacherComponent,
    LoginComponent,
    //NavComponent,
    //DashboardComponent,
    //TableComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    HttpModule,
    JsonpModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes, { useHash: true }),
    NgbModule.forRoot(),
    //LayoutModule,
    //MatToolbarModule,
    //MatButtonModule,
    //MatSidenavModule,
    //MatIconModule,
    //MatListModule,
    //MatGridListModule,
    //MatCardModule,
    //MatMenuModule,
    //MatTableModule,
    //MatPaginatorModule,
    //MatSortModule,
  ],
  exports: [
    RouterModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
  providers: [
     DatePipe,
  ]
})
export class AppModule { }
