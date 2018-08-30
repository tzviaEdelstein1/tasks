import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class PackageService {

  constructor(private http: HttpClient) { }
  subject = new Subject();
dateSubjevt=new Subject();

  getPackage(input:string):Observable<any>{
  
  // let url=`https://api.npms.io/v2/search/suggestions?q=${input}&size=40`;
 
return this.http.get(`https://api.npms.io/v2/search/suggestions?q=${input}&size=40`);


  }
  getDownload(name:string,dates:Date[])
  {
return this.http.get(`https://api.npmjs.org/downloads/point/${dates[0]}:${dates[1]}/${name}`);

  }
}
