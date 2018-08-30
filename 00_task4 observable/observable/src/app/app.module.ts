import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TimeRangeComponent } from './components/time-range/time-range.component';
import { PackageComponent } from './components/package/package.component';
import { PackageListComponent } from './components/package-list/package-list.component';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    TimeRangeComponent,
    PackageComponent,
    PackageListComponent
  ],
  imports: [
    BrowserModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
