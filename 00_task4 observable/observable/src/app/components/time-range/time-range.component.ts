import { Component, OnInit } from '@angular/core';
import { PackageService } from '../../shared/services/package.service';

@Component({
  selector: 'app-time-range',
  templateUrl: './time-range.component.html',
  styleUrls: ['./time-range.component.css']
})
export class TimeRangeComponent implements OnInit {
startDate:Date;
endDate:Date;
dateArray:Date[]=[];
  constructor(private packageService:PackageService) { 
    this.dateArray[0]= new Date('1900/01/01');
    this.dateArray[1]=new Date(Date.now());
  }
  start(value){
this.dateArray[0]=value;
this.packageService.dateSubjevt.next(this.dateArray);

  }
  end(value){
this.dateArray[1]=value;
this.packageService.dateSubjevt.next(this.dateArray);

  }
  ngOnInit() {
  }

}
