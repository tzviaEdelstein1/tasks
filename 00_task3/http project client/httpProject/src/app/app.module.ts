import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '../../node_modules/@angular/forms';
import { AddUserService } from './shared/services/add-user.service';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,FormsModule, ReactiveFormsModule,HttpClientModule
  ],
  providers: [AddUserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
