import { Component, OnInit } from '@angular/core';
import { PackageService } from '../../shared/services/package.service';

@Component({
  selector: 'app-package-list',
  templateUrl: './package-list.component.html',
  styleUrls: ['./package-list.component.css']
})
export class PackageListComponent implements OnInit {
inputValue:string="";
listPackage:any[]=[];
dates:Date[]=[];
  constructor(private packageService:PackageService) { 
    this.packageService.subject.subscribe(
    {
      next: (v:string) =>{this.inputValue=v;
      packageService.getPackage(v).subscribe(
res=>{console.log(res)

this.listPackage=res;
if(this.dates.length==2)
{for(let i=0;i<this.listPackage.length;i++)
  {
    this.packageService.getDownload(this.listPackage[i]["package"].name,this.dates).subscribe(
      res=>{
  
        this.listPackage[i]["package"].downloads=res["downloads"];
      }
    )
  }}
}
);
      }
    }); 
  this.packageService.dateSubjevt.subscribe(
{
next:(v:Date[])=>{
  this.dates=v;

for(let i=0;i<this.listPackage.length;i++)
{
  this.packageService.getDownload(this.listPackage[i]["package"].name,v).subscribe(
    res=>{

      this.listPackage[i]["package"].downloads=res["downloads"];
    }
  )
}

}

}
  
  )
  }
 
  ngOnInit() {
  }

}
