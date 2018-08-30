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
  constructor(private packageService:PackageService) { 
    this.packageService.subject.subscribe(
    {
      next: (v:string) =>{this.inputValue=v;
      packageService.getPackage(v).subscribe(
res=>{console.log(res)

this.listPackage=res;
}
);
      }
    }); 
  this.packageService.dateSubjevt.subscribe(
{
next:(v:Date[])=>{
  console.log(v[0],v[1]);
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
